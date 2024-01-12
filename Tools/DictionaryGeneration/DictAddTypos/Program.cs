using CommandLine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace DictTransformation
{
    class Program
    {
        private readonly static Regex _specialCharactersRegex = new Regex("^[a-zA-Z0-9_]*$", RegexOptions.Compiled);

        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args).WithParsed((o) =>
            {
                if (string.IsNullOrEmpty(o.OutputFile))
                {
                    o.OutputFile = $"{o.InputFile}_new.dic";
                }

                var words = File.ReadAllLines(o.InputFile);
                var splitChars = o.SplitChars.Split('|');
                var forbiddenNumbers = o.RemoveNbrCharWords.Split(",", StringSplitOptions.RemoveEmptyEntries).Select(p => Convert.ToInt32(p));

                var output = new HashSet<string>();

                foreach (var inputWord in words)
                {
                    string inputLwWord = inputWord.ToLower();

                    if (string.IsNullOrEmpty(inputLwWord))
                        continue;

                    var splitWords = SplitWords(new string[1] { inputLwWord }, splitChars, 0).Distinct();
                    if (o.RemoveHex)
                        splitWords = splitWords.Where(p => !p.StartsWith("0x"));

                    foreach (var splitWord in splitWords)
                    {
                        var word = splitWord;

                        //Digits
                        if (o.RemoveDigits && word.Any(char.IsDigit))
                            continue;

                        //Digits but save
                        if (o.RemoveDigitsButKeepWords && word.Any(char.IsDigit))
                            word = string.Concat(word.Where(char.IsLetter));

                        //Special
                        if (o.RemoveSpecials && !_specialCharactersRegex.IsMatch(word))
                            continue;

                        if (string.IsNullOrEmpty(word))
                            continue;

                        var badNbrChars = false;
                        foreach (var forbiddenNumber in forbiddenNumbers)
                        {
                            if (word.Length == forbiddenNumber)
                            {
                                badNbrChars = true;
                                break;
                            }
                        }
                        if (badNbrChars)
                            continue;

                        //Special but save
                        if (o.RemoveSpecials && !_specialCharactersRegex.IsMatch(word))
                            word = Regex.Replace(word, @"[^0-9a-zA-Z]+", "", RegexOptions.Compiled);

                        if (o.InsertTypoLR)
                        {
                            var allNewWords = Combinations(word, 'l', 'r');
                            foreach (var newWord in allNewWords)
                            {
                                if (!output.Contains(newWord))
                                    output.Add(newWord);
                            }
                        }
                        else
                        {
                            if (!output.Contains(word))
                                output.Add(word);
                        }
                    }
                }

                File.WriteAllLines(o.OutputFile, output.OrderBy(p => p));
            });
        }

        private static IEnumerable<string> SplitWords(IEnumerable<string> input, string[] splitChar, int currentIndex)
        {
            if (currentIndex < splitChar.Length)
            {
                input = input.SelectMany(p => p.Split(splitChar[currentIndex], System.StringSplitOptions.RemoveEmptyEntries));
                return SplitWords(input, splitChar, currentIndex + 1);
            }
            return input;
        }

        private static IEnumerable<string> Combinations(string input, char char1, char char2)
        {
            var head = input[0] == char1 || input[0] == char2
                ? new[] { char1.ToString(), char2.ToString() }
                : new[] { input[0].ToString() };

            var tails = input.Length > 1
                ? Combinations(input.Substring(1), char1, char2)
                : new[] { "" };

            return
                from h in head
                from t in tails
                select h + t;
        }
    }
}

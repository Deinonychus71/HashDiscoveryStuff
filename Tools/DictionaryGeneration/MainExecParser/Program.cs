using CommandLine;
using HashCommon;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace MainExecParser
{
    class Program
    {
        private readonly static char[] _trimEnd = new[] { ',', '\"', '\'', ';', ')' };
        private readonly static char[] _trimEndPlusDigits = new[] { ',', '\"', '\'', ';', ')', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        private readonly static char[] _trimStart = new[] { '*', '(', '\"', '\'', ',' };
        private readonly static string[] _validOperatorsHash = new [] { "==", "!=" };
        private readonly static string[] _filterPreviousWord = new[] { "LAB", "FUN", "DAT", "joined" };
        private readonly static string[] _filterFinalWord = new[] { "aaa", "bbb", "ccc", "ddd", "eee", "fff", "ppp" };
        private readonly static Regex _regOnlyDigits = new Regex(@"^[0-9]+$", RegexOptions.Compiled);

        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args).WithParsed((o) =>
            {
                if (File.Exists(o.MainFilePath))
                {
                    var blackList = File.ReadAllLines("blacklist.txt");
                    var blackListStartWith = File.ReadAllLines("blacklistStartWith.txt");
                    var paramLabels = HashHelper.GetParamLabels(o.ParamLabelsFile);
                    var output = new List<string>();

                    using (StreamWriter wr = new StreamWriter(o.OutputSolvedHashesFile))
                    {
                        using (StreamReader sr = new StreamReader(o.MainFilePath))
                        {
                            string line;
                            while ((line = sr.ReadLine()) != null)
                            {
                                var lineSplit = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                                for (int i = 0; i < lineSplit.Length; i++)
                                {
                                    var word = lineSplit[i];
                                    var wordTest = word.TrimEnd(_trimEndPlusDigits).TrimStart(_trimStart).TrimEnd(_trimEnd).TrimStart(_trimStart);

                                    if (Regex.Matches(wordTest, @"[a-zA-Z]").Count > 0 && !blackList.Contains(wordTest))
                                    {
                                        var wordProcess = word.TrimEnd(_trimEnd).TrimStart(_trimStart);
                                        var wordsProcess = WordsParsing.SplitWords(Regex.Replace(wordProcess, @"[^\w\d]", "_", RegexOptions.Compiled)).ToArray();

                                        for (int j = 0; j < wordsProcess.Length; j++)
                                        {
                                            var finalWord = wordsProcess[j].TrimEnd(_trimEnd).TrimStart(_trimStart).TrimEnd(_trimEnd).TrimStart(_trimStart);
                                            var previousWord = j > 0 ? wordsProcess[j - 1].TrimStart(_trimStart).TrimEnd(_trimEnd).TrimStart(_trimStart) : string.Empty;

                                            if (_filterPreviousWord.Contains(previousWord) || blackListStartWith.Any(o => finalWord.StartsWith(o)))
                                                continue;

                                            //Check hashes
                                            if (finalWord.StartsWith("0x"))
                                            {
                                                var hexValue = finalWord;
                                                if (finalWord.Length == 12 || finalWord.Length == 11)
                                                {
                                                    try
                                                    {
                                                        var value = Convert.ToUInt64(hexValue, 16);

                                                        if (paramLabels.ContainsKey(value))
                                                        {
                                                            var valueStr = paramLabels[value];
                                                            line = line.Replace(hexValue, $"\"{valueStr}\"");
                                                        }

                                                        /*if (_validOperatorsHash.Contains(previousWord) && !finalWord.Contains("000") && !finalWord.Contains("fff"))
                                                        {
                                                            Console.WriteLine(finalWord);
                                                        }*/
                                                    }
                                                    catch { }
                                                }
                                                continue;
                                            }

                                            //Check words
                                            var finalWord2 = Regex.Replace(finalWord, @"[^a-zA-Z]", "_", RegexOptions.Compiled);
                                            foreach (var nonDigitWord in finalWord2.Split('_', StringSplitOptions.RemoveEmptyEntries))
                                            {
                                                if (nonDigitWord.Length > 1 && !blackList.Contains(nonDigitWord) && !blackList.Contains(nonDigitWord))
                                                {
                                                    var splitWords = WordsParsing.CaseSplitter(nonDigitWord);
                                                    foreach (var splitWord in splitWords)
                                                    {
                                                        if (splitWord.Length > 1 && !_filterFinalWord.Any(p => splitWord.Contains(p)))
                                                        {
                                                            output.Add(splitWord);
                                                        }
                                                    }

                                                }
                                            }
                                        }
                                    }
                                }

                                wr.WriteLine(line);
                            }
                        }
                    }

                    File.WriteAllLines(o.OutputDictFile, output.Distinct().OrderBy(p => p).ToArray());
                    File.WriteAllLines(o.OutputDictLowerFile, output.Select(p => p.ToLower()).Distinct().OrderBy(p => p).ToArray());
                }
            });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BruteForceHash.Helpers
{
    public class TyposGenerator
    {
        private readonly Options _options;
        private readonly List<Tuple<char, char>> _letterSwapPatterns;
        private readonly List<string> _letterAppendPatterns;

        public TyposGenerator(Options options)
        {
            _options = options;

            _letterSwapPatterns = [];
            if (!string.IsNullOrEmpty(_options.TyposEnableLetterSwap))
            {
                foreach (var pattern in _options.TyposEnableLetterSwap.Split(",", StringSplitOptions.RemoveEmptyEntries))
                {
                    var split = pattern.Trim().Split("-", StringSplitOptions.RemoveEmptyEntries);
                    if (split.Length == 2 && split[0].Trim().Length > 0 && split[1].Trim().Length > 0)
                        _letterSwapPatterns.Add(new Tuple<char, char>(split[0].Trim()[0], split[1].Trim()[0]));
                }
            }

            _letterAppendPatterns = [];
            if (!string.IsNullOrEmpty(_options.TyposEnableAppendLetters))
            {
                foreach (var pattern in _options.TyposEnableAppendLetters.Split(",", StringSplitOptions.RemoveEmptyEntries))
                {
                    _letterAppendPatterns.Add(pattern.Trim());
                }
            }
        }

        public IEnumerable<string> GenerateTypos(string word)
        {
            var typo = new List<string>();
            var wordLength = word.Length;

            if (wordLength < 2)
                return typo;

            var qwertyKeyboard = GetKeyboardMapping();

            for (var j = wordLength - 1; j >= 0; j--)
            {
                if (_options.TyposEnableSkipLetter)
                    typo.Add(string.Concat(word.AsSpan(0, j), word.AsSpan(j + 1))); // Skip letter
                else if (_options.TyposEnableSkipDoubleLetter && j > 0 && word[j] == word[j - 1])
                    typo.Add(string.Concat(word.AsSpan(0, j), word.AsSpan(j + 1))); // Skip double letter
                if (_options.TyposEnableDoubleLetter)
                    typo.Add(word.Insert(j, word[j].ToString())); // Double Letter

                var keyboardChars = IsItemInArrayNearest(qwertyKeyboard, word[j]);
                // Extra Letter & Wrong letter
                for (var k = 0; k < keyboardChars.Count; k++)
                {
                    if (_options.TyposEnableExtraLetter)
                        typo.Add(word.Insert(j, keyboardChars[k].ToString())); // Extra letter
                    if (_options.TyposEnableWrongLetter)
                        typo.Add(word[..j] + keyboardChars[k] + word[(j + 1)..]); //Wrong letter
                }

                if (_options.TyposEnableReverseLetter)
                {
                    // Reverse letters
                    if (wordLength > j + 1)
                    {
                        var tempChar = word[j];
                        var tempChar2 = word[j + 1];
                        var reversedWord = SwapCharacter(word, tempChar, j + 1);
                        reversedWord = SwapCharacter(reversedWord, tempChar2, j);
                        typo.Add(reversedWord);
                    }
                }
            }

            if (_letterSwapPatterns.Count > 0)
            {
                foreach (var letterSwapPattern in _letterSwapPatterns)
                {
                    typo.AddRange(GenerateLetterSwapTypos(word, letterSwapPattern.Item1, letterSwapPattern.Item2));
                }
            }
            if (_letterAppendPatterns.Count > 0)
            {
                foreach (var letterAppendPattern in _letterAppendPatterns)
                {
                    if (!word.EndsWith(letterAppendPattern))
                        typo.Add($"{word}{letterAppendPattern}");
                }
            }

            return typo;
        }

        private static IEnumerable<string> GenerateLetterSwapTypos(string input, char char1, char char2)
        {
            var head = input[0] == char1 || input[0] == char2
                ? new[] { char1.ToString(), char2.ToString() }
                : new[] { input[0].ToString() };

            var tails = Encoding.UTF8.GetByteCount(input) > 1
                ? GenerateLetterSwapTypos(input[1..], char1, char2)
                : new[] { "" };

            return
                from h in head
                from t in tails
                select h + t;
        }

        private static string SwapCharacter(string input, char insertChar, int index)
        {
            string f = input[..index];
            string l = input[(index + 1)..];

            return f + insertChar + l;
        }

        private static char[][] GetKeyboardMapping()
        {
            var keyboardMapping = new char[3][];
            keyboardMapping[0] = ['q', 'w', 'e', 'r', 't', 'y', 'u', 'i', 'o', 'p'];
            keyboardMapping[1] = ['a', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l'];
            keyboardMapping[2] = ['z', 'x', 'c', 'v', 'b', 'n', 'm'];
            return keyboardMapping;
        }

        private static bool IsArraySizeValid<T>(IEnumerable<T> array, int size)
        {
            return size >= 0 && array.Count() > size;
        }

        private static List<char> IsItemInArrayNearest(char[][] keyboard, char character)
        {
            var nearKeys = new List<char>();
            for (var i = 0; i < keyboard.Length; i++)
            {
                for (var j = 0; j < keyboard[i].Length; j++)
                {
                    if (keyboard[i][j] == character)
                    {
                        if (IsArraySizeValid(keyboard, i) && IsArraySizeValid(keyboard[i], j + 1))
                        {
                            nearKeys.Add(keyboard[i][j + 1]);
                        }
                        if (IsArraySizeValid(keyboard, i + 1) && IsArraySizeValid(keyboard[i + 1], j))
                        {
                            nearKeys.Add(keyboard[i + 1][j]);
                        }
                        if (IsArraySizeValid(keyboard, i + 1) && IsArraySizeValid(keyboard[i + 1], j + 1))
                        {
                            nearKeys.Add(keyboard[i + 1][j + 1]);
                        }
                        if (IsArraySizeValid(keyboard, i) && IsArraySizeValid(keyboard[i], j - 1))
                        {
                            nearKeys.Add(keyboard[i][j - 1]);
                        }
                        if (IsArraySizeValid(keyboard, i - 1) && IsArraySizeValid(keyboard[i - 1], j - 1))
                        {
                            nearKeys.Add(keyboard[i - 1][j - 1]);
                        }
                        if (IsArraySizeValid(keyboard, i - 1) && IsArraySizeValid(keyboard[i - 1], j))
                        {
                            nearKeys.Add(keyboard[i - 1][j]);
                        }
                        if (IsArraySizeValid(keyboard, i - 1) && IsArraySizeValid(keyboard[i - 1], j + 1))
                        {
                            nearKeys.Add(keyboard[i - 1][j + 1]);
                        }
                        if (IsArraySizeValid(keyboard, i + 1) && IsArraySizeValid(keyboard[i + 1], j - 1))
                        {
                            nearKeys.Add(keyboard[i + 1][j - 1]);
                        }
                    }
                }
            }
            return nearKeys;
        }

        private static string RemoveConsLetterDuplicates(string input)
        {
            if (input.Length <= 1)
                return input;
            if (input[0] == input[1])
                return RemoveConsLetterDuplicates(input[1..]);
            else
                return input[0] + RemoveConsLetterDuplicates(input[1..]);
        }
    }
}

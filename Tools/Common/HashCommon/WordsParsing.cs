using System;
using System.Collections.Generic;
using System.Linq;

namespace HashCommon
{
    public static class WordsParsing
    {
        private readonly static char[] _splitChars = new[] { ',', '.', '\\', '/', '_', '(',')' };

        public static IEnumerable<string> SplitWords(string input, int currentIndex = 0)
        {
            return SplitWords(new string[] {input}, currentIndex);
        }

        public static IEnumerable<string> SplitWords(IEnumerable<string> input, int currentIndex = 0)
        {
            if (currentIndex < _splitChars.Length)
            {
                input = input.SelectMany(p => p.Split(_splitChars[currentIndex], System.StringSplitOptions.RemoveEmptyEntries));
                return SplitWords(input, currentIndex + 1);
            }
            return input;
        }

        public static string[] CaseSplitter(string stringToSplit)
        {
            if (!string.IsNullOrEmpty(stringToSplit))
            {
                List<string> words = new List<string>();

                string temp = string.Empty;

                foreach (char ch in stringToSplit)
                {
                    if (ch >= 'a' && ch <= 'z')
                        temp = temp + ch;
                    else
                    {
                        words.Add(temp);
                        temp = string.Empty + ch;
                    }
                }
                words.Add(temp);
                return words.ToArray();
            }
            else
                return null;
        }
    }
}

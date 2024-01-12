using System.Collections.Generic;
using System.Linq;

namespace HashCommon
{
    public static class WordsParsing
    {
        private readonly static char[] _splitChars = new[] { ',', '.', '\\', '/', '_', '(', ')' };

        public static IEnumerable<string> SplitWords(string input, int currentIndex = 0)
        {
            return SplitWords(new string[] { input }, currentIndex);
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

        public static IEnumerable<string> GetAllWords(IEnumerable<string> lines, bool skipDigits = false, int minLength = -1, int maxLength = -1, bool keepDouble = false)
        {
            var output = new List<string>();
            foreach (var line in lines)
            {
                var splitWords = SplitWords(new string[1] { line }, 0).Distinct();
                foreach (var splitWord in splitWords)
                {
                    if (minLength != -1 && splitWord.Length < minLength)
                        continue;

                    if (maxLength != -1 && splitWord.Length > maxLength)
                        continue;

                    if (skipDigits && !splitWord.All(char.IsLetter))
                        continue;

                    if (keepDouble || (!keepDouble && !output.Contains(splitWord)))
                        output.Add(splitWord);
                }
            }
            return output;
        }
    }
}

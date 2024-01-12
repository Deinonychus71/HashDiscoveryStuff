using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BruteForceHash.CombinationGenerator
{
    public class CombinationGeneratorHybrid : CombinationGeneratorBase
    {
        private char[] _startingChars;

        public CombinationGeneratorHybrid(Options options, int stringLength) :
            base(options, stringLength)
        {
            _startingChars = options.ValidStartingChars.ToCharArray();
        }

        public override byte[] CompileCombination(string combinationPattern)
        {
            var bytes = new List<byte>();
            var index = 0;
            while (index < combinationPattern.Length)
            {
                var chara = combinationPattern[index];
                if (chara == '{')
                {
                    index++;
                    bytes.Add(0);
                    var valueStr = combinationPattern.Substring(index, combinationPattern.Substring(index).IndexOf('}'));
                    bytes.Add(Convert.ToByte(valueStr));
                    index += valueStr.Length + 1;
                }
                else
                {
                    index++;
                    bytes.Add(Encoding.UTF8.GetBytes(new char[] { chara })[0]);
                }
            }
            return bytes.ToArray();
        }

        public override byte[] CompileCombinationJoin(string combinationPattern)
        {
            return CompileCombination(combinationPattern);
        }

        public override IEnumerable<string> GenerateCombinations(int stringLength, string customWordsDictionariesPaths, int combinationDeepLevel)
        {
            IEnumerable<List<string>> combinationsCustom = GenerateWordCombinations(stringLength, customWordsDictionariesPaths, combinationDeepLevel);
            var hasCombinationsCustom = combinationsCustom.Any();

            //Sorting
            switch (_options.Order.ToLower())
            {
                case "more_words_first":
                    combinationsCustom = combinationsCustom.OrderBy(p => p.Sum(x => x.Length));
                    break;
                case "fewer_words_first":
                    combinationsCustom = combinationsCustom.OrderByDescending(p => p.Sum(x => x.Length));
                    break;
            }

            var output = new List<string>();
            if (hasCombinationsCustom)
            {
                foreach (var combinationCustom in combinationsCustom)
                {
                    GenerateCombinationsRec(output, combinationCustom, combinationCustom.Count, string.Empty, stringLength, true);
                }
            }
            else
            {
                GenerateCombinationsRec(output, new List<string>(), 0, string.Empty, stringLength, true);
            }

            //Sorting Interval
            if (_options.Order == "interval")
            {
                output = OrderList(output, _options.OrderLongerWordsFirst);
            }

            //Filters
            var output2 = new List<string>();
            var excludePatterns = _options.ExcludePatterns.Split(",", StringSplitOptions.RemoveEmptyEntries);
            var includePatterns = _options.IncludePatterns.Split(",", StringSplitOptions.RemoveEmptyEntries);
            if (excludePatterns.Length > 0 || includePatterns.Length > 0)
            {
                foreach (var combination in output.Select(p => $"${p}^"))
                {
                    if (!excludePatterns.Any(p => combination.Contains(p)) &&
                        (includePatterns.Length == 0 || includePatterns.All(p => combination.Contains(p))))
                    {
                        output2.Add(combination.TrimStart('$').Trim('^'));
                    }

                }
                output = output2;
            }

            return output;
        }

        private void GenerateCombinationsRec(List<string> output, IEnumerable<string> words, int nbrWords, string combination, int stringLength, bool isFirst)
        {
            for (int i = 0; i < stringLength; i++)
            {
                foreach (var word in words)
                {
                    if (isFirst && i == 0 && !_startingChars.Contains(word[0]))
                        continue;

                    var newIndex = stringLength - i;

                    if (newIndex >= word.Length)
                    {
                        if (nbrWords > 1)
                        {
                            string newCombination = i > 0 ? $"{combination}{{{i}}}{word}" : $"{combination}{word}";
                            GenerateCombinationsRec(output, words.Except(new[] { word }), nbrWords - 1, newCombination, newIndex - word.Length, false);
                        }
                        else
                        {
                            newIndex -= word.Length;
                            if (newIndex > 0)
                            {
                                string newCombination = i > 0 ? $"{combination}{{{i}}}{word}{{{newIndex}}}" : $"{combination}{word}{{{newIndex}}}";
                                output.Add(newCombination);
                            }
                            else
                            {
                                string newCombination = i > 0 ? $"{combination}{{{i}}}{word}" : $"{combination}{word}";
                                output.Add(newCombination);
                            }
                        }
                    }
                }
            }
        }
    }
}

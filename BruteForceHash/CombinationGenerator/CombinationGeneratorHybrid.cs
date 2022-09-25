using BruteForceHash.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

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
            //Get combinations of custom words
            List<List<string>> combinationsCustom = new List<List<string>>();
            if (combinationDeepLevel > 0 && !string.IsNullOrEmpty(customWordsDictionariesPaths))
            {
                var splitPaths = customWordsDictionariesPaths.Split(";", StringSplitOptions.RemoveEmptyEntries);
                var allCustomWords = new List<string>();
                foreach (var dictPath in splitPaths)
                {
                    if (File.Exists(dictPath))
                    {
                        allCustomWords.AddRange(File.ReadAllLines(dictPath));
                    }
                }
                allCustomWords = allCustomWords.Distinct().ToList();
                combinationsCustom = allCustomWords.Combinations(combinationDeepLevel).ToList();
            }
            var hasCombinationsCustom = combinationsCustom.Count > 0;

            //Get include word
            var includeWords = _options.IncludeWord.Split(",", StringSplitOptions.RemoveEmptyEntries);
            if (includeWords.Length > 0)
            {
                if (hasCombinationsCustom)
                {
                    for (var i = 0; i < combinationsCustom.Count; i++)
                    {
                        combinationsCustom[i].AddRange(includeWords);
                        combinationsCustom[i] = combinationsCustom[i].Distinct().ToList();
                    }
                }
                else
                {
                    combinationsCustom.Add(includeWords.Distinct().ToList());
                }
            }
            hasCombinationsCustom = combinationsCustom.Count > 0;

            var filteredCombinationsCustom = combinationsCustom.Where(p => { 
                var sum = stringLength - p.Sum(x => x.Length); 
                return sum <= _options.HybridMaxCharacters && sum >= _options.HybridMinCharacters; 
            });

            //Sorting
            switch (_options.Order.ToLower())
            {
                case "more_words_first":
                    filteredCombinationsCustom = filteredCombinationsCustom.OrderBy(p => p.Sum(x => x.Length));
                    break;
                case "fewer_words_first":
                    filteredCombinationsCustom = filteredCombinationsCustom.OrderByDescending(p => p.Sum(x => x.Length));
                    break;
            }

            var output = new List<string>();
            if (hasCombinationsCustom)
            {
                foreach (var combinationCustom in filteredCombinationsCustom)
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

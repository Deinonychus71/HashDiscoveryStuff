using BruteForceHash.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BruteForceHash.CombinationGenerator
{
    public abstract class CombinationGeneratorBase
    {
        protected readonly Options _options;
        protected readonly int _stringLength;
        private readonly TyposGenerator _typosGenerator;

        public CombinationGeneratorBase(Options options, int stringLength)
        {
            _options = options;
            _stringLength = stringLength;
            _typosGenerator = new TyposGenerator(options);
        }

        public abstract byte[] CompileCombination(string combinationPattern);

        public abstract byte[] CompileCombinationJoin(string combinationPattern);

        public abstract IEnumerable<string> GenerateCombinations(int stringLength, string customWordsDictionariesPaths, int combinationDeepLevel);

        public IEnumerable<byte[]> CompileCombinations(IEnumerable<string> combinationsPattern)
        {
            return combinationsPattern.Select(p => CompileCombination(p));
        }

        public IEnumerable<byte[]> CompileCombinationsJoin(IEnumerable<string> combinationsPattern)
        {
            return combinationsPattern.Select(p => CompileCombinationJoin(p)).Distinct(new SequenceEqualityComparer<byte>());
        }

        public static string DecompileCombination(byte[] compiledCombinationPattern)
        {
            var output = string.Empty;
            for (var i = 0; i < compiledCombinationPattern.Length; i++)
            {
                byte val = compiledCombinationPattern[i];
                if (val == 0)
                {
                    if (i != 0)
                        output += '|';
                    i++;
                    output += $"{{{compiledCombinationPattern[i]}}}";
                }
                else
                {
                    if (i > 1 && compiledCombinationPattern[i - 2] == 0)
                        output += '|';
                    output += Encoding.UTF8.GetString(new byte[1] { val });
                }
            }
            return output;
        }

        protected static List<string> OrderList(List<string> patterns, bool longestWordFirst = false)
        {
            var PatternToScore = new Dictionary<string, double>();

            foreach (var pattern in patterns)
            {
                var tempPattern = pattern;
                var differences = new List<int>();
                int lastInteger = 0;
                while (tempPattern.Contains('{'))
                {
                    int firstOpenBracket = tempPattern.IndexOf('{');
                    int firstCloseBracket = tempPattern.IndexOf('}');
                    var test = tempPattern.Substring(firstOpenBracket + 1, firstCloseBracket - 1);
                    var currentInteger = int.Parse(tempPattern.Substring(firstOpenBracket + 1, firstCloseBracket - firstOpenBracket - 1));
                    if (lastInteger != 0)
                        differences.Add(lastInteger - currentInteger);
                    lastInteger = currentInteger;
                    tempPattern = tempPattern[(firstCloseBracket + 1)..];
                }
                if (differences.Count == 0)
                    PatternToScore.Add(pattern, 1.0);

                else if (differences.Count == 1)
                {
                    PatternToScore.Add(pattern, Math.Min(Math.Abs(differences[0] / 5.0), 1.0));
                }
                else
                {
                    double scoreSum = Math.Min(Math.Abs(differences[0] / 5.0), 1.0);
                    int scoresCounted = 1;
                    for (int i = 1; i < differences.Count - 1; i++)
                    {
                        var tempScore = 0.0;
                        if (differences[i] != 0)
                        {
                            tempScore = 0.5 * Math.Min(Math.Abs(differences[i] / 5.0), 1.0);
                            if (((double)differences[i - 1]) / ((double)differences[i]) < 0)
                                tempScore += 0.5;
                        }
                        scoreSum += tempScore;
                        scoresCounted++;
                    }

                    PatternToScore.Add(pattern, scoreSum / scoresCounted + (longestWordFirst && differences.Sum() < 0 ? Math.Abs(differences.Sum()) * 0.05 : 0));
                }


            }

            var KeyValueList = PatternToScore.ToList();
            KeyValueList.Sort((Pair1, Pair2) => Pair2.Value.CompareTo(Pair1.Value));
            return (from KeyValuePair in KeyValueList select KeyValuePair.Key).ToList();
        }

        protected List<List<string>> GenerateWordCombinations(int stringLength, string customWordsDictionariesPaths, int combinationDeepLevel)
        {
            //Get combinations of custom words
            var combinationsCustom = new List<List<string>>();
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

                if (_options.DictionariesCustomMinWordsHashUseTypos)
                {
                    var allCustomWordsTypos = new List<string>();
                    foreach (var customWord in allCustomWords.Distinct())
                    {
                        allCustomWordsTypos.Add(customWord);
                        allCustomWordsTypos.AddRange(_typosGenerator.GenerateTypos(customWord));
                    }
                    allCustomWords = allCustomWordsTypos;
                }
                else
                {
                    allCustomWords = allCustomWords.Distinct().ToList();
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

            if (_options.Method == "hybrid")
            {
                return combinationsCustom.Where(p =>
                {
                    var sum = stringLength - p.Sum(x => x.Length);
                    return sum <= _options.HybridMaxCharacters && sum >= _options.HybridMinCharacters;
                }).ToList();
            }

            return combinationsCustom;
        }

        private class SequenceEqualityComparer<T> : IEqualityComparer<T[]>
        {
            public bool Equals(T[] a, T[] b)
            {
                if (a == null) return b == null;
                if (b == null) return false;
                return a.SequenceEqual(b);
            }

            public int GetHashCode(T[] val)
            {
                return val.Where(v => v != null)
                        .Aggregate(0, (h, v) => h ^ v.GetHashCode());
            }
        }
    }
}

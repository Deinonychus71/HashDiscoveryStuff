using BruteForceHash.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace BruteForceHash.CombinationGenerator
{
    public class CombinationGeneratorAdvanced : CombinationGeneratorBase
    {
        private readonly string _delimiter;
        private readonly int _delimiterLength;
        private readonly int _minWordLength;
        private readonly int _maxWordLength;
        private readonly int _maxDelimiters;
        private readonly int _minDelimiters;
        private readonly int _maxConsecutives;
        private readonly int _minConsecutives;
        private readonly int _maxWords;
        private readonly int _minWords;
        private readonly int _maxOnes;
        private readonly bool _concatenateOnlyLastTwo;
        private readonly bool _concatenateOnlyFirstTwo;
        private readonly int _minOnes;
        private readonly int _maxTwos;
        private readonly int _minTwos;
        private readonly int _maxThrees;
        private readonly int _minThrees;
        private readonly int _maxFours;
        private readonly int _minFours;
        private readonly int _maxConsecutiveOnes;
        private readonly int _maxConsecutiveConcatenated;
        private readonly int _minConsecutiveConcatenated;

        public CombinationGeneratorAdvanced(Options options, int stringLength) 
            : base(options, stringLength)
        {
            if (string.IsNullOrEmpty(options.Delimiter))
            {
                _delimiter = "|";
                _delimiterLength = 0;
            }
            else
            {
                _delimiter = options.Delimiter;
                _delimiterLength = Encoding.UTF8.GetByteCount(_delimiter);
            }

            _maxDelimiters = options.MaxDelimiters;
            _minDelimiters = options.MinDelimiters;
            _maxConsecutives = options.MaxConcatenatedWords;
            _minConsecutives = options.MinConcatenatedWords;
            _maxWords = options.WordsLimit;
            _minWords = options.MinWordsLimit;
            _concatenateOnlyLastTwo = options.ConcatenateLastTwoWords;
            _concatenateOnlyFirstTwo = options.ConcatenateFirstTwoWords;
            _maxOnes = options.MaxOnes;
            _minOnes = options.MinOnes;
            _maxTwos = options.MaxTwos;
            _minTwos = options.MinTwos;
            _maxThrees = options.MaxThrees;
            _minThrees = options.MinThrees;
            _maxFours = options.MaxFours;
            _minFours = options.MinFours;
            _maxConsecutiveOnes = options.MaxConsecutiveOnes;
            _maxConsecutiveConcatenated = options.MaxConsecutiveConcatenation;
            _minConsecutiveConcatenated = options.MinConsecutiveConcatenation;

            _minWordLength = options.MinWordLength;
            _maxWordLength = Math.Min(options.MaxWordLength, stringLength);
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
                else if (chara == '|')
                {
                    index++;
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
            var bytes = new List<byte>();
            var index = 0;
            while (index < combinationPattern.Length)
            {
                var chara = combinationPattern[index];
                if (chara == '{')
                {
                    while (chara == '{')
                    {
                        index++;
                        var valueStr = combinationPattern.Substring(index, combinationPattern.Substring(index).IndexOf('}'));
                        if (bytes.Count == 0 || bytes[bytes.Count - 2] != 0)
                        {
                            bytes.Add(0);
                            bytes.Add(Convert.ToByte(valueStr));
                        }
                        else
                        {
                            bytes[bytes.Count - 1] += Convert.ToByte(valueStr);
                        }
                        index += valueStr.Length + 1;
                        if (index >= combinationPattern.Length)
                            break;
                        chara = combinationPattern[index];
                        if (chara == '|')
                        {
                            index++;
                            chara = combinationPattern[index];
                        }
                    }

                }
                else if (chara == '|')
                {
                    index++;
                }
                else
                {
                    index++;
                    bytes.Add(Encoding.UTF8.GetBytes(new char[] { chara })[0]);
                }
            }
            return bytes.ToArray();
        }

        public override IEnumerable<string> GenerateCombinations(int stringLength, string customWordsDictionariesPaths, int combinationDeepLevel)
        {
            //Get combinations of custom words
            List<IEnumerable<string>> combinationsCustom = new List<IEnumerable<string>>();
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
            var hasIncludeWords = includeWords.Length > 0;

            var alreadyFoundMap = new Dictionary<int, List<string>>();
            for (var i = 1; i <= stringLength; i++)
            {
                alreadyFoundMap[i] = GenerateValidCombinations(i, alreadyFoundMap, _delimiterLength, 0, _options.OrderLongerWordsFirst, 0);
            }

            //Sorting
            var inputList = Filter(alreadyFoundMap[stringLength]);


            switch (_options.Order.ToLower())
            {
                case "interval":
                    inputList = OrderList(inputList, _options.OrderLongerWordsFirst);
                    break;
                case "fewer_words_first":
                    inputList = inputList.OrderBy(p => p.Length).ToList();
                    break;
                case "more_words_first":
                    inputList = inputList.OrderByDescending(p => p.Length).ToList();
                    break;
            }

            var output = new List<string>();
            var excludePatterns = _options.ExcludePatterns.Split(",", StringSplitOptions.RemoveEmptyEntries);
            var includePatterns = _options.IncludePatterns.Split(",", StringSplitOptions.RemoveEmptyEntries);
            foreach (var combination in inputList.Select(p => $"${p}^"))
            {
                List<string> nbrChar = new List<string>();
                string reducedCombination = combination;
                while (reducedCombination.IndexOf('}') != -1)
                {
                    nbrChar.Add(reducedCombination.Substring(0, reducedCombination.IndexOf('}') + 1));
                    reducedCombination = reducedCombination.Substring(reducedCombination.IndexOf('}') + 1);
                }
                if (nbrChar.Count <= _maxWords &&
                    !excludePatterns.Any(p => combination.Contains(p)) &&
                    (includePatterns.Length == 0 || includePatterns.All(p => combination.Contains(p))))
                {
                    if (hasCombinationsCustom)
                    {
                        foreach (var combinationCustom in combinationsCustom)
                        {
                            if (hasIncludeWords)
                            {
                                var includeWordsAndCombination = combinationCustom.ToList();
                                includeWordsAndCombination.AddRange(includeWords);
                                var wordCandidates = GenerateIncludeWordCombinations(combination, includeWordsAndCombination.Distinct());
                                if (wordCandidates.Count() > 0)
                                {
                                    output.AddRange(wordCandidates);
                                }
                            }
                            else
                            {
                                var wordCandidates = GenerateIncludeWordCombinations(combination, combinationCustom);
                                if (wordCandidates.Count() > 0)
                                {
                                    output.AddRange(wordCandidates);
                                }
                            }
                        }
                    }
                    else if (hasIncludeWords)
                    {
                        var wordCandidates = GenerateIncludeWordCombinations(combination, includeWords);
                        if (wordCandidates != null)
                        {
                            output.AddRange(wordCandidates);
                        }
                    }
                    else
                        output.Add(combination.TrimStart('$').Trim('^'));
                }

            }

            return output.Distinct();
        }

        private IEnumerable<string> GenerateIncludeWordCombinations(string combination, IEnumerable<string> includeWords)
        {
            var wordCandidates = new List<string>() { combination };
            foreach (var includeWord in includeWords)
            {
                var includeWordSize = Encoding.UTF8.GetByteCount(includeWord);
                string combinationMatch;
                string combinationRegexp;
                if (_options.IncludeWordNotFirst && _options.IncludeWordNotLast)
                {
                    combinationMatch = $"{_delimiter}{{{includeWordSize}}}{_delimiter}";
                    combinationRegexp = Regex.Escape($"{_delimiter}{{{includeWordSize}}}{_delimiter}");
                }
                else if (_options.IncludeWordNotLast)
                {
                    combinationMatch = $"{{{includeWordSize}}}{_delimiter}";
                    combinationRegexp = Regex.Escape($"{{{includeWordSize}}}{_delimiter}");
                }
                else if (_options.IncludeWordNotFirst)
                {
                    combinationMatch = $"{_delimiter}{{{includeWordSize}}}";
                    combinationRegexp = Regex.Escape($"{_delimiter}{{{includeWordSize}}}");
                }
                else
                {
                    combinationMatch = $"{{{includeWordSize}}}";
                    combinationRegexp = "\\{" + includeWordSize + "\\}";
                }
                var tempWordCandidates = new List<string>();
                foreach (var wordCandidate in wordCandidates)
                {
                    if (!wordCandidate.Contains(combinationMatch))
                        continue;
                    var nbrMatch = Regex.Matches(wordCandidate, combinationRegexp, RegexOptions.Compiled).Count;
                    for (int i = 0; i < nbrMatch; i++)
                    {
                        tempWordCandidates.Add(ReplaceNthOccurrence(wordCandidate, combinationMatch, includeWord, i + 1));
                    }
                }
                wordCandidates = tempWordCandidates;
            }
            return wordCandidates.Select(p => p.TrimStart('$').Trim('^'));
        }

        private List<string> GenerateValidCombinations(int stringLength, Dictionary<int, List<string>> alreadyFoundMap, int delimiterLength, int wordsSoFar, bool longerWordsFirst, int delimitersSoFar)
        {
            var returnCombinations = new List<string>();
            if (wordsSoFar >= _maxWords && stringLength > 0)
            {
                returnCombinations.Add("invalid");
            }
            else if (stringLength == _minWordLength)
            {
                returnCombinations.Add($"{{{_minWordLength}}}");
            }
            else if (stringLength == 0)
            {
                if (delimiterLength == 0)
                {
                    returnCombinations.Add("ended");
                }
                else
                {
                    returnCombinations.Add("invalid");
                }
            }
            else if (delimiterLength != 0 && stringLength == -1 * delimiterLength)
            {
                returnCombinations.Add("ended");
            }
            else if (delimiterLength != 0 && stringLength < 0 && stringLength != delimiterLength * -1)
            {
                returnCombinations.Add("invalid");
            }

            else
            {
                int i = longerWordsFirst ? Math.Min(_maxWordLength, stringLength) : _minWordLength;
                while ((longerWordsFirst && i >= _minWordLength) || (!longerWordsFirst && i <= Math.Min(_maxWordLength, stringLength)))
                {
                    int remainingLength = stringLength;
                    var pattern = i.ToString();
                    //j= 0 means do not include delimiter, j = 1 means include it (if applicable)
                    for (int j = 0; j < 2; j++)
                    {

                        if (j == 0)
                        {
                            remainingLength = stringLength - i;
                        }

                        var soFar = delimitersSoFar;
                        if (j == 0 || j == 1 && _delimiterLength > 0 && (soFar < _maxDelimiters || _maxDelimiters == -1))
                        {
                            if (j == 1)
                            {
                                remainingLength = remainingLength - _delimiterLength;
                                soFar++;
                            }


                            List<string> subCombinations;
                            if (alreadyFoundMap.ContainsKey(remainingLength))
                            {
                                subCombinations = alreadyFoundMap[remainingLength];
                            }
                            else
                            {
                                subCombinations = GenerateValidCombinations(remainingLength, alreadyFoundMap, delimiterLength, wordsSoFar + 1, longerWordsFirst, soFar);
                            }

                            foreach (var remainingStringPattern in subCombinations)
                            {
                                if (remainingStringPattern == "ended")
                                {
                                    returnCombinations.Add($"{{{pattern}}}");
                                }
                                else if (remainingStringPattern != "invalid" && (Encoding.UTF8.GetByteCount(remainingStringPattern) - Encoding.UTF8.GetByteCount(remainingStringPattern.Replace("{", ""))) + wordsSoFar + 1 <= _maxWords && (_maxDelimiters == -1 || (remainingStringPattern.Length - remainingStringPattern.Replace(_delimiter, "").Length) + soFar <= _maxDelimiters))
                                {
                                    if (j == 1)
                                        returnCombinations.Add($"{{{pattern}}}{_delimiter}{remainingStringPattern}");
                                    else
                                        returnCombinations.Add($"{{{pattern}}}{"|"}{remainingStringPattern}");

                                }
                            }
                        }


                    }
                    if (longerWordsFirst)
                        i--;
                    else
                        i++;
                }

            }
            return returnCombinations;
        }

        private List<string> Filter(List<string> inputList)
        {
            List<string> finalList = new List<string>();
            foreach (string pattern in inputList)
            {
                if (_concatenateOnlyFirstTwo && !(pattern.Length - pattern.Replace("|", "").Length == 1 && (pattern.IndexOf('|') < pattern.IndexOf(_delimiter) || pattern.IndexOf(_delimiter) == -1 || _delimiterLength == 0)))
                    continue;
                if (_concatenateOnlyLastTwo && !(pattern.Length - pattern.Replace("|", "").Length == 1 && (pattern.IndexOf('|') > pattern.LastIndexOf(_delimiter) || _delimiterLength == 0)))
                    continue;
                if (((pattern.Length - pattern.Replace("{1}", "").Length) > _maxOnes * 3 || (pattern.Length - pattern.Replace("{1}", "").Length) < _minOnes * 3))
                    continue;
                if (_delimiterLength > 0 && (pattern.Length - pattern.Replace(_delimiter, "").Length < _minDelimiters))
                    continue;
                if (pattern.Length - pattern.Replace("{", "").Length < _minWords)
                    continue;

                var freqConsecutives = pattern.Split('|').Length - 1;
                if (freqConsecutives < _minConsecutives || freqConsecutives > _maxConsecutives)
                    continue;

                var nbrTwos = pattern.Split("{2}").Length - 1;
                var nbrThrees = pattern.Split("{3}").Length - 1;
                var nbrFours = pattern.Split("{4}").Length - 1;
                if (nbrTwos < _minTwos || nbrTwos > _maxTwos)
                    continue;
                if (nbrThrees < _minThrees || nbrThrees > _maxThrees)
                    continue;
                if (nbrFours < _minFours || nbrFours > _maxFours)
                    continue;
                if (_options.AtLeastAboveWords > 0 || _options.AtLeastUnderWords > 0 || _options.AtMostAboveWords > 0 || _options.AtMostUnderWords > 0)
                {
                    var dictNbr = new int[50];
                    for (var i = 0; i < dictNbr.Length; i++)
                    {
                        dictNbr[i] = pattern.Split("{" + (i + 1) + "}").Length - 1;
                    }
                    if (_options.AtLeastAboveWords > 0 && dictNbr.Where((p, i) => i >= _options.AtLeastAboveChars - 1).Sum() < _options.AtLeastAboveWords)
                        continue;
                    if (_options.AtLeastUnderWords > 0 && dictNbr.Where((p, i) => i <= _options.AtLeastUnderChars - 1).Sum() < _options.AtLeastUnderWords)
                        continue;
                    if (_options.AtMostAboveWords > 0 && dictNbr.Where((p, i) => i >= _options.AtMostAboveChars - 1).Sum() > _options.AtMostAboveWords)
                        continue;
                    if (_options.AtMostUnderWords > 0 && dictNbr.Where((p, i) => i <= _options.AtMostUnderChars - 1).Sum() > _options.AtMostUnderWords)
                        continue;
                }

                string tempPattern = pattern;
                int numberOfConsecutive = 0;
                int numberOfOnes = 0;
                int maxNumberOfConsecutiveWords = 0;
                int minNumberOfConsecutiveWords = 0;
                int maxOnesInARow = 0;
                while (tempPattern.IndexOf('{') != -1)
                {
                    if (tempPattern.StartsWith(_delimiter) && _delimiter != "|")
                    {
                        tempPattern = tempPattern.Substring(_delimiterLength);
                        if (numberOfConsecutive > maxNumberOfConsecutiveWords)
                            maxNumberOfConsecutiveWords = numberOfConsecutive;
                        if (numberOfConsecutive < minNumberOfConsecutiveWords || minNumberOfConsecutiveWords == 0)
                            minNumberOfConsecutiveWords = numberOfConsecutive;
                        numberOfConsecutive = 0;
                    }
                    else if (tempPattern.StartsWith('|'))
                        tempPattern = tempPattern.Substring(1);
                    else
                    {
                        numberOfConsecutive++;
                        if (tempPattern.StartsWith("{1}"))
                        {
                            numberOfOnes++;
                            tempPattern = tempPattern.Substring(3);
                        }
                        else
                        {
                            if (numberOfOnes > maxOnesInARow)
                                maxOnesInARow = numberOfOnes;
                            numberOfOnes = 0;
                            tempPattern = tempPattern.Substring(tempPattern.IndexOf('}') + 1);
                        }
                    }
                }
                if (numberOfConsecutive > maxNumberOfConsecutiveWords)
                    maxNumberOfConsecutiveWords = numberOfConsecutive;
                if (numberOfConsecutive < minNumberOfConsecutiveWords || minNumberOfConsecutiveWords == 0)
                    minNumberOfConsecutiveWords = numberOfConsecutive;
                if (numberOfOnes > maxOnesInARow)
                    maxOnesInARow = numberOfOnes;

                if (maxOnesInARow > _maxConsecutiveOnes || minNumberOfConsecutiveWords < _minConsecutiveConcatenated || maxNumberOfConsecutiveWords > _maxConsecutiveConcatenated)
                    continue;

                finalList.Add(pattern);
            }
            return finalList;
        }

        private string ReplaceNthOccurrence(string obj, string find, string replace, int nthOccurrence)
        {
            if (nthOccurrence > 0)
            {
                var matchCollection = Regex.Matches(obj, Regex.Escape(find));
                var delimiterLength = Encoding.UTF8.GetByteCount(_delimiter);
                if (matchCollection.Count >= nthOccurrence)
                {
                    var match = matchCollection[nthOccurrence - 1];
                    var matchLength = Encoding.UTF8.GetByteCount(match.Value);
                    if (_options.IncludeWordNotLast && _options.IncludeWordNotFirst)
                        return obj.Remove(match.Index + delimiterLength, matchLength - delimiterLength * 2).Insert(match.Index + delimiterLength, replace);
                    else if (_options.IncludeWordNotLast)
                        return obj.Remove(match.Index, matchLength - delimiterLength).Insert(match.Index, replace);
                    if (_options.IncludeWordNotFirst)
                        return obj.Remove(match.Index + delimiterLength, matchLength - delimiterLength).Insert(match.Index + delimiterLength, replace);
                    return obj.Remove(match.Index, matchLength).Insert(match.Index, replace);
                }
            }
            return obj;
        }

        private List<string> OrderList(List<string> patterns, bool longestWordFirst = false)
        {
            Dictionary<string, double> PatternToScore = new Dictionary<string, double>();

            foreach (var pattern in patterns)
            {
                var tempPattern = pattern;
                List<int> differences = new List<int>();
                int lastInteger = 0;
                while (tempPattern.IndexOf('{') != -1)
                {
                    int firstOpenBracket = tempPattern.IndexOf('{');
                    int firstCloseBracket = tempPattern.IndexOf('}');
                    var test = tempPattern.Substring(firstOpenBracket + 1, firstCloseBracket - 1);
                    var currentInteger = Int32.Parse(tempPattern.Substring(firstOpenBracket + 1, firstCloseBracket - firstOpenBracket - 1));
                    if (lastInteger != 0)
                        differences.Add(lastInteger - currentInteger);
                    lastInteger = currentInteger;
                    tempPattern = tempPattern.Substring(firstCloseBracket + 1);
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
    }
}

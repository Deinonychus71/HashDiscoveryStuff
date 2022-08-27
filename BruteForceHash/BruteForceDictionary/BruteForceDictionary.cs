using BruteForceHash.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace BruteForceHash
{
    public class BruteForceDictionary : BruteForceDictionaryBase
    {
        private readonly Logger _hashCatLogger;
        private readonly Action<ByteString> _testCandidate;
        private readonly bool _runInHashCat;
        private readonly uint _hexValue;
        private uint _hexExtract;
        private int _foundResult = 0;

        public BruteForceDictionary(Logger logger, Options options, int stringLength, uint hexValue, bool runInHashCat = false)
            : base(logger, options, stringLength, hexValue)
        {
            _runInHashCat = runInHashCat;
            _hexValue = hexValue;
            if (runInHashCat)
            {
                Directory.CreateDirectory("Temp");
                _hashCatLogger = new Logger(Path.Combine("Temp", $"{Path.GetFileNameWithoutExtension(_logger.PathFile)}.temp.dic"));
                if (string.IsNullOrEmpty(_options.Prefix) && string.IsNullOrEmpty(_options.Suffix))
                {
                    _hexExtract = _hexValue;
                }
                _testCandidate = WriteCandidateToDictionary;
                _hashCatLogger.Init();
            }
            else
            {
                _testCandidate = TestCandidate;
            }
        }

        public void Run()
        {
            //Run
            var taskScheduler = new LimitedConcurrencyLevelTaskScheduler(_options.NbrThreads);
            var tasks = new List<Task>();

            // Create a TaskFactory and pass it our custom scheduler.
            TaskFactory factory = new TaskFactory(taskScheduler);
            CancellationTokenSource cts = new CancellationTokenSource();

            PrintHeaders();

            foreach (var combinationPattern in _combinationPatterns)
            {
                var task = factory.StartNew(() =>
                {
                    var strBuilder = new ByteString(_stringLength, _hexValue, _options.Prefix, _options.Suffix);
                    if (_options.Verbose)
                        _logger.Log($"Running Pattern: {combinationPattern}", false);
                    RunDictionaries(strBuilder, combinationPattern, true);
                });
                tasks.Add(task);
            }

            // Wait for the tasks to complete before displaying a completion message.
            Task.WaitAll(tasks.ToArray());
            cts.Dispose();

            if (_runInHashCat)
            {
                Thread.Sleep(2000);
                _hashCatLogger.Dispose();

                var dictionaryPath = Path.GetFullPath(_hashCatLogger.PathFile);

                if (_hexExtract == 0)
                {
                    _logger.Log($"No false positive found. Aborting operation.");
                    try
                    {
                        if (_options.DeleteGeneratedDictionary)
                            File.Delete(dictionaryPath);
                    }
                    catch { }
                    return;
                }

                Thread.Sleep(2000);

                // Launch HashCat
                var output = Path.GetFullPath(_logger.PathFile).Replace(".txt", "_hashcat.txt");

                var quiet = string.Empty;
                if (!_options.Verbose)
                    quiet = " --quiet";
                string args = $"--hash-type 11500 -a 0 {_hexExtract:x}:00000000 --outfile \"{output}\" \"{dictionaryPath}\"{quiet}";
                new HashcatTask(_logger, _options).Run(args, _options.Verbose);

                try
                {
                    if (_options.DeleteGeneratedDictionary)
                        File.Delete(dictionaryPath);
                }
                catch { }
            }

            _logger.Log("-----------------------------------------");
            if (_foundResult > 0)
            {
                _logger.Log($"Found {_foundResult} results!");
            }
            else
            {
                _logger.Log($"Nothing :(");
            }
        }

        #region Run Attack
        private void RunDictionaries(ByteString candidate, string combinationPattern, bool firstWord)
        {
            string wordSize;
            bool lastWord = false;

            if (!combinationPattern.Contains(_delimiter))
            {
                wordSize = combinationPattern;
                lastWord = true;
            }
            else
            {
                wordSize = combinationPattern.Substring(0, combinationPattern.IndexOf(_delimiter));
                if (!wordSize.StartsWith("{"))
                {
                    candidate.Append(wordSize);
                    if (_delimiterLength > 0)
                        candidate.Append(_delimiterByte);
                    combinationPattern = combinationPattern[(wordSize.Length + 1)..];
                    RunDictionaries(candidate, combinationPattern, false);
                    candidate.Cursor -= Encoding.UTF8.GetByteCount(wordSize) + _delimiterLength;
                    return;
                }
                combinationPattern = combinationPattern[(combinationPattern.IndexOf(_delimiter) + 1)..];
            }

            if (lastWord && !wordSize.StartsWith("{"))
            {
                candidate.Replace(combinationPattern);
                _testCandidate(candidate);
            }
            else
            {
                byte[][] words;
                if (lastWord)
                    words = _dictionariesLast[wordSize];
                else if (firstWord)
                    words = _dictionariesFirst[wordSize];
                else
                    words = _dictionaries[wordSize];
                foreach (var word in words)
                {
                    if (lastWord)
                    {
                        candidate.Replace(word);
                        _testCandidate(candidate);
                    }
                    else
                    {
                        candidate.Append(word);
                        if (_delimiterLength > 0)
                            candidate.Append(_delimiterByte);
                        RunDictionaries(candidate, combinationPattern, false);
                        candidate.Cursor -= word.Length + _delimiterLength;
                    }
                }
            }
        }

        private void TestCandidate(ByteString candidate)
        {
            if (candidate.CRC32Check())
            {
                _logger.LogResult(candidate.ToString());
                _foundResult++;
            }
        }

        private void WriteCandidateToDictionary(ByteString candidate)
        {
            _hashCatLogger.LogDiscret(candidate.ToString(false));
            if (candidate.CRC32Check() && _hexExtract == 0)
            {
                _logger.LogResult($"False positive found: 0x{candidate.HexSearchValue:x}.");
                _hexExtract = candidate.HexSearchValue;
            }
        }
        #endregion

        #region Generate Combinations
        protected override IEnumerable<string> GenerateCombinations(int stringLength)
        {
            var wordsLimit = _options.WordsLimit;
            var maxOnes = _options.MaxOnes;
            var minOnes = _options.MinOnes;
            var maxTwos = _options.MaxTwos;
            var minTwos = _options.MinTwos;
            var maxThrees = _options.MaxThrees;
            var minThrees = _options.MinThrees;
            var maxFours = _options.MaxFours;
            var minFours = _options.MinFours;
            var maxDelimiters = _options.MaxDelimiters;
            var minDelimiters = _options.MinDelimiters;

            //Get combinations of custom words
            List<IEnumerable<string>> combinationsCustom = new List<IEnumerable<string>>();
            if (_options.DictionariesCustomMinWordsHash > 0 && File.Exists(_options.DictionariesCustom))
            {
                var allCustomWords = File.ReadAllLines(_options.DictionariesCustom).Distinct();
                combinationsCustom = allCustomWords.Combinations(_options.DictionariesCustomMinWordsHash).ToList();
            }
            var hasCombinationsCustom = combinationsCustom.Count > 0;

            //Get include word
            var includeWords = _options.IncludeWord.Split(",", StringSplitOptions.RemoveEmptyEntries);
            var hasIncludeWords = includeWords.Length > 0;

            var alreadyFoundMap = new Dictionary<int, List<string>>();
            for (var i = 1; i <= stringLength; i++)
            {
                alreadyFoundMap[i] = GenerateValidCombinations(i, alreadyFoundMap, _delimiterLength, wordsLimit, 0, _options.OrderLongerWordsFirst);
            }

            //Sorting
            var inputList = alreadyFoundMap[stringLength];

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
                //Size Filtering
                var nbrDelimiters = combination.Split(_delimiter).Length - 1;
                var nbrOnes = combination.Split("{1}").Length - 1;
                var nbrTwos = combination.Split("{2}").Length - 1;
                var nbrThrees = combination.Split("{3}").Length - 1;
                var nbrFours = combination.Split("{4}").Length - 1;
                if (nbrDelimiters < minDelimiters || (nbrDelimiters > maxDelimiters && maxDelimiters != -1))
                    continue;
                if (nbrOnes < minOnes || nbrOnes > maxOnes)
                    continue;
                if (nbrTwos < minTwos || nbrTwos > maxTwos)
                    continue;
                if (nbrThrees < minThrees || nbrThrees > maxThrees)
                    continue;
                if (nbrFours < minFours || nbrFours > maxFours)
                    continue;
                if (_options.AtLeastAboveWords > 0 || _options.AtLeastUnderWords > 0)
                {
                    var dictNbr = new int[11];
                    for (var i = 0; i < dictNbr.Length; i++)
                    {
                        dictNbr[i] = combination.Split("{" + (i + 1) + "}").Length - 1;
                    }
                    if (_options.AtLeastAboveWords > 0 && dictNbr.Where((p, i) => i > _options.AtLeastAboveChars - 1).Sum() < _options.AtLeastAboveWords)
                        continue;
                    if (_options.AtLeastUnderWords > 0 && dictNbr.Where((p, i) => i < _options.AtLeastUnderChars - 1).Sum() < _options.AtLeastUnderWords)
                        continue;
                }

                List<string> nbrChar = new List<string>();
                string reducedCombination = combination;
                while (reducedCombination.IndexOf('}') != -1)
                {
                    nbrChar.Add(reducedCombination.Substring(0, reducedCombination.IndexOf('}') + 1));
                    reducedCombination = reducedCombination.Substring(reducedCombination.IndexOf('}') + 1);
                }
                if (nbrChar.Count <= wordsLimit &&
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
                                if (wordCandidates != null)
                                {
                                    output.AddRange(wordCandidates);
                                }
                            }
                            else
                            {
                                var wordCandidates = GenerateIncludeWordCombinations(combination, combinationCustom);
                                if (wordCandidates != null)
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
                        return null;
                    var nbrMatch = Regex.Matches(wordCandidate, combinationRegexp).Count;
                    for (int i = 0; i < nbrMatch; i++)
                    {
                        tempWordCandidates.Add(ReplaceNthOccurrence(wordCandidate, combinationMatch, includeWord, i + 1));
                    }
                }
                wordCandidates = tempWordCandidates;
            }
            return wordCandidates.Select(p => p.TrimStart('$').Trim('^'));
        }

        private List<string> GenerateValidCombinations(int stringLength, Dictionary<int, List<string>> alreadyFoundMap, int delimiterLength, int wordsLimit, int wordsSoFar, bool longerWordsFirst)
        {
            var returnCombinations = new List<string>();
            if (wordsSoFar >= wordsLimit && stringLength > 0)
            {
                returnCombinations.Add("invalid");
            }
            else if (stringLength == 1)
            {
                returnCombinations.Add("{1}");
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
            else if (delimiterLength == 0 && stringLength < 0 && stringLength != delimiterLength * -1)
            {
                returnCombinations.Add("invalid");
            }

            else
            {
                int i = longerWordsFirst ? stringLength : 1;
                while ((longerWordsFirst && i >= 1) || (!longerWordsFirst && i <= stringLength))
                {
                    var remainingLength = stringLength - i - delimiterLength;
                    var pattern = i.ToString();
                    List<string> subCombinations;
                    if (alreadyFoundMap.ContainsKey(remainingLength))
                    {
                        subCombinations = alreadyFoundMap[remainingLength];
                    }
                    else
                    {
                        subCombinations = GenerateValidCombinations(remainingLength, alreadyFoundMap, delimiterLength, wordsLimit, wordsSoFar + 1, longerWordsFirst);
                    }

                    foreach (var remainingStringPattern in subCombinations)
                    {
                        if (remainingStringPattern == "ended")
                        {
                            returnCombinations.Add($"{{{pattern}}}");
                        }
                        else if (remainingStringPattern != "invalid" && (Encoding.UTF8.GetByteCount(remainingStringPattern) - Encoding.UTF8.GetByteCount(remainingStringPattern.Replace("{", ""))) + wordsSoFar + 1 <= wordsLimit)
                        {
                            returnCombinations.Add($"{{{pattern}}}{_delimiter}{remainingStringPattern}");
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
        #endregion
    }
}
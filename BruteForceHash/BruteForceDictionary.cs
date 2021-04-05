using BruteForceHash.Helpers;
using Force.Crc32;
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
    public class BruteForceDictionary
    {
        private readonly Logger _logger;
        private readonly IEnumerable<string> _combinationPatterns;
        private readonly Dictionary<string, byte[][]> _dictionaries;
        private readonly Dictionary<string, byte[][]> _dictionariesFirst;
        private readonly Dictionary<string, byte[][]> _dictionariesLast;
        private readonly Options _options;
        private readonly uint _hexValue;
        private readonly int _stringLength;
        private readonly string _delimiter;
        private readonly byte _delimiterByte;
        private readonly int _delimiterLength;
        private readonly Regex _specialCharactersRegex = new Regex("^[a-zA-Z0-9_]*$", RegexOptions.Compiled);

        public BruteForceDictionary(Logger logger, Options options, int stringLength, uint hexValue)
        {
            _logger = logger;
            _options = options;
            _hexValue = hexValue;
            if (string.IsNullOrEmpty(options.Delimiter))
            {
                _delimiter = "|";
                _delimiterByte = Encoding.ASCII.GetBytes("|")[0];
                _delimiterLength = 0;
            }
            else
            {
                _delimiter = options.Delimiter;
                _delimiterByte = Encoding.ASCII.GetBytes(options.Delimiter)[0];
                _delimiterLength = _delimiter.Length;
            }
                
            _options.IncludeWord = _options.IncludeWord.ToLower();

            //Calculate stringLength after prefix;
            _stringLength = stringLength;

            //Generate combinations
            var combinationSize = _stringLength - options.Prefix.Length - options.Suffix.Length;
            _combinationPatterns = GenerateCombinations(combinationSize, options.WordsLimit);

            //Load dictionary
            _dictionaries = GetDictionaries(_options.Dictionaries, options.DictionariesSkipDigits, options.DictionariesSkipSpecials, options.DictionariesForceLowercase, options.DictionariesAddTypos, options.DictionariesReverseOrder);
            if (!string.IsNullOrEmpty(options.DictionariesFirstWord))
            {
                _dictionariesFirst = GetDictionaries(_options.DictionariesFirstWord, options.DictionariesFirstSkipDigits, options.DictionariesFirstSkipSpecials, options.DictionariesFirstForceLowercase, options.DictionariesFirstAddTypos, options.DictionariesFirstReverseOrder);
            }
            else
            {
                _dictionariesFirst = _dictionaries;
            }
            if (!string.IsNullOrEmpty(options.DictionariesLastWord))
            {
                _dictionariesLast = GetDictionaries(_options.DictionariesLastWord, options.DictionariesLastSkipDigits, options.DictionariesLastSkipSpecials, options.DictionariesLastForceLowercase, options.DictionariesLastAddTypos, options.DictionariesLastReverseOrder);
            }
            else
            {
                _dictionariesLast = _dictionaries;
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

            _logger.Log($"Delimiter: {_delimiter}");
            _logger.Log($"Words Limit: {_options.WordsLimit}");
            if(!string.IsNullOrEmpty(_options.ExcludePatterns))
                _logger.Log($"Exclude Patterns: {_options.ExcludePatterns}");
            if (!string.IsNullOrEmpty(_options.IncludePatterns))
                _logger.Log($"Include Patterns: {_options.IncludePatterns}");
            if (!string.IsNullOrEmpty(_options.IncludeWord))
            {
                _logger.Log($"Include Word: {_options.IncludeWord}");
                _logger.Log($"Include Word - Skip first word: {_options.IncludeWordNotFirst}");
            }
            _logger.Log($"Combinations found: {_combinationPatterns.Count()}");
            _logger.Log($"Combination Order: {_options.Order}");
            _logger.Log($"Dictionaries: {_options.Dictionaries}");
            _logger.Log($"Dictionaries Skip Digits: {_options.DictionariesSkipDigits}");
            _logger.Log($"Dictionaries Skip Specials: {_options.DictionariesSkipSpecials}");
            _logger.Log($"Dictionaries Force LowerCase: {_options.DictionariesForceLowercase}");
            _logger.Log($"Dictionaries Add Typo: {_options.DictionariesAddTypos}");
            _logger.Log($"Dictionaries Reverse Order: {_options.DictionariesReverseOrder}");
            _logger.Log($"Dictionary words: {_dictionaries.Values.Sum(p => p.Length)}");
            if (_dictionaries != _dictionariesFirst)
            {
                _logger.Log($"Dictionaries (1st word): {_options.DictionariesFirstWord}");
                _logger.Log($"Dictionaries (1st word) Skip Digits: {_options.DictionariesFirstSkipDigits}");
                _logger.Log($"Dictionaries (1st word) Skip Specials: {_options.DictionariesFirstSkipSpecials}");
                _logger.Log($"Dictionaries (1st word) Force LowerCase: {_options.DictionariesFirstForceLowercase}");
                _logger.Log($"Dictionaries (1st word) Add Typo: {_options.DictionariesFirstAddTypos}");
                _logger.Log($"Dictionaries (1st word) Reverse Order: {_options.DictionariesFirstReverseOrder}");
                _logger.Log($"Dictionaries (1st word) words: {_dictionariesFirst.Values.Sum(p => p.Length)}");
            }
            if (_dictionaries != _dictionariesLast)
            {
                _logger.Log($"Dictionaries (last word): {_options.DictionariesLastWord}");
                _logger.Log($"Dictionaries (last word) Skip Digits: {_options.DictionariesLastSkipDigits}");
                _logger.Log($"Dictionaries (last word) Skip Specials: {_options.DictionariesLastSkipSpecials}");
                _logger.Log($"Dictionaries (last word) Force LowerCase: {_options.DictionariesLastForceLowercase}");
                _logger.Log($"Dictionaries (last word) Add Typo: {_options.DictionariesLastAddTypos}");
                _logger.Log($"Dictionaries (last word) Reverse Order: {_options.DictionariesLastReverseOrder}");
                _logger.Log($"Dictionaries (last word) words: {_dictionariesLast.Values.Sum(p => p.Length)}");
            }
            
            
            if (_options.Verbose)
            {
                for(int i = 1; i <= _stringLength - _options.Prefix.Length - _options.Suffix.Length; i++)
                {
                    _logger.Log($"{i}-letter words: {_dictionaries[$"{{{i}}}"].Length}", false);
                }
            }
            _logger.Log($"Search on: {_stringLength - _options.Prefix.Length - _options.Suffix.Length} characters");
            _logger.Log("-----------------------------------------");

            foreach (var combinationPattern in _combinationPatterns)
            {
                var task = factory.StartNew(() =>
                {
                    var strBuilder = new ByteString(_stringLength, _hexValue, _options.Prefix, _options.Suffix);
                    if(_options.Verbose)
                        _logger.Log($"Running Pattern: {combinationPattern}", false);
                    RunDictionaries(strBuilder, combinationPattern, true);
                });
                tasks.Add(task);
            }

            // Wait for the tasks to complete before displaying a completion message.
            Task.WaitAll(tasks.ToArray());
            cts.Dispose();
        }

        private IEnumerable<string> GenerateCombinations(int stringLength,  int wordsLimit)
        {
            var includeWords = _options.IncludeWord.Split(",", StringSplitOptions.RemoveEmptyEntries);
            var alreadyFoundMap = new Dictionary<int, List<string>>();
            for (var i = 1; i <= stringLength; i++)
            {
                alreadyFoundMap[i] = GenerateValidCombinations(i, alreadyFoundMap, _delimiterLength, wordsLimit, 0);
            }

            //Sorting
            var inputList = alreadyFoundMap[stringLength];

            switch (_options.Order.ToLower())
            {
                case "optimized":
                    inputList = OrderList(inputList);
                    break;
                case "longer_first":
                    inputList = inputList.OrderBy(p => p.Length).ToList();
                    break;
                case "shorter_first":
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
                if (nbrChar.Count <= wordsLimit &&
                    !excludePatterns.Any(p => combination.Contains(p)) &&
                    (includePatterns.Length == 0 || includePatterns.All(p => combination.Contains(p))))
                {
                    if (includeWords.Length > 0)
                    {
                        var wordCandidates = new List<string>() { combination };
                        foreach (var includeWord in includeWords)
                        {
                            string combinationMatch;
                            string combinationRegexp;
                            if (!_options.IncludeWordNotFirst)
                            {
                                combinationMatch = $"{{{includeWord.Length}}}";
                                combinationRegexp = "\\{" + includeWord.Length + "\\}";
                            }
                            else
                            {
                                combinationMatch = $"{_delimiter}{{{includeWord.Length}}}";
                                combinationRegexp = Regex.Escape($"{_delimiter}{{{includeWord.Length}}}");// "\\" + _delimiter + "\\{" + includeWord.Length + "\\}";
                            }
                            var tempWordCandidates = new List<string>();
                            foreach (var wordCandidate in wordCandidates)
                            {
                                if (!wordCandidate.Contains(combinationMatch))
                                    continue;
                                var nbrMatch = Regex.Matches(wordCandidate, combinationRegexp).Count;
                                for (int i = 0; i < nbrMatch; i++)
                                {
                                    tempWordCandidates.Add(ReplaceNthOccurrence(wordCandidate, combinationMatch, includeWord, i + 1));
                                }
                            }
                            wordCandidates = tempWordCandidates;
                        }
                        output.AddRange(wordCandidates.Select(p => p.TrimStart('$').Trim('^')));
                        continue;
                    }
                    output.Add(combination.TrimStart('$').Trim('^'));
                }
                    
            }

            return output;
        }

        private List<string> GenerateValidCombinations(int stringLength, Dictionary<int, List<string>> alreadyFoundMap, int delimiterLength, int wordsLimit, int wordsSoFar)
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
                for (int i = 1; i <= stringLength; i++)
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
                        subCombinations = GenerateValidCombinations(remainingLength, alreadyFoundMap, delimiterLength, wordsLimit, wordsSoFar + 1);
                    }

                    foreach (var remainingStringPattern in subCombinations)
                    {
                        if (remainingStringPattern == "ended")
                        {
                            returnCombinations.Add($"{{{pattern}}}");
                        }
                        else if (remainingStringPattern != "invalid" && (remainingStringPattern.Length - remainingStringPattern.Replace("{", "").Length) + wordsSoFar + 1 <= wordsLimit)
                        {
                            returnCombinations.Add($"{{{pattern}}}{_delimiter}{remainingStringPattern}");
                        }
                    }

                }

            }
            return returnCombinations;
        }

        private List<string> OrderList(List<string> patterns)
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
                    PatternToScore.Add(pattern, scoreSum / scoresCounted);
                }


            }

            var KeyValueList = PatternToScore.ToList();
            KeyValueList.Sort((Pair1, Pair2) => Pair2.Value.CompareTo(Pair1.Value));
            return (from KeyValuePair in KeyValueList select KeyValuePair.Key).ToList();
        }

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
                if(!wordSize.StartsWith("{"))
                {
                    candidate.Append(wordSize);
                    if (_delimiterLength > 0)
                        candidate.Append(_delimiterByte);
                    combinationPattern = combinationPattern[(wordSize.Length + 1)..];
                    RunDictionaries(candidate, combinationPattern, false);
                    candidate.Cursor -= wordSize.Length + _delimiterLength;
                    return;
                }
                combinationPattern = combinationPattern[(combinationPattern.IndexOf(_delimiter) + 1)..];
            }

            if (lastWord && !wordSize.StartsWith("{"))
            {
                candidate.Replace(combinationPattern);
                TestCandidate(candidate);
            }
            else
            {
                byte[][] words;
                if (lastWord)
                    words = _dictionariesLast[wordSize];
                else if(firstWord)
                    words = _dictionariesFirst[wordSize];
                else
                    words = _dictionaries[wordSize];
                foreach (var word in words)
                {
                    if (lastWord)
                    {
                        candidate.Replace(word);
                        TestCandidate(candidate);
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
                _logger.LogResult(candidate.ToString());
        }

        private string ReplaceNthOccurrence(string obj, string find, string replace, int nthOccurrence)
        {
            if (nthOccurrence > 0)
            {
                var matchCollection = Regex.Matches(obj, Regex.Escape(find));
                if (matchCollection.Count >= nthOccurrence)
                {
                    var match = matchCollection[nthOccurrence - 1];
                    if(_options.IncludeWordNotFirst)
                        return obj.Remove(match.Index + _delimiter.Length, match.Length - _delimiter.Length).Insert(match.Index + _delimiter.Length, replace);
                    return obj.Remove(match.Index, match.Length).Insert(match.Index, replace);
                }
            }
            return obj;
        }

        private Dictionary<string, byte[][]> GetDictionaries(string dictionaries, bool skipDigits, bool skipSpecials, bool forceLowerCase, bool addTypos, bool reverseOrder)
        {
            Dictionary<string, HashSet<string>> dictionary = new Dictionary<string, HashSet<string>>();
            var output = new Dictionary<string, byte[][]>();

            //Fill if no data present
            for (int i = 1; i <= 100; i++) 
                dictionary.Add($"{{{i}}}", new HashSet<string>());

            string[] allDictionaries;
            if (Directory.Exists("Dictionaries") && dictionaries == "*")
                allDictionaries = Directory.GetFiles("Dictionaries", "*.dic");
            else
                allDictionaries = dictionaries.Split(";", StringSplitOptions.RemoveEmptyEntries);

            foreach (var dictionaryPath in allDictionaries)
            {
                var allWords = File.ReadAllLines(dictionaryPath);
                foreach (var word in allWords)
                {
                    if (word.Length == 0)
                        continue;
                    if (skipDigits && word.Any(char.IsDigit))
                        continue;
                    if(skipSpecials && !_specialCharactersRegex.IsMatch(word))
                        continue;

                    var lengthStr = $"{{{word.Length}}}";
                    var wordToAdd = word;
                    if (forceLowerCase)
                        wordToAdd = word.ToLower();

                    if (addTypos)
                    {
                        var allNewWords = Combinations(wordToAdd, 'l', 'r');
                        foreach (var newWord in allNewWords)
                        {
                            if (!dictionary[lengthStr].Contains(newWord))
                                dictionary[lengthStr].Add(newWord);
                        }
                    }
                    else
                    {
                        if (!dictionary[lengthStr].Contains(wordToAdd))
                            dictionary[lengthStr].Add(wordToAdd);
                    }
                }
            }

            foreach(var entry in dictionary)
            {
                output.Add(entry.Key, new byte[entry.Value.Count][]);
                if(reverseOrder)
                    output[entry.Key] = entry.Value.OrderByDescending(p => p).Select(p => Encoding.ASCII.GetBytes(p)).ToArray();
                else
                    output[entry.Key] = entry.Value.OrderBy(p => p).Select(p => Encoding.ASCII.GetBytes(p)).ToArray();
            }

            return output;
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

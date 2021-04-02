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
            _dictionaries = GetDictionaries(options.SkipDigits, options.SkipSpecials, options.ForceLowercase);
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
                _logger.Log($"Include Word: {_options.IncludeWord}");
            _logger.Log($"Combinations found: {_combinationPatterns.Count()}");
            _logger.Log($"Combination Order: {_options.Order}");
            _logger.Log($"Dictionaries: {_options.UseDictionaries}");
            _logger.Log($"Dictionary words: {_dictionaries.Values.Sum(p => p.Length)}");
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
                    RunDictionaries(strBuilder, combinationPattern);
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
                //Console.WriteLine(combination);
                List<string> nbrChar = new List<string>();
                string reducedCombination = combination;
                while (reducedCombination.IndexOf('}') != -1) 
                {
                    nbrChar.Add(reducedCombination.Substring(0, reducedCombination.IndexOf('}') + 1));
                    reducedCombination = reducedCombination.Substring(reducedCombination.IndexOf('}') + 1);
                }
                //var nbrChar = combination.Split(delimiter);
                if (nbrChar.Count <= wordsLimit &&
                    !excludePatterns.Any(p => combination.Contains(p)) &&
                    (includePatterns.Length == 0 || includePatterns.All(p => combination.Contains(p))))
                {
                    if (includeWords.Length > 0)
                    {
                        var wordCandidates = new List<string>() { combination };
                        foreach (var includeWord in includeWords)
                        {
                            var combinationMatch = $"{{{includeWord.Length}}}";
                            var tempWordCandidates = new List<string>();
                            foreach (var wordCandidate in wordCandidates)
                            {
                                if (!wordCandidate.Contains(combinationMatch))
                                    continue;
                                var nbrMatch = Regex.Matches(wordCandidate, "\\{" + includeWord.Length + "\\}").Count;
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

        private void RunDictionaries(ByteString candidate, string combinationPattern)
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
                    RunDictionaries(candidate, combinationPattern);
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
                var words = _dictionaries[wordSize];
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
                        RunDictionaries(candidate, combinationPattern);
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
                    return obj.Remove(match.Index, match.Length).Insert(match.Index, replace);
                }
            }
            return obj;
        }

        private Dictionary<string, byte[][]> GetDictionaries(bool skipDigits, bool skipSpecials, bool forceLowerCase)
        {
            Dictionary<string, HashSet<string>> dictionary = new Dictionary<string, HashSet<string>>();
            var output = new Dictionary<string, byte[][]>();

            //Fill if no data present
            for (int i = 1; i <= 100; i++) 
                dictionary.Add($"{{{i}}}", new HashSet<string>());

            string[] allDictionaries;
            if (Directory.Exists("Dictionaries") && _options.UseDictionaries == "*")
                allDictionaries = Directory.GetFiles("Dictionaries", "*.dic");
            else
                allDictionaries = _options.UseDictionaries.Split(";", StringSplitOptions.RemoveEmptyEntries);

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

                    if (!dictionary[lengthStr].Contains(wordToAdd))
                        dictionary[lengthStr].Add(wordToAdd);
                }
            }

            foreach(var entry in dictionary)
            {
                output.Add(entry.Key, new byte[entry.Value.Count][]);
                output[entry.Key] = entry.Value.Select(p => Encoding.ASCII.GetBytes(p)).ToArray();
            }

            return output;
        }
    }
}

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
        private readonly Dictionary<string, HashSet<string>> _dictionaries;
        private readonly Options _options;
        private readonly uint _hexValue;
        private readonly string _delimiter;

        public BruteForceDictionary(Logger logger, Options options, int stringLength, uint hexValue)
        {
            _logger = logger;
            _options = options;
            _hexValue = hexValue;
            _delimiter = options.Delimiter;
            _options.IncludeWord = _options.IncludeWord.ToLower();

            //Calculate stringLength after prefix;
            stringLength -= options.Prefix.Length;

            //Generate combinations
            _combinationPatterns = GenerateCombinations(stringLength, _delimiter, options.WordsLimit);

            //Load dictionary
            _dictionaries = DictionariesHelper.GetDictionaries(options.SkipDigits, options.ForceLowercase);
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
            _logger.Log($"Dictionary words: {_dictionaries.Values.Sum(p => p.Count)}");
            _logger.Log("-----------------------------------------");

            foreach (var combinationPattern in _combinationPatterns)
            {
                var task = factory.StartNew(() =>
                {
                    var strBuilder = new StringBuilder();
                    if (!string.IsNullOrEmpty(_options.Prefix))
                    {
                        strBuilder.Append(_options.Prefix);
                    }
                    _logger.Log($"Running Pattern: {combinationPattern}", false);
                    RunDictionaries(strBuilder, combinationPattern);
                });
                tasks.Add(task);
            }

            // Wait for the tasks to complete before displaying a completion message.
            Task.WaitAll(tasks.ToArray());
            cts.Dispose();
        }

        private IEnumerable<string> GenerateCombinations(int stringLength, string delimiter, int wordsLimit)
        {
            var alreadyFoundMap = new Dictionary<int, List<string>>();
            for (var i = 1; i <= stringLength; i++)
            {
                alreadyFoundMap[i] = GenerateValidCombinations(i, alreadyFoundMap, delimiter);
            }

            var output = new List<string>();
            var excludePatterns = _options.ExcludePatterns.Split(",", StringSplitOptions.RemoveEmptyEntries);
            var includePatterns = _options.IncludePatterns.Split(",", StringSplitOptions.RemoveEmptyEntries);
            foreach (var combination in alreadyFoundMap[stringLength])
            {
                var nbrChar = combination.Split(delimiter);
                if (nbrChar.Length <= wordsLimit && 
                    !excludePatterns.Any(p => combination.Contains(p)) && 
                    (includePatterns.Length == 0 || includePatterns.Any(p => combination.Contains(p))))
                {
                    if (!string.IsNullOrEmpty(_options.IncludeWord))
                    {
                        var combinationMatch = $"{{{_options.IncludeWord.Length}}}";
                        if (!combination.Contains(combinationMatch))
                            continue;
                        var nbrMatch = Regex.Matches(combination, "\\{" + _options.IncludeWord.Length + "\\}").Count;
                        for(int i = 0; i < nbrMatch; i++)
                        {
                            output.Add(ReplaceNthOccurrence(combination, combinationMatch, _options.IncludeWord, i + 1));
                        }
                        continue;
                    }
                    output.Add(combination);
                }
                    
            }

            return output.OrderBy(p => p.Length);
        }

        private List<string> GenerateValidCombinations(int stringLength, Dictionary<int, List<string>> alreadyFoundMap, string delimiter)
        {
            var returnCombinations = new List<string>();
            if (stringLength == 1)
            {
                returnCombinations.Add("{1}");
            }
            else if (stringLength == 0)
            {
                returnCombinations.Add("invalid");
            }
            else if (stringLength == -1)
            {
                returnCombinations.Add("ended");
            }
            else
            {
                for (int i = 1; i <= stringLength; i++)
                {
                    var remainingLength = stringLength - i - 1;
                    var pattern = i.ToString();
                    List<string> subCombinations;
                    if (alreadyFoundMap.ContainsKey(remainingLength))
                    {
                        subCombinations = alreadyFoundMap[remainingLength];
                    }
                    else
                    {
                        subCombinations = GenerateValidCombinations(remainingLength, alreadyFoundMap, delimiter);
                    }

                    foreach (var remainingStringPattern in subCombinations)
                    {
                        if (remainingStringPattern == "ended")
                        {
                            returnCombinations.Add($"{{{pattern}}}");
                        }
                        else if (remainingStringPattern != "invalid")
                        {
                            returnCombinations.Add($"{{{pattern}}}{delimiter}{remainingStringPattern}");
                        }
                    }

                }

            }
            return returnCombinations;
        }

        private void RunDictionaries(StringBuilder candidate, string combinationPattern)
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
                    var wordLength = wordSize.Length + _delimiter.Length;
                    candidate.Append(wordSize);
                    candidate.Append(_delimiter);
                    combinationPattern = combinationPattern[(wordLength)..];
                    RunDictionaries(candidate, combinationPattern);
                    candidate.Remove(candidate.Length - wordLength, wordLength);
                    return;
                }
                combinationPattern = combinationPattern[(combinationPattern.IndexOf(_delimiter) + _delimiter.Length)..];
            }

            if (lastWord && !wordSize.StartsWith("{"))
            {
                candidate.Append(combinationPattern);
                TestCandidate(candidate);
                candidate.Remove(candidate.Length - combinationPattern.Length, combinationPattern.Length);
            }
            else
            {
                var words = _dictionaries[wordSize];
                foreach (var word in words)
                {
                    if (lastWord)
                    {
                        candidate.Append(word);
                        TestCandidate(candidate);
                        candidate.Remove(candidate.Length - word.Length, word.Length);
                    }
                    else
                    {
                        candidate.Append(word);
                        candidate.Append(_delimiter);
                        RunDictionaries(candidate, combinationPattern);
                        int length = _delimiter.Length + word.Length;
                        candidate.Remove(candidate.Length - length, length);
                    }
                }
            }
        }

        private void TestCandidate(StringBuilder candidate)
        {
            var testValue = Crc32Algorithm.Compute(Encoding.ASCII.GetBytes(candidate.ToString()));
            if (testValue == _hexValue)
                _logger.Log(candidate.ToString());
        }

        private string ReplaceNthOccurrence(string obj, string find, string replace, int nthOccurrence)
        {
            if (nthOccurrence > 0)
            {
                MatchCollection matchCollection = Regex.Matches(obj, Regex.Escape(find));
                if (matchCollection.Count >= nthOccurrence)
                {
                    Match match = matchCollection[nthOccurrence - 1];
                    return obj.Remove(match.Index, match.Length).Insert(match.Index, replace);
                }
            }
            return obj;
        }
    }

    public static class DictionariesHelper
    {
        private static readonly Dictionary<string, HashSet<string>> _dictionary = new Dictionary<string, HashSet<string>>();
        private static readonly Dictionary<string, HashSet<string>> _dictionaryNoDigit = new Dictionary<string, HashSet<string>>();
        private static readonly Dictionary<string, HashSet<string>> _dictionaryNoDigitLowerCase = new Dictionary<string, HashSet<string>>();
        private static readonly Dictionary<string, HashSet<string>> _dictionaryLowerCase = new Dictionary<string, HashSet<string>>();

        public static Dictionary<string, HashSet<string>> GetDictionaries(bool skipDigits, bool forceLowerCase)
        {
            Dictionary<string, HashSet<string>> dictionary = null;

            if (skipDigits && forceLowerCase)
                dictionary = _dictionaryNoDigitLowerCase;
            if (skipDigits && !forceLowerCase)
                dictionary = _dictionaryNoDigit;
            if (!skipDigits && forceLowerCase)
                dictionary = _dictionaryLowerCase;
            if (!skipDigits && !forceLowerCase)
                dictionary = _dictionary;

            if (dictionary.Count != 0)
                return dictionary;

            //Fill if no data present
            for (int i = 1; i <= 100; i++)
                dictionary.Add($"{{{i}}}", new HashSet<string>());

            var allDictionaries = Directory.GetFiles("Dictionaries", "*.txt");
            foreach (var dictionaryPath in allDictionaries)
            {
                var allWords = File.ReadAllLines(dictionaryPath);
                foreach (var word in allWords)
                {
                    if (word.Length == 0)
                        continue;
                    if (skipDigits && word.Any(char.IsDigit))
                        continue;

                    var lengthStr = $"{{{word.Length}}}";
                    var wordToAdd = word;
                    if (forceLowerCase)
                        wordToAdd = word.ToLower();

                    if (!dictionary[lengthStr].Contains(wordToAdd))
                        dictionary[lengthStr].Add(wordToAdd);
                }
            }
            return dictionary;
        }
    }
}

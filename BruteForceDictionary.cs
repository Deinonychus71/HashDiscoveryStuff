using BruteForceHash.Helpers;
using Force.Crc32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BruteForceHash
{
    public class BruteForceDictionary
    {
        private readonly Logger _logger;
        private readonly IEnumerable<string> _combinationPatterns;
        private readonly Dictionary<string, List<string>> _dictionaries;
        private readonly Options _options;
        private readonly uint _hexValue;
        private readonly string _delimiter;

        public BruteForceDictionary(Logger logger, Options options, int stringLength, uint hexValue)
        {
            _logger = logger;
            _options = options;
            _hexValue = hexValue;
            _delimiter = options.Delimiter;

            //Calculate stringLength after prefix;
            stringLength -= options.Prefix.Length;

            //Generate combinations
            _combinationPatterns = GenerateCombinations(stringLength, _delimiter, options.WordsLimit);

            //Load dictionary
            _dictionaries = GetDictionaries(stringLength, _delimiter, options.SkipDigits);
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
            _logger.Log($"Exclude Patterns: {_options.ExcludePatterns}");
            _logger.Log($"Include Patterns: {_options.IncludePatterns}");
            _logger.Log($"Combinations found: {_combinationPatterns.Count()}");
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
                    output.Add(combination);
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

        private Dictionary<string, List<string>> GetDictionaries(int stringLength, string delimiter, bool skipDigits)
        {
            var output = new Dictionary<string, List<string>>();
            var lengthSkip = delimiter.Length > 0 ? stringLength - delimiter.Length : stringLength + 1;

            for (int i = 1; i <= stringLength; i++)
                output.Add($"{{{i}}}", new List<string>());

            var allDictionaries = Directory.GetFiles("Dictionaries", "*.txt");
            foreach (var dictionaryPath in allDictionaries)
            {
                var allWords = File.ReadAllLines(dictionaryPath);
                foreach (var word in allWords)
                {
                    if (word.Length > stringLength || word.Length == lengthSkip || word.Length == 0)
                        continue;
                    if (skipDigits && word.Any(char.IsDigit))
                        continue;

                    var lengthStr = $"{{{word.Length}}}";
                    if (!output[lengthStr].Contains(word))
                        output[lengthStr].Add(word);
                }
            }
            return output;
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
                combinationPattern = combinationPattern[(combinationPattern.IndexOf(_delimiter) + _delimiter.Length)..];

            }

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

        private void TestCandidate(StringBuilder candidate)
        {
            var testValue = Crc32Algorithm.Compute(Encoding.ASCII.GetBytes(candidate.ToString()));
            if (testValue == _hexValue)
                _logger.Log(candidate.ToString());
        }
    }
}

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
    public class BruteForceDictionaryAdvanced
    {
        private readonly Logger _logger;
        private Logger _hashCatLogger;
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
        private uint _hexExtract;
        private bool _runInHashCat;
        private int _foundResult = 0;
        private Action<ByteString> _testCandidate;
        private int _maxDelimiters;
        private int _minDelimiters;
        private int _maxConsecutives;
        private int _minConsecutives;
        private int _maxWords;
        private int _minWords;
        private bool _concatenateOnlyLastTwo;
        private bool _concatenateOnlyFirstTwo;
        private int _minWordLength;
        private int _maxWordLength;
        private int _maxOnes;
        private int _minOnes;
        private int _maxTwos;
        private int _minTwos;
        private int _maxThrees;
        private int _minThrees;
        private int _maxFours;
        private int _minFours;
        private int _maxConsecutiveOnes;
        private int _maxConsecutiveConcatenated;
        private int _minConsecutiveConcatenated;

        private readonly Regex _specialCharactersRegex = new Regex("^[a-zA-Z0-9_]*$", RegexOptions.Compiled);

        public BruteForceDictionaryAdvanced(Logger logger, Options options, int stringLength, uint hexValue, bool runInHashCat = false)
        {
            _runInHashCat = runInHashCat;
            _logger = logger;
            _options = options;
            _hexValue = hexValue;
            if (string.IsNullOrEmpty(options.Delimiter))
            {
                _delimiter = "|";
                _delimiterByte = Encoding.UTF8.GetBytes("|")[0];
                _delimiterLength = 0;
            }
            else
            {
                _delimiter = options.Delimiter;
                _delimiterByte = Encoding.UTF8.GetBytes(options.Delimiter)[0];
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

            _options.IncludeWord = _options.IncludeWord.ToLower();

            //Calculate stringLength after prefix;
            _stringLength = stringLength;

            //Generate combinations
            var combinationSize = _stringLength - Encoding.UTF8.GetByteCount(options.Prefix) - Encoding.UTF8.GetByteCount(options.Suffix);
            _maxWordLength = Math.Min(options.MaxWordLength, _stringLength);
            _combinationPatterns = GenerateCombinations(combinationSize);

            //Load common dictionary
            _dictionaries = GetDictionaries(_options.Dictionaries, null, options.DictionariesSkipDigits, options.DictionariesSkipSpecials, options.DictionariesForceLowercase, options.DictionariesAddTypos,
                _options.DictionariesCustom, _options.DictionariesCustomSkipDigits, _options.DictionariesCustomSkipSpecials, _options.DictionariesCustomForceLowercase, _options.DictionariesCustomAddTypos,
                options.DictionariesReverseOrder, _options.DictionariesExclude, _options.DictionariesExcludePartialWords);

            //Load first word dictionary
            var dictionaryFirstWord = _options.Dictionaries;
            var dictionaryFirstWordSkipDigits = options.DictionariesSkipDigits;
            var dictionaryFirstWordSkipSpecials = options.DictionariesSkipSpecials;
            var dictionaryFirstWordForceLowercase = options.DictionariesForceLowercase;
            var dictionaryFirstWordAddTypos = options.DictionariesAddTypos;
            var dictionaryFirstWordCustom = options.DictionariesCustom;
            var dictionaryFirstWordCustomSkipDigits = options.DictionariesCustomSkipDigits;
            var dictionaryFirstWordCustomSkipSpecials = options.DictionariesCustomSkipSpecials;
            var dictionaryFirstWordCustomForceLowercase = options.DictionariesCustomForceLowercase;
            var dictionaryFirstWordCustomAddTypos = options.DictionariesCustomAddTypos;
            var dictionaryFirstWordReverseOrder = options.DictionariesReverseOrder;
            var dictionaryFirstWordExclude = _options.DictionariesExclude;
            var dictionaryFirstWordExcludePartialWords = _options.DictionariesExcludePartialWords;
            if (options.DictionariesFirstWord == null && options.DictionariesFirstWordCustom == null && options.DictionariesFirstWordExclude == null && string.IsNullOrEmpty(options.DictionaryFilterFirst))
            {
                _dictionariesFirst = _dictionaries;
            }
            else
            {
                if (options.DictionariesFirstWord != null)
                {
                    dictionaryFirstWord = _options.DictionariesFirstWord;
                    dictionaryFirstWordSkipDigits = options.DictionariesFirstSkipDigits;
                    dictionaryFirstWordSkipSpecials = options.DictionariesFirstSkipSpecials;
                    dictionaryFirstWordForceLowercase = options.DictionariesFirstForceLowercase;
                    dictionaryFirstWordAddTypos = options.DictionariesFirstAddTypos;
                    dictionaryFirstWordReverseOrder = options.DictionariesFirstReverseOrder;
                }
                if (options.DictionariesFirstWordCustom != null)
                {
                    dictionaryFirstWordCustom = _options.DictionariesFirstWordCustom;
                    dictionaryFirstWordCustomSkipDigits = options.DictionariesFirstCustomSkipDigits;
                    dictionaryFirstWordCustomSkipSpecials = options.DictionariesFirstCustomSkipSpecials;
                    dictionaryFirstWordCustomForceLowercase = options.DictionariesFirstCustomForceLowercase;
                    dictionaryFirstWordCustomAddTypos = options.DictionariesFirstCustomAddTypos;
                }
                if (options.DictionariesFirstWordExclude != null)
                {
                    dictionaryFirstWordExclude = _options.DictionariesFirstWordExclude;
                    dictionaryFirstWordExcludePartialWords = options.DictionariesFirstWordExcludePartialWords;
                }

                _dictionariesFirst = GetDictionaries(dictionaryFirstWord, options.DictionaryFilterFirst, dictionaryFirstWordSkipDigits, dictionaryFirstWordSkipSpecials, dictionaryFirstWordForceLowercase, dictionaryFirstWordAddTypos,
                    dictionaryFirstWordCustom, dictionaryFirstWordCustomSkipDigits, dictionaryFirstWordCustomSkipSpecials, dictionaryFirstWordCustomForceLowercase, dictionaryFirstWordCustomAddTypos,
                    dictionaryFirstWordReverseOrder, dictionaryFirstWordExclude, dictionaryFirstWordExcludePartialWords);
            }

            //Load last word dictionary
            var dictionaryLastWord = _options.Dictionaries;
            var dictionaryLastWordSkipDigits = options.DictionariesSkipDigits;
            var dictionaryLastWordSkipSpecials = options.DictionariesSkipSpecials;
            var dictionaryLastWordForceLowercase = options.DictionariesForceLowercase;
            var dictionaryLastWordAddTypos = options.DictionariesAddTypos;
            var dictionaryLastWordCustom = options.DictionariesCustom;
            var dictionaryLastWordCustomSkipDigits = options.DictionariesCustomSkipDigits;
            var dictionaryLastWordCustomSkipSpecials = options.DictionariesCustomSkipSpecials;
            var dictionaryLastWordCustomForceLowercase = options.DictionariesCustomForceLowercase;
            var dictionaryLastWordCustomAddTypos = options.DictionariesCustomAddTypos;
            var dictionaryLastWordReverseOrder = options.DictionariesReverseOrder;
            var dictionaryLastWordExclude = _options.DictionariesExclude;
            var dictionaryLastWordExcludePartialWords = _options.DictionariesExcludePartialWords;
            if (options.DictionariesLastWord == null && options.DictionariesLastWordCustom == null && options.DictionariesLastWordExclude == null)
            {
                _dictionariesLast = _dictionaries;
            }
            else
            {
                if (options.DictionariesLastWord != null)
                {
                    dictionaryLastWord = _options.DictionariesLastWord;
                    dictionaryLastWordSkipDigits = options.DictionariesLastSkipDigits;
                    dictionaryLastWordSkipSpecials = options.DictionariesLastSkipSpecials;
                    dictionaryLastWordForceLowercase = options.DictionariesLastForceLowercase;
                    dictionaryLastWordAddTypos = options.DictionariesLastAddTypos;
                    dictionaryLastWordReverseOrder = options.DictionariesLastReverseOrder;
                }
                if (options.DictionariesLastWordCustom != null)
                {
                    dictionaryLastWordCustom = _options.DictionariesLastWordCustom;
                    dictionaryLastWordCustomSkipDigits = options.DictionariesLastCustomSkipDigits;
                    dictionaryLastWordCustomSkipSpecials = options.DictionariesLastCustomSkipSpecials;
                    dictionaryLastWordCustomForceLowercase = options.DictionariesLastCustomForceLowercase;
                    dictionaryLastWordCustomAddTypos = options.DictionariesLastCustomAddTypos;
                }
                if (options.DictionariesLastWordExclude != null)
                {
                    dictionaryLastWordExclude = _options.DictionariesLastWordExclude;
                    dictionaryLastWordExcludePartialWords = options.DictionariesLastWordExcludePartialWords;
                }

                _dictionariesLast = GetDictionaries(dictionaryLastWord, null, dictionaryLastWordSkipDigits, dictionaryLastWordSkipSpecials, dictionaryLastWordForceLowercase, dictionaryLastWordAddTypos,
                    dictionaryLastWordCustom, dictionaryLastWordCustomSkipDigits, dictionaryLastWordCustomSkipSpecials, dictionaryLastWordCustomForceLowercase, dictionaryLastWordCustomAddTypos,
                    dictionaryLastWordReverseOrder, dictionaryLastWordExclude, dictionaryLastWordExcludePartialWords);
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
            _logger.Log($"Delimiters: Between {_options.MinDelimiters} and {_options.MaxDelimiters}");
            _logger.Log($"Words Length: Between {_options.MinWordLength} and {_options.MaxWordLength}");
            _logger.Log($"Ones Limit: Between {_options.MinOnes} and {_options.MaxOnes}");
            _logger.Log($"Twos Limit: Between {_options.MinTwos} and {_options.MaxTwos}");
            _logger.Log($"Threes Limit: Between {_options.MinThrees} and {_options.MaxThrees}");
            _logger.Log($"Fours Limit: Between {_options.MinFours} and {_options.MaxFours}");
            if (_options.AtLeastAboveChars > 0 && _options.AtLeastAboveWords > 0)
                _logger.Log($"Size: At least {_options.AtLeastAboveWords} words above {_options.AtLeastAboveChars} characters");
            if (_options.AtLeastUnderChars > 0 && _options.AtLeastUnderWords > 0)
                _logger.Log($"Size: At least {_options.AtLeastUnderWords} words under {_options.AtLeastUnderChars} characters");
            _logger.Log($"Concatenated Words: Between {_options.MinConcatenatedWords} and {_options.MaxConcatenatedWords}");
            _logger.Log($"Consecutive Concatenation Limit: Between  {_options.MinConsecutiveConcatenation} and  {_options.MaxConsecutiveConcatenation}");
            _logger.Log($"Max Consecutive Ones: {_options.MaxConsecutiveOnes}");
            _logger.Log($"Words Limit: Between {_options.MinWordsLimit} and {_options.WordsLimit}");
            _logger.Log($"Only First Two Words Concatenated: {_options.ConcatenateFirstTwoWords}");
            _logger.Log($"Only Last Two Words Concatenated: {_options.ConcatenateLastTwoWords}");

            if (!string.IsNullOrEmpty(_options.ExcludePatterns))
                _logger.Log($"Exclude Patterns: {_options.ExcludePatterns}");
            if (!string.IsNullOrEmpty(_options.IncludePatterns))
                _logger.Log($"Include Patterns: {_options.IncludePatterns}");
            if (!string.IsNullOrEmpty(_options.IncludeWord))
            {
                _logger.Log($"Include Word: {_options.IncludeWord}");
                _logger.Log($"Include Word - Skip first word: {_options.IncludeWordNotFirst}");
            }
            _logger.Log($"Combinations found: {_combinationPatterns.Count()}");
            _logger.Log($"Combination Order Algorithm: {_options.Order}");
            _logger.Log($"Combination Order Longer words first: {_options.OrderLongerWordsFirst}");
            if (_options.Verbose)
            {
                _logger.Log($"Dictionaries: {_options.Dictionaries}");
                _logger.Log($"Dictionaries Skip Digits: {_options.DictionariesSkipDigits}");
                _logger.Log($"Dictionaries Skip Specials: {_options.DictionariesSkipSpecials}");
                _logger.Log($"Dictionaries Force LowerCase: {_options.DictionariesForceLowercase}");
                _logger.Log($"Dictionaries Add Typo: {_options.DictionariesAddTypos}");
                _logger.Log($"Dictionaries Reverse Order: {_options.DictionariesReverseOrder}");
                if (!string.IsNullOrEmpty(_options.DictionariesCustom))
                {
                    _logger.Log($"Dictionaries (Custom): {_options.DictionariesCustom}");
                    _logger.Log($"Dictionaries (Custom) Skip Digits: {_options.DictionariesCustomSkipDigits}");
                    _logger.Log($"Dictionaries (Custom) Skip Specials: {_options.DictionariesCustomSkipSpecials}");
                    _logger.Log($"Dictionaries (Custom) Force LowerCase: {_options.DictionariesCustomForceLowercase}");
                    _logger.Log($"Dictionaries (Custom) Add Typo: {_options.DictionariesCustomAddTypos}");
                    _logger.Log($"Dictionaries (Custom) At least {_options.DictionariesCustomMinWordsHash} words in hash");
                }
                if (!string.IsNullOrEmpty(_options.DictionariesExclude))
                {
                    _logger.Log($"Dictionaries (Exclude): {_options.DictionariesExclude}");
                    _logger.Log($"Dictionaries (Exclude) Use Partial Words: {(_options.DictionariesExcludePartialWords ? "Yes": "No")}");
                }
            }
            _logger.Log($"Dictionary words: {_dictionaries.Values.Sum(p => p.Length)}");
            if (_dictionaries != _dictionariesFirst)
            {
                if (_options.Verbose)
                {
                    _logger.Log($"Dictionaries (1st word): {_options.DictionariesFirstWord}");
                    _logger.Log($"Dictionaries (1st word) Skip Digits: {_options.DictionariesFirstSkipDigits}");
                    _logger.Log($"Dictionaries (1st word) Skip Specials: {_options.DictionariesFirstSkipSpecials}");
                    _logger.Log($"Dictionaries (1st word) Force LowerCase: {_options.DictionariesFirstForceLowercase}");
                    _logger.Log($"Dictionaries (1st word) Add Typo: {_options.DictionariesFirstAddTypos}");
                    _logger.Log($"Dictionaries (1st word) Reverse Order: {_options.DictionariesFirstReverseOrder}");
                    if (!string.IsNullOrEmpty(_options.DictionariesFirstWordCustom))
                    {
                        _logger.Log($"Dictionaries (1st word) (Custom): {_options.DictionariesFirstWordCustom}");
                        _logger.Log($"Dictionaries (1st word) (Custom) Skip Digits: {_options.DictionariesFirstCustomSkipDigits}");
                        _logger.Log($"Dictionaries (1st word) (Custom) Skip Specials: {_options.DictionariesFirstCustomSkipSpecials}");
                        _logger.Log($"Dictionaries (1st word) (Custom) Force LowerCase: {_options.DictionariesFirstCustomForceLowercase}");
                        _logger.Log($"Dictionaries (1st word) (Custom) Add Typo: {_options.DictionariesFirstCustomAddTypos}");
                    }
                    if (!string.IsNullOrEmpty(_options.DictionariesFirstWordExclude))
                    {
                        _logger.Log($"Dictionaries (1st word) (Exclude): {_options.DictionariesFirstWordExclude}");
                        _logger.Log($"Dictionaries (1st word) (Exclude) Use Partial Words: {(_options.DictionariesFirstWordExcludePartialWords ? "Yes" : "No")}");
                    }
                }
                _logger.Log($"Dictionaries (1st word) words: {_dictionariesFirst.Values.Sum(p => p.Length)}");
            }
            if (!string.IsNullOrEmpty(_options.DictionaryFilterFirst))
                _logger.Log($"Dictionaries (1st word) filter: {_options.DictionaryFilterFirst}");
            if (_dictionaries != _dictionariesLast)
            {
                if (_options.Verbose)
                {
                    _logger.Log($"Dictionaries (last word): {_options.DictionariesLastWord}");
                    _logger.Log($"Dictionaries (last word) Skip Digits: {_options.DictionariesLastSkipDigits}");
                    _logger.Log($"Dictionaries (last word) Skip Specials: {_options.DictionariesLastSkipSpecials}");
                    _logger.Log($"Dictionaries (last word) Force LowerCase: {_options.DictionariesLastForceLowercase}");
                    _logger.Log($"Dictionaries (last word) Add Typo: {_options.DictionariesLastAddTypos}");
                    _logger.Log($"Dictionaries (last word) Reverse Order: {_options.DictionariesLastReverseOrder}");
                    if (!string.IsNullOrEmpty(_options.DictionariesLastWordCustom))
                    {
                        _logger.Log($"Dictionaries (last word) (Custom): {_options.DictionariesLastWordCustom}");
                        _logger.Log($"Dictionaries (last word) (Custom) Skip Digits: {_options.DictionariesLastCustomSkipDigits}");
                        _logger.Log($"Dictionaries (last word) (Custom) Skip Specials: {_options.DictionariesLastCustomSkipSpecials}");
                        _logger.Log($"Dictionaries (last word) (Custom) Force LowerCase: {_options.DictionariesLastCustomForceLowercase}");
                        _logger.Log($"Dictionaries (last word) (Custom) Add Typo: {_options.DictionariesLastCustomAddTypos}");
                    }
                    if (!string.IsNullOrEmpty(_options.DictionariesLastWordExclude))
                    {
                        _logger.Log($"Dictionaries (last word) (Exclude): {_options.DictionariesLastWordExclude}");
                        _logger.Log($"Dictionaries (last word) (Exclude) Use Partial Words: {(_options.DictionariesLastWordExcludePartialWords ? "Yes" : "No")}");
                    }
                }
                _logger.Log($"Dictionaries (last word) words: {_dictionariesLast.Values.Sum(p => p.Length)}");
            }


            if (_options.Verbose)
            {
                for (int i = 1; i <= _stringLength - Encoding.UTF8.GetByteCount(_options.Prefix) - Encoding.UTF8.GetByteCount(_options.Suffix); i++)
                {
                    _logger.Log($"{i}-letter words: {_dictionaries[$"{{{i}}}"].Length}", false);
                }
            }
            _logger.Log($"Search on: {_stringLength - Encoding.UTF8.GetByteCount(_options.Prefix) - Encoding.UTF8.GetByteCount(_options.Suffix)} characters");
            _logger.Log("-----------------------------------------");

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

                string args = $"--hash-type 11500 -a 0 {_hexExtract:x}:00000000 --outfile \"{output}\" \"{dictionaryPath}\"";
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
            string currentWord;
            bool lastWord;
            int nextDelimiter;
            bool appendDelimiterByte;

            int nextActualDel = combinationPattern.IndexOf(_delimiter);
            int nextFakeDel = combinationPattern.IndexOf("|");
            if (nextActualDel == -1)
                nextDelimiter = nextFakeDel;
            else
            {

                if (nextFakeDel == -1)
                    nextDelimiter = nextActualDel;
                else
                    nextDelimiter = Math.Min(nextActualDel, nextFakeDel);
            }

            appendDelimiterByte = nextActualDel == nextDelimiter;
            lastWord = nextDelimiter == -1;

            if (lastWord)
            {
                currentWord = combinationPattern;
            }

            else
            {
                currentWord = combinationPattern.Substring(0, nextDelimiter);
                if (!currentWord.StartsWith("{"))
                {
                    candidate.Append(currentWord);
                    if (_delimiterLength > 0 && appendDelimiterByte)
                        candidate.Append(_delimiterByte);
                    combinationPattern = combinationPattern[(currentWord.Length + 1)..];
                    RunDictionaries(candidate, combinationPattern, false);
                    candidate.Cursor -= Encoding.UTF8.GetByteCount(currentWord) + (appendDelimiterByte ? _delimiterLength : 0);
                    return;
                }
                combinationPattern = combinationPattern[(nextDelimiter + 1)..];
            }

            if (lastWord && !currentWord.StartsWith("{"))
            {
                candidate.Replace(combinationPattern);
                _testCandidate(candidate);
            }
            else
            {
                byte[][] words;
                if (lastWord)
                    words = _dictionariesLast[currentWord];
                else if (firstWord)
                    words = _dictionariesFirst[currentWord];
                else
                    words = _dictionaries[currentWord];
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
                        if (_delimiterLength > 0 && appendDelimiterByte)
                            candidate.Append(_delimiterByte);
                        RunDictionaries(candidate, combinationPattern, false);
                        candidate.Cursor -= word.Length + (appendDelimiterByte ? _delimiterLength : 0);
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

        #region Generate Dictionaries
        private Dictionary<string, byte[][]> GetDictionaries(string dictionaries, string dictionariesFilterFirst, bool skipDigits, bool skipSpecials, bool forceLowerCase, bool addTypos,
           string dictionariesCustom, bool customSkipDigits, bool customSkipSpecials, bool customForceLowerCase, bool customAddTypos, bool reverseOrder,
           string dictionariesExclude, bool excludePartialWords)
        {
            Dictionary<string, HashSet<string>> dictionaryHashRef = new Dictionary<string, HashSet<string>>();
            var output = new Dictionary<string, byte[][]>();

            //Fill if no data present
            for (int i = 1; i <= 100; i++)
                dictionaryHashRef.Add($"{{{i}}}", new HashSet<string>());

            FillDictionaries(dictionaryHashRef, dictionaries, dictionariesFilterFirst, skipDigits, skipSpecials, forceLowerCase, addTypos);
            FillDictionaries(dictionaryHashRef, dictionariesCustom, null, customSkipDigits, customSkipSpecials, customForceLowerCase, customAddTypos);

            //Exclude
            if (!string.IsNullOrEmpty(dictionariesExclude) && File.Exists(dictionariesExclude))
            {
                var allExcludeWords = File.ReadAllLines(dictionariesExclude);

                foreach (var hashSet in dictionaryHashRef.Values)
                {
                    var toFilterOut = new List<string>();
                    foreach (var value in hashSet)
                    {
                        if ((excludePartialWords == true && allExcludeWords.Any(p => value.Contains(p))) || (excludePartialWords == false && allExcludeWords.Any(p => value == p)))
                            toFilterOut.Add(value);
                    }
                    foreach (var toFilterOutEntry in toFilterOut)
                    {
                        hashSet.Remove(toFilterOutEntry);
                    }
                }
            }

            foreach (var entry in dictionaryHashRef)
            {
                output.Add(entry.Key, new byte[entry.Value.Count][]);
                if (reverseOrder)
                    output[entry.Key] = entry.Value.OrderByDescending(p => p).Select(p => Encoding.UTF8.GetBytes(p)).ToArray();
                else
                    output[entry.Key] = entry.Value.OrderBy(p => p).Select(p => Encoding.UTF8.GetBytes(p)).ToArray();
            }


            return output;
        }

        private void FillDictionaries(Dictionary<string, HashSet<string>> dictionaryHashRef, string dictionaries, string dictionariesFilterFirst, bool skipDigits, bool skipSpecials, bool forceLowerCase, bool addTypos)
        {
            string[] allDictionaries;
            if (Directory.Exists("Dictionaries") && dictionaries == "*")
                allDictionaries = Directory.GetFiles("Dictionaries", "*.dic");
            else
                allDictionaries = dictionaries.Split(";", StringSplitOptions.RemoveEmptyEntries);

            var filterStartList = GetFilterStartList(dictionariesFilterFirst);

            foreach (var dictionaryPath in allDictionaries)
            {
                var allWords = File.ReadAllLines(dictionaryPath);
                foreach (var word in allWords)
                {
                    if (word.Length == 0)
                        continue;

                    var wordToAdd = word.Length > 1 ? word.Trim() : word;
                    if (skipDigits && wordToAdd.Any(char.IsDigit))
                        continue;
                    if (skipSpecials && !_specialCharactersRegex.IsMatch(wordToAdd))
                        continue;

                    if (forceLowerCase)
                        wordToAdd = word.ToLower();

                    if (filterStartList != null && !filterStartList.Contains(wordToAdd[0]))
                        continue;

                    if (addTypos && Encoding.UTF8.GetByteCount(wordToAdd) > 3)
                    {
                        var allNewWords = new List<string>();
                        allNewWords.Add(wordToAdd);
                        allNewWords.AddRange(GenerateTypos(wordToAdd));
                        if (_options.TyposEnableLetterSwap)
                            allNewWords.AddRange(GenerateLetterSwapTypos(wordToAdd, 'l', 'r'));
                        foreach (var newWord in allNewWords)
                        {
                            var lengthStr = $"{{{Encoding.UTF8.GetByteCount(newWord)}}}";
                            if (!dictionaryHashRef[lengthStr].Contains(newWord))
                            {
                                if (filterStartList != null && !filterStartList.Contains(newWord[0]))
                                    continue;
                                dictionaryHashRef[lengthStr].Add(newWord);
                            }
                        }
                    }
                    else
                    {
                        var lengthStr = $"{{{Encoding.UTF8.GetByteCount(wordToAdd)}}}";
                        if (!dictionaryHashRef[lengthStr].Contains(wordToAdd))
                            dictionaryHashRef[lengthStr].Add(wordToAdd);
                    }
                }
            }
        }

        public static IEnumerable<char> GetFilterStartList(string dictionariesFilterFirst)
        {
            if (string.IsNullOrEmpty(dictionariesFilterFirst))
                return null;

            var split = dictionariesFilterFirst.Split("-");
            var dictionariesFilterFirstA = split.Length == 2 ? split[0] : string.Empty;
            var dictionariesFilterFirstB = split.Length == 2 ? split[1] : string.Empty;

            if (!string.IsNullOrEmpty(dictionariesFilterFirstA) && !string.IsNullOrEmpty(dictionariesFilterFirstB))
                return Enumerable.Range((int)dictionariesFilterFirstA[0], (int)dictionariesFilterFirstB[0] - (int)dictionariesFilterFirstA[0] + 1).Select(i => (char)i);

            return null;
        }

        private static IEnumerable<string> GenerateLetterSwapTypos(string input, char char1, char char2)
        {
            var head = input[0] == char1 || input[0] == char2
                ? new[] { char1.ToString(), char2.ToString() }
                : new[] { input[0].ToString() };

            var tails = Encoding.UTF8.GetByteCount(input) > 1
                ? GenerateLetterSwapTypos(input.Substring(1), char1, char2)
                : new[] { "" };

            return
                from h in head
                from t in tails
                select h + t;
        }

        private string SwapCharacter(string input, char insertChar, int index)
        {
            string f = input.Substring(0, index);
            string l = input.Substring(index + 1);

            return f + insertChar + l;
        }

        private char[][] GetKeyboardMapping()
        {
            var keyboardMapping = new char[3][];
            keyboardMapping[0] = new char[] { 'q', 'w', 'e', 'r', 't', 'y', 'u', 'i', 'o', 'p' };
            keyboardMapping[1] = new char[] { 'a', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l' };
            keyboardMapping[2] = new char[] { 'z', 'x', 'c', 'v', 'b', 'n', 'm' };
            return keyboardMapping;
        }

        private bool IsArraySizeValid<T>(IEnumerable<T> array, int size)
        {
            return size >= 0 && array.Count() > size;
        }

        private List<char> IsItemInArrayNearest(char[][] keyboard, char character)
        {
            var nearKeys = new List<char>();
            for (var i = 0; i < keyboard.Length; i++)
            {
                for (var j = 0; j < keyboard[i].Length; j++)
                {
                    if (keyboard[i][j] == character)
                    {
                        if (IsArraySizeValid(keyboard, i) && IsArraySizeValid(keyboard[i], j + 1))
                        {
                            nearKeys.Add(keyboard[i][j + 1]);
                        }
                        if (IsArraySizeValid(keyboard, i + 1) && IsArraySizeValid(keyboard[i + 1], j))
                        {
                            nearKeys.Add(keyboard[i + 1][j]);
                        }
                        if (IsArraySizeValid(keyboard, i + 1) && IsArraySizeValid(keyboard[i + 1], j + 1))
                        {
                            nearKeys.Add(keyboard[i + 1][j + 1]);
                        }
                        if (IsArraySizeValid(keyboard, i) && IsArraySizeValid(keyboard[i], j - 1))
                        {
                            nearKeys.Add(keyboard[i][j - 1]);
                        }
                        if (IsArraySizeValid(keyboard, i - 1) && IsArraySizeValid(keyboard[i - 1], j - 1))
                        {
                            nearKeys.Add(keyboard[i - 1][j - 1]);
                        }
                        if (IsArraySizeValid(keyboard, i - 1) && IsArraySizeValid(keyboard[i - 1], j))
                        {
                            nearKeys.Add(keyboard[i - 1][j]);
                        }
                        if (IsArraySizeValid(keyboard, i - 1) && IsArraySizeValid(keyboard[i - 1], j + 1))
                        {
                            nearKeys.Add(keyboard[i - 1][j + 1]);
                        }
                        if (IsArraySizeValid(keyboard, i + 1) && IsArraySizeValid(keyboard[i + 1], j - 1))
                        {
                            nearKeys.Add(keyboard[i + 1][j - 1]);
                        }
                    }
                }
            }
            return nearKeys;
        }

        private IEnumerable<string> GenerateTypos(string word)
        {
            var typo = new List<string>();
            var wordLength = word.Length;

            if (wordLength < 2)
                return typo;

            var qwertyKeyboard = GetKeyboardMapping();

            for (var j = wordLength - 1; j >= 0; j--)
            {
                if (_options.TyposEnableSkipLetter)
                    typo.Add(word.Substring(0, j) + word.Substring(j + 1)); // Skip letter
                if (_options.TyposEnableDoubleLetter)
                    typo.Add(word.Insert(j, word[j].ToString())); // Double Letter

                var keyboardChars = IsItemInArrayNearest(qwertyKeyboard, word[j]);
                // Extra Letter & Wrong letter
                for (var k = 0; k < keyboardChars.Count; k++)
                {
                    if (_options.TyposEnableExtraLetter)
                        typo.Add(word.Insert(j, keyboardChars[k].ToString())); // Extra letter
                    if (_options.TyposEnableWrongLetter)
                        typo.Add(word.Substring(0, j) + keyboardChars[k] + word.Substring(j + 1)); //Wrong letter
                }

                if (_options.TyposEnableReverseLetter)
                {
                    // Reverse letters
                    if (wordLength > j + 1)
                    {
                        var tempChar = word[j];
                        var tempChar2 = word[j + 1];
                        var reversedWord = SwapCharacter(word, tempChar, j + 1);
                        reversedWord = SwapCharacter(reversedWord, tempChar2, j);
                        typo.Add(reversedWord);
                    }
                }
            }
            return typo;
        }
        #endregion

        #region Generate Combinations
        private IEnumerable<string> GenerateCombinations(int stringLength)
        {
            var includeWords = _options.IncludeWord.Split(",", StringSplitOptions.RemoveEmptyEntries);
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
                    if (includeWords.Length > 0)
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

            return output.Distinct();
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
                if (_options.AtLeastAboveWords > 0 || _options.AtLeastUnderWords > 0)
                {
                    var dictNbr = new int[11];
                    for (var i = 0; i < dictNbr.Length; i++)
                    {
                        dictNbr[i] = pattern.Split("{" + (i + 1) + "}").Length - 1;
                    }
                    if (_options.AtLeastAboveWords > 0 && dictNbr.Where((p, i) => i > _options.AtLeastAboveChars - 1).Sum() < _options.AtLeastAboveWords)
                        continue;
                    if (_options.AtLeastUnderWords > 0 && dictNbr.Where((p, i) => i < _options.AtLeastUnderChars - 1).Sum() < _options.AtLeastUnderWords)
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
        #endregion
    }
}
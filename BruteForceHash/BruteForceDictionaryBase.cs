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
    public abstract class BruteForceDictionaryBase
    {
        protected readonly Logger _logger;
        protected readonly IEnumerable<string> _combinationPatterns;
        protected readonly Dictionary<string, byte[][]> _dictionaries;
        protected readonly Dictionary<string, byte[][]> _dictionariesFirst;
        protected readonly Dictionary<string, byte[][]> _dictionariesLast;
        protected readonly Options _options;
        protected readonly uint _hexValue;
        protected readonly int _combinationSize;
        protected readonly int _stringLength;
        protected readonly string _delimiter;
        protected readonly byte _delimiterByte;
        protected readonly int _delimiterLength;
        protected readonly int _minWordLength;
        protected readonly int _maxWordLength;
        protected readonly int _maxDelimiters;
        protected readonly int _minDelimiters;
        protected readonly int _maxConsecutives;
        protected readonly int _minConsecutives;
        protected readonly int _maxWords;
        protected readonly int _minWords;
        protected readonly bool _concatenateOnlyLastTwo;
        protected readonly bool _concatenateOnlyFirstTwo;
        protected readonly int _maxOnes;
        protected readonly int _minOnes;
        protected readonly int _maxTwos;
        protected readonly int _minTwos;
        protected readonly int _maxThrees;
        protected readonly int _minThrees;
        protected readonly int _maxFours;
        protected readonly int _minFours;
        protected readonly int _maxConsecutiveOnes;
        protected readonly int _maxConsecutiveConcatenated;
        protected readonly int _minConsecutiveConcatenated;
        protected readonly Regex _specialCharactersRegex = new Regex("^[a-zA-Z0-9_]*$", RegexOptions.Compiled);
        protected CancellationTokenSource _cancellationTokenSource;
        protected int _foundResult = 0;

        public BruteForceDictionaryBase(Logger logger, Options options, int stringLength, uint hexValue)
        {
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
            _options.IncludeWord = _options.IncludeWord.ToLower();

            //Calculate stringLength after prefix;
            _stringLength = stringLength;

            //Generate combinations
            _combinationSize = _stringLength - Encoding.UTF8.GetByteCount(options.Prefix) - Encoding.UTF8.GetByteCount(options.Suffix);
            _maxWordLength = Math.Min(options.MaxWordLength, _stringLength);
            _combinationPatterns = GenerateCombinations(_combinationSize);

            //Filter combinations
            var isFirstFilterFrom = !string.IsNullOrEmpty(options.DictionaryFilterFirstFrom);
            var isFirstFilterTo = !string.IsNullOrEmpty(options.DictionaryFilterFirstTo);
            if ((isFirstFilterFrom || isFirstFilterTo) && (options.DictionariesCustomMinWordsHash > 0 || !string.IsNullOrEmpty(options.IncludeWord)))
            {
                _combinationPatterns = _combinationPatterns.Where(p =>
                    p.StartsWith("{") || (
                        (!isFirstFilterFrom || string.Compare(p, options.DictionaryFilterFirstFrom) > 0) &&
                        (!isFirstFilterTo || string.Compare(p, options.DictionaryFilterFirstTo) < 0)
                    )
                ); ;
            }

            //Load common dictionary
            _dictionaries = GetDictionaries(_options.Dictionaries, null, null, options.DictionariesSkipDigits, options.DictionariesSkipSpecials, options.DictionariesForceLowercase, options.DictionariesAddTypos,
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
            if (options.DictionariesFirstWord == null && options.DictionariesFirstWordCustom == null && options.DictionariesFirstWordExclude == null 
                && string.IsNullOrEmpty(options.DictionaryFilterFirstFrom) && string.IsNullOrEmpty(options.DictionaryFilterFirstTo))
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

                _dictionariesFirst = GetDictionaries(dictionaryFirstWord, options.DictionaryFilterFirstFrom, options.DictionaryFilterFirstTo, dictionaryFirstWordSkipDigits, dictionaryFirstWordSkipSpecials, dictionaryFirstWordForceLowercase, dictionaryFirstWordAddTypos,
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

                _dictionariesLast = GetDictionaries(dictionaryLastWord, null, null, dictionaryLastWordSkipDigits, dictionaryLastWordSkipSpecials, dictionaryLastWordForceLowercase, dictionaryLastWordAddTypos,
                    dictionaryLastWordCustom, dictionaryLastWordCustomSkipDigits, dictionaryLastWordCustomSkipSpecials, dictionaryLastWordCustomForceLowercase, dictionaryLastWordCustomAddTypos,
                    dictionaryLastWordReverseOrder, dictionaryLastWordExclude, dictionaryLastWordExcludePartialWords);
            }
        }

        protected void PrintHeaders()
        {
            _logger.Log($"Delimiter: {_delimiter}");
            _logger.Log($"Delimiters: Between {_options.MinDelimiters} and {_options.MaxDelimiters}");
            _logger.Log($"Words Limit: {_options.WordsLimit}");
            _logger.Log($"Words Length: Between {_options.MinWordLength} and {_options.MaxWordLength}");
            _logger.Log($"Ones Limit: Between {_options.MinOnes} and {_options.MaxOnes}");
            _logger.Log($"Twos Limit: Between {_options.MinTwos} and {_options.MaxTwos}");
            _logger.Log($"Threes Limit: Between {_options.MinThrees} and {_options.MaxThrees}");
            _logger.Log($"Fours Limit: Between {_options.MinFours} and {_options.MaxFours}");

            if (_options.AtLeastAboveChars > 0 && _options.AtLeastAboveWords > 0)
                _logger.Log($"Size: At least {_options.AtLeastAboveWords} word(s) greater than/equal to {_options.AtLeastAboveChars} character(s)");
            if (_options.AtLeastUnderChars > 0 && _options.AtLeastUnderWords > 0)
                _logger.Log($"Size: At least {_options.AtLeastUnderWords} word(s) less than/equal to {_options.AtLeastUnderChars} character(s)");
            if (_options.AtMostAboveChars > 0 && _options.AtMostAboveWords > 0)
                _logger.Log($"Size: At most {_options.AtMostAboveWords} word(s) greater than/equal to {_options.AtMostAboveChars} character(s)");
            if (_options.AtMostUnderChars > 0 && _options.AtMostUnderWords > 0)
                _logger.Log($"Size: At most {_options.AtMostUnderWords} word(s) less than/equal to {_options.AtMostUnderChars} character(s)");

            if (!string.IsNullOrEmpty(_options.ExcludePatterns))
                _logger.Log($"Exclude Patterns: {_options.ExcludePatterns}");
            if (!string.IsNullOrEmpty(_options.IncludePatterns))
                _logger.Log($"Include Patterns: {_options.IncludePatterns}");
            if (!string.IsNullOrEmpty(_options.IncludeWord))
            {
                _logger.Log($"Include Word: {_options.IncludeWord}");
                _logger.Log($"Include Word - Skip first word: {_options.IncludeWordNotFirst}");
            }

            if (this is BruteForceDictionaryAdvanced)
            {
                _logger.Log($"Concatenated Words: Between {_options.MinConcatenatedWords} and {_options.MaxConcatenatedWords}");
                _logger.Log($"Consecutive Concatenation Limit: Between {_options.MinConsecutiveConcatenation} and  {_options.MaxConsecutiveConcatenation}");
                _logger.Log($"Max Consecutive Ones: {_options.MaxConsecutiveOnes}");
                _logger.Log($"Words Limit: Between {_options.MinWordsLimit} and {_options.WordsLimit}");
                _logger.Log($"Only First Two Words Concatenated: {_options.ConcatenateFirstTwoWords}");
                _logger.Log($"Only Last Two Words Concatenated: {_options.ConcatenateLastTwoWords}");
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
                    _logger.Log($"Dictionaries (Exclude) Use Partial Words: {(_options.DictionariesExcludePartialWords ? "Yes" : "No")}");
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
            if (!string.IsNullOrEmpty(_options.DictionaryFilterFirstFrom) && !string.IsNullOrEmpty(_options.DictionaryFilterFirstTo))
                _logger.Log($"Dictionaries (1st word) filter: Between '{_options.DictionaryFilterFirstFrom.Trim()}' and '{_options.DictionaryFilterFirstTo.Trim()}'");
            else if (!string.IsNullOrEmpty(_options.DictionaryFilterFirstFrom))
                _logger.Log($"Dictionaries (1st word) filter: From '{_options.DictionaryFilterFirstFrom.Trim()}'");
            else if (!string.IsNullOrEmpty(_options.DictionaryFilterFirstTo))
                _logger.Log($"Dictionaries (1st word) filter: Until '{_options.DictionaryFilterFirstTo.Trim()}'");
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
                for (int i = 1; i <= _combinationSize; i++)
                {
                    _logger.Log($"{i}-letter words: {_dictionaries[$"{{{i}}}"].Length}", false);
                }
            }
            _logger.Log($"Search on: {_combinationSize} characters");
            _logger.Log("-----------------------------------------");
        }

        public void Run()
        {
            //Run
            var taskScheduler = new LimitedConcurrencyLevelTaskScheduler(_options.NbrThreads);
            var tasks = new List<Task>();

            // Create a TaskFactory and pass it our custom scheduler.
            TaskFactory factory = new TaskFactory(taskScheduler);
            _cancellationTokenSource = new CancellationTokenSource();

            PrintHeaders();

            foreach (var combinationPattern in _combinationPatterns)
            {
                var task = factory.StartNew(() =>
                {
                    var strBuilder = new ByteString(_stringLength, _hexValue, _options.Prefix, _options.Suffix, true);
                    if (_options.Verbose)
                        _logger.Log($"Running Pattern: {combinationPattern}", false);
                    RunDictionaries(strBuilder, combinationPattern, true, _cancellationTokenSource.Token);
                });
                tasks.Add(task);
            }

            WaitForDictionariesToRun(tasks.ToArray(), _cancellationTokenSource.Token);

            //_cancellationTokenSource.Dispose();

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

        protected virtual void WaitForDictionariesToRun(Task[] tasks, CancellationToken cancellationToken)
        {
            Task.WaitAll(tasks, cancellationToken);
        }
        protected abstract void RunDictionaries(ByteString candidate, string combinationPattern, bool firstWord, CancellationToken cancellationToken);
        protected abstract IEnumerable<string> GenerateCombinations(int combinationSize);

        #region Generate Dictionaries
        private Dictionary<string, byte[][]> GetDictionaries(string dictionaries, string dictionariesFilterFirstFrom, string dictionariesFilterFirstTo, bool skipDigits, bool skipSpecials, bool forceLowerCase, bool addTypos,
            string dictionariesCustom, bool customSkipDigits, bool customSkipSpecials, bool customForceLowerCase, bool customAddTypos, bool reverseOrder,
            string dictionariesExclude, bool excludePartialWords)
        {
            Dictionary<string, HashSet<string>> dictionaryHashRef = new Dictionary<string, HashSet<string>>();
            var output = new Dictionary<string, byte[][]>();

            //Fill if no data present
            for (int i = 1; i <= 100; i++)
                dictionaryHashRef.Add($"{{{i}}}", new HashSet<string>());

            FillDictionaries(dictionaryHashRef, dictionaries, dictionariesFilterFirstFrom, dictionariesFilterFirstTo, skipDigits, skipSpecials, forceLowerCase, addTypos);
            FillDictionaries(dictionaryHashRef, dictionariesCustom, dictionariesFilterFirstFrom, dictionariesFilterFirstTo, customSkipDigits, customSkipSpecials, customForceLowerCase, customAddTypos);

            //Exclude
            if (!string.IsNullOrEmpty(dictionariesExclude) && File.Exists(dictionariesExclude))
            {
                var allExcludeWords = File.ReadAllLines(dictionariesExclude).Distinct();

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

        private void FillDictionaries(Dictionary<string, HashSet<string>> dictionaryHashRef, string dictionaries, string dictionariesFilterFirstFrom, string dictionariesFilterFirstTo, bool skipDigits, bool skipSpecials, bool forceLowerCase, bool addTypos)
        {
            if (string.IsNullOrEmpty(dictionaries))
                return;

            string[] allDictionaries;
            if (Directory.Exists("Dictionaries") && dictionaries == "*")
                allDictionaries = Directory.GetFiles("Dictionaries", "*.dic");
            else
                allDictionaries = dictionaries.Split(";", StringSplitOptions.RemoveEmptyEntries);

            var isFirstFilterFrom = !string.IsNullOrEmpty(dictionariesFilterFirstFrom);
            var isFirstFilterTo = !string.IsNullOrEmpty(dictionariesFilterFirstTo);

            foreach (var dictionaryPath in allDictionaries)
            {
                var allWords = File.ReadAllLines(dictionaryPath).Distinct();

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

                    if (isFirstFilterFrom && string.Compare(word, dictionariesFilterFirstFrom) < 0)
                        continue;
                    if (isFirstFilterTo && string.Compare(word, dictionariesFilterFirstTo) > 0)
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
                            var byteCount = Encoding.UTF8.GetByteCount(newWord);
                            if (byteCount < _minWordLength || byteCount > _maxWordLength)
                                continue;

                            var lengthStr = $"{{{byteCount}}}";
                            if (!dictionaryHashRef[lengthStr].Contains(newWord))
                            {
                                if (isFirstFilterFrom && string.Compare(newWord, dictionariesFilterFirstFrom) < 0)
                                    continue;
                                if (isFirstFilterTo && string.Compare(newWord, dictionariesFilterFirstTo) > 0)
                                    continue;

                                dictionaryHashRef[lengthStr].Add(newWord);
                            }
                        }
                    }
                    else
                    {
                        var byteCount = Encoding.UTF8.GetByteCount(wordToAdd);
                        if (byteCount < _minWordLength || byteCount > _maxWordLength)
                            continue;

                        var lengthStr = $"{{{byteCount}}}";
                        if (!dictionaryHashRef[lengthStr].Contains(wordToAdd))
                            dictionaryHashRef[lengthStr].Add(wordToAdd);
                    }
                }
            }
        }

        private IEnumerable<string> GenerateLetterSwapTypos(string input, char char1, char char2)
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
    }
}
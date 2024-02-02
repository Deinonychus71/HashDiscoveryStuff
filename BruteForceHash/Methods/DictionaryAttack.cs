using BruteForceHash.CombinationGenerator;
using BruteForceHash.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace BruteForceHash.Methods
{
    public class DictionaryAttack
    {
        protected readonly Logger _logger;
        protected readonly Options _options;
        protected readonly uint _hexValue;
        protected readonly int _combinationSize;
        protected CancellationTokenSource _cancellationTokenSource;
        protected TyposGenerator _typosGenerator;

        private readonly IEnumerable<string> _combinationPatterns;
        private readonly Dictionary<byte, byte[][]> _dictionaries;
        private readonly Dictionary<byte, byte[][]> _dictionariesFirst;
        private readonly Dictionary<byte, byte[][]> _dictionariesLast;
        private readonly byte _nullByte = 0x00;
        private readonly int _stringLength;
        private readonly string _delimiter;
        private readonly int _minWordLength;
        private readonly int _maxWordLength;
        private readonly Regex _specialCharactersRegex = new("^[a-zA-Z0-9_]*$", RegexOptions.Compiled);
        private readonly CombinationGeneratorBase _combinationGeneration;
        private int _foundResult = 0;

        public DictionaryAttack(Logger logger, Options options, int stringLength, uint hexValue)
        {
            _logger = logger;
            _options = options;
            _hexValue = hexValue;
            _typosGenerator = new TyposGenerator(options);
            if (string.IsNullOrEmpty(options.Delimiter))
            {
                _delimiter = "|";
            }
            else
            {
                _delimiter = options.Delimiter;
            }

            if (_options.MaxConcatenatedWords == 0)
                _combinationGeneration = new CombinationGeneratorSimple(options, stringLength);
            else
                _combinationGeneration = new CombinationGeneratorAdvanced(options, stringLength);

            _minWordLength = options.MinWordLength;

            //Calculate stringLength after prefix;
            _stringLength = stringLength;

            //Generate combinations
            _combinationSize = _stringLength - Encoding.UTF8.GetByteCount(options.Prefix) - Encoding.UTF8.GetByteCount(options.Suffix);
            _maxWordLength = Math.Min(options.MaxWordLength, _stringLength);
            _combinationPatterns = _combinationGeneration.GenerateCombinations(_combinationSize, _options.DictionariesCustom, _options.DictionariesCustomMinWordsHash);

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
                _logger.Log($"Include Word - Skip last word: {_options.IncludeWordNotLast}");
            }

            if (_options.MaxConcatenatedWords > 0)
            {
                _logger.Log($"Concatenated Words: Between {_options.MinConcatenatedWords} and {_options.MaxConcatenatedWords}");
                _logger.Log($"Consecutive Concatenation Limit: Between {_options.MinConsecutiveConcatenation} and {_options.MaxConsecutiveConcatenation}");
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
                for (byte i = 1; i <= _combinationSize; i++)
                {
                    _logger.Log($"{i}-letter words: {_dictionaries[i].Length}", false);
                }
            }
            _logger.Log($"Optimizations: {(_options.EnableDynamicPrefixCache ? _options.EnableDynamicSuffixCache ? "Prefix/Suffix" : "Prefix" : _options.EnableDynamicSuffixCache ? "Suffix" : "No")}");
            _logger.Log($"Search on: {_combinationSize} characters");
            _logger.Log("-----------------------------------------");
        }

        #region Run Attack
        public void Run()
        {
            //Run
            var taskScheduler = new LimitedConcurrencyLevelTaskScheduler(_options.NbrThreads);
            var tasks = new List<Task>();

            // Create a TaskFactory and pass it our custom scheduler.
            var factory = new TaskFactory(taskScheduler);
            _cancellationTokenSource = new CancellationTokenSource();

            PrintHeaders();

            _options.Prefix = _options.Prefix?.Trim();
            _options.Suffix = _options.Suffix?.Trim();
            var prefixBytes = !string.IsNullOrEmpty(_options.Prefix) ? Encoding.UTF8.GetBytes(_options.Prefix) : [];
            var suffixBytes = !string.IsNullOrEmpty(_options.Suffix) ? Encoding.UTF8.GetBytes(_options.Suffix) : [];

            foreach (var combinationPattern in _combinationPatterns)
            {
                var compiledCombination = _combinationGeneration.CompileCombination(combinationPattern);
                var isFirstWordDict = compiledCombination[0] == 0;
                var isLastWordDict = compiledCombination[^2] == 0;
                var firstDict = isFirstWordDict ? _dictionariesFirst : _dictionaries;
                var lastDict = isLastWordDict ? _dictionariesLast : _dictionaries;

                if (_options.EnableDynamicPrefixCache || _options.EnableDynamicSuffixCache)
                {
                    var numberWords = compiledCombination.Count(p => p == _nullByte);

                    if (numberWords > 2)
                    {
                        //First word & last word optimizations
                        if (_options.EnableDynamicPrefixCache && _options.EnableDynamicSuffixCache)
                        {
                            var nbrFirstDictWords = firstDict.Sum(p => p.Value.Length);
                            var nbrLastDictWords = lastDict.Sum(p => p.Value.Length);

                            if (nbrLastDictWords > nbrFirstDictWords)
                                RunSuffixOptimized(factory, tasks, compiledCombination, prefixBytes, suffixBytes, firstDict, lastDict, true);
                            else
                                RunPrefixOptimized(factory, tasks, compiledCombination, prefixBytes, suffixBytes, firstDict, lastDict, true);
                            continue;
                        }
                        //First word optimization only
                        else if (_options.EnableDynamicPrefixCache)
                        {
                            RunPrefixOptimized(factory, tasks, compiledCombination, prefixBytes, suffixBytes, firstDict, lastDict, false);
                            continue;
                        }
                        //Last word optimization only
                        else if (_options.EnableDynamicSuffixCache)
                        {
                            RunSuffixOptimized(factory, tasks, compiledCombination, prefixBytes, suffixBytes, firstDict, lastDict, false);
                            continue;
                        }
                    }
                }

                //No optimization
                tasks.Add(AddTaskToTaskScheduler(factory, combinationPattern, compiledCombination, prefixBytes, suffixBytes, firstDict, lastDict));
            }

            WaitForDictionariesToRun([.. tasks], _cancellationTokenSource.Token);

            //_cancellationTokenSource.Dispose(); //For Hashcat

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

        private void RunSuffixOptimized(TaskFactory taskFactory, List<Task> tasks, byte[] compiledCombination, byte[] prefixBytes, byte[] suffixBytes,
            Dictionary<byte, byte[][]> firstDict, Dictionary<byte, byte[][]> lastDict, bool runPrefixOptimization)
        {
            if (compiledCombination[^2] == 0)
            {
                var size = compiledCombination[^1];
                if (lastDict[size].Length == 0)
                    return;

                var strippedSize = Array.LastIndexOf(compiledCombination, _nullByte, compiledCombination.Length - 3) + 2;

                //Build new combination
                var strippedCompiledCombination = new byte[strippedSize];
                var strippedMidWordSize = compiledCombination.Length - strippedSize - 2;
                Buffer.BlockCopy(compiledCombination, 0, strippedCompiledCombination, 0, strippedSize);

                //Build Prefix
                var fullSuffix = new byte[suffixBytes.Length + size + strippedMidWordSize];
                Buffer.BlockCopy(compiledCombination, strippedSize, fullSuffix, 0, strippedMidWordSize);
                Buffer.BlockCopy(suffixBytes, 0, fullSuffix, strippedMidWordSize + size, suffixBytes.Length);
                foreach (var lastWord in lastDict[size])
                {
                    Buffer.BlockCopy(lastWord, 0, fullSuffix, strippedMidWordSize, size);

                    if (runPrefixOptimization && strippedCompiledCombination.Length > 2)
                        RunPrefixOptimized(taskFactory, tasks, strippedCompiledCombination, prefixBytes, [.. fullSuffix], firstDict, _dictionaries, false);
                    else
                        tasks.Add(AddTaskToTaskScheduler(taskFactory, null, strippedCompiledCombination, prefixBytes, [.. fullSuffix], firstDict, _dictionaries));
                }
            }
            else
            {
                var strippedSize = Array.LastIndexOf(compiledCombination, _nullByte, compiledCombination.Length - 1) + 2;

                //Build new combination
                var strippedCompiledCombination = new byte[strippedSize];
                var strippedMidWordSize = compiledCombination.Length - strippedSize;
                Buffer.BlockCopy(compiledCombination, 0, strippedCompiledCombination, 0, strippedSize);

                //Build Prefix
                var fullSuffix = new byte[suffixBytes.Length + strippedMidWordSize];
                Buffer.BlockCopy(compiledCombination, strippedSize, fullSuffix, 0, strippedMidWordSize);
                Buffer.BlockCopy(suffixBytes, 0, fullSuffix, strippedMidWordSize, suffixBytes.Length);

                if (runPrefixOptimization && strippedCompiledCombination.Length > 2)
                    RunPrefixOptimized(taskFactory, tasks, strippedCompiledCombination, prefixBytes, [.. fullSuffix], firstDict, _dictionaries, false);
                else
                    tasks.Add(AddTaskToTaskScheduler(taskFactory, null, strippedCompiledCombination, prefixBytes, [.. fullSuffix], firstDict, _dictionaries));
            }
        }

        private void RunPrefixOptimized(TaskFactory taskFactory, List<Task> tasks, byte[] compiledCombination, byte[] prefixBytes, byte[] suffixBytes,
            Dictionary<byte, byte[][]> firstDict, Dictionary<byte, byte[][]> lastDict, bool runPrefixOptimization)
        {
            if (compiledCombination[0] == 0)
            {
                var size = compiledCombination[1];
                if (firstDict[size].Length == 0)
                    return;

                var nextWordEndPos = Array.IndexOf(compiledCombination, _nullByte, 2);
                var strippedSize = compiledCombination.Length - nextWordEndPos;

                //Build new combination
                var strippedCompiledCombination = new byte[strippedSize];
                var strippedMidWordSize = nextWordEndPos - 2;
                Buffer.BlockCopy(compiledCombination, nextWordEndPos, strippedCompiledCombination, 0, strippedSize);

                //Build Prefix
                var fullPrefix = new byte[prefixBytes.Length + size + strippedMidWordSize];
                Buffer.BlockCopy(prefixBytes, 0, fullPrefix, 0, prefixBytes.Length);
                Buffer.BlockCopy(compiledCombination, 2, fullPrefix, prefixBytes.Length + size, strippedMidWordSize);
                foreach (var firstWord in firstDict[size])
                {
                    Buffer.BlockCopy(firstWord, 0, fullPrefix, prefixBytes.Length, size);

                    if (runPrefixOptimization && strippedCompiledCombination.Length > 2)
                        RunSuffixOptimized(taskFactory, tasks, strippedCompiledCombination, [.. fullPrefix], suffixBytes, _dictionaries, lastDict, false);
                    else
                        tasks.Add(AddTaskToTaskScheduler(taskFactory, null, strippedCompiledCombination, [.. fullPrefix], suffixBytes, _dictionaries, lastDict));
                }
            }
            else
            {
                var nextWordEndPos = Array.IndexOf(compiledCombination, _nullByte, 0);
                var strippedSize = compiledCombination.Length - nextWordEndPos;

                //Build new combination
                var strippedCompiledCombination = new byte[strippedSize];
                Buffer.BlockCopy(compiledCombination, nextWordEndPos, strippedCompiledCombination, 0, strippedSize);

                //Build Prefix
                var fullPrefix = new byte[prefixBytes.Length + nextWordEndPos];
                Buffer.BlockCopy(prefixBytes, 0, fullPrefix, 0, prefixBytes.Length);
                Buffer.BlockCopy(compiledCombination, 0, fullPrefix, prefixBytes.Length, nextWordEndPos);

                if (runPrefixOptimization && strippedCompiledCombination.Length > 2)
                    RunSuffixOptimized(taskFactory, tasks, strippedCompiledCombination, [.. fullPrefix], suffixBytes, _dictionaries, lastDict, false);
                else
                    tasks.Add(AddTaskToTaskScheduler(taskFactory, null, strippedCompiledCombination, [.. fullPrefix], suffixBytes, _dictionaries, lastDict));
            }
        }

        private Task AddTaskToTaskScheduler(TaskFactory taskFactory, string combinationPattern, byte[] compiledCombination, byte[] prefix, byte[] suffix,
            Dictionary<byte, byte[][]> firstDict, Dictionary<byte, byte[][]> lastDict)
        {
            return taskFactory.StartNew(() =>
            {
                var strBuilder = new ByteString(_stringLength, _hexValue, prefix, suffix, true);
                if (_options.Verbose)
                {
                    if (string.IsNullOrEmpty(combinationPattern))
                        _logger.Log($"Running Optimized Pattern: {CombinationGeneratorBase.DecompileCombination(compiledCombination)}", false);
                    else
                        _logger.Log($"Running Pattern: {combinationPattern}", false);
                }
                RunDictionaries(strBuilder, compiledCombination, firstDict, lastDict, 0, _cancellationTokenSource.Token);
            });
        }

        protected virtual void WaitForDictionariesToRun(Task[] tasks, CancellationToken cancellationToken)
        {
            Task.WaitAll(tasks, cancellationToken);
        }
        #endregion

        #region Run Attack - Per Dictionary
        protected void RunDictionaries(ByteString candidate, byte[] combinationPattern, Dictionary<byte, byte[][]> dictWords, Dictionary<byte, byte[][]> dictLastWord, int combinationCursor, CancellationToken cancellationToken)
        {
            //For Hashcat, disabled
            //if (cancellationToken.IsCancellationRequested)
            //    return;

            bool lastWord;
            int preWordSize = 0;
            byte wordSize;
            byte[][] words;

            if (combinationPattern[combinationCursor] != 0)
            {
                preWordSize = Array.IndexOf(combinationPattern, _nullByte, combinationCursor) - combinationCursor;
                if (preWordSize > 0)
                {
                    candidate.Append(combinationPattern, combinationCursor, preWordSize);
                    combinationCursor += preWordSize;
                }
                else
                {
                    candidate.Replace(combinationPattern, combinationCursor, combinationPattern.Length - combinationCursor);
                    TestCandidate(candidate);
                    return;
                }
            }

            wordSize = combinationPattern[combinationCursor + 1];
            combinationCursor += 2;
            lastWord = combinationCursor == combinationPattern.Length;

            if (lastWord)
            {
                words = dictLastWord[wordSize];
                foreach (var word in words)
                {
                    candidate.Replace(word);
                    TestCandidate(candidate);
                }
            }
            else
            {
                words = dictWords[wordSize];
                foreach (var word in words)
                {
                    candidate.Append(word);
                    RunDictionaries(candidate, combinationPattern, _dictionaries, dictLastWord, combinationCursor, cancellationToken);
                    candidate.Cursor -= wordSize;
                }
            }

            candidate.Cursor -= preWordSize;
        }

        protected virtual void TestCandidate(ByteString candidate)
        {
            if (candidate.CRC32Check())
            {
                _logger.LogResult(candidate.ToString());
                _foundResult++;
            }
        }
        #endregion

        #region Generate Dictionaries
        private Dictionary<byte, byte[][]> GetDictionaries(string dictionaries, string dictionariesFilterFirstFrom, string dictionariesFilterFirstTo, bool skipDigits, bool skipSpecials, bool forceLowerCase, bool addTypos,
            string dictionariesCustom, bool customSkipDigits, bool customSkipSpecials, bool customForceLowerCase, bool customAddTypos, bool reverseOrder,
            string dictionariesExclude, bool excludePartialWords)
        {
            Dictionary<byte, HashSet<string>> dictionaryHashRef = [];
            var output = new Dictionary<byte, byte[][]>();

            //Fill if no data present
            for (byte i = 1; i <= 100; i++)
                dictionaryHashRef.Add(i, []);

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

        private void FillDictionaries(Dictionary<byte, HashSet<string>> dictionaryHashRef, string dictionaries, string dictionariesFilterFirstFrom, string dictionariesFilterFirstTo, bool skipDigits, bool skipSpecials, bool forceLowerCase, bool addTypos)
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
                if (!File.Exists(dictionaryPath))
                    continue;

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
                        allNewWords.AddRange(_typosGenerator.GenerateTypos(wordToAdd));

                        foreach (var newWord in allNewWords)
                        {
                            var byteCount = (byte)Encoding.UTF8.GetByteCount(newWord);
                            if (byteCount < _minWordLength || byteCount > _maxWordLength)
                                continue;

                            if (!dictionaryHashRef[byteCount].Contains(newWord))
                            {
                                if (isFirstFilterFrom && string.Compare(newWord, dictionariesFilterFirstFrom) < 0)
                                    continue;
                                if (isFirstFilterTo && string.Compare(newWord, dictionariesFilterFirstTo) > 0)
                                    continue;

                                dictionaryHashRef[byteCount].Add(newWord);
                            }
                        }
                    }
                    else
                    {
                        var byteCount = (byte)Encoding.UTF8.GetByteCount(wordToAdd);
                        if (byteCount < _minWordLength || byteCount > _maxWordLength)
                            continue;

                        dictionaryHashRef[byteCount].Add(wordToAdd);
                    }
                }
            }
        }
        #endregion
    }
}
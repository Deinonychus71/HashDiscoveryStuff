using BruteForceHash.CombinationGenerator;
using BruteForceHash.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BruteForceHash
{
    public class HybridAttack
    {
        protected readonly Logger _logger;
        protected readonly Options _options;
        protected uint _hexValue;
        protected readonly int _combinationSize;
        protected CancellationTokenSource _cancellationTokenSource;

        protected CombinationGeneratorBase _combinationGeneration;
        protected readonly IEnumerable<string> _combinationPatterns;
        protected readonly string _inputValidChars;
        protected readonly string _inputValidStartChars;
        protected readonly byte[] _validBytes = null;
        protected readonly byte[] _validStartBytes = null;

        protected readonly byte _nullByte = 0x00;
        protected readonly int _stringLength;
        protected readonly string _delimiter;
        
        private int _foundResult = 0;

        public HybridAttack(Logger logger, Options options, int stringLength, uint hexValue)
        {
            _logger = logger;
            _options = options;
            _hexValue = hexValue;
            _delimiter = string.IsNullOrEmpty(options.Delimiter) ? "|" : options.Delimiter;

            //Valid bytes
            _inputValidChars = _options.ValidChars;
            _validBytes = Encoding.ASCII.GetBytes(_options.ValidChars);

            //Valid start bytes
            _inputValidStartChars = _options.ValidStartingChars;
            _validStartBytes = Encoding.ASCII.GetBytes(_options.ValidStartingChars);

            if (_options.MaxConcatenatedWords == 0)
                _combinationGeneration = new CombinationGeneratorSimple(options, stringLength);
            else
                _combinationGeneration = new CombinationGeneratorAdvanced(options, stringLength);

            //Calculate stringLength after prefix;
            _stringLength = stringLength;

            //Generate combinations
            _combinationSize = _stringLength - Encoding.UTF8.GetByteCount(options.Prefix) - Encoding.UTF8.GetByteCount(options.Suffix);
            _combinationPatterns = _combinationGeneration.GenerateCombinations(_combinationSize, $"{_options.HybridDictionary};{_options.HybridDictionaryFirstWord};{_options.HybridDictionaryLastWord}", _options.HybridWordsHash);

            //Filter combinations
            var useFirstWords = !string.IsNullOrEmpty(_options.HybridDictionaryFirstWord);
            var useLastWords = !string.IsNullOrEmpty(_options.HybridDictionaryLastWord);
            var words = File.Exists(_options.HybridDictionary) ? File.ReadAllLines(_options.HybridDictionary) : new string[0];
            var firstWords = File.Exists(_options.HybridDictionaryFirstWord) ? File.ReadAllLines(_options.HybridDictionaryFirstWord) : new string[0];
            var lastWords = File.Exists(_options.HybridDictionaryLastWord) ? File.ReadAllLines(_options.HybridDictionaryLastWord) : new string[0];
            var onlyFirstWords = firstWords.Except(words).ToArray();
            var onlyLastWords = lastWords.Except(words).ToArray();

            var finalCombinationPatterns = new List<string>();
            foreach(var combinationPattern in _combinationPatterns)
            {
                //To fix - This isn't working as intended
                if (useFirstWords && !combinationPattern.StartsWith("{") && !firstWords.Any(p => combinationPattern.StartsWith(p)))
                    continue;
                if (useLastWords && !combinationPattern.EndsWith("}") && !lastWords.Any(p => combinationPattern.EndsWith(p)))
                    continue;
                //End to fix

                var totalUnknownChars = 0;
                for (var i = 1; i <= 50; i++)
                {
                    totalUnknownChars += (combinationPattern.Split("{" + (i) + "}").Length - 1) * i;
                }
                if (totalUnknownChars <= _options.HybridMaxCharacters && totalUnknownChars >= _options.HybridMinCharacters)
                    finalCombinationPatterns.Add(combinationPattern);
            }
            _combinationPatterns = finalCombinationPatterns;
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

            if (_options.MaxConcatenatedWords > 0)
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

            _logger.Log($"Minimum Characters to Bruteforce: {_options.HybridMinCharacters} characters");
            _logger.Log($"Maximum Characters to Bruteforce: {_options.HybridMaxCharacters} characters");
            _logger.Log($"Numbers of words added: {_options.HybridWordsHash} words");
            _logger.Log($"Valid Characters: {_inputValidChars}");
            _logger.Log($"Valid Starting Characters: {_inputValidStartChars} for first characters");

            _logger.Log($"Search on: {_combinationSize} characters");
            _logger.Log("-----------------------------------------");
        }

        #region Run Attack
        public virtual void Run()
        {
            PrintHeaders();

            var taskFactory = new TaskFactory(new LimitedConcurrencyLevelTaskScheduler(_options.NbrThreads));
            var tasks = new List<Task>();
            RunAttackTasks(taskFactory, tasks, _combinationPatterns, true, true);

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

        protected void RunAttackTasks(TaskFactory taskFactory, List<Task> tasks, IEnumerable<string> combinationPatterns, bool optimizePrefixesAndSuffixes = false, bool verbose = false)
        {
            _cancellationTokenSource = new CancellationTokenSource();

            foreach (var combinationPattern in combinationPatterns)
            {
                var task = taskFactory.StartNew(() =>
                {
                    if (_cancellationTokenSource.Token.IsCancellationRequested)
                        return;

                    var compiledCombination = _combinationGeneration.CompileCombination(combinationPattern);

                    //Optimize Prefix/Suffix
                    var prefixByteStr = string.Empty;
                    var suffixByteStr = string.Empty;
                    if (optimizePrefixesAndSuffixes)
                    {
                        var prefixByteSize = Array.IndexOf(compiledCombination, _nullByte);
                        prefixByteStr = Encoding.UTF8.GetString(compiledCombination, 0, prefixByteSize);
                        var suffixByteOffset = Array.LastIndexOf(compiledCombination, _nullByte);
                        if (suffixByteOffset != -1)
                            suffixByteOffset += 2;
                        var suffixByteSize = compiledCombination.Length - suffixByteOffset;
                        suffixByteStr = Encoding.UTF8.GetString(compiledCombination, suffixByteOffset, suffixByteSize);

                        var newCompiledCombination = new byte[compiledCombination.Length - prefixByteSize - suffixByteSize];
                        Buffer.BlockCopy(compiledCombination, prefixByteSize, newCompiledCombination, 0, compiledCombination.Length - prefixByteSize - suffixByteSize);
                        compiledCombination = newCompiledCombination;
                    }
                    //End Optimize

                    var strBuilder = new ByteString(_stringLength, _hexValue, _options.Prefix + prefixByteStr, suffixByteStr + _options.Suffix , false);
                    if (_options.Verbose && verbose)
                        _logger.Log($"Running Pattern: {combinationPattern}", false);

                    RunHybridAttack(strBuilder, compiledCombination, _validStartBytes, 0, 0, _cancellationTokenSource.Token);

                });
                tasks.Add(task);
            }

            try
            {
                Task.WaitAll(tasks.ToArray(), _cancellationTokenSource.Token);
            }
            catch { }
        }
        #endregion

        #region Run Attack - Per Combination
        protected void RunHybridAttack(ByteString candidate, byte[] combinationPattern, byte[] validBytes, int combinationCursor, int searchSizeRemaining, CancellationToken cancellationToken = default)
        {
            if (cancellationToken.IsCancellationRequested)
                return;

            int preWordSize = 0;
            byte searchLength;

            if(searchSizeRemaining > 0)
            {
                foreach (byte b in validBytes)
                {
                    candidate.Append(b);
                    RunHybridAttack(candidate, combinationPattern, _validBytes, combinationCursor, searchSizeRemaining - 1, cancellationToken);
                    candidate.Cursor -= 1;
                }
            }

            if(combinationCursor == combinationPattern.Length)
            {
                TestCandidate(candidate);
                return;
            }

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
                validBytes = _validBytes;
            }

            searchLength = combinationPattern[combinationCursor + 1];
            combinationCursor += 2;

            RunHybridAttack(candidate, combinationPattern, validBytes, combinationCursor, searchLength, cancellationToken);

            candidate.Cursor -= preWordSize;
        }

        private void DiveByteSimple(ByteString candidate, int level, int searchLength)
        {
            int levelp = level + 1;
            foreach (byte b in _validBytes)
            {
                if (levelp < searchLength)
                {
                    candidate.Append(b);
                    DiveByteSimple(candidate, levelp, searchLength);
                    candidate.Cursor -= 1;
                    continue;
                }
                candidate.Replace(b);
                if (candidate.CRC32Check())
                    _logger.LogResult(candidate.ToString());
            }
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
    }
}
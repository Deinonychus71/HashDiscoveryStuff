using BruteForceHash.Helpers;
using Force.Crc32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BruteForceHash
{
    public class BruteForceCharacter
    {
        private readonly Logger _logger;
        private readonly Options _options;
        private readonly uint _hexValue;
        private readonly int _stringLength;
        private static readonly string _validChars = "etainoshrdlucmfwygpbvkqjxz0123456789_";
        private static readonly string _validStartChars = "etainoshrdlucmfwygpbvkqjxz";
        private static byte[] _validBytes = null;

        public BruteForceCharacter(Logger logger, Options options, int stringLength, uint hexValue)
        {
            _logger = logger;
            _options = options;
            _hexValue = hexValue;
            _stringLength = stringLength;
        }

        public void Run()
        {
            //Run
            var taskScheduler = new LimitedConcurrencyLevelTaskScheduler(_options.NbrThreads);
            var tasks = new List<Task>();

            // Create a TaskFactory and pass it our custom scheduler.
            TaskFactory factory = new TaskFactory(taskScheduler);
            CancellationTokenSource cts = new CancellationTokenSource();

            //Valid bytes
            string inputValidChars;
            if (string.IsNullOrEmpty(_options.ValidChars))
            {
                Console.WriteLine($"Enter valid characters (Default: {_validChars})");
                inputValidChars = Console.ReadLine();
                if (string.IsNullOrEmpty(inputValidChars))
                    inputValidChars = _validChars;
                _validBytes = Encoding.ASCII.GetBytes(inputValidChars);
            }
            else
            {
                inputValidChars = _options.ValidChars;
                _validBytes = Encoding.ASCII.GetBytes(_options.ValidChars);
            }

            //Valid start bytes
            byte[] validStartBytes;
            string inputValidStartChars;
            if (string.IsNullOrEmpty(_options.ValidStartingChars))
            {
                Console.WriteLine($"Enter valid first characters (Default: {_validStartChars})");
                inputValidStartChars = Console.ReadLine();
                if (string.IsNullOrEmpty(inputValidStartChars))
                    inputValidStartChars = _validStartChars;
                
                validStartBytes = Encoding.ASCII.GetBytes(inputValidStartChars);
            }
            else
            {
                inputValidStartChars = _options.ValidStartingChars;
                validStartBytes = Encoding.ASCII.GetBytes(_options.ValidStartingChars);
            }

            if (!string.IsNullOrEmpty(_options.IncludeWord))
            {
                _logger.Log($"Include Word: {_options.IncludeWord}");
                _logger.Log($"Start Position: {_options.StartPosition}");
                if(_options.EndPosition < 0)
                _logger.Log($"End Position: {_options.EndPosition}");
            }
            _logger.Log($"Valid Characters: {inputValidChars}");
            _logger.Log($"Valid Starting Characters: {inputValidStartChars} for first characters");
            _logger.Log($"Search on: {_stringLength - _options.Prefix.Length - _options.Suffix.Length} characters");
            _logger.Log("-----------------------------------------");

            if (string.IsNullOrEmpty(_options.IncludeWord))
            {
                RunCharacterBruteForce(tasks, factory, validStartBytes, _options.Prefix);
            }
            else
            {
                int searchLength = _stringLength - _options.Prefix.Length - _options.Suffix.Length;
                int firstPosition = _options.StartPosition;

                var words = _options.IncludeWord.Split(',', StringSplitOptions.RemoveEmptyEntries);
                foreach (var word in words)
                {
                    var trimmedWord = word.Trim();
                    var trimmedWordLength = trimmedWord.Length;

                    int lastPosition = trimmedWordLength - _options.EndPosition;
                    for (int i = firstPosition; i <= searchLength - lastPosition; i++)
                    {
                        //Calculate pattern
                        var pattern = _options.Prefix;
                        for (int p = 0; p < i; p++)
                            pattern += "*";
                        pattern += trimmedWord;
                        for (int p = 0; p < searchLength - trimmedWordLength - i; p++)
                            pattern += "*";
                        pattern += _options.Suffix;

                        if (i == 0)
                        {
                            RunCharacterBruteForce(tasks, factory, validStartBytes, _options.Prefix + trimmedWord, trimmedWord, pattern, i);
                        }
                        else if (i <= 1)
                        {
                            RunCharacterBruteForce(tasks, factory, validStartBytes, _options.Prefix, trimmedWord, pattern, i);
                        }
                        else
                        {
                            int[] levelTable = new int[searchLength];
                            for (int l = 0; l < searchLength; l++)
                            {
                                if (l == i - 2)
                                    levelTable[l] = trimmedWordLength + 1;
                                else
                                    levelTable[l] = 1;
                            }
                            RunCharacterBruteForce(tasks, factory, validStartBytes, _options.Prefix, trimmedWord, pattern, i, levelTable);
                        }
                    }
                }

                    
            }

            // Wait for the tasks to complete before displaying a completion message.
            Task.WaitAll(tasks.ToArray());
            cts.Dispose();
        }

        private void RunCharacterBruteForce(List<Task> tasks, TaskFactory factory, byte[] validStartBytes, string prefix, string includeWord = null, string pattern = null, int patternPosition = 0, int[] levelTable = null)
        {
            int searchLength = _stringLength - prefix.Length - _options.Suffix.Length - 1;
            for (var t = 0; t < validStartBytes.Length; t++)
            {
                var startingCharacter = Encoding.ASCII.GetString(new byte[1] { validStartBytes[t] });
                var task = factory.StartNew(() =>
                {
                    ByteString strBuilder;

                    try
                    {
                        if (_options.Verbose)
                        {
                            if (!string.IsNullOrEmpty(pattern))
                            {
                                _logger.Log($"{pattern} - Starting new thread for {startingCharacter}", false);
                            }
                            else
                            {
                                _logger.Log($"Starting new thread for {startingCharacter}", false);
                            }
                        }
                        if (patternPosition == 0)
                        {
                            strBuilder = new ByteString(_stringLength, _hexValue, prefix + startingCharacter, _options.Suffix);
                            DiveByteSimple(strBuilder, 0, searchLength);
                        }
                        else if(patternPosition == 1)
                        {
                            strBuilder = new ByteString(_stringLength, _hexValue, prefix + startingCharacter + includeWord, _options.Suffix);
                            DiveByteSimple(strBuilder, 0, searchLength - includeWord.Length);
                        }
                        else
                        {
                            strBuilder = new ByteString(_stringLength, _hexValue, prefix + startingCharacter, _options.Suffix);
                            strBuilder.Replace(includeWord, patternPosition + prefix.Length);
                            DiveByte(strBuilder, 0, searchLength, levelTable, patternPosition);
                        }
                    }
                    catch (Exception e)
                    {
                        _logger.Log($"ERROR on thread {startingCharacter}: {e.Message}");
                    }
                });
                tasks.Add(task);
            }
        }

        private void DiveByte(ByteString candidate, int level, int searchLength, int[] levelTable, int patternPosition)
        {
            int levelp = level + levelTable[level];
            foreach (byte b in _validBytes)
            {
                if (levelp < searchLength)
                {
                    candidate.Replace(b);
                    candidate.Cursor += levelTable[level];
                    DiveByte(candidate, levelp, searchLength, levelTable, patternPosition);
                    candidate.Cursor -= levelTable[level];
                    continue;
                }
                candidate.Replace(b);
                if (candidate.CRC32Check())
                    _logger.LogResult(candidate.ToString());
            }
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
    }
}

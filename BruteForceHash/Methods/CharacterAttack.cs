using BruteForceHash.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BruteForceHash.Methods
{
    public class CharacterAttack
    {
        private readonly Logger _logger;
        private readonly Options _options;
        private readonly uint _hexValue;
        private readonly int _stringLength;
        private static readonly string _validChars = "etainoshrdlucmfwygpbvkqjxz0123456789_";
        private static readonly string _validStartChars = "etainoshrdlucmfwygpbvkqjxz";
        private static byte[] _validBytes = null;

        public CharacterAttack(Logger logger, Options options, int stringLength, uint hexValue)
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

            _logger.Log($"Valid Characters: {inputValidChars}");
            _logger.Log($"Valid Starting Characters: {inputValidStartChars} for first characters");
            _logger.Log($"Search on: {_stringLength - _options.Prefix.Length - _options.Suffix.Length} characters");
            _logger.Log("-----------------------------------------");

            RunCharacterBruteForce(tasks, factory, validStartBytes, _options.Prefix);

            // Wait for the tasks to complete before displaying a completion message.
            Task.WaitAll(tasks.ToArray());
            cts.Dispose();
        }

        private void RunCharacterBruteForce(List<Task> tasks, TaskFactory factory, byte[] validStartBytes, string prefix)
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
                            _logger.Log($"Starting new thread for {startingCharacter}", false);
                        }
                        strBuilder = new ByteString(_stringLength, _hexValue, prefix + startingCharacter, _options.Suffix);
                        DiveByteSimple(strBuilder, 0, searchLength);
                    }
                    catch (Exception e)
                    {
                        _logger.Log($"ERROR on thread {startingCharacter}: {e.Message}");
                    }
                });
                tasks.Add(task);
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

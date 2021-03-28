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
    public class BruteForceLetter
    {
        private readonly Logger _logger;
        private readonly Options _options;
        private readonly uint _hexValue;
        private readonly int _stringLength;
        private readonly int _searchLength;
        private static readonly string _validChars = "etainoshrdlucmfwygpbvkqjxz0123456789_";
        private static readonly string _validStartChars = "etainoshrdlucmfwygpbvkqjxz";
        private static byte[] _validBytes = null;

        public BruteForceLetter(Logger logger, Options options, int stringLength, uint hexValue)
        {
            _logger = logger;
            _options = options;
            _hexValue = hexValue;
            _stringLength = stringLength;
            _searchLength = _stringLength - options.Prefix.Length - options.Suffix.Length - 1;
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
            if (string.IsNullOrEmpty(_options.ValidChars))
            {
                Console.WriteLine($"Enter valid characters (Default: {_validChars})");
                string inputValidChars = Console.ReadLine();
                if (string.IsNullOrEmpty(inputValidChars))
                    inputValidChars = _validChars;
                _logger.Log($"Will use {inputValidChars}");
                _validBytes = Encoding.ASCII.GetBytes(inputValidChars);
            }
            else
            {
                _validBytes = Encoding.ASCII.GetBytes(_options.ValidChars);
            }

            //Valid bytes
            byte[] validStartBytes;
            if (string.IsNullOrEmpty(_options.ValidStartingChars))
            {
                Console.WriteLine($"Enter valid first characters (Default: {_validStartChars})");
                string inputValidStartChars = Console.ReadLine();
                if (string.IsNullOrEmpty(inputValidStartChars))
                    inputValidStartChars = _validStartChars;
                _logger.Log($"Will use {inputValidStartChars} for first characters");
                validStartBytes = Encoding.ASCII.GetBytes(inputValidStartChars);
            }
            else
            {
                validStartBytes = Encoding.ASCII.GetBytes(_options.ValidStartingChars);
            }

            //Bruteforcing
            _logger.Log("-----------------------------------------");

            for (var t = 0; t < validStartBytes.Length; t++)
            {
                var startingCharacter = Encoding.ASCII.GetString(new byte[1] { validStartBytes[t] });
                var task = factory.StartNew(() =>
                {
                    var strBuilder = new ByteString(_stringLength, _hexValue, _options.Prefix + startingCharacter, _options.Suffix);
                    _logger.Log($"Starting new thread for {startingCharacter}", false);
                    try
                    {
                        DiveByte(strBuilder, 0);
                    }
                    catch (Exception e)
                    {
                        _logger.Log($"ERROR on thread {startingCharacter}: {e.Message}");
                    }
                });
                tasks.Add(task);
            }

            // Wait for the tasks to complete before displaying a completion message.
            Task.WaitAll(tasks.ToArray());
            cts.Dispose();
        }

        private void DiveByte(ByteString candidate, int level)
        {
            int levelp = level + 1;
            foreach (byte b in _validBytes)
            {
                if (levelp < _searchLength)
                {
                    candidate.Append(b);
                    DiveByte(candidate, levelp);
                    candidate.Cursor -= 1;
                    continue;
                }
                candidate.Replace(b);
                if (candidate.CRC32Check())
                    _logger.Log(candidate.ToString());
            }
        }

    }
}

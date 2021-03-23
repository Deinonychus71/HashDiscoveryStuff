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
        private static readonly string _validChars = "etainoshrdlucmfwygpbvkqjxz0123456789_./:-";
        private static readonly string _validStartChars = "etainoshrdlucmfwygpbvkqjxz";
        private static byte[] _validBytes = null;
        private readonly string _prefix;

        public BruteForceLetter(Logger logger, Options options, int stringLength, uint hexValue)
        {
            _logger = logger;
            _options = options;
            _hexValue = hexValue;
            _stringLength = stringLength;
            _prefix = options.Prefix;
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
            Console.WriteLine($"Enter valid characters (Default: {_validChars}");
            string inputValidChars = Console.ReadLine();
            if (string.IsNullOrEmpty(inputValidChars))
                inputValidChars = _validChars;
            _logger.Log($"Will use {inputValidChars}");
            _validBytes = Encoding.ASCII.GetBytes(inputValidChars);

            //Valid bytes
            Console.WriteLine($"Enter valid first characters (Default: {_validStartChars}");
            string inputValidStartChars = Console.ReadLine();
            if (string.IsNullOrEmpty(inputValidStartChars))
                inputValidStartChars = _validStartChars;
            _logger.Log($"Will use {inputValidStartChars} for first characters");
            byte[] validStartBytes = Encoding.ASCII.GetBytes(inputValidStartChars);

            //Bruteforcing
            _logger.Log("-----------------------------------------");

            for (var t = 0; t < validStartBytes.Length; t++)
            {
                var buffer = new byte[_stringLength];
                for (var p = 0; p < _prefix.Length; p++)
                {
                    buffer[p] = (byte)_prefix[p];
                }
                buffer[_prefix.Length] = validStartBytes[t];

                var task = factory.StartNew(() =>
                {
                    _logger.Log($"Starting new thread for {Encoding.ASCII.GetString(new byte[1] { buffer[_prefix.Length] })}", false);
                    try
                    {
                        DiveByte(buffer, _prefix.Length + 1);
                    }
                    catch (Exception e)
                    {
                        _logger.Log($"ERROR on thread {Encoding.ASCII.GetString(new byte[1] { buffer[_prefix.Length] })}: {e.Message}");
                    }
                });
                tasks.Add(task);
            }

            // Wait for the tasks to complete before displaying a completion message.
            Task.WaitAll(tasks.ToArray());
            cts.Dispose();
        }

        private void DiveByte(byte[] buffer, int level)
        {
            int levelp = level + 1;
            foreach (byte b in _validBytes)
            {
                if (levelp < _stringLength)
                {
                    buffer[level] = b;
                    DiveByte(buffer, levelp);
                    continue;
                }
                buffer[level] = b;
                var testValue = Crc32Algorithm.Compute(buffer);
                if (_hexValue == testValue)
                {
                    string value = Encoding.ASCII.GetString(buffer);
                    _logger.Log(value);
                }
            }
        }

    }
}

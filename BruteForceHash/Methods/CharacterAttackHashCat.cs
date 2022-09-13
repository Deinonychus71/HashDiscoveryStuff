using BruteForceHash.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BruteForceHash.Methods
{
    public class CharacterAttackHashCat
    {
        private readonly Logger _logger;
        private readonly Options _options;
        private readonly uint _hexValue;
        private readonly int _stringLength;
        private readonly string _validChars = "etainoshrdlucmfwygpbvkqjxz0123456789_";
        private readonly string _validStartChars = "etainoshrdlucmfwygpbvkqjxz";
        private byte[] _validBytes = null;
        private uint _hexExtract;
        private bool _interruptThreads = false;

        public CharacterAttackHashCat(Logger logger, Options options, int stringLength, uint hexValue)
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
            var factory = new TaskFactory(taskScheduler);

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

            var maskSize = _stringLength - _options.Prefix.Length - _options.Suffix.Length;
            _logger.Log($"Valid Characters: {inputValidChars}");
            _logger.Log($"Valid Starting Characters: {inputValidStartChars} for first characters");
            _logger.Log($"Search on: {maskSize} characters");
            _logger.Log("-----------------------------------------");

            if (!string.IsNullOrEmpty(_options.Prefix) || !string.IsNullOrEmpty(_options.Suffix))
            {
                _logger.Log($"Finding false positive...", false);

                var tasks = new List<Task>();
                var cts = new CancellationTokenSource();
                RunCharacterBruteForce(tasks, factory, validStartBytes, _options.Prefix, true);
                // Wait for the tasks to complete before displaying a completion message.
                Task.WaitAll(tasks.ToArray());
                cts.Dispose();

                if (_hexExtract == 0)
                {
                    _logger.Log($"No false positive found. Aborting operation.");
                    return;
                }
            }
            else
            {
                _hexExtract = _hexValue;
            }

            // Launch HashCat
            var output = Path.GetFullPath(_logger.PathFile).Replace(".txt", "_hashcat.txt");

            var mask = "?1";
            for (int i = 1; i < maskSize; i++)
                mask += "?2";

            var quiet = string.Empty;
            if (!_options.Verbose)
                quiet = " --quiet";
            string args = $"--hash-type 11500 -a 3 {_hexExtract:x8}:00000000 -1 {inputValidStartChars} -2 {inputValidChars} {mask} --outfile \"{output}\" --keep-guessing -w 3{quiet}";
            new HashcatTask(_logger, _options).Run(args, _options.Verbose);
        }

        private void RunCharacterBruteForce(List<Task> tasks, TaskFactory factory, byte[] validStartBytes, string prefix, bool shouldInterruptAtFirstResult = false)
        {
            int searchLength = _stringLength - prefix.Length - _options.Suffix.Length - 1;
            for (var t = 0; t < validStartBytes.Length; t++)
            {
                var startingCharacter = Encoding.ASCII.GetString(new byte[1] { validStartBytes[t] });
                var task = factory.StartNew(() =>
                {
                    try
                    {
                        ByteString strBuilder = new ByteString(_stringLength, _hexValue, prefix, _options.Suffix);
                        strBuilder.Append(startingCharacter);
                        DiveByteSimple(strBuilder, 0, searchLength, shouldInterruptAtFirstResult);
                    }
                    catch (Exception e)
                    {
                        _logger.Log($"ERROR on thread {startingCharacter}: {e.Message}");
                    }
                });
                tasks.Add(task);
            }
        }

        private void DiveByteSimple(ByteString candidate, int level, int searchLength, bool shouldInterruptAtFirstResult = false)
        {
            int levelp = level + 1;
            foreach (byte b in _validBytes)
            {
                if (_interruptThreads)
                    break;

                if (levelp < searchLength)
                {
                    candidate.Append(b);
                    DiveByteSimple(candidate, levelp, searchLength, shouldInterruptAtFirstResult);
                    candidate.Cursor -= 1;
                    continue;
                }
                candidate.Replace(b);
                if (candidate.CRC32Check())
                {
                    if (shouldInterruptAtFirstResult)
                    {
                        _logger.LogResult($"False positive found: 0x{candidate.HexSearchValue:x}.");
                        _hexExtract = candidate.HexSearchValue;
                        _interruptThreads = true;
                    }
                    else
                    {
                        _logger.LogResult(candidate.ToString());
                    }
                }

            }
        }
    }
}

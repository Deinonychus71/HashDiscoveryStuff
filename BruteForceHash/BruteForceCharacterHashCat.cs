using BruteForceHash.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BruteForceHash
{
    public class BruteForceCharacterHashCat
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

        public BruteForceCharacterHashCat(Logger logger, Options options, int stringLength, uint hexValue)
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

            var maskSize = _stringLength - _options.Prefix.Length - _options.Suffix.Length;
            _logger.Log($"Valid Characters: {inputValidChars}");
            _logger.Log($"Valid Starting Characters: {inputValidStartChars} for first characters");
            _logger.Log($"Search on: {maskSize} characters");
            _logger.Log("-----------------------------------------");

            if (!string.IsNullOrEmpty(_options.Prefix) || !string.IsNullOrEmpty(_options.Suffix))
            {
                _logger.Log($"Finding false positive...", false);
                RunCharacterBruteForce(tasks, factory, validStartBytes, _options.Prefix);

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

            if (string.IsNullOrEmpty(_options.IncludeWord))
            {
                var mask = "?1";
                for (int i = 1; i < maskSize; i++)
                    mask += "?2";

                string args = $"--hash-type 11500 -a 3 {_hexExtract:x8}:00000000 -1 {inputValidStartChars} -2 {inputValidChars} {mask} --outfile \"{output}\" --keep-guessing -w 3";
                new HashcatTask(_logger, _options).Run(args);
            }
            else
            {
                var words = _options.IncludeWord.Split(',', StringSplitOptions.RemoveEmptyEntries);
                var masks = new List<string>();
                foreach (var word in words)
                {
                    var trimmedWord = word.Trim();
                    var wordLength = trimmedWord.Length;

                    //Create all available masks
                    for (var i = 0; i <= maskSize - wordLength; i++)
                    {
                        var mask = string.Empty;
                        for (var s = 0; s < i; s++)
                        {
                            if (s == 0)
                                mask += "?1";
                            else
                                mask += "?2";
                        }
                        mask += trimmedWord;
                        for (var s = i + wordLength; s < maskSize; s++)
                        {
                            mask += "?2";
                        }

                        masks.Add(mask);
                    }
                }

                //Running HashCat
                var quiet = string.Empty;
                if (!_options.Verbose)
                    quiet = " --quiet";
                var argumentLists = new List<string>();
                foreach (var mask in masks)
                {
                    argumentLists.Add($"--hash-type 11500 -a 3 {_hexExtract:x8}:00000000 -1 {inputValidStartChars} -2 {inputValidChars} {mask} --outfile \"{output}\" --keep-guessing -w 3{quiet}");
                }
                new HashcatTask(_logger, _options).Run(argumentLists);
            }

        }

        private void RunCharacterBruteForce(List<Task> tasks, TaskFactory factory, byte[] validStartBytes, string prefix, string pattern = null, int patternPosition = 0, int[] levelTable = null)
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
                if (_interruptThreads)
                    break;

                if (levelp < searchLength)
                {
                    candidate.Append(b);
                    DiveByteSimple(candidate, levelp, searchLength);
                    candidate.Cursor -= 1;
                    continue;
                }
                candidate.Replace(b);
                if (candidate.CRC32Check())
                {
                    _logger.LogResult($"False positive found: 0x{candidate.HexSearchValue:x}.");
                    _hexExtract = candidate.HexSearchValue;
                    _interruptThreads = true;
                }

            }
        }
    }
}

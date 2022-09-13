using BruteForceHash.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BruteForceHash.Methods
{
    public class CharacterAttackUtf8
    {
        private readonly Logger _logger;
        private readonly Options _options;
        private readonly uint _hexValue;
        private readonly int _stringLength;
        private string _validCharsString = "à１aetinoshrdlucmfwygpbvkqjxz0123456789_"; //"etainoshrdlucmfwygpbvkqjxz0123456789_"
        private string _validStartCharsString = "àtainoshrdlucmfwygpbvkqjxz"; //"etainoshrdlucmfwygpbvkqjxz";
        private byte[] _validBytes = null;
        private Dictionary<int, byte[]> _mappingBytes;

        public CharacterAttackUtf8(Logger logger, Options options, int stringLength, uint hexValue)
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
            if (string.IsNullOrEmpty(_options.ValidChars))
            {
                Console.WriteLine($"Enter valid characters (Default: {_validCharsString})" + 'Ä');
                var inputValidChars = Console.ReadLine();
                if (!string.IsNullOrEmpty(inputValidChars))
                    _validCharsString = inputValidChars;
            }
            else
            {
                _validCharsString = _options.ValidChars;
            }
            var validBytesTuple = GetBytesMappingUtf8(_validCharsString);
            _validBytes = validBytesTuple.Item1;
            _mappingBytes = validBytesTuple.Item2;

            //Valid start bytes
            if (string.IsNullOrEmpty(_options.ValidStartingChars))
            {
                Console.WriteLine($"Enter valid first characters (Default: {_validStartCharsString})");
                var inputValidStartChars = Console.ReadLine();
                if (!string.IsNullOrEmpty(inputValidStartChars))
                    _validStartCharsString = inputValidStartChars;
            }
            else
            {
                _validStartCharsString = _options.ValidStartingChars;
            }

            //Description
            _logger.Log($"Valid Characters: {_validCharsString}");
            _logger.Log($"Valid Starting Characters: {_validStartCharsString} for first characters");
            _logger.Log($"Search on: {_stringLength - Encoding.UTF8.GetByteCount(_options.Prefix) - Encoding.UTF8.GetByteCount(_options.Suffix)} characters");
            _logger.Log("-----------------------------------------");

            RunCharacterBruteForce(tasks, factory, _validStartCharsString, _options.Prefix);

            // Wait for the tasks to complete before displaying a completion message.
            Task.WaitAll(tasks.ToArray());
            cts.Dispose();
        }

        private void RunCharacterBruteForce(List<Task> tasks, TaskFactory factory, string validStartCharsString, string prefix)
        {
            int searchLength = _stringLength - Encoding.UTF8.GetByteCount(prefix) - Encoding.UTF8.GetByteCount(_options.Suffix);
            for (var t = 0; t < validStartCharsString.Length; t++)
            {
                var startingCharacter = _validStartCharsString[t];
                var characterLength = Encoding.UTF8.GetBytes(startingCharacter.ToString()).Length;
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
                        DiveByteSimple(strBuilder, 0, searchLength - characterLength);
                    }
                    catch (Exception e)
                    {
                        _logger.Log($"ERROR on thread {startingCharacter}: {e.Message}");
                    }
                });
                tasks.Add(task);
            }
        }

        private void DiveByteSimple(ByteString candidate, int level, int searchLength, int currentUtf8Value = 0)
        {
            int levelp = level + 1;

            byte[] charsetBytes;
            if (currentUtf8Value > 127 && _mappingBytes.ContainsKey(currentUtf8Value))
                charsetBytes = _mappingBytes[currentUtf8Value];
            else
            {
                charsetBytes = _validBytes;
                currentUtf8Value = 0;
            }

            foreach (byte b in charsetBytes)
            {
                if (levelp < searchLength)
                {
                    candidate.Append(b);
                    DiveByteSimple(candidate, levelp, searchLength, (currentUtf8Value << 8) + b);
                    candidate.Cursor -= 1;
                    continue;
                }
                candidate.Replace(b);
                if (candidate.CRC32Check())
                    _logger.LogResult(candidate.ToString());
            }
        }

        private Tuple<byte[], Dictionary<int, byte[]>> GetBytesMappingUtf8(string chars)
        {
            var validBytesList = new List<byte>();
            var mappingBytesList = new Dictionary<int, List<byte>>();
            foreach (var validChar in chars)
            {
                var byteChars = Encoding.UTF8.GetBytes(validChar.ToString());
                byte byteChar1 = byteChars[0];
                if (!validBytesList.Contains(byteChar1))
                    validBytesList.Add(byteChar1);
                byte byteChar2 = 0;
                if (byteChars.Length > 1)
                {
                    byteChar2 = byteChars[1];
                    if (!mappingBytesList.ContainsKey(byteChar1))
                        mappingBytesList.Add(byteChar1, new List<byte>());
                    if (!mappingBytesList[byteChar1].Contains(byteChar2))
                        mappingBytesList[byteChar1].Add(byteChar2);
                }
                if (byteChars.Length > 2)
                {
                    var first2Bytes = (byteChar1 << 8) + byteChar2;
                    if (!mappingBytesList.ContainsKey(first2Bytes))
                        mappingBytesList.Add(first2Bytes, new List<byte>());
                    if (!mappingBytesList[first2Bytes].Contains(byteChars[2]))
                        mappingBytesList[first2Bytes].Add(byteChars[2]);
                }
            }
            return new Tuple<byte[], Dictionary<int, byte[]>>(validBytesList.ToArray(), mappingBytesList.ToDictionary(p => p.Key, p => p.Value.ToArray()));
        }
    }
}

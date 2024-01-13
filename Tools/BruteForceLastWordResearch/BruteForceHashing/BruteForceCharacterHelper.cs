using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace BruteForceLastWordResearch.BruteForceHashing
{
    /// <summary>
    /// Not thread safe!
    /// </summary>
    public static class BruteForceCharacterHelper
    {
        //Property data
        private static byte[] _validStartBytes;
        private static byte[] _validBytes;

        //Temp data
        private static ByteString _hexExtract;
        private static bool _interruptThreads;
        private static string _prefix;
        private static string _suffix;
        private static int _stringLength;

        public static void SetValidStartChars(string validStartChars) => _validStartBytes = Encoding.ASCII.GetBytes(validStartChars);
        public static void SetValidChars(string validChars) => _validBytes = Encoding.ASCII.GetBytes(validChars);

        public static ByteString RunCharacterBruteForce(string hexValue, string prefix = "", string suffix = "", int nbrThreads = 8, bool shouldInterruptAtFirstResult = false)
        {
            var split = hexValue.Split("x".ToCharArray());
            var lengthStr = split[1].Substring(0, 2);
            var valueStr = split[1][2..];
            var length = Convert.ToInt32(lengthStr, 16);
            var hexToFind = Convert.ToUInt32(valueStr, 16);

            return RunCharacterBruteForce(hexToFind, length, prefix, suffix, nbrThreads, shouldInterruptAtFirstResult);
        }

        public static ByteString RunCharacterBruteForce(uint hexValue, int stringLength, string prefix = "", string suffix = "", int nbrThreads = 8, bool shouldInterruptAtFirstResult = false)
        {
            ClearStaticProperties();

            _prefix = prefix;
            _suffix = suffix;
            _stringLength = stringLength;

            var taskScheduler = new LimitedConcurrencyLevelTaskScheduler(nbrThreads);
            var factory = new TaskFactory(taskScheduler);

            var tasks = new List<Task>();
            var cts = new CancellationTokenSource();
            RunCharacterBruteForce(tasks, factory, hexValue, shouldInterruptAtFirstResult);
            // Wait for the tasks to complete before displaying a completion message.
            Task.WaitAll(tasks.ToArray());
            cts.Dispose();

            var result = _hexExtract;

            ClearStaticProperties();

            return result;
        }

        private static void ClearStaticProperties()
        {
            _hexExtract = null;
            _stringLength = 0;
            _interruptThreads = false;
            _prefix = null;
            _suffix = null;
        }

        private static void RunCharacterBruteForce(List<Task> tasks, TaskFactory factory, uint hexValue, bool shouldInterruptAtFirstResult = false)
        {
            int searchLength = _stringLength - _prefix.Length - _suffix.Length - 1;
            for (var t = 0; t < _validStartBytes.Length; t++)
            {
                var startingCharacter = Encoding.ASCII.GetString(new byte[1] { _validStartBytes[t] });
                var task = factory.StartNew(() =>
                {
                    try
                    {
                        var strBuilder = new ByteString(_stringLength, hexValue, _prefix, _suffix);
                        strBuilder.Append(startingCharacter);
                        DiveByteSimple(strBuilder, 0, searchLength, shouldInterruptAtFirstResult);
                    }
                    catch
                    {
                        _interruptThreads = true;
                        throw;
                    }
                });
                tasks.Add(task);
            }
        }

        private static void DiveByteSimple(ByteString candidate, int level, int searchLength, bool shouldInterruptAtFirstResult = false)
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
                        _hexExtract = candidate;
                        _interruptThreads = true;
                    }
                }

            }
        }
    }
}

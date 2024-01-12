using BruteForceHash.Helpers;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace BruteForceHash.Methods
{
    public class DictionaryAttackHashcat : DictionaryAttack
    {
        private readonly bool _runHashCat;
        private uint _hexExtract;

        public DictionaryAttackHashcat(Logger logger, Options options, int stringLength, uint hexValue)
            : base(logger, options, stringLength, hexValue)
        {
            _runHashCat = options.RunHashcat;
            if (string.IsNullOrEmpty(_options.Prefix) && string.IsNullOrEmpty(_options.Suffix))
            {
                _hexExtract = _hexValue;
            }
        }

        protected override void WaitForDictionariesToRun(Task[] tasks, CancellationToken cancellationToken)
        {
            if (_hexExtract == 0 && !_options.RunHashcat)
                base.WaitForDictionariesToRun(tasks, cancellationToken);

            if (!_runHashCat)
            {
                //Reduce the size of the word if prefix/suffix were found
                _options.HexValue = $"0x{_combinationSize:x2}{_hexExtract:x}";
                _options.Prefix = string.Empty;
                _options.Suffix = string.Empty;
                _options.RunHashcat = true;

                var output = Path.GetFullPath(_logger.PathFile).Replace(".txt", "_hashcat.txt");
                string args = $"--hash-type 11500 -a 0 {_hexExtract:x8}:00000000 --outfile \"{output}\" --keep-guessing -r rules/best64.rule -w 3";

                new HashcatTask(_logger, _options).RunWithWrapper(args, true);
            }
        }

        protected override void TestCandidate(ByteString candidate)
        {
            if (_runHashCat)
            {
                Console.WriteLine(candidate.ToString());
            }
            else if (_hexExtract == 0 && candidate.CRC32Check())
            {
                _logger.LogResult($"False positive found: 0x{candidate.HexSearchValue:x}.");
                _hexExtract = candidate.HexSearchValue;
                _cancellationTokenSource.Cancel(false);
            }
        }
    }
}
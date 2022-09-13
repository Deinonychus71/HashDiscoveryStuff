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
    public class HybridAttackHashCat : HybridAttack
    {
        private uint _hexExtract;

        public HybridAttackHashCat(Logger logger, Options options, int stringLength, uint hexValue) :
            base(logger, options, stringLength, hexValue)
        {
        }

        protected override void Wait(Task[] tasks, CancellationToken cancellationToken)
        {
            if (!string.IsNullOrEmpty(_options.Prefix) || !string.IsNullOrEmpty(_options.Suffix))
            {
                _logger.Log($"Finding false positive...", false);
                Task.WaitAll(tasks, cancellationToken);

                if (_hexExtract == 0)
                {
                    _logger.Log($"No false positive found. Aborting operation.");
                    return;
                }
            }
            else
            {
                _hexExtract = _hexValue;
                _cancellationTokenSource.Cancel();
            }

            if(_combinationPatterns.Count() == 0)
            {
                _logger.Log($"No pattern found. Aborting operation.");
                return;
            }

            if(!File.Exists(_options.PathHashCat))
            {
                _logger.Log($"Hashcat not found. Aborting operation.");
                return;
            }

            //_cancellationTokenSource.Dispose(); //For Hashcat

            // Launch HashCat
            var output = Path.GetFullPath(_logger.PathFile).Replace(".txt", "_hashcat.txt");

            var maskFile = "smash5bruteforce.hcmask";
            var masks = GenerateHashCatMasks();
            var maskPath = Path.Combine(Path.GetDirectoryName(_options.PathHashCat), "masks", maskFile);
            File.WriteAllLines(maskPath, masks.ToArray());

            var quiet = string.Empty;
            if (!_options.Verbose)
                quiet = " --quiet";
            string args = $"--hash-type 11500 -a 3 {_hexExtract:x8}:00000000 masks/{maskFile} --outfile \"{output}\" --keep-guessing -w 3{quiet}";
            new HashcatTask(_logger, _options).Run(args, _options.Verbose);
        }

        protected override void End() { }

        protected override void TestCandidate(ByteString candidate)
        {
            if (candidate.CRC32Check())
            {
                _logger.LogResult($"False positive found: 0x{candidate.HexSearchValue:x}.");
                _hexExtract = candidate.HexSearchValue;
                _cancellationTokenSource.Cancel();
            }
        }

        private List<string> GenerateHashCatMasks()
        {
            var output = new List<string>();
            foreach (var combination in _combinationPatterns)
            {
                var compiledCombination = _combinationGeneration.CompileCombination(combination);
                var mask = new StringBuilder();
                var first = true;
                var inclFirst = false;

                for(int i = 0; i < compiledCombination.Length; i++)
                {
                    var byt = compiledCombination[i];
                    if(byt == 0)
                    {
                        i++;
                        var length = compiledCombination[i];
                        for(int j = 0; j < length; j++)
                        {
                            if (first)
                            {
                                mask.Append("?2");
                                inclFirst = true;
                            }
                            else
                                mask.Append("?1");
                            first = false;
                        }
                    }
                    else
                    {
                        mask.Append((char)byt);
                    }

                    first = false;
                }
                output.Add($"{_inputValidChars},{(inclFirst ? _inputValidStartChars + "," : "")}{mask}");
            }

            return output;
        }
    }
}
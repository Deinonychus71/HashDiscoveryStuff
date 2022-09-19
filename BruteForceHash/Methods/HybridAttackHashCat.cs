using BruteForceHash.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BruteForceHash
{
    public class HybridAttackHashCat : HybridAttack
    {
        private uint _hexExtract;
        private bool _started = false;

        public HybridAttackHashCat(Logger logger, Options options, int stringLength, uint hexValue) :
            base(logger, options, stringLength, hexValue)
        {
        }

        public override void Run()
        {
            PrintHeaders();

            var compiledCombinationPatterns = _combinationGeneration.CompileCombinationsJoin(_combinationPatterns).ToList();

            var taskFactory = new TaskFactory(new LimitedConcurrencyLevelTaskScheduler(_options.NbrThreads));

            //Find false positive if needed
            if (!string.IsNullOrEmpty(_options.Prefix) || !string.IsNullOrEmpty(_options.Suffix))
            {
                _logger.Log($"Finding false positive...", false);

                var tasks = new List<Task>();
                RunAttackTasks(taskFactory, tasks, compiledCombinationPatterns, false, false);
                _cancellationTokenSource.Dispose();

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

            _started = true;

            if (_combinationPatterns.Count() == 0)
            {
                _logger.Log($"No pattern found. Aborting operation.");
                return;
            }

            // Launch HashCat
            var output = Path.GetFullPath(_logger.PathFile).Replace(".txt", "_hashcat.txt");

            var compiledCpuPatterns = compiledCombinationPatterns.Where(p =>
            {
                if (p[0] != 0)
                    return true;

                var totalUnknownChars = 0;
                int cursor = 0;
                var loc = Array.IndexOf(p, _nullByte, cursor);
                while(loc != -1)
                {
                    totalUnknownChars += p[loc + 1];
                    cursor = loc + 1;
                    loc = Array.IndexOf(p, _nullByte, cursor);
                }

                if (totalUnknownChars < _options.HybridMinCharHashcatThreshold)
                    return true;

                return false;
            });
            var compiledHashCatCombinations = compiledCombinationPatterns.Except(compiledCpuPatterns);

            var maskFile = "smash5bruteforce.hcmask";
            var masks = GenerateHashCatMasks(compiledHashCatCombinations);
            var maskPath = Path.Combine(Path.GetDirectoryName(_options.PathHashCat), "masks", maskFile);
            File.WriteAllLines(maskPath, masks.ToArray());

            _logger.Log($"Hashcat Combinations: {masks.Count()}");
            _logger.Log($"CPU Combinations: {compiledCpuPatterns.Count()}");
            _logger.Log("-----------------------------------------");

            var quiet = string.Empty;
            if (!_options.Verbose)
                quiet = " --quiet";
            string args = $"--hash-type 11500 -a 3 {_hexExtract:x8}:00000000 masks/{maskFile} --outfile \"{output}\" --keep-guessing -w 3{quiet}";

            //Run Threaded Hybrid CPU / GPU attack
            var tasksCrack = new List<Task>();

            //CPU will focus on combinations beginning with a known word as Hashcat is much slower dealing with these
            if (compiledHashCatCombinations.Count() > 0)
            {
                tasksCrack.Add(taskFactory.StartNew(() =>
                {
                    new HashcatTask(_logger, _options).Run(args, _options.Verbose);
                }));
            }

            RunAttackTasks(taskFactory, tasksCrack, compiledCpuPatterns, true, false);

            _logger.Log("-----------------------------------------");
            _logger.Log($"Done");
        }

        protected override void TestCandidate(ByteString candidate)
        {
            if (candidate.CRC32Check())
            {
                if (!_started)
                {
                    _logger.LogResult($"False positive found: 0x{candidate.HexSearchValue:x}.");
                    _hexExtract = candidate.HexSearchValue;
                    _cancellationTokenSource.Cancel();
                }
                else
                {
                    _logger.LogResult(candidate.ToString());
                }
            }
        }

        private IEnumerable<string> GenerateHashCatMasks(IEnumerable<byte[]> compiledCombinationPatterns)
        {
            var output = new List<string>();
            foreach (var compiledCombination in compiledCombinationPatterns)
            {
                var mask = new StringBuilder();
                var first = true;
                var inclFirst = false;

                for (int i = 0; i < compiledCombination.Length; i++)
                {
                    var byt = compiledCombination[i];
                    if (byt == 0)
                    {
                        i++;
                        var length = compiledCombination[i];
                        for (int j = 0; j < length; j++)
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

            return output.Distinct();
        }
    }
}
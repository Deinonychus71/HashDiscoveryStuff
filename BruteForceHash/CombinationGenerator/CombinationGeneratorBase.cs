using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BruteForceHash.CombinationGenerator
{
    public abstract class CombinationGeneratorBase
    {
        protected readonly Options _options;
        protected readonly int _stringLength;

        public CombinationGeneratorBase(Options options, int stringLength)
        {
            _options = options;
            _stringLength = stringLength;
        }

        public abstract byte[] CompileCombination(string combinationPattern);

        public abstract byte[] CompileCombinationJoin(string combinationPattern);

        public abstract IEnumerable<string> GenerateCombinations(int stringLength, string customWordsDictionariesPaths, int combinationDeepLevel);

        public IEnumerable<byte[]> CompileCombinations(IEnumerable<string> combinationsPattern)
        {
            return combinationsPattern.Select(p => CompileCombination(p));
        }

        public IEnumerable<byte[]> CompileCombinationsJoin(IEnumerable<string> combinationsPattern)
        {
            return combinationsPattern.Select(p => CompileCombinationJoin(p)).Distinct(new SequenceEqualityComparer<byte>());
        }

        public string DecompileCombination(byte[] compiledCombinationPattern)
        {
            var output = string.Empty;
            for(var i = 0; i < compiledCombinationPattern.Length; i++)
            {
                byte val = compiledCombinationPattern[i];
                if (val == 0)
                {
                    if (i != 0)
                        output += '|';
                    i++;
                    output += $"{{{compiledCombinationPattern[i]}}}";
                }
                else
                {
                    if (i > 1 && compiledCombinationPattern[i - 2] == 0)
                        output += '|';
                    output += Encoding.UTF8.GetString(new byte[1] { val });
                }
            }
            return output;
        }

        private class SequenceEqualityComparer<T> : IEqualityComparer<T[]>
        {
            public bool Equals(T[] a, T[] b)
            {
                if (a == null) return b == null;
                if (b == null) return false;
                return a.SequenceEqual(b);
            }

            public int GetHashCode(T[] val)
            {
                return val.Where(v => v != null)
                        .Aggregate(0, (h, v) => h ^ v.GetHashCode());
            }
        }
    }
}

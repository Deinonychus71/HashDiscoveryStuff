using System.Collections.Generic;
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

        public abstract byte[] CompileCombinations(string combinationPattern);

        public abstract IEnumerable<string> GenerateCombinations(int stringLength);
    }
}

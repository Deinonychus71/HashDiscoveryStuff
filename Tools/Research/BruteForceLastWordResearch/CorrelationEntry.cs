using System.Collections.Generic;

namespace BruteForceLastWordResearch
{
    public class CorrelationEntry
    {
        public string HexCorrelated { get; set; }
        public List<string> CorrelatedHashes { get; set; }
        public List<string> CorrelatedValues { get; set; }
        public string Type { get; set; }
        public string FilePaths { get; set; }
    }
}

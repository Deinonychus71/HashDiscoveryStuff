using System.Collections.Generic;

namespace BruteForceLastWordResearch
{
    public class CsvEntryUncracked
    {
        public string KeyOrValue { get; set; }
        public string Hex { get; set; }
        public string Type { get; set; }
        public string FilePaths { get; set; }
    }

    public class CsvEntryCorrelated
    {
        public string HexCorrelated { get; set; }
        public string CorrelatedHash { get; set; }
        public string CorrelatedValue { get; set; }
        public string Type { get; set; }
        public string FilePaths { get; set; }
    }
}

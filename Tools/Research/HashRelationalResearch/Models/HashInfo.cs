using System.Collections.Generic;

namespace HashRelationalResearch.Models
{
    public class HashInfo
    {
        public string Hash40Hex { get; set; }
        public List<string> Sources { get; set; }
        public List<string> DetailedSources { get; set; }
        public string Label { get; set; }

        public HashInfo()
        {
            Sources = new List<string>();
            DetailedSources = new List<string>();
        }

        public override string ToString()
        {
            return $"{Label ?? Hash40Hex} ({Sources.Count} sources)";
        }
    }
}

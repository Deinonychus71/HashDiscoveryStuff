using System;
using System.Collections.Generic;
using System.Text;

namespace BruteForceHash.GUI
{
    public class HbtFile
    {
        public string HexValue { get; set; }
        public string Method { get; set; }
        public string Prefix { get; set; }
        public string Suffix { get; set; }
        public string Delimiter { get; set; }
        public bool SkipDigits { get; set; }
        public bool SkipSpecials { get; set; }
        public bool ConfirmEnd { get; set; }
        public string ExcludePatterns { get; set; }
        public string IncludePatterns { get; set; }
        public string IncludeWordDict { get; set; }
        public string IncludeWordChar { get; set; }
        public string Dictionaries { get; set; }
        public string DictionariesFirstWord { get; set; }
        public string DictionariesLastWord { get; set; }
        public int WordsLimit { get; set; }
        public string Order { get; set; }
        public bool ForceLowercase { get; set; }
        public int NbrThreads { get; set; }
        public string ValidChars { get; set; }
        public string ValidStartingChars { get; set; }
        public int StartPosition { get; set; }
        public int EndPosition { get; set; }
        public bool Verbose { get; set; }
    }
}

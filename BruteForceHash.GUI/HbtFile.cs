using System;
using System.Collections.Generic;
using System.Text;

namespace BruteForceHash.GUI
{
    public class HbtFile
    {
        public string HexValue { get; set; }
        public bool EnableUtf8 { get; set; }
        public string Method { get; set; }
        public string Prefix { get; set; }
        public string Suffix { get; set; }
        public string Delimiter { get; set; }
        public bool ConfirmEnd { get; set; }
        public string ExcludePatterns { get; set; }
        public string IncludePatterns { get; set; }
        public string IncludeWordDict { get; set; }
        public bool IncludeWordNotFirst { get; set; }
        public bool IncludeWordNotLast { get; set; }
        public string IncludeWordChar { get; set; }
        public string Dictionaries { get; set; }
        public bool DictionariesSkipDigits { get; set; }
        public bool DictionariesSkipSpecials { get; set; }
        public bool DictionariesForceLowercase { get; set; }
        public bool DictionariesAddTypos { get; set; }
        public bool DictionariesReverseTypos { get; set; }
        public bool UseDictionaryFirstWord { get; set; }
        public bool DictionariesFirstWordSkipDigits { get; set; }
        public bool DictionariesFirstWordSkipSpecials { get; set; }
        public bool DictionariesFirstWordForceLowercase { get; set; }
        public bool DictionariesFirstWordAddTypos { get; set; }
        public bool DictionariesFirstWordReverseTypos { get; set; }
        public string DictionariesFirstWord { get; set; }
        public bool UseDictionaryLastWord { get; set; }
        public string DictionariesLastWord { get; set; }
        public bool DictionariesLastWordSkipDigits { get; set; }
        public bool DictionariesLastWordSkipSpecials { get; set; }
        public bool DictionariesLastWordForceLowercase { get; set; }
        public bool DictionariesLastWordAddTypos { get; set; }
        public bool DictionariesLastWordReverseTypos { get; set; }
        public int WordsLimit { get; set; }
        public string Order { get; set; }
        public bool TyposEnableLetterSwap { get; set; }
        public bool TyposEnableSkipLetter { get; set; }
        public bool TyposEnableDoubleLetter { get; set; }
        public bool TyposEnableExtraLetter { get; set; }
        public bool TyposEnableWrongLetter { get; set; }
        public bool TyposEnableReverseLetter { get; set; }

        public int NbrThreads { get; set; }
        public string ValidChars { get; set; }
        public string ValidStartingChars { get; set; }
        public List<string> Charsets { get; set; }
        public int StartPosition { get; set; }
        public int EndPosition { get; set; }
        public bool Verbose { get; set; }
        public string PathHashCat { get; set; }
        public string DictionaryFilterFirst { get; set; }

        /* Advanced */
        public bool DictionaryAdvanced { get; set; }
        public int MaxDelimiters { get; set; }
        public int MinDelimiters { get; set; }
        public int MaxConcatenatedWords { get; set; }
        public int MinConcatenatedWords { get; set; }
        public bool ConcatenateLastTwoWords { get; set; }
        public bool ConcatenateFirstTwoWords { get; set; }
        public int MaxConsecutiveConcatenation { get; set; }
        public int MinConsecutiveConcatenation { get; set; }
        public int MinWordLength { get; set; }
        public int MaxWordLength { get; set; }
        public int MaxOnes { get; set; }
        public int MinOnes { get; set; }
        public int MaxTwos { get; set; }
        public int MinTwos { get; set; }
        public int MaxThrees { get; set; }
        public int MinThrees { get; set; }
        public int MaxFours { get; set; }
        public int MinFours { get; set; }
        public int MaxConsecutiveOnes { get; set; }
        public int MinWordsLimit { get; set; }

        /* Dictionaries */
        public List<string> CustomMainWords { get; set; }
        public List<string> CustomFirstWords { get; set; }
        public List<string> CustomLastWords { get; set; }
    }
}

using System.Collections.Generic;

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
        public bool UseMainDictionaries { get; set; }
        public string Dictionaries { get; set; }
        public bool DictionariesSkipDigits { get; set; }
        public bool DictionariesSkipSpecials { get; set; }
        public bool DictionariesForceLowercase { get; set; }
        public bool DictionariesAddTypos { get; set; }
        public bool DictionariesReverseOrder { get; set; }
        public bool DictionariesCustomWordsUse { get; set; }
        public bool DictionariesCustomWordsSkipDigits { get; set; }
        public bool DictionariesCustomWordsSkipSpecials { get; set; }
        public bool DictionariesCustomWordsForceLowercase { get; set; }
        public bool DictionariesCustomWordsAddTypos { get; set; }
        public int DictionariesCustomWordsMinimumInHash { get; set; }
        public bool DictionariesCustomWordsMinimumInHashUseTypos { get;set;}
        public bool DictionariesExcludeWordsUse { get; set; }
        public List<string> DictionariesExcludeWords { get; set; }
        public bool DictionariesExcludePartialWords { get; set; }
        public bool UseDictionaryFirstWord { get; set; }
        public bool DictionariesFirstWordSkipDigits { get; set; }
        public bool DictionariesFirstWordSkipSpecials { get; set; }
        public bool DictionariesFirstWordForceLowercase { get; set; }
        public bool DictionariesFirstWordAddTypos { get; set; }
        public bool DictionariesFirstWordReverseOrder { get; set; }
        public string DictionariesFirstWord { get; set; }
        public bool DictionariesFirstWordCustomWordsUse { get; set; }
        public bool DictionariesFirstWordCustomWordsSkipDigits { get; set; }
        public bool DictionariesFirstWordCustomWordsSkipSpecials { get; set; }
        public bool DictionariesFirstWordCustomWordsForceLowercase { get; set; }
        public bool DictionariesFirstWordCustomWordsAddTypos { get; set; }
        public bool DictionariesFirstWordExcludeWordsUse { get; set; }
        public List<string> DictionariesFirstWordExcludeWords { get; set; }
        public bool DictionariesFirstWordExcludePartialWords { get; set; }
        public bool UseDictionaryLastWord { get; set; }
        public string DictionariesLastWord { get; set; }
        public bool DictionariesLastWordSkipDigits { get; set; }
        public bool DictionariesLastWordSkipSpecials { get; set; }
        public bool DictionariesLastWordForceLowercase { get; set; }
        public bool DictionariesLastWordAddTypos { get; set; }
        public bool DictionariesLastWordReverseOrder { get; set; }
        public bool DictionariesLastWordCustomWordsUse { get; set; }
        public bool DictionariesLastWordCustomWordsSkipDigits { get; set; }
        public bool DictionariesLastWordCustomWordsSkipSpecials { get; set; }
        public bool DictionariesLastWordCustomWordsForceLowercase { get; set; }
        public bool DictionariesLastWordCustomWordsAddTypos { get; set; }
        public bool DictionariesLastWordExcludeWordsUse { get; set; }
        public List<string> DictionariesLastWordExcludeWords { get; set; }
        public bool DictionariesLastWordExcludePartialWords { get; set; }
        public int WordsLimit { get; set; }
        public string Order { get; set; }
        public string TyposEnableLetterSwap { get; set; }
        public string TyposEnableAppendLetter { get; set; }
        public bool TyposEnableSkipDoubleLetter { get; set; }
        public bool TyposEnableSkipLetter { get; set; }
        public bool TyposEnableDoubleLetter { get; set; }
        public bool TyposEnableExtraLetter { get; set; }
        public bool TyposEnableWrongLetter { get; set; }
        public bool TyposEnableReverseLetter { get; set; }

        public int NbrThreads { get; set; }
        public bool CacheDynamicPrefix { get; set; }
        public bool CacheDynamicSuffix { get; set; }

        public string DictionaryFilterFirstFrom { get; set; }
        public string DictionaryFilterFirstTo { get; set; }

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
        public int AtLeastNbrGteWords { get; set; }
        public int AtLeastNbrGteCharacters { get; set; }
        public int AtLeastNbrLteWords { get; set; }
        public int AtLeastNbrLteCharacters { get; set; }
        public int AtMostNbrGteWords { get; set; }
        public int AtMostNbrGteCharacters { get; set; }
        public int AtMostNbrLteWords { get; set; }
        public int AtMostNbrLteCharacters { get; set; }
        public int MaxConsecutiveOnes { get; set; }
        public int MinWordsLimit { get; set; }

        /* Dictionaries */
        public List<string> CustomMainWords { get; set; }
        public List<string> CustomFirstWords { get; set; }
        public List<string> CustomLastWords { get; set; }

        /* Char Bruteforce */
        public string ValidChars { get; set; }
        public string ValidStartingChars { get; set; }
        public List<string> Charsets { get; set; }
        public bool Verbose { get; set; }
        public string PathHashCat { get; set; }
        public bool UseHybridDictionaries { get; set; }
        public int HybridBruteforceMinChars { get; set; }
        public int HybridBruteforceMaxChars { get; set; }
        public int HybridWordsInHash { get; set; }
        public List<string> HybridDictionariesWords { get; set; }
        public bool UseHybridDictionariesFirstWord { get; set; }
        public List<string> HybridDictionariesFirstWords { get; set; }
        public bool UseHybridDictionariesLastWord { get; set; }
        public List<string> HybridDictionariesLastWords { get; set; }
        public bool HybridIgnoreSizeFilters { get; set; }
        public int HybridMinCharHashcatThreshold { get; set; }
    }
}

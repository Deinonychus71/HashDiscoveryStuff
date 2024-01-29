using System.Collections.Generic;

namespace HashRelationalResearch.GUI.Models
{
    public class HbtFile
    {
        public string HexValue { get; set; } = string.Empty;
        public int NbrThreads { get; set; }
        public string Method { get; set; } = string.Empty;
        public string Prefix { get; set; } = string.Empty;
        public string Suffix { get; set; } = string.Empty;
        public bool Verbose { get; set; }

        public HbtFileWordFiltering WordFiltering { get; set; } = new();

        public HbtFileSizeFiltering SizeFiltering { get; set; } = new();

        public HbtAdvancedAttack AdvancedAttack { get; set; } = new();

        public HbtFileTypos Typos { get; set; } = new();

        public HbtFileDictionaryAttack DictionaryAttack { get; set; } = new();

        public HbtFileCharacterAttack CharacterAttack { get; set; } = new();
    }

    public class HbtFileWordFiltering
    {
        public string ExcludePatterns { get; set; } = string.Empty;
        public string IncludePatterns { get; set; } = string.Empty;
        public string IncludeWordDict { get; set; } = string.Empty;
        public bool IncludeWordNotFirst { get; set; }
        public bool IncludeWordNotLast { get; set; }
        public string Order { get; set; } = string.Empty;
    }

    public class HbtFileSizeFiltering
    {
        public int MinDelimiters { get; set; }
        public int MaxDelimiters { get; set; }
        public int MinWordLength { get; set; }
        public int MaxWordLength { get; set; }
        public int MinOnes { get; set; }
        public int MaxOnes { get; set; }
        public int MinTwos { get; set; }
        public int MaxTwos { get; set; }
        public int MinThrees { get; set; }
        public int MaxThrees { get; set; }
        public int MinFours { get; set; }
        public int MaxFours { get; set; }
        public int AtLeastNbrGteWords { get; set; }
        public int AtLeastNbrGteCharacters { get; set; }
        public int AtLeastNbrLteWords { get; set; }
        public int AtLeastNbrLteCharacters { get; set; }
        public int AtMostNbrGteWords { get; set; }
        public int AtMostNbrGteCharacters { get; set; }
        public int AtMostNbrLteWords { get; set; }
        public int AtMostNbrLteCharacters { get; set; }
    }

    public class HbtAdvancedAttack
    {
        public bool UseDictionaryAdvanced { get; set; }
        public int MinConcatenatedWords { get; set; }
        public int MaxConcatenatedWords { get; set; }
        public int MinConsecutiveConcatenation { get; set; }
        public int MaxConsecutiveConcatenation { get; set; }
        public int MaxConsecutiveOnes { get; set; }
        public int MinWordsLimit { get; set; }
        public bool ConcatenateFirstTwoWords { get; set; }
        public bool ConcatenateLastTwoWords { get; set; }
    }

    public class HbtFileTypos
    {
        public string TyposEnableLetterSwap { get; set; } = string.Empty;
        public string TyposEnableAppendLetter { get; set; } = string.Empty;
        public bool TyposEnableSkipDoubleLetter { get; set; }
        public bool TyposEnableSkipLetter { get; set; }
        public bool TyposEnableDoubleLetter { get; set; }
        public bool TyposEnableExtraLetter { get; set; }
        public bool TyposEnableWrongLetter { get; set; }
        public bool TyposEnableReverseLetter { get; set; }
    }

    public class HbtFileDictionaryAttack
    {
        public HbtFileDictionary DictionaryMain { get; set; } = new();
        public string DictionaryMainFilterFirstFrom { get; set; } = string.Empty;
        public string DictionaryMainFilterFirstTo { get; set; } = string.Empty;
        public int DictionaryMainCustomWordsMinimumInHash { get; set; }
        public bool DictionaryMainCustomWordsMinimumInHashUseTypos { get; set; }
        public bool DictionaryMainCacheDynamicPrefix { get; set; }
        public bool DictionaryMainCacheDynamicSuffix { get; set; }
        public HbtFileDictionary DictionaryFirstWord { get; set; } = new();
        public HbtFileDictionary DictionaryLastWord { get; set; } = new();
    }

    public class HbtFileDictionary
    {
        public bool UseDictionary { get; set; }
        public string? Dictionaries { get; set; }
        public bool SkipDigits { get; set; }
        public bool SkipSpecials { get; set; }
        public bool ForceLowercase { get; set; }
        public bool AddTypos { get; set; }
        public bool ReverseOrder { get; set; }

        public bool UseCustomWords { get; set; }
        public bool CustomWords { get; set; }
        public bool CustomWordsSkipDigits { get; set; }
        public bool CustomWordsSkipSpecials { get; set; }
        public bool CustomWordsForceLowercase { get; set; }
        public bool CustomWordsAddTypos { get; set; }

        public bool UseExcludeWords { get; set; }
        public List<string> ExcludeWords { get; set; } = [];
        public bool ExcludePartialWords { get; set; }
    }

    public class HbtFileCharacterAttack
    {
        public bool EnableUtf8 { get; set; }
        public string ValidChars { get; set; } = string.Empty;
        public string ValidStartingChars { get; set; } = string.Empty;
        public List<string> Charsets { get; set; } = [];
        public string PathHashCat { get; set; } = string.Empty;
        public HbtFileHybridDictionary HybridDictionary { get; set; } = new();
        public int HybridBruteforceMinChars { get; set; }
        public int HybridBruteforceMaxChars { get; set; }
        public int HybridWordsInHash { get; set; }
        public HbtFileHybridDictionary HybridDictionaryFirstWord { get; set; } = new();
        public HbtFileHybridDictionary HybridDictionaryLastWord { get; set; } = new();
        public bool HybridIgnoreSizeFilters { get; set; }
        public int HybridMinCharHashcatThreshold { get; set; }
    }

    public class HbtFileHybridDictionary
    {
        public bool UseDictionary { get; set; }
        public List<string> HybridDictionariesWords { get; set; } = [];
    }
}

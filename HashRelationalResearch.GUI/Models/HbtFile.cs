﻿using System.Collections.Generic;

namespace HashRelationalResearch.GUI.Models
{
    public class HbtFile
    {
        public string HexValue { get; set; } = string.Empty;
        public string? HexLabel { get; set; } = null;
        public int NbrThreads { get; set; } = 8;
        public string AttackType { get; set; } = "Dictionary";
        public string Prefix { get; set; } = string.Empty;
        public string Suffix { get; set; } = string.Empty;
        public bool Verbose { get; set; } = false;

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
        public string Order { get; set; } = "fewer_words_first_long";
    }

    public class HbtFileSizeFiltering
    {
        public int MinDelimiters { get; set; } = -1;
        public int MaxDelimiters { get; set; } = -1;
        public int MinWordLength { get; set; } = 1;
        public int MaxWordLength { get; set; } = 50;
        public int MinOnes { get; set; } = 0;
        public int MaxOnes { get; set; } = 2;
        public int MinTwos { get; set; } = 0;
        public int MaxTwos { get; set; } = 2;
        public int MinThrees { get; set; } = 0;
        public int MaxThrees { get; set; } = 2;
        public int MinFours { get; set; } = 0;
        public int MaxFours { get; set; } = 2;
        public int AtLeastNbrGteWords { get; set; } = 0;
        public int AtLeastNbrGteCharacters { get; set; } = 0;
        public int AtLeastNbrLteWords { get; set; } = 0;
        public int AtLeastNbrLteCharacters { get; set; } = 0;
        public int AtMostNbrGteWords { get; set; } = 0;
        public int AtMostNbrGteCharacters { get; set; } = 0;
        public int AtMostNbrLteWords { get; set; } = 0;
        public int AtMostNbrLteCharacters { get; set; } = 0;
    }

    public class HbtAdvancedAttack
    {
        public bool UseDictionaryAdvanced { get; set; } = false;
        public int MinConcatenatedWords { get; set; } = 0;
        public int MaxConcatenatedWords { get; set; } = 2;
        public int MinConsecutiveConcatenation { get; set; } = 1;
        public int MaxConsecutiveConcatenation { get; set; } = 2;
        public int MaxConsecutiveOnes { get; set; } = 2;
        public int MinWordsLimit { get; set; } = 1;
        public bool ConcatenateFirstTwoWords { get; set; } = false;
        public bool ConcatenateLastTwoWords { get; set; } = false;
    }

    public class HbtFileTypos
    {
        public string TyposEnableLetterSwap { get; set; } = "l-r,a-e";
        public string TyposEnableAppendLetter { get; set; } = "s,ed";
        public bool TyposEnableSkipDoubleLetter { get; set; } = false;
        public bool TyposEnableSkipLetter { get; set; } = false;
        public bool TyposEnableDoubleLetter { get; set; } = false;
        public bool TyposEnableExtraLetter { get; set; } = false;
        public bool TyposEnableWrongLetter { get; set; } = false;
        public bool TyposEnableReverseLetter { get; set; } = false;
    }

    public class HbtFileDictionaryAttack
    {
        public HbtFileDictionary DictionaryMain { get; set; } = new()
        {
            UseDictionary = true
        };
        public HbtFileDictionary DictionaryFirstWord { get; set; } = new();
        public HbtFileDictionary DictionaryLastWord { get; set; } = new();
    }

    public class HbtFileDictionary
    {
        public bool UseDictionary { get; set; } = false;
        public List<string> Dictionaries { get; set; } = [];
        public bool SkipDigits { get; set; } = false;
        public bool SkipSpecials { get; set; } = true;
        public bool ForceLowercase { get; set; } = true;
        public bool AddTypos { get; set; } = false;
        public bool ReverseOrder { get; set; } = false;

        public bool UseCustomWords { get; set; } = false;
        public List<string> CustomWords { get; set; } = [];
        public bool CustomWordsSkipDigits { get; set; } = false;
        public bool CustomWordsSkipSpecials { get; set; } = true;
        public bool CustomWordsForceLowercase { get; set; } = true;
        public bool CustomWordsAddTypos { get; set; } = false;

        public bool UseExcludeWords { get; set; } = false;
        public List<string> ExcludeWords { get; set; } = [];
        public bool ExcludePartialWords { get; set; } = false;

        //Only for Main
        public string MainFilterFirstFrom { get; set; } = string.Empty;
        public string MainFilterFirstTo { get; set; } = string.Empty;
        public bool MainCacheDynamicPrefix { get; set; } = true;
        public bool MainCacheDynamicSuffix { get; set; } = true;

        public int MainCustomWordsMinimumInHash { get; set; } = 0;
        public bool MainCustomWordsMinimumInHashUseTypos { get; set; } = false;
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
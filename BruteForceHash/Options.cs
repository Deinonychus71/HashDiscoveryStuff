using CommandLine;

namespace BruteForceHash
{
    public class Options
    {
        //Common
        [Option('h', "hex_value", Required = false, HelpText = "Hex Value to search. Can be a list (separated by comma)")]
        public string HexValue { get; set; }
        [Option('m', "method", Required = false, Default = "dictionary", HelpText = "Method to use (dictionary or character)")]
        public string Method { get; set; }
        [Option('p', "prefix", Required = false, Default = "", HelpText = "Prefix to apply before the search (optional).")]
        public string Prefix { get; set; }
        [Option('s', "suffix", Required = false, Default = "", HelpText = "Suffix to apply after the search (optional).")]
        public string Suffix { get; set; }
        [Option('d', "delimiter", Required = false, Default = "_", HelpText = "Delimiter (for dictionary attack).")]
        public string Delimiter { get; set; }
        [Option('t', "nbr_threads", Required = false, Default = 16, HelpText = "Nbr of threads to run.")]
        public int NbrThreads { get; set; }
        [Option('I', "include_word", Required = false, Default = "", HelpText = "Try a string where a certain word must appear.")]
        public string IncludeWord { get; set; }
        [Option('d', "description", Required = false, Default = "", HelpText = "Adding a description for the logs.")]
        public string Description { get; set; }
        [Option('v', "verbose", Required = false, Default = false, HelpText = "Display more search and thread information.")]
        public bool Verbose { get; set; }
        [Option('v', "use_utf8", Required = false, Default = false, HelpText = "Use UTF8.")]
        public bool UseUTF8 { get; set; }
        [Option('v', "use_hashcat", Required = false, Default = false, HelpText = "Use Hashcat.")]
        public bool UseHashcat { get; set; }
        [Option('e', "confirm_end", Required = false, Default = false, HelpText = "Confirm before exiting the window.")]
        public bool ConfirmEnd { get; set; }

        //Patterns Generated
        [Option('n', "enable_dynamic_prefix_cache", Required = false, Default = false, HelpText = "Disable dynamic prefix optimization.")]
        public bool EnableDynamicPrefixCache { get; set; }
        [Option('n', "enable_dynamic_suffix_cache", Required = false, Default = false, HelpText = "Disable dynamic suffix optimization.")]
        public bool EnableDynamicSuffixCache { get; set; }
        [Option('n', "max_delimiters", Required = false, Default = -1, HelpText = "Maximum Number of Delimiters that can be in the target string.")]
        public int MaxDelimiters { get; set; }
        [Option('n', "min_delimiters", Required = false, Default = -1, HelpText = "Minimum Number of Delimiters that can be in the target string.")]
        public int MinDelimiters { get; set; }
        [Option('P', "only_last_two_concatenated", Required = false, Default = false, HelpText = "Only concatenate the last two words in the pattern, everything else should be delimiter separated.")]
        public bool ConcatenateLastTwoWords { get; set; }
        [Option('P', "only_first_two_concatenated", Required = false, Default = false, HelpText = "Only concatenate the first two words in the pattern, everything else should be delimiter separated.")]
        public bool ConcatenateFirstTwoWords { get; set; }
        [Option('P', "max_consecutive_concatenation_limit", Required = false, Default = 2, HelpText = "To apply a limit on concatenated words (for dictionary attack).")]
        public int MaxConsecutiveConcatenation { get; set; }
        [Option('P', "min_consecutive_concatenation_limit", Required = false, Default = 1, HelpText = "To apply a limit on concatenated words (for dictionary attack).")]
        public int MinConsecutiveConcatenation { get; set; }
        [Option('P', "min_word_length", Required = false, Default = 1, HelpText = "To apply a limit on word length (for dictionary attack).")]
        public int MinWordLength { get; set; }
        [Option('P', "max_word_length", Required = false, Default = 100, HelpText = "To apply a limit on word length (for dictionary attack).")]
        public int MaxWordLength { get; set; }
        [Option('P', "max_ones", Required = false, Default = 10, HelpText = "To apply a limit on low-length words (for dictionary attack).")]
        public int MaxOnes { get; set; }
        [Option('P', "min_ones", Required = false, Default = 0, HelpText = "To apply a limit on low-length words (for dictionary attack).")]
        public int MinOnes { get; set; }
        [Option('P', "max_twos", Required = false, Default = 10, HelpText = "To apply a limit on low-length words (for dictionary attack).")]
        public int MaxTwos { get; set; }
        [Option('P', "min_twos", Required = false, Default = 0, HelpText = "To apply a limit on low-length words (for dictionary attack).")]
        public int MinTwos { get; set; }
        [Option('P', "max_threes", Required = false, Default = 10, HelpText = "To apply a limit on low-length words (for dictionary attack).")]
        public int MaxThrees { get; set; }
        [Option('P', "min_threes", Required = false, Default = 0, HelpText = "To apply a limit on low-length words (for dictionary attack).")]
        public int MinThrees { get; set; }
        [Option('P', "max_fours", Required = false, Default = 10, HelpText = "To apply a limit on low-length words (for dictionary attack).")]
        public int MaxFours { get; set; }
        [Option('P', "min_fours", Required = false, Default = 0, HelpText = "To apply a limit on low-length words (for dictionary attack).")]
        public int MinFours { get; set; }
        [Option('P', "at_least_gte_chars", Required = false, Default = 0, HelpText = "To have least x words above y characters (for dictionary attack).")]
        public int AtLeastAboveChars { get; set; }
        [Option('P', "at_least_gte_words", Required = false, Default = 0, HelpText = "To have least x words above y characters (for dictionary attack).")]
        public int AtLeastAboveWords { get; set; }
        [Option('P', "at_least_lte_chars", Required = false, Default = 0, HelpText = "To have least x words under y characters (for dictionary attack).")]
        public int AtLeastUnderChars { get; set; }
        [Option('P', "at_least_lte_words", Required = false, Default = 0, HelpText = "To have least x words under y characters (for dictionary attack).")]
        public int AtLeastUnderWords { get; set; }
        [Option('P', "at_most_gte_chars", Required = false, Default = 0, HelpText = "To have most x words above y characters (for dictionary attack).")]
        public int AtMostAboveChars { get; set; }
        [Option('P', "at_most_gte_words", Required = false, Default = 0, HelpText = "To have most x words above y characters (for dictionary attack).")]
        public int AtMostAboveWords { get; set; }
        [Option('P', "at_most_lte_chars", Required = false, Default = 0, HelpText = "To have most x words under y characters (for dictionary attack).")]
        public int AtMostUnderChars { get; set; }
        [Option('P', "at_most_lte_words", Required = false, Default = 0, HelpText = "To have most x words under y characters (for dictionary attack).")]
        public int AtMostUnderWords { get; set; }
        [Option('P', "max_concatenated_words", Required = false, Default = 0, HelpText = "To apply a global limit on concatenated words (for dictionary attack).")]
        public int MaxConcatenatedWords { get; set; }
        [Option('P', "min_concatenated_words", Required = false, Default = 0, HelpText = "To apply a global limit on concatenated words (for dictionary attack).")]
        public int MinConcatenatedWords { get; set; }
        [Option('P', "max_consecutive_ones", Required = false, Default = 1, HelpText = "To apply a limit on low-length words (for dictionary attack).")]
        public int MaxConsecutiveOnes { get; set; }




        //Dictionary attack
        [Option('r', "exclude_patterns", Required = false, Default = "", HelpText = "Remove some patterns (typically: '{1}_{1}' will remove any pattern with two consecutive one-character words, separated by comma) (for dictionary attack)")]
        public string ExcludePatterns { get; set; }
        [Option('i', "include_patterns", Required = false, Default = "", HelpText = "Only run patterns that include are specific here (typically: '{3}' would run any pattern containing a 3 characters word, separated by comma) (for dictionary attack)")]
        public string IncludePatterns { get; set; }
        [Option('I', "include_word_not_first", Required = false, Default = false, HelpText = "Do not include the word in the first position (for dictionary attack).")]
        public bool IncludeWordNotFirst { get; set; }
        [Option('I', "include_word_not_last", Required = false, Default = false, HelpText = "Do not include the word in the last position (for dictionary attack).")]
        public bool IncludeWordNotLast { get; set; }
        [Option('w', "words_limit", Required = false, Default = 10, HelpText = "To apply a limit on words search (for dictionary attack).")]
        public int WordsLimit { get; set; }
        [Option('w', "min_words_limit", Required = false, Default = 1, HelpText = "To apply a limit on words search (for dictionary attack).")]
        public int MinWordsLimit { get; set; }
        [Option('o', "order_algorithm", Required = false, Default = "interval", HelpText = "Pick the order in which combinations will run (for dictionary attack, values are interval, fewer_words_first or more_words_first).")]
        public string Order { get; set; }
        [Option('o', "order_longer_words_first", Required = false, Default = false, HelpText = "Pick if longer words should appear first (for dictionary attack).")]
        public bool OrderLongerWordsFirst { get; set; }


        [Option('D', "dictionaries", Required = false, Default = null, HelpText = "List all the main dictionaries to use (separated by semi-colon) (for dictionary attack). First and Last words can be overriden by other parameters.")]
        public string Dictionaries { get; set; }
        [Option('D', "dictionaries_custom", Required = false, Default = null, HelpText = "Path of a custom dictionary for this hash (for custom dictionary attack). First and Last words can be overriden by other parameters.")]
        public string DictionariesCustom { get; set; }
        [Option('D', "dictionaries_exclude", Required = false, Default = null, HelpText = "Path of a list of words to exclude (for dictionary attack). First and Last words can be overriden by other parameters.")]
        public string DictionariesExclude { get; set; }
        [Option('D', "dictionaries_exclude_partial", Required = false, Default = false, HelpText = "True to exclude words that are met partially. First and Last words can be overriden by other parameters.")]
        public bool DictionariesExcludePartialWords { get; set; }
        [Option('D', "dictionaries_skip_digits", Required = false, Default = false, HelpText = "To skip all digits in the search. (for dictionary attack).")]
        public bool DictionariesSkipDigits { get; set; }
        [Option('D', "dictionaries_skip_specials", Required = false, Default = false, HelpText = "To skip all special characters (non alphanumerical) in the search. (for dictionary attack).")]
        public bool DictionariesSkipSpecials { get; set; }
        [Option('D', "dictionaries_force_lowercase", Required = false, Default = false, HelpText = "Force all words to be lowercase (for dictionary attack).")]
        public bool DictionariesForceLowercase { get; set; }
        [Option('D', "dictionaries_add_typos", Required = false, Default = false, HelpText = "Add all sorts of typos to the dictionary (for dictionary attack).")]
        public bool DictionariesAddTypos { get; set; }
        [Option('D', "dictionaries_reverse_order", Required = false, Default = false, HelpText = "Add all sorts of typos to the dictionary (for dictionary attack).")]
        public bool DictionariesReverseOrder { get; set; }
        [Option('D', "dictionaries_custom_skip_digits", Required = false, Default = false, HelpText = "To skip all digits in the search. (for custom dictionary attack).")]
        public bool DictionariesCustomSkipDigits { get; set; }
        [Option('D', "dictionaries_custom_skip_specials", Required = false, Default = false, HelpText = "To skip all special characters (non alphanumerical) in the search. (for custom dictionary attack).")]
        public bool DictionariesCustomSkipSpecials { get; set; }
        [Option('D', "dictionaries_custom_force_lowercase", Required = false, Default = false, HelpText = "Force all words to be lowercase (for custom dictionary attack).")]
        public bool DictionariesCustomForceLowercase { get; set; }
        [Option('D', "dictionaries_custom_add_typos", Required = false, Default = false, HelpText = "Add all sorts of typos to the dictionary (for custom dictionary attack).")]
        public bool DictionariesCustomAddTypos { get; set; }
        [Option('D', "dictionaries_custom_min_words_hash", Required = false, Default = 0, HelpText = "Force at least x words from this dictionary to be used (for custom dictionary attack).")]
        public int DictionariesCustomMinWordsHash { get; set; }
        [Option('D', "dictionaries_custom_min_words_hash_use_typos", Required = false, Default = false, HelpText = "Force at least x words from this dictionary to be used - Use Typos (for custom dictionary attack).")]
        public bool DictionariesCustomMinWordsHashUseTypos { get; set; }

        [Option('D', "delete_generated_dictionary", Required = false, Default = false, HelpText = "Delete hashcat dictionary after it's done using it (for dictionary attack).")]
        public bool DeleteGeneratedDictionary { get; set; }

        [Option('D', "dictionary_filter_first_from", Required = false, Default = "", HelpText = "Filter the first words of a dictionary - left word (for dictionary attack).")]
        public string DictionaryFilterFirstFrom { get; set; }
        [Option('D', "dictionary_filter_first_to", Required = false, Default = "", HelpText = "Filter the first words of a dictionary - right word (for dictionary attack).")]
        public string DictionaryFilterFirstTo { get; set; }
        [Option('D', "dictionaries_first_word", Required = false, Default = null, HelpText = "List all the dictionaries to use (separated by semi-colon) for first word (for dictionary attack).")]
        public string DictionariesFirstWord { get; set; }
        [Option('D', "dictionaries_first_word_custom", Required = false, Default = null, HelpText = "Path of a custom dictionary for this hash for first word (for custom dictionary attack).")]
        public string DictionariesFirstWordCustom { get; set; }
        [Option('D', "dictionaries_first_word_exclude", Required = false, Default = null, HelpText = "Path of a list of words to exclude for first word (for dictionary attack).")]
        public string DictionariesFirstWordExclude { get; set; }
        [Option('D', "dictionaries_first_word_exclude_partial", Required = false, Default = false, HelpText = "True to exclude words that are met partially for the first word.")]
        public bool DictionariesFirstWordExcludePartialWords { get; set; }
        [Option('D', "dictionaries_first_skip_digits", Required = false, Default = false, HelpText = "To skip all digits in the search. (for dictionary attack).")]
        public bool DictionariesFirstSkipDigits { get; set; }
        [Option('D', "dictionaries_first_skip_specials", Required = false, Default = false, HelpText = "To skip all special characters (non alphanumerical) in the search. (for dictionary attack).")]
        public bool DictionariesFirstSkipSpecials { get; set; }
        [Option('D', "dictionaries_first_force_lowercase", Required = false, Default = false, HelpText = "Force all words to be lowercase (for dictionary attack).")]
        public bool DictionariesFirstForceLowercase { get; set; }
        [Option('D', "dictionaries_first_add_typos", Required = false, Default = false, HelpText = "Add all sorts of typos to the dictionary (for dictionary attack).")]
        public bool DictionariesFirstAddTypos { get; set; }
        [Option('D', "dictionaries_first_reverse_order", Required = false, Default = false, HelpText = "Add all sorts of typos to the dictionary (for dictionary attack).")]
        public bool DictionariesFirstReverseOrder { get; set; }
        [Option('D', "dictionaries_first_custom_skip_digits", Required = false, Default = false, HelpText = "To skip all digits in the search. (for custom dictionary attack).")]
        public bool DictionariesFirstCustomSkipDigits { get; set; }
        [Option('D', "dictionaries_first_custom_skip_specials", Required = false, Default = false, HelpText = "To skip all special characters (non alphanumerical) in the search. (for custom dictionary attack).")]
        public bool DictionariesFirstCustomSkipSpecials { get; set; }
        [Option('D', "dictionaries_first_custom_force_lowercase", Required = false, Default = false, HelpText = "Force all words to be lowercase (for custom dictionary attack).")]
        public bool DictionariesFirstCustomForceLowercase { get; set; }
        [Option('D', "dictionaries_first_custom_add_typos", Required = false, Default = false, HelpText = "Add all sorts of typos to the dictionary (for custom dictionary attack).")]
        public bool DictionariesFirstCustomAddTypos { get; set; }

        [Option('D', "dictionaries_last_word", Required = false, Default = null, HelpText = "List all the dictionaries to use (separated by semi-colon) for last word (for dictionary attack).")]
        public string DictionariesLastWord { get; set; }
        [Option('D', "dictionaries_last_word_custom", Required = false, Default = null, HelpText = "Path of a custom dictionary for this hash for last word (for custom dictionary attack).")]
        public string DictionariesLastWordCustom { get; set; }
        [Option('D', "dictionaries_last_word_exclude", Required = false, Default = null, HelpText = "Path of a list of words to exclude for last word (for dictionary attack).")]
        public string DictionariesLastWordExclude { get; set; }
        [Option('D', "dictionaries_last_word_exclude_partial", Required = false, Default = false, HelpText = "True to exclude words that are met partially for the last word.")]
        public bool DictionariesLastWordExcludePartialWords { get; set; }
        [Option('D', "dictionaries_last_skip_digits", Required = false, Default = false, HelpText = "To skip all digits in the search. (for dictionary attack).")]
        public bool DictionariesLastSkipDigits { get; set; }
        [Option('D', "dictionaries_last_skip_specials", Required = false, Default = false, HelpText = "To skip all special characters (non alphanumerical) in the search. (for dictionary attack).")]
        public bool DictionariesLastSkipSpecials { get; set; }
        [Option('D', "dictionaries_last_force_lowercase", Required = false, Default = false, HelpText = "Force all words to be lowercase (for dictionary attack).")]
        public bool DictionariesLastForceLowercase { get; set; }
        [Option('D', "dictionaries_last_add_typos", Required = false, Default = false, HelpText = "Add all sorts of typos to the dictionary (for dictionary attack).")]
        public bool DictionariesLastAddTypos { get; set; }
        [Option('D', "dictionaries_last_reverse_order", Required = false, Default = false, HelpText = "Add all sorts of typos to the dictionary (for dictionary attack).")]
        public bool DictionariesLastReverseOrder { get; set; }
        [Option('D', "dictionaries_last_custom_skip_digits", Required = false, Default = false, HelpText = "To skip all digits in the search. (for custom dictionary attack).")]
        public bool DictionariesLastCustomSkipDigits { get; set; }
        [Option('D', "dictionaries_last_custom_skip_specials", Required = false, Default = false, HelpText = "To skip all special characters (non alphanumerical) in the search. (for custom dictionary attack).")]
        public bool DictionariesLastCustomSkipSpecials { get; set; }
        [Option('D', "dictionaries_last_custom_force_lowercase", Required = false, Default = false, HelpText = "Force all words to be lowercase (for custom dictionary attack).")]
        public bool DictionariesLastCustomForceLowercase { get; set; }
        [Option('D', "dictionaries_last_custom_add_typos", Required = false, Default = false, HelpText = "Add all sorts of typos to the dictionary (for custom dictionary attack).")]
        public bool DictionariesLastCustomAddTypos { get; set; }

        [Option('T', "typos_enable_letter_swap", Required = false, Default = "", HelpText = "Typos - Enable letter swap, formatted like x-y,a-b. (for dictionary attack).")]
        public string TyposEnableLetterSwap { get; set; }
        [Option('T', "typos_enable_append_letters", Required = false, Default = "", HelpText = "Typos - Enable append letter, formatted like s,ed. (for dictionary attack).")]
        public string TyposEnableAppendLetters { get; set; }
        [Option('T', "typos_enable_skip_letter", Required = false, Default = false, HelpText = "Typos - Enable letter skipping. (for dictionary attack).")]
        public bool TyposEnableSkipLetter { get; set; }
        [Option('T', "typos_enable_skip_double_letter", Required = false, Default = false, HelpText = "Typos - Enable letter doubling. (for dictionary attack).")]
        public bool TyposEnableSkipDoubleLetter { get; set; }
        [Option('T', "typos_enable_double_letter", Required = false, Default = false, HelpText = "Typos - Enable letter doubling. (for dictionary attack).")]
        public bool TyposEnableDoubleLetter { get; set; }
        [Option('T', "typos_enable_extra_letter", Required = false, Default = false, HelpText = "Typos - Enable extra letter. (for dictionary attack).")]
        public bool TyposEnableExtraLetter { get; set; }
        [Option('T', "typos_enable_wrong_letter", Required = false, Default = false, HelpText = "Typos - Enable wrong letter. (for dictionary attack).")]
        public bool TyposEnableWrongLetter { get; set; }
        [Option('T', "typos_enable_reverse_letter", Required = false, Default = false, HelpText = "Typos - Enable reverse letter. (for dictionary attack).")]
        public bool TyposEnableReverseLetter { get; set; }
        [Option('H', "run_hashcat", Required = false, Default = false, HelpText = "Script running in hashcat mode (silent) to generate a list of dictionaries. (for dictionary attack).")]
        public bool RunHashcat { get; set; }


        //Character attack
        [Option('c', "valid_chars", Required = false, Default = "etainoshrdlucmfwygpbvkqjxz0123456789_", HelpText = "All the characters to bruteforce (for character attack).")]
        public string ValidChars { get; set; }
        [Option('C', "valid_starting_chars", Required = false, Default = "etainoshrdlucmfwygpbvkqjxz_", HelpText = "All the characters to start with for bruteforce (for character attack).")]
        public string ValidStartingChars { get; set; }
        [Option('h', "path_hashcat", Required = false, Default = "Tools\\Hashcat\\hashcat.exe", HelpText = "Path for HashCat (for character attack).")]
        public string PathHashCat { get; set; }

        //Hybrid attack
        [Option('C', "hybrid_min_characters", Required = false, Default = 1, HelpText = "Min number of unknown characters to bruteforce (for hybrid attack).")]
        public int HybridMinCharacters { get; set; }
        [Option('C', "hybrid_max_characters", Required = false, Default = 7, HelpText = "Max number of unknown characters to bruteforce (for hybrid attack).")]
        public int HybridMaxCharacters { get; set; }
        [Option('D', "hybrid_words_hash", Required = false, Default = 0, HelpText = "Use x words to use in addition to character bruteforcing (for hybrid attack).")]
        public int HybridWordsHash { get; set; }
        [Option('D', "hybrid_dictionary", Required = false, Default = null, HelpText = "Path of a dictionary for this hash (for hybrid attack). First and Last words can be overriden by other parameters.")]
        public string HybridDictionary { get; set; }
        [Option('D', "hybrid_dictionary_first_word", Required = false, Default = null, HelpText = "Path of a dictionary for this hash for first word (for hybrid attack).")]
        public string HybridDictionaryFirstWord { get; set; }
        [Option('D', "hybrid_dictionary_last_word", Required = false, Default = null, HelpText = "Path of a dictionary for this hash for last word (for hybrid attack).")]
        public string HybridDictionaryLastWord { get; set; }
        [Option('C', "hybrid_ignore_size_filters", Required = false, Default = false, HelpText = "Ignore Size Filters to find a maximum of combinations (for hybrid attack).")]
        public bool HybridIgnoreSizeFilters { get; set; }
        [Option('C', "hybrid_min_char_hashcat_threshold", Required = false, Default = 6, HelpText = "Minimum number of characters needed to trigger hashcat (for hybrid attack).")]
        public int HybridMinCharHashcatThreshold { get; set; }
    }
}

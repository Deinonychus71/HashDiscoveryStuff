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
        [Option('e', "confirm_end", Required = false, Default = false, HelpText = "Confirm before exiting the window.")]
        public bool ConfirmEnd { get; set; }

        //Patterns Generated
        [Option('n', "max_delimiters", Required = false, Default = -1, HelpText = "Maximum Number of Delimiters that can be in the target string.")]
        public int MaxDelimiters { get; set; }
        [Option('n', "min_delimiters", Required = false, Default = -1, HelpText = "Minimum Number of Delimiters that can be in the target string.")]
        public int MinDelimiters { get; set; }
        [Option('P', "only_last_two_concatenated", Required = false, Default = false, HelpText = "Only concatenate the last two words in the pattern, everything else should be delimiter separated.")]
        public bool ConcatenateLastTwoWords { get; set; }
        [Option('P', "only_first_two_concatenated", Required = false, Default = false, HelpText = "Only concatenate the first two words in the pattern, everything else should be delimiter separated.")]
        public bool ConcatenateFirstTwoWords { get; set; }
        [Option('P', "max_consecutive_concatenation_limit", Required = false, Default = 10, HelpText = "To apply a limit on concatenated words (for dictionary attack).")]
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
        [Option('P', "max_consecutive_ones", Required = false, Default = 10, HelpText = "To apply a limit on low-length words (for dictionary attack).")]
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


        [Option('D', "dictionaries", Required = false, Default = "*", HelpText = "List all the dictionaries to use (separated by semi-colon) (for dictionary attack).")]
        public string Dictionaries { get; set; }
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
        [Option('D', "delete_generated_dictionary", Required = false, Default = false, HelpText = "Delete hashcat dictionary after it's done using it (for dictionary attack).")]
        public bool DeleteGeneratedDictionary { get; set; }

        [Option('D', "dictionary_filter_first", Required = false, Default = "", HelpText = "Filter the first words of a dictionary.")]
        public string DictionaryFilterFirst { get; set; }
        [Option('D', "dictionaries_first_word", Required = false, Default = "", HelpText = "List all the dictionaries to use (separated by semi-colon) for first word (for dictionary attack).")]
        public string DictionariesFirstWord { get; set; }
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


        [Option('D', "dictionaries_last_word", Required = false, Default = "", HelpText = "List all the dictionaries to use (separated by semi-colon) for last word (for dictionary attack).")]
        public string DictionariesLastWord { get; set; }
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
        [Option('T', "typos_enable_letter_swap", Required = false, Default = false, HelpText = "Typos - Enable l-r swapping. (for dictionary attack).")]
        public bool TyposEnableLetterSwap { get; set; }
        [Option('T', "typos_enable_skip_letter", Required = false, Default = false, HelpText = "Typos - Enable letter skipping. (for dictionary attack).")]
        public bool TyposEnableSkipLetter { get; set; }
        [Option('T', "typos_enable_double_letter", Required = false, Default = false, HelpText = "Typos - Enable letter doubling. (for dictionary attack).")]
        public bool TyposEnableDoubleLetter { get; set; }
        [Option('T', "typos_enable_extra_letter", Required = false, Default = false, HelpText = "Typos - Enable extra letter. (for dictionary attack).")]
        public bool TyposEnableExtraLetter { get; set; }
        [Option('T', "typos_enable_wrong_letter", Required = false, Default = false, HelpText = "Typos - Enable wrong letter. (for dictionary attack).")]
        public bool TyposEnableWrongLetter { get; set; }
        [Option('T', "typos_enable_reverse_letter", Required = false, Default = false, HelpText = "Typos - Enable reverse letter. (for dictionary attack).")]
        public bool TyposEnableReverseLetter { get; set; }



        //Character attack
        [Option('c', "valid_chars", Required = false, Default = "etainoshrdlucmfwygpbvkqjxz0123456789_", HelpText = "All the characters to bruteforce (for character attack).")]
        public string ValidChars { get; set; }
        [Option('C', "valid_starting_chars", Required = false, Default = "etainoshrdlucmfwygpbvkqjxz_", HelpText = "All the characters to start with for bruteforce (for character attack).")]
        public string ValidStartingChars { get; set; }
        [Option('0', "start_position", Required = false, Default = 0, HelpText = "Start position when searching for a word (for character attack).")]
        public int StartPosition { get; set; }
        [Option('1', "end_position", Required = false, Default = -1, HelpText = "End position when searching for a word (for character attack).")]
        public int EndPosition { get; set; }
        [Option('h', "path_hashcat", Required = false, Default = "Tools\\Hashcat\\hashcat.exe", HelpText = "Path for HashCat (for character attack).")]
        public string PathHashCat { get; set; }
        /*[Option('2', "skip_delimiter_in_last_position", Required = false, Default = false, HelpText = "If true, the last character check will skip the delimiter value (for character attack).")]
        public bool SkipDelimiterInLastPosition { get; set; }
        [Option('3', "skip_delimiter_in_first_position", Required = false, Default = false, HelpText = "If true, the first character check will skip the delimiter value (for character attack).")]
        public bool SkipDelimiterInFirstPosition { get; set; }*/



    }
}

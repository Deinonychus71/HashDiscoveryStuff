using CommandLine;

namespace BruteForceHash
{
    public class Options
    {
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
        [Option('S', "skip_digits", Required = false, Default = false, HelpText = "To skip all digits in the search.")]
        public bool SkipDigits { get; set; }
        [Option('l', "skip_specials", Required = false, Default = false, HelpText = "To skip all special characters (non alphanumerical) in the search.")]
        public bool SkipSpecials { get; set; }
        [Option('e', "confirm_end", Required = false, Default = false, HelpText = "Confirm before exiting the window.")]
        public bool ConfirmEnd { get; set; }
        [Option('r', "exclude_patterns", Required = false, Default = "", HelpText = "Remove some patterns (typically: '{1}_{1}' will remove any pattern with two consecutive one-character words, separated by comma) (for dictionary attack)")]
        public string ExcludePatterns { get; set; }
        [Option('i', "include_patterns", Required = false, Default = "", HelpText = "Only run patterns that include are specific here (typically: '{3}' would run any pattern containing a 3 characters word, separated by comma) (for dictionary attack)")]
        public string IncludePatterns { get; set; }
        [Option('I', "include_word", Required = false, Default = "", HelpText = "Try a string where a certain word must appear.")]
        public string IncludeWord { get; set; }
        [Option('D', "dictionaries", Required = false, Default = "*", HelpText = "List all the dictionaries to use (separated by semi-colon) (for dictionary attack).")]
        public string Dictionaries { get; set; }
        [Option('D', "dictionaries_first_word", Required = false, Default = "", HelpText = "List all the dictionaries to use (separated by semi-colon) for first word (for dictionary attack).")]
        public string DictionariesFirstWord { get; set; }
        [Option('D', "dictionaries_last_word", Required = false, Default = "", HelpText = "List all the dictionaries to use (separated by semi-colon) for last word (for dictionary attack).")]
        public string DictionariesLastWord { get; set; }
        [Option('w', "words_limit", Required = false, Default = 10, HelpText = "To apply a limit on words search (for dictionary attack).")]
        public int WordsLimit { get; set; }
        [Option('o', "order", Required = false, Default = "Optimized", HelpText = "Pick the order in which combinations will run (for dictionary attack, values are Ascending, Descending or Optimized).")]
        public string Order { get; set; }
        [Option('f', "force_lowercase", Required = false, Default = false, HelpText = "Force all words to be lowercase (for dictionary attack).")]
        public bool ForceLowercase { get; set; }
        [Option('t', "nbr_threads", Required = false, Default = 16, HelpText = "Nbr of threads to run.")]
        public int NbrThreads { get; set; }
        [Option('c', "valid_chars", Required = false, Default = "etainoshrdlucmfwygpbvkqjxz0123456789_", HelpText = "All the characters to bruteforce (for character attack).")]
        public string ValidChars { get; set; }
        [Option('C', "valid_starting_chars", Required = false, Default = "etainoshrdlucmfwygpbvkqjxz_", HelpText = "All the characters to start with for bruteforce (for character attack).")]
        public string ValidStartingChars { get; set; }
        [Option('0', "start_position", Required = false, Default = 0, HelpText = "Start position when searching for a word (for character attack).")]
        public int StartPosition { get; set; }
        [Option('1', "end_position", Required = false, Default = -1, HelpText = "End position when searching for a word (for character attack).")]
        public int EndPosition { get; set; }
        /*[Option('2', "skip_delimiter_in_last_position", Required = false, Default = false, HelpText = "If true, the last character check will skip the delimiter value (for character attack).")]
        public bool SkipDelimiterInLastPosition { get; set; }
        [Option('3', "skip_delimiter_in_first_position", Required = false, Default = false, HelpText = "If true, the first character check will skip the delimiter value (for character attack).")]
        public bool SkipDelimiterInFirstPosition { get; set; }*/
        [Option('v', "verbose", Required = false, Default = false, HelpText = "Display more search and thread information.")]
        public bool Verbose { get; set; }
    }
}

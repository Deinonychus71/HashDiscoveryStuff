using CommandLine;

namespace BruteForceHash
{
    public class Options
    {
        [Option('h', "hex_value", Required = false, HelpText = "Hex Value to search. Can be a list (separated by comma)")]
        public string HexValue { get; set; }
        [Option('m', "method", Required = false, Default = "dictionary", HelpText = "Method to use (dictionary or letter)")]
        public string Method { get; set; }
        [Option('p', "prefix", Required = false, Default = "", HelpText = "Prefix to apply before the search (optional).")]
        public string Prefix { get; set; }
        [Option('s', "suffix", Required = false, Default = "", HelpText = "Suffix to apply after the search (optional).")]
        public string Suffix { get; set; }
        [Option('d', "delimiter", Required = false, Default = '_', HelpText = "Delimiter (for dictionary hash).")]
        public char Delimiter { get; set; }
        [Option('S', "skip_digits", Required = false, Default = false, HelpText = "To skip all digits in the search.")]
        public bool SkipDigits { get; set; }
        [Option('l', "skip_specials", Required = false, Default = true, HelpText = "To skip all special characters (non alphanumerical) in the search.")]
        public bool SkipSpecials { get; set; }
        [Option('e', "confirm_end", Required = false, Default = true, HelpText = "Confirm before exiting the window.")]
        public bool ConfirmEnd { get; set; }
        [Option('r', "exclude_patterns", Required = false, Default = "", HelpText = "Remove some patterns (typically: '{1}_{1}' will remove any pattern with two consecutive one-letter words, separated by comma) (for dictionary hash)")]
        public string ExcludePatterns { get; set; }
        [Option('i', "include_patterns", Required = false, Default = "", HelpText = "Only run patterns that include are specific here (typically: '{3}' would run any pattern containing a 3 letter word, separated by comma) (for dictionary hash)")]
        public string IncludePatterns { get; set; }
        [Option('I', "include_word", Required = false, Default = "", HelpText = "Try a string where a certain word must appear (for dictionary hash).")]
        public string IncludeWord { get; set; }
        [Option('D', "use_dictionaries", Required = false, Default = "*", HelpText = "List all the dictionaries to use (separated by semi-colon) (for dictionary hash).")]
        public string UseDictionaries { get; set; }
        [Option('w', "words_limit", Required = false, Default = 10, HelpText = "To apply a limit on words search (for dictionary hash).")]
        public int WordsLimit { get; set; }
        [Option('f', "force_lowercase", Required = false, Default = true, HelpText = "Force all words to be lowercase (for dictionary hash).")]
        public bool ForceLowercase { get; set; }
        [Option('t', "nbr_threads", Required = false, Default = 16, HelpText = "Nbr of threads to run.")]
        public int NbrThreads { get; set; }
    }
}

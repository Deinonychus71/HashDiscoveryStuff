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
        [Option('d', "delimiter", Required = false, Default = "_", HelpText = "Delimiter (for dictionary hash).")]
        public string Delimiter { get; set; }
        [Option('s', "skipdigits", Required = false, Default = false, HelpText = "To skip all digits search.")]
        public bool SkipDigits { get; set; }
        [Option('w', "wordslimit", Required = false, Default = 10, HelpText = "To apply a limit on words search (for dictionary hash).")]
        public int WordsLimit { get; set; }
        [Option('t', "threads", Required = false, Default = 16, HelpText = "Nbr of threads to run.")]
        public int NbrThreads { get; set; }
    }
}

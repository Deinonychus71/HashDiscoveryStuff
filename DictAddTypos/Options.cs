using CommandLine;

namespace DictTransformation
{
    public class Options
    {
        [Option('i', "input_file", Required = true, HelpText = "Input dictionary file")]
        public string InputFile { get; set; }
        [Option('o', "output_file", Required = false, HelpText = "Output dictionary file")]
        public string OutputFile { get; set; }

        [Option('d', "remove_digits", Required = false, HelpText = "Remove digits")]
        public bool RemoveDigits { get; set; }
        [Option('D', "remove_digits_keep", Required = false, HelpText = "Remove digits, but keep the words (split if necessary)")]
        public bool RemoveDigitsButKeepWords { get; set; }

        [Option('s', "remove_specials", Required = false, HelpText = "Remove specials")]
        public bool RemoveSpecials { get; set; }
        [Option('S', "remove_specials_keep", Required = false, HelpText = "Remove specials, but keep the words (split if necessary)")]
        public bool RemoveSpecialsButKeepWords { get; set; }

        [Option('t', "insert_typos_lr", Required = false, HelpText = "Insert swap L-R (for smash)")]
        public bool InsertTypoLR { get; set; }

        [Option('c', "split_characters", Required = false, Default = "", HelpText = "List of characters to split, separated by |")]
        public string SplitChars { get; set; }

        [Option('h', "remove_hex", Required = false, HelpText = "Remove hex (for param labels)")]
        public bool RemoveHex { get; set; }
    }
}

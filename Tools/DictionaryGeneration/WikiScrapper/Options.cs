using CommandLine;

namespace WikiScrapper
{
    public class Options
    {
        [Option('i', "input_url", Required = false, Default = "ParamLabels.csv", HelpText = "Input ParamLabel")]
        public string InputUrl { get; set; }

        [Option('d', "dict_eng", Required = false, Default = "dict_english.dic", HelpText = "English Dictionary")]
        public string EnglishDictionary { get; set; }

        [Option('o', "output_file", Required = false, Default = "output_dictionary.dic", HelpText = "Output Dictionary")]
        public string OutputDictionary { get; set; }

        [Option('n', "remove_digits", Required = false, HelpText = "Remove digits")]
        public bool RemoveDigits { get; set; }

        [Option('s', "remove_specials", Required = false, HelpText = "Remove specials")]
        public bool RemoveSpecials { get; set; }

        [Option('a', "remove_accents", Required = false, HelpText = "Remove accents")]
        public bool RemoveAccents { get; set; }
    }
}

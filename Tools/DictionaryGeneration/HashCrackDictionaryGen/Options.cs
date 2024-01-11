using CommandLine;

namespace HashCrackDictionaryGen
{
    public class Options
    {
        [Option('i', "input_file", Required = false, Default = "Sources\\ParamLabels.csv", HelpText = "Input ParamLabels.csv")]
        public string InputParamLabelsFile { get; set; }

        [Option('i', "input_file_smash_wiiu", Required = false, Default = "Sources\\SmashWiiU.txt", HelpText = "Input SmashWiiU.txt")]
        public string InputFileSmashWiiU { get; set; }

        [Option('i', "input_file_const_value_table", Required = false, Default = "Sources\\const_value_table.csv", HelpText = "Input const_value_table")]
        public string InputFileConstValueTableFile { get; set; }

        [Option('i', "input_file_path_hashes", Required = false, Default = "Sources\\Hashes_FullPath.txt", HelpText = "Input path_hashes")]
        public string InputFilePathHashes { get; set; }

        [Option('i', "input_smash_root_path", Required = false, Default = "root", HelpText = "Param to smash root")]
        public string InputSmashRootPath { get; set; }

        [Option('d', "dict_eng", Required = false, Default = "Sources\\dict_english.dic", HelpText = "English Dictionary")]
        public string EnglishDictionary { get; set; }

        [Option('d', "dict_jpn", Required = false, Default = "Sources\\dict_japanese.dic", HelpText = "Japanese Dictionary")]
        public string JapaneseDictionary { get; set; }

        [Option('l', "minimum_characters_deep_search", Required = false, Default = 5, HelpText = "Minimum number of characters for deep search for english/japanese words")]
        public int MinimumCharactersDeepSearch { get; set; }

        [Option('t', "common_words_threshold", Required = false, Default = 250, HelpText = "Number of top words to make it to the 'common' list")]
        public int CommonWordsThreshold { get; set; }

        [Option('t', "common_words_threshold_size_min", Required = false, Default = 3, HelpText = "Minimum size of the words in the common list")]
        public int CommonWordsThresholdSizeMin { get; set; }
    }
}

using CommandLine;

namespace ParamLabelsParser
{
    public class Options
    {
        [Option('i', "input_file", Required = false, Default ="ParamLabels.csv", HelpText = "Input ParamLabel")]
        public string ParamLabelsFile { get; set; }

        [Option('d', "dict_eng", Required = false, Default = "dict_english.dic", HelpText = "English Dictionary")]
        public string EnglishDictionary { get; set; }

        [Option('d', "dict_jpn", Required = false, Default = "dict_japanese.dic", HelpText = "Japanese Dictionary")]
        public string JapaneseDictionary { get; set; }

        [Option('l', "minimum_characters_deep_search", Required = false, Default = 5, HelpText = "Minimum number of characters for deep search for english/japanese words")]
        public int MinimumCharactersDeepSearch { get; set; }

        [Option('t', "common_words_threshold", Required = false, Default = 250, HelpText = "Number of top words to make it to the 'common' list")]
        public int CommonWordsThreshold { get; set; }

        [Option('t', "common_words_threshold_size_min", Required = false, Default = 3, HelpText = "Minimum size of the words in the common list")]
        public int CommonWordsThresholdSizeMin { get; set; }
    }
}

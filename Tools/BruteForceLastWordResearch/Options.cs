using CommandLine;

namespace BruteForceLastWordResearch
{
    public class Options
    {
        [Option('i', "input_smash_root_path", Required = false, Default = "root", HelpText = "Param to smash root")]
        public string InputSmashRootPath { get; set; }

        [Option('p', "input_uncracked_hashes_grouped", Required = false, Default = "uncracked_hashes_grouped.csv", HelpText = "uncracked_hashes_grouped.csv file")]
        public string InputUncrackedHashesGrouped { get; set; }

        [Option('f', "last_word_dictionary", Required = false, Default = "LastWordDictionary.txt", HelpText = "Dictionary of last words to search matching false positive")]
        public string FormatString { get; set; }

        [Option('o', "output_path", Required = false, Default = "dicts_by_type", HelpText = "Output path for dictionary files")]
        public string OutputPath { get; set; }
    }
}

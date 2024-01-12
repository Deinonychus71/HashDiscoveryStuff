using CommandLine;

namespace GhidraMainCrackDictionaryGen
{
    public class Options
    {
        [Option('i', "input_file", Required = false, Default = "main_1101.c", HelpText = "Input ParamLabel")]
        public string MainFilePath { get; set; }
        [Option('o', "output_dict_file", Required = false, Default = "[SmashUltimate][Main]All.dic", HelpText = "Ouput dictionary")]
        public string OutputDictFile { get; set; }
        [Option('l', "output_dict_lowerc_file", Required = false, Default = "[SmashUltimate][Main]All_lowercase.dic", HelpText = "Ouput dictionary")]
        public string OutputDictLowerFile { get; set; }
        [Option('s', "output_solved_file", Required = false, Default = "main_hashes.c", HelpText = "main with solved hashes")]
        public string OutputSolvedHashesFile { get; set; }
        [Option('p', "param_labels_file", Required = false, Default = "Sources\\ParamLabels.csv", HelpText = "Input ParamLabel")]
        public string ParamLabelsFile { get; set; }
    }
}

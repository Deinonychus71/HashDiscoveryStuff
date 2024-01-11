using CommandLine;

namespace HashKeys
{
    public class Options
    {
        [Option('i', "input_smash_root_path", Required = false, Default = "root", HelpText = "Param to smash root")]
        public string InputSmashRootPath { get; set; }

        [Option('f', "format_string", Required = false, Default = "[Smash][Ultimate][ParamLabels][Key-Value]{0}{1}{2}.dic", HelpText = "Format string for the output filename. {0} is [LastWord], {1} is [ByHits], {2} is the type of key/value")]
        public string FormatString { get; set; }

        [Option('r', "exclude_filter_path", Required = false, Default = "", HelpText = "Path to filter out, separated by comma (ex: /stage)")]
        public string ExcludeFilterPath { get; set; }

        [Option('a', "include_filter_path", Required = false, Default = "", HelpText = "Path to filter in, separated by comma (ex: /ui,/param,/fighter)")]
        public string IncludeFilterPath { get; set; }

        [Option('o', "output_path", Required = false, Default = "dicts_by_type", HelpText = "Output path for dictionary files")]
        public string OutputPath { get; set; }

        [Option('p', "input_param_labels", Required = false, Default = "ParamLabels.csv", HelpText = "Input ParamLabel")]
        public string InputParamLabelsFile { get; set; }

        [Option('l', "add_last_word_dic", Required = false, Default = false, HelpText = "Add a version of the dictionary with only last words")]
        public bool AddLastWordDic { get; set; }

        [Option('h', "add_by_hits_dic", Required = false, Default = false, HelpText = "Add a version of the dictionary with only most used words")]
        public bool AddByHitsDic { get; set; }
    }
}

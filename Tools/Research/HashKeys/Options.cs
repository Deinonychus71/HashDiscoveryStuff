using CommandLine;

namespace HashKeys
{
    public class Options
    {
        [Option('i', "input_path", Required = false, Default = "root", HelpText = "Param to root")]
        public string InputPath { get; set; }

        [Option('f', "format_string", Required = false, Default = "[Smash][Ultimate][ParamLabels][Key-Value][All]{0}.dic", HelpText = "Format string for the output filename")]
        public string FormatString { get; set; }

        [Option('r', "exclude_filter_path", Required = false, Default = "", HelpText = "Path to filter out, separated by comma (ex: /stage)")]
        public string ExcludeFilterPath { get; set; }

        [Option('a', "include_filter_path", Required = false, Default = "", HelpText = "Path to filter in, separated by comma (ex: /ui,/param,/fighter)")]
        public string IncludeFilterPath { get; set; }

        [Option('o', "output_path", Required = false, Default = "dicts_by_type", HelpText = "Output path for dictionary files")]
        public string OutputPath { get; set; }

        [Option('p', "input_param_labels", Required = false, Default = "ParamLabels.csv", HelpText = "Input ParamLabel")]
        public string InputParamLabelsFile { get; set; }
    }
}

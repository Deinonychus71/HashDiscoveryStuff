using CommandLine;

namespace HashKeys
{
    public class Options
    {
        [Option('i', "input_path", Required = false, Default = "root", HelpText = "Param to root")]
        public string InputPath { get; set; }

        [Option('o', "output_path", Required = false, Default = "dicts_by_type", HelpText = "Output path for dictionary files")]
        public string OutputPath { get; set; }

        [Option('p', "input_param_labels", Required = false, Default = "ParamLabels.csv", HelpText = "Input ParamLabel")]
        public string InputParamLabelsFile { get; set; }
    }
}

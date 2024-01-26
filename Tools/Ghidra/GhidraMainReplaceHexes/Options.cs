using CommandLine;

namespace GhidraMainReplaceHexes
{
    public class Options
    {
        [Option('i', "input_file_paramlabels", Required = false, Default = "Sources\\ParamLabels.csv", HelpText = "Input ParamLabels.csv")]
        public string InputParamLabelsFile { get; set; }

        [Option('i', "input_file_main", Required = false, Default = "main_1301.c", HelpText = "Input Main")]
        public string InputFileMain { get; set; }

        [Option('o', "output_file_main", Required = false, Default = "main_1301_string.c", HelpText = "Output Main")]
        public string OutputFileMain { get; set; }
    }
}

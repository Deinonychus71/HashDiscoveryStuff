using CommandLine;

namespace HashTable
{
    public class Options
    {
        [Option('i', "input_file", Required = false, Default = "root", HelpText = "Param to PRC file")]
        public string InputFile { get; set; }

        [Option('l', "input_list", Required = false, Default = "root", HelpText = "Param to input list")]
        public string InputFileList { get; set; }

        [Option('o', "output_file", Required = false, Default = "root_csv", HelpText = "Output param to root")]
        public string OutputCSV { get; set; }

        [Option('p', "input_param_labels", Required = false, Default = "ParamLabels.csv", HelpText = "Input ParamLabel")]
        public string InputParamLabelsFile { get; set; }
    }
}

using CommandLine;

namespace HashTable
{
    public class Options
    {
        [Option('i', "input_file", Required = true, HelpText = "Path to Param PRC file, for example 'ui_bgm_db.prc'")]
        public string InputFile { get; set; }

        [Option('l', "input_list", Required = true, HelpText = "Param input list, for ex 'db_root'")]
        public string InputFileList { get; set; }

        [Option('o', "output_file", Required = false, Default = "output.csv", HelpText = "Output param to root")]
        public string OutputCSV { get; set; }

        [Option('p', "input_param_labels", Required = false, Default = "ParamLabels.csv", HelpText = "Input ParamLabel")]
        public string InputParamLabelsFile { get; set; }
    }
}

using CommandLine;

namespace HashRelationalResearch
{
    public class Options
    {
        [Option('i', "input_prc_root_path", Required = false, Default = "root", HelpText = "PRC Root files")]
        public string InputPrcRootPath { get; set; }

        [Option('i', "input_c_root_path", Required = false, Default = "", HelpText = "C Root files")]
        public string InputCRootPath { get; set; }

        [Option('i', "input_file_paramlabels", Required = false, Default = "Sources\\ParamLabels.csv", HelpText = "Input ParamLabels.csv")]
        public string InputParamLabelsFile { get; set; }

        [Option('i', "input_file_motion_list_labels", Required = false, Default = "Sources\\MotionListLabels.txt", HelpText = "Input motion_list_labels")]
        public string InputFileMotionListLabels { get; set; }

        [Option('i', "input_file_effects_labels", Required = false, Default = "Sources\\effect_handle_flags.csv", HelpText = "Input effect_handle_flags")]
        public string InputFileEffectsLabels { get; set; }

        [Option('i', "input_file_sound_label_info", Required = false, Default = "Sources\\SoundLabelInfo.txt", HelpText = "Input sound_label_info")]
        public string InputFileSoundLabelInfo { get; set; }

        [Option('i', "input_file_path_hashes", Required = false, Default = "Sources\\Hashes_FullPath.txt", HelpText = "Input path_hashes")]
        public string InputFilePathHashes { get; set; }

        [Option('i', "input_file_sqb_labels", Required = false, Default = "Sources\\SQBLabels.txt", HelpText = "Input sqb_labels")]
        public string InputFileSQBLabels { get; set; }

        [Option('o', "output_file_json", Required = false, Default = "export.json", HelpText = "Output JSON")]
        public string OutputFileJSON { get; set; }

        [Option('o', "output_file_csv", Required = false, Default = "export.csv", HelpText = "Output CSV")]
        public string OutputFileCSV { get; set; }
    }
}

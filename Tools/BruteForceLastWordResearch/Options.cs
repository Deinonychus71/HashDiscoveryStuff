using CommandLine;

namespace BruteForceLastWordResearch
{
    public class Options
    {
        [Option('p', "input_uncracked_hashes_grouped", Required = false, Default = "uncracked_hashes_grouped.csv", HelpText = "uncracked_hashes_grouped.csv file")]
        public string InputUncrackedHashesGrouped { get; set; }

        [Option('p', "input_inline_hashes", Required = false, Default = "", HelpText = "List of hashes to test inline, comma separated")]
        public string InputInlineHashes { get; set; }

        [Option('f', "last_words_dictionary_inline", Required = false, Default = "LastWordsDictionaryInline.txt", HelpText = "Dictionary of last words to search matching false positive for inline hashes")]
        public string InputLastWordsDictionaryInline { get; set; }

        [Option('f', "last_words_dictionary_numeric", Required = false, Default = "LastWordsDictionaryNumeric.txt", HelpText = "Dictionary of last words to search matching false positive for numeric hashes")]
        public string InputLastWordsDictionaryNumeric { get; set; }

        [Option('f', "last_words_dictionary_other", Required = false, Default = "LastWordsDictionaryOther.txt", HelpText = "Dictionary of last words to search matching false positive for other hashes")]
        public string InputLastWordsDictionaryOther { get; set; }

        [Option('r', "exclude_filter_path", Required = false, Default = "", HelpText = "Path to filter out, separated by comma (ex: /stage)")]
        public string ExcludeFilterPath { get; set; }

        [Option('a', "include_filter_path", Required = false, Default = "", HelpText = "Path to filter in, separated by comma (ex: /ui,/param,/fighter)")]
        public string IncludeFilterPath { get; set; }

        [Option('a', "accepted_types", Required = false, Default = "byte,float,int,sbyte,short,uint,ushort,string,hash40", HelpText = "Accepted types, comma separated, if using input_uncracked_hashes_grouped")]
        public string AcceptedTypes { get; set; }

        [Option('s', "search_size_minimum", Required = false, Default = 6, HelpText = "Length of a hex to search for minimum. The hex will be skipped if its length minus lastword is less than this value")]
        public int SearchSizeMinimum { get; set; }

        [Option('s', "search_size_maximum", Required = false, Default = 40, HelpText = "Length of a hex to search for maximum. The hex will be skipped if its length minus lastword is more than this value")]
        public int SearchSizeMaximum { get; set; }

        [Option('t', "nbr_threads", Required = false, Default = 8, HelpText = "Nbr of threads to run.")]
        public int NbrThreads { get; set; }

        [Option('o', "output_path", Required = false, Default = "root_csv", HelpText = "Output path for researched csvs")]
        public string OutputPath { get; set; }
    }
}

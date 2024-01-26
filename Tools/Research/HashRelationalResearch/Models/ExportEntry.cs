using System.Collections.Generic;

namespace HashRelationalResearch.Models
{
    public class ExportContainer
    {
        public Dictionary<string, ExportEntry> ExportEntries { get; set; }

        public Dictionary<string, List<ExportFunctionEntry>> ExportFunctions { get; set; }
    }

    public class ExportEntry
    {
        public string Hash40Hex { get; set; }

        /// <summary>
        /// If really unsure that it's a valid hex
        /// </summary>
        public bool SuspiciousHex { get; set; }

        public HashInfo Label { get; set; }

        public List<ExportPRCFileEntry> PRCFiles { get; set; }

        public List<ExportCFileEntry> CFiles { get; set; }

        public ExportEntry()
        {
            PRCFiles = new List<ExportPRCFileEntry>();
            CFiles = new List<ExportCFileEntry>();
        }

        public override string ToString()
        {
            return Label?.ToString() ?? Hash40Hex;
        }
    }

    public class ExportPRCFileEntry
    {
        public string File { get; set; }

        public string Path { get; set; }

        public bool IsKey { get; set; }

        public string Type { get; set; }
    }

    public class ExportCFileEntry
    {
        public string File { get; set; }

        public List<ExportCFileInstanceEntry> Instances { get; set; }

        public ExportCFileEntry()
        {
            Instances = new List<ExportCFileInstanceEntry>();
        }
    }

    public class ExportCFileInstanceEntry
    {
        public int FunctionId { get; set; }

        public int FileLine { get; set; }

        public int FunctionLine { get; set; }

        public string LineCode { get; set; }
    }

    public class ExportFunctionEntry
    {
        public string Function { get; set; }

        public string Content { get; set; }

        public List<string> Hashes { get; set; }

        public ExportFunctionEntry()
        {
            Hashes = new List<string>();
        }
    }
}

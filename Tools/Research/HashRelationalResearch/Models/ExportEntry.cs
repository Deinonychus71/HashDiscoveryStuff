using ProtoBuf;
using System.Collections.Generic;

namespace HashRelationalResearch.Models
{
    [ProtoContract]
    public class ExportContainer
    {
        [ProtoMember(1)]
        public Dictionary<string, ExportEntry> ExportEntries { get; set; }

        [ProtoMember(2)]
        public Dictionary<string, List<ExportFunctionEntry>> ExportFunctions { get; set; }

        [ProtoMember(3)]
        public Dictionary<string, HashInfo> HashLabels { get; set; }
    }

    [ProtoContract]
    public class ExportEntry
    {
        [ProtoMember(1)]
        public string Hash40Hex { get; set; }

        [ProtoMember(2)]
        /// <summary>
        /// If really unsure that it's a valid hex
        /// </summary>
        public bool SuspiciousHex { get; set; }

        [ProtoMember(3)]
        public List<ExportPRCFileEntry> PRCFiles { get; set; }

        [ProtoMember(4)]
        public List<ExportCFileEntry> CFiles { get; set; }

        public ExportEntry()
        {
            PRCFiles = [];
            CFiles = [];
        }

        public override string ToString()
        {
            return Hash40Hex;
        }
    }

    [ProtoContract]
    public class ExportPRCFileEntry
    {
        [ProtoMember(1)]
        public string File { get; set; }

        [ProtoMember(2)]
        public string Path { get; set; }

        [ProtoMember(3)]
        public bool IsKey { get; set; }

        [ProtoMember(4)]
        public string Type { get; set; }
    }

    [ProtoContract]
    public class ExportCFileEntry
    {
        [ProtoMember(1)]
        public string File { get; set; }

        [ProtoMember(2)]
        public List<ExportCFileInstanceEntry> Instances { get; set; }

        public ExportCFileEntry()
        {
            Instances = [];
        }
    }

    [ProtoContract]
    public class ExportCFileInstanceEntry
    {
        [ProtoMember(1)]
        public int FunctionId { get; set; }

        [ProtoMember(2)]
        public int FileLine { get; set; }

        [ProtoMember(3)]
        public int FunctionLine { get; set; }
    }

    [ProtoContract]
    public class ExportFunctionEntry
    {
        [ProtoMember(1)]
        public string Function { get; set; }

        [ProtoMember(2)]
        public string Content { get; set; }

        [ProtoMember(3)]
        public List<string> Hashes { get; set; }

        public ExportFunctionEntry()
        {
            Hashes = [];
        }
    }
}

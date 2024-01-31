using ProtoBuf;
using System.Collections.Generic;

namespace HashRelationalResearch.Models
{
    [ProtoContract]
    public class HashInfo
    {
        [ProtoMember(1)]
        public string Hash40Hex { get; set; }

        [ProtoMember(2)]
        public List<string> Sources { get; set; }

        [ProtoMember(3)]
        public List<string> DetailedSources { get; set; }

        [ProtoMember(4)]
        public string Label { get; set; }

        public HashInfo()
        {
            Sources = [];
            DetailedSources = [];
        }

        public override string ToString()
        {
            return $"{Label ?? Hash40Hex} ({Sources.Count} sources)";
        }
    }
}

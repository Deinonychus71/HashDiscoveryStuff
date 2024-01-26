namespace HashRelationalResearch.Models
{
    public class CSVEntry
    {
        public string Hash { get; set; }

        public string Label { get; set; }

        public string LabelSources { get; set; }

        public string PRCSources { get; set; }

        public string PRCFirstPath { get; set; }

        public string PRCType { get; set; }

        public string CSources { get; set; }

        public string CFirstLine { get; set; }

        public string CFirstFunction { get; set; }

        public string CFirstCode { get; set; }

        public string RelatedKnownHashes { get; set; }

        public string RelatedUnknownHashes { get; set; }

        public string RelatedSuspiciousHashes { get; set; }

        public bool SuspiciousHash { get; set; }
    }
}

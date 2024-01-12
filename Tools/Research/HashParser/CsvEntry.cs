namespace HashParser
{
    public class CsvEntry
    {
        public string FilePath { get; set; }
        public string FullPath { get; set; }
        public string ListPath { get; set; }
        public string KeyLabel { get; set; }
        public string Type { get; set; }
        public string ValueLabel { get; set; }
        public string KeyHexa { get; set; }
        public string ValueHexa { get; set; }
    }

    public class CsvEntryUncracked
    {
        public string KeyOrValue { get; set; }
        public string Hex { get; set; }
        public string Type { get; set; }
        public string FilePaths { get; set; }
    }
}

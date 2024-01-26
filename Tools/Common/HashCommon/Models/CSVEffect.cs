using CsvHelper.Configuration.Attributes;

namespace HashCommon.Models
{
    public class CSVEffect
    {
        [Name("path")]
        public string Path { get; set; }

        [Name("name")]
        public string Name { get; set; }

        [Name("value")]
        public string Value { get; set; }
    }
}

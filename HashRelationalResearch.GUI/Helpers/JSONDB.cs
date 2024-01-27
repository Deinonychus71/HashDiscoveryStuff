using HashRelationalResearch.Models;
using System.IO;
using System.Text.Json;

namespace HashRelationalResearch.GUI.Helpers
{
    public static class JSONDB
    {
        private static Dictionary<string, ExportEntry> _entries = [];
        private static Dictionary<string, List<ExportFunctionEntry>> _functions = [];

        public static void Init(string filename)
        {
            try
            {
                var file = JsonSerializer.Deserialize<ExportContainer>(File.ReadAllText(filename));
                if (file != null)
                {
                    _entries = file.ExportEntries;
                    _functions = file.ExportFunctions;
                }
            }
            catch
            {
                _entries = [];
                _functions = [];
            }
        }

        public static ExportEntry? GetEntry(string hash)
        {
            if (hash.StartsWith("0x") && _entries.TryGetValue(hash, out ExportEntry? value))
                return value;
            return null;
        }

        public static ExportFunctionEntry? GetFunction(string file, int functionId)
        {
            if (_functions.TryGetValue(file, out List<ExportFunctionEntry>? value))
                return value[functionId];
            return null;
        }

        public static List<ExportFunctionEntry> GetFunctions(string file, IEnumerable<int> functionIds)
        {
            var output = new List<ExportFunctionEntry>();
            if (functionIds != null && _functions.TryGetValue(file, out List<ExportFunctionEntry>? value))
            {
                foreach (var functionId in functionIds)
                {
                    output.Add(value[functionId]);
                }
            }
            return output;
        }
    }
}

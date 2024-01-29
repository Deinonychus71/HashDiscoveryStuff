using HashRelationalResearch.Models;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace HashRelationalResearch.GUI.Helpers
{
    public static class JSONDB
    {
        private static Dictionary<string, ExportEntry> _entries = [];
        private static Dictionary<string, List<ExportFunctionEntry>> _functions = [];
        private static Dictionary<string, string> _labels = [];

        public static void Init(string filename)
        {
            try
            {
                var file = JsonSerializer.Deserialize<ExportContainer>(File.ReadAllText(filename));
                if (file != null)
                {
                    _entries = file.ExportEntries;
                    _functions = file.ExportFunctions;
                    _labels = _entries.Values.Where(p => p.Label != null).ToDictionary(p => p.Hash40Hex, p => p.Label.Label);
                    prcEditor.MainWindow.HashToStringLabels.Clear();
                    prcEditor.MainWindow.StringToHashLabels.Clear();
                    foreach (var label in _labels)
                    {
                        prcEditor.MainWindow.HashToStringLabels.Add(ulong.Parse(label.Key[2..], NumberStyles.HexNumber), label.Value);
                        prcEditor.MainWindow.StringToHashLabels.Add(label.Value, ulong.Parse(label.Key[2..], NumberStyles.HexNumber));
                    }

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

        public static string? GetLabel(string hash40)
        {
            if (_labels.TryGetValue(hash40, out string? value))
                return value;
            return null;
        }
    }
}

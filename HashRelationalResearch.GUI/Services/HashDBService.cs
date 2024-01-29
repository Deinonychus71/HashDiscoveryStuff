using HashRelationalResearch.GUI.Services.Interfaces;
using HashRelationalResearch.Models;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace HashRelationalResearch.GUI.Services
{
    public class HashDBService: IHashDBService
    {
        private Dictionary<string, ExportEntry> _entries = [];
        private Dictionary<string, List<ExportFunctionEntry>> _functions = [];
        private Dictionary<string, string> _labels = [];

        public void Init(string filename)
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

        public ExportEntry? GetEntry(string hash)
        {
            if (hash.StartsWith("0x") && _entries.TryGetValue(hash, out ExportEntry? value))
                return value;
            return null;
        }

        public ExportFunctionEntry? GetFunction(string file, int functionId)
        {
            if (_functions.TryGetValue(file, out List<ExportFunctionEntry>? value))
                return value[functionId];
            return null;
        }

        public List<ExportFunctionEntry> GetFunctions(string file, IEnumerable<int> functionIds)
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

        public string? GetLabel(string hash40)
        {
            if (_labels.TryGetValue(hash40, out string? value))
                return value;
            return null;
        }
    }
}

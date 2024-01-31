using HashRelationalResearch.GUI.Services.Interfaces;
using HashRelationalResearch.Models;
using ProtoBuf;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace HashRelationalResearch.GUI.Services
{
    public class HashDBService : IHashDBService
    {
        private Dictionary<string, ExportEntry> _entries = [];
        private Dictionary<string, List<ExportFunctionEntry>> _functions = [];
        private Dictionary<string, string> _labels = [];

        public HashDBService(IConfigurationService configurationService)
        {
            LoadHashDBFile(configurationService.HashDBFilePath);
        }

        public bool LoadHashDBFile(string filePath)
        {
            try
            {
                if (filePath != null && File.Exists(filePath))
                {
                    var file = Deserialize(filePath);
                    if (file != null)
                    {
                        _entries = file.ExportEntries;
                        _functions = file.ExportFunctions;
                        _labels = file.HashLabels.ToDictionary(p => p.Key, p => p.Value.Label);
                        prcEditor.MainWindow.HashToStringLabels.Clear();
                        prcEditor.MainWindow.StringToHashLabels.Clear();
                        foreach (var label in _labels)
                        {
                            prcEditor.MainWindow.HashToStringLabels.Add(ulong.Parse(label.Key[2..], NumberStyles.HexNumber), label.Value);
                            prcEditor.MainWindow.StringToHashLabels.Add(label.Value, ulong.Parse(label.Key[2..], NumberStyles.HexNumber));
                        }

                    }
                    return true;
                }
            }
            catch
            {
                _entries = [];
                _functions = [];
            }
            return false;
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

        private static ExportContainer? Deserialize(string filePath)
        {
            if (filePath.EndsWith("json", System.StringComparison.OrdinalIgnoreCase))
            {
                return JsonSerializer.Deserialize<ExportContainer>(File.ReadAllText(filePath));
            }
            else if (filePath.EndsWith("bin", System.StringComparison.OrdinalIgnoreCase))
            {
                using (var file = File.OpenRead(filePath))
                {
                    return Serializer.Deserialize<ExportContainer>(file);
                }
            }
            return null;
        }
    }
}

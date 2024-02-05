using BruteForceHash.GUI.Helpers;
using BruteForceHash.GUI.Services.Interfaces;
using HashCommon;
using HashRelationalResearch.Models;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text.Json;

namespace BruteForceHash.GUI.Services
{
    public class HashDBService : IHashDBService
    {
        private readonly IConfigurationService _configurationService;
        private readonly Dictionary<DiscoverySource, Dictionary<string, string>> _discoveredLabels = [];

        private Dictionary<string, ExportEntry> _entries = [];
        private Dictionary<string, List<ExportFunctionEntry>> _functions = [];
        private Dictionary<string, string> _labels = [];
        private readonly Dictionary<string, HashSet<ExportEntry>> _entriesPerPrc = [];
        private readonly Dictionary<string, List<ExportEntry>> _cachedEntriesRelatedToHashes = [];

        public HashDBService(IConfigurationService configurationService)
        {
            _configurationService = configurationService;
            _discoveredLabels = [];

            LoadHashDBFile(configurationService.HashDBFilePath);
            LoadDiscoveryFiles();
            RefreshPRCLabels();
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
                        if (prcEditor.MainWindow.HashToStringLabels.Count != 0)
                        {
                            RefreshPRCLabels();
                        }
                        RefreshPRCEntries();
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

        public void RemoveEntry(string hash40)
        {
            _entries.Remove(hash40);

        }

        public void RefreshPRCLabels()
        {
            prcEditor.MainWindow.HashToStringLabels.Clear();
            prcEditor.MainWindow.StringToHashLabels.Clear();
            foreach (var label in _labels)
            {
                prcEditor.MainWindow.HashToStringLabels.Add(ulong.Parse(label.Key[2..], NumberStyles.HexNumber), label.Value);
                prcEditor.MainWindow.StringToHashLabels.Add(label.Value, ulong.Parse(label.Key[2..], NumberStyles.HexNumber));
            }
        }

        private void RefreshPRCEntries()
        {
            _entriesPerPrc.Clear();
            foreach (var entry in _entries.Values)
            {
                if (entry.PRCFiles.Count > 0)
                {
                    foreach (var prcFile in entry.PRCFiles)
                    {
                        if (_entriesPerPrc.TryGetValue(prcFile.File, out HashSet<ExportEntry>? prcEntries) && prcEntries != null)
                        {
                            prcEntries.Add(entry);
                        }
                        else
                        {
                            prcEntries = [entry];
                            _entriesPerPrc.Add(prcFile.File, prcEntries);
                        }
                    }
                }
            }
        }

        private void LoadDiscoveryFiles()
        {
            _discoveredLabels.Clear();
            LoadDiscoveryFile(DiscoverySource.ParamLabels);
            LoadDiscoveryFile(DiscoverySource.NROMainLabels);
            LoadDiscoveryFile(DiscoverySource.NROFightersLabels);
        }

        public IEnumerable<ExportFunctionEntry> GetFunctions(string file, IEnumerable<int> functionIds)
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

        public ExportFunctionEntry? GetFunction(string file, int functionId)
        {
            if (_functions.TryGetValue(file, out List<ExportFunctionEntry>? value))
                return value[functionId];
            return null;
        }

        public ExportEntry? GetEntry(string hash)
        {
            if (hash.StartsWith("0x") && _entries.TryGetValue(hash, out ExportEntry? value))
                return value;
            return null;
        }

        public IEnumerable<ExportEntry> GetEntriesRelatedToHash(string hash)
        {
            if (_cachedEntriesRelatedToHashes.TryGetValue(hash, out List<ExportEntry>? exportEntries) && exportEntries != null)
                return exportEntries;

            var output = new List<ExportEntry>();
            var hashEntry = GetEntry(hash);

            if (hashEntry != null)
            {
                //Create dictionary based on CFiles
                foreach (var cFile in hashEntry.CFiles)
                {
                    var functionIds = cFile.Instances.Select(p => p.FunctionId);
                    var functionHashes = GetFunctions(cFile.File, functionIds);
                    if (functionHashes != null)
                    {
                        var hashes = functionHashes.SelectMany(p => p.Hashes.Select(p => GetEntry(p))).Where(p => p != null);
                        if (hashes != null)
                            output.AddRange(hashes!);
                    }
                }

                //Create dictionary based on PRC
                foreach (var prc in hashEntry.PRCFiles)
                {
                    var entriesWithSameFilePath = GetEntriesByPRCFile(prc.File);
                    if (entriesWithSameFilePath != null)
                        output.AddRange(entriesWithSameFilePath);
                }
            }

            output = output.Distinct().ToList();
            _cachedEntriesRelatedToHashes.TryAdd(hash, output);

            return output;
        }

        public IEnumerable<ExportEntry> GetUncrackedEntries()
        {
            return _entries.Values.Where(p => !_labels.ContainsKey(p.Hash40Hex));
        }

        public IEnumerable<ExportEntry> GetEntries()
        {
            return _entries.Values;
        }

        public IEnumerable<ExportEntry> GetEntriesByPRCFile(string file)
        {
            if (_entriesPerPrc.TryGetValue(file, out HashSet<ExportEntry>? exportEntries) && exportEntries != null)
                return exportEntries;
            return new List<ExportEntry>();
        }

        public string? GetLabel(string hash40)
        {
            if (_labels.TryGetValue(hash40, out string? value))
                return value;
            return null;
        }

        public bool AddOrUpdateLabel(string hash40, string label)
        {
            var source = PickBestSource(hash40);
            if (!_discoveredLabels.TryGetValue(source, out Dictionary<string, string>? dictDiscovery))
            {
                dictDiscovery = [];
                _discoveredLabels.Add(source, dictDiscovery);
            }

            // Would rather force saving again
            //if (dictDiscovery.TryGetValue(hash40, out string? value) && value == label)
            //    return true;

            if (HashHelper.ToHash40(label) != hash40)
                return false;

            dictDiscovery[hash40] = label;
            _labels[hash40] = label;
            prcEditor.MainWindow.HashToStringLabels[ulong.Parse(hash40[2..], NumberStyles.HexNumber)] = label;
            prcEditor.MainWindow.StringToHashLabels[label] = ulong.Parse(hash40[2..], NumberStyles.HexNumber);
            return SaveDiscoveryFile(source);
        }

        private bool SaveDiscoveryFile(DiscoverySource source)
        {
            try
            {
                var filePath = GetFilePathFromSource(source);
                if (filePath != null)
                    File.WriteAllLines(filePath, _discoveredLabels[source].OrderBy(p => p.Value).Select(p => $"{p.Key},{p.Value}"));

                return true;
            }
            catch { }
            return false;
        }

        private void LoadDiscoveryFile(DiscoverySource source)
        {
            var filePath = GetFilePathFromSource(source);

            if (File.Exists(filePath))
            {
                var processFile = new Dictionary<string, string>();
                _discoveredLabels.Add(source, processFile);

                var fileContent = File.ReadAllLines(filePath);
                foreach (var fileLine in fileContent)
                {
                    var split = fileLine.Split(',', StringSplitOptions.RemoveEmptyEntries);
                    if (split.Length > 1)
                    {
                        processFile[split[0]] = split[1];
                        _labels[split[0]] = split[1];
                    }
                }
            }
        }

        private string? GetFilePathFromSource(DiscoverySource source)
        {
            var folderPath = _configurationService.DiscoveredHashesPath;
            if (!string.IsNullOrEmpty(folderPath) && !Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            return source switch
            {
                DiscoverySource.ParamLabels => Path.Combine(folderPath, "ParamLabels.csv"),
                DiscoverySource.NROMainLabels => Path.Combine(folderPath, "NROMainLabels.csv"),
                DiscoverySource.NROFightersLabels => Path.Combine(folderPath, "NROFighterLabels.csv"),
                DiscoverySource.Unknown => Path.Combine(folderPath, "UnsortedLabels.csv"),
                _ => null,
            };
        }

        private DiscoverySource PickBestSource(string hash40)
        {
            DiscoverySource source;
            var entry = GetEntry(hash40);
            if (entry != null)
            {
                if (entry.PRCFiles.Count > 0)
                {
                    source = DiscoverySource.ParamLabels;
                }
                else if (entry.CFiles.Count > 0)
                {
                    if (entry.CFiles.Any(p => !p.File.Contains("main", StringComparison.OrdinalIgnoreCase)))
                        source = DiscoverySource.NROFightersLabels;
                    else
                        source = DiscoverySource.NROMainLabels;
                }
                else
                    source = DiscoverySource.Unknown;
            }
            else
                source = DiscoverySource.Unknown;

            return source;
        }

        private static ExportContainer? Deserialize(string filePath)
        {
            if (filePath.EndsWith("json", StringComparison.OrdinalIgnoreCase))
            {
                return JsonSerializer.Deserialize<ExportContainer>(File.ReadAllText(filePath));
            }
            else if (filePath.EndsWith("bin", StringComparison.OrdinalIgnoreCase))
            {
                using var fileStream = File.OpenRead(filePath);
                using var compressionStream = new GZipStream(fileStream, CompressionMode.Decompress);
                return Serializer.Deserialize<ExportContainer>(compressionStream);
            }
            return null;
        }
    }
}

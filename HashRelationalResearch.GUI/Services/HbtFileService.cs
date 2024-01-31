using HashCommon;
using HashRelationalResearch.GUI.Models;
using HashRelationalResearch.GUI.Services.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace HashRelationalResearch.GUI.Services
{
    public class HbtFileService : IHbtFileService
    {
        private const string QUICK_PATH = "HexData\\[{0}]";
        private const string WORKSPACE_FILEPATH = "workspace.json";
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public HbtFileService()
        {
            _jsonSerializerOptions = new JsonSerializerOptions()
            {
                WriteIndented = true
            };
        }

        public HbtFile NewHbrFile()
        {
            return new HbtFile();
        }

        public HbtFile? LoadHbrFile(string? filePath)
        {
            try
            {
                if (filePath != null && File.Exists(filePath))
                {
                    var fileContent = File.ReadAllText(filePath);
                    return JsonSerializer.Deserialize<HbtFile>(fileContent, _jsonSerializerOptions);
                }
            }
            catch { }
            return null;
        }

        public bool SaveHbrFile(string filePath, HbtFile hbtFile)
        {
            try
            {
                var fileContent = JsonSerializer.Serialize(hbtFile, _jsonSerializerOptions);
                File.WriteAllText(filePath, fileContent);
                return true;
            }
            catch { }
            return false;
        }

        public IEnumerable<HbtFile>? LoadHbtWorkspace()
        {
            try
            {
                if (File.Exists(WORKSPACE_FILEPATH))
                {
                    var fileContent = File.ReadAllText(WORKSPACE_FILEPATH);
                    return JsonSerializer.Deserialize<List<HbtFile>>(fileContent, _jsonSerializerOptions);
                }
            }
            catch { }
            return null;
        }

        public bool SaveHbtWorkspace(IEnumerable<HbtFile?>? hbtFiles)
        {
            try
            {
                if (hbtFiles != null)
                {
                    var fileContent = JsonSerializer.Serialize(hbtFiles.Where(p => p != null), _jsonSerializerOptions);
                    File.WriteAllText(WORKSPACE_FILEPATH, fileContent);
                    return true;
                }
            }
            catch { }
            return false;
        }

        public string? GetQuickDirectory(HbtFile? hbtFile, bool create = false)
        {
            var hex = hbtFile?.HexValue;
            if (HashHelper.IsValidHash40Value(hex))
            {
                var path = GetPath(hex);
                if (create && !Directory.Exists(path))
                    Directory.CreateDirectory(path);
                return path;
            }
            return null;
        }

        public bool QuickDirectoryExists(HbtFile? hbtFile)
        {
            var hex = hbtFile?.HexValue;
            if (HashHelper.IsValidHash40Value(hex))
                return Directory.Exists(GetPath(hex));
            return false;
        }

        public string? GetQuickSaveFile(HbtFile? hbtFile)
        {
            var hex = hbtFile?.HexValue;
            var path = GetPath(hex);
            if (HashHelper.IsValidHash40Value(hex) && File.Exists(path))
                return path;
            return null;
        }

        public bool DeleteQuickDirectory(HbtFile? hbtFile)
        {
            var hash40 = hbtFile?.HexValue;
            var hexPath = GetQuickDirectory(hbtFile);
            if (!string.IsNullOrEmpty(hexPath) && !string.IsNullOrEmpty(hash40))
            {
                try
                {
                    if (File.Exists($"{hexPath}\\[{hash40}].hbt"))
                    {
                        File.Delete($"{hexPath}\\[{hash40}].hbt");
                    }
                    if (File.Exists($"{hexPath}\\[{hash40}].dic"))
                    {
                        File.Delete($"{hexPath}\\[{hash40}].dic");
                    }
                    if (File.Exists($"{hexPath}\\[{hash40}][Exclude].dic"))
                    {
                        File.Delete($"{hexPath}\\[{hash40}][Exclude].dic");
                    }
                    if (File.Exists($"{hexPath}\\[{hash40}][1st].dic"))
                    {
                        File.Delete($"{hexPath}\\[{hash40}][1st].dic");
                    }
                    if (File.Exists($"{hexPath}\\[{hash40}][1st][Exclude].dic"))
                    {
                        File.Delete($"{hexPath}\\[{hash40}][1st][Exclude].dic");
                    }
                    if (File.Exists($"{hexPath}\\[{hash40}][Last].dic"))
                    {
                        File.Delete($"{hexPath}\\[{hash40}][Last].dic");
                    }
                    if (File.Exists($"{hexPath}\\[{hash40}][Last][Exclude].dic"))
                    {
                        File.Delete($"{hexPath}\\[{hash40}][Last][Exclude].dic");
                    }
                    Directory.Delete(hexPath);
                }
                catch
                {
                    return false;
                }
            }
            return true;
        }

        private static string GetPath(string? hash40)
        {
            return string.Format(QUICK_PATH, hash40);
        }
    }
}

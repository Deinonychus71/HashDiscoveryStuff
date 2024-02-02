using BruteForceHash.GUI.Models;
using BruteForceHash.GUI.Services.Interfaces;
using HashCommon;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace BruteForceHash.GUI.Services
{
    public class HbtFileService : IHbtFileService
    {
        private const string QUICK_PATH = "HexData\\[{0}]";
        private const string QUICK_SAVE_PATH = "HexData\\[{0}]\\{0}.hbt";
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
                var directory = Path.GetDirectoryName(filePath);
                if (!Directory.Exists(directory) && !string.IsNullOrEmpty(directory))
                    Directory.CreateDirectory(directory);
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

        public string? GetQuickDirectoryPath(HbtFile? hbtFile, bool create = false)
        {
            var hex = hbtFile?.HexValue;
            if (HashHelper.IsValidHash40Value(hex))
            {
                var path = string.Format(QUICK_PATH, hex);
                if (create && !Directory.Exists(path))
                    Directory.CreateDirectory(path);
                return path;
            }
            return null;
        }

        public bool QuickSaveExists(HbtFile? hbtFile)
        {
            var hex = hbtFile?.HexValue;
            if (HashHelper.IsValidHash40Value(hex))
                return File.Exists(GetQuickSavePath(hex));
            return false;
        }

        public string? GetQuickSaveFilePath(HbtFile? hbtFile)
        {
            var hex = hbtFile?.HexValue;
            var path = GetQuickSavePath(hex);
            if (HashHelper.IsValidHash40Value(hex))
                return path;
            return null;
        }

        public bool DeleteQuickDirectory(HbtFile? hbtFile)
        {
            var hash40 = hbtFile?.HexValue;
            var hexPath = GetQuickDirectoryPath(hbtFile);
            if (!string.IsNullOrEmpty(hexPath) && !string.IsNullOrEmpty(hash40))
            {
                try
                {
                    if (File.Exists(GetQuickSavePath(hash40)))
                    {
                        File.Delete(GetQuickSavePath(hash40));
                    }
                    if (File.Exists($"{hexPath}\\[{hash40}][Research].dic"))
                    {
                        File.Delete($"{hexPath}\\[{hash40}][Research].dic");
                    }
                    if (File.Exists($"{hexPath}\\[{hash40}][Main][Custom].dic"))
                    {
                        File.Delete($"{hexPath}\\[{hash40}][Main][Custom].dic");
                    }
                    if (File.Exists($"{hexPath}\\[{hash40}][Main][Hybrid].dic"))
                    {
                        File.Delete($"{hexPath}\\[{hash40}][Main][Hybrid].dic");
                    }
                    if (File.Exists($"{hexPath}\\[{hash40}][Main][Exclude].dic"))
                    {
                        File.Delete($"{hexPath}\\[{hash40}][Main][Exclude].dic");
                    }
                    if (File.Exists($"{hexPath}\\[{hash40}][1st][Custom].dic"))
                    {
                        File.Delete($"{hexPath}\\[{hash40}][1st][Custom].dic");
                    }
                    if (File.Exists($"{hexPath}\\[{hash40}][1st][Hybrid].dic"))
                    {
                        File.Delete($"{hexPath}\\[{hash40}][1st][Hybrid].dic");
                    }
                    if (File.Exists($"{hexPath}\\[{hash40}][1st][Exclude].dic"))
                    {
                        File.Delete($"{hexPath}\\[{hash40}][1st][Exclude].dic");
                    }
                    if (File.Exists($"{hexPath}\\[{hash40}][Last][Custom].dic"))
                    {
                        File.Delete($"{hexPath}\\[{hash40}][Last][Custom].dic");
                    }
                    if (File.Exists($"{hexPath}\\[{hash40}][Last][Hybrid].dic"))
                    {
                        File.Delete($"{hexPath}\\[{hash40}][Last][Hybrid].dic");
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

        private static string GetQuickSavePath(string? hash40)
        {
            return string.Format(QUICK_SAVE_PATH, hash40);
        }
    }
}

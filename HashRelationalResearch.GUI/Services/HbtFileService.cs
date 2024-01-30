using HashCommon;
using HashRelationalResearch.GUI.Models;
using HashRelationalResearch.GUI.Services.Interfaces;
using System.IO;
using System.Security.Policy;
using System.Text.Json;

namespace HashRelationalResearch.GUI.Services
{
    public class HbtFileService : IHbtFileService
    {
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

        public void SaveHbrFile(string filePath, HbtFile hbtFile)
        {
            try
            {
                var fileContent = JsonSerializer.Serialize(hbtFile, _jsonSerializerOptions);
                File.WriteAllText(filePath, fileContent);
            }
            catch { }
        }

        public string? GetQuickDirectory(HbtFile? hbtFile, bool create = false)
        {
            var hex = hbtFile?.HexLabel;
            if (HashHelper.IsValidHash40Value(hex))
            {
                if (create && !Directory.Exists($"HexData\\[{hex}]"))
                    Directory.CreateDirectory($"HexData\\[{hex}]");
                return $"HexData\\[{hex}]";
            }
            return null;
        }

        public string? GetQuickSaveFile(HbtFile? hbtFile)
        {
            var hex = hbtFile?.HexLabel;
            if (HashHelper.IsValidHash40Value(hex) && File.Exists($"HexData\\[{hex}]"))
            {
                return $"HexData\\[{hex}]";
            }
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
    }
}

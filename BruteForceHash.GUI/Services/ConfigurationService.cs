using BruteForceHash.GUI.Config;
using BruteForceHash.GUI.Services.Interfaces;
using Microsoft.Extensions.Options;
using System.IO;
using System.Text.Json;

namespace BruteForceHash.GUI.Services
{
    public class ConfigurationService : IConfigurationService
    {
        private const string FILE_GLOBAL_CONFIG = "appsettings.json";
        private string[]? _excludePatterns = null;
        private string[]? _includePatterns = null;
        private readonly AppConfiguration _configuration;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public string HashDBFilePath { get => _configuration.HashDBFilePath; set { _configuration.HashDBFilePath = value; } }
        public string HashcatFilePath { get => _configuration.HashcatFilePath; set { _configuration.HashcatFilePath = value; } }
        public string PrcRootPath { get => _configuration.PrcRootPath; set { _configuration.PrcRootPath = value; } }
        public string DiscoveredHashesPath { get => _configuration.DiscoveredHashesPath; set { _configuration.DiscoveredHashesPath = value; } }
        public string BlacklistFilePath { get => _configuration.BlacklistFilePath; set { _configuration.BlacklistFilePath = value; } }

        public ConfigurationService(IOptions<AppConfiguration> configuration)
        {
            _configuration = configuration.Value;
            _jsonSerializerOptions = new JsonSerializerOptions()
            {
                WriteIndented = true
            };
        }

        public string[] GetExcludePatterns()
        {
            if (_excludePatterns == null && File.Exists("PatternSamples/exclude_patterns.txt"))
            {
                _excludePatterns = File.ReadAllLines("PatternSamples/exclude_patterns.txt");
            }
            return _excludePatterns ?? [];
        }

        public string[] GetIncludePatterns()
        {
            if (_includePatterns == null && File.Exists("PatternSamples/include_patterns.txt"))
            {
                _includePatterns = File.ReadAllLines("PatternSamples/include_patterns.txt");
            }
            return _includePatterns ?? [];
        }

        public void SaveGlobalConfiguration()
        {
            File.WriteAllText(FILE_GLOBAL_CONFIG, JsonSerializer.Serialize(_configuration, _jsonSerializerOptions));
        }
    }
}

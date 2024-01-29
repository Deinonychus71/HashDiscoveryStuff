using HashRelationalResearch.GUI.Config;
using HashRelationalResearch.GUI.Services.Interfaces;
using Microsoft.Extensions.Options;
using System.IO;
using System.Text.Json;

namespace HashRelationalResearch.GUI.Services
{
    public class ConfigurationService : IConfigurationService
    {
        private const string FILE_GLOBAL_CONFIG = "appsettings.json";
        private string[]? _excludePatterns = null;
        private string[]? _includePatterns = null;
        private readonly AppConfiguration _configuration;

        public string HashDBFilePath { get => _configuration.HashDBFilePath; set { _configuration.HashDBFilePath = value; } }
        public string HashcatPath { get => _configuration.HashcatPath; set { _configuration.HashcatPath = value; } }
        public string PrcRootPath { get => _configuration.PrcRootPath; set { _configuration.PrcRootPath = value; } }

        public ConfigurationService(IOptions<AppConfiguration> configuration)
        {
            _configuration = configuration.Value;
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
            File.WriteAllText(FILE_GLOBAL_CONFIG, JsonSerializer.Serialize(_configuration));
        }
    }
}

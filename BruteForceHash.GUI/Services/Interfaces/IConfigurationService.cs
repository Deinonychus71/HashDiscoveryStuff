namespace BruteForceHash.GUI.Services.Interfaces
{
    public interface IConfigurationService
    {
        string HashDBFilePath { get; set; }
        string HashcatFilePath { get; set; }
        string PrcRootPath { get; set; }
        string DiscoveredHashesPath { get; set; }
        string BlacklistFilePath { get; set; }

        string[] GetExcludePatterns();
        string[] GetIncludePatterns();

        void SaveGlobalConfiguration();
    }
}

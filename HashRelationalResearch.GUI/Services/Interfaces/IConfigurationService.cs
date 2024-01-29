namespace HashRelationalResearch.GUI.Services.Interfaces
{
    public interface IConfigurationService
    {
        string HashDBFilePath { get; set; }
        string HashcatPath { get; set; }
        string PrcRootPath { get; set; }

        string[] GetExcludePatterns();
        string[] GetIncludePatterns();

        void SaveGlobalConfiguration();
    }
}

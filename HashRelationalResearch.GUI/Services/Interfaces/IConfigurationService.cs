namespace HashRelationalResearch.GUI.Services.Interfaces
{
    public interface IConfigurationService
    {
        string HashDBFilePath { get; set; }
        string HashcatFilePath { get; set; }
        string PrcRootPath { get; set; }

        string[] GetExcludePatterns();
        string[] GetIncludePatterns();

        void SaveGlobalConfiguration();
    }
}

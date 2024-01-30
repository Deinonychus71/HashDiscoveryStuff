using HashRelationalResearch.GUI.Models;

namespace HashRelationalResearch.GUI.Services.Interfaces
{
    public interface IHbtFileService
    {
        HbtFile NewHbrFile();
        HbtFile? LoadHbrFile(string? filePath);
        void SaveHbrFile(string filePath, HbtFile hbtFile);
        string? GetQuickDirectory(HbtFile? hbtFile, bool create = false);
        string? GetQuickSaveFile(HbtFile? hbtFile);
        bool DeleteQuickDirectory(HbtFile? hbtFile);
    }
}

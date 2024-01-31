using HashRelationalResearch.GUI.Models;
using System.Collections.Generic;

namespace HashRelationalResearch.GUI.Services.Interfaces
{
    public interface IHbtFileService
    {
        HbtFile NewHbrFile();
        HbtFile? LoadHbrFile(string? filePath);
        bool SaveHbrFile(string filePath, HbtFile hbtFile);
        string? GetQuickDirectoryPath(HbtFile? hbtFile, bool create = false);
        string? GetQuickSaveFilePath(HbtFile? hbtFile);
        bool QuickSaveExists(HbtFile? hbtFile);
        bool DeleteQuickDirectory(HbtFile? hbtFile);
        IEnumerable<HbtFile>? LoadHbtWorkspace();
        bool SaveHbtWorkspace(IEnumerable<HbtFile?>? hbtFiles);
    }
}

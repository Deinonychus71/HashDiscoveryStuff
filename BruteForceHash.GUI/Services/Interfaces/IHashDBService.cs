using HashRelationalResearch.Models;
using System.Collections.Generic;

namespace BruteForceHash.GUI.Services.Interfaces
{
    public interface IHashDBService
    {
        bool LoadHashDBFile(string filename);
        ExportEntry? GetEntry(string hash40);
        IEnumerable<ExportEntry> GetEntriesRelatedToHash(string hash);
        void RemoveEntry(string hash40);
        ExportFunctionEntry? GetFunction(string file, int functionId);
        IEnumerable<ExportFunctionEntry> GetFunctions(string file, IEnumerable<int> functionIds);
        IEnumerable<ExportEntry> GetEntriesByPRCFile(string file);
        string? GetLabel(string hash40);
        IEnumerable<ExportEntry> GetUncrackedEntries();
        bool AddOrUpdateLabel(string hash40, string label);
    }
}

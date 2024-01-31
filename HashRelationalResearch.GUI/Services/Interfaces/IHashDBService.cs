using HashRelationalResearch.GUI.Helpers;
using HashRelationalResearch.Models;
using System.Collections.Generic;

namespace HashRelationalResearch.GUI.Services.Interfaces
{
    public interface IHashDBService
    {
        bool LoadHashDBFile(string filename);
        ExportEntry? GetEntry(string hash40);
        ExportFunctionEntry? GetFunction(string file, int functionId);
        List<ExportFunctionEntry> GetFunctions(string file, IEnumerable<int> functionIds);
        string? GetLabel(string hash40);
        bool AddOrUpdateLabel(DiscoverySource source, string hash40, string label);
    }
}

using HashRelationalResearch.Models;
using System.Collections.Generic;

namespace HashRelationalResearch.GUI.Services.Interfaces
{
    public interface IHashDBService
    {
        void Init(string filename);
        ExportEntry? GetEntry(string hash);
        ExportFunctionEntry? GetFunction(string file, int functionId);
        List<ExportFunctionEntry> GetFunctions(string file, IEnumerable<int> functionIds);
        string? GetLabel(string hash40);
    }
}

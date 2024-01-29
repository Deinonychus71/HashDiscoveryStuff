using HashRelationalResearch.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

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

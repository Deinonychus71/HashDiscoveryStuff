using BruteForceHash.GUI.Models;
using HashRelationalResearch.Models;
using System.Collections.Generic;

namespace BruteForceHash.GUI.Services.Interfaces
{
    public interface IBruteForceHashService
    {
        string LastCommand { get; }

        bool StartProcess(HbtFile hbtFile, bool useHashCat);

        IEnumerable<string> GenerateResearchDictionary(ExportEntry? hashEntry, bool forceRefresh = false);
        void WipeResearchDictionaryCache();
    }
}

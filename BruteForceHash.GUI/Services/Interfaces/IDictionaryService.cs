using BruteForceHash.GUI.Models;
using System.Collections.Generic;

namespace BruteForceHash.GUI.Services.Interfaces
{
    public interface IDictionaryService
    {
        List<TreeViewItemModel> GetDictionaries();
        void RefreshDictionaries();
    }
}

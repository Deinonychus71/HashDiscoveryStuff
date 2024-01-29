using HashRelationalResearch.GUI.Models;
using System.Collections.Generic;

namespace HashRelationalResearch.GUI.Services.Interfaces
{
    public interface IDictionaryService
    {
        List<TreeViewItemModel> GetDictionaries();
        void RefreshDictionaries();
    }
}

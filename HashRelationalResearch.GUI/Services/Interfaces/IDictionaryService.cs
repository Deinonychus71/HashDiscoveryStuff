using HashRelationalResearch.GUI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HashRelationalResearch.GUI.Services.Interfaces
{
    public interface IDictionaryService
    {
        ObservableCollection<TreeViewItem> LoadDictionaries();
    }
}

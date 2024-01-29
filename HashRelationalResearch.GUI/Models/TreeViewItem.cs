using HashRelationalResearch.GUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace HashRelationalResearch.GUI.Models
{
    public class TreeViewItem : ObservableModelBase
    {
        public string Key { get; set; }
        public string Name { get; set; }
        public string FullPathName { get; set; }
        public ObservableCollection<TreeViewItem> Children { get; } = [];

        public bool IsChecked { get; set; } = false;
        public bool IsExpanded { get; set; } = false;
        public bool IncludeChildren { get; set; } = false;

        public TreeViewItem(string key, string name)
        {
            Key = key;  
            Name = name;
        }
    }
}

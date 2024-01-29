using HashRelationalResearch.GUI.Models;
using HashRelationalResearch.GUI.Services.Interfaces;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace HashRelationalResearch.GUI.ViewModels
{
    public class HashCrackDictionaryTabVM : ViewModelBase
    {
        #region Members
        private HbtFileDictionary? _hbtFileDictionary;
        private bool _isMainDictionary;
        #endregion

        #region Properties
        public HbtFileDictionary? HbtFileDictionary
        {
            get => _hbtFileDictionary;
            set
            {
                _hbtFileDictionary = value;
                OnPropertyChanged(nameof(HbtFileDictionary));
            }
        }

        public ObservableCollection<TreeViewItemModel> TreeViewItems { get; set; }

        public bool IsMainDictionary
        {
            get => _isMainDictionary;
            set
            {
                _isMainDictionary = value;
                OnPropertyChanged(nameof(IsMainDictionary));
            }
        }
        #endregion

        public HashCrackDictionaryTabVM(IDictionaryService dictionaryService)
        {
            _isMainDictionary = false;

            TreeViewItems = new ObservableCollection<TreeViewItemModel>(dictionaryService.GetDictionaries());
        }

        public void LoadHbtFileDictionary(HbtFileDictionary hbtFileDictionary)
        {
            HbtFileDictionary = hbtFileDictionary;
        }

        public List<string> RetrieveDictionaries()
        {
            return RetrieveDictionaries(TreeViewItems);
        }

        private static List<string> RetrieveDictionaries(IEnumerable<TreeViewItemModel> treeViewItems)
        {
            var output = new List<string>();
            foreach(var treeViewItem in treeViewItems)
            {
                if(treeViewItem.IsChecked.HasValue && treeViewItem.IsChecked.Value && !string.IsNullOrEmpty(treeViewItem.FullPathName))
                    output.Add(treeViewItem.FullPathName);
                output.AddRange(RetrieveDictionaries(treeViewItem.Children));
            }
            return output;
        }
    }
}

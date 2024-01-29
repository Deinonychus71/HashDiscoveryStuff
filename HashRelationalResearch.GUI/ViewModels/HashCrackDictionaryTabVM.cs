using HashRelationalResearch.GUI.Models;
using HashRelationalResearch.GUI.Services.Interfaces;
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

        public ObservableCollection<TreeViewItem> TreeViewItems { get; set; }

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

            TreeViewItems = dictionaryService.LoadDictionaries();
        }

        public void LoadHbtFileDictionary(HbtFileDictionary hbtFileDictionary)
        {
            HbtFileDictionary = hbtFileDictionary;
        }
    }
}

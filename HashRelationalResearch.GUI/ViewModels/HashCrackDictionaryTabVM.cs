using CommunityToolkit.Mvvm.Input;
using HashRelationalResearch.GUI.Models;
using HashRelationalResearch.GUI.Services;
using HashRelationalResearch.GUI.Services.Interfaces;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace HashRelationalResearch.GUI.ViewModels
{
    public class HashCrackDictionaryTabVM : ViewModelBase
    {
        #region Members
        private const string TEXT_SEPARATOR = "\r\n";

        private readonly IDictionaryService _dictionaryService;
        private HbtFileDictionary? _hbtFileDictionary;
        private HbtFileDictionary? _parentHbtFileDictionary;
        private string? _customWords;
        private string? _excludeWords;
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

        public string? CustomWords
        {
            get => _customWords;
            set
            {
                _customWords = value;
                if (_customWords != null && _hbtFileDictionary != null)
                {
                    _hbtFileDictionary.CustomWords = [.. _customWords.Split(TEXT_SEPARATOR)];
                }
                OnPropertyChanged(nameof(CustomWords));
            }
        }

        public string? ExcludeWords
        {
            get => _excludeWords;
            set
            {
                _excludeWords = value;
                if (_excludeWords != null && _hbtFileDictionary != null)
                {
                    _hbtFileDictionary.ExcludeWords = [.. _excludeWords.Split(TEXT_SEPARATOR)];
                }
                OnPropertyChanged(nameof(ExcludeWords));
            }
        }

        public ObservableCollection<TreeViewItemModel> TreeViewItems { get; set; } = [];

        public bool IsMainDictionary
        {
            get => _isMainDictionary;
            set
            {
                _isMainDictionary = value;
                OnPropertyChanged(nameof(IsMainDictionary));
            }
        }

        public int[] HashWordsList { get; private set; } = GetIntegerList(0, 4);

        public ICommand UnselectAllCommand { get => new RelayCommand(UnselectAll); }

        public ICommand CopyTreeViewFromViewCommand { get => new RelayCommand(() => LoadTreeViewFromDictionaries(_parentHbtFileDictionary?.Dictionaries)); }

        public ICommand CopyCustomWordsFromViewCommand { get => new RelayCommand(CopyCustomWordsFromMain); }

        public ICommand CopyExcludeWordsCopyFromViewCommand { get => new RelayCommand(CopyExcludeWordsFromMain); }

        public ICommand TreeViewItemCheckedCommand { get => new RelayCommand(SaveDictionaries); }
        #endregion

        public HashCrackDictionaryTabVM(IDictionaryService dictionaryService)
        {
            _dictionaryService = dictionaryService;
            _isMainDictionary = false;
        }

        public void LoadHbtFileDictionary(HbtFileDictionary hbtFileDictionary, HbtFileDictionary? parentHbtFileDictionary = null)
        {
            _parentHbtFileDictionary = parentHbtFileDictionary;
            HbtFileDictionary = hbtFileDictionary;
            LoadTreeView();
            LoadTreeViewFromDictionaries(hbtFileDictionary.Dictionaries);
            CustomWords = string.Join(TEXT_SEPARATOR, hbtFileDictionary.CustomWords);
            ExcludeWords = string.Join(TEXT_SEPARATOR, hbtFileDictionary.ExcludeWords);
        }

        public void LoadTreeViewFromDictionaries(List<string>? dictionaries)
        {
            if (dictionaries != null)
            {
                foreach (var treeViewItem in TreeViewItems)
                    treeViewItem.CheckValues(dictionaries);
            }
        }

        private void LoadTreeView()
        {
            var nodes = _dictionaryService.GetDictionaries();

            TreeViewItems.Clear();
            foreach(var node in nodes)
            {
                TreeViewItems.Add(node);
            }
        }

        private void SaveDictionaries()
        {
            if (_hbtFileDictionary != null)
            {
                var output = new List<string>();
                foreach (var treeViewItem in TreeViewItems)
                    treeViewItem.GetSelectedNodes(ref output);
                _hbtFileDictionary.Dictionaries = output;
            }
        }

        public void UnselectAll()
        {
            foreach (var treeViewItem in TreeViewItems)
                treeViewItem.UnselectAll();
        }

        public void CopyCustomWordsFromMain()
        {
            if (_hbtFileDictionary != null && _parentHbtFileDictionary != null)
            {
                CustomWords = string.Join(TEXT_SEPARATOR, _parentHbtFileDictionary.CustomWords);
            }
        }

        public void CopyExcludeWordsFromMain()
        {
            if (_hbtFileDictionary != null && _parentHbtFileDictionary != null)
            {
                ExcludeWords = string.Join(TEXT_SEPARATOR, _parentHbtFileDictionary.ExcludeWords);
            }
        }

        private static int[] GetIntegerList(int minValue, int maxValue)
        {
            return Enumerable.Range(minValue, maxValue).ToArray();
        }
    }
}

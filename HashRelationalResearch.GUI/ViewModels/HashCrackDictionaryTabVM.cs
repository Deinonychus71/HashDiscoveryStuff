using CommunityToolkit.Mvvm.Input;
using HashRelationalResearch.GUI.Helpers;
using HashRelationalResearch.GUI.Models;
using HashRelationalResearch.GUI.Services.Interfaces;
using System.Collections.Generic;
using System.Collections.ObjectModel;

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
        private bool _isUseResearchWordsEnabled = false;
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

        public bool IsUseResearchWordsEnabled
        {
            get => _isUseResearchWordsEnabled;
            set
            {
                _isUseResearchWordsEnabled = value;
                OnPropertyChanged(nameof(IsUseResearchWordsEnabled));
            }
        }

        public int[] HashWordsList { get; private set; } = ListGenerators.GetIntegerList(0, 4);

        public IRelayCommand UnselectAllCommand { get; private set; }
        public IRelayCommand CopyTreeViewFromViewCommand { get; private set; }
        public IRelayCommand CopyCustomWordsFromViewCommand { get; private set; }
        public IRelayCommand CopyExcludeWordsCopyFromViewCommand { get; private set; }
        public IRelayCommand TreeViewItemCheckedCommand { get; private set; }
        #endregion

        public HashCrackDictionaryTabVM(IDictionaryService dictionaryService)
        {
            _dictionaryService = dictionaryService;
            _isMainDictionary = false;

            UnselectAllCommand = new RelayCommand(UnselectAll);
            CopyTreeViewFromViewCommand = new RelayCommand(CopyDictionariesFromMain);
            CopyCustomWordsFromViewCommand = new RelayCommand(CopyCustomWordsFromMain);
            CopyExcludeWordsCopyFromViewCommand = new RelayCommand(CopyExcludeWordsFromMain);
            TreeViewItemCheckedCommand = new RelayCommand(SaveDictionaries);
        }

        public void LoadHbtFileDictionary(HbtFileDictionary hbtFileDictionary, HbtFileDictionary? parentHbtFileDictionary = null)
        {
            _parentHbtFileDictionary = parentHbtFileDictionary;
            HbtFileDictionary = hbtFileDictionary;
            LoadTreeView();
            LoadTreeViewFromDictionaries(hbtFileDictionary.Words);
            CustomWords = string.Join(TEXT_SEPARATOR, hbtFileDictionary.CustomWords);
            ExcludeWords = string.Join(TEXT_SEPARATOR, hbtFileDictionary.ExcludeWords);
        }

        private void LoadTreeViewFromDictionaries(List<string>? dictionaries)
        {
            if (dictionaries != null)
            {
                foreach (var treeViewItem in TreeViewItems)
                    treeViewItem.CheckValues(dictionaries);
            }
        }

        private void UnselectAll()
        {
            foreach (var treeViewItem in TreeViewItems)
                treeViewItem.UnselectAll();
        }

        private void CopyDictionariesFromMain()
        {
            LoadTreeViewFromDictionaries(_parentHbtFileDictionary?.Words);
            SaveDictionaries();
        }

        private void CopyCustomWordsFromMain()
        {
            if (_hbtFileDictionary != null && _parentHbtFileDictionary != null)
            {
                CustomWords = string.Join(TEXT_SEPARATOR, _parentHbtFileDictionary.CustomWords);
            }
        }

        private void CopyExcludeWordsFromMain()
        {
            if (_hbtFileDictionary != null && _parentHbtFileDictionary != null)
            {
                ExcludeWords = string.Join(TEXT_SEPARATOR, _parentHbtFileDictionary.ExcludeWords);
            }
        }

        private void LoadTreeView()
        {
            var nodes = _dictionaryService.GetDictionaries();

            TreeViewItems.Clear();
            foreach (var node in nodes)
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
                _hbtFileDictionary.Words = output;
            }
        }
    }
}

using BruteForceHash.GUI.Helpers;
using BruteForceHash.GUI.Models;
using CommunityToolkit.Mvvm.Input;
using System.Collections.Generic;
using System.Linq;

namespace BruteForceHash.GUI.ViewModels
{
    public class HashCrackHybridTabVM : ViewModelBase
    {
        #region Members
        private const string TEXT_SEPARATOR = "\r\n";

        private HbtFileHybridAttack? _hbtFileHybridAttack;
        private string? _validCharsPreview;
        private string? _validStartingCharsPreview;
        private string? _mainDictWords;
        private string? _firstDictWords;
        private string? _lastDictWords;
        private bool _isUseResearchWordsEnabled = false;
        #endregion

        #region Properties
        public HbtFileHybridAttack? HbtFileHybridAttack
        {
            get => _hbtFileHybridAttack;
            set
            {
                _hbtFileHybridAttack = value;
                OnPropertyChanged(nameof(HbtFileHybridAttack));
            }
        }

        public string? MainDictWords
        {
            get => _mainDictWords;
            set
            {
                _mainDictWords = value;
                if (_mainDictWords != null && _hbtFileHybridAttack?.Dictionary != null)
                {
                    _hbtFileHybridAttack.Dictionary.Words = [.. _mainDictWords.Split(TEXT_SEPARATOR)];
                }
                OnPropertyChanged(nameof(MainDictWords));
            }
        }

        public string? FirstDictWords
        {
            get => _firstDictWords;
            set
            {
                _firstDictWords = value;
                if (_firstDictWords != null && _hbtFileHybridAttack?.Dictionary != null)
                {
                    _hbtFileHybridAttack.DictionaryFirstWord.Words = [.. _firstDictWords.Split(TEXT_SEPARATOR)];
                }
                OnPropertyChanged(nameof(FirstDictWords));
            }
        }

        public string? LastDictWords
        {
            get => _lastDictWords;
            set
            {
                _lastDictWords = value;
                if (_lastDictWords != null && _hbtFileHybridAttack?.Dictionary != null)
                {
                    _hbtFileHybridAttack.DictionaryLastWord.Words = [.. _lastDictWords.Split(TEXT_SEPARATOR)];
                }
                OnPropertyChanged(nameof(LastDictWords));
            }
        }

        public string? ValidCharsPreview
        {
            get => _validCharsPreview;
            set
            {
                _validCharsPreview = value;
                OnPropertyChanged(nameof(ValidCharsPreview));
            }
        }

        public string? ValidStartingCharsPreview
        {
            get => _validStartingCharsPreview;
            set
            {
                _validStartingCharsPreview = value;
                OnPropertyChanged(nameof(ValidStartingCharsPreview));
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

        public List<CharsetModelView> CharsetsList { get; set; } = Charsets.GetCharsetList();
        public ListItem<int>[] BruteforceMinCharsList { get; set; } = ListGenerators.GetIntegerListWithLabel("chars", 0, 9);
        public ListItem<int>[] BruteforceMaxCharsList { get; set; } = ListGenerators.GetIntegerListWithLabel("chars", 1, 11);
        public ListItem<int>[] WordsInHashList { get; set; } = ListGenerators.GetIntegerListWithLabel("words", 1, 4);
        public ListItem<int>[] MinCharHashcatThresholdList { get; set; } = ListGenerators.GetIntegerListWithLabel("min chars.", 0, 9);

        public IRelayCommand CharsetItemCheckedCommand { get; private set; }
        public IRelayCommand ValidCharsChanged { get; private set; }
        public IRelayCommand ValidStartingCharsChanged { get; private set; }
        #endregion

        public HashCrackHybridTabVM()
        {
            CharsetItemCheckedCommand = new RelayCommand(SaveCharsets);
            ValidCharsChanged = new RelayCommand(RefreshPreview);
            ValidStartingCharsChanged = new RelayCommand(RefreshPreview);
        }

        public void LoadHbtFileHybrid(HbtFileHybridAttack hbtFileHybridAttack)
        {
            HbtFileHybridAttack = hbtFileHybridAttack;
            MainDictWords = string.Join(TEXT_SEPARATOR, hbtFileHybridAttack.Dictionary.Words);
            FirstDictWords = string.Join(TEXT_SEPARATOR, hbtFileHybridAttack.DictionaryFirstWord.Words);
            LastDictWords = string.Join(TEXT_SEPARATOR, hbtFileHybridAttack.DictionaryLastWord.Words);
            LoadCharsets();
            RefreshPreview();
        }

        private void LoadCharsets()
        {
            if (_hbtFileHybridAttack != null)
            {
                foreach (var charsetItem in CharsetsList)
                {
                    charsetItem.IsChecked = _hbtFileHybridAttack.Charsets.Any(p => p == charsetItem.Name);
                }

            }
        }

        private void SaveCharsets()
        {
            if (_hbtFileHybridAttack != null)
            {
                _hbtFileHybridAttack.Charsets = CharsetsList.Where(p => p.IsChecked).Select(p => p.Name).ToList();
                RefreshPreview();
            }
        }

        private void RefreshPreview()
        {
            if (_hbtFileHybridAttack != null)
            {
                ValidCharsPreview = Charsets.GetAllValidChars(_hbtFileHybridAttack.ValidChars, CharsetsList.Where(p => p.IsChecked));
                ValidStartingCharsPreview = Charsets.GetAllValidChars(_hbtFileHybridAttack.ValidStartingChars, CharsetsList.Where(p => p.IsChecked));
            }
        }
    }
}

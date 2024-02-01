using CommunityToolkit.Mvvm.Input;
using HashRelationalResearch.GUI.Helpers;
using HashRelationalResearch.GUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HashRelationalResearch.GUI.ViewModels
{
    public class HashCrackCharacterTabVM : ViewModelBase
    {
        #region Members
        private HbtFileCharacterAttack? _hbtFileCharacterAttack;
        private string? _validCharsPreview;
        private string? _validStartingCharsPreview;
        #endregion

        #region Properties
        public HbtFileCharacterAttack? HbtFileCharacterAttack
        {
            get => _hbtFileCharacterAttack;
            set
            {
                _hbtFileCharacterAttack = value;
                OnPropertyChanged(nameof(HbtFileCharacterAttack));
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

        public List<CharsetModelView> CharsetsList { get; set; } = Charsets.GetCharsetList();
        public int[] StartPositionList { get; private set; } = ListGenerators.GetIntegerList(0, 30);
        public int[] EndPositionList { get; private set; } = ListGenerators.GetIntegerList(-30, 0).Reverse().ToArray();

        public IRelayCommand CharsetItemCheckedCommand { get; private set; }
        public IRelayCommand ValidCharsChanged { get; private set; }
        public IRelayCommand ValidStartingCharsChanged { get; private set; }
        #endregion

        public HashCrackCharacterTabVM()
        {
            CharsetItemCheckedCommand = new RelayCommand(SaveCharsets);
            ValidCharsChanged = new RelayCommand(RefreshPreview);
            ValidStartingCharsChanged = new RelayCommand(RefreshPreview);
        }

        public void LoadHbtFileCharacter(HbtFileCharacterAttack hbtFileCharacterAttack)
        {
            HbtFileCharacterAttack = hbtFileCharacterAttack;
            LoadCharsets();
            RefreshPreview();
        }

        private void LoadCharsets()
        {
            if (_hbtFileCharacterAttack != null)
            {
                foreach (var charsetItem in CharsetsList)
                {
                    charsetItem.IsChecked = _hbtFileCharacterAttack.Charsets.Any(p => p == charsetItem.Name);
                }

            }
        }

        private void SaveCharsets()
        {
            if (_hbtFileCharacterAttack != null)
            {
                _hbtFileCharacterAttack.Charsets = CharsetsList.Where(p => p.IsChecked).Select(p => p.Name).ToList();
                RefreshPreview();
            }
        }

        private void RefreshPreview()
        {
            if (_hbtFileCharacterAttack != null)
            {
                ValidCharsPreview = Charsets.GetAllValidChars(_hbtFileCharacterAttack.ValidChars, CharsetsList.Where(p => p.IsChecked));
                ValidStartingCharsPreview = Charsets.GetAllValidChars(_hbtFileCharacterAttack.ValidStartingChars, CharsetsList.Where(p => p.IsChecked));
            }
        }
    }
}

using CommunityToolkit.Mvvm.Input;
using HashRelationalResearch.GUI.Helpers;
using HashRelationalResearch.GUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashRelationalResearch.GUI.ViewModels
{
    public class HashCrackHybridTabVM : ViewModelBase
    {
        #region Members
        private HbtFileHybridAttack? _hbtFileHybridAttack;
        private string? _validCharsPreview;
        private string? _validStartingCharsPreview;
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

        public HashCrackHybridTabVM()
        {
            ListGenerators.GetIntegerList(-30, 0);
            CharsetItemCheckedCommand = new RelayCommand(SaveCharsets);
            ValidCharsChanged = new RelayCommand(RefreshPreview);
            ValidStartingCharsChanged = new RelayCommand(RefreshPreview);
        }

        public void LoadHbtFileHybrid(HbtFileHybridAttack hbtFileHybridAttack)
        {
            HbtFileHybridAttack = hbtFileHybridAttack;
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

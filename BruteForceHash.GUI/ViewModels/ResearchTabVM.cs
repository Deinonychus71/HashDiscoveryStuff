using BruteForceHash.GUI.Helpers;
using BruteForceHash.GUI.Models;
using BruteForceHash.GUI.Services.Interfaces;
using BruteForceHash.Helpers;
using CommunityToolkit.Mvvm.Input;
using HashCommon;
using HashRelationalResearch.Models;

namespace BruteForceHash.GUI.ViewModels
{
    public class ResearchTabVM : ViewModelBase
    {
        #region Members
        private const string DEFAULT_TAB_NAME = "Blank";
        private readonly IBruteForceHashService _bruteForceHashService;
        private readonly IHashDBService _hashDBService;
        private readonly IHbtFileService _hbtFileService;
        private readonly IDialogService _dialogService;
        private ResearchNroVM _nroVM;
        private ResearchPrcVM _prcVM;
        private ResearchHashesGridVM _hashesVM;
        private HashCrackVM _hashCrackVM;
        private HbtFile? _hbtFile;

        private string _selectedAttackType = AttackTypes.ATTACK_DICTIONARY;
        private string _tabLabel = DEFAULT_TAB_NAME;
        private string? _hashValue;
        private string? _hashLabel;
        private string? _hashLabelSaved;
        private bool _quickSavePathExists;
        private bool _isValidHash40;
        private bool _isLabelChangedSuccess;
        private bool _isLabelChangedFailure;

        private ExportEntry? _exportEntry;
        #endregion

        #region Properties
        public HbtFile? HbtFile
        {
            get => _hbtFile;
            set
            {
                _hbtFile = value;
                OnPropertyChanged(nameof(HbtFile));
            }
        }

        public ResearchPrcVM NROPRC
        {
            get => _prcVM;
            set
            {
                _prcVM = value;
                OnPropertyChanged(nameof(NROPRC));
            }
        }

        public ResearchNroVM NROVM
        {
            get => _nroVM;
            set
            {
                _nroVM = value;
                OnPropertyChanged(nameof(NROVM));
            }
        }

        public ResearchHashesGridVM HashesVM
        {
            get => _hashesVM;
            set
            {
                _hashesVM = value;
                OnPropertyChanged(nameof(HashesVM));
            }
        }

        public HashCrackVM HackCrackVM
        {
            get => _hashCrackVM;
            set
            {
                _hashCrackVM = value;
                OnPropertyChanged(nameof(HackCrackVM));
            }
        }

        public string? HashValue
        {
            get => _hashValue;
            set
            {
                var valueTemp = value;
                if (valueTemp != null && valueTemp.Length == 11 && valueTemp.StartsWith("0x") && !valueTemp.StartsWith("0x0"))
                    valueTemp = valueTemp.Replace("0x", "0x0");
                _hashValue = valueTemp;
                if (_hbtFile != null)
                    _hbtFile.HexValue = valueTemp ?? string.Empty;
                TabLabel = !string.IsNullOrEmpty(_hashLabel) ? _hashLabel : !string.IsNullOrEmpty(_hashValue) ? _hashValue : DEFAULT_TAB_NAME;
                QuickSaveExists = _hbtFileService.QuickSaveExists(_hbtFile);
                IsValidHash40 = HashHelper.IsValidHash40Value(_hbtFile?.HexValue);
                OnPropertyChanged(nameof(HashValue));
                OnPropertyChanged(nameof(TabLabel));
            }
        }

        public string? HashLabel
        {
            get => _hashLabel;
            set
            {
                _hashLabel = value;
                if (_hbtFile != null)
                    _hbtFile.HexLabel = _hashLabel;
                TabLabel = !string.IsNullOrEmpty(_hashLabel) ? _hashLabel : !string.IsNullOrEmpty(_hashValue) ? _hashValue : DEFAULT_TAB_NAME;
                OnPropertyChanged(nameof(HashLabel));
            }
        }

        public string TabLabel
        {
            get => _tabLabel;
            set
            {
                _tabLabel = value;
                if (string.IsNullOrEmpty(_tabLabel))
                {
                    _tabLabel = DEFAULT_TAB_NAME;
                }
                OnPropertyChanged(nameof(TabLabel));
            }
        }

        public bool IsLabelChangedSuccess
        {
            get => _isLabelChangedSuccess;
            set
            {
                _isLabelChangedSuccess = value;
                OnPropertyChanged(nameof(IsLabelChangedSuccess));
            }
        }

        public bool IsLabelChangedFailure
        {
            get => _isLabelChangedFailure;
            set
            {
                _isLabelChangedFailure = value;
                OnPropertyChanged(nameof(IsLabelChangedFailure));
            }
        }

        public bool IsValidHash40
        {
            get => _isValidHash40;
            set
            {
                _isValidHash40 = value;
                QuickSaveCommand.NotifyCanExecuteChanged();
                OnPropertyChanged(nameof(IsValidHash40));
            }
        }

        public bool QuickSaveExists
        {
            get => _quickSavePathExists;
            set
            {
                _quickSavePathExists = value;
                QuickLoadCommand.NotifyCanExecuteChanged();
                OnPropertyChanged(nameof(QuickSaveExists));
            }
        }

        public string SelectedAttackType
        {
            get => _selectedAttackType;
            set
            {
                _selectedAttackType = value;
                OnPropertyChanged(nameof(SelectedAttackType));
            }
        }

        public string[] AttackTypeList { get; private set; } = ["Dictionary", "Character", "Hybrid"];

        public int[] NbrThreadsList { get; private set; } = ListGenerators.GetIntegerList(1, 64);

        public IRelayCommand SaveLabelCommand { get; private set; }
        public IRelayCommand HashValueChanged { get; private set; }
        public IRelayCommand HashLabelChanged { get; private set; }
        public IRelayCommand AttackTypeChanged { get; private set; }
        public IRelayCommand QuickSaveCommand { get; private set; }
        public IRelayCommand QuickLoadCommand { get; private set; }
        public IRelayCommand StartBruteforceCommand { get; private set; }
        public IRelayCommand StartBruteforceHashcatCommand { get; private set; }
        #endregion

        public ResearchTabVM(IHashDBService hashDBService, IHbtFileService hbtFileService, IDialogService dialogService, ResearchHashesGridVM researchHashesGridVM,
           IBruteForceHashService bruteForceHashService, ResearchNroVM researchNroVM, ResearchPrcVM researchPrcVM, HashCrackVM hashCrackVM)
        {
            _bruteForceHashService = bruteForceHashService;
            _hashesVM = researchHashesGridVM;
            _hashDBService = hashDBService;
            _hbtFileService = hbtFileService;
            _dialogService = dialogService;
            _nroVM = researchNroVM;
            _prcVM = researchPrcVM;
            _hashCrackVM = hashCrackVM;

            QuickSaveCommand = new RelayCommand(QuickSave, () => IsValidHash40);
            QuickLoadCommand = new RelayCommand(QuickLoad, () => QuickSaveExists);
            SaveLabelCommand = new RelayCommand(SaveLabel);
            HashValueChanged = new RelayCommand(LoadNewHash);
            HashLabelChanged = new RelayCommand(TestHashLabel);
            AttackTypeChanged = new RelayCommand(ChangeAttackType);

            StartBruteforceCommand = new RelayCommand(() => StartBruteforce(false));
            StartBruteforceHashcatCommand = new RelayCommand(() => StartBruteforce(true));
        }

        public void LoadHbtFile(HbtFile? hbtFile)
        {
            if (hbtFile != null)
            {
                HbtFile = hbtFile;
                HashLabel = hbtFile.HexLabel;
                HashValue = hbtFile.HexValue;
                _hashCrackVM.LoadHbtFile(hbtFile);
                LoadNewHash();
            }
        }

        private void SaveLabel()
        {
            if (_hbtFile?.HexLabel != null && IsLabelChangedSuccess && HashHelper.IsValidHash40Value(_hbtFile.HexValue))
            {
                if (_hashDBService.AddOrUpdateLabel(_hbtFile.HexValue, _hbtFile.HexLabel))
                {
                    _dialogService.ShowMessage($"Successfully saved '{_hbtFile.HexValue},{_hbtFile.HexLabel}'.");
                    _hashLabelSaved = _hbtFile.HexLabel;
                    _nroVM.RefreshCurrentFunction();
                    TestHashLabel();
                }
                else
                    _dialogService.ShowMessage($"Error saving '{_hbtFile.HexValue},{_hbtFile.HexLabel}'.", true);
            }
        }

        private void ChangeAttackType()
        {
            if (_hbtFile != null)
            {
                SelectedAttackType = _hbtFile.AttackType;
                _hashCrackVM.SetAttackType(_hbtFile.AttackType);
            }
        }

        private void StartBruteforce(bool useHashcat)
        {
            if (_hbtFile != null)
                _bruteForceHashService.StartProcess(_hbtFile, useHashcat);
        }

        private void QuickLoad()
        {
            var quickSaveFilePath = _hbtFileService.GetQuickSaveFilePath(_hbtFile);
            var loadedHbtFile = _hbtFileService.LoadHbrFile(quickSaveFilePath);
            if (loadedHbtFile != null)
                LoadHbtFile(loadedHbtFile);
        }

        private void QuickSave()
        {
            if (_hbtFile != null)
            {
                var quickSaveFile = _hbtFileService.GetQuickSaveFilePath(_hbtFile);
                if (quickSaveFile != null)
                {
                    QuickSaveExists = _hbtFileService.SaveHbrFile(quickSaveFile, _hbtFile);
                }
            }
        }

        private bool CanQuickSave()
        {
            return HashHelper.IsValidHash40Value(HbtFile?.HexValue);
        }

        private void RefreshHash()
        {
            HashLabel = string.Empty;
            _nroVM.ClearData();
            _prcVM.ClearData();

            if (_exportEntry != null)
            {
                var label = _hashDBService.GetLabel(_exportEntry.Hash40Hex);
                if (label != null)
                {
                    _hashLabelSaved = label;
                    HashLabel = label;
                }

                _nroVM.LoadFiles(_exportEntry.CFiles);
                _prcVM.LoadFiles(_exportEntry.PRCFiles);
            }

            if (!string.IsNullOrEmpty(_exportEntry?.Hash40Hex))
                _hashesVM.SetCurrentHash40(_exportEntry.Hash40Hex);
        }

        private void LoadNewHash()
        {
            var hash = _hashValue?.Trim().ToLower();
            if (hash != null && hash.StartsWith("0x"))
                _exportEntry = _hashDBService.GetEntry(hash) ?? null;
            else
                _exportEntry = null;

            _hashCrackVM.RefreshHash();
            RefreshHash();
        }

        private void TestHashLabel()
        {
            if (_hashLabelSaved == _hashLabel)
            {
                IsLabelChangedFailure = false;
                IsLabelChangedSuccess = false;
            }
            else
            {
                var testHash40 = HashHelper.ToHash40(_hashLabel);
                if (testHash40 == _hashValue)
                {
                    IsLabelChangedFailure = false;
                    IsLabelChangedSuccess = true;
                }
                else
                {
                    IsLabelChangedSuccess = false;
                    IsLabelChangedFailure = true;
                }
            }
        }
    }
}

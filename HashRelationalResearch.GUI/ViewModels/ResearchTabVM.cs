using CommunityToolkit.Mvvm.Input;
using HashCommon;
using HashRelationalResearch.GUI.Models;
using HashRelationalResearch.GUI.Services.Interfaces;
using HashRelationalResearch.Models;
using System.Windows.Input;

namespace HashRelationalResearch.GUI.ViewModels
{
    public class ResearchTabVM : ViewModelBase
    {
        #region Members
        private const string DEFAULT_TAB_NAME = "Blank";
        private readonly IHashDBService _hashDBService;
        private readonly IDiscoveryDBService _discoveryDBService;
        private ResearchNroVM _nroVM;
        private ResearchPrcVM _prcVM;
        private HashCrackVM _hashCrackVM;
        private HbtFile? _hbtFile;

        private string _tabLabel = DEFAULT_TAB_NAME;
        private string? _hashValue;
        private string? _hashLabel;
        private string? _hashLabelSaved;
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

        public HashCrackVM HackCrackVM
        {
            get => _hashCrackVM;
            set
            {
                _hashCrackVM = value;
                OnPropertyChanged(nameof(HackCrackVM));
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
                TabLabel = valueTemp ?? DEFAULT_TAB_NAME;
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
                OnPropertyChanged(nameof(HashLabel));
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

        public ICommand SaveLabelCommand { get => new RelayCommand(SaveLabel); }

        public ICommand HashValueChanged { get => new RelayCommand(LoadNewHash); }

        public ICommand HashLabelChanged { get => new RelayCommand(TestHashLabel); }
        #endregion

        public ResearchTabVM(IHashDBService hashDBService, IDiscoveryDBService discoveryDBService,
            ResearchNroVM researchNroVM, ResearchPrcVM researchPrcVM, HashCrackVM hashCrackVM)
        {
            _hashDBService = hashDBService;
            _discoveryDBService = discoveryDBService;
            _nroVM = researchNroVM;
            _prcVM = researchPrcVM;
            _hashCrackVM = hashCrackVM;
        }

        public void LoadHbtFile(HbtFile? hbtFile)
        {
            if (hbtFile != null)
            {
                HbtFile = hbtFile;
                HashLabel = hbtFile.HexLabel;
                HashValue = hbtFile.HexValue;
                _hashCrackVM.LoadHbtFile(hbtFile);
            }
        }

        public void SaveLabel()
        {
            //TODO
        }

        private void RefreshHash()
        {
            HashLabel = string.Empty;
            _nroVM.ClearData();
            _prcVM.ClearData();

            if (_exportEntry != null)
            {
                var label = _exportEntry.Label;
                if (label != null)
                {
                    _hashLabelSaved = label.Label;
                    HashLabel = label.Label;
                }

                _nroVM.LoadFiles(_exportEntry.CFiles);
                _prcVM.LoadFiles(_exportEntry.PRCFiles);
            }
        }

        private void LoadNewHash()
        {
            var hash = _hashValue?.Trim().ToLower();
            if (hash != null && hash.StartsWith("0x"))
                _exportEntry = _hashDBService.GetEntry(hash) ?? null;
            else
                _exportEntry = null;

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

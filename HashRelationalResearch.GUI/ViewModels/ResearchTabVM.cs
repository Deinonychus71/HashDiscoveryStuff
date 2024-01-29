using CommunityToolkit.Mvvm.Input;
using HashCommon;
using HashRelationalResearch.GUI.Helpers;
using HashRelationalResearch.Models;
using System.Windows.Input;

namespace HashRelationalResearch.GUI.ViewModels
{
    public class ResearchTabVM : ViewModelBase
    {
        #region Members
        private ResearchNroVM _nroVM;
        private ResearchPrcVM _prcVM;
        private HashCrackVM _hashCrackVM;

        private string? _hashValue;
        private string? _hashLabel;
        private string? _hashLabelSaved;
        private bool _isLabelChangedSuccess;
        private bool _isLabelChangedFailure;

        private ExportEntry? _exportEntry;
        #endregion

        #region Properties
        public ICommand HashValueChanged { get; }

        public ICommand HashLabelChanged { get; }

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

        public string? HashValue
        {
            get => _hashValue;
            set
            {
                var valueTemp = value;
                if (valueTemp != null && valueTemp.Length == 11 && valueTemp.StartsWith("0x"))
                    valueTemp = valueTemp.Replace("0x", "0x0");
                _hashValue = valueTemp;
                OnPropertyChanged(nameof(HashValue));
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

        public string? HashLabel
        {
            get => _hashLabel;
            set
            {
                _hashLabel = value;
                OnPropertyChanged(nameof(HashLabel));
            }
        }
        #endregion

        public ResearchTabVM()
        {
            _nroVM = new ResearchNroVM();
            _prcVM = new ResearchPrcVM();
            _hashCrackVM = new HashCrackVM();
            HashValueChanged = new RelayCommand(LoadNewHash);
            HashLabelChanged = new RelayCommand(TestHashLabel);
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
                _exportEntry = JSONDB.GetEntry(hash) ?? null;
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

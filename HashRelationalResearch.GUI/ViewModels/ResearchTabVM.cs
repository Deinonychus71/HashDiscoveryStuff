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
        private string? _hashValue;
        private string? _hashLabel;
        private string? _hashLabelSaved;
        private bool _isLabelChangedSuccess;
        private bool _isLabelChangedFailure;
        private string? _codeEditorText;
        private ExportEntry? _exportEntry;
        #endregion

        #region Properties
        public ICommand LoadEntry { get; }

        public ICommand HashValueChanged { get; }

        public ICommand HashLabelChanged { get; }

        public string? HashValue
        {
            get => _hashValue;
            set
            {
                _hashValue = value;
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

        public string? CodeEditorText
        {
            get => _codeEditorText;
            set
            {
                _codeEditorText = value;
                OnPropertyChanged(nameof(CodeEditorText));
            }
        }
        #endregion

        public ResearchTabVM()
        {
            LoadEntry = new RelayCommand<string>((p) => LoggedIn(p));
            HashValueChanged = new RelayCommand(LoadNewHash);
            HashLabelChanged = new RelayCommand(TestHashLabel);
        }

        private void RefreshHash()
        {
            HashLabel = string.Empty;
            CodeEditorText = string.Empty;

            if (_exportEntry != null)
            {
                var label = _exportEntry.Label;
                if (label != null)
                {
                    _hashLabelSaved = label.Label;
                    HashLabel = label.Label;
                }

                var firstFile = _exportEntry.CFiles?.FirstOrDefault();
                if (firstFile != null)
                {
                    var function = JSONDB.GetFunctions(firstFile.File, firstFile.Instances.Select(p => p.FunctionId));
                    CodeEditorText = function[0].Content;
                }
            }
        }

        #region Commands
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

        private void LoggedIn(string parameter)
        {
        }
        #endregion
    }
}

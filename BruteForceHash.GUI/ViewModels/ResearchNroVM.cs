using BruteForceHash.GUI.Helpers;
using BruteForceHash.GUI.Services.Interfaces;
using CommunityToolkit.Mvvm.Input;
using HashRelationalResearch.Models;
using System.Collections.Generic;
using System.Linq;

namespace BruteForceHash.GUI.ViewModels
{
    public class ResearchNroVM : ViewModelBase
    {
        #region Members
        private readonly IHashDBService _hashDBService;

        private string? _codeEditorText;
        private bool _shouldDisplayKnownLabels;
        private ExportCFileEntry? _selectedCFileEntry;
        private ExportFunctionEntry? _selectedCFunctionEntry;
        #endregion

        #region Properties
        public string? CodeEditorText
        {
            get => _codeEditorText;
            set
            {
                _codeEditorText = value;
                OnPropertyChanged(nameof(CodeEditorText));
            }
        }

        public bool ShouldDisplayKnownLabels
        {
            get => _shouldDisplayKnownLabels;
            set
            {
                _shouldDisplayKnownLabels = value;
                OnPropertyChanged(nameof(ShouldDisplayKnownLabels));
            }
        }

        public ExportCFileEntry? SelectedCFileEntry
        {
            get => _selectedCFileEntry;
            set
            {
                _selectedCFileEntry = value;
                OnPropertyChanged(nameof(SelectedCFileEntry));
            }
        }

        public ExportFunctionEntry? SelectedCFunctionEntry
        {
            get => _selectedCFunctionEntry;
            set
            {
                _selectedCFunctionEntry = value;
                OnPropertyChanged(nameof(SelectedCFunctionEntry));
            }
        }

        public WpfObservableRangeCollection<ExportCFileEntry> CFileEntries { get; set; }

        public WpfObservableRangeCollection<ExportFunctionEntry> CFunctionEntries { get; set; }

        public IRelayCommand CFileSelected { get; }
        public IRelayCommand CFunctionSelected { get; }
        #endregion

        public ResearchNroVM(IHashDBService hashDBService)
        {
            _hashDBService = hashDBService;
            CFileEntries = [];
            CFunctionEntries = [];
            CFileSelected = new RelayCommand(LoadFunctionInstances);
            CFunctionSelected = new RelayCommand<ExportFunctionEntry?>(LoadFunction);
            ShouldDisplayKnownLabels = true;
        }

        public void ClearData()
        {
            SelectedCFileEntry = null;
            SelectedCFunctionEntry = null;
            CFileEntries.Clear();
            CFunctionEntries.Clear();
            CodeEditorText = string.Empty;
        }

        public void LoadFiles(List<ExportCFileEntry>? cFiles)
        {
            if (cFiles != null && cFiles.Count > 0)
            {
                CFileEntries.AddRange(cFiles);
                SelectedCFileEntry = CFileEntries.First();
                LoadFunctionInstances();
            }
        }

        public void RefreshCurrentFunction()
        {
            LoadFunction(SelectedCFunctionEntry);
        }

        private void LoadFunctionInstances()
        {
            if (_selectedCFileEntry != null)
            {
                CFunctionEntries.Clear();
                var functions = _hashDBService.GetFunctions(_selectedCFileEntry.File, _selectedCFileEntry.Instances.Select(p => p.FunctionId).Distinct());
                CFunctionEntries.AddRange(functions);
                var firstCFunction = CFunctionEntries.First();
                SelectedCFunctionEntry = firstCFunction;
                LoadFunction(firstCFunction);
            }
        }

        private void LoadFunction(ExportFunctionEntry? cFunctionEntry)
        {
            if (cFunctionEntry != null)
            {
                if (ShouldDisplayKnownLabels)
                {
                    var content = cFunctionEntry.Content;
                    foreach (var hash40 in cFunctionEntry.Hashes)
                    {
                        var label = _hashDBService.GetLabel(hash40);
                        if (label != null)
                            content = content.Replace(hash40.Replace("0x0", "0x"), $"\"{label}\"");
                    }
                    CodeEditorText = content;
                }
                else
                {
                    CodeEditorText = cFunctionEntry.Content;
                }
            }
        }
    }
}

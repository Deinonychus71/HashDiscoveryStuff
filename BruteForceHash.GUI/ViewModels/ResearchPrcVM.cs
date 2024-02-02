using BruteForceHash.GUI.Helpers;
using BruteForceHash.GUI.Services.Interfaces;
using CommunityToolkit.Mvvm.Input;
using HashRelationalResearch.Models;
using paracobNET;
using prcEditor.Windows;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Threading;

namespace BruteForceHash.GUI.ViewModels
{
    public class ResearchPrcVM : ViewModelBase
    {
        #region Members
        private readonly IConfigurationService _configurationService;
        private string? _loadedPrcFile;
        private ExportPRCFileEntry? _selectedPrcFileEntry;
        private ParamControl? _prcFile;
        #endregion

        #region Properties
        public ExportPRCFileEntry? SelectedPrcFileEntry
        {
            get => _selectedPrcFileEntry;
            set
            {
                _selectedPrcFileEntry = value;
                OnPropertyChanged(nameof(SelectedPrcFileEntry));
            }
        }

        public ParamControl? PRCFile
        {
            get => _prcFile;
            set
            {
                _prcFile = value;
                OnPropertyChanged(nameof(PRCFile));
            }
        }

        public WpfObservableRangeCollection<ExportPRCFileEntry> PrcFileEntries { get; set; }

        public IRelayCommand PrcFileSelected { get; }
        #endregion

        public ResearchPrcVM(IConfigurationService configurationService)
        {
            _configurationService = configurationService;
            PrcFileEntries = [];
            PrcFileSelected = new RelayCommand<string?>(LoadPRCFile);
        }

        public void ClearData()
        {
            _loadedPrcFile = null;
            SelectedPrcFileEntry = null;
            PRCFile = null;
            PrcFileEntries.Clear();
        }

        public void LoadFiles(List<ExportPRCFileEntry>? prcFiles)
        {
            if (prcFiles != null && prcFiles.Count > 0)
            {
                PrcFileEntries.AddRange(prcFiles);
                var firstPrcFile = prcFiles.First();
                SelectedPrcFileEntry = firstPrcFile;
                LoadPRCFile(firstPrcFile.File);
            }
        }

        public void LoadPRCFile(string? prcFile)
        {
            if (prcFile != null && _loadedPrcFile != prcFile)
            {
                var t = new ParamFile();
                var file = prcFile;
                if (file.StartsWith('/'))
                    file = file[1..];
                var filePath = Path.Combine(_configurationService.PrcRootPath, file.Replace('/', Path.DirectorySeparatorChar));
                if (File.Exists(filePath))
                {
                    t.Open(filePath);
                    PRCFile = new ParamControl(t.Root);
                    Dispatcher.CurrentDispatcher.BeginInvoke(() =>
                    {
                        if (PRCFile.FindName("Param_TreeView") is TreeView treeView)
                        {
                            foreach (var item in treeView.Items)
                            {
                                var childControl = treeView.ItemContainerGenerator.ContainerFromItem(item);
                                if (childControl != null)
                                {
                                    if (childControl is TreeViewItem treeViewItem)
                                    {
                                        treeViewItem.IsExpanded = true;
                                        //Do further expanding
                                    }
                                }
                            }
                        }
                    });
                    _loadedPrcFile = prcFile;
                }
            }
        }
    }
}

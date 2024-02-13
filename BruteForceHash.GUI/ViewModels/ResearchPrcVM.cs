using BruteForceHash.GUI.Helpers;
using BruteForceHash.GUI.Services.Interfaces;
using CommunityToolkit.Mvvm.Input;
using HashRelationalResearch.Models;
using paracobNET;
using prcEditor.Windows;
using System.Collections.Concurrent;
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
        private ExportPRCFileEntry? _selectedPrcFileEntry;
        private ParamControl? _prcFile;
        private ConcurrentDictionary<string, ParamControl> _cachedPrcFiles;
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
        public IRelayCommand PrcFileLoaded { get; }
        #endregion

        public ResearchPrcVM(IConfigurationService configurationService)
        {
            _cachedPrcFiles = new ConcurrentDictionary<string, ParamControl>();
            _configurationService = configurationService;
            PrcFileEntries = [];
            PrcFileSelected = new RelayCommand<string?>(LoadPRCFile);
            //PrcFileLoaded = new RelayCommand(ExpandPRCFile);
        }

        public void ClearData()
        {
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
            if (prcFile != null)
            {
                var file = prcFile;
                if (file.StartsWith('/'))
                    file = file[1..];
                var filePath = Path.Combine(_configurationService.PrcRootPath, file.Replace('/', Path.DirectorySeparatorChar));
                if (File.Exists(filePath))
                {
                    if (_cachedPrcFiles.TryGetValue(filePath, out ParamControl? prcControl))
                    {
                        PRCFile = prcControl;
                    }
                    else
                    {
                        Dispatcher.CurrentDispatcher.BeginInvoke(() =>
                        {
                            var t = new ParamFile();
                            t.Open(filePath);
                            var paramControl = new ParamControl(t.Root);
                            paramControl.Loaded += ExpandPRCFile;
                            _cachedPrcFiles.TryAdd(filePath, paramControl);
                            PRCFile = paramControl;
                        });
                    }
                }
            }
        }

        private void ExpandPRCFile(object sender, System.Windows.RoutedEventArgs e)
        {
            if (sender is ParamControl paramControl)
            {
                if (paramControl.FindName("Param_TreeView") is TreeView treeView)
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
                paramControl.Loaded -= ExpandPRCFile;
            }
        }
    }
}

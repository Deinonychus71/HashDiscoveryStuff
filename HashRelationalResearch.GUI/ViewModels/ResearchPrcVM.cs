using CommunityToolkit.Mvvm.Input;
using HashRelationalResearch.GUI.Helpers;
using HashRelationalResearch.Models;
using paracobNET;
using prcEditor.Windows;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace HashRelationalResearch.GUI.ViewModels
{
    public class ResearchPrcVM : ViewModelBase
    {
        #region Members
        private ExportPRCFileEntry? _selectedPrcFileEntry;
        private ParamControl? _prcFile;
        #endregion

        #region Properties
        public ICommand PrcFileSelected { get; }

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
        #endregion

        public ResearchPrcVM()
        {
            PrcFileEntries = [];
            PrcFileSelected = new RelayCommand(LoadPRCFile);
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
                SelectedPrcFileEntry = prcFiles.First();
            }
        }

        public void LoadPRCFile()
        {
            if (_selectedPrcFileEntry != null)
            {
                var t = new ParamFile();
                var file = _selectedPrcFileEntry.File;
                if (file.StartsWith("/"))
                    file = file.Substring(1);
                t.Open(Path.Combine("C:\\Users\\deihn\\Desktop\\bruteforcepublish\\smash13.1", file.Replace('/', Path.DirectorySeparatorChar)));
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
                                var treeViewItem = childControl as TreeViewItem;
                                if (treeViewItem != null)
                                {
                                    treeViewItem.IsExpanded = true;
                                    //Do further expanding
                                }
                            }
                        }
                    }
                });

            }
        }
    }
}

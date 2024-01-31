using CommunityToolkit.Mvvm.Input;
using HashRelationalResearch.GUI.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Threading;

namespace HashRelationalResearch.GUI.ViewModels
{
    public class MainWindowVM : ViewModelBase
    {
        #region Members
        private readonly IServiceProvider _serviceProvider;
        private readonly IHashDBService _hashDBService;
        private readonly IConfigurationService _configurationService;
        private readonly IBruteForceHashService _bruteForceHasService;
        private readonly IDictionaryService _dictionaryService;
        private readonly IHbtFileService _hbtFileService;
        private readonly IDialogService _dialogService;
        private ResearchTabVM _selectedResearchTab;
        private bool _selectedChangedAfterAdd = true;
        #endregion

        #region Properties
        public ObservableCollection<ResearchTabVM> ResearchTabs { get; set; }

        public ResearchTabVM SelectedResearchTab
        {
            get => _selectedResearchTab;
            set
            {
                _selectedResearchTab = value;
                OnPropertyChanged(nameof(SelectedResearchTab));
            }
        }

        public IRelayCommand ExitApplicationCommand { get; private set; }
        public IRelayCommand NewResearchTabCommand { get; private set; }
        public IRelayCommand RemoveResearchTabCommand { get; private set; }
        public IRelayCommand PickHashDBFileCommand { get; private set; }
        public IRelayCommand PickHashcatFileCommand { get; private set; }
        public IRelayCommand PickPRCRootFolderCommand { get; private set; }
        public IRelayCommand PickDiscoveryFolderCommand { get; private set; }
        public IRelayCommand SaveFileCommand { get; private set; }
        public IRelayCommand LoadFileCommand { get; private set; }
        public IRelayCommand CleanHashFolderCommand { get; private set; }
        public IRelayCommand RefreshDictionariesCommand { get; private set; }
        public IRelayCommand PrintLastCommandCommand { get; private set; }
        #endregion

        public MainWindowVM(IServiceProvider serviceProvider, IHashDBService hashDBService, IHbtFileService hbtFileService, IBruteForceHashService bruteForceHasService,
            IDialogService dialogService, IDictionaryService dictionaryService, IConfigurationService configurationService)
        {
            _serviceProvider = serviceProvider;
            _hashDBService = hashDBService;
            _configurationService = configurationService;
            _hbtFileService = hbtFileService;
            _dialogService = dialogService;
            _bruteForceHasService = bruteForceHasService;
            _dictionaryService = dictionaryService;


            ExitApplicationCommand = new RelayCommand(Application.Current.Shutdown);
            NewResearchTabCommand = new RelayCommand<string?>((s) => { if (s == "NEW") NewResearchTab(); });
            RemoveResearchTabCommand = new RelayCommand<ResearchTabVM?>(RemoveResearchTab);
            PickHashDBFileCommand = new RelayCommand(PickHashDBFile);
            PickHashcatFileCommand = new RelayCommand(PickHashcatFile);
            PickPRCRootFolderCommand = new RelayCommand(PickPRCRootFolder);
            PickDiscoveryFolderCommand = new RelayCommand(PickDiscoveryFolder);
            SaveFileCommand = new RelayCommand(SaveFile);
            LoadFileCommand = new RelayCommand(LoadFile);
            CleanHashFolderCommand = new RelayCommand(CleanHashFolder);
            RefreshDictionariesCommand = new RelayCommand(RefreshDictionaries);
            PrintLastCommandCommand = new RelayCommand(PrintLastCommand);

            var hbtFiles = hbtFileService.LoadHbtWorkspace();
            if (hbtFiles != null && hbtFiles.Any())
            {
                var listVMToLoad = new List<ResearchTabVM>();
                foreach (var hbtFile in hbtFiles)
                {
                    var researchTabVM = _serviceProvider.GetRequiredService<ResearchTabVM>();
                    researchTabVM.LoadHbtFile(hbtFile);
                    listVMToLoad.Add(researchTabVM);
                }
                ResearchTabs = new ObservableCollection<ResearchTabVM>(listVMToLoad);
            }
            else
            {
                ResearchTabs = [_serviceProvider.GetRequiredService<ResearchTabVM>()];
            }
            _selectedResearchTab = ResearchTabs.First();
        }

        public void NewResearchTab()
        {
            if (_selectedChangedAfterAdd)
            {
                _selectedChangedAfterAdd = false;
                Dispatcher.CurrentDispatcher.BeginInvoke(() =>
                {
                    var newResearchTabVM = _serviceProvider.GetRequiredService<ResearchTabVM>();
                    ResearchTabs.Add(newResearchTabVM);
                    SelectedResearchTab = newResearchTabVM;
                    newResearchTabVM.LoadHbtFile(_hbtFileService.NewHbrFile());
                    _selectedChangedAfterAdd = true;
                });
            }
        }

        public void RemoveResearchTab(ResearchTabVM? researchTabVM)
        {
            if (researchTabVM != null && ResearchTabs.Count > 1)
            {
                ResearchTabs.Remove(researchTabVM);
            }
        }

        public void RefreshDictionaries()
        {
            if (ResearchTabs != null)
            {
                _dictionaryService.RefreshDictionaries();
                foreach (var researchTabs in ResearchTabs)
                {
                    researchTabs.LoadHbtFile(researchTabs.HbtFile);
                }
            }
        }

        private void PrintLastCommand()
        {
            if (!string.IsNullOrEmpty(_bruteForceHasService.LastCommand))
                _dialogService.ShowMessage(_bruteForceHasService.LastCommand);
            else
                _dialogService.ShowMessage("Please run an attack first");
        }

        #region File Manipulation
        public void SaveWorkspace()
        {
            var hbtFiles = ResearchTabs.Select(p => p.HbtFile);
            _hbtFileService.SaveHbtWorkspace(hbtFiles);
        }

        private void SaveFile()
        {
            var label = _selectedResearchTab?.HashValue ?? "research";
            var filePath = _dialogService.SaveFileDialog(Helpers.FileTypes.Hbt, label, Helpers.FileTypes.Hbt);
            if (!string.IsNullOrEmpty(filePath) && SelectedResearchTab?.HbtFile != null)
            {
                _hbtFileService.SaveHbrFile(filePath, SelectedResearchTab.HbtFile);
            }
        }

        private void LoadFile()
        {
            var label = _selectedResearchTab?.HashValue ?? "research";
            var filePath = _dialogService.OpenFileDialog(Helpers.FileTypes.Hbt, label, Helpers.FileTypes.Hbt);
            if (!string.IsNullOrEmpty(filePath))
            {
                var hbtFile = _hbtFileService.LoadHbrFile(filePath);
                SelectedResearchTab.LoadHbtFile(hbtFile);
            }
        }

        private void PickHashDBFile()
        {
            var filePath = _dialogService.OpenFileDialog(Helpers.FileTypes.Json | Helpers.FileTypes.Bin, "db", Helpers.FileTypes.Bin);
            if (filePath != null && _configurationService.HashDBFilePath != filePath && File.Exists(filePath))
            {
                _configurationService.HashDBFilePath = filePath;
                _hashDBService.LoadHashDBFile(filePath);
                _configurationService.SaveGlobalConfiguration();
                _dialogService.ShowMessage($"HashDB File loaded: '{filePath}'");
            }
        }

        private void PickHashcatFile()
        {
            var filePath = _dialogService.OpenFileDialog(Helpers.FileTypes.Exe, "hashcat", Helpers.FileTypes.Exe);
            if (filePath != null && _configurationService.HashcatFilePath != filePath && File.Exists(filePath))
            {
                _configurationService.HashcatFilePath = filePath;
                _configurationService.SaveGlobalConfiguration();
                _dialogService.ShowMessage($"Hashcat Path loaded: '{filePath}'");
            }
        }

        private void PickPRCRootFolder()
        {
            var folderPath = _dialogService.OpenFolderDialog();
            if (folderPath != null && _configurationService.PrcRootPath != folderPath)
            {
                _configurationService.PrcRootPath = folderPath;
                _configurationService.SaveGlobalConfiguration();
                _dialogService.ShowMessage($"PRC Root Folder loaded: '{folderPath}'");
            }
        }

        private void PickDiscoveryFolder()
        {
            var folderPath = _dialogService.OpenFolderDialog();
            if (folderPath != null && _configurationService.DiscoveredHashesPath != folderPath)
            {
                _configurationService.DiscoveredHashesPath = folderPath;
                _configurationService.SaveGlobalConfiguration();
                _dialogService.ShowMessage($"Discovery Folder loaded: '{folderPath}'");
            }
        }

        public void CleanHashFolder()
        {
            var hbtFile = SelectedResearchTab?.HbtFile;
            var hash40 = hbtFile?.HexValue;
            var hexPath = _hbtFileService.GetQuickDirectoryPath(hbtFile);
            if (!string.IsNullOrEmpty(hexPath) && !string.IsNullOrEmpty(hash40))
            {
                if (_dialogService.ShowYesNoQuestion($"Are you sure you wish to clean folder '{hexPath}'"))
                {
                    _hbtFileService.DeleteQuickDirectory(hbtFile);
                }
            }
            else
            {
                _dialogService.ShowMessage($"The quick path '{hexPath}' doesn't exist.");
            }
        }
        #endregion
    }
}

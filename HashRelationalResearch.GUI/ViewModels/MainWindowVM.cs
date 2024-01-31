using CommunityToolkit.Mvvm.Input;
using HashRelationalResearch.GUI.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace HashRelationalResearch.GUI.ViewModels
{
    public class MainWindowVM : ViewModelBase
    {
        #region Members
        private readonly IServiceProvider _serviceProvider;
        private readonly IHashDBService _hashDBService;
        private readonly IConfigurationService _configurationService;
        private readonly IDictionaryService _dictionaryService;
        private readonly IHbtFileService _hbtFileService;
        private readonly IDialogService _dialogService;
        private ResearchTabVM _selectedResearchTab;
        private bool _selectedChangedAfterAdd = true;
        #endregion

        #region Properties
        public static ICommand ExitApplicationCommand { get => new RelayCommand(Application.Current.Shutdown); }
        public ICommand NewResearchTabCommand { get => new RelayCommand<string?>((s) => { if (s == "NEW") NewResearchTab(); }); }
        public ICommand RemoveResearchTabCommand { get => new RelayCommand<ResearchTabVM?>(RemoveResearchTab); }
        public ICommand PickHashDBFileCommand { get => new RelayCommand(PickHashDBFile); }
        public ICommand PickPRCRootFolderCommand { get => new RelayCommand(PickPRCRootFolder); }
        public ICommand PickHashcatFolderCommand { get => new RelayCommand(PickHashcatFile); }
        public ICommand SaveFileCommand { get => new RelayCommand(SaveFile); }
        public ICommand LoadFileCommand { get => new RelayCommand(LoadFile); }
        public ICommand CleanHashFolderCommand { get => new RelayCommand(CleanHashFolder); }
        public ICommand RefreshDictionariesCommand { get => new RelayCommand(RefreshDictionaries); }

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
        #endregion

        public MainWindowVM(IServiceProvider serviceProvider, IHashDBService hashDBService, IHbtFileService hbtFileService,
            IDialogService dialogService, IDictionaryService dictionaryService, IConfigurationService configurationService,
            ResearchTabVM researchTabVM)
        {
            _serviceProvider = serviceProvider;
            _hashDBService = hashDBService;
            _configurationService = configurationService;
            _hbtFileService = hbtFileService;
            _dialogService = dialogService;
            _dictionaryService = dictionaryService;
            _selectedResearchTab = researchTabVM;
            researchTabVM.LoadHbtFile(hbtFileService.NewHbrFile());
            ResearchTabs = [researchTabVM];
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
            if (researchTabVM != null && SelectedResearchTab != researchTabVM)
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

        #region File Manipulation
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
            var filePath = _dialogService.OpenFileDialog(Helpers.FileTypes.Json | Helpers.FileTypes.Bin, "db", Helpers.FileTypes.Json);
            if (filePath != null && _configurationService.HashDBFilePath != filePath)
            {
                _configurationService.HashDBFilePath = filePath;
                _configurationService.SaveGlobalConfiguration();
                _hashDBService.LoadHashDBFile(filePath);
                _dialogService.ShowMessage($"HashDB loaded: '{filePath}'");
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

        public void CleanHashFolder()
        {
            var hbtFile = SelectedResearchTab?.HbtFile;
            var hash40 = hbtFile?.HexValue;
            var hexPath = _hbtFileService.GetQuickDirectory(hbtFile);
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

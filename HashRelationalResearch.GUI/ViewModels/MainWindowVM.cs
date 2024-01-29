using CommunityToolkit.Mvvm.Input;
using HashRelationalResearch.GUI.Controls;
using HashRelationalResearch.GUI.Helpers;
using HashRelationalResearch.GUI.Services;
using HashRelationalResearch.GUI.Services.Interfaces;
using HashRelationalResearch.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
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
        private ResearchTabVM _selectedResearchTab;
        private bool _selectedChangedAfterAdd = true;
        #endregion

        #region Properties
        public static ICommand ExitApplicationCommand { get => new RelayCommand(Application.Current.Shutdown); }
        public ICommand NewResearchTabCommand { get => new RelayCommand<string?>((s) => { if (s == "NEW") NewResearchTab(); }); }
        public ICommand RemoveResearchTabCommand { get => new RelayCommand<ResearchTabVM?>(RemoveResearchTab); }
        public ICommand PickHashDBFileCommand { get => new RelayCommand<string>(PickHashDBFile, CanOpenFile); }
        public ICommand PickPRCRootFolderCommand { get => new RelayCommand<string>(PickPRCRootFolder, CanOpenFolder); }
        public ICommand PickHashcatFolderCommand { get => new RelayCommand<string>(PickHashcatFolder, CanOpenFolder); }

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

        public MainWindowVM(IServiceProvider serviceProvider, IHashDBService hashDBService, IConfigurationService configurationService,
            ResearchTabVM researchTabVM)
        {
            _serviceProvider = serviceProvider;
            _hashDBService = hashDBService;
            _configurationService = configurationService;
            _selectedResearchTab = researchTabVM;
            ResearchTabs = [researchTabVM];

            //OpenHashDBFile(_configurationService.HashDBFilePath);
        }

        public void NewResearchTab()
        {
            if (_selectedChangedAfterAdd)
            {
                _selectedChangedAfterAdd = false;
                Dispatcher.CurrentDispatcher.BeginInvoke(() =>
                {
                    ResearchTabs.Add(_serviceProvider.GetRequiredService<ResearchTabVM>());
                    SelectedResearchTab = ResearchTabs.Last();
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

        #region File Manipulation
        private void OpenHashDBFile(string? filePath)
        {
            if (filePath != null && File.Exists(filePath))
                _hashDBService.Init(filePath);
        }

        private void PickHashDBFile(string? filePath)
        {
            if (filePath != null && _configurationService.HashDBFilePath != filePath)
            {
                _configurationService.HashDBFilePath = filePath;
                _configurationService.SaveGlobalConfiguration();
                OpenHashDBFile(filePath);
            }
        }

        private void PickPRCRootFolder(string? folderPath)
        {
            if (folderPath != null && _configurationService.PrcRootPath != folderPath)
            {
                _configurationService.PrcRootPath = folderPath;
                _configurationService.SaveGlobalConfiguration();
            }
        }

        private void PickHashcatFolder(string? folderPath)
        {
            if (folderPath != null && _configurationService.HashcatPath != folderPath)
            {
                _configurationService.HashcatPath = folderPath;
                _configurationService.SaveGlobalConfiguration();
            }
        }

        private bool CanOpenFile(string? filePath)
        {
            return filePath != null && File.Exists(filePath);
        }

        private bool CanOpenFolder(string? folderPath)
        {
            return folderPath != null && Path.Exists(folderPath);
        }
        #endregion
    }
}

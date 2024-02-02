using BruteForceHash.GUI.Models;
using BruteForceHash.GUI.Services.Interfaces;
using CommunityToolkit.Mvvm.Input;
using HashRelationalResearch.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace BruteForceHash.GUI.ViewModels
{
    public class ResearchHashesGridVM : ViewModelBase
    {
        #region Members
        private readonly IHashDBService _hashDBService;
        private readonly IBlacklistService _blacklistService;
        private readonly IDialogService _dialogService;

        private string _sourceType;
        private string? _currentHash40;
        private bool _shouldShowSuspicious = false;
        private bool _shouldOnlyShowRelated = false;
        #endregion

        #region Properties
        public ObservableCollection<ResearchHashItemView> Items { get; private set; } = [];

        public string SourceType
        {
            get => _sourceType;
            set
            {
                _sourceType = value;
                OnPropertyChanged(nameof(SourceType));
            }
        }

        public bool ShouldShowSuspicious
        {
            get => _shouldShowSuspicious;
            set
            {
                _shouldShowSuspicious = value;
                OnPropertyChanged(nameof(ShouldShowSuspicious));
            }
        }

        public bool ShouldOnlyShowRelated
        {
            get => _shouldOnlyShowRelated;
            set
            {
                _shouldOnlyShowRelated = value;
                OnPropertyChanged(nameof(ShouldOnlyShowRelated));
            }
        }

        public ListItem<string>[] SourceList { get; set; } = [new ListItem<string>("All", "all"), new ListItem<string>("PRC & NRO", "prc_nro"), new ListItem<string>("PRC Only", "prc"), new ListItem<string>("NRO Only", "nro")];

        public IRelayCommand BlacklistClickedCommand { get; private set; }
        public IRelayCommand ReloadCommand { get; private set; }
        #endregion

        public ResearchHashesGridVM(IHashDBService hashDBService, IBlacklistService blacklistService, IDialogService dialogService)
        {
            _hashDBService = hashDBService;
            _blacklistService = blacklistService;
            _dialogService = dialogService;
            _sourceType = "all";

            BlacklistClickedCommand = new RelayCommand<ResearchHashItemView?>(WriteToBlacklist);
            ReloadCommand = new RelayCommand(LoadList);

            LoadList();

        }

        public void SetCurrentHash40(string hash40)
        {
            _currentHash40 = hash40;
            if (ShouldOnlyShowRelated)
                LoadList();
        }

        public void LoadList()
        {
            Items.Clear();

            IEnumerable<ExportEntry> entries;
            if (ShouldOnlyShowRelated)
            {
                if (!string.IsNullOrEmpty(_currentHash40))
                    entries = _hashDBService.GetEntriesRelatedToHash(_currentHash40);
                else
                    entries = new List<ExportEntry>();
            }
            else
                entries = _hashDBService.GetUncrackedEntries();

            foreach (var entry in entries)
            {
                if (!ShouldShowSuspicious && entry.SuspiciousHex)
                    continue;

                if (SourceType == "prc" && entry.PRCFiles.Count == 0)
                    continue;

                if (SourceType == "nro" && entry.CFiles.Count == 0)
                    continue;

                if (SourceType == "prc_nro" && (entry.CFiles.Count == 0 || entry.PRCFiles.Count == 0))
                    continue;

                var prcFile = entry.PRCFiles.FirstOrDefault();
                var type = prcFile?.Type;
                var prcFileName = prcFile?.File;
                if (entry.PRCFiles.Count > 1)
                    prcFileName += $" ({entry.PRCFiles.Count} files)";

                var cFileName = entry.CFiles.FirstOrDefault()?.File;
                if (entry.CFiles.Count > 1)
                    cFileName += $" ({entry.CFiles.Count} files)";

                string? label = null;
                if (ShouldOnlyShowRelated)
                    label = _hashDBService.GetLabel(entry.Hash40Hex);

                Items.Add(new ResearchHashItemView(entry.Hash40Hex, label, type, cFileName, prcFileName, entry.SuspiciousHex));
            }
        }

        private void WriteToBlacklist(ResearchHashItemView? researchHashItem)
        {
            if (!string.IsNullOrEmpty(researchHashItem?.Hash40))
            {
                if (_dialogService.ShowYesNoQuestion($"Do you want to put '{researchHashItem.Hash40} in the blacklist?"))
                {
                    _blacklistService.AddToBlackList(researchHashItem.Hash40);
                    _dialogService.ShowMessage($"'{researchHashItem.Hash40}' was added to the blacklist.");
                    Items.Remove(researchHashItem);
                }
            }
        }
    }
}

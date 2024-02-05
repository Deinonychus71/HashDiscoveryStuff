using BruteForceHash.GUI.Helpers;
using BruteForceHash.GUI.Models;
using BruteForceHash.GUI.Services.Interfaces;
using CommunityToolkit.Mvvm.Input;
using HashRelationalResearch.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BruteForceHash.GUI.ViewModels
{
    public class ResearchHashesGridVM : ViewModelBase
    {
        #region Members
        private readonly IHashDBService _hashDBService;
        private readonly IBlacklistService _blacklistService;
        private readonly IDialogService _dialogService;

        private string? _cacheSourceType;
        private string? _cacheCurrentHash40;
        private bool _cacheShouldShowSuspicious;
        private bool _cacheShouldOnlyShowRelated;

        private string _sourceType;
        private string _hashesInfo = string.Empty;
        private int _knownHashes = 0;
        private string? _currentHash40;
        private bool _shouldShowSuspicious = false;
        private bool _shouldOnlyShowRelated = false;
        private bool _shouldAutoRefresh = true;
        #endregion

        #region Properties
        public WpfObservableRangeCollection<ResearchHashItemView> Items { get; private set; } = [];

        public string HashesInfo
        {
            get => _hashesInfo;
            set
            {
                _hashesInfo = value;
                OnPropertyChanged(nameof(HashesInfo));
            }
        }

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

        public bool ShouldAutoRefresh
        {
            get => _shouldAutoRefresh;
            set
            {
                _shouldAutoRefresh = value;
                OnPropertyChanged(nameof(ShouldAutoRefresh));
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
            ReloadCommand = new RelayCommand(RefreshList);

            RefreshList();

        }

        public void SetCurrentHash40(string hash40)
        {
            _currentHash40 = hash40;
            if (ShouldOnlyShowRelated)
                RefreshList();
            else
            {
                Task.Run(() =>
                {
                    _hashDBService.GetEntriesRelatedToHash(hash40);
                });
            }
        }

        public void RefreshList()
        {
            if (ShouldAutoRefresh || Items.Count == 0)
            {
                _cacheSourceType = SourceType;
                _cacheCurrentHash40 = _currentHash40;
                _cacheShouldOnlyShowRelated = ShouldOnlyShowRelated;
                _cacheShouldShowSuspicious = ShouldShowSuspicious;
            }

            Items.Clear();

            IEnumerable<ExportEntry> entries;
            if (_cacheShouldOnlyShowRelated)
            {
                if (!string.IsNullOrEmpty(_cacheCurrentHash40))
                    entries = _hashDBService.GetEntriesRelatedToHash(_cacheCurrentHash40);
                else
                    entries = new List<ExportEntry>();
            }
            else
                entries = _hashDBService.GetUncrackedEntries();

            _knownHashes = 0;
            var items = new List<ResearchHashItemView>();
            foreach (var entry in entries)
            {
                if (!_cacheShouldShowSuspicious && entry.SuspiciousHex)
                    continue;

                if (entry.PRCFiles.Count == 0 && _cacheSourceType == "prc")
                    continue;

                if (entry.CFiles.Count == 0 && _cacheSourceType == "nro")
                    continue;

                if ((entry.CFiles.Count == 0 || entry.PRCFiles.Count == 0) && _cacheSourceType == "prc_nro")
                    continue;

                string? prcType = null;
                string? prcPath = null;
                string? prcFileName = null;
                var prcFile = entry.PRCFiles.FirstOrDefault();
                if (prcFile != null)
                {
                    prcType = prcFile.Type;
                    prcPath = prcFile.Path;
                    if (entry.PRCFiles.Count > 1)
                        prcFileName += $"{prcFile.File} ({entry.PRCFiles.Count} files)";
                    else
                        prcFileName = prcFile.File;
                }

                string? cFileName = null;
                var cFile = entry.CFiles.FirstOrDefault();
                if (cFile != null)
                {
                    var cFileLine = cFile.Instances.FirstOrDefault()?.FileLine;
                    if (entry.CFiles.Count > 1)
                        cFileName = $"{cFile.File}:{cFileLine} ({entry.CFiles.Count} files)";
                    else
                        cFileName = $"{cFile.File}:{cFileLine}";
                }

                string? label = null;
                if (_cacheShouldOnlyShowRelated)
                {
                    label = _hashDBService.GetLabel(entry.Hash40Hex);
                    if (!string.IsNullOrEmpty(label))
                        _knownHashes++;
                }

                items.Add(new ResearchHashItemView(entry.Hash40Hex, label, prcType, cFileName, prcFileName, prcPath, entry.SuspiciousHex));
            }

            Items.AddRange(items);

            UpdateHashesInfo();
        }

        private void UpdateHashesInfo()
        {
            if (_cacheShouldOnlyShowRelated)
                HashesInfo = $"{_knownHashes}/{Items.Count} hashes known";
            else
                HashesInfo = $"{Items.Count} hashes";
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
                    UpdateHashesInfo();
                }
            }
        }
    }
}

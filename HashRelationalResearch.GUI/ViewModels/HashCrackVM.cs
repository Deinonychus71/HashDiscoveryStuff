using CommunityToolkit.Mvvm.Input;
using HashCommon;
using HashRelationalResearch.GUI.Models;
using HashRelationalResearch.GUI.Services.Interfaces;
using System.IO;
using System.Linq;
using System.Windows.Input;

namespace HashRelationalResearch.GUI.ViewModels
{
    public class HashCrackVM : ViewModelBase
    {
        private readonly IConfigurationService _configurationService;
        private readonly IBruteForceHashService _bruteforceForceHashService;
        private readonly IHbtFileService _hbtFileService;

        private HashCrackDictionaryTabVM _mainDictionaryVM;
        private HashCrackDictionaryTabVM _firstWordVM;
        private HashCrackDictionaryTabVM _lastWordVM;
        private HbtFile? _hbtFile;

        private string? _selectedExcludePattern;
        private string? _selectedIncludePattern;

        #region Properties
        public HbtFile? HbtFile
        {
            get => _hbtFile;
            set
            {
                _hbtFile = value;
                OnPropertyChanged(nameof(HbtFile));
            }
        }

        public string? SelectedExcludePattern
        {
            get => _selectedExcludePattern;
            set
            {
                _selectedExcludePattern = value;
                if (HbtFile != null)
                    HbtFile.WordFiltering.ExcludePatterns = value ?? string.Empty;
                OnPropertyChanged(nameof(HbtFile));
                OnPropertyChanged(nameof(SelectedExcludePattern));
            }
        }

        public string? SelectedIncludePattern
        {
            get => _selectedIncludePattern;
            set
            {
                _selectedIncludePattern = value;
                if (HbtFile != null)
                    HbtFile.WordFiltering.IncludePatterns = value ?? string.Empty;
                OnPropertyChanged(nameof(HbtFile));
                OnPropertyChanged(nameof(SelectedIncludePattern));
            }
        }

        public HashCrackDictionaryTabVM MainDictionaryVM
        {
            get => _mainDictionaryVM;
            set
            {
                _mainDictionaryVM = value;
                OnPropertyChanged(nameof(MainDictionaryVM));
            }
        }

        public HashCrackDictionaryTabVM FirstWordVM
        {
            get => _firstWordVM;
            set
            {
                _firstWordVM = value;
                OnPropertyChanged(nameof(FirstWordVM));
            }
        }

        public HashCrackDictionaryTabVM LastWordVM
        {
            get => _lastWordVM;
            set
            {
                _lastWordVM = value;
                OnPropertyChanged(nameof(LastWordVM));
            }
        }

        //Common
        public string[] AttackTypeList { get; private set; } = ["Dictionary", "Character", "Hybrid"];
        public int[] NbrThreadsList { get; private set; } = GetIntegerList(1, 64);

        //Word Filtering
        public string[] ExcludePatternsList { get; private set; }
        public string[] IncludePatternsList { get; private set; }
        public ListItem<string>[] CombinationOrdersList { get; private set; } = GetCombinationOrders();

        //Size Filtering
        public int[] DelimitersList { get; private set; } = GetIntegerList(-1, 10);
        public int[] MinWordLengthList { get; private set; } = GetIntegerList(1, 10);
        public int[] MaxWordLengthList { get; private set; } = GetIntegerList(1, 50);
        public int[] WordSizeList { get; set; } = GetIntegerList(0, 10);
        public ListItem<int>[] WordsList { get; set; } = GetIntegerListWithLabel("words", 0, 10);
        public ListItem<int>[] CharactersList { get; set; } = GetIntegerListWithLabel("characters", 0, 10);
        public int[] AdvancedConcatWordsList { get; set; } = GetIntegerList(0, 10);
        public int[] AdvancedConsecutiveList { get; set; } = GetIntegerList(1, 10);
        public int[] AdvancedMinWordsList { get; set; } = GetIntegerList(1, 10);

        public ICommand QuickSaveCommand { get => new RelayCommand(QuickSave, CanQuickSave); }
        public ICommand QuickLoadCommand { get => new RelayCommand(QuickLoad, CanQuickLoad); }
        public ICommand StartBruteforceCommand { get => new RelayCommand(() => StartBruteforce(false)); }
        public ICommand StartBruteforceHashcatCommand { get => new RelayCommand(() => StartBruteforce(true)); }
        #endregion

        public HashCrackVM(IConfigurationService configurationService, IBruteForceHashService bruteforceForceHashService, IHbtFileService hbtFileService,
            HashCrackDictionaryTabVM mainDictionaryVM, HashCrackDictionaryTabVM firstWordDictionaryVM, HashCrackDictionaryTabVM lastWordDictionaryVM)
        {
            _configurationService = configurationService;
            _bruteforceForceHashService = bruteforceForceHashService;
            _hbtFileService = hbtFileService;

            //Set arrays
            ExcludePatternsList = configurationService.GetExcludePatterns();
            IncludePatternsList = configurationService.GetIncludePatterns();

            _mainDictionaryVM = mainDictionaryVM;
            _mainDictionaryVM.IsMainDictionary = true;
            _firstWordVM = firstWordDictionaryVM;
            _lastWordVM = lastWordDictionaryVM;
        }

        public void LoadHbtFile(HbtFile hbtFile)
        {
            HbtFile = hbtFile;
            _mainDictionaryVM.LoadHbtFileDictionary(hbtFile.DictionaryAttack.DictionaryMain);
            _firstWordVM.LoadHbtFileDictionary(hbtFile.DictionaryAttack.DictionaryFirstWord, hbtFile.DictionaryAttack.DictionaryMain);
            _lastWordVM.LoadHbtFileDictionary(hbtFile.DictionaryAttack.DictionaryLastWord, hbtFile.DictionaryAttack.DictionaryMain);
        }

        private void StartBruteforce(bool useHashcat)
        {
            //var dictionaries = _mainDictionaryVM.RetrieveDictionaries();
        }

        private void QuickLoad()
        {
            //FIX
            var quickSaveFile = _hbtFileService.GetQuickSaveFile(_hbtFile);
            var loadedHbtFile = _hbtFileService.LoadHbrFile(quickSaveFile);
            if(loadedHbtFile != null)
                LoadHbtFile(loadedHbtFile);
        }

        private bool CanQuickLoad()
        {
            var quickSaveFile = _hbtFileService.GetQuickSaveFile(_hbtFile);
            return File.Exists(quickSaveFile);
        }

        private void QuickSave()
        {
            //FIX
            if(_hbtFile != null)
            {
                _hbtFileService.GetQuickDirectory(_hbtFile, true);
                var quickSaveFile = _hbtFileService.GetQuickSaveFile(_hbtFile);
                if (quickSaveFile != null)
                {
                    _hbtFileService.SaveHbrFile(quickSaveFile, _hbtFile);
                }
            }
        }

        private bool CanQuickSave()
        {
            return HashHelper.IsValidHash40Value(HbtFile?.HexValue);
        }

        private static int[] GetIntegerList(int minValue, int maxValue)
        {
            return Enumerable.Range(minValue, maxValue).ToArray();
        }

        private static ListItem<int>[] GetIntegerListWithLabel(string label, int minValue, int maxValue)
        {
            return Enumerable.Range(minValue, maxValue).Select(p => new ListItem<int>($"{p} {label}", p)).ToArray();
        }

        private static ListItem<string>[] GetCombinationOrders()
        {
            return
            [
                new ListItem<string>("Interval short/long", "interval_short"),
                new ListItem<string>("Interval long/short", "interval_long"),
                new ListItem<string>("Fewer/shorter words first", "fewer_words_first_short"),
                new ListItem<string>("Fewer/longer words first", "fewer_words_first_long"),
                new ListItem<string>("Greater/shorter words first", "more_words_first_short"),
                new ListItem<string>("Greater/longer words first", "more_words_first_long"),
            ];
        }
    }
}

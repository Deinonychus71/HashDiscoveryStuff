using HashRelationalResearch.GUI.Helpers;
using HashRelationalResearch.GUI.Models;
using HashRelationalResearch.GUI.Services.Interfaces;

namespace HashRelationalResearch.GUI.ViewModels
{
    public class HashCrackVM : ViewModelBase
    {
        private readonly IConfigurationService _configurationService;
        private readonly IHashDBService _hashDBService;

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

        //Word Filtering
        public string[] ExcludePatternsList { get; private set; }
        public string[] IncludePatternsList { get; private set; }
        public ListItem<string>[] CombinationOrdersList { get; private set; } = GetCombinationOrders();

        //Size Filtering
        public int[] DelimitersList { get; private set; } = ListGenerators.GetIntegerList(-1, 10);
        public int[] MinWordLengthList { get; private set; } = ListGenerators.GetIntegerList(1, 10);
        public int[] MaxWordLengthList { get; private set; } = ListGenerators.GetIntegerList(1, 50);
        public int[] WordsLimitList { get; private set; } = ListGenerators.GetIntegerList(1, 10);
        public int[] WordSizeList { get; set; } = ListGenerators.GetIntegerList(0, 10);
        public ListItem<int>[] WordsList { get; set; } = ListGenerators.GetIntegerListWithLabel("words", 0, 10);
        public ListItem<int>[] CharactersList { get; set; } = ListGenerators.GetIntegerListWithLabel("characters", 0, 10);
        public int[] AdvancedConcatWordsList { get; set; } = ListGenerators.GetIntegerList(0, 10);
        public int[] AdvancedConsecutiveList { get; set; } = ListGenerators.GetIntegerList(1, 10);
        public int[] AdvancedMinWordsList { get; set; } = ListGenerators.GetIntegerList(1, 10);
        #endregion

        public HashCrackVM(IConfigurationService configurationService, IHashDBService hashDBService, HashCrackDictionaryTabVM mainDictionaryVM,
            HashCrackDictionaryTabVM firstWordDictionaryVM, HashCrackDictionaryTabVM lastWordDictionaryVM)
        {
            _configurationService = configurationService;
            _hashDBService = hashDBService;

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

        public void RefreshHash()
        {
            var isUseResearchWordsEnabled = false;

            if (!string.IsNullOrEmpty(_hbtFile?.HexValue))
            {
                var entry = _hashDBService.GetEntry(_hbtFile.HexValue);
                isUseResearchWordsEnabled = entry != null && (entry.PRCFiles.Count > 0 || entry.CFiles.Count > 0);
            }
            _mainDictionaryVM.IsUseResearchWordsEnabled = isUseResearchWordsEnabled;
            _firstWordVM.IsUseResearchWordsEnabled = isUseResearchWordsEnabled;
            _lastWordVM.IsUseResearchWordsEnabled = isUseResearchWordsEnabled;
        }

        private static ListItem<string>[] GetCombinationOrders()
        {
            return
            [
                new ListItem<string>("Interval short/long", "interval|short"),
                new ListItem<string>("Interval long/short", "interval|long"),
                new ListItem<string>("Fewer/shorter words first", "fewer_words_first|short"),
                new ListItem<string>("Fewer/longer words first", "fewer_words_first|long"),
                new ListItem<string>("Greater/shorter words first", "more_words_first|short"),
                new ListItem<string>("Greater/longer words first", "more_words_first|long"),
            ];
        }
    }
}

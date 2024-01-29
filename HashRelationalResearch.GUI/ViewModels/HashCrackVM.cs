using CsvHelper.Configuration.Attributes;
using HashRelationalResearch.GUI.Models;
using HashRelationalResearch.GUI.Services;
using HashRelationalResearch.GUI.Services.Interfaces;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Windows.Documents;

namespace HashRelationalResearch.GUI.ViewModels
{
    public class HashCrackVM : ViewModelBase
    {
        private readonly IConfigurationService _configurationService;

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
        #endregion

        public HashCrackVM(IConfigurationService configurationService, HashCrackDictionaryTabVM mainDictionaryVM, 
            HashCrackDictionaryTabVM firstWordDictionaryVM, HashCrackDictionaryTabVM lastWordDictionaryVM)
        {
            _configurationService = configurationService;

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
            _firstWordVM.LoadHbtFileDictionary(hbtFile.DictionaryAttack.DictionaryFirstWord);
            _lastWordVM.LoadHbtFileDictionary(hbtFile.DictionaryAttack.DictionaryLastWord);
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

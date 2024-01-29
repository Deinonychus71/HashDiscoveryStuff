namespace HashRelationalResearch.GUI.ViewModels
{
    public class HashCrackVM : ViewModelBase
    {
        private HashCrackDictionaryTabVM _mainDictionaryVM;
        private HashCrackDictionaryTabVM _firstWordVM;
        private HashCrackDictionaryTabVM _lastWordVM;

        #region Properties
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
        #endregion

        public HashCrackVM()
        {
            _mainDictionaryVM = new HashCrackDictionaryTabVM();
            _firstWordVM = new HashCrackDictionaryTabVM();
            _lastWordVM = new HashCrackDictionaryTabVM();
        }
    }
}

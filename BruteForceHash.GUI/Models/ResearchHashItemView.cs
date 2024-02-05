namespace BruteForceHash.GUI.Models
{
    public class ResearchHashItemView : ObservableModelBase
    {
        private string? _label;

        public string Hash40 { get; private set; }
        public string? Label
        {
            get => _label;
            set
            {
                _label = value;
                OnPropertyChanged(nameof(Label));
            }
        }

        public string? Type { get; private set; }
        public string? CFile { get; private set; }
        public string? PRCFile { get; private set; }
        public string? PRCPath { get; private set; }
        public bool IsSuspicious { get; private set; }
        public bool CanBeBlacklisted { get { return string.IsNullOrEmpty(PRCFile) && string.IsNullOrEmpty(Label); } }

        public ResearchHashItemView(string hash40, string? label, string? type, string? cFile, string? prcFile, string? prcPath, bool isSuspicious)
        {
            Hash40 = hash40;
            Label = label;
            Type = type;
            CFile = cFile;
            PRCFile = prcFile;
            PRCPath = prcPath;
            IsSuspicious = isSuspicious;
        }
    }
}

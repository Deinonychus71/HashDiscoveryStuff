namespace BruteForceHash.GUI.Models
{
    public class ResearchHashItemView : ObservableModelBase
    {
        public string Hash40 { get; private set; }
        public string? Label { get; private set; }
        public string? Type { get; private set; }
        public string? CFile { get; private set; }
        public string? PRCFile { get; private set; }
        public bool IsSuspicious { get; private set; }
        public bool CanBeBlacklisted { get { return string.IsNullOrEmpty(PRCFile); } }

        public ResearchHashItemView(string hash40, string? label, string? type, string? cFile, string? prcFile, bool isSuspicious)
        {
            Hash40 = hash40;
            Label = label;
            Type = type;
            CFile = cFile;
            PRCFile = prcFile;
            IsSuspicious = isSuspicious;
        }
    }
}

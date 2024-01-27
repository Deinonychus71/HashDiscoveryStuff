using CommunityToolkit.Mvvm.Input;
using HashRelationalResearch.GUI.Helpers;
using System.IO;
using System.Windows.Input;

namespace HashRelationalResearch.GUI.ViewModels
{
    public class MainWindowVM : ViewModelBase
    {
        public ICommand OpenFileCommand { get => new RelayCommand<string>(OpenFile, CanOpenFile); }

        private void OpenFile(string? filePath)
        {
            if (filePath != null)
                JSONDB.Init(filePath);
        }

        private bool CanOpenFile(string? filePath)
        {
            return filePath != null && File.Exists(filePath);
        }
    }
}

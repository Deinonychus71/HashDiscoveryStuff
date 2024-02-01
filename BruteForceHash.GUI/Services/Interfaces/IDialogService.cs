using BruteForceHash.GUI.Helpers;

namespace BruteForceHash.GUI.Services.Interfaces
{
    public interface IDialogService
    {
        string? OpenFolderDialog(string? placerHolder = null, bool multiselect = false);

        string? OpenFileDialog(FileTypes fileTypes, string? placerHolder = null, FileTypes defaultExt = FileTypes.None, bool multiselect = false);

        string? SaveFileDialog(FileTypes fileTypes, string? placerHolder = null, FileTypes defaultExt = FileTypes.None);

        void ShowMessage(string message, bool isError = false);

        bool ShowYesNoQuestion(string message);
    }
}

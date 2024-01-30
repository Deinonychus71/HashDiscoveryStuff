using HashRelationalResearch.GUI.Helpers;
using HashRelationalResearch.GUI.Services.Interfaces;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Windows;

namespace HashRelationalResearch.GUI.Services
{
    public class DialogService : IDialogService
    {
        private const string MESSAGEBOX_TITLE = "BruteForceHash";
        private readonly OpenFileDialog _openFileDialog;
        private readonly OpenFolderDialog _openFolderDialog;
        private readonly SaveFileDialog _saveFileDialog;

        public DialogService()
        {
            _saveFileDialog = new SaveFileDialog
            {
                CheckPathExists = true,
                AddExtension = true
            };

            _openFileDialog = new OpenFileDialog
            {
                CheckPathExists = true,
                AddExtension = true
            };

            _openFolderDialog = new OpenFolderDialog();
        }

        public string OpenFolderDialog(string? placerHolder = null, bool multiselect = false)
        {
            _openFolderDialog.Multiselect = multiselect;
            _openFolderDialog.FolderName = placerHolder ?? null;

            if (_openFolderDialog.ShowDialog() == true)
                return _openFolderDialog.FolderName ?? string.Empty;

            return string.Empty;
        }

        public string OpenFileDialog(FileTypes fileTypes, string? placerHolder = null, FileTypes defaultExt = FileTypes.None, bool multiselect = false)
        {
            _openFileDialog.Multiselect = multiselect;
            _openFileDialog.FileName = placerHolder ?? null;
            _openFileDialog.DefaultExt = GetFlagToExtension(defaultExt);
            _openFileDialog.AddExtension = _openFileDialog.DefaultExt != null;
            _openFileDialog.Filter = GetFlagToFilter(fileTypes);

            if (_openFileDialog.ShowDialog() == true)
                return _openFileDialog.FileName ?? string.Empty;

            return string.Empty;
        }

        public string SaveFileDialog(FileTypes fileTypes, string? placerHolder = null, FileTypes defaultExt = FileTypes.None)
        {
            _saveFileDialog.FileName = placerHolder ?? null;
            _saveFileDialog.DefaultExt = GetFlagToExtension(defaultExt);
            _saveFileDialog.AddExtension = _openFileDialog.DefaultExt != null;
            _saveFileDialog.Filter = GetFlagToFilter(fileTypes);

            if (_saveFileDialog.ShowDialog() == true)
                return _saveFileDialog.FileName ?? string.Empty;

            return string.Empty;
        }

        public void ShowMessage(string message, bool isError = false)
        {
            if (isError)
                MessageBox.Show(message, MESSAGEBOX_TITLE, MessageBoxButton.OK, MessageBoxImage.Error);
            else
                MessageBox.Show(message, MESSAGEBOX_TITLE, MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public bool ShowYesNoQuestion(string message)
        {
            return MessageBox.Show(message, MESSAGEBOX_TITLE, MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes;
        }

        private static string? GetFlagToFilter(FileTypes extension)
        {
            var output = new List<string>();
            if (extension.HasFlag(FileTypes.Json))
                output.Add("JSON File|*.json");
            if (extension.HasFlag(FileTypes.Hbt))
                output.Add("BruteforceHash File|*.hbt");
            if (extension.HasFlag(FileTypes.Exe))
                output.Add("Application File|*.exe");
            if (extension.HasFlag(FileTypes.Bin))
                output.Add("Binary File|*.bin");
            if (extension.HasFlag(FileTypes.All))
                output.Add("All Files (.)|.");

            return string.Join(';', output);
        }

        private static string? GetFlagToExtension(FileTypes extension)
        {
            return extension switch
            {
                FileTypes.Json => "json",
                FileTypes.Hbt => "hbt",
                FileTypes.Exe => "exe",
                FileTypes.Bin => "bin",
                _ => null,
            };
        }
    }
}

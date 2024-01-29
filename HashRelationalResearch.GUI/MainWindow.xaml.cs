using HashRelationalResearch.GUI.Config;
using HashRelationalResearch.GUI.Services;
using HashRelationalResearch.GUI.Services.Interfaces;
using HashRelationalResearch.GUI.ViewModels;
using Microsoft.Extensions.Options;
using Microsoft.Win32;
using System.Windows;
using System.Windows.Controls;

namespace HashRelationalResearch.GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SaveClick(object sender, RoutedEventArgs e)
        {

        }

        private void LoadClick(object sender, RoutedEventArgs e)
        {

        }

        private void RefreshClick(object sender, RoutedEventArgs e)
        {

        }

        private void QuickSaveClick(object sender, RoutedEventArgs e)
        {

        }

        private void QuickLoadClick(object sender, RoutedEventArgs e)
        {

        }

        private void QuickCleanClick(object sender, RoutedEventArgs e)
        {

        }

        private void PickDBFileClick(object sender, RoutedEventArgs e)
        {
            if (DataContext is MainWindowVM viewModel)
            {
                OpenFileDialog openFileDialog = new()
                {
                    FileName = "export.json",
                    DefaultExt = "json"
                };
                if (openFileDialog.ShowDialog() == true && viewModel.PickHashDBFileCommand.CanExecute(openFileDialog.FileName))
                {
                    viewModel.PickHashDBFileCommand.Execute(openFileDialog.FileName);
                }
            }
        }

        private void PickPRCRootFolderClick(object sender, RoutedEventArgs e)
        {
            if (DataContext is MainWindowVM viewModel)
            {
                OpenFolderDialog openFolderDialog = new();
                if (openFolderDialog.ShowDialog() == true && viewModel.PickPRCRootFolderCommand.CanExecute(openFolderDialog.FolderName))
                {
                    viewModel.PickPRCRootFolderCommand.Execute(openFolderDialog.FolderName);
                }
            }
        }

        private void PickHashcatFolderClick(object sender, RoutedEventArgs e)
        {
            if (DataContext is MainWindowVM viewModel)
            {
                OpenFolderDialog openFolderDialog = new();
                if (openFolderDialog.ShowDialog() == true && viewModel.PickHashcatFolderCommand.CanExecute(openFolderDialog.FolderName))
                {
                    viewModel.PickHashcatFolderCommand.Execute(openFolderDialog.FolderName);
                }
            }
        }
    }
}
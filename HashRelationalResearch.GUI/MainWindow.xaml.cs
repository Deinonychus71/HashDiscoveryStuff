using HashRelationalResearch.GUI.ViewModels;
using Microsoft.Win32;
using System.Windows;

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

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (this.DataContext is MainWindowVM viewModel)
            {
                OpenFileDialog openFileDialog = new()
                {
                    FileName = "export.json",
                    DefaultExt = "json"
                };
                if (openFileDialog.ShowDialog() == true && viewModel.OpenFileCommand.CanExecute(openFileDialog.FileName))
                {
                    viewModel.OpenFileCommand.Execute(openFileDialog.FileName);
                }
            }
        }
    }
}
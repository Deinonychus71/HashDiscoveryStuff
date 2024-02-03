﻿using BruteForceHash.GUI.ViewModels;
using System.ComponentModel;
using System.Windows;

namespace BruteForceHash.GUI
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (DataContext is MainWindowVM mainWindowVM)
                mainWindowVM.SaveWorkspace();

            base.OnClosing(e);
        }
    }
}
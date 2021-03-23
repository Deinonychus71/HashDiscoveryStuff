using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BruteForceHash.GUI
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            cbMethod.SelectedIndex = 0;
            cbNbThreads.SelectedIndex = 7;
            cbWordsLimit.SelectedIndex = 2;

            if (Directory.Exists("Dictionaries"))
            {
                var allDictionaries = Directory.GetFiles("Dictionaries", "*.dic");
                foreach (var dictionaryPath in allDictionaries)
                {
                    chklDictionaries.Items.Add(Path.GetFileName(dictionaryPath));
                    ;
                }
            }
            else
            {
                Directory.CreateDirectory("Dictionaries");
            }
        }

        private void OnBtnStartClick(object sender, EventArgs e)
        {
            var allDictionaries = Directory.GetFiles("Dictionaries", "*.dic");
            var dictionaries = string.Empty;
            foreach(var dict in chklDictionaries.CheckedItems)
            {
                var dictStr = dict.ToString();
                var dictPath = allDictionaries.FirstOrDefault(p => p.EndsWith(dictStr));
                dictionaries += $"{dictPath};";
            }

            using (var process = new Process())
            {
                process.StartInfo.FileName = "BruteForceHash.exe";
                process.StartInfo.Arguments = $"--nbr_threads {cbNbThreads.SelectedItem} " +
                                                $"--method {cbMethod.SelectedItem} " +
                                                $"--words_limit {cbWordsLimit.SelectedItem} " +
                                                $"--skip_digits {chkSkipDigits.Checked} " +
                                                $"--force_lowercase {chkLowerCase.Checked} " +
                                                $"--use_dictionaries \"{dictionaries}\" " +
                                                $"--include_word \"{txtIncludeWord.Text}\" " +
                                                $"--include_patterns \"{txtIncludeWord.Text}\" " +
                                                $"--exclude_patterns \"{txtExcludePatterns.Text}\" " +
                                                $"--delimiter \"{txtDelimiter.Text}\" " +
                                                $"--prefix \"{txtPrefix.Text}\" " +
                                                $"--hex_value \"{txtHexValues.Text}\"";
                process.StartInfo.UseShellExecute = false;
                process.Start();

                process.WaitForExit();
                process.Close();
            }
        }
    }
}

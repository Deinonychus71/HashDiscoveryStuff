using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
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
            cbCombinationOrder.SelectedIndex = 0;

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

            pnlDictionary.Visible = true;
            pnlCharacter.Visible = false;
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
                if (cbMethod.SelectedItem.ToString() == "Dictionary")
                {
                    process.StartInfo.Arguments = $"--nbr_threads {cbNbThreads.SelectedItem} " +
                                                    $"--method {cbMethod.SelectedItem} " +
                                                    $"--words_limit {cbWordsLimit.SelectedItem} " +
                                                    $"{(chkSkipDigits.Checked ? "--skip_digits" : "")} " +
                                                    $"{(chkSpecials.Checked ? "--skip_specials" : "")} " +
                                                    $"{(chkLowerCase.Checked ? "--force_lowercase" : "")} " +
                                                    $"--order {cbCombinationOrder.SelectedItem} " +
                                                    $"{(chkVerbose.Checked ? "--verbose" : "")} " +
                                                    $"--confirm_end " +
                                                    $"--dictionaries \"{dictionaries}\" " +
                                                    $"--include_word \"{txtIncludeWord.Text.Trim()}\" " +
                                                    $"--include_patterns \"{txtIncludePatterns.Text.Trim()}\" " +
                                                    $"--exclude_patterns \"{txtExcludePatterns.Text.Trim()}\" " +
                                                    $"--delimiter \"{txtDelimiter.Text.Trim()}\" " +
                                                    $"--prefix \"{txtPrefix.Text.Trim()}\" " +
                                                    $"--suffix \"{txtSuffix.Text.Trim()}\" " +
                                                    $"--hex_value \"{txtHexValues.Text.Trim()}\"";
                }
                else
                {
                    process.StartInfo.Arguments = $"--nbr_threads {cbNbThreads.SelectedItem} " +
                                                    $"--method {cbMethod.SelectedItem} " +
                                                    $"{(chkVerbose.Checked ? "--verbose" : "")} " +
                                                    $"--confirm_end " +
                                                    $"--valid_chars \"{txtValidChars.Text.Trim()}\" " +
                                                    $"--valid_starting_chars \"{txtStartingValidChars.Text.Trim()}\" " +
                                                    $"--start_position \"{numStartPosition.Value}\" " +
                                                    $"--end_position \"{numEndPosition.Value}\" " +
                                                    $"--include_word \"{txtIncludeWordsCharacter.Text.Trim()}\" " +
                                                    $"--prefix \"{txtPrefix.Text.Trim()}\" " +
                                                    $"--suffix \"{txtSuffix.Text.Trim()}\" " +
                                                    $"--hex_value \"{txtHexValues.Text.Trim()}\"";
                }
                process.StartInfo.UseShellExecute = false;
                process.Start();

                process.WaitForExit();
                process.Close();
            }
        }

        private void OnCbMethodChanged(object sender, EventArgs e)
        {
            pnlDictionary.Visible = cbMethod.SelectedItem == null || cbMethod.SelectedItem.ToString() == "Dictionary";
            pnlCharacter.Visible = !pnlDictionary.Visible;
        }
    }
}

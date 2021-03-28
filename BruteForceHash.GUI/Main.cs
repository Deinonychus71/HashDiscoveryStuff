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
                                                    $"{(chkCombinationOrder.Checked ? "--order_descending" : "")} " +
                                                    $"{(chkVerbose.Checked ? "--verbose" : "")} " +
                                                    $"--confirm_end " +
                                                    $"--use_dictionaries \"{dictionaries}\" " +
                                                    $"--include_word \"{txtIncludeWord.Text}\" " +
                                                    $"--include_patterns \"{txtIncludePatterns.Text}\" " +
                                                    $"--exclude_patterns \"{txtExcludePatterns.Text}\" " +
                                                    $"--delimiter \"{txtDelimiter.Text}\" " +
                                                    $"--prefix \"{txtPrefix.Text}\" " +
                                                    $"--suffix \"{txtSuffix.Text}\" " +
                                                    $"--hex_value \"{txtHexValues.Text}\"";
                }
                else
                {
                    process.StartInfo.Arguments = $"--nbr_threads {cbNbThreads.SelectedItem} " +
                                                    $"--method {cbMethod.SelectedItem} " +
                                                    $"{(chkVerbose.Checked ? "--verbose" : "")} " +
                                                    $"--confirm_end " +
                                                    $"--valid_chars \"{txtValidChars.Text}\" " +
                                                    $"--valid_starting_chars \"{txtStartingValidChars.Text}\" " +
                                                    $"--include_word \"{txtIncludeWordsCharacter.Text}\" " +
                                                    $"--prefix \"{txtPrefix.Text}\" " +
                                                    $"--suffix \"{txtSuffix.Text}\" " +
                                                    $"--hex_value \"{txtHexValues.Text}\"";
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

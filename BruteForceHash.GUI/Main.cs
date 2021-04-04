using Newtonsoft.Json;
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
            mnLoad.Click += OnLoadClick;
            mnSave.Click += OnSaveClick;
            openFile.InitialDirectory = Directory.GetCurrentDirectory();
            saveFile.InitialDirectory = Directory.GetCurrentDirectory();
            openFile.Filter = "HBT files|*.hbt";
            saveFile.Filter = "HBT files|*.hbt";

            if (Directory.Exists("Dictionaries"))
            {
                var allDictionaries = Directory.GetFiles("Dictionaries", "*.dic");
                foreach (var dictionaryPath in allDictionaries)
                {
                    var filename = Path.GetFileName(dictionaryPath);
                    chklDictionaries.Items.Add(filename);
                    chklDictionariesFirstWord.Items.Add(filename);
                    chklDictionariesLastWord.Items.Add(filename);
                }
            }
            else
            {
                Directory.CreateDirectory("Dictionaries");
            }

            pnlDictionary.Visible = true;
            pnlCharacter.Visible = false;
        }

        private void OnSaveClick(object sender, EventArgs e)
        {
            var dictionaries = GetDictionary(chklDictionaries);
            var dictionariesFirstWord = GetDictionary(chklDictionariesFirstWord);
            var dictionariesLastWord = GetDictionary(chklDictionariesLastWord);

            var result = saveFile.ShowDialog();
            if(result == DialogResult.OK)
            {
                var hbtObject = new HbtFile()
                {
                    Method = cbMethod.SelectedItem.ToString(),
                    NbrThreads = Convert.ToInt32(cbNbThreads.SelectedItem),
                    WordsLimit = Convert.ToInt32(cbWordsLimit.SelectedItem),
                    SkipDigits = chkSkipDigits.Checked,
                    SkipSpecials = chkSpecials.Checked,
                    ForceLowercase = chkLowerCase.Checked,
                    Order = cbCombinationOrder.SelectedItem.ToString(),
                    Verbose = chkVerbose.Checked,
                    Dictionaries = dictionaries,
                    DictionariesFirstWord = dictionariesFirstWord,
                    DictionariesLastWord = dictionariesLastWord,
                    IncludeWordDict = txtIncludeWord.Text.Trim(),
                    IncludeWordChar = txtIncludeWordsCharacter.Text.Trim(),
                    IncludePatterns = txtIncludePatterns.Text.Trim(),
                    ExcludePatterns = txtExcludePatterns.Text.Trim(),
                    Delimiter = txtDelimiter.Text.Trim(),
                    Prefix = txtPrefix.Text.Trim(),
                    Suffix = txtSuffix.Text.Trim(),
                    ValidChars = txtValidChars.Text.Trim(),
                    ValidStartingChars = txtStartingValidChars.Text.Trim(),
                    StartPosition = Convert.ToInt32(numStartPosition.Value),
                    EndPosition = Convert.ToInt32(numEndPosition.Value),
                    HexValue = txtHexValues.Text.Trim()
                };
                File.WriteAllText(saveFile.FileName, JsonConvert.SerializeObject(hbtObject));
            }
        }

        private void OnLoadClick(object sender, EventArgs e)
        {
            var result = openFile.ShowDialog();
            if (result == DialogResult.OK)
            {
                var hbtObject = JsonConvert.DeserializeObject<HbtFile>(File.ReadAllText(openFile.FileName));
                cbMethod.SelectedItem = hbtObject.Method;
                cbNbThreads.SelectedItem = hbtObject.NbrThreads;
                cbWordsLimit.SelectedItem = hbtObject.WordsLimit;
                chkSkipDigits.Checked = hbtObject.SkipDigits;
                chkSpecials.Checked = hbtObject.SkipSpecials;
                chkLowerCase.Checked = hbtObject.ForceLowercase;
                cbCombinationOrder.SelectedItem = hbtObject.Order;
                chkVerbose.Checked = hbtObject.Verbose;
                SetDictionary(chklDictionaries, hbtObject.Dictionaries);
                SetDictionary(chklDictionariesFirstWord, hbtObject.DictionariesFirstWord);
                SetDictionary(chklDictionariesLastWord, hbtObject.DictionariesLastWord);
                txtIncludeWord.Text = hbtObject.IncludeWordDict;
                txtIncludeWordsCharacter.Text = hbtObject.IncludeWordChar;
                txtIncludePatterns.Text = hbtObject.IncludePatterns;
                txtExcludePatterns.Text = hbtObject.ExcludePatterns;
                txtDelimiter.Text = hbtObject.Delimiter;
                txtPrefix.Text = hbtObject.Prefix;
                txtSuffix.Text = hbtObject.Suffix;
                txtValidChars.Text = hbtObject.ValidChars;
                txtStartingValidChars.Text = hbtObject.ValidStartingChars;
                numStartPosition.Value = hbtObject.StartPosition;
                numEndPosition.Value = hbtObject.EndPosition;
                txtHexValues.Text = hbtObject.HexValue;
            }
        }

        private void OnBtnStartClick(object sender, EventArgs e)
        {
            var dictionaries = GetDictionary(chklDictionaries);
            var dictionariesFirstWord = GetDictionary(chklDictionariesFirstWord);
            var dictionariesLastWord = GetDictionary(chklDictionariesLastWord);

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
                                                    $"--dictionaries_first_word \"{dictionariesFirstWord}\" " +
                                                    $"--dictionaries_last_word \"{dictionariesLastWord}\" " +
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

        private string GetDictionary(CheckedListBox chkList)
        {
            var allDictionaries = Directory.GetFiles("Dictionaries", "*.dic");
            var dictionaries = string.Empty;
            foreach (var dict in chkList.CheckedItems)
            {
                var dictStr = dict.ToString();
                var dictPath = allDictionaries.FirstOrDefault(p => p.EndsWith(dictStr));
                dictionaries += $"{dictPath};";
            }
            return dictionaries;
        }

        private void SetDictionary(CheckedListBox chkList, string dictionaries)
        {
            if (!string.IsNullOrEmpty(dictionaries))
            {
                var splitEntries = dictionaries.Split(";", StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < chkList.Items.Count; i++)
                {
                    chkList.SetItemChecked(i, false);
                }
                foreach (var entry in splitEntries)
                {
                    var dict = Path.GetFileName(entry);
                    for (int i = 0; i < chkList.Items.Count; i++)
                    {
                        if (chkList.Items[i].ToString().EndsWith(dict))
                        {
                            chkList.SetItemChecked(i, true);
                            break;
                        }
                    }
                }
            }
        }

        private void OnCbMethodChanged(object sender, EventArgs e)
        {
            pnlDictionary.Visible = cbMethod.SelectedItem == null || cbMethod.SelectedItem.ToString() == "Dictionary";
            pnlCharacter.Visible = !pnlDictionary.Visible;
        }

        private void OnCopyFirstClick(object sender, EventArgs e)
        {
            var dictionaries = GetDictionary(chklDictionaries);
            SetDictionary(chklDictionariesFirstWord, dictionaries);
        }

        private void OnCopyLastClick(object sender, EventArgs e)
        {
            var dictionaries = GetDictionary(chklDictionaries);
            SetDictionary(chklDictionariesLastWord, dictionaries);
        }
    }
}

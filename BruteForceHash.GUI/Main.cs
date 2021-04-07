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

            mnLoad.Click += OnLoadClick;
            mnSave.Click += OnSaveClick;
            mnNew.Click += OnNewClick;
            Directory.CreateDirectory("Templates");
            openFile.InitialDirectory = Directory.GetCurrentDirectory() + "\\Templates\\";
            saveFile.InitialDirectory = Directory.GetCurrentDirectory() + "\\Templates\\";
            openFile.Filter = "HBT files|*.hbt";
            saveFile.Filter = "HBT files|*.hbt";

            OnNewClick(this, null);
        }

        #region Button Clicks
        private void OnNewClick(object sender, EventArgs e)
        {
            cbMethod.SelectedIndex = 0;
            cbNbThreads.SelectedIndex = 7;
            cbWordsLimit.SelectedIndex = 2;
            cbCombinationOrder.SelectedIndex = 0;
            chkVerbose.Checked = true;

            SetDictionary(chklDictionaries, string.Empty);
            chkDictSkipDigits.Checked = false;
            chkDictSkipSpecials.Checked = true;
            chkDictForceLowercase.Checked = true;
            chkDictAddTypos.Checked = false;
            chkDictReverseOrder.Checked = false;

            chkUseCustomDictFirst.Checked = false;
            SetDictionary(chklDictionariesFirstWord, string.Empty);
            chkDictFirstSkipDigits.Checked = false;
            chkDictFirstSkipSpecials.Checked = false;
            chkDictFirstForceLowercase.Checked = false;
            chkDictFirstAddTypos.Checked = false;
            chkDictFirstReverseOrder.Checked = false;

            chkUseCustomDictLast.Checked = false;
            SetDictionary(chklDictionariesLastWord, string.Empty);
            chkDictLastSkipDigits.Checked = false;
            chkDictLastSkipSpecials.Checked = false;
            chkDictLastForceLowercase.Checked = false;
            chkDictLastAddTypos.Checked = false;
            chkDictLastReverseOrder.Checked = false;

            txtIncludeWord.Text = string.Empty;
            chkIncludeWordNotFirst.Checked = false;
            chkIncludeWordNotLast.Checked = false;
            txtIncludeWordsCharacter.Text = string.Empty;
            txtIncludePatterns.Text = string.Empty;
            txtExcludePatterns.Text = string.Empty;
            txtDelimiter.Text = "_";
            txtPrefix.Text = string.Empty;
            txtSuffix.Text = string.Empty;
            txtValidChars.Text = "etainoshrdlucmfwygpbvkqjxz0123456789_";
            txtStartingValidChars.Text = "etainoshrdlucmfwygpbvkqjxz_";
            numStartPosition.Value = 0;
            numEndPosition.Value = 0;
            txtHexValues.Text = string.Empty;

            txtHashCatPath.Text = "Tools\\Hashcat\\hashcat.exe";

            OnCustomDictFirstCheckedChanged(this, null);
            OnCustomDictLastCheckedChanged(this, null);

            chklDictionaries.Items.Clear();
            chklDictionariesFirstWord.Items.Clear();
            chklDictionariesLastWord.Items.Clear();
            if (Directory.Exists("Dictionaries"))
            {
                var allDictionaries = Directory.GetFiles("Dictionaries", "*.dic");
                foreach (var dictionaryPath in allDictionaries)
                {
                    var filename = Path.GetFileName(dictionaryPath);
                    var isFirstDic = filename.Contains("[1st]");
                    var isLastDic = filename.Contains("[Last]");
                    if (!isFirstDic && !isLastDic)
                        chklDictionaries.Items.Add(filename);
                    if (!isLastDic)
                        chklDictionariesFirstWord.Items.Add(filename);
                    if (!isFirstDic)
                        chklDictionariesLastWord.Items.Add(filename);
                }
            }
            else
            {
                Directory.CreateDirectory("Dictionaries");
            }

            pnlDictionary.Visible = true;
            pnlCharacter.Visible = false;
            btnStartHashCat.Enabled = (pnlCharacter.Visible && string.IsNullOrEmpty(txtIncludeWordsCharacter.Text)) || pnlDictionary.Visible;
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
                    Order = cbCombinationOrder.SelectedItem.ToString(),
                    Verbose = chkVerbose.Checked,
                    Dictionaries = dictionaries,
                    DictionariesSkipDigits = chkDictSkipDigits.Checked,
                    DictionariesSkipSpecials = chkDictSkipSpecials.Checked,
                    DictionariesForceLowercase = chkDictForceLowercase.Checked,
                    DictionariesAddTypos = chkDictAddTypos.Checked,
                    DictionariesReverseTypos = chkDictReverseOrder.Checked,
                    UseDictionaryFirstWord = chkUseCustomDictFirst.Checked,
                    DictionariesFirstWord = dictionariesFirstWord,
                    DictionariesFirstWordSkipDigits = chkDictFirstSkipDigits.Checked,
                    DictionariesFirstWordSkipSpecials = chkDictFirstSkipSpecials.Checked,
                    DictionariesFirstWordForceLowercase = chkDictFirstForceLowercase.Checked,
                    DictionariesFirstWordAddTypos = chkDictFirstAddTypos.Checked,
                    DictionariesFirstWordReverseTypos = chkDictFirstReverseOrder.Checked,
                    UseDictionaryLastWord = chkUseCustomDictLast.Checked,
                    DictionariesLastWord = dictionariesLastWord,
                    DictionariesLastWordSkipDigits = chkDictLastSkipDigits.Checked,
                    DictionariesLastWordSkipSpecials = chkDictLastSkipSpecials.Checked,
                    DictionariesLastWordForceLowercase = chkDictLastForceLowercase.Checked,
                    DictionariesLastWordAddTypos = chkDictLastAddTypos.Checked,
                    DictionariesLastWordReverseTypos = chkDictLastReverseOrder.Checked,
                    IncludeWordDict = txtIncludeWord.Text.Trim(),
                    IncludeWordNotFirst = chkIncludeWordNotFirst.Checked,
                    IncludeWordNotLast = chkIncludeWordNotLast.Checked,
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
                    HexValue = txtHexValues.Text.Trim(),
                    PathHashCat = txtHashCatPath.Text.Trim()
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
                cbNbThreads.SelectedItem = hbtObject.NbrThreads.ToString();
                cbWordsLimit.SelectedItem = hbtObject.WordsLimit.ToString();
                cbCombinationOrder.SelectedItem = hbtObject.Order;
                chkVerbose.Checked = hbtObject.Verbose;

                SetDictionary(chklDictionaries, hbtObject.Dictionaries);
                chkDictSkipDigits.Checked = hbtObject.DictionariesSkipDigits;
                chkDictSkipSpecials.Checked = hbtObject.DictionariesSkipSpecials;
                chkDictForceLowercase.Checked = hbtObject.DictionariesForceLowercase;
                chkDictAddTypos.Checked = hbtObject.DictionariesAddTypos;
                chkDictReverseOrder.Checked = hbtObject.DictionariesReverseTypos;

                chkUseCustomDictFirst.Checked = hbtObject.UseDictionaryFirstWord;
                SetDictionary(chklDictionariesFirstWord, hbtObject.DictionariesFirstWord);
                chkDictFirstSkipDigits.Checked = hbtObject.DictionariesFirstWordSkipDigits;
                chkDictFirstSkipSpecials.Checked = hbtObject.DictionariesFirstWordSkipSpecials;
                chkDictFirstForceLowercase.Checked = hbtObject.DictionariesFirstWordForceLowercase;
                chkDictFirstAddTypos.Checked = hbtObject.DictionariesFirstWordAddTypos;
                chkDictFirstReverseOrder.Checked = hbtObject.DictionariesFirstWordReverseTypos;

                chkUseCustomDictLast.Checked = hbtObject.UseDictionaryLastWord;
                SetDictionary(chklDictionariesLastWord, hbtObject.DictionariesLastWord);
                chkDictLastSkipDigits.Checked = hbtObject.DictionariesLastWordSkipDigits;
                chkDictLastSkipSpecials.Checked = hbtObject.DictionariesLastWordSkipSpecials;
                chkDictLastForceLowercase.Checked = hbtObject.DictionariesLastWordForceLowercase;
                chkDictLastAddTypos.Checked = hbtObject.DictionariesLastWordAddTypos;
                chkDictLastReverseOrder.Checked = hbtObject.DictionariesLastWordReverseTypos;

                txtIncludeWord.Text = hbtObject.IncludeWordDict;
                chkIncludeWordNotFirst.Checked = hbtObject.IncludeWordNotFirst;
                chkIncludeWordNotLast.Checked = hbtObject.IncludeWordNotLast;
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
                txtHashCatPath.Text = hbtObject.PathHashCat;
            }
        }

        private void StartProcess(bool useHashCat = false)
        {
            var dictionaries = GetDictionary(chklDictionaries);
            var dictionariesFirstWord = string.Empty;
            var dictionariesLastWord = string.Empty;
            var dictFirstSkipDigits = chkDictSkipDigits.Checked;
            var dictFirstSkipSpecial = chkDictSkipSpecials.Checked;
            var dictFirstForceLowercase = chkDictForceLowercase.Checked;
            var dictFirstAddTypos = chkDictAddTypos.Checked;
            var dictFirstReverseOrder = chkDictReverseOrder.Checked;
            var dictLastSkipDigits = chkDictSkipDigits.Checked;
            var dictLastSkipSpecial = chkDictSkipSpecials.Checked;
            var dictLastForceLowercase = chkDictForceLowercase.Checked;
            var dictLastAddTypos = chkDictAddTypos.Checked;
            var dictLastReverseOrder = chkDictReverseOrder.Checked;
            if (chkUseCustomDictFirst.Checked)
            {
                dictFirstSkipDigits = chkDictFirstSkipDigits.Checked;
                dictFirstSkipSpecial = chkDictFirstSkipSpecials.Checked;
                dictFirstForceLowercase = chkDictFirstForceLowercase.Checked;
                dictFirstAddTypos = chkDictFirstAddTypos.Checked;
                dictFirstReverseOrder = chkDictFirstReverseOrder.Checked;
                dictionariesFirstWord = GetDictionary(chklDictionariesFirstWord);
            }
            if (chkUseCustomDictLast.Checked)
            {
                dictLastSkipDigits = chkDictLastSkipDigits.Checked;
                dictLastSkipSpecial = chkDictLastSkipSpecials.Checked;
                dictLastForceLowercase = chkDictLastForceLowercase.Checked;
                dictLastAddTypos = chkDictLastAddTypos.Checked;
                dictLastReverseOrder = chkDictLastReverseOrder.Checked;
                dictionariesLastWord = GetDictionary(chklDictionariesLastWord);
            }

            using (var process = new Process())
            {
                process.StartInfo.FileName = "BruteForceHash.exe";
                if (cbMethod.SelectedItem.ToString() == "Dictionary")
                {
                    process.StartInfo.Arguments = $"--nbr_threads {cbNbThreads.SelectedItem} " +
                                                    $"--method {(useHashCat ? "dictionary_hashcat" : cbMethod.SelectedItem)} " +
                                                    $"--words_limit {cbWordsLimit.SelectedItem} " +
                                                    $"{(chkDictSkipDigits.Checked ? "--dictionaries_skip_digits" : "")} " +
                                                    $"{(chkDictSkipSpecials.Checked ? "--dictionaries_skip_specials" : "")} " +
                                                    $"{(chkDictForceLowercase.Checked ? "--dictionaries_force_lowercase" : "")} " +
                                                    $"{(chkDictAddTypos.Checked ? "--dictionaries_add_typos" : "")} " +
                                                    $"{(chkDictReverseOrder.Checked ? "--dictionaries_reverse_order" : "")} " +
                                                    $"{(dictFirstSkipDigits ? "--dictionaries_first_skip_digits" : "")} " +
                                                    $"{(dictFirstSkipSpecial ? "--dictionaries_first_skip_specials" : "")} " +
                                                    $"{(dictFirstForceLowercase ? "--dictionaries_first_force_lowercase" : "")} " +
                                                    $"{(dictFirstAddTypos ? "--dictionaries_first_add_typos" : "")} " +
                                                    $"{(dictFirstReverseOrder ? "--dictionaries_first_reverse_order" : "")} " +
                                                    $"{(dictLastSkipDigits ? "--dictionaries_last_skip_digits" : "")} " +
                                                    $"{(dictLastSkipSpecial ? "--dictionaries_last_skip_specials" : "")} " +
                                                    $"{(dictLastForceLowercase ? "--dictionaries_last_force_lowercase" : "")} " +
                                                    $"{(dictLastAddTypos ? "--dictionaries_last_add_typos" : "")} " +
                                                    $"{(dictLastReverseOrder ? "--dictionaries_last_reverse_order" : "")} " +
                                                    $"--order_algorithm {GetCombinationOrderName()} " +
                                                    $"{(GetCombinationOrderLongerFirst() ? "--order_longer_words_first" : "")} " +
                                                    $"{(chkVerbose.Checked ? "--verbose" : "")} " +
                                                    $"--confirm_end " +
                                                    $"--dictionaries \"{dictionaries}\" " +
                                                    $"--dictionaries_first_word \"{dictionariesFirstWord}\" " +
                                                    $"--dictionaries_last_word \"{dictionariesLastWord}\" " +
                                                    $"--include_word \"{txtIncludeWord.Text.Trim()}\" " +
                                                    $"{(chkIncludeWordNotFirst.Checked ? "--include_word_not_first" : "")} " +
                                                    $"{(chkIncludeWordNotLast.Checked ? "--include_word_not_last" : "")} " +
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
                                                    $"--method {(useHashCat ? "character_hashcat" : cbMethod.SelectedItem)} " +
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

        private string GetCombinationOrderName()
        {
            return cbCombinationOrder.SelectedItem.ToString() switch
            {
                "Interval short/long" => "interval",
                "Interval long/short" => "interval",
                "Fewer/shorter words first" => "fewer_words_first",
                "Fewer/longer words first" => "fewer_words_first",
                "Greater/shorter words first" => "more_words_first",
                "Greater/longer words first" => "more_words_first",
                _ => throw new NotImplementedException(),
            };
        }
        private bool GetCombinationOrderLongerFirst()
        {
            return cbCombinationOrder.SelectedItem.ToString() switch
            {
                "Interval short/long" => false,
                "Interval long/short" => true,
                "Fewer/shorter words first" => false,
                "Fewer/longer words first" => true,
                "Greater/shorter words first" => false,
                "Greater/longer words first" => true,
                _ => throw new NotImplementedException(),
            };
        }

        private void OnBtnStartClick(object sender, EventArgs e)
        {
            StartProcess();
        }

        private void OnStartHashCatClick(object sender, EventArgs e)
        {
            StartProcess(true);
        }
        #endregion

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
            for (int i = 0; i < chkList.Items.Count; i++)
            {
                chkList.SetItemChecked(i, false);
            }
            if (!string.IsNullOrEmpty(dictionaries))
            {
                var splitEntries = dictionaries.Split(";", StringSplitOptions.RemoveEmptyEntries);
                
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
            btnStartHashCat.Enabled = (pnlCharacter.Visible && string.IsNullOrEmpty(txtIncludeWordsCharacter.Text)) || pnlDictionary.Visible;
        }

        private void OnCustomDictFirstCheckedChanged(object sender, EventArgs e)
        {
            chkDictFirstSkipDigits.Enabled = chkUseCustomDictFirst.Checked;
            chkDictFirstSkipSpecials.Enabled = chkUseCustomDictFirst.Checked;
            chkDictFirstForceLowercase.Enabled = chkUseCustomDictFirst.Checked;
            chkDictFirstAddTypos.Enabled = chkUseCustomDictFirst.Checked;
            chkDictFirstReverseOrder.Enabled = chkUseCustomDictFirst.Checked;
            chklDictionariesFirstWord.Enabled = chkUseCustomDictFirst.Checked;
            if (chkUseCustomDictFirst.Checked)
            {
                chkDictFirstSkipDigits.Checked = chkDictSkipDigits.Checked;
                chkDictFirstSkipSpecials.Checked = chkDictSkipSpecials.Checked;
                chkDictFirstForceLowercase.Checked = chkDictForceLowercase.Checked;
                chkDictFirstAddTypos.Checked = chkDictAddTypos.Checked;
                chkDictFirstReverseOrder.Checked = chkDictReverseOrder.Checked;
                var dictionaries = GetDictionary(chklDictionaries);
                SetDictionary(chklDictionariesFirstWord, dictionaries);
            }
            else
            {
                chkDictFirstSkipDigits.Checked = false;
                chkDictFirstSkipSpecials.Checked = false;
                chkDictFirstForceLowercase.Checked = false;
                chkDictFirstAddTypos.Checked = false;
                chkDictFirstReverseOrder.Checked = false;
                SetDictionary(chklDictionariesFirstWord, string.Empty);
            }
        }

        private void OnCustomDictLastCheckedChanged(object sender, EventArgs e)
        {
            chkDictLastSkipDigits.Enabled = chkUseCustomDictLast.Checked;
            chkDictLastSkipSpecials.Enabled = chkUseCustomDictLast.Checked;
            chkDictLastForceLowercase.Enabled = chkUseCustomDictLast.Checked;
            chkDictLastAddTypos.Enabled = chkUseCustomDictLast.Checked;
            chkDictLastReverseOrder.Enabled = chkUseCustomDictLast.Checked;
            chklDictionariesLastWord.Enabled = chkUseCustomDictLast.Checked;
            if (chkUseCustomDictLast.Checked)
            {
                chkDictLastSkipDigits.Checked = chkDictSkipDigits.Checked;
                chkDictLastSkipSpecials.Checked = chkDictSkipSpecials.Checked;
                chkDictLastForceLowercase.Checked = chkDictForceLowercase.Checked;
                chkDictLastAddTypos.Checked = chkDictAddTypos.Checked;
                chkDictLastReverseOrder.Checked = chkDictReverseOrder.Checked;
                var dictionaries = GetDictionary(chklDictionaries);
                SetDictionary(chklDictionariesLastWord, dictionaries);
            }
            else
            {
                chkDictLastSkipDigits.Checked = false;
                chkDictLastSkipSpecials.Checked = false;
                chkDictLastForceLowercase.Checked = false;
                chkDictLastAddTypos.Checked = false;
                chkDictLastReverseOrder.Checked = false;
                SetDictionary(chklDictionariesLastWord, string.Empty);
            }
        }

        private void OnTxtIncludeWordsCharacterTextChanged(object sender, EventArgs e)
        {
            btnStartHashCat.Enabled = pnlCharacter.Visible && string.IsNullOrEmpty(txtIncludeWordsCharacter.Text);
        }

        
    }
}

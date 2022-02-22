using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using RikTheVeggie;
using System.Collections;

namespace BruteForceHash.GUI
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();

            mnLoad.Click += OnLoadClick;
            mnSave.Click += OnSaveClick;
            mnQuickSave.Click += OnQuickSaveClick;
            mnQuickLoad.Click += OnQuickLoadClick;
            btnQuickLoad.Click += OnQuickLoadClick;
            btnQuickSave.Click += OnQuickSaveClick;
            mnQuickClean.Click += OnCleanQuickAndCustom;
            mnNew.Click += OnNewClick;
            mnRefresh.Click += OnRefreshClick;
            Directory.CreateDirectory("Templates");
            openFile.InitialDirectory = Directory.GetCurrentDirectory() + "\\Templates\\";
            saveFile.InitialDirectory = Directory.GetCurrentDirectory() + "\\Templates\\";
            openFile.Filter = "HBT files|*.hbt";
            saveFile.Filter = "HBT files|*.hbt";
            tvDictMain.TreeViewNodeSorter = new TreeViewSorter();
            tvDictFirstWord.TreeViewNodeSorter = new TreeViewSorter();
            tvDictLastWord.TreeViewNodeSorter = new TreeViewSorter();

            OnNewClick(this, null);
        }

        #region Button Clicks
        private void OnNewClick(object sender, EventArgs e)
        {
            cbMethod.SelectedIndex = 0;
            cbNbThreads.SelectedIndex = 7;
            cbWordsLimit.SelectedIndex = 2;
            cbCombinationOrder.SelectedIndex = 0;
            btnStart.Enabled = false;
            btnQuickSave.Enabled = false;
            btnQuickLoad.Enabled = false;
            chkVerbose.Checked = true;
            chkUtf8Toggle.Checked = false;

            SetDictionary(tvDictMain, string.Empty);
            chkDictSkipDigits.Checked = false;
            chkDictSkipSpecials.Checked = true;
            chkDictForceLowercase.Checked = true;
            chkDictAddTypos.Checked = false;
            chkDictReverseOrder.Checked = false;

            chkUseCustomDictFirst.Checked = false;
            SetDictionary(tvDictFirstWord, string.Empty);
            chkDictFirstSkipDigits.Checked = false;
            chkDictFirstSkipSpecials.Checked = false;
            chkDictFirstForceLowercase.Checked = false;
            chkDictFirstAddTypos.Checked = false;
            chkDictFirstReverseOrder.Checked = false;

            chkUseCustomDictLast.Checked = false;
            SetDictionary(tvDictLastWord, string.Empty);
            chkDictLastSkipDigits.Checked = false;
            chkDictLastSkipSpecials.Checked = false;
            chkDictLastForceLowercase.Checked = false;
            chkDictLastAddTypos.Checked = false;
            chkDictLastReverseOrder.Checked = false;

            chkTyposDoubleLetter.Checked = true;
            chkTyposExtraLetter.Checked = true;
            chkTyposLetterSwap.Checked = true;
            chkTyposReverseLetter.Checked = true;
            chkTyposSkipLetter.Checked = true;
            chkTyposWrongLetter.Checked = true;

            txtDictCustWords.Text = string.Empty;
            txtDictFirstCustWords.Text = string.Empty;
            txtDictLastCustWords.Text = string.Empty;
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
            txtDictionaryFilterFirst.Text = string.Empty;

            //Dictionary Advanced
            chkDictionaryAdvanced.Checked = false;
            chkOnlyFirstTwoWordsConcat.Checked = false;
            chkOnlyLastTwoWordsConcat.Checked = false;
            cbMaxDelim.SelectedIndex = 0;
            cbMinDelim.SelectedIndex = 0;
            cbMaxConcatWords.SelectedIndex = 10;
            cbMinConcatWords.SelectedIndex = 0;
            cbMaxWordLength.SelectedIndex = 49;
            cbMinWordLength.SelectedIndex = 0;
            cbMaxOnes.SelectedIndex = 10;
            cbMinOnes.SelectedIndex = 0;
            cbMaxConsecutiveOnes.SelectedIndex = 9;
            cbMinWordsLimit.SelectedIndex = 0;
            cbMaxConsecutiveConcat.SelectedIndex = 9;
            cbMinConsecutiveConcat.SelectedIndex = 0;

            txtHashCatPath.Text = "Tools\\Hashcat\\hashcat.exe";

            OnCustomDictFirstCheckedChanged(this, null);
            OnCustomDictLastCheckedChanged(this, null);
            OnDictionaryAdvancedCheckedChanged(this, null);

            chklCharsets.Items.Clear();
            var charsets = Charsets.GetCharsetList().Keys;
            foreach (var charset in charsets)
            {
                chklCharsets.Items.Add(charset);
            }
            PreviewCharsets();
            LoadDictionaries();
            LoadPatternSamples();

            pnlDictionary.Visible = true;
            pnlCharacter.Visible = false;
            btnStartHashCat.Enabled = ShouldEnableHashCat();
        }

        private void OnSaveClick(object sender, EventArgs e)
        {
            var result = saveFile.ShowDialog();
            if (result == DialogResult.OK)
            {
                SaveHBT(saveFile.FileName);
            }
        }

        private void OnLoadClick(object sender, EventArgs e)
        {
            var result = openFile.ShowDialog();
            if (result == DialogResult.OK)
            {
                LoadHBT(openFile.FileName);
            }
        }

        private void OnQuickSaveClick(object sender, EventArgs e)
        {
            var hex = GetHex();
            var hexFolder = GetHexFolder();
            if (IsValidHex())
            {
                var fileName = $"{hexFolder}\\[{hex}].hbt";
                SaveHBT(fileName);
                btnQuickLoad.Enabled = true;
            }
        }

        private void OnQuickLoadClick(object sender, EventArgs e)
        {
            var hex = GetHex();
            var hexFolder = GetHexFolder();
            var fileName = $"{hexFolder}\\[{hex}].hbt";
            if (!string.IsNullOrEmpty(hex) && File.Exists(fileName))
            {
                LoadHBT(fileName);
            }
        }

        private void OnRefreshClick(object sender, EventArgs e)
        {
            var dictionaries = GetDictionary(tvDictMain);
            var dictionariesFirstWord = GetDictionary(tvDictFirstWord);
            var dictionariesLastWord = GetDictionary(tvDictLastWord);

            LoadDictionaries();
            LoadPatternSamples();

            SetDictionary(tvDictMain, dictionaries);
            SetDictionary(tvDictFirstWord, dictionariesFirstWord);
            SetDictionary(tvDictLastWord, dictionariesLastWord);
        }

        private void LoadDictionaries()
        {
            tvDictMain.BeginUpdate();
            tvDictFirstWord.BeginUpdate();
            tvDictLastWord.BeginUpdate();
            tvDictMain.Nodes.Clear();
            tvDictFirstWord.Nodes.Clear();
            tvDictLastWord.Nodes.Clear();
            if (Directory.Exists("Dictionaries"))
            {
                var allDictionaries = Directory.GetFiles("Dictionaries", "*.dic");
                foreach (var dictionaryPath in allDictionaries)
                {
                    var filename = Path.GetFileName(dictionaryPath);
                    AddDictionaryToTreeView(tvDictMain, filename, dictionaryPath);
                    AddDictionaryToTreeView(tvDictFirstWord, filename, dictionaryPath);
                    AddDictionaryToTreeView(tvDictLastWord, filename, dictionaryPath);
                }
            }
            else
            {
                Directory.CreateDirectory("Dictionaries");
            }
            tvDictMain.Sort();
            tvDictFirstWord.Sort();
            tvDictLastWord.Sort();
            tvDictMain.EndUpdate();
            tvDictFirstWord.EndUpdate();
            tvDictLastWord.EndUpdate();
        }

        private void AddDictionaryToTreeView(TreeView tv, string filename, string dictionaryPath)
        {
            var dictionaryFiles = Regex.Split(filename, @"\[(.*?)\]", RegexOptions.Compiled).Where(p => !string.IsNullOrEmpty(p)).ToArray();
            var lastKey = string.Empty;
            var currentNodeCollection = tv.Nodes;
            for (int i = 0; i < dictionaryFiles.Length; i++)
            {
                var last = i == dictionaryFiles.Length - 1;
                var label = dictionaryFiles[i];
                var key = $"{i}-{label}";
                if (!last)
                {
                    var currentNode = currentNodeCollection.Find(key, false).FirstOrDefault();
                    if (currentNode == null)
                    {
                        currentNode = new TreeNode($" -{label}-");
                        currentNode.Name = key;
                        currentNodeCollection.Add(currentNode);
                    }
                    currentNodeCollection = currentNode.Nodes;
                    continue;
                }
                else
                {
                    var nbrLines = File.ReadAllLines(dictionaryPath).Length;
                    var lastNode = new TreeNode($" {label.Replace(".dic", "", StringComparison.InvariantCultureIgnoreCase)} ~{nbrLines} words");
                    lastNode.Name = dictionaryPath;
                    currentNodeCollection.Add(lastNode);
                }
            }
        }

        private void LoadPatternSamples()
        {
            cbExcludePatternsSamples.Items.Clear();
            cbIncludePatternsSamples.Items.Clear();

            if (!Directory.Exists("PatternsSamples"))
            {
                Directory.CreateDirectory("PatternsSamples");
            }
            if (File.Exists("PatternsSamples\\exclude_patterns.txt"))
            {
                var excludePatternSample = File.ReadAllLines("PatternsSamples\\exclude_patterns.txt");
                cbExcludePatternsSamples.Items.AddRange(excludePatternSample);
            }
            if (File.Exists("PatternsSamples\\include_patterns.txt"))
            {
                var includePatternSample = File.ReadAllLines("PatternsSamples\\include_patterns.txt");
                cbIncludePatternsSamples.Items.AddRange(includePatternSample);
            }
        }

        private void StartProcess(bool useHashCat = false)
        {
            var hex = GetHex();
            var hexFolder = GetHexFolder();

            SaveCustomDictionaries();
            var dictionaries = GetDictionary(tvDictMain);
            if (File.Exists($"{hexFolder}\\[{hex}].dic"))
            {
                dictionaries = $"{hexFolder}\\[{hex}].dic;" + dictionaries;
            }
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
                dictionariesFirstWord = GetDictionary(tvDictFirstWord);
                if (File.Exists($"{hexFolder}\\[{hex}][1st].dic"))
                {
                    dictionariesFirstWord = $"{hexFolder}\\[{hex}][1st].dic;" + dictionariesFirstWord;
                }
            }
            if (chkUseCustomDictLast.Checked)
            {
                dictLastSkipDigits = chkDictLastSkipDigits.Checked;
                dictLastSkipSpecial = chkDictLastSkipSpecials.Checked;
                dictLastForceLowercase = chkDictLastForceLowercase.Checked;
                dictLastAddTypos = chkDictLastAddTypos.Checked;
                dictLastReverseOrder = chkDictLastReverseOrder.Checked;
                dictionariesLastWord = GetDictionary(tvDictLastWord);
                if (File.Exists($"{hexFolder}\\[{hex}][Last].dic"))
                {
                    dictionariesLastWord = $"{hexFolder}\\[{hex}][Last].dic;" + dictionariesLastWord;
                }
            }

            var useUtf8 = !useHashCat && chkUtf8Toggle.Checked;
            var useDictAdvanced = chkDictionaryAdvanced.Checked;

            using (var process = new Process())
            {
                process.StartInfo.FileName = "BruteForceHash.exe";
                if (cbMethod.SelectedItem.ToString() == "Dictionary")
                {
                    process.StartInfo.Arguments = $"--nbr_threads {cbNbThreads.SelectedItem} " +
                                                    $"--method {(useDictAdvanced ? "dictionary_advanced" : useHashCat ? "dictionary_hashcat" : cbMethod.SelectedItem)} " +
                                                    $"--words_limit {cbWordsLimit.SelectedItem} " +
                                                    $"--min_words_limit {cbMinWordsLimit.SelectedItem} " +
                                                    $"--max_delimiters {cbMaxDelim.SelectedItem} " +
                                                    $"--min_delimiters {cbMinDelim.SelectedItem} " +
                                                    $"--max_concatenated_words {cbMaxConcatWords.SelectedItem} " +
                                                    $"--min_concatenated_words {cbMinConcatWords.SelectedItem} " +
                                                    $"{(chkOnlyLastTwoWordsConcat.Checked ? "--only_last_two_concatenated" : "")} " +
                                                    $"{(chkOnlyFirstTwoWordsConcat.Checked ? "--only_first_two_concatenated" : "")} " +
                                                    $"--max_consecutive_concatenation_limit {cbMaxConsecutiveConcat.SelectedItem} " +
                                                    $"--min_consecutive_concatenation_limit {cbMinConsecutiveConcat.SelectedItem} " +
                                                    $"--max_word_length {cbMaxWordLength.SelectedItem} " +
                                                    $"--min_word_length {cbMinWordLength.SelectedItem} " +
                                                    $"--max_ones {cbMaxOnes.SelectedItem} " +
                                                    $"--min_ones {cbMinOnes.SelectedItem} " +
                                                    $"--max_consecutive_ones {cbMaxConsecutiveOnes.SelectedItem} " +
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
                                                    $"{(chkTyposLetterSwap.Checked ? "--typos_enable_letter_swap" : "")} " +
                                                    $"{(chkTyposSkipLetter.Checked ? "--typos_enable_skip_letter" : "")} " +
                                                    $"{(chkTyposDoubleLetter.Checked ? "--typos_enable_double_letter" : "")} " +
                                                    $"{(chkTyposExtraLetter.Checked ? "--typos_enable_extra_letter" : "")} " +
                                                    $"{(chkTyposWrongLetter.Checked ? "--typos_enable_wrong_letter" : "")} " +
                                                    $"{(chkTyposReverseLetter.Checked ? "--typos_enable_reverse_letter" : "")} " +
                                                    $"--order_algorithm {GetCombinationOrderName()} " +
                                                    $"{(GetCombinationOrderLongerFirst() ? "--order_longer_words_first" : "")} " +
                                                    $"{(chkVerbose.Checked ? "--verbose" : "")} " +
                                                    $"--confirm_end " +
                                                    $"--dictionaries \"{dictionaries}\" " +
                                                    $"--dictionaries_first_word \"{dictionariesFirstWord}\" " +
                                                    $"--dictionaries_last_word \"{dictionariesLastWord}\" " +
                                                    $"--include_word \"{txtIncludeWord.Text.Trim()}\" " +
                                                    $"--dictionary_filter_first \"{txtDictionaryFilterFirst.Text.Trim()}\" " +
                                                    $"{(chkIncludeWordNotFirst.Checked ? "--include_word_not_first" : "")} " +
                                                    $"{(chkIncludeWordNotLast.Checked ? "--include_word_not_last" : "")} " +
                                                    $"--include_patterns \"{txtIncludePatterns.Text.Trim()}\" " +
                                                    $"--exclude_patterns \"{txtExcludePatterns.Text.Trim()}\" " +
                                                    $"--delimiter \"{txtDelimiter.Text.Trim()}\" " +
                                                    $"--prefix \"{txtPrefix.Text.Trim()}\" " +
                                                    $"--suffix \"{txtSuffix.Text.Trim()}\" " +
                                                    $"--path_hashcat \"{txtHashCatPath.Text.Trim()}\" " +
                                                    $"--hex_value \"{txtHexValues.Text.Trim()}\"";
                }
                else
                {
                    PreviewCharsets();
                    process.StartInfo.Arguments = $"--nbr_threads {cbNbThreads.SelectedItem} " +
                                                    $"--method {(useUtf8 ? "character_utf8" : useHashCat ? "character_hashcat" : cbMethod.SelectedItem)} " +
                                                    $"{(chkVerbose.Checked ? "--verbose" : "")} " +
                                                    $"--confirm_end " +
                                                    $"--valid_chars \"{txtValidCharsPreview.Text.Trim().Replace("\\", "\\\\").Replace("\"", "\\\"")}\" " +
                                                    $"--valid_starting_chars \"{txtStartingValidCharsPreview.Text.Trim().Replace("\\", "\\\\").Replace("\"", "\\\"")}\" " +
                                                    $"--start_position \"{numStartPosition.Value}\" " +
                                                    $"--end_position \"{numEndPosition.Value}\" " +
                                                    $"--include_word \"{txtIncludeWordsCharacter.Text.Trim()}\" " +
                                                    $"--prefix \"{txtPrefix.Text.Trim()}\" " +
                                                    $"--suffix \"{txtSuffix.Text.Trim()}\" " +
                                                    $"--path_hashcat \"{txtHashCatPath.Text.Trim()}\" " +
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

        private void SaveHBT(string fileName)
        {
            var dictionaries = GetDictionary(tvDictMain);
            var dictionariesFirstWord = GetDictionary(tvDictFirstWord);
            var dictionariesLastWord = GetDictionary(tvDictLastWord);
            var charsets = new List<string>();
            foreach (var charset in chklCharsets.CheckedItems)
                charsets.Add(charset.ToString());

            var hbtObject = new HbtFile()
            {
                Method = cbMethod.SelectedItem.ToString(),
                NbrThreads = Convert.ToInt32(cbNbThreads.SelectedItem),
                WordsLimit = Convert.ToInt32(cbWordsLimit.SelectedItem),
                Order = cbCombinationOrder.SelectedItem.ToString(),
                Verbose = chkVerbose.Checked,
                EnableUtf8 = chkUtf8Toggle.Checked,
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
                TyposEnableDoubleLetter = chkTyposDoubleLetter.Checked,
                TyposEnableExtraLetter = chkTyposExtraLetter.Checked,
                TyposEnableLetterSwap = chkTyposLetterSwap.Checked,
                TyposEnableReverseLetter = chkTyposReverseLetter.Checked,
                TyposEnableSkipLetter = chkTyposSkipLetter.Checked,
                TyposEnableWrongLetter = chkTyposWrongLetter.Checked,
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
                Charsets = charsets,
                StartPosition = Convert.ToInt32(numStartPosition.Value),
                EndPosition = Convert.ToInt32(numEndPosition.Value),
                HexValue = txtHexValues.Text.Trim(),
                PathHashCat = txtHashCatPath.Text.Trim(),
                DictionaryFilterFirst = txtDictionaryFilterFirst.Text.Trim(),
                //Advanced
                DictionaryAdvanced = chkDictionaryAdvanced.Checked,
                ConcatenateFirstTwoWords = chkOnlyFirstTwoWordsConcat.Checked,
                ConcatenateLastTwoWords = chkOnlyLastTwoWordsConcat.Checked,
                MaxDelimiters = Convert.ToInt32(cbMaxDelim.SelectedItem),
                MinDelimiters = Convert.ToInt32(cbMinDelim.SelectedItem),
                MaxConcatenatedWords = Convert.ToInt32(cbMaxConcatWords.SelectedItem),
                MinConcatenatedWords = Convert.ToInt32(cbMinConcatWords.SelectedItem),
                MaxWordLength = Convert.ToInt32(cbMaxWordLength.SelectedItem),
                MinWordLength = Convert.ToInt32(cbMinWordLength.SelectedItem),
                MaxOnes = Convert.ToInt32(cbMaxOnes.SelectedItem),
                MinOnes = Convert.ToInt32(cbMinOnes.SelectedItem),
                MaxConsecutiveOnes = Convert.ToInt32(cbMaxConsecutiveOnes.SelectedItem),
                MinWordsLimit = Convert.ToInt32(cbMinWordsLimit.SelectedItem),
                MaxConsecutiveConcatenation = Convert.ToInt32(cbMaxConsecutiveConcat.SelectedItem),
                MinConsecutiveConcatenation = Convert.ToInt32(cbMinConsecutiveConcat.SelectedItem),
            };
            File.WriteAllText(fileName, JsonConvert.SerializeObject(hbtObject));
            SaveCustomDictionaries();
        }

        public void LoadHBT(string fileName)
        {
            var hbtObject = JsonConvert.DeserializeObject<HbtFile>(File.ReadAllText(fileName));
            cbMethod.SelectedItem = hbtObject.Method;
            cbNbThreads.SelectedItem = hbtObject.NbrThreads.ToString();
            cbWordsLimit.SelectedItem = hbtObject.WordsLimit.ToString();
            cbCombinationOrder.SelectedItem = hbtObject.Order;
            chkVerbose.Checked = hbtObject.Verbose;
            chkUtf8Toggle.Checked = hbtObject.EnableUtf8;

            SetDictionary(tvDictMain, hbtObject.Dictionaries);
            chkDictSkipDigits.Checked = hbtObject.DictionariesSkipDigits;
            chkDictSkipSpecials.Checked = hbtObject.DictionariesSkipSpecials;
            chkDictForceLowercase.Checked = hbtObject.DictionariesForceLowercase;
            chkDictAddTypos.Checked = hbtObject.DictionariesAddTypos;
            chkDictReverseOrder.Checked = hbtObject.DictionariesReverseTypos;

            chkUseCustomDictFirst.Checked = hbtObject.UseDictionaryFirstWord;
            SetDictionary(tvDictFirstWord, hbtObject.DictionariesFirstWord);
            chkDictFirstSkipDigits.Checked = hbtObject.DictionariesFirstWordSkipDigits;
            chkDictFirstSkipSpecials.Checked = hbtObject.DictionariesFirstWordSkipSpecials;
            chkDictFirstForceLowercase.Checked = hbtObject.DictionariesFirstWordForceLowercase;
            chkDictFirstAddTypos.Checked = hbtObject.DictionariesFirstWordAddTypos;
            chkDictFirstReverseOrder.Checked = hbtObject.DictionariesFirstWordReverseTypos;

            chkUseCustomDictLast.Checked = hbtObject.UseDictionaryLastWord;
            SetDictionary(tvDictLastWord, hbtObject.DictionariesLastWord);
            chkDictLastSkipDigits.Checked = hbtObject.DictionariesLastWordSkipDigits;
            chkDictLastSkipSpecials.Checked = hbtObject.DictionariesLastWordSkipSpecials;
            chkDictLastForceLowercase.Checked = hbtObject.DictionariesLastWordForceLowercase;
            chkDictLastAddTypos.Checked = hbtObject.DictionariesLastWordAddTypos;
            chkDictLastReverseOrder.Checked = hbtObject.DictionariesLastWordReverseTypos;
            chkTyposDoubleLetter.Checked = hbtObject.TyposEnableDoubleLetter;
            chkTyposExtraLetter.Checked = hbtObject.TyposEnableExtraLetter;
            chkTyposLetterSwap.Checked = hbtObject.TyposEnableLetterSwap;
            chkTyposReverseLetter.Checked = hbtObject.TyposEnableReverseLetter;
            chkTyposSkipLetter.Checked = hbtObject.TyposEnableSkipLetter;
            chkTyposWrongLetter.Checked = hbtObject.TyposEnableWrongLetter;

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
            txtDictionaryFilterFirst.Text = hbtObject.DictionaryFilterFirst;
            numStartPosition.Value = hbtObject.StartPosition;
            numEndPosition.Value = hbtObject.EndPosition;
            txtHexValues.Text = hbtObject.HexValue;
            txtHashCatPath.Text = hbtObject.PathHashCat;

            for (int i = 0; i < chklCharsets.Items.Count; i++)
            {
                chklCharsets.SetItemChecked(i, false);
            }
            if (hbtObject.Charsets != null)
            {
                foreach (var charset in hbtObject.Charsets)
                {
                    for (int i = 0; i < chklCharsets.Items.Count; i++)
                    {
                        if (chklCharsets.Items[i].ToString() == charset)
                        {
                            chklCharsets.SetItemChecked(i, true);
                            break;
                        }
                    }
                }
            }
            PreviewCharsets();

            //Advanced
            chkDictionaryAdvanced.Checked = hbtObject.DictionaryAdvanced;
            chkOnlyFirstTwoWordsConcat.Checked = hbtObject.ConcatenateFirstTwoWords;
            chkOnlyLastTwoWordsConcat.Checked = hbtObject.ConcatenateLastTwoWords;
            cbMaxDelim.SelectedItem = hbtObject.MaxDelimiters.ToString();
            cbMinDelim.SelectedItem = hbtObject.MinDelimiters.ToString();
            cbMaxConcatWords.SelectedItem = hbtObject.MaxConcatenatedWords.ToString();
            cbMinConcatWords.SelectedItem = hbtObject.MinConcatenatedWords.ToString();
            cbMaxWordLength.SelectedItem = hbtObject.MaxWordLength.ToString();
            cbMinWordLength.SelectedItem = hbtObject.MinWordLength.ToString();
            cbMaxOnes.SelectedItem = hbtObject.MaxOnes.ToString();
            cbMinOnes.SelectedItem = hbtObject.MinOnes.ToString();
            cbMaxConsecutiveOnes.SelectedItem = hbtObject.MaxConsecutiveOnes.ToString();
            cbMinWordsLimit.SelectedItem = hbtObject.MinWordsLimit.ToString();
            cbMaxConsecutiveConcat.SelectedItem = hbtObject.MaxConsecutiveConcatenation.ToString();
            cbMinConsecutiveConcat.SelectedItem = hbtObject.MinConsecutiveConcatenation.ToString();

            LoadCustomDictionaries();
        }

        public void OnCleanQuickAndCustom(object sender, EventArgs e)
        {
            var hex = GetHex();
            var hexFolder = GetHexFolder();

            if (!string.IsNullOrEmpty(hex) && File.Exists($"{hexFolder}\\[{hex}].hbt"))
            {
                File.Delete($"{hexFolder}\\[{hex}].hbt");
            }

            if (!string.IsNullOrEmpty(hex) && File.Exists($"{hexFolder}\\[{hex}].dic"))
            {
                File.Delete($"{hexFolder}\\[{hex}].dic");
            }
            if (!string.IsNullOrEmpty(hex) && File.Exists($"{hexFolder}\\[{hex}][1st].dic"))
            {
                File.Delete($"{hexFolder}\\[{hex}][1st].dic");
            }
            if (!string.IsNullOrEmpty(hex) && File.Exists($"{hexFolder}\\[{hex}][Last].dic"))
            {
                File.Delete($"{hexFolder}\\[{hex}][Last].dic");
            }
            Directory.Delete(hexFolder);
        }

        private void SaveCustomDictionaries()
        {
            var hex = GetHex();
            var hexFolder = GetHexFolder();

            if (IsValidHex())
            {
                File.WriteAllText($"{hexFolder}\\[{hex}].dic", txtDictCustWords.Text);
                File.WriteAllText($"{hexFolder}\\[{hex}][1st].dic", txtDictFirstCustWords.Text);
                File.WriteAllText($"{hexFolder}\\[{hex}][Last].dic", txtDictLastCustWords.Text);
            }
        }

        private void LoadCustomDictionaries()
        {
            var hex = GetHex();
            var hexFolder = GetHexFolder();

            if (!string.IsNullOrEmpty(hex) && File.Exists($"{hexFolder}\\[{hex}].dic"))
            {
                txtDictCustWords.Text = File.ReadAllText($"{hexFolder}\\[{hex}].dic");
            }
            if (!string.IsNullOrEmpty(hex) && File.Exists($"{hexFolder}\\[{hex}][1st].dic"))
            {
                txtDictFirstCustWords.Text = File.ReadAllText($"{hexFolder}\\[{hex}][1st].dic");
            }
            if (!string.IsNullOrEmpty(hex) && File.Exists($"{hexFolder}\\[{hex}][Last].dic"))
            {
                txtDictLastCustWords.Text = File.ReadAllText($"{hexFolder}\\[{hex}][Last].dic");
            }
        }
        #endregion

        private string GetDictionary(TriStateTreeView tv)
        {
            var allDictionaries = Directory.GetFiles("Dictionaries", "*.dic");
            return GetDictionaryRec(tv.Nodes, string.Empty, allDictionaries);
        }

        private string GetDictionaryRec(TreeNodeCollection trc, string output, string[] allDictionaries)
        {
            if (trc != null)
            {
                foreach (TreeNode node in trc)
                {
                    var dictStr = node.Name;
                    if (!string.IsNullOrEmpty(dictStr))
                    {
                        var dictPath = allDictionaries.FirstOrDefault(p => p.EndsWith(dictStr));
                        if (!string.IsNullOrEmpty(dictPath) && node.Checked)
                            output += $"{dictPath};";
                    }
                    output = GetDictionaryRec(node.Nodes, output, allDictionaries);
                }
            }
            return output;
        }

        private void SetDictionary(TriStateTreeView tv, string dictionaries)
        {
            for (int i = 0; i < tv.Nodes.Count; i++)
            {
                tv.Nodes[i].Checked = false;
            }
            if (!string.IsNullOrEmpty(dictionaries))
            {
                var splitEntries = dictionaries.Split(";", StringSplitOptions.RemoveEmptyEntries);

                foreach (var entry in splitEntries)
                {
                    var node = tv.Nodes.Find(entry, true).FirstOrDefault();
                    if (node != null)
                    {
                        node.Checked = true;
                    }
                }
            }
            SetDictionaryCheckChecked(tv.Nodes, null);
        }

        private bool SetDictionaryCheckChecked(TreeNodeCollection trc, TreeNode parentNode)
        {
            bool shouldCheck = true;
            foreach (TreeNode node in trc)
            {
                if (node.Nodes != null && node.Nodes.Count != 0)
                    shouldCheck = SetDictionaryCheckChecked(node.Nodes, node);

                if (!node.Checked)
                    shouldCheck = false;
            }
            if (shouldCheck && parentNode != null)
            {
                parentNode.Checked = true;
            }
            return shouldCheck;
        }

        private void OnCbMethodChanged(object sender, EventArgs e)
        {
            pnlDictionary.Visible = cbMethod.SelectedItem == null || cbMethod.SelectedItem.ToString() == "Dictionary";
            pnlCharacter.Visible = !pnlDictionary.Visible;
            btnStartHashCat.Enabled = ShouldEnableHashCat();
        }

        private void OnCustomDictFirstCheckedChanged(object sender, EventArgs e)
        {
            chkDictFirstSkipDigits.Enabled = chkUseCustomDictFirst.Checked;
            chkDictFirstSkipSpecials.Enabled = chkUseCustomDictFirst.Checked;
            chkDictFirstForceLowercase.Enabled = chkUseCustomDictFirst.Checked;
            chkDictFirstAddTypos.Enabled = chkUseCustomDictFirst.Checked;
            chkDictFirstReverseOrder.Enabled = chkUseCustomDictFirst.Checked;
            tvDictFirstWord.Enabled = chkUseCustomDictFirst.Checked;
            if (chkUseCustomDictFirst.Checked)
            {
                chkDictFirstSkipDigits.Checked = chkDictSkipDigits.Checked;
                chkDictFirstSkipSpecials.Checked = chkDictSkipSpecials.Checked;
                chkDictFirstForceLowercase.Checked = chkDictForceLowercase.Checked;
                chkDictFirstAddTypos.Checked = chkDictAddTypos.Checked;
                chkDictFirstReverseOrder.Checked = chkDictReverseOrder.Checked;
            }
            else
            {
                chkDictFirstSkipDigits.Checked = false;
                chkDictFirstSkipSpecials.Checked = false;
                chkDictFirstForceLowercase.Checked = false;
                chkDictFirstAddTypos.Checked = false;
                chkDictFirstReverseOrder.Checked = false;
            }
        }

        private void OnCustomDictLastCheckedChanged(object sender, EventArgs e)
        {
            chkDictLastSkipDigits.Enabled = chkUseCustomDictLast.Checked;
            chkDictLastSkipSpecials.Enabled = chkUseCustomDictLast.Checked;
            chkDictLastForceLowercase.Enabled = chkUseCustomDictLast.Checked;
            chkDictLastAddTypos.Enabled = chkUseCustomDictLast.Checked;
            chkDictLastReverseOrder.Enabled = chkUseCustomDictLast.Checked;
            tvDictLastWord.Enabled = chkUseCustomDictLast.Checked;
            if (chkUseCustomDictLast.Checked)
            {
                chkDictLastSkipDigits.Checked = chkDictSkipDigits.Checked;
                chkDictLastSkipSpecials.Checked = chkDictSkipSpecials.Checked;
                chkDictLastForceLowercase.Checked = chkDictForceLowercase.Checked;
                chkDictLastAddTypos.Checked = chkDictAddTypos.Checked;
                chkDictLastReverseOrder.Checked = chkDictReverseOrder.Checked;
            }
            else
            {
                chkDictLastSkipDigits.Checked = false;
                chkDictLastSkipSpecials.Checked = false;
                chkDictLastForceLowercase.Checked = false;
                chkDictLastAddTypos.Checked = false;
                chkDictLastReverseOrder.Checked = false;
            }
        }

        private void OnTxtIncludeWordsCharacterTextChanged(object sender, EventArgs e)
        {
            btnStartHashCat.Enabled = ShouldEnableHashCat();
        }

        private void OnDictionaryAdvancedCheckedChanged(object sender, EventArgs e)
        {
            chkOnlyFirstTwoWordsConcat.Enabled = chkDictionaryAdvanced.Checked;
            chkOnlyLastTwoWordsConcat.Enabled = chkDictionaryAdvanced.Checked;
            cbMaxConcatWords.Enabled = chkDictionaryAdvanced.Checked;
            cbMinConcatWords.Enabled = chkDictionaryAdvanced.Checked;
            cbMaxDelim.Enabled = chkDictionaryAdvanced.Checked;
            cbMinDelim.Enabled = chkDictionaryAdvanced.Checked;
            cbMaxWordLength.Enabled = chkDictionaryAdvanced.Checked;
            cbMinWordLength.Enabled = chkDictionaryAdvanced.Checked;
            cbMaxOnes.Enabled = chkDictionaryAdvanced.Checked;
            cbMinOnes.Enabled = chkDictionaryAdvanced.Checked;
            cbMaxConsecutiveOnes.Enabled = chkDictionaryAdvanced.Checked;
            cbMinWordsLimit.Enabled = chkDictionaryAdvanced.Checked;
            cbMaxConsecutiveConcat.Enabled = chkDictionaryAdvanced.Checked;
            cbMinConsecutiveConcat.Enabled = chkDictionaryAdvanced.Checked;
            btnStartHashCat.Enabled = ShouldEnableHashCat();
        }

        private void Utf8ToggleCheckedChanged(object sender, EventArgs e)
        {
            btnStartHashCat.Enabled = ShouldEnableHashCat();
        }

        private void TxtValidCharsChanged(object sender, EventArgs e)
        {
            PreviewCharsets();
        }

        private void TxtStartingValidCharsChanged(object sender, EventArgs e)
        {
            PreviewCharsets();
        }

        private void ChklCharsetsSelectedIndexChanged(object sender, EventArgs e)
        {
            PreviewCharsets();
        }

        private void ChklCharsetsSelectedValueChanged(object sender, EventArgs e)
        {
            PreviewCharsets();
        }

        private void PreviewCharsets()
        {
            var charsets = Charsets.GetCharsetList();

            var validCharsPreview = txtValidChars.Text.Trim();
            var validCharsStartingPreview = txtStartingValidChars.Text.Trim();

            foreach (var charset in chklCharsets.CheckedItems)
            {
                if (charsets.ContainsKey(charset.ToString()))
                {
                    var charsetValue = charsets[charset.ToString()];
                    validCharsPreview += charsetValue;
                    validCharsStartingPreview += charsetValue;
                }
            }

            txtStartingValidCharsPreview.Text = string.Join("", validCharsStartingPreview.Distinct());
            txtValidCharsPreview.Text = string.Join("", validCharsPreview.Distinct());
        }

        private void btnDictUnselected_Click(object sender, EventArgs e)
        {
            foreach (TreeNode node in tvDictMain.Nodes)
            {
                node.Checked = false;
            }
        }

        private void btnDictFirstUnselected_Click(object sender, EventArgs e)
        {
            foreach (TreeNode node in tvDictFirstWord.Nodes)
            {
                node.Checked = false;
            }
        }

        private void btnDictLastUnselected_Click(object sender, EventArgs e)
        {
            foreach (TreeNode node in tvDictLastWord.Nodes)
            {
                node.Checked = false;
            }
        }

        private void cbExcludePatternsSamples_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbExcludePatternsSamples.SelectedItem != null)
            {
                txtExcludePatterns.Text = cbExcludePatternsSamples.SelectedItem?.ToString();
                cbExcludePatternsSamples.SelectedItem = null;
            }
        }

        private void cbIncludePatternsSamples_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbIncludePatternsSamples.SelectedItem != null)
            {
                txtIncludePatterns.Text = cbIncludePatternsSamples.SelectedItem?.ToString();
                cbIncludePatternsSamples.SelectedItem = null;
            }
        }

        private void btnCopyToDictFirst_Click(object sender, EventArgs e)
        {
            var dictionaries = GetDictionary(tvDictMain);
            SetDictionary(tvDictFirstWord, dictionaries);
        }

        private void btnCopyToDictLast_Click(object sender, EventArgs e)
        {
            var dictionaries = GetDictionary(tvDictMain);
            SetDictionary(tvDictLastWord, dictionaries);
        }

        private string GetHex()
        {
            return txtHexValues.Text?.Trim()?.ToLower();
        }

        private string GetHexFolder(bool create = true)
        {
            var hex = GetHex();
            if (create && !Directory.Exists($"HexData\\[{hex}]"))
                Directory.CreateDirectory($"HexData\\[{hex}]");
            return $"HexData\\[{hex}]";
        }

        private bool ShouldEnableHashCat()
        {
            return IsValidHex() && ((pnlCharacter.Visible && !chkUtf8Toggle.Checked)); // || (pnlDictionary.Visible && !chkDictionaryAdvanced.Checked)) ;
        }

        private bool IsValidHex()
        {
            var hex = GetHex();
            return hex.Contains("0x") && hex.Length == 12;
        }

        private void txtHexValues_TextChanged(object sender, EventArgs e)
        {
            var hex = GetHex();
            var hexFolder = GetHexFolder(false);
            var isValidHex = IsValidHex();

            btnQuickSave.Enabled = isValidHex;

            var fileName = $"{hexFolder}\\[{hex}].hbt";
            btnQuickLoad.Enabled = isValidHex && File.Exists(fileName);

            btnStartHashCat.Enabled = ShouldEnableHashCat();
            btnStart.Enabled = IsValidHex();
        }
    }

    public class TreeViewSorter : IComparer
    {
        public int Compare(object x, object y)
        {
            var tx = x as TreeNode;
            var ty = y as TreeNode;

            if (tx.Nodes.Count > 0 && ty.Nodes.Count == 0)
                return -1;

            if (tx.Nodes.Count == 0 && ty.Nodes.Count > 0)
                return 1;

            return string.Compare(tx.Text, ty.Text);
        }
    }
}

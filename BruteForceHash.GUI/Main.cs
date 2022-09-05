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
        private static string _lastCommand = string.Empty;
        private bool _needOverrideConfirmation = false;

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
            cbNbThreads.SelectedIndex = 15;
            cbWordsLimit.SelectedIndex = 3;
            cbCombinationOrder.SelectedIndex = 0;
            btnStart.Enabled = false;
            btnQuickSave.Enabled = false;
            btnQuickLoad.Enabled = false;
            chkVerbose.Checked = true;
            chkUtf8Toggle.Checked = false;

            chkDictionariesUse.Checked = true;
            chkDictionariesCustomWordsUse.Checked = false;
            chkDictionariesExcludeWordsUse.Checked = false;
            SetDictionary(tvDictMain, string.Empty);
            chkDictSkipDigits.Checked = false;
            chkDictSkipSpecials.Checked = true;
            chkDictForceLowercase.Checked = true;
            chkDictAddTypos.Checked = false;
            chkDictReverseOrder.Checked = false;

            chkUseDictFirst.Checked = false;
            chkDictionariesFirstWordCustomWordsUse.Checked = false;
            chkDictionariesFirstWordExcludeWordsUse.Checked = false;
            SetDictionary(tvDictFirstWord, string.Empty);
            chkDictFirstSkipDigits.Checked = false;
            chkDictFirstSkipSpecials.Checked = false;
            chkDictFirstForceLowercase.Checked = false;
            chkDictFirstAddTypos.Checked = false;
            chkDictFirstReverseOrder.Checked = false;

            chkUseDictLast.Checked = false;
            chkDictionariesLastWordCustomWordsUse.Checked = false;
            chkDictionariesLastWordExcludeWordsUse.Checked = false;
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
            txtDictionaryFilterFirstFrom.Text = string.Empty;
            txtDictionaryFilterFirstTo.Text = string.Empty;

            //Dictionary Advanced
            chkDictionaryAdvanced.Checked = false;
            chkOnlyFirstTwoWordsConcat.Checked = false;
            chkOnlyLastTwoWordsConcat.Checked = false;
            cbCombinationOrder.SelectedIndex = 3;
            cbDictionariesCustomWordsMinimumInHash.SelectedIndex = 0;
            cbMaxDelim.SelectedIndex = 0;
            cbMinDelim.SelectedIndex = 0;
            cbMaxConcatWords.SelectedIndex = 2;
            cbMinConcatWords.SelectedIndex = 0;
            cbMaxWordLength.SelectedIndex = 49;
            cbMinWordLength.SelectedIndex = 0;
            cbMaxOnes.SelectedIndex = 2;
            cbMinOnes.SelectedIndex = 0;
            cbMaxTwos.SelectedIndex = 2;
            cbMinTwos.SelectedIndex = 0;
            cbMaxThrees.SelectedIndex = 2;
            cbMinThrees.SelectedIndex = 0;
            cbMaxFours.SelectedIndex = 2;
            cbMinFours.SelectedIndex = 0;
            cbAtLeastAboveNbrChars.SelectedIndex = 0;
            cbAtLeastAboveNbrWords.SelectedIndex = 0;
            cbAtLeastUnderNbrChars.SelectedIndex = 0;
            cbAtLeastUnderNbrWords.SelectedIndex = 0;
            cbAtMostAboveNbrChars.SelectedIndex = 0;
            cbAtMostAboveNbrWords.SelectedIndex = 0;
            cbAtMostUnderNbrChars.SelectedIndex = 0;
            cbAtMostUnderNbrWords.SelectedIndex = 0;
            cbMaxConsecutiveOnes.SelectedIndex = 1;
            cbMinWordsLimit.SelectedIndex = 0;
            cbMaxConsecutiveConcat.SelectedIndex = 1;
            cbMinConsecutiveConcat.SelectedIndex = 0;

            txtHashCatPath.Text = "Tools\\Hashcat\\hashcat.exe";

            chkDictionariesUse_CheckedChanged(this, null);
            chkDictionariesCustomWordsUse_CheckedChanged(this, null);
            chkDictionariesExcludeWordsUse_CheckedChanged(this, null);
            chkDictionariesFirstWordCustomWordsUse_CheckedChanged(this, null);
            chkDictionariesLastWordCustomWordsUse_CheckedChanged(this, null);
            chkDictionariesFirstWordExcludeWordsUse_CheckedChanged(this, null);
            chkDictionariesLastWordExcludeWordsUse_CheckedChanged(this, null);
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
                var allDictionaries = Directory.GetFiles("Dictionaries", "*.dic", SearchOption.AllDirectories);
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

            var dictionaries = string.Empty;
            var dictionariesCustom = string.Empty;
            var dictionariesExclude = string.Empty;
            var dictionariesFirstWordCustom = string.Empty;
            var dictionariesFirstWordExclude = string.Empty;
            var dictionariesLastWordCustom = string.Empty;
            var dictionariesLastWordExclude = string.Empty;
            var dictionariesFirstWord = string.Empty;
            var dictionariesLastWord = string.Empty;

            SaveCustomDictionaries();
            if(chkDictionariesUse.Checked)
                dictionaries = GetDictionary(tvDictMain);
            if (chkDictionariesCustomWordsUse.Checked && File.Exists($"{hexFolder}\\[{hex}].dic"))
                dictionariesCustom = $"{hexFolder}\\[{hex}].dic";
            if(chkDictionariesExcludeWordsUse.Checked && File.Exists($"{hexFolder}\\[{hex}][Exclude].dic"))
                dictionariesExclude = $"{hexFolder}\\[{hex}][Exclude].dic";

            if (chkUseDictFirst.Checked)
                dictionariesFirstWord = GetDictionary(tvDictFirstWord);
            if (chkDictionariesFirstWordCustomWordsUse.Checked && File.Exists($"{hexFolder}\\[{hex}][1st].dic"))
                dictionariesFirstWordCustom = $"{hexFolder}\\[{hex}][1st].dic";
            if (chkDictionariesFirstWordExcludeWordsUse.Checked && File.Exists($"{hexFolder}\\[{hex}][1st][Exclude].dic"))
                dictionariesFirstWordExclude = $"{hexFolder}\\[{hex}][1st][Exclude].dic";

            if (chkUseDictLast.Checked)
                dictionariesLastWord = GetDictionary(tvDictLastWord);
            if (chkDictionariesLastWordCustomWordsUse.Checked && File.Exists($"{hexFolder}\\[{hex}][Last].dic"))
                dictionariesLastWordCustom = $"{hexFolder}\\[{hex}][Last].dic";
            if (chkDictionariesLastWordExcludeWordsUse.Checked && File.Exists($"{hexFolder}\\[{hex}][Last][Exclude].dic"))
                dictionariesLastWordExclude = $"{hexFolder}\\[{hex}][Last][Exclude].dic";

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
                                                    $"--max_twos {cbMaxTwos.SelectedItem} " +
                                                    $"--min_twos {cbMinTwos.SelectedItem} " +
                                                    $"--max_threes {cbMaxThrees.SelectedItem} " +
                                                    $"--min_threes {cbMinThrees.SelectedItem} " +
                                                    $"--max_fours {cbMaxFours.SelectedItem} " +
                                                    $"--min_fours {cbMinFours.SelectedItem} " +
                                                    (cbAtLeastAboveNbrChars.SelectedIndex > 0 ? $"--at_least_gte_chars {cbAtLeastAboveNbrChars.SelectedIndex} " +
                                                    $"--at_least_gte_words {cbAtLeastAboveNbrWords.SelectedIndex} " : string.Empty) +
                                                    (cbAtLeastUnderNbrChars.SelectedIndex > 0 ? $"--at_least_lte_chars {cbAtLeastUnderNbrChars.SelectedIndex} " +
                                                    $"--at_least_lte_words {cbAtLeastUnderNbrWords.SelectedItem} " : string.Empty) +
                                                    (cbAtMostAboveNbrChars.SelectedIndex > 0 ? $"--at_most_gte_chars {cbAtMostAboveNbrChars.SelectedIndex} " +
                                                    $"--at_most_gte_words {cbAtMostAboveNbrWords.SelectedIndex} " : string.Empty) +
                                                    (cbAtMostUnderNbrChars.SelectedIndex > 0 ? $"--at_most_lte_chars {cbAtMostUnderNbrChars.SelectedIndex} " +
                                                    $"--at_most_lte_words {cbAtMostUnderNbrWords.SelectedItem} " : string.Empty) +
                                                    $"--max_consecutive_ones {cbMaxConsecutiveOnes.SelectedItem} " +
                                                    $"{(chkDictionariesUse.Checked && chkDictSkipDigits.Checked ? "--dictionaries_skip_digits" : "")} " +
                                                    $"{(chkDictionariesUse.Checked && chkDictSkipSpecials.Checked ? "--dictionaries_skip_specials" : "")} " +
                                                    $"{(chkDictionariesUse.Checked && chkDictForceLowercase.Checked ? "--dictionaries_force_lowercase" : "")} " +
                                                    $"{(chkDictionariesUse.Checked && chkDictAddTypos.Checked ? "--dictionaries_add_typos" : "")} " +
                                                    $"{(chkDictionariesUse.Checked && chkDictReverseOrder.Checked ? "--dictionaries_reverse_order" : "")} " +
                                                    $"{(chkDictionariesCustomWordsUse.Checked && chkDictCustomWordsSkipDigits.Checked ? "--dictionaries_custom_skip_digits" : "")} " +
                                                    $"{(chkDictionariesCustomWordsUse.Checked && chkDictCustomWordsSkipSpecials.Checked ? "--dictionaries_custom_skip_specials" : "")} " +
                                                    $"{(chkDictionariesCustomWordsUse.Checked && chkDictCustomWordsForceLowercase.Checked ? "--dictionaries_custom_force_lowercase" : "")} " +
                                                    $"{(chkDictionariesCustomWordsUse.Checked && chkDictCustomWordsAddTypos.Checked ? "--dictionaries_custom_add_typos" : "")} " +
                                                    (chkDictionariesCustomWordsUse.Checked ? $"--dictionaries_custom_min_words_hash {cbDictionariesCustomWordsMinimumInHash.SelectedItem} " : string.Empty) +
                                                    $"{(chkUseDictFirst.Checked && chkDictFirstSkipDigits.Checked ? "--dictionaries_first_skip_digits" : "")} " +
                                                    $"{(chkUseDictFirst.Checked && chkDictFirstSkipSpecials.Checked ? "--dictionaries_first_skip_specials" : "")} " +
                                                    $"{(chkUseDictFirst.Checked && chkDictFirstForceLowercase.Checked ? "--dictionaries_first_force_lowercase" : "")} " +
                                                    $"{(chkUseDictFirst.Checked && chkDictFirstAddTypos.Checked ? "--dictionaries_first_add_typos" : "")} " +
                                                    $"{(chkUseDictFirst.Checked && chkDictFirstReverseOrder.Checked ? "--dictionaries_first_reverse_order" : "")} " +
                                                    $"{(chkDictionariesFirstWordCustomWordsUse.Checked && chkDictFirstWordCustomWordsSkipDigits.Checked ? "--dictionaries_first_custom_skip_digits" : "")} " +
                                                    $"{(chkDictionariesFirstWordCustomWordsUse.Checked && chkDictFirstWordCustomWordsSkipSpecials.Checked ? "--dictionaries_first_custom_skip_specials" : "")} " +
                                                    $"{(chkDictionariesFirstWordCustomWordsUse.Checked && chkDictFirstWordCustomWordsForceLowercase.Checked ? "--dictionaries_first_custom_force_lowercase" : "")} " +
                                                    $"{(chkDictionariesFirstWordCustomWordsUse.Checked && chkDictFirstWordCustomWordsAddTypos.Checked ? "--dictionaries_first_custom_add_typos" : "")} " +
                                                    $"{(chkUseDictLast.Checked && chkDictLastSkipDigits.Checked ? "--dictionaries_last_skip_digits" : "")} " +
                                                    $"{(chkUseDictLast.Checked && chkDictLastSkipSpecials.Checked ? "--dictionaries_last_skip_specials" : "")} " +
                                                    $"{(chkUseDictLast.Checked && chkDictLastForceLowercase.Checked ? "--dictionaries_last_force_lowercase" : "")} " +
                                                    $"{(chkUseDictLast.Checked && chkDictLastAddTypos.Checked ? "--dictionaries_last_add_typos" : "")} " +
                                                    $"{(chkUseDictLast.Checked && chkDictLastReverseOrder.Checked ? "--dictionaries_last_reverse_order" : "")} " +
                                                    $"{(chkDictionariesLastWordCustomWordsUse.Checked && chkDictLastWordCustomWordsSkipDigits.Checked ? "--dictionaries_last_custom_skip_digits" : "")} " +
                                                    $"{(chkDictionariesLastWordCustomWordsUse.Checked && chkDictLastWordCustomWordsSkipSpecials.Checked ? "--dictionaries_last_custom_skip_specials" : "")} " +
                                                    $"{(chkDictionariesLastWordCustomWordsUse.Checked && chkDictLastWordCustomWordsForceLowercase.Checked ? "--dictionaries_last_custom_force_lowercase" : "")} " +
                                                    $"{(chkDictionariesLastWordCustomWordsUse.Checked && chkDictLastWordCustomWordsAddTypos.Checked ? "--dictionaries_last_add_custom_typos" : "")} " +
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
                                                    (chkDictionariesUse.Checked ? $"--dictionaries \"{dictionaries}\" " : string.Empty) +
                                                    (chkUseDictFirst.Checked ? $"--dictionaries_first_word \"{dictionariesFirstWord}\" " : string.Empty) +
                                                    (chkUseDictLast.Checked ? $"--dictionaries_last_word \"{dictionariesLastWord}\" " : string.Empty) +
                                                    (chkDictionariesCustomWordsUse.Checked ? $"--dictionaries_custom \"{dictionariesCustom}\" " : string.Empty) +
                                                    (chkDictionariesFirstWordCustomWordsUse.Checked ? $"--dictionaries_first_word_custom \"{dictionariesFirstWordCustom}\" " : string.Empty) +
                                                    (chkDictionariesLastWordCustomWordsUse.Checked ? $"--dictionaries_last_word_custom \"{dictionariesLastWordCustom}\" " : string.Empty) +
                                                    (chkDictionariesExcludeWordsUse.Checked ? $"--dictionaries_exclude \"{dictionariesExclude}\" " : string.Empty) +
                                                    $"{(chkDictionariesExcludeWordsUse.Checked && chkDictExcludePartialWords.Checked ? "--dictionaries_exclude_partial" : "")} " +
                                                    (chkDictionariesFirstWordExcludeWordsUse.Checked ? $"--dictionaries_first_word_exclude \"{dictionariesFirstWordExclude}\" " : string.Empty) +
                                                    $"{(chkDictionariesFirstWordExcludeWordsUse.Checked && chkDictFirstWordExcludePartialWords.Checked ? "--dictionaries_first_word_exclude_partial" : "")} " +
                                                    (chkDictionariesLastWordExcludeWordsUse.Checked ? $"--dictionaries_last_word_exclude \"{dictionariesLastWordExclude}\" " : string.Empty) +
                                                    $"{(chkDictionariesLastWordExcludeWordsUse.Checked && chkDictLastWordExcludePartialWords.Checked ? "--dictionaries_last_word_exclude_partial" : "")} " +
                                                    $"--include_word \"{txtIncludeWord.Text.Trim()}\" " +
                                                    (!string.IsNullOrEmpty(txtDictionaryFilterFirstFrom.Text.Trim()) ? $"--dictionary_filter_first_from \"{txtDictionaryFilterFirstFrom.Text.Trim()}\" " : string.Empty) +
                                                    (!string.IsNullOrEmpty(txtDictionaryFilterFirstTo.Text.Trim()) ? $"--dictionary_filter_first_to \"{txtDictionaryFilterFirstTo.Text.Trim()}\" " : string.Empty) +
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
                _lastCommand = process.StartInfo.Arguments;

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
            var hex = GetHex();
            if(_needOverrideConfirmation)
            {
                var hexFolder = GetHexFolder(false);
                var isValidHex = IsValidHex();
                var fileNameLoad = $"{hexFolder}\\[{hex}].hbt";

                if (File.Exists(fileNameLoad) && MessageBox.Show($"Do you want to override the current configuration for Hex 0x{hex:x}", "Warning", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    return;
                _needOverrideConfirmation = false;
            }

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
                UseMainDictionaries = chkDictionariesUse.Checked,
                Dictionaries = dictionaries,
                DictionariesSkipDigits = chkDictSkipDigits.Checked,
                DictionariesSkipSpecials = chkDictSkipSpecials.Checked,
                DictionariesForceLowercase = chkDictForceLowercase.Checked,
                DictionariesAddTypos = chkDictAddTypos.Checked,
                DictionariesReverseOrder = chkDictReverseOrder.Checked,
                DictionariesCustomWordsUse = chkDictionariesCustomWordsUse.Checked,
                DictionariesCustomWordsSkipDigits = chkDictCustomWordsSkipDigits.Checked,
                DictionariesCustomWordsSkipSpecials = chkDictCustomWordsSkipSpecials.Checked,
                DictionariesCustomWordsForceLowercase = chkDictCustomWordsForceLowercase.Checked,
                DictionariesCustomWordsAddTypos = chkDictCustomWordsAddTypos.Checked,
                DictionariesCustomWordsMinimumInHash = Convert.ToInt32(cbDictionariesCustomWordsMinimumInHash.SelectedItem),
                DictionariesExcludeWordsUse = chkDictionariesExcludeWordsUse.Checked,
                DictionariesExcludePartialWords = chkDictExcludePartialWords.Checked,
                DictionariesExcludeWords = txtDictExcludeWords.Text.Split("\r\n", StringSplitOptions.RemoveEmptyEntries).Select(p => p.Trim()).Distinct().OrderBy(p => p).ToList(),
                UseDictionaryFirstWord = chkUseDictFirst.Checked,
                DictionariesFirstWord = dictionariesFirstWord,
                DictionariesFirstWordSkipDigits = chkDictFirstSkipDigits.Checked,
                DictionariesFirstWordSkipSpecials = chkDictFirstSkipSpecials.Checked,
                DictionariesFirstWordForceLowercase = chkDictFirstForceLowercase.Checked,
                DictionariesFirstWordAddTypos = chkDictFirstAddTypos.Checked,
                DictionariesFirstWordReverseOrder = chkDictFirstReverseOrder.Checked,
                DictionariesFirstWordCustomWordsUse = chkDictionariesFirstWordCustomWordsUse.Checked,
                DictionariesFirstWordCustomWordsSkipDigits = chkDictFirstWordCustomWordsSkipDigits.Checked,
                DictionariesFirstWordCustomWordsSkipSpecials = chkDictFirstWordCustomWordsSkipSpecials.Checked,
                DictionariesFirstWordCustomWordsForceLowercase = chkDictFirstWordCustomWordsForceLowercase.Checked,
                DictionariesFirstWordCustomWordsAddTypos = chkDictFirstWordCustomWordsAddTypos.Checked,
                DictionariesFirstWordExcludeWordsUse = chkDictionariesFirstWordExcludeWordsUse.Checked,
                DictionariesFirstWordExcludePartialWords = chkDictFirstWordExcludePartialWords.Checked,
                DictionariesFirstWordExcludeWords = txtDictFirstWordExcludeWords.Text.Split("\r\n", StringSplitOptions.RemoveEmptyEntries).Select(p => p.Trim()).Distinct().OrderBy(p => p).ToList(),
                UseDictionaryLastWord = chkUseDictLast.Checked,
                DictionariesLastWord = dictionariesLastWord,
                DictionariesLastWordSkipDigits = chkDictLastSkipDigits.Checked,
                DictionariesLastWordSkipSpecials = chkDictLastSkipSpecials.Checked,
                DictionariesLastWordForceLowercase = chkDictLastForceLowercase.Checked,
                DictionariesLastWordAddTypos = chkDictLastAddTypos.Checked,
                DictionariesLastWordReverseOrder = chkDictLastReverseOrder.Checked,
                DictionariesLastWordCustomWordsUse = chkDictionariesLastWordCustomWordsUse.Checked,
                DictionariesLastWordCustomWordsSkipDigits = chkDictLastWordCustomWordsSkipDigits.Checked,
                DictionariesLastWordCustomWordsSkipSpecials = chkDictLastWordCustomWordsSkipSpecials.Checked,
                DictionariesLastWordCustomWordsForceLowercase = chkDictLastWordCustomWordsForceLowercase.Checked,
                DictionariesLastWordCustomWordsAddTypos = chkDictLastWordCustomWordsAddTypos.Checked,
                DictionariesLastWordExcludeWordsUse = chkDictionariesLastWordExcludeWordsUse.Checked,
                DictionariesLastWordExcludePartialWords = chkDictLastWordExcludePartialWords.Checked,
                DictionariesLastWordExcludeWords = txtDictLastWordExcludeWords.Text.Split("\r\n", StringSplitOptions.RemoveEmptyEntries).Select(p => p.Trim()).Distinct().OrderBy(p => p).ToList(),
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
                DictionaryFilterFirstFrom = txtDictionaryFilterFirstFrom.Text.Trim(),
                DictionaryFilterFirstTo = txtDictionaryFilterFirstTo.Text.Trim(),
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
                MaxTwos = Convert.ToInt32(cbMaxTwos.SelectedItem),
                MinTwos = Convert.ToInt32(cbMinTwos.SelectedItem),
                MaxThrees = Convert.ToInt32(cbMaxThrees.SelectedItem),
                MinThrees = Convert.ToInt32(cbMinThrees.SelectedItem),
                MaxFours = Convert.ToInt32(cbMaxFours.SelectedItem),
                MinFours = Convert.ToInt32(cbMinFours.SelectedItem),
                AtLeastNbrGteCharacters = cbAtLeastAboveNbrChars.SelectedIndex,
                AtLeastNbrGteWords = cbAtLeastAboveNbrWords.SelectedIndex,
                AtLeastNbrLteCharacters = cbAtLeastUnderNbrChars.SelectedIndex,
                AtLeastNbrLteWords = cbAtLeastUnderNbrWords.SelectedIndex,
                AtMostNbrGteCharacters = cbAtMostAboveNbrChars.SelectedIndex,
                AtMostNbrGteWords = cbAtMostAboveNbrWords.SelectedIndex,
                AtMostNbrLteCharacters = cbAtMostUnderNbrChars.SelectedIndex,
                AtMostNbrLteWords = cbAtMostUnderNbrWords.SelectedIndex,
                MaxConsecutiveOnes = Convert.ToInt32(cbMaxConsecutiveOnes.SelectedItem),
                MinWordsLimit = Convert.ToInt32(cbMinWordsLimit.SelectedItem),
                MaxConsecutiveConcatenation = Convert.ToInt32(cbMaxConsecutiveConcat.SelectedItem),
                MinConsecutiveConcatenation = Convert.ToInt32(cbMinConsecutiveConcat.SelectedItem),
                CustomMainWords = txtDictCustWords.Text.Split("\r\n", StringSplitOptions.RemoveEmptyEntries).Select(p => p.Trim()).Distinct().OrderBy(p => p).ToList(),
                CustomFirstWords = txtDictFirstCustWords.Text.Split("\r\n", StringSplitOptions.RemoveEmptyEntries).Select(p => p.Trim()).Distinct().OrderBy(p => p).ToList(),
                CustomLastWords = txtDictLastCustWords.Text.Split("\r\n", StringSplitOptions.RemoveEmptyEntries).Select(p => p.Trim()).Distinct().OrderBy(p => p).ToList()
            };
            File.WriteAllText(fileName, JsonConvert.SerializeObject(hbtObject));
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

            chkDictionariesUse.Checked = hbtObject.UseMainDictionaries;
            SetDictionary(tvDictMain, hbtObject.Dictionaries);
            chkDictSkipDigits.Checked = hbtObject.DictionariesSkipDigits;
            chkDictSkipSpecials.Checked = hbtObject.DictionariesSkipSpecials;
            chkDictForceLowercase.Checked = hbtObject.DictionariesForceLowercase;
            chkDictAddTypos.Checked = hbtObject.DictionariesAddTypos;
            chkDictReverseOrder.Checked = hbtObject.DictionariesReverseOrder;
            chkDictionariesCustomWordsUse.Checked = hbtObject.DictionariesCustomWordsUse;
            chkDictCustomWordsSkipDigits.Checked = hbtObject.DictionariesCustomWordsSkipDigits;
            chkDictCustomWordsSkipSpecials.Checked = hbtObject.DictionariesCustomWordsSkipSpecials;
            chkDictCustomWordsForceLowercase.Checked = hbtObject.DictionariesCustomWordsForceLowercase;
            chkDictCustomWordsAddTypos.Checked = hbtObject.DictionariesCustomWordsAddTypos;
            cbDictionariesCustomWordsMinimumInHash.SelectedItem = hbtObject.DictionariesCustomWordsMinimumInHash.ToString();
            chkDictionariesExcludeWordsUse.Checked = hbtObject.DictionariesExcludeWordsUse;
            chkDictExcludePartialWords.Checked = hbtObject.DictionariesExcludePartialWords;
            txtDictExcludeWords.Text = string.Join("\r\n", hbtObject.DictionariesExcludeWords ?? new List<string>());

            chkUseDictFirst.Checked = hbtObject.UseDictionaryFirstWord;
            SetDictionary(tvDictFirstWord, hbtObject.DictionariesFirstWord);
            chkDictFirstSkipDigits.Checked = hbtObject.DictionariesFirstWordSkipDigits;
            chkDictFirstSkipSpecials.Checked = hbtObject.DictionariesFirstWordSkipSpecials;
            chkDictFirstForceLowercase.Checked = hbtObject.DictionariesFirstWordForceLowercase;
            chkDictFirstAddTypos.Checked = hbtObject.DictionariesFirstWordAddTypos;
            chkDictFirstReverseOrder.Checked = hbtObject.DictionariesFirstWordReverseOrder;
            chkDictionariesFirstWordCustomWordsUse.Checked = hbtObject.DictionariesFirstWordCustomWordsUse;
            chkDictFirstWordCustomWordsSkipDigits.Checked = hbtObject.DictionariesFirstWordCustomWordsSkipDigits;
            chkDictFirstWordCustomWordsSkipSpecials.Checked = hbtObject.DictionariesFirstWordCustomWordsSkipSpecials;
            chkDictFirstWordCustomWordsForceLowercase.Checked = hbtObject.DictionariesFirstWordCustomWordsForceLowercase;
            chkDictFirstWordCustomWordsAddTypos.Checked = hbtObject.DictionariesFirstWordCustomWordsAddTypos;
            chkDictionariesFirstWordExcludeWordsUse.Checked = hbtObject.DictionariesFirstWordExcludeWordsUse;
            chkDictFirstWordExcludePartialWords.Checked = hbtObject.DictionariesFirstWordExcludePartialWords;
            txtDictFirstWordExcludeWords.Text = string.Join("\r\n", hbtObject.DictionariesFirstWordExcludeWords ?? new List<string>());

            chkUseDictLast.Checked = hbtObject.UseDictionaryLastWord;
            SetDictionary(tvDictLastWord, hbtObject.DictionariesLastWord);
            chkDictLastSkipDigits.Checked = hbtObject.DictionariesLastWordSkipDigits;
            chkDictLastSkipSpecials.Checked = hbtObject.DictionariesLastWordSkipSpecials;
            chkDictLastForceLowercase.Checked = hbtObject.DictionariesLastWordForceLowercase;
            chkDictLastAddTypos.Checked = hbtObject.DictionariesLastWordAddTypos;
            chkDictLastReverseOrder.Checked = hbtObject.DictionariesLastWordReverseOrder;
            chkDictionariesLastWordCustomWordsUse.Checked = hbtObject.DictionariesLastWordCustomWordsUse;
            chkDictLastWordCustomWordsSkipDigits.Checked = hbtObject.DictionariesLastWordCustomWordsSkipDigits;
            chkDictLastWordCustomWordsSkipSpecials.Checked = hbtObject.DictionariesLastWordCustomWordsSkipSpecials;
            chkDictLastWordCustomWordsForceLowercase.Checked = hbtObject.DictionariesLastWordCustomWordsForceLowercase;
            chkDictLastWordCustomWordsAddTypos.Checked = hbtObject.DictionariesLastWordCustomWordsAddTypos;
            chkDictionariesLastWordExcludeWordsUse.Checked = hbtObject.DictionariesLastWordExcludeWordsUse;
            chkDictLastWordExcludePartialWords.Checked = hbtObject.DictionariesLastWordExcludePartialWords;
            txtDictLastWordExcludeWords.Text = string.Join("\r\n", hbtObject.DictionariesLastWordExcludeWords ?? new List<string>());

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
            txtDictionaryFilterFirstFrom.Text = hbtObject.DictionaryFilterFirstFrom;
            txtDictionaryFilterFirstTo.Text = hbtObject.DictionaryFilterFirstTo;
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

            //Size Filters
            cbMaxDelim.SelectedItem = hbtObject.MaxDelimiters.ToString();
            cbMinDelim.SelectedItem = hbtObject.MinDelimiters.ToString();
            cbMaxWordLength.SelectedItem = hbtObject.MaxWordLength.ToString();
            cbMinWordLength.SelectedItem = hbtObject.MinWordLength.ToString();
            cbMaxOnes.SelectedItem = hbtObject.MaxOnes.ToString();
            cbMinOnes.SelectedItem = hbtObject.MinOnes.ToString();
            cbMaxTwos.SelectedItem = hbtObject.MaxTwos.ToString();
            cbMinTwos.SelectedItem = hbtObject.MinTwos.ToString();
            cbMaxThrees.SelectedItem = hbtObject.MaxThrees.ToString();
            cbMinThrees.SelectedItem = hbtObject.MinThrees.ToString();
            cbMaxFours.SelectedItem = hbtObject.MaxFours.ToString();
            cbMinFours.SelectedItem = hbtObject.MinFours.ToString();
            cbAtLeastAboveNbrChars.SelectedIndex = hbtObject.AtLeastNbrGteCharacters;
            cbAtLeastAboveNbrWords.SelectedIndex = hbtObject.AtLeastNbrGteWords;
            cbAtLeastUnderNbrChars.SelectedIndex = hbtObject.AtLeastNbrLteCharacters;
            cbAtLeastUnderNbrWords.SelectedIndex = hbtObject.AtLeastNbrLteWords;
            cbAtMostAboveNbrChars.SelectedIndex = hbtObject.AtMostNbrGteCharacters;
            cbAtMostAboveNbrWords.SelectedIndex = hbtObject.AtMostNbrGteWords;
            cbAtMostUnderNbrChars.SelectedIndex = hbtObject.AtMostNbrLteCharacters;
            cbAtMostUnderNbrWords.SelectedIndex = hbtObject.AtMostNbrLteWords;

            //Advanced
            chkDictionaryAdvanced.Checked = hbtObject.DictionaryAdvanced;
            chkOnlyFirstTwoWordsConcat.Checked = hbtObject.ConcatenateFirstTwoWords;
            chkOnlyLastTwoWordsConcat.Checked = hbtObject.ConcatenateLastTwoWords;
            cbMaxConcatWords.SelectedItem = hbtObject.MaxConcatenatedWords.ToString();
            cbMinConcatWords.SelectedItem = hbtObject.MinConcatenatedWords.ToString();
            cbMaxConsecutiveOnes.SelectedItem = hbtObject.MaxConsecutiveOnes.ToString();
            cbMinWordsLimit.SelectedItem = hbtObject.MinWordsLimit.ToString();
            cbMaxConsecutiveConcat.SelectedItem = hbtObject.MaxConsecutiveConcatenation.ToString();
            cbMinConsecutiveConcat.SelectedItem = hbtObject.MinConsecutiveConcatenation.ToString();

            txtDictCustWords.Text = string.Join("\r\n", hbtObject.CustomMainWords);
            txtDictFirstCustWords.Text = string.Join("\r\n", hbtObject.CustomFirstWords);
            txtDictLastCustWords.Text = string.Join("\r\n", hbtObject.CustomLastWords);

            _needOverrideConfirmation = false;
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
            if (!string.IsNullOrEmpty(hex) && File.Exists($"{hexFolder}\\[{hex}][Exclude].dic"))
            {
                File.Delete($"{hexFolder}\\[{hex}][Exclude].dic");
            }
            if (!string.IsNullOrEmpty(hex) && File.Exists($"{hexFolder}\\[{hex}][1st].dic"))
            {
                File.Delete($"{hexFolder}\\[{hex}][1st].dic");
            }
            if (!string.IsNullOrEmpty(hex) && File.Exists($"{hexFolder}\\[{hex}][1st][Exclude].dic"))
            {
                File.Delete($"{hexFolder}\\[{hex}][1st][Exclude].dic");
            }
            if (!string.IsNullOrEmpty(hex) && File.Exists($"{hexFolder}\\[{hex}][Last].dic"))
            {
                File.Delete($"{hexFolder}\\[{hex}][Last].dic");
            }
            if (!string.IsNullOrEmpty(hex) && File.Exists($"{hexFolder}\\[{hex}][Last][Exclude].dic"))
            {
                File.Delete($"{hexFolder}\\[{hex}][Last][Exclude].dic");
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
                File.WriteAllText($"{hexFolder}\\[{hex}][Exclude].dic", txtDictExcludeWords.Text);
                File.WriteAllText($"{hexFolder}\\[{hex}][1st].dic", txtDictFirstCustWords.Text);
                File.WriteAllText($"{hexFolder}\\[{hex}][1st][Exclude].dic", txtDictFirstWordExcludeWords.Text);
                File.WriteAllText($"{hexFolder}\\[{hex}][Last].dic", txtDictLastCustWords.Text);
                File.WriteAllText($"{hexFolder}\\[{hex}][Last][Exclude].dic", txtDictLastWordExcludeWords.Text);
            }
        }
        #endregion

        private string GetDictionary(TriStateTreeView tv)
        {
            var allDictionaries = Directory.GetFiles("Dictionaries", "*.dic", SearchOption.AllDirectories);
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
            chkDictFirstSkipDigits.Enabled = chkUseDictFirst.Checked;
            chkDictFirstSkipSpecials.Enabled = chkUseDictFirst.Checked;
            chkDictFirstForceLowercase.Enabled = chkUseDictFirst.Checked;
            chkDictFirstAddTypos.Enabled = chkUseDictFirst.Checked;
            chkDictFirstReverseOrder.Enabled = chkUseDictFirst.Checked;
            tvDictFirstWord.Enabled = chkUseDictFirst.Checked;
            btnCopyToDictFirst.Enabled = chkUseDictFirst.Checked;
            btnDictFirstUnselected.Enabled = chkUseDictFirst.Checked;
            if (chkUseDictFirst.Checked)
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
            chkDictLastSkipDigits.Enabled = chkUseDictLast.Checked;
            chkDictLastSkipSpecials.Enabled = chkUseDictLast.Checked;
            chkDictLastForceLowercase.Enabled = chkUseDictLast.Checked;
            chkDictLastAddTypos.Enabled = chkUseDictLast.Checked;
            chkDictLastReverseOrder.Enabled = chkUseDictLast.Checked;
            tvDictLastWord.Enabled = chkUseDictLast.Checked;
            btnCopyToDictLast.Enabled = chkUseDictLast.Checked;
            btnDictLastUnselected.Enabled = chkUseDictLast.Checked;
            if (chkUseDictLast.Checked)
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
            return IsValidHex() && ((pnlCharacter.Visible && !chkUtf8Toggle.Checked)); // || (pnlDictionary.Visible && !chkDictionaryAdvanced.Checked));
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

            _needOverrideConfirmation = true;
        }

        private void chkDictionariesUse_CheckedChanged(object sender, EventArgs e)
        {
            chkDictSkipDigits.Enabled = chkDictionariesUse.Checked;
            chkDictSkipSpecials.Enabled = chkDictionariesUse.Checked;
            chkDictForceLowercase.Enabled = chkDictionariesUse.Checked;
            chkDictAddTypos.Enabled = chkDictionariesUse.Checked;
            chkDictReverseOrder.Enabled = chkDictionariesUse.Checked;
            tvDictMain.Enabled = chkDictionariesUse.Checked;
            txtDictionaryFilterFirstFrom.Enabled = chkDictionariesUse.Checked;
            btnDictUnselected.Enabled = chkDictionariesUse.Checked;
        }

        private void chkDictionariesExcludeWordsUse_CheckedChanged(object sender, EventArgs e)
        {
            chkDictExcludePartialWords.Enabled = chkDictionariesExcludeWordsUse.Checked;
            txtDictExcludeWords.Enabled = chkDictionariesExcludeWordsUse.Checked;
        }

        private void chkDictionariesCustomWordsUse_CheckedChanged(object sender, EventArgs e)
        {
            chkDictCustomWordsSkipDigits.Enabled = chkDictionariesCustomWordsUse.Checked;
            chkDictCustomWordsSkipSpecials.Enabled = chkDictionariesCustomWordsUse.Checked;
            chkDictCustomWordsForceLowercase.Enabled = chkDictionariesCustomWordsUse.Checked;
            chkDictCustomWordsAddTypos.Enabled = chkDictionariesCustomWordsUse.Checked;
            cbDictionariesCustomWordsMinimumInHash.Enabled = chkDictionariesCustomWordsUse.Checked;
            txtDictCustWords.Enabled = chkDictionariesCustomWordsUse.Checked;
            if (chkDictionariesCustomWordsUse.Checked)
            {
                chkDictCustomWordsSkipDigits.Checked = chkDictSkipDigits.Checked;
                chkDictCustomWordsSkipSpecials.Checked = chkDictSkipSpecials.Checked;
                chkDictCustomWordsForceLowercase.Checked = chkDictForceLowercase.Checked;
                chkDictCustomWordsAddTypos.Checked = chkDictAddTypos.Checked;
            }
            else
            {
                chkDictCustomWordsSkipDigits.Checked = false;
                chkDictCustomWordsSkipSpecials.Checked = false;
                chkDictCustomWordsForceLowercase.Checked = false;
                chkDictCustomWordsAddTypos.Checked = false;
            }
        }

        private void chkDictionariesFirstWordCustomWordsUse_CheckedChanged(object sender, EventArgs e)
        {
            chkDictFirstWordCustomWordsSkipDigits.Enabled = chkDictionariesFirstWordCustomWordsUse.Checked;
            chkDictFirstWordCustomWordsSkipSpecials.Enabled = chkDictionariesFirstWordCustomWordsUse.Checked;
            chkDictFirstWordCustomWordsForceLowercase.Enabled = chkDictionariesFirstWordCustomWordsUse.Checked;
            chkDictFirstWordCustomWordsAddTypos.Enabled = chkDictionariesFirstWordCustomWordsUse.Checked;
            txtDictFirstCustWords.Enabled = chkDictionariesFirstWordCustomWordsUse.Checked;
            btnCopyToDictCustomFirst.Enabled = chkDictionariesFirstWordCustomWordsUse.Checked;
            if (chkDictionariesFirstWordCustomWordsUse.Checked)
            {
                if (chkDictionariesCustomWordsUse.Checked)
                {
                    chkDictFirstWordCustomWordsSkipDigits.Checked = chkDictCustomWordsSkipDigits.Checked;
                    chkDictFirstWordCustomWordsSkipSpecials.Checked = chkDictCustomWordsSkipSpecials.Checked;
                    chkDictFirstWordCustomWordsForceLowercase.Checked = chkDictCustomWordsForceLowercase.Checked;
                    chkDictFirstWordCustomWordsAddTypos.Checked = chkDictCustomWordsAddTypos.Checked;
                }
                else if (chkUseDictFirst.Checked)
                {
                    chkDictFirstWordCustomWordsSkipDigits.Checked = chkDictFirstSkipDigits.Checked;
                    chkDictFirstWordCustomWordsSkipSpecials.Checked = chkDictFirstSkipSpecials.Checked;
                    chkDictFirstWordCustomWordsForceLowercase.Checked = chkDictFirstForceLowercase.Checked;
                    chkDictFirstWordCustomWordsAddTypos.Checked = chkDictFirstAddTypos.Checked;
                }
                else
                {
                    chkDictFirstWordCustomWordsSkipDigits.Checked = chkDictSkipDigits.Checked;
                    chkDictFirstWordCustomWordsSkipSpecials.Checked = chkDictSkipSpecials.Checked;
                    chkDictFirstWordCustomWordsForceLowercase.Checked = chkDictForceLowercase.Checked;
                    chkDictFirstWordCustomWordsAddTypos.Checked = chkDictAddTypos.Checked;
                }
            }
            else
            {
                chkDictFirstWordCustomWordsSkipDigits.Checked = false;
                chkDictFirstWordCustomWordsSkipSpecials.Checked = false;
                chkDictFirstWordCustomWordsForceLowercase.Checked = false;
                chkDictFirstWordCustomWordsAddTypos.Checked = false;
            }
        }

        private void chkDictionariesFirstWordExcludeWordsUse_CheckedChanged(object sender, EventArgs e)
        {
            chkDictFirstWordExcludePartialWords.Enabled = chkDictionariesFirstWordExcludeWordsUse.Checked;
            txtDictFirstWordExcludeWords.Enabled = chkDictionariesFirstWordExcludeWordsUse.Checked;
            btnCopyToDictExcludeFirst.Enabled = chkDictionariesFirstWordExcludeWordsUse.Checked;
        }

        private void chkDictionariesLastWordCustomWordsUse_CheckedChanged(object sender, EventArgs e)
        {
            chkDictLastWordCustomWordsSkipDigits.Enabled = chkDictionariesLastWordCustomWordsUse.Checked;
            chkDictLastWordCustomWordsSkipSpecials.Enabled = chkDictionariesLastWordCustomWordsUse.Checked;
            chkDictLastWordCustomWordsForceLowercase.Enabled = chkDictionariesLastWordCustomWordsUse.Checked;
            chkDictLastWordCustomWordsAddTypos.Enabled = chkDictionariesLastWordCustomWordsUse.Checked;
            txtDictLastCustWords.Enabled = chkDictionariesLastWordCustomWordsUse.Checked;
            btnCopyToDictCustomLast.Enabled = chkDictionariesLastWordCustomWordsUse.Checked;
            if (chkDictionariesLastWordCustomWordsUse.Checked)
            {
                if (chkDictionariesCustomWordsUse.Checked)
                {
                    chkDictLastWordCustomWordsSkipDigits.Checked = chkDictCustomWordsSkipDigits.Checked;
                    chkDictLastWordCustomWordsSkipSpecials.Checked = chkDictCustomWordsSkipSpecials.Checked;
                    chkDictLastWordCustomWordsForceLowercase.Checked = chkDictCustomWordsForceLowercase.Checked;
                    chkDictLastWordCustomWordsAddTypos.Checked = chkDictCustomWordsAddTypos.Checked;
                }
                else if (chkUseDictLast.Checked)
                {
                    chkDictLastWordCustomWordsSkipDigits.Checked = chkDictLastSkipDigits.Checked;
                    chkDictLastWordCustomWordsSkipSpecials.Checked = chkDictLastSkipSpecials.Checked;
                    chkDictLastWordCustomWordsForceLowercase.Checked = chkDictLastForceLowercase.Checked;
                    chkDictLastWordCustomWordsAddTypos.Checked = chkDictLastAddTypos.Checked;
                }
                else
                {
                    chkDictLastWordCustomWordsSkipDigits.Checked = chkDictSkipDigits.Checked;
                    chkDictLastWordCustomWordsSkipSpecials.Checked = chkDictSkipSpecials.Checked;
                    chkDictLastWordCustomWordsForceLowercase.Checked = chkDictForceLowercase.Checked;
                    chkDictLastWordCustomWordsAddTypos.Checked = chkDictAddTypos.Checked;
                }
            }
            else
            {
                chkDictLastWordCustomWordsSkipDigits.Checked = false;
                chkDictLastWordCustomWordsSkipSpecials.Checked = false;
                chkDictLastWordCustomWordsForceLowercase.Checked = false;
                chkDictLastWordCustomWordsAddTypos.Checked = false;
            }
        }

        private void chkDictionariesLastWordExcludeWordsUse_CheckedChanged(object sender, EventArgs e)
        {
            chkDictLastWordExcludePartialWords.Enabled = chkDictionariesLastWordExcludeWordsUse.Checked;
            txtDictLastWordExcludeWords.Enabled = chkDictionariesLastWordExcludeWordsUse.Checked;
            btnCopyToDictExcludeLast.Enabled = chkDictionariesLastWordExcludeWordsUse.Checked;
        }

        private void printLatestCommandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(_lastCommand);
        }

        private void btnCopyToDictCustomFirst_Click(object sender, EventArgs e)
        {
            txtDictFirstCustWords.Text = txtDictCustWords.Text;
        }

        private void btnCopyToDictExcludeFirst_Click(object sender, EventArgs e)
        {
            txtDictFirstWordExcludeWords.Text = txtDictExcludeWords.Text;
        }

        private void btnCopyToDictCustomLast_Click(object sender, EventArgs e)
        {
            txtDictLastCustWords.Text = txtDictCustWords.Text;
        }

        private void btnCopyToDictExcludeLast_Click(object sender, EventArgs e)
        {
            txtDictLastWordExcludeWords.Text = txtDictExcludeWords.Text;
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

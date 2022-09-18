
namespace BruteForceHash.GUI
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblHexValues = new System.Windows.Forms.Label();
            this.txtHexValues = new System.Windows.Forms.TextBox();
            this.lblMethod = new System.Windows.Forms.Label();
            this.cbMethod = new System.Windows.Forms.ComboBox();
            this.lblPrefix = new System.Windows.Forms.Label();
            this.txtPrefix = new System.Windows.Forms.TextBox();
            this.lblDelimiter = new System.Windows.Forms.Label();
            this.txtDelimiter = new System.Windows.Forms.TextBox();
            this.lblNbThreads = new System.Windows.Forms.Label();
            this.cbNbThreads = new System.Windows.Forms.ComboBox();
            this.lblExcludePatterns = new System.Windows.Forms.Label();
            this.txtExcludePatterns = new System.Windows.Forms.TextBox();
            this.lblIncludePatterns = new System.Windows.Forms.Label();
            this.txtIncludePatterns = new System.Windows.Forms.TextBox();
            this.lblIncludeWord = new System.Windows.Forms.Label();
            this.txtIncludeWord = new System.Windows.Forms.TextBox();
            this.lblWordsLimit = new System.Windows.Forms.Label();
            this.cbWordsLimit = new System.Windows.Forms.ComboBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblSuffix = new System.Windows.Forms.Label();
            this.txtSuffix = new System.Windows.Forms.TextBox();
            this.lblCombinationOrder = new System.Windows.Forms.Label();
            this.pnlDictionary = new System.Windows.Forms.Panel();
            this.grpSizeFiltering = new System.Windows.Forms.GroupBox();
            this.cbMaxFours = new System.Windows.Forms.ComboBox();
            this.cbMaxThrees = new System.Windows.Forms.ComboBox();
            this.cbMaxTwos = new System.Windows.Forms.ComboBox();
            this.cbAtMostUnderNbrChars = new System.Windows.Forms.ComboBox();
            this.cbAtMostAboveNbrChars = new System.Windows.Forms.ComboBox();
            this.cbAtMostUnderNbrWords = new System.Windows.Forms.ComboBox();
            this.cbAtMostAboveNbrWords = new System.Windows.Forms.ComboBox();
            this.lblAtMostUnder = new System.Windows.Forms.Label();
            this.lblAtMostAbove = new System.Windows.Forms.Label();
            this.cbAtLeastUnderNbrChars = new System.Windows.Forms.ComboBox();
            this.cbAtLeastUnderNbrWords = new System.Windows.Forms.ComboBox();
            this.lblAtLeastUnder = new System.Windows.Forms.Label();
            this.cbAtLeastAboveNbrChars = new System.Windows.Forms.ComboBox();
            this.cbAtLeastAboveNbrWords = new System.Windows.Forms.ComboBox();
            this.lblAtLeastAbove = new System.Windows.Forms.Label();
            this.cbMinFours = new System.Windows.Forms.ComboBox();
            this.lblToFours = new System.Windows.Forms.Label();
            this.lblFours = new System.Windows.Forms.Label();
            this.cbMinThrees = new System.Windows.Forms.ComboBox();
            this.lblToThrees = new System.Windows.Forms.Label();
            this.lblThrees = new System.Windows.Forms.Label();
            this.cbMinTwos = new System.Windows.Forms.ComboBox();
            this.lblToTwos = new System.Windows.Forms.Label();
            this.lblTwos = new System.Windows.Forms.Label();
            this.lblMaxDelim = new System.Windows.Forms.Label();
            this.lblOnes = new System.Windows.Forms.Label();
            this.cbMinWordLength = new System.Windows.Forms.ComboBox();
            this.cbMaxOnes = new System.Windows.Forms.ComboBox();
            this.lblMinWordLength = new System.Windows.Forms.Label();
            this.lblToOnes = new System.Windows.Forms.Label();
            this.cbMaxWordLength = new System.Windows.Forms.ComboBox();
            this.cbMaxDelim = new System.Windows.Forms.ComboBox();
            this.cbMinOnes = new System.Windows.Forms.ComboBox();
            this.lblMaxWordLength = new System.Windows.Forms.Label();
            this.lblMinDelim = new System.Windows.Forms.Label();
            this.cbMinDelim = new System.Windows.Forms.ComboBox();
            this.grpWordFiltering = new System.Windows.Forms.GroupBox();
            this.cbIncludePatternsSamples = new System.Windows.Forms.ComboBox();
            this.cbExcludePatternsSamples = new System.Windows.Forms.ComboBox();
            this.cbCombinationOrder = new System.Windows.Forms.ComboBox();
            this.chkIncludeWordNotLast = new System.Windows.Forms.CheckBox();
            this.chkIncludeWordNotFirst = new System.Windows.Forms.CheckBox();
            this.grpAdvanced = new System.Windows.Forms.GroupBox();
            this.cbMinConcatWords = new System.Windows.Forms.ComboBox();
            this.cbMaxConcatWords = new System.Windows.Forms.ComboBox();
            this.lblMinConcatWords = new System.Windows.Forms.Label();
            this.lblMaxConcatWords = new System.Windows.Forms.Label();
            this.chkDictionaryAdvanced = new System.Windows.Forms.CheckBox();
            this.lblOnlyLastTwoWordsConcat = new System.Windows.Forms.Label();
            this.chkOnlyLastTwoWordsConcat = new System.Windows.Forms.CheckBox();
            this.lblOnlyFirstTwoWordsConcat = new System.Windows.Forms.Label();
            this.chkOnlyFirstTwoWordsConcat = new System.Windows.Forms.CheckBox();
            this.lblMaxConsecutiveConcat = new System.Windows.Forms.Label();
            this.cbMinWordsLimit = new System.Windows.Forms.ComboBox();
            this.cbMaxConsecutiveConcat = new System.Windows.Forms.ComboBox();
            this.lblMinWordsLimit = new System.Windows.Forms.Label();
            this.lblMinConsecutiveConcat = new System.Windows.Forms.Label();
            this.cbMaxConsecutiveOnes = new System.Windows.Forms.ComboBox();
            this.cbMinConsecutiveConcat = new System.Windows.Forms.ComboBox();
            this.lblMaxConsecutiveOnes = new System.Windows.Forms.Label();
            this.grpTypos = new System.Windows.Forms.GroupBox();
            this.txtTyposAppendLetters = new System.Windows.Forms.TextBox();
            this.lblTyposAppendLetters = new System.Windows.Forms.Label();
            this.txtTyposSwapLetters = new System.Windows.Forms.TextBox();
            this.lblTyposSwapLetters = new System.Windows.Forms.Label();
            this.chkTyposReverseLetter = new System.Windows.Forms.CheckBox();
            this.chkTyposWrongLetter = new System.Windows.Forms.CheckBox();
            this.chkTyposExtraLetter = new System.Windows.Forms.CheckBox();
            this.chkTyposDoubleLetter = new System.Windows.Forms.CheckBox();
            this.chkTyposSkipLetter = new System.Windows.Forms.CheckBox();
            this.chkTyposSkipDoubleLetter = new System.Windows.Forms.CheckBox();
            this.pnlDictBruteforce = new System.Windows.Forms.Panel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabMainDictionaries = new System.Windows.Forms.TabControl();
            this.tabMainDictionariesCommon = new System.Windows.Forms.TabPage();
            this.txtDictionaryFilterFirstTo = new System.Windows.Forms.TextBox();
            this.lblDictionaryFilterFirstTo = new System.Windows.Forms.Label();
            this.chkDictionariesUse = new System.Windows.Forms.CheckBox();
            this.lblDictionariesUse = new System.Windows.Forms.Label();
            this.btnDictUnselected = new System.Windows.Forms.Button();
            this.tvDictMain = new RikTheVeggie.TriStateTreeView();
            this.chkDictReverseOrder = new System.Windows.Forms.CheckBox();
            this.chkDictAddTypos = new System.Windows.Forms.CheckBox();
            this.txtDictionaryFilterFirstFrom = new System.Windows.Forms.TextBox();
            this.chkDictForceLowercase = new System.Windows.Forms.CheckBox();
            this.lblDictionaryFilterFirstFrom = new System.Windows.Forms.Label();
            this.chkDictSkipSpecials = new System.Windows.Forms.CheckBox();
            this.chkDictSkipDigits = new System.Windows.Forms.CheckBox();
            this.tabMainDictionariesCustom = new System.Windows.Forms.TabPage();
            this.chkDictionariesCustomWordsUse = new System.Windows.Forms.CheckBox();
            this.lblDictionariesCustomWordsUse = new System.Windows.Forms.Label();
            this.lblDictionariesCustomWordsAtLeast = new System.Windows.Forms.Label();
            this.lblDictionariesCustomWordsHash = new System.Windows.Forms.Label();
            this.cbDictionariesCustomWordsMinimumInHash = new System.Windows.Forms.ComboBox();
            this.lblDictionariesCustomWordsFiltering = new System.Windows.Forms.Label();
            this.chkDictCustomWordsAddTypos = new System.Windows.Forms.CheckBox();
            this.chkDictCustomWordsForceLowercase = new System.Windows.Forms.CheckBox();
            this.chkDictCustomWordsSkipSpecials = new System.Windows.Forms.CheckBox();
            this.chkDictCustomWordsSkipDigits = new System.Windows.Forms.CheckBox();
            this.txtDictCustWords = new System.Windows.Forms.TextBox();
            this.tabMainDictionariesExcludeWords = new System.Windows.Forms.TabPage();
            this.chkDictExcludePartialWords = new System.Windows.Forms.CheckBox();
            this.chkDictionariesExcludeWordsUse = new System.Windows.Forms.CheckBox();
            this.lblDictionariesExcludeWordsUse = new System.Windows.Forms.Label();
            this.txtDictExcludeWords = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabFirstWordDictionaries = new System.Windows.Forms.TabControl();
            this.tabFirstWordDictionariesCommon = new System.Windows.Forms.TabPage();
            this.lblDictionariesFirstWordUse = new System.Windows.Forms.Label();
            this.tvDictFirstWord = new RikTheVeggie.TriStateTreeView();
            this.chkDictFirstReverseOrder = new System.Windows.Forms.CheckBox();
            this.btnCopyToDictFirst = new System.Windows.Forms.Button();
            this.btnDictFirstUnselected = new System.Windows.Forms.Button();
            this.chkDictFirstAddTypos = new System.Windows.Forms.CheckBox();
            this.chkDictFirstForceLowercase = new System.Windows.Forms.CheckBox();
            this.chkDictFirstSkipSpecials = new System.Windows.Forms.CheckBox();
            this.chkUseDictFirst = new System.Windows.Forms.CheckBox();
            this.chkDictFirstSkipDigits = new System.Windows.Forms.CheckBox();
            this.tabFirstWordDictionariesCustom = new System.Windows.Forms.TabPage();
            this.btnCopyToDictCustomFirst = new System.Windows.Forms.Button();
            this.chkDictionariesFirstWordCustomWordsUse = new System.Windows.Forms.CheckBox();
            this.lblDictionariesFirstWordCustomWordsUse = new System.Windows.Forms.Label();
            this.chkDictFirstWordCustomWordsAddTypos = new System.Windows.Forms.CheckBox();
            this.chkDictFirstWordCustomWordsForceLowercase = new System.Windows.Forms.CheckBox();
            this.chkDictFirstWordCustomWordsSkipSpecials = new System.Windows.Forms.CheckBox();
            this.chkDictFirstWordCustomWordsSkipDigits = new System.Windows.Forms.CheckBox();
            this.txtDictFirstCustWords = new System.Windows.Forms.TextBox();
            this.tabFirstWordDictionariesExcludeWords = new System.Windows.Forms.TabPage();
            this.btnCopyToDictExcludeFirst = new System.Windows.Forms.Button();
            this.txtDictFirstWordExcludeWords = new System.Windows.Forms.TextBox();
            this.chkDictFirstWordExcludePartialWords = new System.Windows.Forms.CheckBox();
            this.chkDictionariesFirstWordExcludeWordsUse = new System.Windows.Forms.CheckBox();
            this.lblDictionariesFirstWordExcludeWordsUse = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabLastWordDictionaries = new System.Windows.Forms.TabControl();
            this.tabLastWordDictionariesCommon = new System.Windows.Forms.TabPage();
            this.lblDictionaryLastWordUse = new System.Windows.Forms.Label();
            this.tvDictLastWord = new RikTheVeggie.TriStateTreeView();
            this.chkDictLastForceLowercase = new System.Windows.Forms.CheckBox();
            this.btnCopyToDictLast = new System.Windows.Forms.Button();
            this.btnDictLastUnselected = new System.Windows.Forms.Button();
            this.chkDictLastSkipSpecials = new System.Windows.Forms.CheckBox();
            this.chkDictLastAddTypos = new System.Windows.Forms.CheckBox();
            this.chkDictLastSkipDigits = new System.Windows.Forms.CheckBox();
            this.chkUseDictLast = new System.Windows.Forms.CheckBox();
            this.chkDictLastReverseOrder = new System.Windows.Forms.CheckBox();
            this.tabLastWordDictionariesCustom = new System.Windows.Forms.TabPage();
            this.btnCopyToDictCustomLast = new System.Windows.Forms.Button();
            this.chkDictionariesLastWordCustomWordsUse = new System.Windows.Forms.CheckBox();
            this.lblDictionariesLastWordCustomWordsUse = new System.Windows.Forms.Label();
            this.chkDictLastWordCustomWordsAddTypos = new System.Windows.Forms.CheckBox();
            this.chkDictLastWordCustomWordsForceLowercase = new System.Windows.Forms.CheckBox();
            this.chkDictLastWordCustomWordsSkipSpecials = new System.Windows.Forms.CheckBox();
            this.chkDictLastWordCustomWordsSkipDigits = new System.Windows.Forms.CheckBox();
            this.txtDictLastCustWords = new System.Windows.Forms.TextBox();
            this.tabLastWordDictionariesExcludeWords = new System.Windows.Forms.TabPage();
            this.btnCopyToDictExcludeLast = new System.Windows.Forms.Button();
            this.txtDictLastWordExcludeWords = new System.Windows.Forms.TextBox();
            this.chkDictLastWordExcludePartialWords = new System.Windows.Forms.CheckBox();
            this.chkDictionariesLastWordExcludeWordsUse = new System.Windows.Forms.CheckBox();
            this.lblDictionariesLastWordExcludeWordsUse = new System.Windows.Forms.Label();
            this.chkVerbose = new System.Windows.Forms.CheckBox();
            this.mnStrip = new System.Windows.Forms.MenuStrip();
            this.mnFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnNew = new System.Windows.Forms.ToolStripMenuItem();
            this.mnSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.mnRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.mnSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnQuickLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.mnQuickSave = new System.Windows.Forms.ToolStripMenuItem();
            this.mnQuickClean = new System.Windows.Forms.ToolStripMenuItem();
            this.mnSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.mnSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printLatestCommandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            this.saveFile = new System.Windows.Forms.SaveFileDialog();
            this.lblVerbose = new System.Windows.Forms.Label();
            this.btnStartHashCat = new System.Windows.Forms.Button();
            this.btnQuickSave = new System.Windows.Forms.Button();
            this.btnQuickLoad = new System.Windows.Forms.Button();
            this.pnlCharBruteforce = new System.Windows.Forms.Panel();
            this.tbCharBruteforce = new System.Windows.Forms.TabControl();
            this.tabBruteforceMain = new System.Windows.Forms.TabPage();
            this.grpSpecials = new System.Windows.Forms.GroupBox();
            this.chklCharsets = new System.Windows.Forms.CheckedListBox();
            this.grpCharsetPreview = new System.Windows.Forms.GroupBox();
            this.lblStartingValidCharsPreview = new System.Windows.Forms.Label();
            this.txtStartingValidCharsPreview = new System.Windows.Forms.TextBox();
            this.lblValidCharsPreview = new System.Windows.Forms.Label();
            this.txtValidCharsPreview = new System.Windows.Forms.TextBox();
            this.tabBruteforceDict = new System.Windows.Forms.TabPage();
            this.pnlHybridDict = new System.Windows.Forms.Panel();
            this.lblHybridHashcatThreshold2 = new System.Windows.Forms.Label();
            this.cbHybridHashcatThreshold = new System.Windows.Forms.ComboBox();
            this.lblHybridHashcatThreshold = new System.Windows.Forms.Label();
            this.chkHybridIgnoreSizeFilters = new System.Windows.Forms.CheckBox();
            this.cbHybridBruteForceMaxCharacters = new System.Windows.Forms.ComboBox();
            this.cbHybridBruteForceMinCharacters = new System.Windows.Forms.ComboBox();
            this.lblHybridBruteForceFrom = new System.Windows.Forms.Label();
            this.lblHybridBruteForceUpTo = new System.Windows.Forms.Label();
            this.lblHybridWordsInHash = new System.Windows.Forms.Label();
            this.cbHybridWordsInHash = new System.Windows.Forms.ComboBox();
            this.lblHybridCombination = new System.Windows.Forms.Label();
            this.lblHybridDictUse = new System.Windows.Forms.Label();
            this.chkHybridDictUse = new System.Windows.Forms.CheckBox();
            this.txtHybridDictWords = new System.Windows.Forms.TextBox();
            this.lblHybridBruteForce = new System.Windows.Forms.Label();
            this.tabBruteforceDictFirstWord = new System.Windows.Forms.TabPage();
            this.pnlHybridDictFirstWord = new System.Windows.Forms.Panel();
            this.lblHybridDictFirstWordUse = new System.Windows.Forms.Label();
            this.txtHybridDictFirstWord = new System.Windows.Forms.TextBox();
            this.chkHybridDictFirstWordUse = new System.Windows.Forms.CheckBox();
            this.tabBruteforceDictLastWord = new System.Windows.Forms.TabPage();
            this.pnlHybridDictLastWord = new System.Windows.Forms.Panel();
            this.lblHybridDictLastWordUse = new System.Windows.Forms.Label();
            this.txtHybridDictLastWord = new System.Windows.Forms.TextBox();
            this.chkHybridDictLastWordUse = new System.Windows.Forms.CheckBox();
            this.grpGeneral = new System.Windows.Forms.GroupBox();
            this.txtValidChars = new System.Windows.Forms.TextBox();
            this.lblValidChars = new System.Windows.Forms.Label();
            this.txtHashCatPath = new System.Windows.Forms.TextBox();
            this.lblUtf8Toggle = new System.Windows.Forms.Label();
            this.lblHashCat = new System.Windows.Forms.Label();
            this.lblStartingValidChars = new System.Windows.Forms.Label();
            this.chkUtf8Toggle = new System.Windows.Forms.CheckBox();
            this.txtStartingValidChars = new System.Windows.Forms.TextBox();
            this.chkDictCachePrefix = new System.Windows.Forms.CheckBox();
            this.chkDictCacheSuffix = new System.Windows.Forms.CheckBox();
            this.pnlDictionary.SuspendLayout();
            this.grpSizeFiltering.SuspendLayout();
            this.grpWordFiltering.SuspendLayout();
            this.grpAdvanced.SuspendLayout();
            this.grpTypos.SuspendLayout();
            this.pnlDictBruteforce.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabMainDictionaries.SuspendLayout();
            this.tabMainDictionariesCommon.SuspendLayout();
            this.tabMainDictionariesCustom.SuspendLayout();
            this.tabMainDictionariesExcludeWords.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabFirstWordDictionaries.SuspendLayout();
            this.tabFirstWordDictionariesCommon.SuspendLayout();
            this.tabFirstWordDictionariesCustom.SuspendLayout();
            this.tabFirstWordDictionariesExcludeWords.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabLastWordDictionaries.SuspendLayout();
            this.tabLastWordDictionariesCommon.SuspendLayout();
            this.tabLastWordDictionariesCustom.SuspendLayout();
            this.tabLastWordDictionariesExcludeWords.SuspendLayout();
            this.mnStrip.SuspendLayout();
            this.pnlCharBruteforce.SuspendLayout();
            this.tbCharBruteforce.SuspendLayout();
            this.tabBruteforceMain.SuspendLayout();
            this.grpSpecials.SuspendLayout();
            this.grpCharsetPreview.SuspendLayout();
            this.tabBruteforceDict.SuspendLayout();
            this.pnlHybridDict.SuspendLayout();
            this.tabBruteforceDictFirstWord.SuspendLayout();
            this.pnlHybridDictFirstWord.SuspendLayout();
            this.tabBruteforceDictLastWord.SuspendLayout();
            this.pnlHybridDictLastWord.SuspendLayout();
            this.grpGeneral.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblHexValues
            // 
            this.lblHexValues.AutoSize = true;
            this.lblHexValues.Location = new System.Drawing.Point(23, 127);
            this.lblHexValues.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHexValues.Name = "lblHexValues";
            this.lblHexValues.Size = new System.Drawing.Size(111, 25);
            this.lblHexValues.TabIndex = 0;
            this.lblHexValues.Text = "Hex Value(s):";
            // 
            // txtHexValues
            // 
            this.txtHexValues.Location = new System.Drawing.Point(176, 123);
            this.txtHexValues.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtHexValues.Name = "txtHexValues";
            this.txtHexValues.PlaceholderText = "0x105274ba4f";
            this.txtHexValues.Size = new System.Drawing.Size(227, 31);
            this.txtHexValues.TabIndex = 1;
            this.txtHexValues.TextChanged += new System.EventHandler(this.txtHexValues_TextChanged);
            // 
            // lblMethod
            // 
            this.lblMethod.AutoSize = true;
            this.lblMethod.Location = new System.Drawing.Point(23, 60);
            this.lblMethod.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMethod.Name = "lblMethod";
            this.lblMethod.Size = new System.Drawing.Size(108, 25);
            this.lblMethod.TabIndex = 2;
            this.lblMethod.Text = "Attack Type:";
            // 
            // cbMethod
            // 
            this.cbMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMethod.FormattingEnabled = true;
            this.cbMethod.Items.AddRange(new object[] {
            "Dictionary",
            "Character",
            "Hybrid"});
            this.cbMethod.Location = new System.Drawing.Point(176, 55);
            this.cbMethod.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbMethod.Name = "cbMethod";
            this.cbMethod.Size = new System.Drawing.Size(227, 33);
            this.cbMethod.TabIndex = 3;
            this.cbMethod.SelectedIndexChanged += new System.EventHandler(this.OnCbMethodChanged);
            // 
            // lblPrefix
            // 
            this.lblPrefix.AutoSize = true;
            this.lblPrefix.Location = new System.Drawing.Point(584, 127);
            this.lblPrefix.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPrefix.Name = "lblPrefix";
            this.lblPrefix.Size = new System.Drawing.Size(59, 25);
            this.lblPrefix.TabIndex = 4;
            this.lblPrefix.Text = "Prefix:";
            // 
            // txtPrefix
            // 
            this.txtPrefix.Location = new System.Drawing.Point(686, 123);
            this.txtPrefix.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPrefix.Name = "txtPrefix";
            this.txtPrefix.Size = new System.Drawing.Size(203, 31);
            this.txtPrefix.TabIndex = 5;
            // 
            // lblDelimiter
            // 
            this.lblDelimiter.AutoSize = true;
            this.lblDelimiter.Location = new System.Drawing.Point(856, 60);
            this.lblDelimiter.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDelimiter.Name = "lblDelimiter";
            this.lblDelimiter.Size = new System.Drawing.Size(87, 25);
            this.lblDelimiter.TabIndex = 6;
            this.lblDelimiter.Text = "Delimiter:";
            // 
            // txtDelimiter
            // 
            this.txtDelimiter.Location = new System.Drawing.Point(971, 53);
            this.txtDelimiter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDelimiter.MaxLength = 1;
            this.txtDelimiter.Name = "txtDelimiter";
            this.txtDelimiter.Size = new System.Drawing.Size(37, 31);
            this.txtDelimiter.TabIndex = 7;
            this.txtDelimiter.Text = "_";
            this.txtDelimiter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblNbThreads
            // 
            this.lblNbThreads.AutoSize = true;
            this.lblNbThreads.Location = new System.Drawing.Point(584, 60);
            this.lblNbThreads.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNbThreads.Name = "lblNbThreads";
            this.lblNbThreads.Size = new System.Drawing.Size(78, 25);
            this.lblNbThreads.TabIndex = 12;
            this.lblNbThreads.Text = "Threads:";
            // 
            // cbNbThreads
            // 
            this.cbNbThreads.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNbThreads.FormattingEnabled = true;
            this.cbNbThreads.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59",
            "60",
            "61",
            "62",
            "63",
            "64"});
            this.cbNbThreads.Location = new System.Drawing.Point(686, 57);
            this.cbNbThreads.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbNbThreads.Name = "cbNbThreads";
            this.cbNbThreads.Size = new System.Drawing.Size(110, 33);
            this.cbNbThreads.TabIndex = 13;
            // 
            // lblExcludePatterns
            // 
            this.lblExcludePatterns.AutoSize = true;
            this.lblExcludePatterns.Location = new System.Drawing.Point(9, 37);
            this.lblExcludePatterns.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblExcludePatterns.Name = "lblExcludePatterns";
            this.lblExcludePatterns.Size = new System.Drawing.Size(143, 25);
            this.lblExcludePatterns.TabIndex = 14;
            this.lblExcludePatterns.Text = "Exclude Patterns:";
            // 
            // txtExcludePatterns
            // 
            this.txtExcludePatterns.Location = new System.Drawing.Point(173, 33);
            this.txtExcludePatterns.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtExcludePatterns.Name = "txtExcludePatterns";
            this.txtExcludePatterns.PlaceholderText = "{1}_{1},{2}_{2}";
            this.txtExcludePatterns.Size = new System.Drawing.Size(267, 31);
            this.txtExcludePatterns.TabIndex = 15;
            // 
            // lblIncludePatterns
            // 
            this.lblIncludePatterns.AutoSize = true;
            this.lblIncludePatterns.Location = new System.Drawing.Point(9, 88);
            this.lblIncludePatterns.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIncludePatterns.Name = "lblIncludePatterns";
            this.lblIncludePatterns.Size = new System.Drawing.Size(141, 25);
            this.lblIncludePatterns.TabIndex = 16;
            this.lblIncludePatterns.Text = "Include Patterns:";
            // 
            // txtIncludePatterns
            // 
            this.txtIncludePatterns.Location = new System.Drawing.Point(173, 83);
            this.txtIncludePatterns.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtIncludePatterns.Name = "txtIncludePatterns";
            this.txtIncludePatterns.PlaceholderText = "{3}";
            this.txtIncludePatterns.Size = new System.Drawing.Size(267, 31);
            this.txtIncludePatterns.TabIndex = 17;
            // 
            // lblIncludeWord
            // 
            this.lblIncludeWord.AutoSize = true;
            this.lblIncludeWord.Location = new System.Drawing.Point(9, 145);
            this.lblIncludeWord.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIncludeWord.Name = "lblIncludeWord";
            this.lblIncludeWord.Size = new System.Drawing.Size(122, 25);
            this.lblIncludeWord.TabIndex = 18;
            this.lblIncludeWord.Text = "Include Word:";
            // 
            // txtIncludeWord
            // 
            this.txtIncludeWord.Location = new System.Drawing.Point(171, 138);
            this.txtIncludeWord.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtIncludeWord.Name = "txtIncludeWord";
            this.txtIncludeWord.PlaceholderText = "mario,luigi";
            this.txtIncludeWord.Size = new System.Drawing.Size(161, 31);
            this.txtIncludeWord.TabIndex = 19;
            // 
            // lblWordsLimit
            // 
            this.lblWordsLimit.AutoSize = true;
            this.lblWordsLimit.Location = new System.Drawing.Point(337, 208);
            this.lblWordsLimit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWordsLimit.Name = "lblWordsLimit";
            this.lblWordsLimit.Size = new System.Drawing.Size(111, 25);
            this.lblWordsLimit.TabIndex = 20;
            this.lblWordsLimit.Text = "Words Limit:";
            // 
            // cbWordsLimit
            // 
            this.cbWordsLimit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbWordsLimit.FormattingEnabled = true;
            this.cbWordsLimit.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.cbWordsLimit.Location = new System.Drawing.Point(449, 203);
            this.cbWordsLimit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbWordsLimit.Name = "cbWordsLimit";
            this.cbWordsLimit.Size = new System.Drawing.Size(53, 33);
            this.cbWordsLimit.TabIndex = 21;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(250, 1157);
            this.btnStart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(304, 37);
            this.btnStart.TabIndex = 24;
            this.btnStart.Text = "START";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.OnBtnStartClick);
            // 
            // lblSuffix
            // 
            this.lblSuffix.AutoSize = true;
            this.lblSuffix.Location = new System.Drawing.Point(907, 127);
            this.lblSuffix.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSuffix.Name = "lblSuffix";
            this.lblSuffix.Size = new System.Drawing.Size(60, 25);
            this.lblSuffix.TabIndex = 27;
            this.lblSuffix.Text = "Suffix:";
            // 
            // txtSuffix
            // 
            this.txtSuffix.Location = new System.Drawing.Point(974, 123);
            this.txtSuffix.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSuffix.Name = "txtSuffix";
            this.txtSuffix.Size = new System.Drawing.Size(218, 31);
            this.txtSuffix.TabIndex = 28;
            // 
            // lblCombinationOrder
            // 
            this.lblCombinationOrder.AutoSize = true;
            this.lblCombinationOrder.Location = new System.Drawing.Point(14, 208);
            this.lblCombinationOrder.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCombinationOrder.Name = "lblCombinationOrder";
            this.lblCombinationOrder.Size = new System.Drawing.Size(62, 25);
            this.lblCombinationOrder.TabIndex = 29;
            this.lblCombinationOrder.Text = "Order:";
            // 
            // pnlDictionary
            // 
            this.pnlDictionary.Controls.Add(this.grpSizeFiltering);
            this.pnlDictionary.Controls.Add(this.grpWordFiltering);
            this.pnlDictionary.Controls.Add(this.grpAdvanced);
            this.pnlDictionary.Controls.Add(this.grpTypos);
            this.pnlDictionary.Controls.Add(this.pnlDictBruteforce);
            this.pnlDictionary.Location = new System.Drawing.Point(17, 173);
            this.pnlDictionary.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlDictionary.Name = "pnlDictionary";
            this.pnlDictionary.Size = new System.Drawing.Size(1181, 977);
            this.pnlDictionary.TabIndex = 31;
            // 
            // grpSizeFiltering
            // 
            this.grpSizeFiltering.Controls.Add(this.cbMaxFours);
            this.grpSizeFiltering.Controls.Add(this.cbMaxThrees);
            this.grpSizeFiltering.Controls.Add(this.cbMaxTwos);
            this.grpSizeFiltering.Controls.Add(this.cbAtMostUnderNbrChars);
            this.grpSizeFiltering.Controls.Add(this.cbAtMostAboveNbrChars);
            this.grpSizeFiltering.Controls.Add(this.cbAtMostUnderNbrWords);
            this.grpSizeFiltering.Controls.Add(this.cbAtMostAboveNbrWords);
            this.grpSizeFiltering.Controls.Add(this.lblAtMostUnder);
            this.grpSizeFiltering.Controls.Add(this.lblAtMostAbove);
            this.grpSizeFiltering.Controls.Add(this.cbAtLeastUnderNbrChars);
            this.grpSizeFiltering.Controls.Add(this.cbAtLeastUnderNbrWords);
            this.grpSizeFiltering.Controls.Add(this.lblAtLeastUnder);
            this.grpSizeFiltering.Controls.Add(this.cbAtLeastAboveNbrChars);
            this.grpSizeFiltering.Controls.Add(this.cbAtLeastAboveNbrWords);
            this.grpSizeFiltering.Controls.Add(this.lblAtLeastAbove);
            this.grpSizeFiltering.Controls.Add(this.cbMinFours);
            this.grpSizeFiltering.Controls.Add(this.lblToFours);
            this.grpSizeFiltering.Controls.Add(this.lblFours);
            this.grpSizeFiltering.Controls.Add(this.cbMinThrees);
            this.grpSizeFiltering.Controls.Add(this.lblToThrees);
            this.grpSizeFiltering.Controls.Add(this.lblThrees);
            this.grpSizeFiltering.Controls.Add(this.cbMinTwos);
            this.grpSizeFiltering.Controls.Add(this.lblToTwos);
            this.grpSizeFiltering.Controls.Add(this.lblTwos);
            this.grpSizeFiltering.Controls.Add(this.lblMaxDelim);
            this.grpSizeFiltering.Controls.Add(this.lblOnes);
            this.grpSizeFiltering.Controls.Add(this.cbMinWordLength);
            this.grpSizeFiltering.Controls.Add(this.cbMaxOnes);
            this.grpSizeFiltering.Controls.Add(this.lblMinWordLength);
            this.grpSizeFiltering.Controls.Add(this.lblToOnes);
            this.grpSizeFiltering.Controls.Add(this.cbMaxWordLength);
            this.grpSizeFiltering.Controls.Add(this.cbMaxDelim);
            this.grpSizeFiltering.Controls.Add(this.cbMinOnes);
            this.grpSizeFiltering.Controls.Add(this.lblMaxWordLength);
            this.grpSizeFiltering.Controls.Add(this.lblMinDelim);
            this.grpSizeFiltering.Controls.Add(this.cbMinDelim);
            this.grpSizeFiltering.Location = new System.Drawing.Point(10, 273);
            this.grpSizeFiltering.Name = "grpSizeFiltering";
            this.grpSizeFiltering.Size = new System.Drawing.Size(520, 303);
            this.grpSizeFiltering.TabIndex = 86;
            this.grpSizeFiltering.TabStop = false;
            this.grpSizeFiltering.Text = "Size Filtering";
            // 
            // cbMaxFours
            // 
            this.cbMaxFours.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMaxFours.FormattingEnabled = true;
            this.cbMaxFours.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.cbMaxFours.Location = new System.Drawing.Point(196, 255);
            this.cbMaxFours.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbMaxFours.Name = "cbMaxFours";
            this.cbMaxFours.Size = new System.Drawing.Size(53, 33);
            this.cbMaxFours.TabIndex = 82;
            // 
            // cbMaxThrees
            // 
            this.cbMaxThrees.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMaxThrees.FormattingEnabled = true;
            this.cbMaxThrees.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.cbMaxThrees.Location = new System.Drawing.Point(196, 212);
            this.cbMaxThrees.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbMaxThrees.Name = "cbMaxThrees";
            this.cbMaxThrees.Size = new System.Drawing.Size(53, 33);
            this.cbMaxThrees.TabIndex = 78;
            // 
            // cbMaxTwos
            // 
            this.cbMaxTwos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMaxTwos.FormattingEnabled = true;
            this.cbMaxTwos.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.cbMaxTwos.Location = new System.Drawing.Point(196, 168);
            this.cbMaxTwos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbMaxTwos.Name = "cbMaxTwos";
            this.cbMaxTwos.Size = new System.Drawing.Size(53, 33);
            this.cbMaxTwos.TabIndex = 74;
            // 
            // cbAtMostUnderNbrChars
            // 
            this.cbAtMostUnderNbrChars.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAtMostUnderNbrChars.DropDownWidth = 110;
            this.cbAtMostUnderNbrChars.FormattingEnabled = true;
            this.cbAtMostUnderNbrChars.Items.AddRange(new object[] {
            "0 character",
            "1 character",
            "2 characters",
            "3 characters",
            "4 characters",
            "5 characters",
            "6 characters",
            "7 characters",
            "8 characters",
            "9 characters",
            "10 characters"});
            this.cbAtMostUnderNbrChars.Location = new System.Drawing.Point(437, 255);
            this.cbAtMostUnderNbrChars.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbAtMostUnderNbrChars.Name = "cbAtMostUnderNbrChars";
            this.cbAtMostUnderNbrChars.Size = new System.Drawing.Size(63, 33);
            this.cbAtMostUnderNbrChars.TabIndex = 98;
            // 
            // cbAtMostAboveNbrChars
            // 
            this.cbAtMostAboveNbrChars.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAtMostAboveNbrChars.DropDownWidth = 110;
            this.cbAtMostAboveNbrChars.FormattingEnabled = true;
            this.cbAtMostAboveNbrChars.Items.AddRange(new object[] {
            "0 character",
            "1 character",
            "2 characters",
            "3 characters",
            "4 characters",
            "5 characters",
            "6 characters",
            "7 characters",
            "8 characters",
            "9 characters",
            "10 characters"});
            this.cbAtMostAboveNbrChars.Location = new System.Drawing.Point(437, 212);
            this.cbAtMostAboveNbrChars.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbAtMostAboveNbrChars.Name = "cbAtMostAboveNbrChars";
            this.cbAtMostAboveNbrChars.Size = new System.Drawing.Size(63, 33);
            this.cbAtMostAboveNbrChars.TabIndex = 97;
            // 
            // cbAtMostUnderNbrWords
            // 
            this.cbAtMostUnderNbrWords.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAtMostUnderNbrWords.DropDownWidth = 80;
            this.cbAtMostUnderNbrWords.FormattingEnabled = true;
            this.cbAtMostUnderNbrWords.Items.AddRange(new object[] {
            "0 word",
            "1 word",
            "2 words",
            "3 words",
            "4 words",
            "5 words",
            "6 words",
            "7 words",
            "8 words",
            "9 words",
            "10 words"});
            this.cbAtMostUnderNbrWords.Location = new System.Drawing.Point(345, 255);
            this.cbAtMostUnderNbrWords.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbAtMostUnderNbrWords.Name = "cbAtMostUnderNbrWords";
            this.cbAtMostUnderNbrWords.Size = new System.Drawing.Size(63, 33);
            this.cbAtMostUnderNbrWords.TabIndex = 96;
            // 
            // cbAtMostAboveNbrWords
            // 
            this.cbAtMostAboveNbrWords.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAtMostAboveNbrWords.DropDownWidth = 80;
            this.cbAtMostAboveNbrWords.FormattingEnabled = true;
            this.cbAtMostAboveNbrWords.Items.AddRange(new object[] {
            "0 word",
            "1 word",
            "2 words",
            "3 words",
            "4 words",
            "5 words",
            "6 words",
            "7 words",
            "8 words",
            "9 words",
            "10 words"});
            this.cbAtMostAboveNbrWords.Location = new System.Drawing.Point(345, 212);
            this.cbAtMostAboveNbrWords.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbAtMostAboveNbrWords.Name = "cbAtMostAboveNbrWords";
            this.cbAtMostAboveNbrWords.Size = new System.Drawing.Size(63, 33);
            this.cbAtMostAboveNbrWords.TabIndex = 95;
            // 
            // lblAtMostUnder
            // 
            this.lblAtMostUnder.AutoSize = true;
            this.lblAtMostUnder.Location = new System.Drawing.Point(269, 262);
            this.lblAtMostUnder.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAtMostUnder.Name = "lblAtMostUnder";
            this.lblAtMostUnder.Size = new System.Drawing.Size(168, 25);
            this.lblAtMostUnder.TabIndex = 94;
            this.lblAtMostUnder.Text = "At most                ≤";
            // 
            // lblAtMostAbove
            // 
            this.lblAtMostAbove.AutoSize = true;
            this.lblAtMostAbove.Location = new System.Drawing.Point(269, 217);
            this.lblAtMostAbove.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAtMostAbove.Name = "lblAtMostAbove";
            this.lblAtMostAbove.Size = new System.Drawing.Size(168, 25);
            this.lblAtMostAbove.TabIndex = 93;
            this.lblAtMostAbove.Text = "At most                ≥";
            // 
            // cbAtLeastUnderNbrChars
            // 
            this.cbAtLeastUnderNbrChars.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAtLeastUnderNbrChars.DropDownWidth = 110;
            this.cbAtLeastUnderNbrChars.FormattingEnabled = true;
            this.cbAtLeastUnderNbrChars.Items.AddRange(new object[] {
            "0 character",
            "1 character",
            "2 characters",
            "3 characters",
            "4 characters",
            "5 characters",
            "6 characters",
            "7 characters",
            "8 characters",
            "9 characters",
            "10 characters"});
            this.cbAtLeastUnderNbrChars.Location = new System.Drawing.Point(437, 168);
            this.cbAtLeastUnderNbrChars.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbAtLeastUnderNbrChars.Name = "cbAtLeastUnderNbrChars";
            this.cbAtLeastUnderNbrChars.Size = new System.Drawing.Size(63, 33);
            this.cbAtLeastUnderNbrChars.TabIndex = 92;
            // 
            // cbAtLeastUnderNbrWords
            // 
            this.cbAtLeastUnderNbrWords.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAtLeastUnderNbrWords.DropDownWidth = 80;
            this.cbAtLeastUnderNbrWords.FormattingEnabled = true;
            this.cbAtLeastUnderNbrWords.Items.AddRange(new object[] {
            "0 word",
            "1 word",
            "2 words",
            "3 words",
            "4 words",
            "5 words",
            "6 words",
            "7 words",
            "8 words",
            "9 words",
            "10 words"});
            this.cbAtLeastUnderNbrWords.Location = new System.Drawing.Point(345, 168);
            this.cbAtLeastUnderNbrWords.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbAtLeastUnderNbrWords.Name = "cbAtLeastUnderNbrWords";
            this.cbAtLeastUnderNbrWords.Size = new System.Drawing.Size(63, 33);
            this.cbAtLeastUnderNbrWords.TabIndex = 87;
            // 
            // lblAtLeastUnder
            // 
            this.lblAtLeastUnder.AutoSize = true;
            this.lblAtLeastUnder.Location = new System.Drawing.Point(269, 173);
            this.lblAtLeastUnder.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAtLeastUnder.Name = "lblAtLeastUnder";
            this.lblAtLeastUnder.Size = new System.Drawing.Size(168, 25);
            this.lblAtLeastUnder.TabIndex = 90;
            this.lblAtLeastUnder.Text = "At least                 ≤";
            // 
            // cbAtLeastAboveNbrChars
            // 
            this.cbAtLeastAboveNbrChars.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAtLeastAboveNbrChars.DropDownWidth = 110;
            this.cbAtLeastAboveNbrChars.FormattingEnabled = true;
            this.cbAtLeastAboveNbrChars.Items.AddRange(new object[] {
            "0 character",
            "1 character",
            "2 characters",
            "3 characters",
            "4 characters",
            "5 characters",
            "6 characters",
            "7 characters",
            "8 characters",
            "9 characters",
            "10 characters"});
            this.cbAtLeastAboveNbrChars.Location = new System.Drawing.Point(437, 125);
            this.cbAtLeastAboveNbrChars.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbAtLeastAboveNbrChars.Name = "cbAtLeastAboveNbrChars";
            this.cbAtLeastAboveNbrChars.Size = new System.Drawing.Size(63, 33);
            this.cbAtLeastAboveNbrChars.TabIndex = 89;
            // 
            // cbAtLeastAboveNbrWords
            // 
            this.cbAtLeastAboveNbrWords.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAtLeastAboveNbrWords.DropDownWidth = 80;
            this.cbAtLeastAboveNbrWords.FormattingEnabled = true;
            this.cbAtLeastAboveNbrWords.Items.AddRange(new object[] {
            "0 word",
            "1 word",
            "2 words",
            "3 words",
            "4 words",
            "5 words",
            "6 words",
            "7 words",
            "8 words",
            "9 words",
            "10 words"});
            this.cbAtLeastAboveNbrWords.Location = new System.Drawing.Point(345, 125);
            this.cbAtLeastAboveNbrWords.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbAtLeastAboveNbrWords.Name = "cbAtLeastAboveNbrWords";
            this.cbAtLeastAboveNbrWords.Size = new System.Drawing.Size(63, 33);
            this.cbAtLeastAboveNbrWords.TabIndex = 86;
            // 
            // lblAtLeastAbove
            // 
            this.lblAtLeastAbove.AutoSize = true;
            this.lblAtLeastAbove.Location = new System.Drawing.Point(269, 130);
            this.lblAtLeastAbove.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAtLeastAbove.Name = "lblAtLeastAbove";
            this.lblAtLeastAbove.Size = new System.Drawing.Size(168, 25);
            this.lblAtLeastAbove.TabIndex = 85;
            this.lblAtLeastAbove.Text = "At least                 ≥";
            // 
            // cbMinFours
            // 
            this.cbMinFours.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMinFours.FormattingEnabled = true;
            this.cbMinFours.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.cbMinFours.Location = new System.Drawing.Point(113, 255);
            this.cbMinFours.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbMinFours.Name = "cbMinFours";
            this.cbMinFours.Size = new System.Drawing.Size(53, 33);
            this.cbMinFours.TabIndex = 84;
            // 
            // lblToFours
            // 
            this.lblToFours.AutoSize = true;
            this.lblToFours.Location = new System.Drawing.Point(168, 262);
            this.lblToFours.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblToFours.Name = "lblToFours";
            this.lblToFours.Size = new System.Drawing.Size(29, 25);
            this.lblToFours.TabIndex = 83;
            this.lblToFours.Text = "to";
            // 
            // lblFours
            // 
            this.lblFours.AutoSize = true;
            this.lblFours.Location = new System.Drawing.Point(19, 260);
            this.lblFours.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFours.Name = "lblFours";
            this.lblFours.Size = new System.Drawing.Size(65, 25);
            this.lblFours.TabIndex = 81;
            this.lblFours.Text = "Fours :";
            // 
            // cbMinThrees
            // 
            this.cbMinThrees.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMinThrees.FormattingEnabled = true;
            this.cbMinThrees.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.cbMinThrees.Location = new System.Drawing.Point(113, 212);
            this.cbMinThrees.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbMinThrees.Name = "cbMinThrees";
            this.cbMinThrees.Size = new System.Drawing.Size(53, 33);
            this.cbMinThrees.TabIndex = 80;
            // 
            // lblToThrees
            // 
            this.lblToThrees.AutoSize = true;
            this.lblToThrees.Location = new System.Drawing.Point(168, 218);
            this.lblToThrees.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblToThrees.Name = "lblToThrees";
            this.lblToThrees.Size = new System.Drawing.Size(29, 25);
            this.lblToThrees.TabIndex = 79;
            this.lblToThrees.Text = "to";
            // 
            // lblThrees
            // 
            this.lblThrees.AutoSize = true;
            this.lblThrees.Location = new System.Drawing.Point(19, 217);
            this.lblThrees.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblThrees.Name = "lblThrees";
            this.lblThrees.Size = new System.Drawing.Size(72, 25);
            this.lblThrees.TabIndex = 77;
            this.lblThrees.Text = "Threes :";
            // 
            // cbMinTwos
            // 
            this.cbMinTwos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMinTwos.FormattingEnabled = true;
            this.cbMinTwos.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.cbMinTwos.Location = new System.Drawing.Point(113, 168);
            this.cbMinTwos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbMinTwos.Name = "cbMinTwos";
            this.cbMinTwos.Size = new System.Drawing.Size(53, 33);
            this.cbMinTwos.TabIndex = 76;
            // 
            // lblToTwos
            // 
            this.lblToTwos.AutoSize = true;
            this.lblToTwos.Location = new System.Drawing.Point(168, 172);
            this.lblToTwos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblToTwos.Name = "lblToTwos";
            this.lblToTwos.Size = new System.Drawing.Size(29, 25);
            this.lblToTwos.TabIndex = 75;
            this.lblToTwos.Text = "to";
            // 
            // lblTwos
            // 
            this.lblTwos.AutoSize = true;
            this.lblTwos.Location = new System.Drawing.Point(19, 172);
            this.lblTwos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTwos.Name = "lblTwos";
            this.lblTwos.Size = new System.Drawing.Size(61, 25);
            this.lblTwos.TabIndex = 73;
            this.lblTwos.Text = "Twos :";
            // 
            // lblMaxDelim
            // 
            this.lblMaxDelim.AutoSize = true;
            this.lblMaxDelim.Location = new System.Drawing.Point(19, 40);
            this.lblMaxDelim.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMaxDelim.Name = "lblMaxDelim";
            this.lblMaxDelim.Size = new System.Drawing.Size(133, 25);
            this.lblMaxDelim.TabIndex = 57;
            this.lblMaxDelim.Text = "Max Delimiters:";
            // 
            // lblOnes
            // 
            this.lblOnes.AutoSize = true;
            this.lblOnes.Location = new System.Drawing.Point(19, 130);
            this.lblOnes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOnes.Name = "lblOnes";
            this.lblOnes.Size = new System.Drawing.Size(62, 25);
            this.lblOnes.TabIndex = 69;
            this.lblOnes.Text = "Ones :";
            // 
            // cbMinWordLength
            // 
            this.cbMinWordLength.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMinWordLength.FormattingEnabled = true;
            this.cbMinWordLength.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.cbMinWordLength.Location = new System.Drawing.Point(447, 78);
            this.cbMinWordLength.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbMinWordLength.Name = "cbMinWordLength";
            this.cbMinWordLength.Size = new System.Drawing.Size(53, 33);
            this.cbMinWordLength.TabIndex = 68;
            // 
            // cbMaxOnes
            // 
            this.cbMaxOnes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMaxOnes.FormattingEnabled = true;
            this.cbMaxOnes.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.cbMaxOnes.Location = new System.Drawing.Point(196, 125);
            this.cbMaxOnes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbMaxOnes.Name = "cbMaxOnes";
            this.cbMaxOnes.Size = new System.Drawing.Size(53, 33);
            this.cbMaxOnes.TabIndex = 70;
            // 
            // lblMinWordLength
            // 
            this.lblMinWordLength.AutoSize = true;
            this.lblMinWordLength.Location = new System.Drawing.Point(269, 83);
            this.lblMinWordLength.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMinWordLength.Name = "lblMinWordLength";
            this.lblMinWordLength.Size = new System.Drawing.Size(159, 25);
            this.lblMinWordLength.TabIndex = 67;
            this.lblMinWordLength.Text = "Min Word Length :";
            // 
            // lblToOnes
            // 
            this.lblToOnes.AutoSize = true;
            this.lblToOnes.Location = new System.Drawing.Point(168, 130);
            this.lblToOnes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblToOnes.Name = "lblToOnes";
            this.lblToOnes.Size = new System.Drawing.Size(29, 25);
            this.lblToOnes.TabIndex = 71;
            this.lblToOnes.Text = "to";
            // 
            // cbMaxWordLength
            // 
            this.cbMaxWordLength.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMaxWordLength.FormattingEnabled = true;
            this.cbMaxWordLength.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50"});
            this.cbMaxWordLength.Location = new System.Drawing.Point(196, 82);
            this.cbMaxWordLength.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbMaxWordLength.Name = "cbMaxWordLength";
            this.cbMaxWordLength.Size = new System.Drawing.Size(53, 33);
            this.cbMaxWordLength.TabIndex = 66;
            // 
            // cbMaxDelim
            // 
            this.cbMaxDelim.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMaxDelim.FormattingEnabled = true;
            this.cbMaxDelim.Items.AddRange(new object[] {
            "-1",
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.cbMaxDelim.Location = new System.Drawing.Point(196, 37);
            this.cbMaxDelim.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbMaxDelim.Name = "cbMaxDelim";
            this.cbMaxDelim.Size = new System.Drawing.Size(53, 33);
            this.cbMaxDelim.TabIndex = 58;
            // 
            // cbMinOnes
            // 
            this.cbMinOnes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMinOnes.FormattingEnabled = true;
            this.cbMinOnes.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.cbMinOnes.Location = new System.Drawing.Point(113, 125);
            this.cbMinOnes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbMinOnes.Name = "cbMinOnes";
            this.cbMinOnes.Size = new System.Drawing.Size(53, 33);
            this.cbMinOnes.TabIndex = 72;
            // 
            // lblMaxWordLength
            // 
            this.lblMaxWordLength.AutoSize = true;
            this.lblMaxWordLength.Location = new System.Drawing.Point(19, 87);
            this.lblMaxWordLength.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMaxWordLength.Name = "lblMaxWordLength";
            this.lblMaxWordLength.Size = new System.Drawing.Size(162, 25);
            this.lblMaxWordLength.TabIndex = 65;
            this.lblMaxWordLength.Text = "Max Word Length :";
            // 
            // lblMinDelim
            // 
            this.lblMinDelim.AutoSize = true;
            this.lblMinDelim.Location = new System.Drawing.Point(269, 40);
            this.lblMinDelim.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMinDelim.Name = "lblMinDelim";
            this.lblMinDelim.Size = new System.Drawing.Size(130, 25);
            this.lblMinDelim.TabIndex = 59;
            this.lblMinDelim.Text = "Min Delimiters:";
            // 
            // cbMinDelim
            // 
            this.cbMinDelim.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMinDelim.FormattingEnabled = true;
            this.cbMinDelim.Items.AddRange(new object[] {
            "-1",
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.cbMinDelim.Location = new System.Drawing.Point(447, 35);
            this.cbMinDelim.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbMinDelim.Name = "cbMinDelim";
            this.cbMinDelim.Size = new System.Drawing.Size(53, 33);
            this.cbMinDelim.TabIndex = 60;
            // 
            // grpWordFiltering
            // 
            this.grpWordFiltering.Controls.Add(this.cbIncludePatternsSamples);
            this.grpWordFiltering.Controls.Add(this.cbExcludePatternsSamples);
            this.grpWordFiltering.Controls.Add(this.lblExcludePatterns);
            this.grpWordFiltering.Controls.Add(this.txtExcludePatterns);
            this.grpWordFiltering.Controls.Add(this.lblIncludePatterns);
            this.grpWordFiltering.Controls.Add(this.txtIncludePatterns);
            this.grpWordFiltering.Controls.Add(this.cbCombinationOrder);
            this.grpWordFiltering.Controls.Add(this.chkIncludeWordNotLast);
            this.grpWordFiltering.Controls.Add(this.lblCombinationOrder);
            this.grpWordFiltering.Controls.Add(this.cbWordsLimit);
            this.grpWordFiltering.Controls.Add(this.lblIncludeWord);
            this.grpWordFiltering.Controls.Add(this.lblWordsLimit);
            this.grpWordFiltering.Controls.Add(this.chkIncludeWordNotFirst);
            this.grpWordFiltering.Controls.Add(this.txtIncludeWord);
            this.grpWordFiltering.Location = new System.Drawing.Point(10, 7);
            this.grpWordFiltering.Name = "grpWordFiltering";
            this.grpWordFiltering.Size = new System.Drawing.Size(520, 258);
            this.grpWordFiltering.TabIndex = 85;
            this.grpWordFiltering.TabStop = false;
            this.grpWordFiltering.Text = "Word Filtering";
            // 
            // cbIncludePatternsSamples
            // 
            this.cbIncludePatternsSamples.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIncludePatternsSamples.DropDownWidth = 500;
            this.cbIncludePatternsSamples.FormattingEnabled = true;
            this.cbIncludePatternsSamples.Location = new System.Drawing.Point(449, 82);
            this.cbIncludePatternsSamples.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbIncludePatternsSamples.Name = "cbIncludePatternsSamples";
            this.cbIncludePatternsSamples.Size = new System.Drawing.Size(53, 33);
            this.cbIncludePatternsSamples.TabIndex = 57;
            this.cbIncludePatternsSamples.SelectedIndexChanged += new System.EventHandler(this.cbIncludePatternsSamples_SelectedIndexChanged);
            // 
            // cbExcludePatternsSamples
            // 
            this.cbExcludePatternsSamples.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbExcludePatternsSamples.DropDownWidth = 500;
            this.cbExcludePatternsSamples.FormattingEnabled = true;
            this.cbExcludePatternsSamples.Location = new System.Drawing.Point(449, 33);
            this.cbExcludePatternsSamples.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbExcludePatternsSamples.Name = "cbExcludePatternsSamples";
            this.cbExcludePatternsSamples.Size = new System.Drawing.Size(53, 33);
            this.cbExcludePatternsSamples.TabIndex = 56;
            this.cbExcludePatternsSamples.SelectedIndexChanged += new System.EventHandler(this.cbExcludePatternsSamples_SelectedIndexChanged);
            // 
            // cbCombinationOrder
            // 
            this.cbCombinationOrder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCombinationOrder.FormattingEnabled = true;
            this.cbCombinationOrder.Items.AddRange(new object[] {
            "Interval short/long",
            "Interval long/short",
            "Fewer/shorter words first",
            "Fewer/longer words first",
            "Greater/shorter words first",
            "Greater/longer words first"});
            this.cbCombinationOrder.Location = new System.Drawing.Point(173, 203);
            this.cbCombinationOrder.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbCombinationOrder.Name = "cbCombinationOrder";
            this.cbCombinationOrder.Size = new System.Drawing.Size(158, 33);
            this.cbCombinationOrder.TabIndex = 30;
            // 
            // chkIncludeWordNotLast
            // 
            this.chkIncludeWordNotLast.AutoSize = true;
            this.chkIncludeWordNotLast.Location = new System.Drawing.Point(357, 162);
            this.chkIncludeWordNotLast.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkIncludeWordNotLast.Name = "chkIncludeWordNotLast";
            this.chkIncludeWordNotLast.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkIncludeWordNotLast.Size = new System.Drawing.Size(146, 29);
            this.chkIncludeWordNotLast.TabIndex = 55;
            this.chkIncludeWordNotLast.Text = "Not last word";
            this.chkIncludeWordNotLast.UseVisualStyleBackColor = true;
            // 
            // chkIncludeWordNotFirst
            // 
            this.chkIncludeWordNotFirst.AutoSize = true;
            this.chkIncludeWordNotFirst.Location = new System.Drawing.Point(361, 123);
            this.chkIncludeWordNotFirst.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkIncludeWordNotFirst.Name = "chkIncludeWordNotFirst";
            this.chkIncludeWordNotFirst.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkIncludeWordNotFirst.Size = new System.Drawing.Size(143, 29);
            this.chkIncludeWordNotFirst.TabIndex = 37;
            this.chkIncludeWordNotFirst.Text = "Not 1st word";
            this.chkIncludeWordNotFirst.UseVisualStyleBackColor = true;
            // 
            // grpAdvanced
            // 
            this.grpAdvanced.Controls.Add(this.cbMinConcatWords);
            this.grpAdvanced.Controls.Add(this.cbMaxConcatWords);
            this.grpAdvanced.Controls.Add(this.lblMinConcatWords);
            this.grpAdvanced.Controls.Add(this.lblMaxConcatWords);
            this.grpAdvanced.Controls.Add(this.chkDictionaryAdvanced);
            this.grpAdvanced.Controls.Add(this.lblOnlyLastTwoWordsConcat);
            this.grpAdvanced.Controls.Add(this.chkOnlyLastTwoWordsConcat);
            this.grpAdvanced.Controls.Add(this.lblOnlyFirstTwoWordsConcat);
            this.grpAdvanced.Controls.Add(this.chkOnlyFirstTwoWordsConcat);
            this.grpAdvanced.Controls.Add(this.lblMaxConsecutiveConcat);
            this.grpAdvanced.Controls.Add(this.cbMinWordsLimit);
            this.grpAdvanced.Controls.Add(this.cbMaxConsecutiveConcat);
            this.grpAdvanced.Controls.Add(this.lblMinWordsLimit);
            this.grpAdvanced.Controls.Add(this.lblMinConsecutiveConcat);
            this.grpAdvanced.Controls.Add(this.cbMaxConsecutiveOnes);
            this.grpAdvanced.Controls.Add(this.cbMinConsecutiveConcat);
            this.grpAdvanced.Controls.Add(this.lblMaxConsecutiveOnes);
            this.grpAdvanced.Location = new System.Drawing.Point(10, 585);
            this.grpAdvanced.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpAdvanced.Name = "grpAdvanced";
            this.grpAdvanced.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpAdvanced.Size = new System.Drawing.Size(520, 218);
            this.grpAdvanced.TabIndex = 81;
            this.grpAdvanced.TabStop = false;
            this.grpAdvanced.Text = "      Advanced Attack";
            // 
            // cbMinConcatWords
            // 
            this.cbMinConcatWords.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMinConcatWords.FormattingEnabled = true;
            this.cbMinConcatWords.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.cbMinConcatWords.Location = new System.Drawing.Point(446, 38);
            this.cbMinConcatWords.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbMinConcatWords.Name = "cbMinConcatWords";
            this.cbMinConcatWords.Size = new System.Drawing.Size(53, 33);
            this.cbMinConcatWords.TabIndex = 82;
            // 
            // cbMaxConcatWords
            // 
            this.cbMaxConcatWords.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMaxConcatWords.FormattingEnabled = true;
            this.cbMaxConcatWords.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.cbMaxConcatWords.Location = new System.Drawing.Point(183, 38);
            this.cbMaxConcatWords.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbMaxConcatWords.Name = "cbMaxConcatWords";
            this.cbMaxConcatWords.Size = new System.Drawing.Size(53, 33);
            this.cbMaxConcatWords.TabIndex = 81;
            // 
            // lblMinConcatWords
            // 
            this.lblMinConcatWords.AutoSize = true;
            this.lblMinConcatWords.Location = new System.Drawing.Point(277, 42);
            this.lblMinConcatWords.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMinConcatWords.Name = "lblMinConcatWords";
            this.lblMinConcatWords.Size = new System.Drawing.Size(167, 25);
            this.lblMinConcatWords.TabIndex = 80;
            this.lblMinConcatWords.Text = "Min Concat. Words:";
            // 
            // lblMaxConcatWords
            // 
            this.lblMaxConcatWords.AutoSize = true;
            this.lblMaxConcatWords.Location = new System.Drawing.Point(6, 42);
            this.lblMaxConcatWords.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMaxConcatWords.Name = "lblMaxConcatWords";
            this.lblMaxConcatWords.Size = new System.Drawing.Size(170, 25);
            this.lblMaxConcatWords.TabIndex = 79;
            this.lblMaxConcatWords.Text = "Max Concat. Words:";
            // 
            // chkDictionaryAdvanced
            // 
            this.chkDictionaryAdvanced.AutoSize = true;
            this.chkDictionaryAdvanced.Location = new System.Drawing.Point(13, 2);
            this.chkDictionaryAdvanced.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkDictionaryAdvanced.Name = "chkDictionaryAdvanced";
            this.chkDictionaryAdvanced.Size = new System.Drawing.Size(22, 21);
            this.chkDictionaryAdvanced.TabIndex = 56;
            this.chkDictionaryAdvanced.UseVisualStyleBackColor = true;
            this.chkDictionaryAdvanced.CheckedChanged += new System.EventHandler(this.OnDictionaryAdvancedCheckedChanged);
            // 
            // lblOnlyLastTwoWordsConcat
            // 
            this.lblOnlyLastTwoWordsConcat.AutoSize = true;
            this.lblOnlyLastTwoWordsConcat.Location = new System.Drawing.Point(276, 177);
            this.lblOnlyLastTwoWordsConcat.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOnlyLastTwoWordsConcat.Name = "lblOnlyLastTwoWordsConcat";
            this.lblOnlyLastTwoWordsConcat.Size = new System.Drawing.Size(188, 25);
            this.lblOnlyLastTwoWordsConcat.TabIndex = 78;
            this.lblOnlyLastTwoWordsConcat.Text = "Last 2 Words Concat. :";
            // 
            // chkOnlyLastTwoWordsConcat
            // 
            this.chkOnlyLastTwoWordsConcat.AutoSize = true;
            this.chkOnlyLastTwoWordsConcat.Checked = true;
            this.chkOnlyLastTwoWordsConcat.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOnlyLastTwoWordsConcat.Location = new System.Drawing.Point(479, 178);
            this.chkOnlyLastTwoWordsConcat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkOnlyLastTwoWordsConcat.Name = "chkOnlyLastTwoWordsConcat";
            this.chkOnlyLastTwoWordsConcat.Size = new System.Drawing.Size(22, 21);
            this.chkOnlyLastTwoWordsConcat.TabIndex = 77;
            this.chkOnlyLastTwoWordsConcat.UseVisualStyleBackColor = true;
            // 
            // lblOnlyFirstTwoWordsConcat
            // 
            this.lblOnlyFirstTwoWordsConcat.AutoSize = true;
            this.lblOnlyFirstTwoWordsConcat.Location = new System.Drawing.Point(6, 177);
            this.lblOnlyFirstTwoWordsConcat.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOnlyFirstTwoWordsConcat.Name = "lblOnlyFirstTwoWordsConcat";
            this.lblOnlyFirstTwoWordsConcat.Size = new System.Drawing.Size(190, 25);
            this.lblOnlyFirstTwoWordsConcat.TabIndex = 38;
            this.lblOnlyFirstTwoWordsConcat.Text = "First 2 Words Concat. :";
            // 
            // chkOnlyFirstTwoWordsConcat
            // 
            this.chkOnlyFirstTwoWordsConcat.AutoSize = true;
            this.chkOnlyFirstTwoWordsConcat.Checked = true;
            this.chkOnlyFirstTwoWordsConcat.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOnlyFirstTwoWordsConcat.Location = new System.Drawing.Point(216, 178);
            this.chkOnlyFirstTwoWordsConcat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkOnlyFirstTwoWordsConcat.Name = "chkOnlyFirstTwoWordsConcat";
            this.chkOnlyFirstTwoWordsConcat.Size = new System.Drawing.Size(22, 21);
            this.chkOnlyFirstTwoWordsConcat.TabIndex = 37;
            this.chkOnlyFirstTwoWordsConcat.UseVisualStyleBackColor = true;
            // 
            // lblMaxConsecutiveConcat
            // 
            this.lblMaxConsecutiveConcat.AutoSize = true;
            this.lblMaxConsecutiveConcat.Location = new System.Drawing.Point(6, 85);
            this.lblMaxConsecutiveConcat.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMaxConsecutiveConcat.Name = "lblMaxConsecutiveConcat";
            this.lblMaxConsecutiveConcat.Size = new System.Drawing.Size(167, 25);
            this.lblMaxConsecutiveConcat.TabIndex = 61;
            this.lblMaxConsecutiveConcat.Text = "Max Cons. Concat. :";
            // 
            // cbMinWordsLimit
            // 
            this.cbMinWordsLimit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMinWordsLimit.FormattingEnabled = true;
            this.cbMinWordsLimit.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.cbMinWordsLimit.Location = new System.Drawing.Point(446, 127);
            this.cbMinWordsLimit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbMinWordsLimit.Name = "cbMinWordsLimit";
            this.cbMinWordsLimit.Size = new System.Drawing.Size(53, 33);
            this.cbMinWordsLimit.TabIndex = 76;
            // 
            // cbMaxConsecutiveConcat
            // 
            this.cbMaxConsecutiveConcat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMaxConsecutiveConcat.FormattingEnabled = true;
            this.cbMaxConsecutiveConcat.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.cbMaxConsecutiveConcat.Location = new System.Drawing.Point(183, 83);
            this.cbMaxConsecutiveConcat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbMaxConsecutiveConcat.Name = "cbMaxConsecutiveConcat";
            this.cbMaxConsecutiveConcat.Size = new System.Drawing.Size(53, 33);
            this.cbMaxConsecutiveConcat.TabIndex = 62;
            // 
            // lblMinWordsLimit
            // 
            this.lblMinWordsLimit.AutoSize = true;
            this.lblMinWordsLimit.Location = new System.Drawing.Point(277, 132);
            this.lblMinWordsLimit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMinWordsLimit.Name = "lblMinWordsLimit";
            this.lblMinWordsLimit.Size = new System.Drawing.Size(146, 25);
            this.lblMinWordsLimit.TabIndex = 75;
            this.lblMinWordsLimit.Text = "Min Words Limit:";
            // 
            // lblMinConsecutiveConcat
            // 
            this.lblMinConsecutiveConcat.AutoSize = true;
            this.lblMinConsecutiveConcat.Location = new System.Drawing.Point(277, 85);
            this.lblMinConsecutiveConcat.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMinConsecutiveConcat.Name = "lblMinConsecutiveConcat";
            this.lblMinConsecutiveConcat.Size = new System.Drawing.Size(164, 25);
            this.lblMinConsecutiveConcat.TabIndex = 63;
            this.lblMinConsecutiveConcat.Text = "Min Cons. Concat. :";
            // 
            // cbMaxConsecutiveOnes
            // 
            this.cbMaxConsecutiveOnes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMaxConsecutiveOnes.FormattingEnabled = true;
            this.cbMaxConsecutiveOnes.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.cbMaxConsecutiveOnes.Location = new System.Drawing.Point(183, 127);
            this.cbMaxConsecutiveOnes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbMaxConsecutiveOnes.Name = "cbMaxConsecutiveOnes";
            this.cbMaxConsecutiveOnes.Size = new System.Drawing.Size(53, 33);
            this.cbMaxConsecutiveOnes.TabIndex = 74;
            // 
            // cbMinConsecutiveConcat
            // 
            this.cbMinConsecutiveConcat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMinConsecutiveConcat.FormattingEnabled = true;
            this.cbMinConsecutiveConcat.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.cbMinConsecutiveConcat.Location = new System.Drawing.Point(446, 83);
            this.cbMinConsecutiveConcat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbMinConsecutiveConcat.Name = "cbMinConsecutiveConcat";
            this.cbMinConsecutiveConcat.Size = new System.Drawing.Size(53, 33);
            this.cbMinConsecutiveConcat.TabIndex = 64;
            // 
            // lblMaxConsecutiveOnes
            // 
            this.lblMaxConsecutiveOnes.AutoSize = true;
            this.lblMaxConsecutiveOnes.Location = new System.Drawing.Point(6, 132);
            this.lblMaxConsecutiveOnes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMaxConsecutiveOnes.Name = "lblMaxConsecutiveOnes";
            this.lblMaxConsecutiveOnes.Size = new System.Drawing.Size(149, 25);
            this.lblMaxConsecutiveOnes.TabIndex = 73;
            this.lblMaxConsecutiveOnes.Text = "Max Cons. Ones :";
            // 
            // grpTypos
            // 
            this.grpTypos.Controls.Add(this.txtTyposAppendLetters);
            this.grpTypos.Controls.Add(this.lblTyposAppendLetters);
            this.grpTypos.Controls.Add(this.txtTyposSwapLetters);
            this.grpTypos.Controls.Add(this.lblTyposSwapLetters);
            this.grpTypos.Controls.Add(this.chkTyposReverseLetter);
            this.grpTypos.Controls.Add(this.chkTyposWrongLetter);
            this.grpTypos.Controls.Add(this.chkTyposExtraLetter);
            this.grpTypos.Controls.Add(this.chkTyposDoubleLetter);
            this.grpTypos.Controls.Add(this.chkTyposSkipLetter);
            this.grpTypos.Controls.Add(this.chkTyposSkipDoubleLetter);
            this.grpTypos.Location = new System.Drawing.Point(10, 812);
            this.grpTypos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpTypos.Name = "grpTypos";
            this.grpTypos.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpTypos.Size = new System.Drawing.Size(519, 158);
            this.grpTypos.TabIndex = 80;
            this.grpTypos.TabStop = false;
            this.grpTypos.Text = "Typos";
            // 
            // txtTyposAppendLetters
            // 
            this.txtTyposAppendLetters.Location = new System.Drawing.Point(391, 110);
            this.txtTyposAppendLetters.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTyposAppendLetters.Name = "txtTyposAppendLetters";
            this.txtTyposAppendLetters.PlaceholderText = "s,ed";
            this.txtTyposAppendLetters.Size = new System.Drawing.Size(108, 31);
            this.txtTyposAppendLetters.TabIndex = 88;
            // 
            // lblTyposAppendLetters
            // 
            this.lblTyposAppendLetters.AutoSize = true;
            this.lblTyposAppendLetters.Location = new System.Drawing.Point(261, 117);
            this.lblTyposAppendLetters.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTyposAppendLetters.Name = "lblTyposAppendLetters";
            this.lblTyposAppendLetters.Size = new System.Drawing.Size(129, 25);
            this.lblTyposAppendLetters.TabIndex = 87;
            this.lblTyposAppendLetters.Text = "Append Letter:";
            // 
            // txtTyposSwapLetters
            // 
            this.txtTyposSwapLetters.Location = new System.Drawing.Point(126, 112);
            this.txtTyposSwapLetters.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTyposSwapLetters.Name = "txtTyposSwapLetters";
            this.txtTyposSwapLetters.PlaceholderText = "l-r,a-e,i-y";
            this.txtTyposSwapLetters.Size = new System.Drawing.Size(108, 31);
            this.txtTyposSwapLetters.TabIndex = 86;
            // 
            // lblTyposSwapLetters
            // 
            this.lblTyposSwapLetters.AutoSize = true;
            this.lblTyposSwapLetters.Location = new System.Drawing.Point(17, 117);
            this.lblTyposSwapLetters.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTyposSwapLetters.Name = "lblTyposSwapLetters";
            this.lblTyposSwapLetters.Size = new System.Drawing.Size(106, 25);
            this.lblTyposSwapLetters.TabIndex = 85;
            this.lblTyposSwapLetters.Text = "Letter swap:";
            // 
            // chkTyposReverseLetter
            // 
            this.chkTyposReverseLetter.AutoSize = true;
            this.chkTyposReverseLetter.Checked = true;
            this.chkTyposReverseLetter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTyposReverseLetter.Location = new System.Drawing.Point(173, 35);
            this.chkTyposReverseLetter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkTyposReverseLetter.Name = "chkTyposReverseLetter";
            this.chkTyposReverseLetter.Size = new System.Drawing.Size(147, 29);
            this.chkTyposReverseLetter.TabIndex = 84;
            this.chkTyposReverseLetter.Text = "Reverse Letter";
            this.chkTyposReverseLetter.UseVisualStyleBackColor = true;
            // 
            // chkTyposWrongLetter
            // 
            this.chkTyposWrongLetter.AutoSize = true;
            this.chkTyposWrongLetter.Checked = true;
            this.chkTyposWrongLetter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTyposWrongLetter.Location = new System.Drawing.Point(173, 77);
            this.chkTyposWrongLetter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkTyposWrongLetter.Name = "chkTyposWrongLetter";
            this.chkTyposWrongLetter.Size = new System.Drawing.Size(142, 29);
            this.chkTyposWrongLetter.TabIndex = 83;
            this.chkTyposWrongLetter.Text = "Wrong Letter";
            this.chkTyposWrongLetter.UseVisualStyleBackColor = true;
            // 
            // chkTyposExtraLetter
            // 
            this.chkTyposExtraLetter.AutoSize = true;
            this.chkTyposExtraLetter.Checked = true;
            this.chkTyposExtraLetter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTyposExtraLetter.Location = new System.Drawing.Point(17, 35);
            this.chkTyposExtraLetter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkTyposExtraLetter.Name = "chkTyposExtraLetter";
            this.chkTyposExtraLetter.Size = new System.Drawing.Size(125, 29);
            this.chkTyposExtraLetter.TabIndex = 82;
            this.chkTyposExtraLetter.Text = "Extra Letter";
            this.chkTyposExtraLetter.UseVisualStyleBackColor = true;
            // 
            // chkTyposDoubleLetter
            // 
            this.chkTyposDoubleLetter.AutoSize = true;
            this.chkTyposDoubleLetter.Checked = true;
            this.chkTyposDoubleLetter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTyposDoubleLetter.Location = new System.Drawing.Point(337, 35);
            this.chkTyposDoubleLetter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkTyposDoubleLetter.Name = "chkTyposDoubleLetter";
            this.chkTyposDoubleLetter.Size = new System.Drawing.Size(145, 29);
            this.chkTyposDoubleLetter.TabIndex = 81;
            this.chkTyposDoubleLetter.Text = "Double Letter";
            this.chkTyposDoubleLetter.UseVisualStyleBackColor = true;
            // 
            // chkTyposSkipLetter
            // 
            this.chkTyposSkipLetter.AutoSize = true;
            this.chkTyposSkipLetter.Checked = true;
            this.chkTyposSkipLetter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTyposSkipLetter.Location = new System.Drawing.Point(17, 77);
            this.chkTyposSkipLetter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkTyposSkipLetter.Name = "chkTyposSkipLetter";
            this.chkTyposSkipLetter.Size = new System.Drawing.Size(121, 29);
            this.chkTyposSkipLetter.TabIndex = 80;
            this.chkTyposSkipLetter.Text = "Skip Letter";
            this.chkTyposSkipLetter.UseVisualStyleBackColor = true;
            // 
            // chkTyposSkipDoubleLetter
            // 
            this.chkTyposSkipDoubleLetter.AutoSize = true;
            this.chkTyposSkipDoubleLetter.Checked = true;
            this.chkTyposSkipDoubleLetter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTyposSkipDoubleLetter.Location = new System.Drawing.Point(337, 77);
            this.chkTyposSkipDoubleLetter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkTyposSkipDoubleLetter.Name = "chkTyposSkipDoubleLetter";
            this.chkTyposSkipDoubleLetter.Size = new System.Drawing.Size(184, 29);
            this.chkTyposSkipDoubleLetter.TabIndex = 79;
            this.chkTyposSkipDoubleLetter.Text = "Skip Double Letter";
            this.chkTyposSkipDoubleLetter.UseVisualStyleBackColor = true;
            // 
            // pnlDictBruteforce
            // 
            this.pnlDictBruteforce.Controls.Add(this.tabControl);
            this.pnlDictBruteforce.Location = new System.Drawing.Point(531, 2);
            this.pnlDictBruteforce.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlDictBruteforce.Name = "pnlDictBruteforce";
            this.pnlDictBruteforce.Size = new System.Drawing.Size(650, 977);
            this.pnlDictBruteforce.TabIndex = 87;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Controls.Add(this.tabPage3);
            this.tabControl.Location = new System.Drawing.Point(7, 18);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(634, 963);
            this.tabControl.TabIndex = 84;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tabMainDictionaries);
            this.tabPage1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(626, 925);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Main Dictionary";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabMainDictionaries
            // 
            this.tabMainDictionaries.Controls.Add(this.tabMainDictionariesCommon);
            this.tabMainDictionaries.Controls.Add(this.tabMainDictionariesCustom);
            this.tabMainDictionaries.Controls.Add(this.tabMainDictionariesExcludeWords);
            this.tabMainDictionaries.Location = new System.Drawing.Point(0, 0);
            this.tabMainDictionaries.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabMainDictionaries.Name = "tabMainDictionaries";
            this.tabMainDictionaries.SelectedIndex = 0;
            this.tabMainDictionaries.Size = new System.Drawing.Size(623, 917);
            this.tabMainDictionaries.TabIndex = 85;
            // 
            // tabMainDictionariesCommon
            // 
            this.tabMainDictionariesCommon.Controls.Add(this.chkDictCacheSuffix);
            this.tabMainDictionariesCommon.Controls.Add(this.chkDictCachePrefix);
            this.tabMainDictionariesCommon.Controls.Add(this.txtDictionaryFilterFirstTo);
            this.tabMainDictionariesCommon.Controls.Add(this.lblDictionaryFilterFirstTo);
            this.tabMainDictionariesCommon.Controls.Add(this.chkDictionariesUse);
            this.tabMainDictionariesCommon.Controls.Add(this.lblDictionariesUse);
            this.tabMainDictionariesCommon.Controls.Add(this.btnDictUnselected);
            this.tabMainDictionariesCommon.Controls.Add(this.tvDictMain);
            this.tabMainDictionariesCommon.Controls.Add(this.chkDictReverseOrder);
            this.tabMainDictionariesCommon.Controls.Add(this.chkDictAddTypos);
            this.tabMainDictionariesCommon.Controls.Add(this.txtDictionaryFilterFirstFrom);
            this.tabMainDictionariesCommon.Controls.Add(this.chkDictForceLowercase);
            this.tabMainDictionariesCommon.Controls.Add(this.lblDictionaryFilterFirstFrom);
            this.tabMainDictionariesCommon.Controls.Add(this.chkDictSkipSpecials);
            this.tabMainDictionariesCommon.Controls.Add(this.chkDictSkipDigits);
            this.tabMainDictionariesCommon.Location = new System.Drawing.Point(4, 32);
            this.tabMainDictionariesCommon.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabMainDictionariesCommon.Name = "tabMainDictionariesCommon";
            this.tabMainDictionariesCommon.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabMainDictionariesCommon.Size = new System.Drawing.Size(615, 881);
            this.tabMainDictionariesCommon.TabIndex = 0;
            this.tabMainDictionariesCommon.Text = "Common Dictionaries";
            this.tabMainDictionariesCommon.UseVisualStyleBackColor = true;
            // 
            // txtDictionaryFilterFirstTo
            // 
            this.txtDictionaryFilterFirstTo.Location = new System.Drawing.Point(9, 342);
            this.txtDictionaryFilterFirstTo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDictionaryFilterFirstTo.Name = "txtDictionaryFilterFirstTo";
            this.txtDictionaryFilterFirstTo.PlaceholderText = "zelda";
            this.txtDictionaryFilterFirstTo.Size = new System.Drawing.Size(138, 29);
            this.txtDictionaryFilterFirstTo.TabIndex = 95;
            // 
            // lblDictionaryFilterFirstTo
            // 
            this.lblDictionaryFilterFirstTo.AutoSize = true;
            this.lblDictionaryFilterFirstTo.Location = new System.Drawing.Point(13, 313);
            this.lblDictionaryFilterFirstTo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDictionaryFilterFirstTo.Name = "lblDictionaryFilterFirstTo";
            this.lblDictionaryFilterFirstTo.Size = new System.Drawing.Size(30, 23);
            this.lblDictionaryFilterFirstTo.TabIndex = 94;
            this.lblDictionaryFilterFirstTo.Text = "to:";
            // 
            // chkDictionariesUse
            // 
            this.chkDictionariesUse.AutoSize = true;
            this.chkDictionariesUse.Location = new System.Drawing.Point(114, 13);
            this.chkDictionariesUse.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkDictionariesUse.Name = "chkDictionariesUse";
            this.chkDictionariesUse.Size = new System.Drawing.Size(22, 21);
            this.chkDictionariesUse.TabIndex = 93;
            this.chkDictionariesUse.UseVisualStyleBackColor = true;
            this.chkDictionariesUse.CheckedChanged += new System.EventHandler(this.chkDictionariesUse_CheckedChanged);
            // 
            // lblDictionariesUse
            // 
            this.lblDictionariesUse.AutoSize = true;
            this.lblDictionariesUse.Location = new System.Drawing.Point(9, 12);
            this.lblDictionariesUse.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDictionariesUse.Name = "lblDictionariesUse";
            this.lblDictionariesUse.Size = new System.Drawing.Size(42, 23);
            this.lblDictionariesUse.TabIndex = 22;
            this.lblDictionariesUse.Text = "Use:";
            // 
            // btnDictUnselected
            // 
            this.btnDictUnselected.Location = new System.Drawing.Point(6, 828);
            this.btnDictUnselected.Name = "btnDictUnselected";
            this.btnDictUnselected.Size = new System.Drawing.Size(146, 37);
            this.btnDictUnselected.TabIndex = 55;
            this.btnDictUnselected.Text = "Unselect All";
            this.btnDictUnselected.UseVisualStyleBackColor = true;
            this.btnDictUnselected.Click += new System.EventHandler(this.btnDictUnselected_Click);
            // 
            // tvDictMain
            // 
            this.tvDictMain.Location = new System.Drawing.Point(156, 3);
            this.tvDictMain.Name = "tvDictMain";
            this.tvDictMain.Size = new System.Drawing.Size(451, 864);
            this.tvDictMain.TabIndex = 84;
            this.tvDictMain.TriStateStyleProperty = RikTheVeggie.TriStateTreeView.TriStateStyles.Standard;
            // 
            // chkDictReverseOrder
            // 
            this.chkDictReverseOrder.AutoSize = true;
            this.chkDictReverseOrder.Location = new System.Drawing.Point(9, 200);
            this.chkDictReverseOrder.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkDictReverseOrder.Name = "chkDictReverseOrder";
            this.chkDictReverseOrder.Size = new System.Drawing.Size(143, 27);
            this.chkDictReverseOrder.TabIndex = 54;
            this.chkDictReverseOrder.Text = "Reverse Order";
            this.chkDictReverseOrder.UseVisualStyleBackColor = true;
            // 
            // chkDictAddTypos
            // 
            this.chkDictAddTypos.AutoSize = true;
            this.chkDictAddTypos.Location = new System.Drawing.Point(9, 162);
            this.chkDictAddTypos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkDictAddTypos.Name = "chkDictAddTypos";
            this.chkDictAddTypos.Size = new System.Drawing.Size(115, 27);
            this.chkDictAddTypos.TabIndex = 53;
            this.chkDictAddTypos.Text = "Add Typos";
            this.chkDictAddTypos.UseVisualStyleBackColor = true;
            // 
            // txtDictionaryFilterFirstFrom
            // 
            this.txtDictionaryFilterFirstFrom.Location = new System.Drawing.Point(9, 270);
            this.txtDictionaryFilterFirstFrom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDictionaryFilterFirstFrom.Name = "txtDictionaryFilterFirstFrom";
            this.txtDictionaryFilterFirstFrom.PlaceholderText = "alucard";
            this.txtDictionaryFilterFirstFrom.Size = new System.Drawing.Size(138, 29);
            this.txtDictionaryFilterFirstFrom.TabIndex = 82;
            // 
            // chkDictForceLowercase
            // 
            this.chkDictForceLowercase.AutoSize = true;
            this.chkDictForceLowercase.Checked = true;
            this.chkDictForceLowercase.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDictForceLowercase.Location = new System.Drawing.Point(9, 123);
            this.chkDictForceLowercase.Margin = new System.Windows.Forms.Padding(4, 5, 0, 5);
            this.chkDictForceLowercase.Name = "chkDictForceLowercase";
            this.chkDictForceLowercase.Size = new System.Drawing.Size(114, 27);
            this.chkDictForceLowercase.TabIndex = 52;
            this.chkDictForceLowercase.Text = "Lowercase";
            this.chkDictForceLowercase.UseVisualStyleBackColor = true;
            // 
            // lblDictionaryFilterFirstFrom
            // 
            this.lblDictionaryFilterFirstFrom.AutoSize = true;
            this.lblDictionaryFilterFirstFrom.Location = new System.Drawing.Point(9, 242);
            this.lblDictionaryFilterFirstFrom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDictionaryFilterFirstFrom.Name = "lblDictionaryFilterFirstFrom";
            this.lblDictionaryFilterFirstFrom.Size = new System.Drawing.Size(132, 23);
            this.lblDictionaryFilterFirstFrom.TabIndex = 83;
            this.lblDictionaryFilterFirstFrom.Text = "First Word from:";
            // 
            // chkDictSkipSpecials
            // 
            this.chkDictSkipSpecials.AutoSize = true;
            this.chkDictSkipSpecials.Checked = true;
            this.chkDictSkipSpecials.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDictSkipSpecials.Location = new System.Drawing.Point(9, 85);
            this.chkDictSkipSpecials.Margin = new System.Windows.Forms.Padding(4, 5, 0, 5);
            this.chkDictSkipSpecials.Name = "chkDictSkipSpecials";
            this.chkDictSkipSpecials.Size = new System.Drawing.Size(132, 27);
            this.chkDictSkipSpecials.TabIndex = 51;
            this.chkDictSkipSpecials.Text = "Skip Specials";
            this.chkDictSkipSpecials.UseVisualStyleBackColor = true;
            // 
            // chkDictSkipDigits
            // 
            this.chkDictSkipDigits.AutoSize = true;
            this.chkDictSkipDigits.Location = new System.Drawing.Point(9, 47);
            this.chkDictSkipDigits.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkDictSkipDigits.Name = "chkDictSkipDigits";
            this.chkDictSkipDigits.Size = new System.Drawing.Size(115, 27);
            this.chkDictSkipDigits.TabIndex = 50;
            this.chkDictSkipDigits.Text = "Skip Digits";
            this.chkDictSkipDigits.UseVisualStyleBackColor = true;
            // 
            // tabMainDictionariesCustom
            // 
            this.tabMainDictionariesCustom.Controls.Add(this.chkDictionariesCustomWordsUse);
            this.tabMainDictionariesCustom.Controls.Add(this.lblDictionariesCustomWordsUse);
            this.tabMainDictionariesCustom.Controls.Add(this.lblDictionariesCustomWordsAtLeast);
            this.tabMainDictionariesCustom.Controls.Add(this.lblDictionariesCustomWordsHash);
            this.tabMainDictionariesCustom.Controls.Add(this.cbDictionariesCustomWordsMinimumInHash);
            this.tabMainDictionariesCustom.Controls.Add(this.lblDictionariesCustomWordsFiltering);
            this.tabMainDictionariesCustom.Controls.Add(this.chkDictCustomWordsAddTypos);
            this.tabMainDictionariesCustom.Controls.Add(this.chkDictCustomWordsForceLowercase);
            this.tabMainDictionariesCustom.Controls.Add(this.chkDictCustomWordsSkipSpecials);
            this.tabMainDictionariesCustom.Controls.Add(this.chkDictCustomWordsSkipDigits);
            this.tabMainDictionariesCustom.Controls.Add(this.txtDictCustWords);
            this.tabMainDictionariesCustom.Location = new System.Drawing.Point(4, 32);
            this.tabMainDictionariesCustom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabMainDictionariesCustom.Name = "tabMainDictionariesCustom";
            this.tabMainDictionariesCustom.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabMainDictionariesCustom.Size = new System.Drawing.Size(615, 881);
            this.tabMainDictionariesCustom.TabIndex = 1;
            this.tabMainDictionariesCustom.Text = "Custom Words";
            this.tabMainDictionariesCustom.UseVisualStyleBackColor = true;
            // 
            // chkDictionariesCustomWordsUse
            // 
            this.chkDictionariesCustomWordsUse.AutoSize = true;
            this.chkDictionariesCustomWordsUse.Location = new System.Drawing.Point(114, 13);
            this.chkDictionariesCustomWordsUse.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkDictionariesCustomWordsUse.Name = "chkDictionariesCustomWordsUse";
            this.chkDictionariesCustomWordsUse.Size = new System.Drawing.Size(22, 21);
            this.chkDictionariesCustomWordsUse.TabIndex = 92;
            this.chkDictionariesCustomWordsUse.UseVisualStyleBackColor = true;
            this.chkDictionariesCustomWordsUse.CheckedChanged += new System.EventHandler(this.chkDictionariesCustomWordsUse_CheckedChanged);
            // 
            // lblDictionariesCustomWordsUse
            // 
            this.lblDictionariesCustomWordsUse.AutoSize = true;
            this.lblDictionariesCustomWordsUse.Location = new System.Drawing.Point(9, 12);
            this.lblDictionariesCustomWordsUse.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDictionariesCustomWordsUse.Name = "lblDictionariesCustomWordsUse";
            this.lblDictionariesCustomWordsUse.Size = new System.Drawing.Size(42, 23);
            this.lblDictionariesCustomWordsUse.TabIndex = 91;
            this.lblDictionariesCustomWordsUse.Text = "Use:";
            // 
            // lblDictionariesCustomWordsAtLeast
            // 
            this.lblDictionariesCustomWordsAtLeast.AutoSize = true;
            this.lblDictionariesCustomWordsAtLeast.Location = new System.Drawing.Point(13, 245);
            this.lblDictionariesCustomWordsAtLeast.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDictionariesCustomWordsAtLeast.Name = "lblDictionariesCustomWordsAtLeast";
            this.lblDictionariesCustomWordsAtLeast.Size = new System.Drawing.Size(67, 23);
            this.lblDictionariesCustomWordsAtLeast.TabIndex = 89;
            this.lblDictionariesCustomWordsAtLeast.Text = "At least";
            // 
            // lblDictionariesCustomWordsHash
            // 
            this.lblDictionariesCustomWordsHash.AutoSize = true;
            this.lblDictionariesCustomWordsHash.Location = new System.Drawing.Point(13, 277);
            this.lblDictionariesCustomWordsHash.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDictionariesCustomWordsHash.Name = "lblDictionariesCustomWordsHash";
            this.lblDictionariesCustomWordsHash.Size = new System.Drawing.Size(125, 23);
            this.lblDictionariesCustomWordsHash.TabIndex = 88;
            this.lblDictionariesCustomWordsHash.Text = "word(s) in hash";
            // 
            // cbDictionariesCustomWordsMinimumInHash
            // 
            this.cbDictionariesCustomWordsMinimumInHash.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDictionariesCustomWordsMinimumInHash.FormattingEnabled = true;
            this.cbDictionariesCustomWordsMinimumInHash.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3"});
            this.cbDictionariesCustomWordsMinimumInHash.Location = new System.Drawing.Point(81, 238);
            this.cbDictionariesCustomWordsMinimumInHash.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbDictionariesCustomWordsMinimumInHash.Name = "cbDictionariesCustomWordsMinimumInHash";
            this.cbDictionariesCustomWordsMinimumInHash.Size = new System.Drawing.Size(53, 31);
            this.cbDictionariesCustomWordsMinimumInHash.TabIndex = 87;
            // 
            // lblDictionariesCustomWordsFiltering
            // 
            this.lblDictionariesCustomWordsFiltering.AutoSize = true;
            this.lblDictionariesCustomWordsFiltering.Location = new System.Drawing.Point(9, 203);
            this.lblDictionariesCustomWordsFiltering.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDictionariesCustomWordsFiltering.Name = "lblDictionariesCustomWordsFiltering";
            this.lblDictionariesCustomWordsFiltering.Size = new System.Drawing.Size(123, 23);
            this.lblDictionariesCustomWordsFiltering.TabIndex = 86;
            this.lblDictionariesCustomWordsFiltering.Text = "Filtering (slow):";
            // 
            // chkDictCustomWordsAddTypos
            // 
            this.chkDictCustomWordsAddTypos.AutoSize = true;
            this.chkDictCustomWordsAddTypos.Location = new System.Drawing.Point(9, 162);
            this.chkDictCustomWordsAddTypos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkDictCustomWordsAddTypos.Name = "chkDictCustomWordsAddTypos";
            this.chkDictCustomWordsAddTypos.Size = new System.Drawing.Size(115, 27);
            this.chkDictCustomWordsAddTypos.TabIndex = 58;
            this.chkDictCustomWordsAddTypos.Text = "Add Typos";
            this.chkDictCustomWordsAddTypos.UseVisualStyleBackColor = true;
            // 
            // chkDictCustomWordsForceLowercase
            // 
            this.chkDictCustomWordsForceLowercase.AutoSize = true;
            this.chkDictCustomWordsForceLowercase.Checked = true;
            this.chkDictCustomWordsForceLowercase.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDictCustomWordsForceLowercase.Location = new System.Drawing.Point(9, 123);
            this.chkDictCustomWordsForceLowercase.Margin = new System.Windows.Forms.Padding(4, 5, 0, 5);
            this.chkDictCustomWordsForceLowercase.Name = "chkDictCustomWordsForceLowercase";
            this.chkDictCustomWordsForceLowercase.Size = new System.Drawing.Size(114, 27);
            this.chkDictCustomWordsForceLowercase.TabIndex = 57;
            this.chkDictCustomWordsForceLowercase.Text = "Lowercase";
            this.chkDictCustomWordsForceLowercase.UseVisualStyleBackColor = true;
            // 
            // chkDictCustomWordsSkipSpecials
            // 
            this.chkDictCustomWordsSkipSpecials.AutoSize = true;
            this.chkDictCustomWordsSkipSpecials.Checked = true;
            this.chkDictCustomWordsSkipSpecials.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDictCustomWordsSkipSpecials.Location = new System.Drawing.Point(9, 85);
            this.chkDictCustomWordsSkipSpecials.Margin = new System.Windows.Forms.Padding(4, 5, 0, 5);
            this.chkDictCustomWordsSkipSpecials.Name = "chkDictCustomWordsSkipSpecials";
            this.chkDictCustomWordsSkipSpecials.Size = new System.Drawing.Size(132, 27);
            this.chkDictCustomWordsSkipSpecials.TabIndex = 56;
            this.chkDictCustomWordsSkipSpecials.Text = "Skip Specials";
            this.chkDictCustomWordsSkipSpecials.UseVisualStyleBackColor = true;
            // 
            // chkDictCustomWordsSkipDigits
            // 
            this.chkDictCustomWordsSkipDigits.AutoSize = true;
            this.chkDictCustomWordsSkipDigits.Location = new System.Drawing.Point(9, 47);
            this.chkDictCustomWordsSkipDigits.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkDictCustomWordsSkipDigits.Name = "chkDictCustomWordsSkipDigits";
            this.chkDictCustomWordsSkipDigits.Size = new System.Drawing.Size(115, 27);
            this.chkDictCustomWordsSkipDigits.TabIndex = 55;
            this.chkDictCustomWordsSkipDigits.Text = "Skip Digits";
            this.chkDictCustomWordsSkipDigits.UseVisualStyleBackColor = true;
            // 
            // txtDictCustWords
            // 
            this.txtDictCustWords.Location = new System.Drawing.Point(156, 3);
            this.txtDictCustWords.Multiline = true;
            this.txtDictCustWords.Name = "txtDictCustWords";
            this.txtDictCustWords.Size = new System.Drawing.Size(451, 864);
            this.txtDictCustWords.TabIndex = 0;
            // 
            // tabMainDictionariesExcludeWords
            // 
            this.tabMainDictionariesExcludeWords.Controls.Add(this.chkDictExcludePartialWords);
            this.tabMainDictionariesExcludeWords.Controls.Add(this.chkDictionariesExcludeWordsUse);
            this.tabMainDictionariesExcludeWords.Controls.Add(this.lblDictionariesExcludeWordsUse);
            this.tabMainDictionariesExcludeWords.Controls.Add(this.txtDictExcludeWords);
            this.tabMainDictionariesExcludeWords.Location = new System.Drawing.Point(4, 32);
            this.tabMainDictionariesExcludeWords.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabMainDictionariesExcludeWords.Name = "tabMainDictionariesExcludeWords";
            this.tabMainDictionariesExcludeWords.Size = new System.Drawing.Size(615, 881);
            this.tabMainDictionariesExcludeWords.TabIndex = 2;
            this.tabMainDictionariesExcludeWords.Text = "Exclude Words";
            this.tabMainDictionariesExcludeWords.UseVisualStyleBackColor = true;
            // 
            // chkDictExcludePartialWords
            // 
            this.chkDictExcludePartialWords.AutoSize = true;
            this.chkDictExcludePartialWords.Location = new System.Drawing.Point(9, 47);
            this.chkDictExcludePartialWords.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkDictExcludePartialWords.Name = "chkDictExcludePartialWords";
            this.chkDictExcludePartialWords.Size = new System.Drawing.Size(133, 27);
            this.chkDictExcludePartialWords.TabIndex = 93;
            this.chkDictExcludePartialWords.Text = "Partial words";
            this.chkDictExcludePartialWords.UseVisualStyleBackColor = true;
            // 
            // chkDictionariesExcludeWordsUse
            // 
            this.chkDictionariesExcludeWordsUse.AutoSize = true;
            this.chkDictionariesExcludeWordsUse.Location = new System.Drawing.Point(114, 13);
            this.chkDictionariesExcludeWordsUse.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkDictionariesExcludeWordsUse.Name = "chkDictionariesExcludeWordsUse";
            this.chkDictionariesExcludeWordsUse.Size = new System.Drawing.Size(22, 21);
            this.chkDictionariesExcludeWordsUse.TabIndex = 92;
            this.chkDictionariesExcludeWordsUse.UseVisualStyleBackColor = true;
            this.chkDictionariesExcludeWordsUse.CheckedChanged += new System.EventHandler(this.chkDictionariesExcludeWordsUse_CheckedChanged);
            // 
            // lblDictionariesExcludeWordsUse
            // 
            this.lblDictionariesExcludeWordsUse.AutoSize = true;
            this.lblDictionariesExcludeWordsUse.Location = new System.Drawing.Point(9, 12);
            this.lblDictionariesExcludeWordsUse.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDictionariesExcludeWordsUse.Name = "lblDictionariesExcludeWordsUse";
            this.lblDictionariesExcludeWordsUse.Size = new System.Drawing.Size(42, 23);
            this.lblDictionariesExcludeWordsUse.TabIndex = 91;
            this.lblDictionariesExcludeWordsUse.Text = "Use:";
            // 
            // txtDictExcludeWords
            // 
            this.txtDictExcludeWords.Location = new System.Drawing.Point(156, 3);
            this.txtDictExcludeWords.Multiline = true;
            this.txtDictExcludeWords.Name = "txtDictExcludeWords";
            this.txtDictExcludeWords.Size = new System.Drawing.Size(451, 864);
            this.txtDictExcludeWords.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tabFirstWordDictionaries);
            this.tabPage2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(626, 925);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "First Word Overrides";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabFirstWordDictionaries
            // 
            this.tabFirstWordDictionaries.Controls.Add(this.tabFirstWordDictionariesCommon);
            this.tabFirstWordDictionaries.Controls.Add(this.tabFirstWordDictionariesCustom);
            this.tabFirstWordDictionaries.Controls.Add(this.tabFirstWordDictionariesExcludeWords);
            this.tabFirstWordDictionaries.Location = new System.Drawing.Point(0, 0);
            this.tabFirstWordDictionaries.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabFirstWordDictionaries.Name = "tabFirstWordDictionaries";
            this.tabFirstWordDictionaries.SelectedIndex = 0;
            this.tabFirstWordDictionaries.Size = new System.Drawing.Size(623, 917);
            this.tabFirstWordDictionaries.TabIndex = 86;
            // 
            // tabFirstWordDictionariesCommon
            // 
            this.tabFirstWordDictionariesCommon.Controls.Add(this.lblDictionariesFirstWordUse);
            this.tabFirstWordDictionariesCommon.Controls.Add(this.tvDictFirstWord);
            this.tabFirstWordDictionariesCommon.Controls.Add(this.chkDictFirstReverseOrder);
            this.tabFirstWordDictionariesCommon.Controls.Add(this.btnCopyToDictFirst);
            this.tabFirstWordDictionariesCommon.Controls.Add(this.btnDictFirstUnselected);
            this.tabFirstWordDictionariesCommon.Controls.Add(this.chkDictFirstAddTypos);
            this.tabFirstWordDictionariesCommon.Controls.Add(this.chkDictFirstForceLowercase);
            this.tabFirstWordDictionariesCommon.Controls.Add(this.chkDictFirstSkipSpecials);
            this.tabFirstWordDictionariesCommon.Controls.Add(this.chkUseDictFirst);
            this.tabFirstWordDictionariesCommon.Controls.Add(this.chkDictFirstSkipDigits);
            this.tabFirstWordDictionariesCommon.Location = new System.Drawing.Point(4, 32);
            this.tabFirstWordDictionariesCommon.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabFirstWordDictionariesCommon.Name = "tabFirstWordDictionariesCommon";
            this.tabFirstWordDictionariesCommon.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabFirstWordDictionariesCommon.Size = new System.Drawing.Size(615, 881);
            this.tabFirstWordDictionariesCommon.TabIndex = 0;
            this.tabFirstWordDictionariesCommon.Text = "Common Dictionaries";
            this.tabFirstWordDictionariesCommon.UseVisualStyleBackColor = true;
            // 
            // lblDictionariesFirstWordUse
            // 
            this.lblDictionariesFirstWordUse.AutoSize = true;
            this.lblDictionariesFirstWordUse.Location = new System.Drawing.Point(9, 12);
            this.lblDictionariesFirstWordUse.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDictionariesFirstWordUse.Name = "lblDictionariesFirstWordUse";
            this.lblDictionariesFirstWordUse.Size = new System.Drawing.Size(79, 23);
            this.lblDictionariesFirstWordUse.TabIndex = 33;
            this.lblDictionariesFirstWordUse.Text = "Override:";
            // 
            // tvDictFirstWord
            // 
            this.tvDictFirstWord.Location = new System.Drawing.Point(156, 3);
            this.tvDictFirstWord.Name = "tvDictFirstWord";
            this.tvDictFirstWord.Size = new System.Drawing.Size(451, 864);
            this.tvDictFirstWord.TabIndex = 58;
            this.tvDictFirstWord.TriStateStyleProperty = RikTheVeggie.TriStateTreeView.TriStateStyles.Standard;
            // 
            // chkDictFirstReverseOrder
            // 
            this.chkDictFirstReverseOrder.AutoSize = true;
            this.chkDictFirstReverseOrder.Location = new System.Drawing.Point(9, 200);
            this.chkDictFirstReverseOrder.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkDictFirstReverseOrder.Name = "chkDictFirstReverseOrder";
            this.chkDictFirstReverseOrder.Size = new System.Drawing.Size(143, 27);
            this.chkDictFirstReverseOrder.TabIndex = 44;
            this.chkDictFirstReverseOrder.Text = "Reverse Order";
            this.chkDictFirstReverseOrder.UseVisualStyleBackColor = true;
            // 
            // btnCopyToDictFirst
            // 
            this.btnCopyToDictFirst.Location = new System.Drawing.Point(6, 785);
            this.btnCopyToDictFirst.Name = "btnCopyToDictFirst";
            this.btnCopyToDictFirst.Size = new System.Drawing.Size(146, 37);
            this.btnCopyToDictFirst.TabIndex = 57;
            this.btnCopyToDictFirst.Text = "Copy from Main";
            this.btnCopyToDictFirst.UseVisualStyleBackColor = true;
            this.btnCopyToDictFirst.Click += new System.EventHandler(this.btnCopyToDictFirst_Click);
            // 
            // btnDictFirstUnselected
            // 
            this.btnDictFirstUnselected.Location = new System.Drawing.Point(6, 828);
            this.btnDictFirstUnselected.Name = "btnDictFirstUnselected";
            this.btnDictFirstUnselected.Size = new System.Drawing.Size(146, 37);
            this.btnDictFirstUnselected.TabIndex = 56;
            this.btnDictFirstUnselected.Text = "Unselect All";
            this.btnDictFirstUnselected.UseVisualStyleBackColor = true;
            this.btnDictFirstUnselected.Click += new System.EventHandler(this.btnDictFirstUnselected_Click);
            // 
            // chkDictFirstAddTypos
            // 
            this.chkDictFirstAddTypos.AutoSize = true;
            this.chkDictFirstAddTypos.Location = new System.Drawing.Point(9, 162);
            this.chkDictFirstAddTypos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkDictFirstAddTypos.Name = "chkDictFirstAddTypos";
            this.chkDictFirstAddTypos.Size = new System.Drawing.Size(115, 27);
            this.chkDictFirstAddTypos.TabIndex = 43;
            this.chkDictFirstAddTypos.Text = "Add Typos";
            this.chkDictFirstAddTypos.UseVisualStyleBackColor = true;
            // 
            // chkDictFirstForceLowercase
            // 
            this.chkDictFirstForceLowercase.AutoSize = true;
            this.chkDictFirstForceLowercase.Location = new System.Drawing.Point(9, 123);
            this.chkDictFirstForceLowercase.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkDictFirstForceLowercase.Name = "chkDictFirstForceLowercase";
            this.chkDictFirstForceLowercase.Size = new System.Drawing.Size(114, 27);
            this.chkDictFirstForceLowercase.TabIndex = 42;
            this.chkDictFirstForceLowercase.Text = "Lowercase";
            this.chkDictFirstForceLowercase.UseVisualStyleBackColor = true;
            // 
            // chkDictFirstSkipSpecials
            // 
            this.chkDictFirstSkipSpecials.AutoSize = true;
            this.chkDictFirstSkipSpecials.Location = new System.Drawing.Point(9, 85);
            this.chkDictFirstSkipSpecials.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkDictFirstSkipSpecials.Name = "chkDictFirstSkipSpecials";
            this.chkDictFirstSkipSpecials.Size = new System.Drawing.Size(132, 27);
            this.chkDictFirstSkipSpecials.TabIndex = 41;
            this.chkDictFirstSkipSpecials.Text = "Skip Specials";
            this.chkDictFirstSkipSpecials.UseVisualStyleBackColor = true;
            // 
            // chkUseDictFirst
            // 
            this.chkUseDictFirst.AutoSize = true;
            this.chkUseDictFirst.Location = new System.Drawing.Point(114, 13);
            this.chkUseDictFirst.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkUseDictFirst.Name = "chkUseDictFirst";
            this.chkUseDictFirst.Size = new System.Drawing.Size(22, 21);
            this.chkUseDictFirst.TabIndex = 38;
            this.chkUseDictFirst.UseVisualStyleBackColor = true;
            this.chkUseDictFirst.CheckedChanged += new System.EventHandler(this.OnCustomDictFirstCheckedChanged);
            // 
            // chkDictFirstSkipDigits
            // 
            this.chkDictFirstSkipDigits.AutoSize = true;
            this.chkDictFirstSkipDigits.Location = new System.Drawing.Point(9, 47);
            this.chkDictFirstSkipDigits.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkDictFirstSkipDigits.Name = "chkDictFirstSkipDigits";
            this.chkDictFirstSkipDigits.Size = new System.Drawing.Size(115, 27);
            this.chkDictFirstSkipDigits.TabIndex = 40;
            this.chkDictFirstSkipDigits.Text = "Skip Digits";
            this.chkDictFirstSkipDigits.UseVisualStyleBackColor = true;
            // 
            // tabFirstWordDictionariesCustom
            // 
            this.tabFirstWordDictionariesCustom.Controls.Add(this.btnCopyToDictCustomFirst);
            this.tabFirstWordDictionariesCustom.Controls.Add(this.chkDictionariesFirstWordCustomWordsUse);
            this.tabFirstWordDictionariesCustom.Controls.Add(this.lblDictionariesFirstWordCustomWordsUse);
            this.tabFirstWordDictionariesCustom.Controls.Add(this.chkDictFirstWordCustomWordsAddTypos);
            this.tabFirstWordDictionariesCustom.Controls.Add(this.chkDictFirstWordCustomWordsForceLowercase);
            this.tabFirstWordDictionariesCustom.Controls.Add(this.chkDictFirstWordCustomWordsSkipSpecials);
            this.tabFirstWordDictionariesCustom.Controls.Add(this.chkDictFirstWordCustomWordsSkipDigits);
            this.tabFirstWordDictionariesCustom.Controls.Add(this.txtDictFirstCustWords);
            this.tabFirstWordDictionariesCustom.Location = new System.Drawing.Point(4, 32);
            this.tabFirstWordDictionariesCustom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabFirstWordDictionariesCustom.Name = "tabFirstWordDictionariesCustom";
            this.tabFirstWordDictionariesCustom.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabFirstWordDictionariesCustom.Size = new System.Drawing.Size(615, 881);
            this.tabFirstWordDictionariesCustom.TabIndex = 1;
            this.tabFirstWordDictionariesCustom.Text = "Custom Words";
            this.tabFirstWordDictionariesCustom.UseVisualStyleBackColor = true;
            // 
            // btnCopyToDictCustomFirst
            // 
            this.btnCopyToDictCustomFirst.Location = new System.Drawing.Point(6, 828);
            this.btnCopyToDictCustomFirst.Name = "btnCopyToDictCustomFirst";
            this.btnCopyToDictCustomFirst.Size = new System.Drawing.Size(146, 37);
            this.btnCopyToDictCustomFirst.TabIndex = 106;
            this.btnCopyToDictCustomFirst.Text = "Copy from Main";
            this.btnCopyToDictCustomFirst.UseVisualStyleBackColor = true;
            this.btnCopyToDictCustomFirst.Click += new System.EventHandler(this.btnCopyToDictCustomFirst_Click);
            // 
            // chkDictionariesFirstWordCustomWordsUse
            // 
            this.chkDictionariesFirstWordCustomWordsUse.AutoSize = true;
            this.chkDictionariesFirstWordCustomWordsUse.Location = new System.Drawing.Point(114, 13);
            this.chkDictionariesFirstWordCustomWordsUse.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkDictionariesFirstWordCustomWordsUse.Name = "chkDictionariesFirstWordCustomWordsUse";
            this.chkDictionariesFirstWordCustomWordsUse.Size = new System.Drawing.Size(22, 21);
            this.chkDictionariesFirstWordCustomWordsUse.TabIndex = 105;
            this.chkDictionariesFirstWordCustomWordsUse.UseVisualStyleBackColor = true;
            this.chkDictionariesFirstWordCustomWordsUse.CheckedChanged += new System.EventHandler(this.chkDictionariesFirstWordCustomWordsUse_CheckedChanged);
            // 
            // lblDictionariesFirstWordCustomWordsUse
            // 
            this.lblDictionariesFirstWordCustomWordsUse.AutoSize = true;
            this.lblDictionariesFirstWordCustomWordsUse.Location = new System.Drawing.Point(9, 12);
            this.lblDictionariesFirstWordCustomWordsUse.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDictionariesFirstWordCustomWordsUse.Name = "lblDictionariesFirstWordCustomWordsUse";
            this.lblDictionariesFirstWordCustomWordsUse.Size = new System.Drawing.Size(79, 23);
            this.lblDictionariesFirstWordCustomWordsUse.TabIndex = 104;
            this.lblDictionariesFirstWordCustomWordsUse.Text = "Override:";
            // 
            // chkDictFirstWordCustomWordsAddTypos
            // 
            this.chkDictFirstWordCustomWordsAddTypos.AutoSize = true;
            this.chkDictFirstWordCustomWordsAddTypos.Location = new System.Drawing.Point(9, 162);
            this.chkDictFirstWordCustomWordsAddTypos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkDictFirstWordCustomWordsAddTypos.Name = "chkDictFirstWordCustomWordsAddTypos";
            this.chkDictFirstWordCustomWordsAddTypos.Size = new System.Drawing.Size(115, 27);
            this.chkDictFirstWordCustomWordsAddTypos.TabIndex = 98;
            this.chkDictFirstWordCustomWordsAddTypos.Text = "Add Typos";
            this.chkDictFirstWordCustomWordsAddTypos.UseVisualStyleBackColor = true;
            // 
            // chkDictFirstWordCustomWordsForceLowercase
            // 
            this.chkDictFirstWordCustomWordsForceLowercase.AutoSize = true;
            this.chkDictFirstWordCustomWordsForceLowercase.Checked = true;
            this.chkDictFirstWordCustomWordsForceLowercase.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDictFirstWordCustomWordsForceLowercase.Location = new System.Drawing.Point(9, 123);
            this.chkDictFirstWordCustomWordsForceLowercase.Margin = new System.Windows.Forms.Padding(4, 5, 0, 5);
            this.chkDictFirstWordCustomWordsForceLowercase.Name = "chkDictFirstWordCustomWordsForceLowercase";
            this.chkDictFirstWordCustomWordsForceLowercase.Size = new System.Drawing.Size(114, 27);
            this.chkDictFirstWordCustomWordsForceLowercase.TabIndex = 97;
            this.chkDictFirstWordCustomWordsForceLowercase.Text = "Lowercase";
            this.chkDictFirstWordCustomWordsForceLowercase.UseVisualStyleBackColor = true;
            // 
            // chkDictFirstWordCustomWordsSkipSpecials
            // 
            this.chkDictFirstWordCustomWordsSkipSpecials.AutoSize = true;
            this.chkDictFirstWordCustomWordsSkipSpecials.Checked = true;
            this.chkDictFirstWordCustomWordsSkipSpecials.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDictFirstWordCustomWordsSkipSpecials.Location = new System.Drawing.Point(9, 85);
            this.chkDictFirstWordCustomWordsSkipSpecials.Margin = new System.Windows.Forms.Padding(4, 5, 0, 5);
            this.chkDictFirstWordCustomWordsSkipSpecials.Name = "chkDictFirstWordCustomWordsSkipSpecials";
            this.chkDictFirstWordCustomWordsSkipSpecials.Size = new System.Drawing.Size(132, 27);
            this.chkDictFirstWordCustomWordsSkipSpecials.TabIndex = 96;
            this.chkDictFirstWordCustomWordsSkipSpecials.Text = "Skip Specials";
            this.chkDictFirstWordCustomWordsSkipSpecials.UseVisualStyleBackColor = true;
            // 
            // chkDictFirstWordCustomWordsSkipDigits
            // 
            this.chkDictFirstWordCustomWordsSkipDigits.AutoSize = true;
            this.chkDictFirstWordCustomWordsSkipDigits.Location = new System.Drawing.Point(9, 47);
            this.chkDictFirstWordCustomWordsSkipDigits.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkDictFirstWordCustomWordsSkipDigits.Name = "chkDictFirstWordCustomWordsSkipDigits";
            this.chkDictFirstWordCustomWordsSkipDigits.Size = new System.Drawing.Size(115, 27);
            this.chkDictFirstWordCustomWordsSkipDigits.TabIndex = 95;
            this.chkDictFirstWordCustomWordsSkipDigits.Text = "Skip Digits";
            this.chkDictFirstWordCustomWordsSkipDigits.UseVisualStyleBackColor = true;
            // 
            // txtDictFirstCustWords
            // 
            this.txtDictFirstCustWords.Location = new System.Drawing.Point(156, 3);
            this.txtDictFirstCustWords.Multiline = true;
            this.txtDictFirstCustWords.Name = "txtDictFirstCustWords";
            this.txtDictFirstCustWords.Size = new System.Drawing.Size(451, 864);
            this.txtDictFirstCustWords.TabIndex = 0;
            // 
            // tabFirstWordDictionariesExcludeWords
            // 
            this.tabFirstWordDictionariesExcludeWords.Controls.Add(this.btnCopyToDictExcludeFirst);
            this.tabFirstWordDictionariesExcludeWords.Controls.Add(this.txtDictFirstWordExcludeWords);
            this.tabFirstWordDictionariesExcludeWords.Controls.Add(this.chkDictFirstWordExcludePartialWords);
            this.tabFirstWordDictionariesExcludeWords.Controls.Add(this.chkDictionariesFirstWordExcludeWordsUse);
            this.tabFirstWordDictionariesExcludeWords.Controls.Add(this.lblDictionariesFirstWordExcludeWordsUse);
            this.tabFirstWordDictionariesExcludeWords.Location = new System.Drawing.Point(4, 32);
            this.tabFirstWordDictionariesExcludeWords.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabFirstWordDictionariesExcludeWords.Name = "tabFirstWordDictionariesExcludeWords";
            this.tabFirstWordDictionariesExcludeWords.Size = new System.Drawing.Size(615, 881);
            this.tabFirstWordDictionariesExcludeWords.TabIndex = 2;
            this.tabFirstWordDictionariesExcludeWords.Text = "Exclude Words";
            this.tabFirstWordDictionariesExcludeWords.UseVisualStyleBackColor = true;
            // 
            // btnCopyToDictExcludeFirst
            // 
            this.btnCopyToDictExcludeFirst.Location = new System.Drawing.Point(6, 828);
            this.btnCopyToDictExcludeFirst.Name = "btnCopyToDictExcludeFirst";
            this.btnCopyToDictExcludeFirst.Size = new System.Drawing.Size(146, 37);
            this.btnCopyToDictExcludeFirst.TabIndex = 98;
            this.btnCopyToDictExcludeFirst.Text = "Copy from Main";
            this.btnCopyToDictExcludeFirst.UseVisualStyleBackColor = true;
            this.btnCopyToDictExcludeFirst.Click += new System.EventHandler(this.btnCopyToDictExcludeFirst_Click);
            // 
            // txtDictFirstWordExcludeWords
            // 
            this.txtDictFirstWordExcludeWords.Location = new System.Drawing.Point(156, 3);
            this.txtDictFirstWordExcludeWords.Multiline = true;
            this.txtDictFirstWordExcludeWords.Name = "txtDictFirstWordExcludeWords";
            this.txtDictFirstWordExcludeWords.Size = new System.Drawing.Size(451, 864);
            this.txtDictFirstWordExcludeWords.TabIndex = 97;
            // 
            // chkDictFirstWordExcludePartialWords
            // 
            this.chkDictFirstWordExcludePartialWords.AutoSize = true;
            this.chkDictFirstWordExcludePartialWords.Location = new System.Drawing.Point(9, 47);
            this.chkDictFirstWordExcludePartialWords.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkDictFirstWordExcludePartialWords.Name = "chkDictFirstWordExcludePartialWords";
            this.chkDictFirstWordExcludePartialWords.Size = new System.Drawing.Size(133, 27);
            this.chkDictFirstWordExcludePartialWords.TabIndex = 96;
            this.chkDictFirstWordExcludePartialWords.Text = "Partial words";
            this.chkDictFirstWordExcludePartialWords.UseVisualStyleBackColor = true;
            // 
            // chkDictionariesFirstWordExcludeWordsUse
            // 
            this.chkDictionariesFirstWordExcludeWordsUse.AutoSize = true;
            this.chkDictionariesFirstWordExcludeWordsUse.Location = new System.Drawing.Point(114, 13);
            this.chkDictionariesFirstWordExcludeWordsUse.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkDictionariesFirstWordExcludeWordsUse.Name = "chkDictionariesFirstWordExcludeWordsUse";
            this.chkDictionariesFirstWordExcludeWordsUse.Size = new System.Drawing.Size(22, 21);
            this.chkDictionariesFirstWordExcludeWordsUse.TabIndex = 95;
            this.chkDictionariesFirstWordExcludeWordsUse.UseVisualStyleBackColor = true;
            this.chkDictionariesFirstWordExcludeWordsUse.CheckedChanged += new System.EventHandler(this.chkDictionariesFirstWordExcludeWordsUse_CheckedChanged);
            // 
            // lblDictionariesFirstWordExcludeWordsUse
            // 
            this.lblDictionariesFirstWordExcludeWordsUse.AutoSize = true;
            this.lblDictionariesFirstWordExcludeWordsUse.Location = new System.Drawing.Point(9, 12);
            this.lblDictionariesFirstWordExcludeWordsUse.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDictionariesFirstWordExcludeWordsUse.Name = "lblDictionariesFirstWordExcludeWordsUse";
            this.lblDictionariesFirstWordExcludeWordsUse.Size = new System.Drawing.Size(79, 23);
            this.lblDictionariesFirstWordExcludeWordsUse.TabIndex = 94;
            this.lblDictionariesFirstWordExcludeWordsUse.Text = "Override:";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.tabLastWordDictionaries);
            this.tabPage3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabPage3.Location = new System.Drawing.Point(4, 34);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(626, 925);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Last Word Overrides";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabLastWordDictionaries
            // 
            this.tabLastWordDictionaries.Controls.Add(this.tabLastWordDictionariesCommon);
            this.tabLastWordDictionaries.Controls.Add(this.tabLastWordDictionariesCustom);
            this.tabLastWordDictionaries.Controls.Add(this.tabLastWordDictionariesExcludeWords);
            this.tabLastWordDictionaries.Location = new System.Drawing.Point(0, 0);
            this.tabLastWordDictionaries.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabLastWordDictionaries.Name = "tabLastWordDictionaries";
            this.tabLastWordDictionaries.SelectedIndex = 0;
            this.tabLastWordDictionaries.Size = new System.Drawing.Size(623, 917);
            this.tabLastWordDictionaries.TabIndex = 87;
            // 
            // tabLastWordDictionariesCommon
            // 
            this.tabLastWordDictionariesCommon.Controls.Add(this.lblDictionaryLastWordUse);
            this.tabLastWordDictionariesCommon.Controls.Add(this.tvDictLastWord);
            this.tabLastWordDictionariesCommon.Controls.Add(this.chkDictLastForceLowercase);
            this.tabLastWordDictionariesCommon.Controls.Add(this.btnCopyToDictLast);
            this.tabLastWordDictionariesCommon.Controls.Add(this.btnDictLastUnselected);
            this.tabLastWordDictionariesCommon.Controls.Add(this.chkDictLastSkipSpecials);
            this.tabLastWordDictionariesCommon.Controls.Add(this.chkDictLastAddTypos);
            this.tabLastWordDictionariesCommon.Controls.Add(this.chkDictLastSkipDigits);
            this.tabLastWordDictionariesCommon.Controls.Add(this.chkUseDictLast);
            this.tabLastWordDictionariesCommon.Controls.Add(this.chkDictLastReverseOrder);
            this.tabLastWordDictionariesCommon.Location = new System.Drawing.Point(4, 32);
            this.tabLastWordDictionariesCommon.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabLastWordDictionariesCommon.Name = "tabLastWordDictionariesCommon";
            this.tabLastWordDictionariesCommon.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabLastWordDictionariesCommon.Size = new System.Drawing.Size(615, 881);
            this.tabLastWordDictionariesCommon.TabIndex = 0;
            this.tabLastWordDictionariesCommon.Text = "Common Dictionaries";
            this.tabLastWordDictionariesCommon.UseVisualStyleBackColor = true;
            // 
            // lblDictionaryLastWordUse
            // 
            this.lblDictionaryLastWordUse.AutoSize = true;
            this.lblDictionaryLastWordUse.Location = new System.Drawing.Point(9, 12);
            this.lblDictionaryLastWordUse.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDictionaryLastWordUse.Name = "lblDictionaryLastWordUse";
            this.lblDictionaryLastWordUse.Size = new System.Drawing.Size(79, 23);
            this.lblDictionaryLastWordUse.TabIndex = 31;
            this.lblDictionaryLastWordUse.Text = "Override:";
            // 
            // tvDictLastWord
            // 
            this.tvDictLastWord.Location = new System.Drawing.Point(156, 3);
            this.tvDictLastWord.Name = "tvDictLastWord";
            this.tvDictLastWord.Size = new System.Drawing.Size(451, 864);
            this.tvDictLastWord.TabIndex = 59;
            this.tvDictLastWord.TriStateStyleProperty = RikTheVeggie.TriStateTreeView.TriStateStyles.Standard;
            // 
            // chkDictLastForceLowercase
            // 
            this.chkDictLastForceLowercase.AutoSize = true;
            this.chkDictLastForceLowercase.Location = new System.Drawing.Point(9, 123);
            this.chkDictLastForceLowercase.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkDictLastForceLowercase.Name = "chkDictLastForceLowercase";
            this.chkDictLastForceLowercase.Size = new System.Drawing.Size(114, 27);
            this.chkDictLastForceLowercase.TabIndex = 47;
            this.chkDictLastForceLowercase.Text = "Lowercase";
            this.chkDictLastForceLowercase.UseVisualStyleBackColor = true;
            // 
            // btnCopyToDictLast
            // 
            this.btnCopyToDictLast.Location = new System.Drawing.Point(6, 785);
            this.btnCopyToDictLast.Name = "btnCopyToDictLast";
            this.btnCopyToDictLast.Size = new System.Drawing.Size(146, 37);
            this.btnCopyToDictLast.TabIndex = 58;
            this.btnCopyToDictLast.Text = "Copy from Main";
            this.btnCopyToDictLast.UseVisualStyleBackColor = true;
            this.btnCopyToDictLast.Click += new System.EventHandler(this.btnCopyToDictLast_Click);
            // 
            // btnDictLastUnselected
            // 
            this.btnDictLastUnselected.Location = new System.Drawing.Point(6, 828);
            this.btnDictLastUnselected.Name = "btnDictLastUnselected";
            this.btnDictLastUnselected.Size = new System.Drawing.Size(146, 37);
            this.btnDictLastUnselected.TabIndex = 57;
            this.btnDictLastUnselected.Text = "Unselect All";
            this.btnDictLastUnselected.UseVisualStyleBackColor = true;
            this.btnDictLastUnselected.Click += new System.EventHandler(this.btnDictLastUnselected_Click);
            // 
            // chkDictLastSkipSpecials
            // 
            this.chkDictLastSkipSpecials.AutoSize = true;
            this.chkDictLastSkipSpecials.Location = new System.Drawing.Point(9, 85);
            this.chkDictLastSkipSpecials.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkDictLastSkipSpecials.Name = "chkDictLastSkipSpecials";
            this.chkDictLastSkipSpecials.Size = new System.Drawing.Size(132, 27);
            this.chkDictLastSkipSpecials.TabIndex = 46;
            this.chkDictLastSkipSpecials.Text = "Skip Specials";
            this.chkDictLastSkipSpecials.UseVisualStyleBackColor = true;
            // 
            // chkDictLastAddTypos
            // 
            this.chkDictLastAddTypos.AutoSize = true;
            this.chkDictLastAddTypos.Location = new System.Drawing.Point(9, 162);
            this.chkDictLastAddTypos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkDictLastAddTypos.Name = "chkDictLastAddTypos";
            this.chkDictLastAddTypos.Size = new System.Drawing.Size(115, 27);
            this.chkDictLastAddTypos.TabIndex = 48;
            this.chkDictLastAddTypos.Text = "Add Typos";
            this.chkDictLastAddTypos.UseVisualStyleBackColor = true;
            // 
            // chkDictLastSkipDigits
            // 
            this.chkDictLastSkipDigits.AutoSize = true;
            this.chkDictLastSkipDigits.Location = new System.Drawing.Point(9, 47);
            this.chkDictLastSkipDigits.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkDictLastSkipDigits.Name = "chkDictLastSkipDigits";
            this.chkDictLastSkipDigits.Size = new System.Drawing.Size(115, 27);
            this.chkDictLastSkipDigits.TabIndex = 45;
            this.chkDictLastSkipDigits.Text = "Skip Digits";
            this.chkDictLastSkipDigits.UseVisualStyleBackColor = true;
            // 
            // chkUseDictLast
            // 
            this.chkUseDictLast.AutoSize = true;
            this.chkUseDictLast.Location = new System.Drawing.Point(114, 13);
            this.chkUseDictLast.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkUseDictLast.Name = "chkUseDictLast";
            this.chkUseDictLast.Size = new System.Drawing.Size(22, 21);
            this.chkUseDictLast.TabIndex = 39;
            this.chkUseDictLast.UseVisualStyleBackColor = true;
            this.chkUseDictLast.CheckedChanged += new System.EventHandler(this.OnCustomDictLastCheckedChanged);
            // 
            // chkDictLastReverseOrder
            // 
            this.chkDictLastReverseOrder.AutoSize = true;
            this.chkDictLastReverseOrder.Location = new System.Drawing.Point(9, 200);
            this.chkDictLastReverseOrder.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkDictLastReverseOrder.Name = "chkDictLastReverseOrder";
            this.chkDictLastReverseOrder.Size = new System.Drawing.Size(143, 27);
            this.chkDictLastReverseOrder.TabIndex = 49;
            this.chkDictLastReverseOrder.Text = "Reverse Order";
            this.chkDictLastReverseOrder.UseVisualStyleBackColor = true;
            // 
            // tabLastWordDictionariesCustom
            // 
            this.tabLastWordDictionariesCustom.Controls.Add(this.btnCopyToDictCustomLast);
            this.tabLastWordDictionariesCustom.Controls.Add(this.chkDictionariesLastWordCustomWordsUse);
            this.tabLastWordDictionariesCustom.Controls.Add(this.lblDictionariesLastWordCustomWordsUse);
            this.tabLastWordDictionariesCustom.Controls.Add(this.chkDictLastWordCustomWordsAddTypos);
            this.tabLastWordDictionariesCustom.Controls.Add(this.chkDictLastWordCustomWordsForceLowercase);
            this.tabLastWordDictionariesCustom.Controls.Add(this.chkDictLastWordCustomWordsSkipSpecials);
            this.tabLastWordDictionariesCustom.Controls.Add(this.chkDictLastWordCustomWordsSkipDigits);
            this.tabLastWordDictionariesCustom.Controls.Add(this.txtDictLastCustWords);
            this.tabLastWordDictionariesCustom.Location = new System.Drawing.Point(4, 32);
            this.tabLastWordDictionariesCustom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabLastWordDictionariesCustom.Name = "tabLastWordDictionariesCustom";
            this.tabLastWordDictionariesCustom.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabLastWordDictionariesCustom.Size = new System.Drawing.Size(615, 881);
            this.tabLastWordDictionariesCustom.TabIndex = 1;
            this.tabLastWordDictionariesCustom.Text = "Custom Words";
            this.tabLastWordDictionariesCustom.UseVisualStyleBackColor = true;
            // 
            // btnCopyToDictCustomLast
            // 
            this.btnCopyToDictCustomLast.Location = new System.Drawing.Point(6, 828);
            this.btnCopyToDictCustomLast.Name = "btnCopyToDictCustomLast";
            this.btnCopyToDictCustomLast.Size = new System.Drawing.Size(146, 37);
            this.btnCopyToDictCustomLast.TabIndex = 106;
            this.btnCopyToDictCustomLast.Text = "Copy from Main";
            this.btnCopyToDictCustomLast.UseVisualStyleBackColor = true;
            this.btnCopyToDictCustomLast.Click += new System.EventHandler(this.btnCopyToDictCustomLast_Click);
            // 
            // chkDictionariesLastWordCustomWordsUse
            // 
            this.chkDictionariesLastWordCustomWordsUse.AutoSize = true;
            this.chkDictionariesLastWordCustomWordsUse.Location = new System.Drawing.Point(114, 13);
            this.chkDictionariesLastWordCustomWordsUse.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkDictionariesLastWordCustomWordsUse.Name = "chkDictionariesLastWordCustomWordsUse";
            this.chkDictionariesLastWordCustomWordsUse.Size = new System.Drawing.Size(22, 21);
            this.chkDictionariesLastWordCustomWordsUse.TabIndex = 105;
            this.chkDictionariesLastWordCustomWordsUse.UseVisualStyleBackColor = true;
            this.chkDictionariesLastWordCustomWordsUse.CheckedChanged += new System.EventHandler(this.chkDictionariesLastWordCustomWordsUse_CheckedChanged);
            // 
            // lblDictionariesLastWordCustomWordsUse
            // 
            this.lblDictionariesLastWordCustomWordsUse.AutoSize = true;
            this.lblDictionariesLastWordCustomWordsUse.Location = new System.Drawing.Point(9, 12);
            this.lblDictionariesLastWordCustomWordsUse.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDictionariesLastWordCustomWordsUse.Name = "lblDictionariesLastWordCustomWordsUse";
            this.lblDictionariesLastWordCustomWordsUse.Size = new System.Drawing.Size(79, 23);
            this.lblDictionariesLastWordCustomWordsUse.TabIndex = 104;
            this.lblDictionariesLastWordCustomWordsUse.Text = "Override:";
            // 
            // chkDictLastWordCustomWordsAddTypos
            // 
            this.chkDictLastWordCustomWordsAddTypos.AutoSize = true;
            this.chkDictLastWordCustomWordsAddTypos.Location = new System.Drawing.Point(9, 162);
            this.chkDictLastWordCustomWordsAddTypos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkDictLastWordCustomWordsAddTypos.Name = "chkDictLastWordCustomWordsAddTypos";
            this.chkDictLastWordCustomWordsAddTypos.Size = new System.Drawing.Size(115, 27);
            this.chkDictLastWordCustomWordsAddTypos.TabIndex = 98;
            this.chkDictLastWordCustomWordsAddTypos.Text = "Add Typos";
            this.chkDictLastWordCustomWordsAddTypos.UseVisualStyleBackColor = true;
            // 
            // chkDictLastWordCustomWordsForceLowercase
            // 
            this.chkDictLastWordCustomWordsForceLowercase.AutoSize = true;
            this.chkDictLastWordCustomWordsForceLowercase.Checked = true;
            this.chkDictLastWordCustomWordsForceLowercase.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDictLastWordCustomWordsForceLowercase.Location = new System.Drawing.Point(9, 123);
            this.chkDictLastWordCustomWordsForceLowercase.Margin = new System.Windows.Forms.Padding(4, 5, 0, 5);
            this.chkDictLastWordCustomWordsForceLowercase.Name = "chkDictLastWordCustomWordsForceLowercase";
            this.chkDictLastWordCustomWordsForceLowercase.Size = new System.Drawing.Size(114, 27);
            this.chkDictLastWordCustomWordsForceLowercase.TabIndex = 97;
            this.chkDictLastWordCustomWordsForceLowercase.Text = "Lowercase";
            this.chkDictLastWordCustomWordsForceLowercase.UseVisualStyleBackColor = true;
            // 
            // chkDictLastWordCustomWordsSkipSpecials
            // 
            this.chkDictLastWordCustomWordsSkipSpecials.AutoSize = true;
            this.chkDictLastWordCustomWordsSkipSpecials.Checked = true;
            this.chkDictLastWordCustomWordsSkipSpecials.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDictLastWordCustomWordsSkipSpecials.Location = new System.Drawing.Point(9, 85);
            this.chkDictLastWordCustomWordsSkipSpecials.Margin = new System.Windows.Forms.Padding(4, 5, 0, 5);
            this.chkDictLastWordCustomWordsSkipSpecials.Name = "chkDictLastWordCustomWordsSkipSpecials";
            this.chkDictLastWordCustomWordsSkipSpecials.Size = new System.Drawing.Size(132, 27);
            this.chkDictLastWordCustomWordsSkipSpecials.TabIndex = 96;
            this.chkDictLastWordCustomWordsSkipSpecials.Text = "Skip Specials";
            this.chkDictLastWordCustomWordsSkipSpecials.UseVisualStyleBackColor = true;
            // 
            // chkDictLastWordCustomWordsSkipDigits
            // 
            this.chkDictLastWordCustomWordsSkipDigits.AutoSize = true;
            this.chkDictLastWordCustomWordsSkipDigits.Location = new System.Drawing.Point(9, 47);
            this.chkDictLastWordCustomWordsSkipDigits.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkDictLastWordCustomWordsSkipDigits.Name = "chkDictLastWordCustomWordsSkipDigits";
            this.chkDictLastWordCustomWordsSkipDigits.Size = new System.Drawing.Size(115, 27);
            this.chkDictLastWordCustomWordsSkipDigits.TabIndex = 95;
            this.chkDictLastWordCustomWordsSkipDigits.Text = "Skip Digits";
            this.chkDictLastWordCustomWordsSkipDigits.UseVisualStyleBackColor = true;
            // 
            // txtDictLastCustWords
            // 
            this.txtDictLastCustWords.Location = new System.Drawing.Point(156, 3);
            this.txtDictLastCustWords.Multiline = true;
            this.txtDictLastCustWords.Name = "txtDictLastCustWords";
            this.txtDictLastCustWords.Size = new System.Drawing.Size(451, 864);
            this.txtDictLastCustWords.TabIndex = 0;
            // 
            // tabLastWordDictionariesExcludeWords
            // 
            this.tabLastWordDictionariesExcludeWords.Controls.Add(this.btnCopyToDictExcludeLast);
            this.tabLastWordDictionariesExcludeWords.Controls.Add(this.txtDictLastWordExcludeWords);
            this.tabLastWordDictionariesExcludeWords.Controls.Add(this.chkDictLastWordExcludePartialWords);
            this.tabLastWordDictionariesExcludeWords.Controls.Add(this.chkDictionariesLastWordExcludeWordsUse);
            this.tabLastWordDictionariesExcludeWords.Controls.Add(this.lblDictionariesLastWordExcludeWordsUse);
            this.tabLastWordDictionariesExcludeWords.Location = new System.Drawing.Point(4, 32);
            this.tabLastWordDictionariesExcludeWords.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabLastWordDictionariesExcludeWords.Name = "tabLastWordDictionariesExcludeWords";
            this.tabLastWordDictionariesExcludeWords.Size = new System.Drawing.Size(615, 881);
            this.tabLastWordDictionariesExcludeWords.TabIndex = 2;
            this.tabLastWordDictionariesExcludeWords.Text = "Exclude Words";
            this.tabLastWordDictionariesExcludeWords.UseVisualStyleBackColor = true;
            // 
            // btnCopyToDictExcludeLast
            // 
            this.btnCopyToDictExcludeLast.Location = new System.Drawing.Point(6, 828);
            this.btnCopyToDictExcludeLast.Name = "btnCopyToDictExcludeLast";
            this.btnCopyToDictExcludeLast.Size = new System.Drawing.Size(146, 37);
            this.btnCopyToDictExcludeLast.TabIndex = 98;
            this.btnCopyToDictExcludeLast.Text = "Copy from Main";
            this.btnCopyToDictExcludeLast.UseVisualStyleBackColor = true;
            this.btnCopyToDictExcludeLast.Click += new System.EventHandler(this.btnCopyToDictExcludeLast_Click);
            // 
            // txtDictLastWordExcludeWords
            // 
            this.txtDictLastWordExcludeWords.Location = new System.Drawing.Point(156, 3);
            this.txtDictLastWordExcludeWords.Multiline = true;
            this.txtDictLastWordExcludeWords.Name = "txtDictLastWordExcludeWords";
            this.txtDictLastWordExcludeWords.Size = new System.Drawing.Size(451, 864);
            this.txtDictLastWordExcludeWords.TabIndex = 97;
            // 
            // chkDictLastWordExcludePartialWords
            // 
            this.chkDictLastWordExcludePartialWords.AutoSize = true;
            this.chkDictLastWordExcludePartialWords.Location = new System.Drawing.Point(9, 47);
            this.chkDictLastWordExcludePartialWords.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkDictLastWordExcludePartialWords.Name = "chkDictLastWordExcludePartialWords";
            this.chkDictLastWordExcludePartialWords.Size = new System.Drawing.Size(133, 27);
            this.chkDictLastWordExcludePartialWords.TabIndex = 96;
            this.chkDictLastWordExcludePartialWords.Text = "Partial words";
            this.chkDictLastWordExcludePartialWords.UseVisualStyleBackColor = true;
            // 
            // chkDictionariesLastWordExcludeWordsUse
            // 
            this.chkDictionariesLastWordExcludeWordsUse.AutoSize = true;
            this.chkDictionariesLastWordExcludeWordsUse.Location = new System.Drawing.Point(114, 13);
            this.chkDictionariesLastWordExcludeWordsUse.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkDictionariesLastWordExcludeWordsUse.Name = "chkDictionariesLastWordExcludeWordsUse";
            this.chkDictionariesLastWordExcludeWordsUse.Size = new System.Drawing.Size(22, 21);
            this.chkDictionariesLastWordExcludeWordsUse.TabIndex = 95;
            this.chkDictionariesLastWordExcludeWordsUse.UseVisualStyleBackColor = true;
            this.chkDictionariesLastWordExcludeWordsUse.CheckedChanged += new System.EventHandler(this.chkDictionariesLastWordExcludeWordsUse_CheckedChanged);
            // 
            // lblDictionariesLastWordExcludeWordsUse
            // 
            this.lblDictionariesLastWordExcludeWordsUse.AutoSize = true;
            this.lblDictionariesLastWordExcludeWordsUse.Location = new System.Drawing.Point(9, 12);
            this.lblDictionariesLastWordExcludeWordsUse.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDictionariesLastWordExcludeWordsUse.Name = "lblDictionariesLastWordExcludeWordsUse";
            this.lblDictionariesLastWordExcludeWordsUse.Size = new System.Drawing.Size(79, 23);
            this.lblDictionariesLastWordExcludeWordsUse.TabIndex = 94;
            this.lblDictionariesLastWordExcludeWordsUse.Text = "Override:";
            // 
            // chkVerbose
            // 
            this.chkVerbose.AutoSize = true;
            this.chkVerbose.Checked = true;
            this.chkVerbose.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkVerbose.Location = new System.Drawing.Point(1174, 63);
            this.chkVerbose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkVerbose.Name = "chkVerbose";
            this.chkVerbose.Size = new System.Drawing.Size(22, 21);
            this.chkVerbose.TabIndex = 33;
            this.chkVerbose.UseVisualStyleBackColor = true;
            // 
            // mnStrip
            // 
            this.mnStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.mnStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnFile,
            this.toolsToolStripMenuItem});
            this.mnStrip.Location = new System.Drawing.Point(0, 0);
            this.mnStrip.Name = "mnStrip";
            this.mnStrip.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.mnStrip.Size = new System.Drawing.Size(1211, 35);
            this.mnStrip.TabIndex = 34;
            // 
            // mnFile
            // 
            this.mnFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnNew,
            this.mnSeparator,
            this.mnRefresh,
            this.mnSeparator2,
            this.mnQuickLoad,
            this.mnQuickSave,
            this.mnQuickClean,
            this.mnSeparator3,
            this.mnLoad,
            this.mnSave});
            this.mnFile.Name = "mnFile";
            this.mnFile.Size = new System.Drawing.Size(54, 29);
            this.mnFile.Text = "File";
            // 
            // mnNew
            // 
            this.mnNew.Name = "mnNew";
            this.mnNew.Size = new System.Drawing.Size(207, 34);
            this.mnNew.Text = "New";
            // 
            // mnSeparator
            // 
            this.mnSeparator.Name = "mnSeparator";
            this.mnSeparator.Size = new System.Drawing.Size(204, 6);
            // 
            // mnRefresh
            // 
            this.mnRefresh.Name = "mnRefresh";
            this.mnRefresh.Size = new System.Drawing.Size(207, 34);
            this.mnRefresh.Text = "Refresh";
            // 
            // mnSeparator2
            // 
            this.mnSeparator2.Name = "mnSeparator2";
            this.mnSeparator2.Size = new System.Drawing.Size(204, 6);
            // 
            // mnQuickLoad
            // 
            this.mnQuickLoad.Name = "mnQuickLoad";
            this.mnQuickLoad.Size = new System.Drawing.Size(207, 34);
            this.mnQuickLoad.Text = "Quick Load";
            // 
            // mnQuickSave
            // 
            this.mnQuickSave.Name = "mnQuickSave";
            this.mnQuickSave.Size = new System.Drawing.Size(207, 34);
            this.mnQuickSave.Text = "Quick Save";
            // 
            // mnQuickClean
            // 
            this.mnQuickClean.Name = "mnQuickClean";
            this.mnQuickClean.Size = new System.Drawing.Size(207, 34);
            this.mnQuickClean.Text = "Quick Clean";
            // 
            // mnSeparator3
            // 
            this.mnSeparator3.Name = "mnSeparator3";
            this.mnSeparator3.Size = new System.Drawing.Size(204, 6);
            // 
            // mnLoad
            // 
            this.mnLoad.Name = "mnLoad";
            this.mnLoad.Size = new System.Drawing.Size(207, 34);
            this.mnLoad.Text = "Load...";
            // 
            // mnSave
            // 
            this.mnSave.Name = "mnSave";
            this.mnSave.Size = new System.Drawing.Size(207, 34);
            this.mnSave.Text = "Save...";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.printLatestCommandToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(69, 29);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // printLatestCommandToolStripMenuItem
            // 
            this.printLatestCommandToolStripMenuItem.Name = "printLatestCommandToolStripMenuItem";
            this.printLatestCommandToolStripMenuItem.Size = new System.Drawing.Size(283, 34);
            this.printLatestCommandToolStripMenuItem.Text = "Print latest command";
            this.printLatestCommandToolStripMenuItem.Click += new System.EventHandler(this.printLatestCommandToolStripMenuItem_Click);
            // 
            // openFile
            // 
            this.openFile.FileName = "file.hbt";
            // 
            // saveFile
            // 
            this.saveFile.FileName = "file.hbt";
            // 
            // lblVerbose
            // 
            this.lblVerbose.AutoSize = true;
            this.lblVerbose.Location = new System.Drawing.Point(1069, 60);
            this.lblVerbose.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVerbose.Name = "lblVerbose";
            this.lblVerbose.Size = new System.Drawing.Size(80, 25);
            this.lblVerbose.TabIndex = 35;
            this.lblVerbose.Text = "Verbose:";
            // 
            // btnStartHashCat
            // 
            this.btnStartHashCat.Location = new System.Drawing.Point(584, 1157);
            this.btnStartHashCat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnStartHashCat.Name = "btnStartHashCat";
            this.btnStartHashCat.Size = new System.Drawing.Size(304, 37);
            this.btnStartHashCat.TabIndex = 36;
            this.btnStartHashCat.Text = "START (HashCat)";
            this.btnStartHashCat.UseVisualStyleBackColor = true;
            this.btnStartHashCat.Click += new System.EventHandler(this.OnStartHashCatClick);
            // 
            // btnQuickSave
            // 
            this.btnQuickSave.Location = new System.Drawing.Point(406, 122);
            this.btnQuickSave.Name = "btnQuickSave";
            this.btnQuickSave.Size = new System.Drawing.Size(66, 33);
            this.btnQuickSave.TabIndex = 37;
            this.btnQuickSave.Text = "Save";
            this.btnQuickSave.UseVisualStyleBackColor = true;
            // 
            // btnQuickLoad
            // 
            this.btnQuickLoad.Location = new System.Drawing.Point(471, 122);
            this.btnQuickLoad.Name = "btnQuickLoad";
            this.btnQuickLoad.Size = new System.Drawing.Size(67, 33);
            this.btnQuickLoad.TabIndex = 38;
            this.btnQuickLoad.Text = "Load";
            this.btnQuickLoad.UseVisualStyleBackColor = true;
            // 
            // pnlCharBruteforce
            // 
            this.pnlCharBruteforce.Controls.Add(this.tbCharBruteforce);
            this.pnlCharBruteforce.Controls.Add(this.grpGeneral);
            this.pnlCharBruteforce.Location = new System.Drawing.Point(549, 173);
            this.pnlCharBruteforce.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlCharBruteforce.Name = "pnlCharBruteforce";
            this.pnlCharBruteforce.Size = new System.Drawing.Size(650, 977);
            this.pnlCharBruteforce.TabIndex = 32;
            // 
            // tbCharBruteforce
            // 
            this.tbCharBruteforce.Controls.Add(this.tabBruteforceMain);
            this.tbCharBruteforce.Controls.Add(this.tabBruteforceDict);
            this.tbCharBruteforce.Controls.Add(this.tabBruteforceDictFirstWord);
            this.tbCharBruteforce.Controls.Add(this.tabBruteforceDictLastWord);
            this.tbCharBruteforce.Location = new System.Drawing.Point(9, 250);
            this.tbCharBruteforce.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbCharBruteforce.Name = "tbCharBruteforce";
            this.tbCharBruteforce.SelectedIndex = 0;
            this.tbCharBruteforce.Size = new System.Drawing.Size(637, 720);
            this.tbCharBruteforce.TabIndex = 44;
            // 
            // tabBruteforceMain
            // 
            this.tabBruteforceMain.Controls.Add(this.grpSpecials);
            this.tabBruteforceMain.Controls.Add(this.grpCharsetPreview);
            this.tabBruteforceMain.Location = new System.Drawing.Point(4, 34);
            this.tabBruteforceMain.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabBruteforceMain.Name = "tabBruteforceMain";
            this.tabBruteforceMain.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabBruteforceMain.Size = new System.Drawing.Size(629, 682);
            this.tabBruteforceMain.TabIndex = 0;
            this.tabBruteforceMain.Text = "Bruteforce Characters";
            this.tabBruteforceMain.UseVisualStyleBackColor = true;
            // 
            // grpSpecials
            // 
            this.grpSpecials.Controls.Add(this.chklCharsets);
            this.grpSpecials.Location = new System.Drawing.Point(0, 7);
            this.grpSpecials.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpSpecials.Name = "grpSpecials";
            this.grpSpecials.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpSpecials.Size = new System.Drawing.Size(307, 667);
            this.grpSpecials.TabIndex = 41;
            this.grpSpecials.TabStop = false;
            this.grpSpecials.Text = "Special charsets";
            // 
            // chklCharsets
            // 
            this.chklCharsets.FormattingEnabled = true;
            this.chklCharsets.Location = new System.Drawing.Point(10, 37);
            this.chklCharsets.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chklCharsets.Name = "chklCharsets";
            this.chklCharsets.Size = new System.Drawing.Size(287, 592);
            this.chklCharsets.TabIndex = 0;
            this.chklCharsets.SelectedIndexChanged += new System.EventHandler(this.ChklCharsetsSelectedIndexChanged);
            this.chklCharsets.SelectedValueChanged += new System.EventHandler(this.ChklCharsetsSelectedValueChanged);
            // 
            // grpCharsetPreview
            // 
            this.grpCharsetPreview.Controls.Add(this.lblStartingValidCharsPreview);
            this.grpCharsetPreview.Controls.Add(this.txtStartingValidCharsPreview);
            this.grpCharsetPreview.Controls.Add(this.lblValidCharsPreview);
            this.grpCharsetPreview.Controls.Add(this.txtValidCharsPreview);
            this.grpCharsetPreview.Location = new System.Drawing.Point(316, 7);
            this.grpCharsetPreview.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpCharsetPreview.Name = "grpCharsetPreview";
            this.grpCharsetPreview.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpCharsetPreview.Size = new System.Drawing.Size(296, 668);
            this.grpCharsetPreview.TabIndex = 43;
            this.grpCharsetPreview.TabStop = false;
            this.grpCharsetPreview.Text = "Charset Previews";
            // 
            // lblStartingValidCharsPreview
            // 
            this.lblStartingValidCharsPreview.AutoSize = true;
            this.lblStartingValidCharsPreview.Location = new System.Drawing.Point(13, 358);
            this.lblStartingValidCharsPreview.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStartingValidCharsPreview.Name = "lblStartingValidCharsPreview";
            this.lblStartingValidCharsPreview.Size = new System.Drawing.Size(126, 25);
            this.lblStartingValidCharsPreview.TabIndex = 43;
            this.lblStartingValidCharsPreview.Text = "Starting Chars:";
            // 
            // txtStartingValidCharsPreview
            // 
            this.txtStartingValidCharsPreview.Location = new System.Drawing.Point(13, 393);
            this.txtStartingValidCharsPreview.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtStartingValidCharsPreview.Multiline = true;
            this.txtStartingValidCharsPreview.Name = "txtStartingValidCharsPreview";
            this.txtStartingValidCharsPreview.ReadOnly = true;
            this.txtStartingValidCharsPreview.Size = new System.Drawing.Size(270, 247);
            this.txtStartingValidCharsPreview.TabIndex = 42;
            // 
            // lblValidCharsPreview
            // 
            this.lblValidCharsPreview.AutoSize = true;
            this.lblValidCharsPreview.Location = new System.Drawing.Point(13, 35);
            this.lblValidCharsPreview.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblValidCharsPreview.Name = "lblValidCharsPreview";
            this.lblValidCharsPreview.Size = new System.Drawing.Size(103, 25);
            this.lblValidCharsPreview.TabIndex = 41;
            this.lblValidCharsPreview.Text = "Valid Chars:";
            // 
            // txtValidCharsPreview
            // 
            this.txtValidCharsPreview.Location = new System.Drawing.Point(13, 72);
            this.txtValidCharsPreview.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtValidCharsPreview.Multiline = true;
            this.txtValidCharsPreview.Name = "txtValidCharsPreview";
            this.txtValidCharsPreview.ReadOnly = true;
            this.txtValidCharsPreview.Size = new System.Drawing.Size(270, 247);
            this.txtValidCharsPreview.TabIndex = 0;
            // 
            // tabBruteforceDict
            // 
            this.tabBruteforceDict.Controls.Add(this.pnlHybridDict);
            this.tabBruteforceDict.Location = new System.Drawing.Point(4, 34);
            this.tabBruteforceDict.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabBruteforceDict.Name = "tabBruteforceDict";
            this.tabBruteforceDict.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabBruteforceDict.Size = new System.Drawing.Size(629, 682);
            this.tabBruteforceDict.TabIndex = 1;
            this.tabBruteforceDict.Text = "Dictionnary";
            this.tabBruteforceDict.UseVisualStyleBackColor = true;
            // 
            // pnlHybridDict
            // 
            this.pnlHybridDict.Controls.Add(this.lblHybridHashcatThreshold2);
            this.pnlHybridDict.Controls.Add(this.cbHybridHashcatThreshold);
            this.pnlHybridDict.Controls.Add(this.lblHybridHashcatThreshold);
            this.pnlHybridDict.Controls.Add(this.chkHybridIgnoreSizeFilters);
            this.pnlHybridDict.Controls.Add(this.cbHybridBruteForceMaxCharacters);
            this.pnlHybridDict.Controls.Add(this.cbHybridBruteForceMinCharacters);
            this.pnlHybridDict.Controls.Add(this.lblHybridBruteForceFrom);
            this.pnlHybridDict.Controls.Add(this.lblHybridBruteForceUpTo);
            this.pnlHybridDict.Controls.Add(this.lblHybridWordsInHash);
            this.pnlHybridDict.Controls.Add(this.cbHybridWordsInHash);
            this.pnlHybridDict.Controls.Add(this.lblHybridCombination);
            this.pnlHybridDict.Controls.Add(this.lblHybridDictUse);
            this.pnlHybridDict.Controls.Add(this.chkHybridDictUse);
            this.pnlHybridDict.Controls.Add(this.txtHybridDictWords);
            this.pnlHybridDict.Controls.Add(this.lblHybridBruteForce);
            this.pnlHybridDict.Location = new System.Drawing.Point(0, 0);
            this.pnlHybridDict.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlHybridDict.Name = "pnlHybridDict";
            this.pnlHybridDict.Size = new System.Drawing.Size(621, 673);
            this.pnlHybridDict.TabIndex = 101;
            // 
            // lblHybridHashcatThreshold2
            // 
            this.lblHybridHashcatThreshold2.AutoSize = true;
            this.lblHybridHashcatThreshold2.Location = new System.Drawing.Point(69, 580);
            this.lblHybridHashcatThreshold2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHybridHashcatThreshold2.Name = "lblHybridHashcatThreshold2";
            this.lblHybridHashcatThreshold2.Size = new System.Drawing.Size(92, 25);
            this.lblHybridHashcatThreshold2.TabIndex = 114;
            this.lblHybridHashcatThreshold2.Text = "min chars.";
            // 
            // cbHybridHashcatThreshold
            // 
            this.cbHybridHashcatThreshold.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHybridHashcatThreshold.DropDownWidth = 80;
            this.cbHybridHashcatThreshold.FormattingEnabled = true;
            this.cbHybridHashcatThreshold.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.cbHybridHashcatThreshold.Location = new System.Drawing.Point(11, 576);
            this.cbHybridHashcatThreshold.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbHybridHashcatThreshold.Name = "cbHybridHashcatThreshold";
            this.cbHybridHashcatThreshold.Size = new System.Drawing.Size(53, 33);
            this.cbHybridHashcatThreshold.TabIndex = 113;
            // 
            // lblHybridHashcatThreshold
            // 
            this.lblHybridHashcatThreshold.AutoSize = true;
            this.lblHybridHashcatThreshold.Location = new System.Drawing.Point(14, 542);
            this.lblHybridHashcatThreshold.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHybridHashcatThreshold.Name = "lblHybridHashcatThreshold";
            this.lblHybridHashcatThreshold.Size = new System.Drawing.Size(162, 25);
            this.lblHybridHashcatThreshold.TabIndex = 112;
            this.lblHybridHashcatThreshold.Text = "Hashcat Threshold:";
            // 
            // chkHybridIgnoreSizeFilters
            // 
            this.chkHybridIgnoreSizeFilters.AutoSize = true;
            this.chkHybridIgnoreSizeFilters.Location = new System.Drawing.Point(9, 628);
            this.chkHybridIgnoreSizeFilters.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkHybridIgnoreSizeFilters.Name = "chkHybridIgnoreSizeFilters";
            this.chkHybridIgnoreSizeFilters.Size = new System.Drawing.Size(180, 29);
            this.chkHybridIgnoreSizeFilters.TabIndex = 111;
            this.chkHybridIgnoreSizeFilters.Text = "Bypass Size Filters";
            this.chkHybridIgnoreSizeFilters.UseVisualStyleBackColor = true;
            // 
            // cbHybridBruteForceMaxCharacters
            // 
            this.cbHybridBruteForceMaxCharacters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHybridBruteForceMaxCharacters.FormattingEnabled = true;
            this.cbHybridBruteForceMaxCharacters.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.cbHybridBruteForceMaxCharacters.Location = new System.Drawing.Point(67, 138);
            this.cbHybridBruteForceMaxCharacters.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbHybridBruteForceMaxCharacters.Name = "cbHybridBruteForceMaxCharacters";
            this.cbHybridBruteForceMaxCharacters.Size = new System.Drawing.Size(53, 33);
            this.cbHybridBruteForceMaxCharacters.TabIndex = 99;
            // 
            // cbHybridBruteForceMinCharacters
            // 
            this.cbHybridBruteForceMinCharacters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHybridBruteForceMinCharacters.FormattingEnabled = true;
            this.cbHybridBruteForceMinCharacters.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.cbHybridBruteForceMinCharacters.Location = new System.Drawing.Point(67, 92);
            this.cbHybridBruteForceMinCharacters.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbHybridBruteForceMinCharacters.Name = "cbHybridBruteForceMinCharacters";
            this.cbHybridBruteForceMinCharacters.Size = new System.Drawing.Size(53, 33);
            this.cbHybridBruteForceMinCharacters.TabIndex = 109;
            // 
            // lblHybridBruteForceFrom
            // 
            this.lblHybridBruteForceFrom.AutoSize = true;
            this.lblHybridBruteForceFrom.Location = new System.Drawing.Point(11, 95);
            this.lblHybridBruteForceFrom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHybridBruteForceFrom.Name = "lblHybridBruteForceFrom";
            this.lblHybridBruteForceFrom.Size = new System.Drawing.Size(153, 25);
            this.lblHybridBruteForceFrom.TabIndex = 110;
            this.lblHybridBruteForceFrom.Text = "from              chrs";
            // 
            // lblHybridBruteForceUpTo
            // 
            this.lblHybridBruteForceUpTo.AutoSize = true;
            this.lblHybridBruteForceUpTo.Location = new System.Drawing.Point(13, 140);
            this.lblHybridBruteForceUpTo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHybridBruteForceUpTo.Name = "lblHybridBruteForceUpTo";
            this.lblHybridBruteForceUpTo.Size = new System.Drawing.Size(152, 25);
            this.lblHybridBruteForceUpTo.TabIndex = 108;
            this.lblHybridBruteForceUpTo.Text = "up to             chrs";
            // 
            // lblHybridWordsInHash
            // 
            this.lblHybridWordsInHash.AutoSize = true;
            this.lblHybridWordsInHash.Location = new System.Drawing.Point(89, 239);
            this.lblHybridWordsInHash.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHybridWordsInHash.Name = "lblHybridWordsInHash";
            this.lblHybridWordsInHash.Size = new System.Drawing.Size(68, 25);
            this.lblHybridWordsInHash.TabIndex = 103;
            this.lblHybridWordsInHash.Text = "in hash";
            // 
            // cbHybridWordsInHash
            // 
            this.cbHybridWordsInHash.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHybridWordsInHash.DropDownWidth = 80;
            this.cbHybridWordsInHash.FormattingEnabled = true;
            this.cbHybridWordsInHash.Items.AddRange(new object[] {
            "1 word",
            "2 words",
            "3 words",
            "4 words"});
            this.cbHybridWordsInHash.Location = new System.Drawing.Point(11, 234);
            this.cbHybridWordsInHash.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbHybridWordsInHash.Name = "cbHybridWordsInHash";
            this.cbHybridWordsInHash.Size = new System.Drawing.Size(70, 33);
            this.cbHybridWordsInHash.TabIndex = 102;
            // 
            // lblHybridCombination
            // 
            this.lblHybridCombination.AutoSize = true;
            this.lblHybridCombination.Location = new System.Drawing.Point(9, 200);
            this.lblHybridCombination.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHybridCombination.Name = "lblHybridCombination";
            this.lblHybridCombination.Size = new System.Drawing.Size(127, 25);
            this.lblHybridCombination.TabIndex = 101;
            this.lblHybridCombination.Text = "Combinations:";
            // 
            // lblHybridDictUse
            // 
            this.lblHybridDictUse.AutoSize = true;
            this.lblHybridDictUse.Location = new System.Drawing.Point(9, 12);
            this.lblHybridDictUse.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHybridDictUse.Name = "lblHybridDictUse";
            this.lblHybridDictUse.Size = new System.Drawing.Size(45, 25);
            this.lblHybridDictUse.TabIndex = 94;
            this.lblHybridDictUse.Text = "Use:";
            // 
            // chkHybridDictUse
            // 
            this.chkHybridDictUse.AutoSize = true;
            this.chkHybridDictUse.Location = new System.Drawing.Point(114, 13);
            this.chkHybridDictUse.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkHybridDictUse.Name = "chkHybridDictUse";
            this.chkHybridDictUse.Size = new System.Drawing.Size(22, 21);
            this.chkHybridDictUse.TabIndex = 95;
            this.chkHybridDictUse.UseVisualStyleBackColor = true;
            this.chkHybridDictUse.CheckedChanged += new System.EventHandler(this.chkHybridDictUse_CheckedChanged);
            // 
            // txtHybridDictWords
            // 
            this.txtHybridDictWords.Location = new System.Drawing.Point(196, 3);
            this.txtHybridDictWords.Multiline = true;
            this.txtHybridDictWords.Name = "txtHybridDictWords";
            this.txtHybridDictWords.Size = new System.Drawing.Size(423, 654);
            this.txtHybridDictWords.TabIndex = 93;
            // 
            // lblHybridBruteForce
            // 
            this.lblHybridBruteForce.AutoSize = true;
            this.lblHybridBruteForce.Location = new System.Drawing.Point(9, 60);
            this.lblHybridBruteForce.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHybridBruteForce.Name = "lblHybridBruteForce";
            this.lblHybridBruteForce.Size = new System.Drawing.Size(97, 25);
            this.lblHybridBruteForce.TabIndex = 96;
            this.lblHybridBruteForce.Text = "Bruteforce:";
            // 
            // tabBruteforceDictFirstWord
            // 
            this.tabBruteforceDictFirstWord.Controls.Add(this.pnlHybridDictFirstWord);
            this.tabBruteforceDictFirstWord.Location = new System.Drawing.Point(4, 34);
            this.tabBruteforceDictFirstWord.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabBruteforceDictFirstWord.Name = "tabBruteforceDictFirstWord";
            this.tabBruteforceDictFirstWord.Size = new System.Drawing.Size(629, 682);
            this.tabBruteforceDictFirstWord.TabIndex = 2;
            this.tabBruteforceDictFirstWord.Text = "First Word Overrides";
            this.tabBruteforceDictFirstWord.UseVisualStyleBackColor = true;
            // 
            // pnlHybridDictFirstWord
            // 
            this.pnlHybridDictFirstWord.Controls.Add(this.lblHybridDictFirstWordUse);
            this.pnlHybridDictFirstWord.Controls.Add(this.txtHybridDictFirstWord);
            this.pnlHybridDictFirstWord.Controls.Add(this.chkHybridDictFirstWordUse);
            this.pnlHybridDictFirstWord.Location = new System.Drawing.Point(0, 0);
            this.pnlHybridDictFirstWord.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlHybridDictFirstWord.Name = "pnlHybridDictFirstWord";
            this.pnlHybridDictFirstWord.Size = new System.Drawing.Size(621, 673);
            this.pnlHybridDictFirstWord.TabIndex = 99;
            // 
            // lblHybridDictFirstWordUse
            // 
            this.lblHybridDictFirstWordUse.AutoSize = true;
            this.lblHybridDictFirstWordUse.Location = new System.Drawing.Point(9, 12);
            this.lblHybridDictFirstWordUse.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHybridDictFirstWordUse.Name = "lblHybridDictFirstWordUse";
            this.lblHybridDictFirstWordUse.Size = new System.Drawing.Size(45, 25);
            this.lblHybridDictFirstWordUse.TabIndex = 97;
            this.lblHybridDictFirstWordUse.Text = "Use:";
            // 
            // txtHybridDictFirstWord
            // 
            this.txtHybridDictFirstWord.Location = new System.Drawing.Point(196, 3);
            this.txtHybridDictFirstWord.Multiline = true;
            this.txtHybridDictFirstWord.Name = "txtHybridDictFirstWord";
            this.txtHybridDictFirstWord.Size = new System.Drawing.Size(452, 654);
            this.txtHybridDictFirstWord.TabIndex = 96;
            // 
            // chkHybridDictFirstWordUse
            // 
            this.chkHybridDictFirstWordUse.AutoSize = true;
            this.chkHybridDictFirstWordUse.Location = new System.Drawing.Point(114, 13);
            this.chkHybridDictFirstWordUse.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkHybridDictFirstWordUse.Name = "chkHybridDictFirstWordUse";
            this.chkHybridDictFirstWordUse.Size = new System.Drawing.Size(22, 21);
            this.chkHybridDictFirstWordUse.TabIndex = 98;
            this.chkHybridDictFirstWordUse.UseVisualStyleBackColor = true;
            this.chkHybridDictFirstWordUse.CheckedChanged += new System.EventHandler(this.chkHybridDictFirstWordUse_CheckedChanged);
            // 
            // tabBruteforceDictLastWord
            // 
            this.tabBruteforceDictLastWord.Controls.Add(this.pnlHybridDictLastWord);
            this.tabBruteforceDictLastWord.Location = new System.Drawing.Point(4, 34);
            this.tabBruteforceDictLastWord.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabBruteforceDictLastWord.Name = "tabBruteforceDictLastWord";
            this.tabBruteforceDictLastWord.Size = new System.Drawing.Size(629, 682);
            this.tabBruteforceDictLastWord.TabIndex = 3;
            this.tabBruteforceDictLastWord.Text = "Last Word Overrides";
            this.tabBruteforceDictLastWord.UseVisualStyleBackColor = true;
            // 
            // pnlHybridDictLastWord
            // 
            this.pnlHybridDictLastWord.Controls.Add(this.lblHybridDictLastWordUse);
            this.pnlHybridDictLastWord.Controls.Add(this.txtHybridDictLastWord);
            this.pnlHybridDictLastWord.Controls.Add(this.chkHybridDictLastWordUse);
            this.pnlHybridDictLastWord.Location = new System.Drawing.Point(0, 0);
            this.pnlHybridDictLastWord.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlHybridDictLastWord.Name = "pnlHybridDictLastWord";
            this.pnlHybridDictLastWord.Size = new System.Drawing.Size(621, 673);
            this.pnlHybridDictLastWord.TabIndex = 99;
            // 
            // lblHybridDictLastWordUse
            // 
            this.lblHybridDictLastWordUse.AutoSize = true;
            this.lblHybridDictLastWordUse.Location = new System.Drawing.Point(9, 12);
            this.lblHybridDictLastWordUse.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHybridDictLastWordUse.Name = "lblHybridDictLastWordUse";
            this.lblHybridDictLastWordUse.Size = new System.Drawing.Size(45, 25);
            this.lblHybridDictLastWordUse.TabIndex = 97;
            this.lblHybridDictLastWordUse.Text = "Use:";
            // 
            // txtHybridDictLastWord
            // 
            this.txtHybridDictLastWord.Location = new System.Drawing.Point(196, 3);
            this.txtHybridDictLastWord.Multiline = true;
            this.txtHybridDictLastWord.Name = "txtHybridDictLastWord";
            this.txtHybridDictLastWord.Size = new System.Drawing.Size(452, 654);
            this.txtHybridDictLastWord.TabIndex = 96;
            // 
            // chkHybridDictLastWordUse
            // 
            this.chkHybridDictLastWordUse.AutoSize = true;
            this.chkHybridDictLastWordUse.Location = new System.Drawing.Point(114, 13);
            this.chkHybridDictLastWordUse.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkHybridDictLastWordUse.Name = "chkHybridDictLastWordUse";
            this.chkHybridDictLastWordUse.Size = new System.Drawing.Size(22, 21);
            this.chkHybridDictLastWordUse.TabIndex = 98;
            this.chkHybridDictLastWordUse.UseVisualStyleBackColor = true;
            this.chkHybridDictLastWordUse.CheckedChanged += new System.EventHandler(this.chkHybridDictLastWordUse_CheckedChanged);
            // 
            // grpGeneral
            // 
            this.grpGeneral.Controls.Add(this.txtValidChars);
            this.grpGeneral.Controls.Add(this.lblValidChars);
            this.grpGeneral.Controls.Add(this.txtHashCatPath);
            this.grpGeneral.Controls.Add(this.lblUtf8Toggle);
            this.grpGeneral.Controls.Add(this.lblHashCat);
            this.grpGeneral.Controls.Add(this.lblStartingValidChars);
            this.grpGeneral.Controls.Add(this.chkUtf8Toggle);
            this.grpGeneral.Controls.Add(this.txtStartingValidChars);
            this.grpGeneral.Location = new System.Drawing.Point(9, 7);
            this.grpGeneral.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpGeneral.Name = "grpGeneral";
            this.grpGeneral.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpGeneral.Size = new System.Drawing.Size(634, 233);
            this.grpGeneral.TabIndex = 42;
            this.grpGeneral.TabStop = false;
            this.grpGeneral.Text = "Bruteforce Settings";
            // 
            // txtValidChars
            // 
            this.txtValidChars.Location = new System.Drawing.Point(171, 32);
            this.txtValidChars.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtValidChars.Name = "txtValidChars";
            this.txtValidChars.Size = new System.Drawing.Size(451, 31);
            this.txtValidChars.TabIndex = 31;
            this.txtValidChars.Text = "etainoshrdlucmfwygpbvkqjxz0123456789_";
            this.txtValidChars.TextChanged += new System.EventHandler(this.TxtValidCharsChanged);
            // 
            // lblValidChars
            // 
            this.lblValidChars.AutoSize = true;
            this.lblValidChars.Location = new System.Drawing.Point(17, 37);
            this.lblValidChars.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblValidChars.Name = "lblValidChars";
            this.lblValidChars.Size = new System.Drawing.Size(103, 25);
            this.lblValidChars.TabIndex = 31;
            this.lblValidChars.Text = "Valid Chars:";
            // 
            // txtHashCatPath
            // 
            this.txtHashCatPath.Location = new System.Drawing.Point(171, 135);
            this.txtHashCatPath.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtHashCatPath.Name = "txtHashCatPath";
            this.txtHashCatPath.Size = new System.Drawing.Size(451, 31);
            this.txtHashCatPath.TabIndex = 39;
            // 
            // lblUtf8Toggle
            // 
            this.lblUtf8Toggle.AutoSize = true;
            this.lblUtf8Toggle.Location = new System.Drawing.Point(17, 188);
            this.lblUtf8Toggle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUtf8Toggle.Name = "lblUtf8Toggle";
            this.lblUtf8Toggle.Size = new System.Drawing.Size(113, 25);
            this.lblUtf8Toggle.TabIndex = 37;
            this.lblUtf8Toggle.Text = "Enable UTF8:";
            // 
            // lblHashCat
            // 
            this.lblHashCat.AutoSize = true;
            this.lblHashCat.Location = new System.Drawing.Point(17, 140);
            this.lblHashCat.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHashCat.Name = "lblHashCat";
            this.lblHashCat.Size = new System.Drawing.Size(118, 25);
            this.lblHashCat.TabIndex = 38;
            this.lblHashCat.Text = "Hashcat Path:";
            // 
            // lblStartingValidChars
            // 
            this.lblStartingValidChars.AutoSize = true;
            this.lblStartingValidChars.Location = new System.Drawing.Point(17, 88);
            this.lblStartingValidChars.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStartingValidChars.Name = "lblStartingValidChars";
            this.lblStartingValidChars.Size = new System.Drawing.Size(126, 25);
            this.lblStartingValidChars.TabIndex = 32;
            this.lblStartingValidChars.Text = "Starting Chars:";
            // 
            // chkUtf8Toggle
            // 
            this.chkUtf8Toggle.AutoSize = true;
            this.chkUtf8Toggle.Location = new System.Drawing.Point(171, 188);
            this.chkUtf8Toggle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkUtf8Toggle.Name = "chkUtf8Toggle";
            this.chkUtf8Toggle.Size = new System.Drawing.Size(22, 21);
            this.chkUtf8Toggle.TabIndex = 40;
            this.chkUtf8Toggle.UseVisualStyleBackColor = true;
            this.chkUtf8Toggle.CheckedChanged += new System.EventHandler(this.Utf8ToggleCheckedChanged);
            // 
            // txtStartingValidChars
            // 
            this.txtStartingValidChars.Location = new System.Drawing.Point(171, 83);
            this.txtStartingValidChars.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtStartingValidChars.Name = "txtStartingValidChars";
            this.txtStartingValidChars.Size = new System.Drawing.Size(451, 31);
            this.txtStartingValidChars.TabIndex = 33;
            this.txtStartingValidChars.Text = "etainoshrdlucmfwygpbvkqjxz_";
            this.txtStartingValidChars.TextChanged += new System.EventHandler(this.TxtStartingValidCharsChanged);
            // 
            // chkDictCachePrefix
            // 
            this.chkDictCachePrefix.AutoSize = true;
            this.chkDictCachePrefix.Location = new System.Drawing.Point(9, 749);
            this.chkDictCachePrefix.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkDictCachePrefix.Name = "chkDictCachePrefix";
            this.chkDictCachePrefix.Size = new System.Drawing.Size(130, 27);
            this.chkDictCachePrefix.TabIndex = 96;
            this.chkDictCachePrefix.Text = "Cache Prefix";
            this.chkDictCachePrefix.UseVisualStyleBackColor = true;
            // 
            // chkDictCacheSuffix
            // 
            this.chkDictCacheSuffix.AutoSize = true;
            this.chkDictCacheSuffix.Location = new System.Drawing.Point(9, 786);
            this.chkDictCacheSuffix.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkDictCacheSuffix.Name = "chkDictCacheSuffix";
            this.chkDictCacheSuffix.Size = new System.Drawing.Size(129, 27);
            this.chkDictCacheSuffix.TabIndex = 97;
            this.chkDictCacheSuffix.Text = "Cache Suffix";
            this.chkDictCacheSuffix.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1211, 1217);
            this.Controls.Add(this.btnQuickLoad);
            this.Controls.Add(this.btnQuickSave);
            this.Controls.Add(this.btnStartHashCat);
            this.Controls.Add(this.lblVerbose);
            this.Controls.Add(this.chkVerbose);
            this.Controls.Add(this.txtDelimiter);
            this.Controls.Add(this.lblDelimiter);
            this.Controls.Add(this.txtSuffix);
            this.Controls.Add(this.lblSuffix);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.cbNbThreads);
            this.Controls.Add(this.lblNbThreads);
            this.Controls.Add(this.txtPrefix);
            this.Controls.Add(this.lblPrefix);
            this.Controls.Add(this.cbMethod);
            this.Controls.Add(this.lblMethod);
            this.Controls.Add(this.txtHexValues);
            this.Controls.Add(this.lblHexValues);
            this.Controls.Add(this.mnStrip);
            this.Controls.Add(this.pnlDictionary);
            this.Controls.Add(this.pnlCharBruteforce);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.mnStrip;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "BruteForceHash";
            this.pnlDictionary.ResumeLayout(false);
            this.grpSizeFiltering.ResumeLayout(false);
            this.grpSizeFiltering.PerformLayout();
            this.grpWordFiltering.ResumeLayout(false);
            this.grpWordFiltering.PerformLayout();
            this.grpAdvanced.ResumeLayout(false);
            this.grpAdvanced.PerformLayout();
            this.grpTypos.ResumeLayout(false);
            this.grpTypos.PerformLayout();
            this.pnlDictBruteforce.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabMainDictionaries.ResumeLayout(false);
            this.tabMainDictionariesCommon.ResumeLayout(false);
            this.tabMainDictionariesCommon.PerformLayout();
            this.tabMainDictionariesCustom.ResumeLayout(false);
            this.tabMainDictionariesCustom.PerformLayout();
            this.tabMainDictionariesExcludeWords.ResumeLayout(false);
            this.tabMainDictionariesExcludeWords.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabFirstWordDictionaries.ResumeLayout(false);
            this.tabFirstWordDictionariesCommon.ResumeLayout(false);
            this.tabFirstWordDictionariesCommon.PerformLayout();
            this.tabFirstWordDictionariesCustom.ResumeLayout(false);
            this.tabFirstWordDictionariesCustom.PerformLayout();
            this.tabFirstWordDictionariesExcludeWords.ResumeLayout(false);
            this.tabFirstWordDictionariesExcludeWords.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabLastWordDictionaries.ResumeLayout(false);
            this.tabLastWordDictionariesCommon.ResumeLayout(false);
            this.tabLastWordDictionariesCommon.PerformLayout();
            this.tabLastWordDictionariesCustom.ResumeLayout(false);
            this.tabLastWordDictionariesCustom.PerformLayout();
            this.tabLastWordDictionariesExcludeWords.ResumeLayout(false);
            this.tabLastWordDictionariesExcludeWords.PerformLayout();
            this.mnStrip.ResumeLayout(false);
            this.mnStrip.PerformLayout();
            this.pnlCharBruteforce.ResumeLayout(false);
            this.tbCharBruteforce.ResumeLayout(false);
            this.tabBruteforceMain.ResumeLayout(false);
            this.grpSpecials.ResumeLayout(false);
            this.grpCharsetPreview.ResumeLayout(false);
            this.grpCharsetPreview.PerformLayout();
            this.tabBruteforceDict.ResumeLayout(false);
            this.pnlHybridDict.ResumeLayout(false);
            this.pnlHybridDict.PerformLayout();
            this.tabBruteforceDictFirstWord.ResumeLayout(false);
            this.pnlHybridDictFirstWord.ResumeLayout(false);
            this.pnlHybridDictFirstWord.PerformLayout();
            this.tabBruteforceDictLastWord.ResumeLayout(false);
            this.pnlHybridDictLastWord.ResumeLayout(false);
            this.pnlHybridDictLastWord.PerformLayout();
            this.grpGeneral.ResumeLayout(false);
            this.grpGeneral.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHexValues;
        private System.Windows.Forms.TextBox txtHexValues;
        private System.Windows.Forms.Label lblMethod;
        private System.Windows.Forms.ComboBox cbMethod;
        private System.Windows.Forms.Label lblPrefix;
        private System.Windows.Forms.TextBox txtPrefix;
        private System.Windows.Forms.Label lblDelimiter;
        private System.Windows.Forms.TextBox txtDelimiter;
        private System.Windows.Forms.Label lblNbThreads;
        private System.Windows.Forms.ComboBox cbNbThreads;
        private System.Windows.Forms.Label lblExcludePatterns;
        private System.Windows.Forms.TextBox txtIncludePatterns;
        private System.Windows.Forms.Label lblIncludePatterns;
        private System.Windows.Forms.TextBox txtExcludePatterns;
        private System.Windows.Forms.Label lblIncludeWord;
        private System.Windows.Forms.TextBox txtIncludeWord;
        private System.Windows.Forms.Label lblWordsLimit;
        private System.Windows.Forms.ComboBox cbWordsLimit;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.CheckBox chkDictFirstAddTypos;
        private System.Windows.Forms.Label lblSuffix;
        private System.Windows.Forms.TextBox txtSuffix;
        private System.Windows.Forms.Label lblCombinationOrder;
        private System.Windows.Forms.Panel pnlDictionary;
        private System.Windows.Forms.CheckBox chkVerbose;
        private System.Windows.Forms.ComboBox cbCombinationOrder;
        private System.Windows.Forms.MenuStrip mnStrip;
        private System.Windows.Forms.ToolStripMenuItem mnFile;
        private System.Windows.Forms.ToolStripMenuItem mnLoad;
        private System.Windows.Forms.ToolStripMenuItem mnSave;
        private System.Windows.Forms.OpenFileDialog openFile;
        private System.Windows.Forms.SaveFileDialog saveFile;
        private System.Windows.Forms.Label lblVerbose;
        private System.Windows.Forms.Label lblDictionaryLastWordUse;
        private System.Windows.Forms.Label lblDictionariesFirstWordUse;
        private System.Windows.Forms.CheckBox chkIncludeWordNotFirst;
        private System.Windows.Forms.CheckBox chkUseDictLast;
        private System.Windows.Forms.CheckBox chkUseDictFirst;
        private System.Windows.Forms.CheckBox chkDictFirstSkipSpecials;
        private System.Windows.Forms.CheckBox chkDictFirstSkipDigits;
        private System.Windows.Forms.CheckBox chkDictFirstForceLowercase;
        private System.Windows.Forms.CheckBox chkDictFirstReverseOrder;
        private System.Windows.Forms.CheckBox chkDictLastSkipDigits;
        private System.Windows.Forms.CheckBox chkDictLastSkipSpecials;
        private System.Windows.Forms.CheckBox chkDictLastForceLowercase;
        private System.Windows.Forms.CheckBox chkDictLastAddTypos;
        private System.Windows.Forms.CheckBox chkDictSkipDigits;
        private System.Windows.Forms.CheckBox chkDictSkipSpecials;
        private System.Windows.Forms.CheckBox chkDictForceLowercase;
        private System.Windows.Forms.CheckBox chkDictAddTypos;
        private System.Windows.Forms.CheckBox chkDictReverseOrder;
        private System.Windows.Forms.ToolStripMenuItem mnNew;
        private System.Windows.Forms.ToolStripSeparator mnSeparator;
        private System.Windows.Forms.Button btnStartHashCat;
        private System.Windows.Forms.CheckBox chkIncludeWordNotLast;
        private System.Windows.Forms.CheckBox chkDictionaryAdvanced;
        private System.Windows.Forms.ComboBox cbMaxDelim;
        private System.Windows.Forms.Label lblMaxDelim;
        private System.Windows.Forms.ComboBox cbMinDelim;
        private System.Windows.Forms.Label lblMinDelim;
        private System.Windows.Forms.ComboBox cbMinConsecutiveConcat;
        private System.Windows.Forms.Label lblMinConsecutiveConcat;
        private System.Windows.Forms.ComboBox cbMaxConsecutiveConcat;
        private System.Windows.Forms.Label lblMaxConsecutiveConcat;
        private System.Windows.Forms.ComboBox cbMinWordLength;
        private System.Windows.Forms.Label lblMinWordLength;
        private System.Windows.Forms.ComboBox cbMaxWordLength;
        private System.Windows.Forms.Label lblMaxWordLength;
        private System.Windows.Forms.ComboBox cbMinOnes;
        private System.Windows.Forms.Label lblToOnes;
        private System.Windows.Forms.ComboBox cbMaxOnes;
        private System.Windows.Forms.Label lblOnes;
        private System.Windows.Forms.ComboBox cbMinWordsLimit;
        private System.Windows.Forms.Label lblMinWordsLimit;
        private System.Windows.Forms.ComboBox cbMaxConsecutiveOnes;
        private System.Windows.Forms.Label lblMaxConsecutiveOnes;
        private System.Windows.Forms.Label lblOnlyLastTwoWordsConcat;
        private System.Windows.Forms.CheckBox chkOnlyLastTwoWordsConcat;
        private System.Windows.Forms.Label lblOnlyFirstTwoWordsConcat;
        private System.Windows.Forms.CheckBox chkOnlyFirstTwoWordsConcat;
        private System.Windows.Forms.GroupBox grpAdvanced;
        private System.Windows.Forms.GroupBox grpTypos;
        private System.Windows.Forms.CheckBox chkTyposReverseLetter;
        private System.Windows.Forms.CheckBox chkTyposWrongLetter;
        private System.Windows.Forms.CheckBox chkTyposExtraLetter;
        private System.Windows.Forms.CheckBox chkTyposDoubleLetter;
        private System.Windows.Forms.CheckBox chkTyposSkipLetter;
        private System.Windows.Forms.CheckBox chkTyposSkipDoubleLetter;
        private System.Windows.Forms.Label lblDictionaryFilterFirstFrom;
        private System.Windows.Forms.TextBox txtDictionaryFilterFirstFrom;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox grpWordFiltering;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label lblMaxConcatWords;
        private System.Windows.Forms.Label lblMinConcatWords;
        private System.Windows.Forms.ComboBox cbMaxConcatWords;
        private System.Windows.Forms.ComboBox cbMinConcatWords;
        private System.Windows.Forms.Button btnDictUnselected;
        private System.Windows.Forms.Button btnDictFirstUnselected;
        private System.Windows.Forms.Button btnDictLastUnselected;
        private System.Windows.Forms.ComboBox cbExcludePatternsSamples;
        private System.Windows.Forms.ComboBox cbIncludePatternsSamples;
        private System.Windows.Forms.ToolStripMenuItem mnRefresh;
        private System.Windows.Forms.ToolStripSeparator mnSeparator2;
        private System.Windows.Forms.Button btnCopyToDictFirst;
        private System.Windows.Forms.Button btnCopyToDictLast;
        private System.Windows.Forms.ToolStripMenuItem mnQuickLoad;
        private System.Windows.Forms.ToolStripMenuItem mnQuickSave;
        private System.Windows.Forms.ToolStripSeparator mnSeparator3;
        private System.Windows.Forms.TextBox txtDictCustWords;
        private System.Windows.Forms.TextBox txtDictLastCustWords;
        private System.Windows.Forms.TextBox txtDictFirstCustWords;
        private System.Windows.Forms.ToolStripMenuItem mnQuickClean;
        private System.Windows.Forms.Button btnQuickSave;
        private System.Windows.Forms.Button btnQuickLoad;
        private RikTheVeggie.TriStateTreeView tvDictMain;
        private RikTheVeggie.TriStateTreeView tvDictFirstWord;
        private RikTheVeggie.TriStateTreeView tvDictLastWord;
        private System.Windows.Forms.GroupBox grpSizeFiltering;
        private System.Windows.Forms.ComboBox cbMaxTwos;
        private System.Windows.Forms.Label lblTwos;
        private System.Windows.Forms.ComboBox cbMinTwos;
        private System.Windows.Forms.Label lblToTwos;
        private System.Windows.Forms.ComboBox cbMinFours;
        private System.Windows.Forms.Label lblToFours;
        private System.Windows.Forms.ComboBox cbMaxFours;
        private System.Windows.Forms.Label lblFours;
        private System.Windows.Forms.ComboBox cbMinThrees;
        private System.Windows.Forms.Label lblToThrees;
        private System.Windows.Forms.ComboBox cbMaxThrees;
        private System.Windows.Forms.Label lblThrees;
        private System.Windows.Forms.ComboBox cbAtLeastAboveNbrChars;
        private System.Windows.Forms.ComboBox cbAtLeastAboveNbrWords;
        private System.Windows.Forms.Label lblAtLeastAbove;
        private System.Windows.Forms.Label lblAtLeastUnder;
        private System.Windows.Forms.ComboBox cbAtLeastUnderNbrChars;
        private System.Windows.Forms.ComboBox cbAtLeastUnderNbrWords;
        private System.Windows.Forms.TabControl tabMainDictionaries;
        private System.Windows.Forms.TabPage tabMainDictionariesCommon;
        private System.Windows.Forms.TabPage tabMainDictionariesCustom;
        private System.Windows.Forms.TabControl tabFirstWordDictionaries;
        private System.Windows.Forms.TabPage tabFirstWordDictionariesCommon;
        private System.Windows.Forms.TabPage tabFirstWordDictionariesCustom;
        private System.Windows.Forms.TabControl tabLastWordDictionaries;
        private System.Windows.Forms.TabPage tabLastWordDictionariesCommon;
        private System.Windows.Forms.TabPage tabLastWordDictionariesCustom;
        private System.Windows.Forms.TabPage tabMainDictionariesExcludeWords;
        private System.Windows.Forms.TabPage tabFirstWordDictionariesExcludeWords;
        private System.Windows.Forms.TabPage tabLastWordDictionariesExcludeWords;
        private System.Windows.Forms.CheckBox chkDictCustomWordsAddTypos;
        private System.Windows.Forms.CheckBox chkDictCustomWordsForceLowercase;
        private System.Windows.Forms.CheckBox chkDictCustomWordsSkipSpecials;
        private System.Windows.Forms.CheckBox chkDictCustomWordsSkipDigits;
        private System.Windows.Forms.Label lblDictionariesCustomWordsAtLeast;
        private System.Windows.Forms.Label lblDictionariesCustomWordsHash;
        private System.Windows.Forms.ComboBox cbDictionariesCustomWordsMinimumInHash;
        private System.Windows.Forms.Label lblDictionariesCustomWordsFiltering;
        private System.Windows.Forms.TextBox txtDictExcludeWords;
        private System.Windows.Forms.CheckBox chkDictionariesExcludeWordsUse;
        private System.Windows.Forms.Label lblDictionariesExcludeWordsUse;
        private System.Windows.Forms.CheckBox chkDictionariesCustomWordsUse;
        private System.Windows.Forms.Label lblDictionariesCustomWordsUse;
        private System.Windows.Forms.CheckBox chkDictExcludePartialWords;
        private System.Windows.Forms.Label lblDictionariesUse;
        private System.Windows.Forms.CheckBox chkDictionariesUse;
        private System.Windows.Forms.CheckBox chkDictionariesFirstWordCustomWordsUse;
        private System.Windows.Forms.Label lblDictionariesFirstWordCustomWordsUse;
        private System.Windows.Forms.CheckBox chkDictFirstWordCustomWordsAddTypos;
        private System.Windows.Forms.CheckBox chkDictFirstWordCustomWordsForceLowercase;
        private System.Windows.Forms.CheckBox chkDictFirstWordCustomWordsSkipSpecials;
        private System.Windows.Forms.CheckBox chkDictFirstWordCustomWordsSkipDigits;
        private System.Windows.Forms.CheckBox chkDictionariesLastWordCustomWordsUse;
        private System.Windows.Forms.Label lblDictionariesLastWordCustomWordsUse;
        private System.Windows.Forms.CheckBox chkDictLastWordCustomWordsAddTypos;
        private System.Windows.Forms.CheckBox chkDictLastWordCustomWordsForceLowercase;
        private System.Windows.Forms.CheckBox chkDictLastWordCustomWordsSkipSpecials;
        private System.Windows.Forms.CheckBox chkDictLastWordCustomWordsSkipDigits;
        private System.Windows.Forms.TextBox txtDictFirstWordExcludeWords;
        private System.Windows.Forms.CheckBox chkDictFirstWordExcludePartialWords;
        private System.Windows.Forms.CheckBox chkDictionariesFirstWordExcludeWordsUse;
        private System.Windows.Forms.Label lblDictionariesFirstWordExcludeWordsUse;
        private System.Windows.Forms.TextBox txtDictLastWordExcludeWords;
        private System.Windows.Forms.CheckBox chkDictLastWordExcludePartialWords;
        private System.Windows.Forms.CheckBox chkDictionariesLastWordExcludeWordsUse;
        private System.Windows.Forms.Label lblDictionariesLastWordExcludeWordsUse;
        private System.Windows.Forms.CheckBox chkDictLastReverseOrder;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printLatestCommandToolStripMenuItem;
        private System.Windows.Forms.Button btnCopyToDictCustomFirst;
        private System.Windows.Forms.Button btnCopyToDictExcludeFirst;
        private System.Windows.Forms.Button btnCopyToDictCustomLast;
        private System.Windows.Forms.Button btnCopyToDictExcludeLast;
        private System.Windows.Forms.ComboBox cbAtMostAboveNbrWords;
        private System.Windows.Forms.Label lblAtMostUnder;
        private System.Windows.Forms.Label lblAtMostAbove;
        private System.Windows.Forms.ComboBox cbAtMostUnderNbrWords;
        private System.Windows.Forms.ComboBox cbAtMostAboveNbrChars;
        private System.Windows.Forms.ComboBox cbAtMostUnderNbrChars;
        private System.Windows.Forms.Label lblDictionaryFilterFirstTo;
        private System.Windows.Forms.TextBox txtDictionaryFilterFirstTo;
        private System.Windows.Forms.TextBox txtTyposSwapLetters;
        private System.Windows.Forms.Label lblTyposSwapLetters;
        private System.Windows.Forms.TextBox txtTyposAppendLetters;
        private System.Windows.Forms.Label lblTyposAppendLetters;
        private System.Windows.Forms.Panel pnlDictBruteforce;
        private System.Windows.Forms.Panel pnlCharBruteforce;
        private System.Windows.Forms.TabControl tbCharBruteforce;
        private System.Windows.Forms.TabPage tabBruteforceMain;
        private System.Windows.Forms.GroupBox grpSpecials;
        private System.Windows.Forms.CheckedListBox chklCharsets;
        private System.Windows.Forms.GroupBox grpCharsetPreview;
        private System.Windows.Forms.Label lblStartingValidCharsPreview;
        private System.Windows.Forms.TextBox txtStartingValidCharsPreview;
        private System.Windows.Forms.Label lblValidCharsPreview;
        private System.Windows.Forms.TextBox txtValidCharsPreview;
        private System.Windows.Forms.TabPage tabBruteforceDict;
        private System.Windows.Forms.TabPage tabBruteforceDictFirstWord;
        private System.Windows.Forms.TabPage tabBruteforceDictLastWord;
        private System.Windows.Forms.GroupBox grpGeneral;
        private System.Windows.Forms.TextBox txtValidChars;
        private System.Windows.Forms.Label lblValidChars;
        private System.Windows.Forms.Label lblUtf8Toggle;
        private System.Windows.Forms.Label lblStartingValidChars;
        private System.Windows.Forms.CheckBox chkUtf8Toggle;
        private System.Windows.Forms.TextBox txtStartingValidChars;
        private System.Windows.Forms.TextBox txtHashCatPath;
        private System.Windows.Forms.Label lblHashCat;
        private System.Windows.Forms.CheckBox chkHybridDictUse;
        private System.Windows.Forms.Label lblHybridDictUse;
        private System.Windows.Forms.TextBox txtHybridDictWords;
        private System.Windows.Forms.Label lblHybridBruteForce;
        private System.Windows.Forms.ComboBox cbHybridBruteForceMaxCharacters;
        private System.Windows.Forms.CheckBox chkHybridDictFirstWordUse;
        private System.Windows.Forms.Label lblHybridDictFirstWordUse;
        private System.Windows.Forms.TextBox txtHybridDictFirstWord;
        private System.Windows.Forms.CheckBox chkHybridDictLastWordUse;
        private System.Windows.Forms.Label lblHybridDictLastWordUse;
        private System.Windows.Forms.TextBox txtHybridDictLastWord;
        private System.Windows.Forms.Panel pnlHybridDict;
        private System.Windows.Forms.Panel pnlHybridDictFirstWord;
        private System.Windows.Forms.Panel pnlHybridDictLastWord;
        private System.Windows.Forms.Label lblHybridWordsInHash;
        private System.Windows.Forms.ComboBox cbHybridWordsInHash;
        private System.Windows.Forms.Label lblHybridCombination;
        private System.Windows.Forms.ComboBox cbHybridBruteForceMinCharacters;
        private System.Windows.Forms.Label lblHybridBruteForceFrom;
        private System.Windows.Forms.Label lblHybridBruteForceUpTo;
        private System.Windows.Forms.CheckBox chkHybridIgnoreSizeFilters;
        private System.Windows.Forms.ComboBox cbHybridHashcatThreshold;
        private System.Windows.Forms.Label lblHybridHashcatThreshold;
        private System.Windows.Forms.Label lblHybridHashcatThreshold2;
        private System.Windows.Forms.CheckBox chkDictCacheSuffix;
        private System.Windows.Forms.CheckBox chkDictCachePrefix;
    }
}



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
            components = new System.ComponentModel.Container();
            lblHexValues = new System.Windows.Forms.Label();
            txtHexValues = new System.Windows.Forms.TextBox();
            lblMethod = new System.Windows.Forms.Label();
            cbMethod = new System.Windows.Forms.ComboBox();
            lblPrefix = new System.Windows.Forms.Label();
            txtPrefix = new System.Windows.Forms.TextBox();
            lblDelimiter = new System.Windows.Forms.Label();
            txtDelimiter = new System.Windows.Forms.TextBox();
            lblNbThreads = new System.Windows.Forms.Label();
            cbNbThreads = new System.Windows.Forms.ComboBox();
            lblExcludePatterns = new System.Windows.Forms.Label();
            txtExcludePatterns = new System.Windows.Forms.TextBox();
            lblIncludePatterns = new System.Windows.Forms.Label();
            txtIncludePatterns = new System.Windows.Forms.TextBox();
            lblIncludeWord = new System.Windows.Forms.Label();
            txtIncludeWord = new System.Windows.Forms.TextBox();
            lblWordsLimit = new System.Windows.Forms.Label();
            cbWordsLimit = new System.Windows.Forms.ComboBox();
            btnStart = new System.Windows.Forms.Button();
            lblSuffix = new System.Windows.Forms.Label();
            txtSuffix = new System.Windows.Forms.TextBox();
            lblCombinationOrder = new System.Windows.Forms.Label();
            pnlDictionary = new System.Windows.Forms.Panel();
            grpSizeFiltering = new System.Windows.Forms.GroupBox();
            cbMaxFours = new System.Windows.Forms.ComboBox();
            cbMaxThrees = new System.Windows.Forms.ComboBox();
            cbMaxTwos = new System.Windows.Forms.ComboBox();
            cbAtMostUnderNbrChars = new System.Windows.Forms.ComboBox();
            cbAtMostAboveNbrChars = new System.Windows.Forms.ComboBox();
            cbAtMostUnderNbrWords = new System.Windows.Forms.ComboBox();
            cbAtMostAboveNbrWords = new System.Windows.Forms.ComboBox();
            lblAtMostUnder = new System.Windows.Forms.Label();
            lblAtMostAbove = new System.Windows.Forms.Label();
            cbAtLeastUnderNbrChars = new System.Windows.Forms.ComboBox();
            cbAtLeastUnderNbrWords = new System.Windows.Forms.ComboBox();
            lblAtLeastUnder = new System.Windows.Forms.Label();
            cbAtLeastAboveNbrChars = new System.Windows.Forms.ComboBox();
            cbAtLeastAboveNbrWords = new System.Windows.Forms.ComboBox();
            lblAtLeastAbove = new System.Windows.Forms.Label();
            cbMinFours = new System.Windows.Forms.ComboBox();
            lblToFours = new System.Windows.Forms.Label();
            lblFours = new System.Windows.Forms.Label();
            cbMinThrees = new System.Windows.Forms.ComboBox();
            lblToThrees = new System.Windows.Forms.Label();
            lblThrees = new System.Windows.Forms.Label();
            cbMinTwos = new System.Windows.Forms.ComboBox();
            lblToTwos = new System.Windows.Forms.Label();
            lblTwos = new System.Windows.Forms.Label();
            lblMaxDelim = new System.Windows.Forms.Label();
            lblOnes = new System.Windows.Forms.Label();
            cbMinWordLength = new System.Windows.Forms.ComboBox();
            cbMaxOnes = new System.Windows.Forms.ComboBox();
            lblMinWordLength = new System.Windows.Forms.Label();
            lblToOnes = new System.Windows.Forms.Label();
            cbMaxWordLength = new System.Windows.Forms.ComboBox();
            cbMaxDelim = new System.Windows.Forms.ComboBox();
            cbMinOnes = new System.Windows.Forms.ComboBox();
            lblMaxWordLength = new System.Windows.Forms.Label();
            lblMinDelim = new System.Windows.Forms.Label();
            cbMinDelim = new System.Windows.Forms.ComboBox();
            grpWordFiltering = new System.Windows.Forms.GroupBox();
            cbIncludePatternsSamples = new System.Windows.Forms.ComboBox();
            cbExcludePatternsSamples = new System.Windows.Forms.ComboBox();
            cbCombinationOrder = new System.Windows.Forms.ComboBox();
            chkIncludeWordNotLast = new System.Windows.Forms.CheckBox();
            chkIncludeWordNotFirst = new System.Windows.Forms.CheckBox();
            grpAdvanced = new System.Windows.Forms.GroupBox();
            cbMinConcatWords = new System.Windows.Forms.ComboBox();
            cbMaxConcatWords = new System.Windows.Forms.ComboBox();
            lblMinConcatWords = new System.Windows.Forms.Label();
            lblMaxConcatWords = new System.Windows.Forms.Label();
            chkDictionaryAdvanced = new System.Windows.Forms.CheckBox();
            lblOnlyLastTwoWordsConcat = new System.Windows.Forms.Label();
            chkOnlyLastTwoWordsConcat = new System.Windows.Forms.CheckBox();
            lblOnlyFirstTwoWordsConcat = new System.Windows.Forms.Label();
            chkOnlyFirstTwoWordsConcat = new System.Windows.Forms.CheckBox();
            lblMaxConsecutiveConcat = new System.Windows.Forms.Label();
            cbMinWordsLimit = new System.Windows.Forms.ComboBox();
            cbMaxConsecutiveConcat = new System.Windows.Forms.ComboBox();
            lblMinWordsLimit = new System.Windows.Forms.Label();
            lblMinConsecutiveConcat = new System.Windows.Forms.Label();
            cbMaxConsecutiveOnes = new System.Windows.Forms.ComboBox();
            cbMinConsecutiveConcat = new System.Windows.Forms.ComboBox();
            lblMaxConsecutiveOnes = new System.Windows.Forms.Label();
            grpTypos = new System.Windows.Forms.GroupBox();
            txtTyposAppendLetters = new System.Windows.Forms.TextBox();
            lblTyposAppendLetters = new System.Windows.Forms.Label();
            txtTyposSwapLetters = new System.Windows.Forms.TextBox();
            lblTyposSwapLetters = new System.Windows.Forms.Label();
            chkTyposReverseLetter = new System.Windows.Forms.CheckBox();
            chkTyposWrongLetter = new System.Windows.Forms.CheckBox();
            chkTyposExtraLetter = new System.Windows.Forms.CheckBox();
            chkTyposDoubleLetter = new System.Windows.Forms.CheckBox();
            chkTyposSkipLetter = new System.Windows.Forms.CheckBox();
            chkTyposSkipDoubleLetter = new System.Windows.Forms.CheckBox();
            pnlDictBruteforce = new System.Windows.Forms.Panel();
            tabControl = new System.Windows.Forms.TabControl();
            tabPage1 = new System.Windows.Forms.TabPage();
            tabMainDictionaries = new System.Windows.Forms.TabControl();
            tabMainDictionariesCommon = new System.Windows.Forms.TabPage();
            chkDictCacheSuffix = new System.Windows.Forms.CheckBox();
            chkDictCachePrefix = new System.Windows.Forms.CheckBox();
            txtDictionaryFilterFirstTo = new System.Windows.Forms.TextBox();
            lblDictionaryFilterFirstTo = new System.Windows.Forms.Label();
            chkDictionariesUse = new System.Windows.Forms.CheckBox();
            lblDictionariesUse = new System.Windows.Forms.Label();
            btnDictUnselected = new System.Windows.Forms.Button();
            tvDictMain = new RikTheVeggie.TriStateTreeView();
            chkDictReverseOrder = new System.Windows.Forms.CheckBox();
            chkDictAddTypos = new System.Windows.Forms.CheckBox();
            txtDictionaryFilterFirstFrom = new System.Windows.Forms.TextBox();
            chkDictForceLowercase = new System.Windows.Forms.CheckBox();
            lblDictionaryFilterFirstFrom = new System.Windows.Forms.Label();
            chkDictSkipSpecials = new System.Windows.Forms.CheckBox();
            chkDictSkipDigits = new System.Windows.Forms.CheckBox();
            tabMainDictionariesCustom = new System.Windows.Forms.TabPage();
            chkDictionariesCustomWordsMinimumInHashUseTypos = new System.Windows.Forms.CheckBox();
            chkDictionariesCustomWordsUse = new System.Windows.Forms.CheckBox();
            lblDictionariesCustomWordsUse = new System.Windows.Forms.Label();
            lblDictionariesCustomWordsAtLeast = new System.Windows.Forms.Label();
            lblDictionariesCustomWordsHash = new System.Windows.Forms.Label();
            cbDictionariesCustomWordsMinimumInHash = new System.Windows.Forms.ComboBox();
            lblDictionariesCustomWordsFiltering = new System.Windows.Forms.Label();
            chkDictCustomWordsAddTypos = new System.Windows.Forms.CheckBox();
            chkDictCustomWordsForceLowercase = new System.Windows.Forms.CheckBox();
            chkDictCustomWordsSkipSpecials = new System.Windows.Forms.CheckBox();
            chkDictCustomWordsSkipDigits = new System.Windows.Forms.CheckBox();
            txtDictCustWords = new System.Windows.Forms.TextBox();
            tabMainDictionariesExcludeWords = new System.Windows.Forms.TabPage();
            chkDictExcludePartialWords = new System.Windows.Forms.CheckBox();
            chkDictionariesExcludeWordsUse = new System.Windows.Forms.CheckBox();
            lblDictionariesExcludeWordsUse = new System.Windows.Forms.Label();
            txtDictExcludeWords = new System.Windows.Forms.TextBox();
            tabPage2 = new System.Windows.Forms.TabPage();
            tabFirstWordDictionaries = new System.Windows.Forms.TabControl();
            tabFirstWordDictionariesCommon = new System.Windows.Forms.TabPage();
            lblDictionariesFirstWordUse = new System.Windows.Forms.Label();
            tvDictFirstWord = new RikTheVeggie.TriStateTreeView();
            chkDictFirstReverseOrder = new System.Windows.Forms.CheckBox();
            btnCopyToDictFirst = new System.Windows.Forms.Button();
            btnDictFirstUnselected = new System.Windows.Forms.Button();
            chkDictFirstAddTypos = new System.Windows.Forms.CheckBox();
            chkDictFirstForceLowercase = new System.Windows.Forms.CheckBox();
            chkDictFirstSkipSpecials = new System.Windows.Forms.CheckBox();
            chkUseDictFirst = new System.Windows.Forms.CheckBox();
            chkDictFirstSkipDigits = new System.Windows.Forms.CheckBox();
            tabFirstWordDictionariesCustom = new System.Windows.Forms.TabPage();
            btnCopyToDictCustomFirst = new System.Windows.Forms.Button();
            chkDictionariesFirstWordCustomWordsUse = new System.Windows.Forms.CheckBox();
            lblDictionariesFirstWordCustomWordsUse = new System.Windows.Forms.Label();
            chkDictFirstWordCustomWordsAddTypos = new System.Windows.Forms.CheckBox();
            chkDictFirstWordCustomWordsForceLowercase = new System.Windows.Forms.CheckBox();
            chkDictFirstWordCustomWordsSkipSpecials = new System.Windows.Forms.CheckBox();
            chkDictFirstWordCustomWordsSkipDigits = new System.Windows.Forms.CheckBox();
            txtDictFirstCustWords = new System.Windows.Forms.TextBox();
            tabFirstWordDictionariesExcludeWords = new System.Windows.Forms.TabPage();
            btnCopyToDictExcludeFirst = new System.Windows.Forms.Button();
            txtDictFirstWordExcludeWords = new System.Windows.Forms.TextBox();
            chkDictFirstWordExcludePartialWords = new System.Windows.Forms.CheckBox();
            chkDictionariesFirstWordExcludeWordsUse = new System.Windows.Forms.CheckBox();
            lblDictionariesFirstWordExcludeWordsUse = new System.Windows.Forms.Label();
            tabPage3 = new System.Windows.Forms.TabPage();
            tabLastWordDictionaries = new System.Windows.Forms.TabControl();
            tabLastWordDictionariesCommon = new System.Windows.Forms.TabPage();
            lblDictionaryLastWordUse = new System.Windows.Forms.Label();
            tvDictLastWord = new RikTheVeggie.TriStateTreeView();
            chkDictLastForceLowercase = new System.Windows.Forms.CheckBox();
            btnCopyToDictLast = new System.Windows.Forms.Button();
            btnDictLastUnselected = new System.Windows.Forms.Button();
            chkDictLastSkipSpecials = new System.Windows.Forms.CheckBox();
            chkDictLastAddTypos = new System.Windows.Forms.CheckBox();
            chkDictLastSkipDigits = new System.Windows.Forms.CheckBox();
            chkUseDictLast = new System.Windows.Forms.CheckBox();
            chkDictLastReverseOrder = new System.Windows.Forms.CheckBox();
            tabLastWordDictionariesCustom = new System.Windows.Forms.TabPage();
            btnCopyToDictCustomLast = new System.Windows.Forms.Button();
            chkDictionariesLastWordCustomWordsUse = new System.Windows.Forms.CheckBox();
            lblDictionariesLastWordCustomWordsUse = new System.Windows.Forms.Label();
            chkDictLastWordCustomWordsAddTypos = new System.Windows.Forms.CheckBox();
            chkDictLastWordCustomWordsForceLowercase = new System.Windows.Forms.CheckBox();
            chkDictLastWordCustomWordsSkipSpecials = new System.Windows.Forms.CheckBox();
            chkDictLastWordCustomWordsSkipDigits = new System.Windows.Forms.CheckBox();
            txtDictLastCustWords = new System.Windows.Forms.TextBox();
            tabLastWordDictionariesExcludeWords = new System.Windows.Forms.TabPage();
            btnCopyToDictExcludeLast = new System.Windows.Forms.Button();
            txtDictLastWordExcludeWords = new System.Windows.Forms.TextBox();
            chkDictLastWordExcludePartialWords = new System.Windows.Forms.CheckBox();
            chkDictionariesLastWordExcludeWordsUse = new System.Windows.Forms.CheckBox();
            lblDictionariesLastWordExcludeWordsUse = new System.Windows.Forms.Label();
            chkVerbose = new System.Windows.Forms.CheckBox();
            mnStrip = new System.Windows.Forms.MenuStrip();
            mnFile = new System.Windows.Forms.ToolStripMenuItem();
            mnNew = new System.Windows.Forms.ToolStripMenuItem();
            mnSeparator = new System.Windows.Forms.ToolStripSeparator();
            mnRefresh = new System.Windows.Forms.ToolStripMenuItem();
            mnSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            mnQuickLoad = new System.Windows.Forms.ToolStripMenuItem();
            mnQuickSave = new System.Windows.Forms.ToolStripMenuItem();
            mnQuickClean = new System.Windows.Forms.ToolStripMenuItem();
            mnSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            mnLoad = new System.Windows.Forms.ToolStripMenuItem();
            mnSave = new System.Windows.Forms.ToolStripMenuItem();
            toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            printLatestCommandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            openFile = new System.Windows.Forms.OpenFileDialog();
            saveFile = new System.Windows.Forms.SaveFileDialog();
            lblVerbose = new System.Windows.Forms.Label();
            btnStartHashCat = new System.Windows.Forms.Button();
            btnQuickSave = new System.Windows.Forms.Button();
            btnQuickLoad = new System.Windows.Forms.Button();
            pnlCharBruteforce = new System.Windows.Forms.Panel();
            tbCharBruteforce = new System.Windows.Forms.TabControl();
            tabBruteforceMain = new System.Windows.Forms.TabPage();
            grpSpecials = new System.Windows.Forms.GroupBox();
            chklCharsets = new System.Windows.Forms.CheckedListBox();
            grpCharsetPreview = new System.Windows.Forms.GroupBox();
            lblStartingValidCharsPreview = new System.Windows.Forms.Label();
            txtStartingValidCharsPreview = new System.Windows.Forms.TextBox();
            lblValidCharsPreview = new System.Windows.Forms.Label();
            txtValidCharsPreview = new System.Windows.Forms.TextBox();
            tabBruteforceDict = new System.Windows.Forms.TabPage();
            pnlHybridDict = new System.Windows.Forms.Panel();
            lblHybridHashcatThreshold2 = new System.Windows.Forms.Label();
            cbHybridHashcatThreshold = new System.Windows.Forms.ComboBox();
            lblHybridHashcatThreshold = new System.Windows.Forms.Label();
            chkHybridIgnoreSizeFilters = new System.Windows.Forms.CheckBox();
            cbHybridBruteForceMaxCharacters = new System.Windows.Forms.ComboBox();
            cbHybridBruteForceMinCharacters = new System.Windows.Forms.ComboBox();
            lblHybridBruteForceFrom = new System.Windows.Forms.Label();
            lblHybridBruteForceUpTo = new System.Windows.Forms.Label();
            lblHybridWordsInHash = new System.Windows.Forms.Label();
            cbHybridWordsInHash = new System.Windows.Forms.ComboBox();
            lblHybridCombination = new System.Windows.Forms.Label();
            lblHybridDictUse = new System.Windows.Forms.Label();
            chkHybridDictUse = new System.Windows.Forms.CheckBox();
            txtHybridDictWords = new System.Windows.Forms.TextBox();
            lblHybridBruteForce = new System.Windows.Forms.Label();
            tabBruteforceDictFirstWord = new System.Windows.Forms.TabPage();
            pnlHybridDictFirstWord = new System.Windows.Forms.Panel();
            lblHybridDictFirstWordUse = new System.Windows.Forms.Label();
            txtHybridDictFirstWord = new System.Windows.Forms.TextBox();
            chkHybridDictFirstWordUse = new System.Windows.Forms.CheckBox();
            tabBruteforceDictLastWord = new System.Windows.Forms.TabPage();
            pnlHybridDictLastWord = new System.Windows.Forms.Panel();
            lblHybridDictLastWordUse = new System.Windows.Forms.Label();
            txtHybridDictLastWord = new System.Windows.Forms.TextBox();
            chkHybridDictLastWordUse = new System.Windows.Forms.CheckBox();
            grpGeneral = new System.Windows.Forms.GroupBox();
            txtValidChars = new System.Windows.Forms.TextBox();
            lblValidChars = new System.Windows.Forms.Label();
            txtHashCatPath = new System.Windows.Forms.TextBox();
            lblUtf8Toggle = new System.Windows.Forms.Label();
            lblHashCat = new System.Windows.Forms.Label();
            lblStartingValidChars = new System.Windows.Forms.Label();
            chkUtf8Toggle = new System.Windows.Forms.CheckBox();
            txtStartingValidChars = new System.Windows.Forms.TextBox();
            pnlDictionary.SuspendLayout();
            grpSizeFiltering.SuspendLayout();
            grpWordFiltering.SuspendLayout();
            grpAdvanced.SuspendLayout();
            grpTypos.SuspendLayout();
            pnlDictBruteforce.SuspendLayout();
            tabControl.SuspendLayout();
            tabPage1.SuspendLayout();
            tabMainDictionaries.SuspendLayout();
            tabMainDictionariesCommon.SuspendLayout();
            tabMainDictionariesCustom.SuspendLayout();
            tabMainDictionariesExcludeWords.SuspendLayout();
            tabPage2.SuspendLayout();
            tabFirstWordDictionaries.SuspendLayout();
            tabFirstWordDictionariesCommon.SuspendLayout();
            tabFirstWordDictionariesCustom.SuspendLayout();
            tabFirstWordDictionariesExcludeWords.SuspendLayout();
            tabPage3.SuspendLayout();
            tabLastWordDictionaries.SuspendLayout();
            tabLastWordDictionariesCommon.SuspendLayout();
            tabLastWordDictionariesCustom.SuspendLayout();
            tabLastWordDictionariesExcludeWords.SuspendLayout();
            mnStrip.SuspendLayout();
            pnlCharBruteforce.SuspendLayout();
            tbCharBruteforce.SuspendLayout();
            tabBruteforceMain.SuspendLayout();
            grpSpecials.SuspendLayout();
            grpCharsetPreview.SuspendLayout();
            tabBruteforceDict.SuspendLayout();
            pnlHybridDict.SuspendLayout();
            tabBruteforceDictFirstWord.SuspendLayout();
            pnlHybridDictFirstWord.SuspendLayout();
            tabBruteforceDictLastWord.SuspendLayout();
            pnlHybridDictLastWord.SuspendLayout();
            grpGeneral.SuspendLayout();
            SuspendLayout();
            // 
            // lblHexValues
            // 
            lblHexValues.AutoSize = true;
            lblHexValues.Location = new System.Drawing.Point(16, 76);
            lblHexValues.Name = "lblHexValues";
            lblHexValues.Size = new System.Drawing.Size(75, 15);
            lblHexValues.TabIndex = 0;
            lblHexValues.Text = "Hex Value(s):";
            // 
            // txtHexValues
            // 
            txtHexValues.Location = new System.Drawing.Point(123, 74);
            txtHexValues.Name = "txtHexValues";
            txtHexValues.PlaceholderText = "0x105274ba4f";
            txtHexValues.Size = new System.Drawing.Size(160, 23);
            txtHexValues.TabIndex = 1;
            txtHexValues.TextChanged += txtHexValues_TextChanged;
            // 
            // lblMethod
            // 
            lblMethod.AutoSize = true;
            lblMethod.Location = new System.Drawing.Point(16, 36);
            lblMethod.Name = "lblMethod";
            lblMethod.Size = new System.Drawing.Size(71, 15);
            lblMethod.TabIndex = 2;
            lblMethod.Text = "Attack Type:";
            // 
            // cbMethod
            // 
            cbMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbMethod.FormattingEnabled = true;
            cbMethod.Items.AddRange(new object[] { "Dictionary", "Character", "Hybrid" });
            cbMethod.Location = new System.Drawing.Point(123, 33);
            cbMethod.Name = "cbMethod";
            cbMethod.Size = new System.Drawing.Size(160, 23);
            cbMethod.TabIndex = 3;
            cbMethod.SelectedIndexChanged += OnCbMethodChanged;
            // 
            // lblPrefix
            // 
            lblPrefix.AutoSize = true;
            lblPrefix.Location = new System.Drawing.Point(409, 76);
            lblPrefix.Name = "lblPrefix";
            lblPrefix.Size = new System.Drawing.Size(40, 15);
            lblPrefix.TabIndex = 4;
            lblPrefix.Text = "Prefix:";
            // 
            // txtPrefix
            // 
            txtPrefix.Location = new System.Drawing.Point(480, 74);
            txtPrefix.Name = "txtPrefix";
            txtPrefix.Size = new System.Drawing.Size(143, 23);
            txtPrefix.TabIndex = 5;
            // 
            // lblDelimiter
            // 
            lblDelimiter.AutoSize = true;
            lblDelimiter.Location = new System.Drawing.Point(599, 36);
            lblDelimiter.Name = "lblDelimiter";
            lblDelimiter.Size = new System.Drawing.Size(58, 15);
            lblDelimiter.TabIndex = 6;
            lblDelimiter.Text = "Delimiter:";
            // 
            // txtDelimiter
            // 
            txtDelimiter.Location = new System.Drawing.Point(680, 32);
            txtDelimiter.MaxLength = 1;
            txtDelimiter.Name = "txtDelimiter";
            txtDelimiter.Size = new System.Drawing.Size(27, 23);
            txtDelimiter.TabIndex = 7;
            txtDelimiter.Text = "_";
            txtDelimiter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblNbThreads
            // 
            lblNbThreads.AutoSize = true;
            lblNbThreads.Location = new System.Drawing.Point(409, 36);
            lblNbThreads.Name = "lblNbThreads";
            lblNbThreads.Size = new System.Drawing.Size(51, 15);
            lblNbThreads.TabIndex = 12;
            lblNbThreads.Text = "Threads:";
            // 
            // cbNbThreads
            // 
            cbNbThreads.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbNbThreads.FormattingEnabled = true;
            cbNbThreads.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60", "61", "62", "63", "64" });
            cbNbThreads.Location = new System.Drawing.Point(480, 34);
            cbNbThreads.Name = "cbNbThreads";
            cbNbThreads.Size = new System.Drawing.Size(78, 23);
            cbNbThreads.TabIndex = 13;
            // 
            // lblExcludePatterns
            // 
            lblExcludePatterns.AutoSize = true;
            lblExcludePatterns.Location = new System.Drawing.Point(6, 22);
            lblExcludePatterns.Name = "lblExcludePatterns";
            lblExcludePatterns.Size = new System.Drawing.Size(97, 15);
            lblExcludePatterns.TabIndex = 14;
            lblExcludePatterns.Text = "Exclude Patterns:";
            // 
            // txtExcludePatterns
            // 
            txtExcludePatterns.Location = new System.Drawing.Point(121, 20);
            txtExcludePatterns.Name = "txtExcludePatterns";
            txtExcludePatterns.PlaceholderText = "{1}_{1},{2}_{2}";
            txtExcludePatterns.Size = new System.Drawing.Size(188, 23);
            txtExcludePatterns.TabIndex = 15;
            // 
            // lblIncludePatterns
            // 
            lblIncludePatterns.AutoSize = true;
            lblIncludePatterns.Location = new System.Drawing.Point(6, 53);
            lblIncludePatterns.Name = "lblIncludePatterns";
            lblIncludePatterns.Size = new System.Drawing.Size(95, 15);
            lblIncludePatterns.TabIndex = 16;
            lblIncludePatterns.Text = "Include Patterns:";
            // 
            // txtIncludePatterns
            // 
            txtIncludePatterns.Location = new System.Drawing.Point(121, 50);
            txtIncludePatterns.Name = "txtIncludePatterns";
            txtIncludePatterns.PlaceholderText = "{3}";
            txtIncludePatterns.Size = new System.Drawing.Size(188, 23);
            txtIncludePatterns.TabIndex = 17;
            // 
            // lblIncludeWord
            // 
            lblIncludeWord.AutoSize = true;
            lblIncludeWord.Location = new System.Drawing.Point(6, 87);
            lblIncludeWord.Name = "lblIncludeWord";
            lblIncludeWord.Size = new System.Drawing.Size(81, 15);
            lblIncludeWord.TabIndex = 18;
            lblIncludeWord.Text = "Include Word:";
            // 
            // txtIncludeWord
            // 
            txtIncludeWord.Location = new System.Drawing.Point(120, 83);
            txtIncludeWord.Name = "txtIncludeWord";
            txtIncludeWord.PlaceholderText = "mario,luigi";
            txtIncludeWord.Size = new System.Drawing.Size(114, 23);
            txtIncludeWord.TabIndex = 19;
            // 
            // lblWordsLimit
            // 
            lblWordsLimit.AutoSize = true;
            lblWordsLimit.Location = new System.Drawing.Point(236, 125);
            lblWordsLimit.Name = "lblWordsLimit";
            lblWordsLimit.Size = new System.Drawing.Size(74, 15);
            lblWordsLimit.TabIndex = 20;
            lblWordsLimit.Text = "Words Limit:";
            // 
            // cbWordsLimit
            // 
            cbWordsLimit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbWordsLimit.FormattingEnabled = true;
            cbWordsLimit.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" });
            cbWordsLimit.Location = new System.Drawing.Point(314, 122);
            cbWordsLimit.Name = "cbWordsLimit";
            cbWordsLimit.Size = new System.Drawing.Size(38, 23);
            cbWordsLimit.TabIndex = 21;
            // 
            // btnStart
            // 
            btnStart.Location = new System.Drawing.Point(175, 694);
            btnStart.Name = "btnStart";
            btnStart.Size = new System.Drawing.Size(213, 22);
            btnStart.TabIndex = 24;
            btnStart.Text = "START";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += OnBtnStartClick;
            // 
            // lblSuffix
            // 
            lblSuffix.AutoSize = true;
            lblSuffix.Location = new System.Drawing.Point(635, 76);
            lblSuffix.Name = "lblSuffix";
            lblSuffix.Size = new System.Drawing.Size(40, 15);
            lblSuffix.TabIndex = 27;
            lblSuffix.Text = "Suffix:";
            // 
            // txtSuffix
            // 
            txtSuffix.Location = new System.Drawing.Point(682, 74);
            txtSuffix.Name = "txtSuffix";
            txtSuffix.Size = new System.Drawing.Size(154, 23);
            txtSuffix.TabIndex = 28;
            // 
            // lblCombinationOrder
            // 
            lblCombinationOrder.AutoSize = true;
            lblCombinationOrder.Location = new System.Drawing.Point(10, 125);
            lblCombinationOrder.Name = "lblCombinationOrder";
            lblCombinationOrder.Size = new System.Drawing.Size(40, 15);
            lblCombinationOrder.TabIndex = 29;
            lblCombinationOrder.Text = "Order:";
            // 
            // pnlDictionary
            // 
            pnlDictionary.Controls.Add(grpSizeFiltering);
            pnlDictionary.Controls.Add(grpWordFiltering);
            pnlDictionary.Controls.Add(grpAdvanced);
            pnlDictionary.Controls.Add(grpTypos);
            pnlDictionary.Controls.Add(pnlDictBruteforce);
            pnlDictionary.Location = new System.Drawing.Point(12, 104);
            pnlDictionary.Name = "pnlDictionary";
            pnlDictionary.Size = new System.Drawing.Size(827, 586);
            pnlDictionary.TabIndex = 31;
            // 
            // grpSizeFiltering
            // 
            grpSizeFiltering.Controls.Add(cbMaxFours);
            grpSizeFiltering.Controls.Add(cbMaxThrees);
            grpSizeFiltering.Controls.Add(cbMaxTwos);
            grpSizeFiltering.Controls.Add(cbAtMostUnderNbrChars);
            grpSizeFiltering.Controls.Add(cbAtMostAboveNbrChars);
            grpSizeFiltering.Controls.Add(cbAtMostUnderNbrWords);
            grpSizeFiltering.Controls.Add(cbAtMostAboveNbrWords);
            grpSizeFiltering.Controls.Add(lblAtMostUnder);
            grpSizeFiltering.Controls.Add(lblAtMostAbove);
            grpSizeFiltering.Controls.Add(cbAtLeastUnderNbrChars);
            grpSizeFiltering.Controls.Add(cbAtLeastUnderNbrWords);
            grpSizeFiltering.Controls.Add(lblAtLeastUnder);
            grpSizeFiltering.Controls.Add(cbAtLeastAboveNbrChars);
            grpSizeFiltering.Controls.Add(cbAtLeastAboveNbrWords);
            grpSizeFiltering.Controls.Add(lblAtLeastAbove);
            grpSizeFiltering.Controls.Add(cbMinFours);
            grpSizeFiltering.Controls.Add(lblToFours);
            grpSizeFiltering.Controls.Add(lblFours);
            grpSizeFiltering.Controls.Add(cbMinThrees);
            grpSizeFiltering.Controls.Add(lblToThrees);
            grpSizeFiltering.Controls.Add(lblThrees);
            grpSizeFiltering.Controls.Add(cbMinTwos);
            grpSizeFiltering.Controls.Add(lblToTwos);
            grpSizeFiltering.Controls.Add(lblTwos);
            grpSizeFiltering.Controls.Add(lblMaxDelim);
            grpSizeFiltering.Controls.Add(lblOnes);
            grpSizeFiltering.Controls.Add(cbMinWordLength);
            grpSizeFiltering.Controls.Add(cbMaxOnes);
            grpSizeFiltering.Controls.Add(lblMinWordLength);
            grpSizeFiltering.Controls.Add(lblToOnes);
            grpSizeFiltering.Controls.Add(cbMaxWordLength);
            grpSizeFiltering.Controls.Add(cbMaxDelim);
            grpSizeFiltering.Controls.Add(cbMinOnes);
            grpSizeFiltering.Controls.Add(lblMaxWordLength);
            grpSizeFiltering.Controls.Add(lblMinDelim);
            grpSizeFiltering.Controls.Add(cbMinDelim);
            grpSizeFiltering.Location = new System.Drawing.Point(7, 164);
            grpSizeFiltering.Margin = new System.Windows.Forms.Padding(2);
            grpSizeFiltering.Name = "grpSizeFiltering";
            grpSizeFiltering.Padding = new System.Windows.Forms.Padding(2);
            grpSizeFiltering.Size = new System.Drawing.Size(364, 182);
            grpSizeFiltering.TabIndex = 86;
            grpSizeFiltering.TabStop = false;
            grpSizeFiltering.Text = "Size Filtering";
            // 
            // cbMaxFours
            // 
            cbMaxFours.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbMaxFours.FormattingEnabled = true;
            cbMaxFours.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" });
            cbMaxFours.Location = new System.Drawing.Point(137, 153);
            cbMaxFours.Name = "cbMaxFours";
            cbMaxFours.Size = new System.Drawing.Size(38, 23);
            cbMaxFours.TabIndex = 82;
            // 
            // cbMaxThrees
            // 
            cbMaxThrees.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbMaxThrees.FormattingEnabled = true;
            cbMaxThrees.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" });
            cbMaxThrees.Location = new System.Drawing.Point(137, 127);
            cbMaxThrees.Name = "cbMaxThrees";
            cbMaxThrees.Size = new System.Drawing.Size(38, 23);
            cbMaxThrees.TabIndex = 78;
            // 
            // cbMaxTwos
            // 
            cbMaxTwos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbMaxTwos.FormattingEnabled = true;
            cbMaxTwos.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" });
            cbMaxTwos.Location = new System.Drawing.Point(137, 101);
            cbMaxTwos.Name = "cbMaxTwos";
            cbMaxTwos.Size = new System.Drawing.Size(38, 23);
            cbMaxTwos.TabIndex = 74;
            // 
            // cbAtMostUnderNbrChars
            // 
            cbAtMostUnderNbrChars.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbAtMostUnderNbrChars.DropDownWidth = 110;
            cbAtMostUnderNbrChars.FormattingEnabled = true;
            cbAtMostUnderNbrChars.Items.AddRange(new object[] { "0 character", "1 character", "2 characters", "3 characters", "4 characters", "5 characters", "6 characters", "7 characters", "8 characters", "9 characters", "10 characters" });
            cbAtMostUnderNbrChars.Location = new System.Drawing.Point(306, 153);
            cbAtMostUnderNbrChars.Name = "cbAtMostUnderNbrChars";
            cbAtMostUnderNbrChars.Size = new System.Drawing.Size(45, 23);
            cbAtMostUnderNbrChars.TabIndex = 98;
            // 
            // cbAtMostAboveNbrChars
            // 
            cbAtMostAboveNbrChars.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbAtMostAboveNbrChars.DropDownWidth = 110;
            cbAtMostAboveNbrChars.FormattingEnabled = true;
            cbAtMostAboveNbrChars.Items.AddRange(new object[] { "0 character", "1 character", "2 characters", "3 characters", "4 characters", "5 characters", "6 characters", "7 characters", "8 characters", "9 characters", "10 characters" });
            cbAtMostAboveNbrChars.Location = new System.Drawing.Point(306, 127);
            cbAtMostAboveNbrChars.Name = "cbAtMostAboveNbrChars";
            cbAtMostAboveNbrChars.Size = new System.Drawing.Size(45, 23);
            cbAtMostAboveNbrChars.TabIndex = 97;
            // 
            // cbAtMostUnderNbrWords
            // 
            cbAtMostUnderNbrWords.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbAtMostUnderNbrWords.DropDownWidth = 80;
            cbAtMostUnderNbrWords.FormattingEnabled = true;
            cbAtMostUnderNbrWords.Items.AddRange(new object[] { "0 word", "1 word", "2 words", "3 words", "4 words", "5 words", "6 words", "7 words", "8 words", "9 words", "10 words" });
            cbAtMostUnderNbrWords.Location = new System.Drawing.Point(227, 153);
            cbAtMostUnderNbrWords.Name = "cbAtMostUnderNbrWords";
            cbAtMostUnderNbrWords.Size = new System.Drawing.Size(45, 23);
            cbAtMostUnderNbrWords.TabIndex = 96;
            // 
            // cbAtMostAboveNbrWords
            // 
            cbAtMostAboveNbrWords.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbAtMostAboveNbrWords.DropDownWidth = 80;
            cbAtMostAboveNbrWords.FormattingEnabled = true;
            cbAtMostAboveNbrWords.Items.AddRange(new object[] { "0 word", "1 word", "2 words", "3 words", "4 words", "5 words", "6 words", "7 words", "8 words", "9 words", "10 words" });
            cbAtMostAboveNbrWords.Location = new System.Drawing.Point(228, 127);
            cbAtMostAboveNbrWords.Name = "cbAtMostAboveNbrWords";
            cbAtMostAboveNbrWords.Size = new System.Drawing.Size(45, 23);
            cbAtMostAboveNbrWords.TabIndex = 95;
            // 
            // lblAtMostUnder
            // 
            lblAtMostUnder.AutoSize = true;
            lblAtMostUnder.Location = new System.Drawing.Point(188, 157);
            lblAtMostUnder.Name = "lblAtMostUnder";
            lblAtMostUnder.Size = new System.Drawing.Size(105, 15);
            lblAtMostUnder.TabIndex = 94;
            lblAtMostUnder.Text = "At most                ≤";
            // 
            // lblAtMostAbove
            // 
            lblAtMostAbove.AutoSize = true;
            lblAtMostAbove.Location = new System.Drawing.Point(188, 130);
            lblAtMostAbove.Name = "lblAtMostAbove";
            lblAtMostAbove.Size = new System.Drawing.Size(105, 15);
            lblAtMostAbove.TabIndex = 93;
            lblAtMostAbove.Text = "At most                ≥";
            // 
            // cbAtLeastUnderNbrChars
            // 
            cbAtLeastUnderNbrChars.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbAtLeastUnderNbrChars.DropDownWidth = 110;
            cbAtLeastUnderNbrChars.FormattingEnabled = true;
            cbAtLeastUnderNbrChars.Items.AddRange(new object[] { "0 character", "1 character", "2 characters", "3 characters", "4 characters", "5 characters", "6 characters", "7 characters", "8 characters", "9 characters", "10 characters" });
            cbAtLeastUnderNbrChars.Location = new System.Drawing.Point(306, 101);
            cbAtLeastUnderNbrChars.Name = "cbAtLeastUnderNbrChars";
            cbAtLeastUnderNbrChars.Size = new System.Drawing.Size(45, 23);
            cbAtLeastUnderNbrChars.TabIndex = 92;
            // 
            // cbAtLeastUnderNbrWords
            // 
            cbAtLeastUnderNbrWords.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbAtLeastUnderNbrWords.DropDownWidth = 80;
            cbAtLeastUnderNbrWords.FormattingEnabled = true;
            cbAtLeastUnderNbrWords.Items.AddRange(new object[] { "0 word", "1 word", "2 words", "3 words", "4 words", "5 words", "6 words", "7 words", "8 words", "9 words", "10 words" });
            cbAtLeastUnderNbrWords.Location = new System.Drawing.Point(232, 101);
            cbAtLeastUnderNbrWords.Name = "cbAtLeastUnderNbrWords";
            cbAtLeastUnderNbrWords.Size = new System.Drawing.Size(45, 23);
            cbAtLeastUnderNbrWords.TabIndex = 87;
            // 
            // lblAtLeastUnder
            // 
            lblAtLeastUnder.AutoSize = true;
            lblAtLeastUnder.Location = new System.Drawing.Point(188, 104);
            lblAtLeastUnder.Name = "lblAtLeastUnder";
            lblAtLeastUnder.Size = new System.Drawing.Size(105, 15);
            lblAtLeastUnder.TabIndex = 90;
            lblAtLeastUnder.Text = "At least                 ≤";
            // 
            // cbAtLeastAboveNbrChars
            // 
            cbAtLeastAboveNbrChars.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbAtLeastAboveNbrChars.DropDownWidth = 110;
            cbAtLeastAboveNbrChars.FormattingEnabled = true;
            cbAtLeastAboveNbrChars.Items.AddRange(new object[] { "0 character", "1 character", "2 characters", "3 characters", "4 characters", "5 characters", "6 characters", "7 characters", "8 characters", "9 characters", "10 characters" });
            cbAtLeastAboveNbrChars.Location = new System.Drawing.Point(306, 75);
            cbAtLeastAboveNbrChars.Name = "cbAtLeastAboveNbrChars";
            cbAtLeastAboveNbrChars.Size = new System.Drawing.Size(45, 23);
            cbAtLeastAboveNbrChars.TabIndex = 89;
            // 
            // cbAtLeastAboveNbrWords
            // 
            cbAtLeastAboveNbrWords.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbAtLeastAboveNbrWords.DropDownWidth = 80;
            cbAtLeastAboveNbrWords.FormattingEnabled = true;
            cbAtLeastAboveNbrWords.Items.AddRange(new object[] { "0 word", "1 word", "2 words", "3 words", "4 words", "5 words", "6 words", "7 words", "8 words", "9 words", "10 words" });
            cbAtLeastAboveNbrWords.Location = new System.Drawing.Point(223, 75);
            cbAtLeastAboveNbrWords.Name = "cbAtLeastAboveNbrWords";
            cbAtLeastAboveNbrWords.Size = new System.Drawing.Size(45, 23);
            cbAtLeastAboveNbrWords.TabIndex = 86;
            // 
            // lblAtLeastAbove
            // 
            lblAtLeastAbove.AutoSize = true;
            lblAtLeastAbove.Location = new System.Drawing.Point(188, 78);
            lblAtLeastAbove.Name = "lblAtLeastAbove";
            lblAtLeastAbove.Size = new System.Drawing.Size(105, 15);
            lblAtLeastAbove.TabIndex = 85;
            lblAtLeastAbove.Text = "At least                 ≥";
            // 
            // cbMinFours
            // 
            cbMinFours.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbMinFours.FormattingEnabled = true;
            cbMinFours.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" });
            cbMinFours.Location = new System.Drawing.Point(79, 153);
            cbMinFours.Name = "cbMinFours";
            cbMinFours.Size = new System.Drawing.Size(38, 23);
            cbMinFours.TabIndex = 84;
            // 
            // lblToFours
            // 
            lblToFours.AutoSize = true;
            lblToFours.Location = new System.Drawing.Point(118, 157);
            lblToFours.Name = "lblToFours";
            lblToFours.Size = new System.Drawing.Size(18, 15);
            lblToFours.TabIndex = 83;
            lblToFours.Text = "to";
            // 
            // lblFours
            // 
            lblFours.AutoSize = true;
            lblFours.Location = new System.Drawing.Point(13, 156);
            lblFours.Name = "lblFours";
            lblFours.Size = new System.Drawing.Size(42, 15);
            lblFours.TabIndex = 81;
            lblFours.Text = "Fours :";
            // 
            // cbMinThrees
            // 
            cbMinThrees.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbMinThrees.FormattingEnabled = true;
            cbMinThrees.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" });
            cbMinThrees.Location = new System.Drawing.Point(79, 127);
            cbMinThrees.Name = "cbMinThrees";
            cbMinThrees.Size = new System.Drawing.Size(38, 23);
            cbMinThrees.TabIndex = 80;
            // 
            // lblToThrees
            // 
            lblToThrees.AutoSize = true;
            lblToThrees.Location = new System.Drawing.Point(118, 131);
            lblToThrees.Name = "lblToThrees";
            lblToThrees.Size = new System.Drawing.Size(18, 15);
            lblToThrees.TabIndex = 79;
            lblToThrees.Text = "to";
            // 
            // lblThrees
            // 
            lblThrees.AutoSize = true;
            lblThrees.Location = new System.Drawing.Point(13, 130);
            lblThrees.Name = "lblThrees";
            lblThrees.Size = new System.Drawing.Size(47, 15);
            lblThrees.TabIndex = 77;
            lblThrees.Text = "Threes :";
            // 
            // cbMinTwos
            // 
            cbMinTwos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbMinTwos.FormattingEnabled = true;
            cbMinTwos.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" });
            cbMinTwos.Location = new System.Drawing.Point(79, 101);
            cbMinTwos.Name = "cbMinTwos";
            cbMinTwos.Size = new System.Drawing.Size(38, 23);
            cbMinTwos.TabIndex = 76;
            // 
            // lblToTwos
            // 
            lblToTwos.AutoSize = true;
            lblToTwos.Location = new System.Drawing.Point(118, 103);
            lblToTwos.Name = "lblToTwos";
            lblToTwos.Size = new System.Drawing.Size(18, 15);
            lblToTwos.TabIndex = 75;
            lblToTwos.Text = "to";
            // 
            // lblTwos
            // 
            lblTwos.AutoSize = true;
            lblTwos.Location = new System.Drawing.Point(13, 103);
            lblTwos.Name = "lblTwos";
            lblTwos.Size = new System.Drawing.Size(39, 15);
            lblTwos.TabIndex = 73;
            lblTwos.Text = "Twos :";
            // 
            // lblMaxDelim
            // 
            lblMaxDelim.AutoSize = true;
            lblMaxDelim.Location = new System.Drawing.Point(13, 24);
            lblMaxDelim.Name = "lblMaxDelim";
            lblMaxDelim.Size = new System.Drawing.Size(89, 15);
            lblMaxDelim.TabIndex = 57;
            lblMaxDelim.Text = "Max Delimiters:";
            // 
            // lblOnes
            // 
            lblOnes.AutoSize = true;
            lblOnes.Location = new System.Drawing.Point(13, 78);
            lblOnes.Name = "lblOnes";
            lblOnes.Size = new System.Drawing.Size(40, 15);
            lblOnes.TabIndex = 69;
            lblOnes.Text = "Ones :";
            // 
            // cbMinWordLength
            // 
            cbMinWordLength.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbMinWordLength.FormattingEnabled = true;
            cbMinWordLength.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" });
            cbMinWordLength.Location = new System.Drawing.Point(313, 47);
            cbMinWordLength.Name = "cbMinWordLength";
            cbMinWordLength.Size = new System.Drawing.Size(38, 23);
            cbMinWordLength.TabIndex = 68;
            // 
            // cbMaxOnes
            // 
            cbMaxOnes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbMaxOnes.FormattingEnabled = true;
            cbMaxOnes.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" });
            cbMaxOnes.Location = new System.Drawing.Point(137, 75);
            cbMaxOnes.Name = "cbMaxOnes";
            cbMaxOnes.Size = new System.Drawing.Size(38, 23);
            cbMaxOnes.TabIndex = 70;
            // 
            // lblMinWordLength
            // 
            lblMinWordLength.AutoSize = true;
            lblMinWordLength.Location = new System.Drawing.Point(188, 50);
            lblMinWordLength.Name = "lblMinWordLength";
            lblMinWordLength.Size = new System.Drawing.Size(106, 15);
            lblMinWordLength.TabIndex = 67;
            lblMinWordLength.Text = "Min Word Length :";
            // 
            // lblToOnes
            // 
            lblToOnes.AutoSize = true;
            lblToOnes.Location = new System.Drawing.Point(118, 78);
            lblToOnes.Name = "lblToOnes";
            lblToOnes.Size = new System.Drawing.Size(18, 15);
            lblToOnes.TabIndex = 71;
            lblToOnes.Text = "to";
            // 
            // cbMaxWordLength
            // 
            cbMaxWordLength.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbMaxWordLength.FormattingEnabled = true;
            cbMaxWordLength.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50" });
            cbMaxWordLength.Location = new System.Drawing.Point(137, 49);
            cbMaxWordLength.Name = "cbMaxWordLength";
            cbMaxWordLength.Size = new System.Drawing.Size(38, 23);
            cbMaxWordLength.TabIndex = 66;
            // 
            // cbMaxDelim
            // 
            cbMaxDelim.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbMaxDelim.FormattingEnabled = true;
            cbMaxDelim.Items.AddRange(new object[] { "-1", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" });
            cbMaxDelim.Location = new System.Drawing.Point(137, 22);
            cbMaxDelim.Name = "cbMaxDelim";
            cbMaxDelim.Size = new System.Drawing.Size(38, 23);
            cbMaxDelim.TabIndex = 58;
            // 
            // cbMinOnes
            // 
            cbMinOnes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbMinOnes.FormattingEnabled = true;
            cbMinOnes.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" });
            cbMinOnes.Location = new System.Drawing.Point(79, 75);
            cbMinOnes.Name = "cbMinOnes";
            cbMinOnes.Size = new System.Drawing.Size(38, 23);
            cbMinOnes.TabIndex = 72;
            // 
            // lblMaxWordLength
            // 
            lblMaxWordLength.AutoSize = true;
            lblMaxWordLength.Location = new System.Drawing.Point(13, 52);
            lblMaxWordLength.Name = "lblMaxWordLength";
            lblMaxWordLength.Size = new System.Drawing.Size(108, 15);
            lblMaxWordLength.TabIndex = 65;
            lblMaxWordLength.Text = "Max Word Length :";
            // 
            // lblMinDelim
            // 
            lblMinDelim.AutoSize = true;
            lblMinDelim.Location = new System.Drawing.Point(188, 24);
            lblMinDelim.Name = "lblMinDelim";
            lblMinDelim.Size = new System.Drawing.Size(87, 15);
            lblMinDelim.TabIndex = 59;
            lblMinDelim.Text = "Min Delimiters:";
            // 
            // cbMinDelim
            // 
            cbMinDelim.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbMinDelim.FormattingEnabled = true;
            cbMinDelim.Items.AddRange(new object[] { "-1", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" });
            cbMinDelim.Location = new System.Drawing.Point(313, 21);
            cbMinDelim.Name = "cbMinDelim";
            cbMinDelim.Size = new System.Drawing.Size(38, 23);
            cbMinDelim.TabIndex = 60;
            // 
            // grpWordFiltering
            // 
            grpWordFiltering.Controls.Add(cbIncludePatternsSamples);
            grpWordFiltering.Controls.Add(cbExcludePatternsSamples);
            grpWordFiltering.Controls.Add(lblExcludePatterns);
            grpWordFiltering.Controls.Add(txtExcludePatterns);
            grpWordFiltering.Controls.Add(lblIncludePatterns);
            grpWordFiltering.Controls.Add(txtIncludePatterns);
            grpWordFiltering.Controls.Add(cbCombinationOrder);
            grpWordFiltering.Controls.Add(chkIncludeWordNotLast);
            grpWordFiltering.Controls.Add(lblCombinationOrder);
            grpWordFiltering.Controls.Add(cbWordsLimit);
            grpWordFiltering.Controls.Add(lblIncludeWord);
            grpWordFiltering.Controls.Add(lblWordsLimit);
            grpWordFiltering.Controls.Add(chkIncludeWordNotFirst);
            grpWordFiltering.Controls.Add(txtIncludeWord);
            grpWordFiltering.Location = new System.Drawing.Point(7, 4);
            grpWordFiltering.Margin = new System.Windows.Forms.Padding(2);
            grpWordFiltering.Name = "grpWordFiltering";
            grpWordFiltering.Padding = new System.Windows.Forms.Padding(2);
            grpWordFiltering.Size = new System.Drawing.Size(364, 155);
            grpWordFiltering.TabIndex = 85;
            grpWordFiltering.TabStop = false;
            grpWordFiltering.Text = "Word Filtering";
            // 
            // cbIncludePatternsSamples
            // 
            cbIncludePatternsSamples.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbIncludePatternsSamples.DropDownWidth = 500;
            cbIncludePatternsSamples.FormattingEnabled = true;
            cbIncludePatternsSamples.Location = new System.Drawing.Point(314, 49);
            cbIncludePatternsSamples.Name = "cbIncludePatternsSamples";
            cbIncludePatternsSamples.Size = new System.Drawing.Size(38, 23);
            cbIncludePatternsSamples.TabIndex = 57;
            cbIncludePatternsSamples.SelectedIndexChanged += cbIncludePatternsSamples_SelectedIndexChanged;
            // 
            // cbExcludePatternsSamples
            // 
            cbExcludePatternsSamples.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbExcludePatternsSamples.DropDownWidth = 500;
            cbExcludePatternsSamples.FormattingEnabled = true;
            cbExcludePatternsSamples.Location = new System.Drawing.Point(314, 20);
            cbExcludePatternsSamples.Name = "cbExcludePatternsSamples";
            cbExcludePatternsSamples.Size = new System.Drawing.Size(38, 23);
            cbExcludePatternsSamples.TabIndex = 56;
            cbExcludePatternsSamples.SelectedIndexChanged += cbExcludePatternsSamples_SelectedIndexChanged;
            // 
            // cbCombinationOrder
            // 
            cbCombinationOrder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbCombinationOrder.FormattingEnabled = true;
            cbCombinationOrder.Items.AddRange(new object[] { "Interval short/long", "Interval long/short", "Fewer/shorter words first", "Fewer/longer words first", "Greater/shorter words first", "Greater/longer words first" });
            cbCombinationOrder.Location = new System.Drawing.Point(121, 122);
            cbCombinationOrder.Name = "cbCombinationOrder";
            cbCombinationOrder.Size = new System.Drawing.Size(112, 23);
            cbCombinationOrder.TabIndex = 30;
            // 
            // chkIncludeWordNotLast
            // 
            chkIncludeWordNotLast.AutoSize = true;
            chkIncludeWordNotLast.Location = new System.Drawing.Point(250, 97);
            chkIncludeWordNotLast.Name = "chkIncludeWordNotLast";
            chkIncludeWordNotLast.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            chkIncludeWordNotLast.Size = new System.Drawing.Size(97, 19);
            chkIncludeWordNotLast.TabIndex = 55;
            chkIncludeWordNotLast.Text = "Not last word";
            chkIncludeWordNotLast.UseVisualStyleBackColor = true;
            // 
            // chkIncludeWordNotFirst
            // 
            chkIncludeWordNotFirst.AutoSize = true;
            chkIncludeWordNotFirst.Location = new System.Drawing.Point(253, 74);
            chkIncludeWordNotFirst.Name = "chkIncludeWordNotFirst";
            chkIncludeWordNotFirst.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            chkIncludeWordNotFirst.Size = new System.Drawing.Size(94, 19);
            chkIncludeWordNotFirst.TabIndex = 37;
            chkIncludeWordNotFirst.Text = "Not 1st word";
            chkIncludeWordNotFirst.UseVisualStyleBackColor = true;
            // 
            // grpAdvanced
            // 
            grpAdvanced.Controls.Add(cbMinConcatWords);
            grpAdvanced.Controls.Add(cbMaxConcatWords);
            grpAdvanced.Controls.Add(lblMinConcatWords);
            grpAdvanced.Controls.Add(lblMaxConcatWords);
            grpAdvanced.Controls.Add(chkDictionaryAdvanced);
            grpAdvanced.Controls.Add(lblOnlyLastTwoWordsConcat);
            grpAdvanced.Controls.Add(chkOnlyLastTwoWordsConcat);
            grpAdvanced.Controls.Add(lblOnlyFirstTwoWordsConcat);
            grpAdvanced.Controls.Add(chkOnlyFirstTwoWordsConcat);
            grpAdvanced.Controls.Add(lblMaxConsecutiveConcat);
            grpAdvanced.Controls.Add(cbMinWordsLimit);
            grpAdvanced.Controls.Add(cbMaxConsecutiveConcat);
            grpAdvanced.Controls.Add(lblMinWordsLimit);
            grpAdvanced.Controls.Add(lblMinConsecutiveConcat);
            grpAdvanced.Controls.Add(cbMaxConsecutiveOnes);
            grpAdvanced.Controls.Add(cbMinConsecutiveConcat);
            grpAdvanced.Controls.Add(lblMaxConsecutiveOnes);
            grpAdvanced.Location = new System.Drawing.Point(7, 351);
            grpAdvanced.Name = "grpAdvanced";
            grpAdvanced.Size = new System.Drawing.Size(364, 131);
            grpAdvanced.TabIndex = 81;
            grpAdvanced.TabStop = false;
            grpAdvanced.Text = "      Advanced Attack";
            // 
            // cbMinConcatWords
            // 
            cbMinConcatWords.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbMinConcatWords.FormattingEnabled = true;
            cbMinConcatWords.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" });
            cbMinConcatWords.Location = new System.Drawing.Point(312, 23);
            cbMinConcatWords.Name = "cbMinConcatWords";
            cbMinConcatWords.Size = new System.Drawing.Size(38, 23);
            cbMinConcatWords.TabIndex = 82;
            // 
            // cbMaxConcatWords
            // 
            cbMaxConcatWords.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbMaxConcatWords.FormattingEnabled = true;
            cbMaxConcatWords.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" });
            cbMaxConcatWords.Location = new System.Drawing.Point(128, 23);
            cbMaxConcatWords.Name = "cbMaxConcatWords";
            cbMaxConcatWords.Size = new System.Drawing.Size(38, 23);
            cbMaxConcatWords.TabIndex = 81;
            // 
            // lblMinConcatWords
            // 
            lblMinConcatWords.AutoSize = true;
            lblMinConcatWords.Location = new System.Drawing.Point(194, 25);
            lblMinConcatWords.Name = "lblMinConcatWords";
            lblMinConcatWords.Size = new System.Drawing.Size(112, 15);
            lblMinConcatWords.TabIndex = 80;
            lblMinConcatWords.Text = "Min Concat. Words:";
            // 
            // lblMaxConcatWords
            // 
            lblMaxConcatWords.AutoSize = true;
            lblMaxConcatWords.Location = new System.Drawing.Point(4, 25);
            lblMaxConcatWords.Name = "lblMaxConcatWords";
            lblMaxConcatWords.Size = new System.Drawing.Size(114, 15);
            lblMaxConcatWords.TabIndex = 79;
            lblMaxConcatWords.Text = "Max Concat. Words:";
            // 
            // chkDictionaryAdvanced
            // 
            chkDictionaryAdvanced.AutoSize = true;
            chkDictionaryAdvanced.Location = new System.Drawing.Point(9, 1);
            chkDictionaryAdvanced.Name = "chkDictionaryAdvanced";
            chkDictionaryAdvanced.Size = new System.Drawing.Size(15, 14);
            chkDictionaryAdvanced.TabIndex = 56;
            chkDictionaryAdvanced.UseVisualStyleBackColor = true;
            chkDictionaryAdvanced.CheckedChanged += OnDictionaryAdvancedCheckedChanged;
            // 
            // lblOnlyLastTwoWordsConcat
            // 
            lblOnlyLastTwoWordsConcat.AutoSize = true;
            lblOnlyLastTwoWordsConcat.Location = new System.Drawing.Point(193, 106);
            lblOnlyLastTwoWordsConcat.Name = "lblOnlyLastTwoWordsConcat";
            lblOnlyLastTwoWordsConcat.Size = new System.Drawing.Size(124, 15);
            lblOnlyLastTwoWordsConcat.TabIndex = 78;
            lblOnlyLastTwoWordsConcat.Text = "Last 2 Words Concat. :";
            // 
            // chkOnlyLastTwoWordsConcat
            // 
            chkOnlyLastTwoWordsConcat.AutoSize = true;
            chkOnlyLastTwoWordsConcat.Checked = true;
            chkOnlyLastTwoWordsConcat.CheckState = System.Windows.Forms.CheckState.Checked;
            chkOnlyLastTwoWordsConcat.Location = new System.Drawing.Point(335, 107);
            chkOnlyLastTwoWordsConcat.Name = "chkOnlyLastTwoWordsConcat";
            chkOnlyLastTwoWordsConcat.Size = new System.Drawing.Size(15, 14);
            chkOnlyLastTwoWordsConcat.TabIndex = 77;
            chkOnlyLastTwoWordsConcat.UseVisualStyleBackColor = true;
            // 
            // lblOnlyFirstTwoWordsConcat
            // 
            lblOnlyFirstTwoWordsConcat.AutoSize = true;
            lblOnlyFirstTwoWordsConcat.Location = new System.Drawing.Point(4, 106);
            lblOnlyFirstTwoWordsConcat.Name = "lblOnlyFirstTwoWordsConcat";
            lblOnlyFirstTwoWordsConcat.Size = new System.Drawing.Size(125, 15);
            lblOnlyFirstTwoWordsConcat.TabIndex = 38;
            lblOnlyFirstTwoWordsConcat.Text = "First 2 Words Concat. :";
            // 
            // chkOnlyFirstTwoWordsConcat
            // 
            chkOnlyFirstTwoWordsConcat.AutoSize = true;
            chkOnlyFirstTwoWordsConcat.Checked = true;
            chkOnlyFirstTwoWordsConcat.CheckState = System.Windows.Forms.CheckState.Checked;
            chkOnlyFirstTwoWordsConcat.Location = new System.Drawing.Point(151, 107);
            chkOnlyFirstTwoWordsConcat.Name = "chkOnlyFirstTwoWordsConcat";
            chkOnlyFirstTwoWordsConcat.Size = new System.Drawing.Size(15, 14);
            chkOnlyFirstTwoWordsConcat.TabIndex = 37;
            chkOnlyFirstTwoWordsConcat.UseVisualStyleBackColor = true;
            // 
            // lblMaxConsecutiveConcat
            // 
            lblMaxConsecutiveConcat.AutoSize = true;
            lblMaxConsecutiveConcat.Location = new System.Drawing.Point(4, 51);
            lblMaxConsecutiveConcat.Name = "lblMaxConsecutiveConcat";
            lblMaxConsecutiveConcat.Size = new System.Drawing.Size(113, 15);
            lblMaxConsecutiveConcat.TabIndex = 61;
            lblMaxConsecutiveConcat.Text = "Max Cons. Concat. :";
            // 
            // cbMinWordsLimit
            // 
            cbMinWordsLimit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbMinWordsLimit.FormattingEnabled = true;
            cbMinWordsLimit.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" });
            cbMinWordsLimit.Location = new System.Drawing.Point(312, 76);
            cbMinWordsLimit.Name = "cbMinWordsLimit";
            cbMinWordsLimit.Size = new System.Drawing.Size(38, 23);
            cbMinWordsLimit.TabIndex = 76;
            // 
            // cbMaxConsecutiveConcat
            // 
            cbMaxConsecutiveConcat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbMaxConsecutiveConcat.FormattingEnabled = true;
            cbMaxConsecutiveConcat.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" });
            cbMaxConsecutiveConcat.Location = new System.Drawing.Point(128, 50);
            cbMaxConsecutiveConcat.Name = "cbMaxConsecutiveConcat";
            cbMaxConsecutiveConcat.Size = new System.Drawing.Size(38, 23);
            cbMaxConsecutiveConcat.TabIndex = 62;
            // 
            // lblMinWordsLimit
            // 
            lblMinWordsLimit.AutoSize = true;
            lblMinWordsLimit.Location = new System.Drawing.Point(194, 79);
            lblMinWordsLimit.Name = "lblMinWordsLimit";
            lblMinWordsLimit.Size = new System.Drawing.Size(98, 15);
            lblMinWordsLimit.TabIndex = 75;
            lblMinWordsLimit.Text = "Min Words Limit:";
            // 
            // lblMinConsecutiveConcat
            // 
            lblMinConsecutiveConcat.AutoSize = true;
            lblMinConsecutiveConcat.Location = new System.Drawing.Point(194, 51);
            lblMinConsecutiveConcat.Name = "lblMinConsecutiveConcat";
            lblMinConsecutiveConcat.Size = new System.Drawing.Size(111, 15);
            lblMinConsecutiveConcat.TabIndex = 63;
            lblMinConsecutiveConcat.Text = "Min Cons. Concat. :";
            // 
            // cbMaxConsecutiveOnes
            // 
            cbMaxConsecutiveOnes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbMaxConsecutiveOnes.FormattingEnabled = true;
            cbMaxConsecutiveOnes.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" });
            cbMaxConsecutiveOnes.Location = new System.Drawing.Point(128, 76);
            cbMaxConsecutiveOnes.Name = "cbMaxConsecutiveOnes";
            cbMaxConsecutiveOnes.Size = new System.Drawing.Size(38, 23);
            cbMaxConsecutiveOnes.TabIndex = 74;
            // 
            // cbMinConsecutiveConcat
            // 
            cbMinConsecutiveConcat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbMinConsecutiveConcat.FormattingEnabled = true;
            cbMinConsecutiveConcat.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" });
            cbMinConsecutiveConcat.Location = new System.Drawing.Point(312, 50);
            cbMinConsecutiveConcat.Name = "cbMinConsecutiveConcat";
            cbMinConsecutiveConcat.Size = new System.Drawing.Size(38, 23);
            cbMinConsecutiveConcat.TabIndex = 64;
            // 
            // lblMaxConsecutiveOnes
            // 
            lblMaxConsecutiveOnes.AutoSize = true;
            lblMaxConsecutiveOnes.Location = new System.Drawing.Point(4, 79);
            lblMaxConsecutiveOnes.Name = "lblMaxConsecutiveOnes";
            lblMaxConsecutiveOnes.Size = new System.Drawing.Size(99, 15);
            lblMaxConsecutiveOnes.TabIndex = 73;
            lblMaxConsecutiveOnes.Text = "Max Cons. Ones :";
            // 
            // grpTypos
            // 
            grpTypos.Controls.Add(txtTyposAppendLetters);
            grpTypos.Controls.Add(lblTyposAppendLetters);
            grpTypos.Controls.Add(txtTyposSwapLetters);
            grpTypos.Controls.Add(lblTyposSwapLetters);
            grpTypos.Controls.Add(chkTyposReverseLetter);
            grpTypos.Controls.Add(chkTyposWrongLetter);
            grpTypos.Controls.Add(chkTyposExtraLetter);
            grpTypos.Controls.Add(chkTyposDoubleLetter);
            grpTypos.Controls.Add(chkTyposSkipLetter);
            grpTypos.Controls.Add(chkTyposSkipDoubleLetter);
            grpTypos.Location = new System.Drawing.Point(7, 487);
            grpTypos.Name = "grpTypos";
            grpTypos.Size = new System.Drawing.Size(363, 95);
            grpTypos.TabIndex = 80;
            grpTypos.TabStop = false;
            grpTypos.Text = "Typos";
            // 
            // txtTyposAppendLetters
            // 
            txtTyposAppendLetters.Location = new System.Drawing.Point(274, 66);
            txtTyposAppendLetters.Name = "txtTyposAppendLetters";
            txtTyposAppendLetters.PlaceholderText = "s,ed";
            txtTyposAppendLetters.Size = new System.Drawing.Size(77, 23);
            txtTyposAppendLetters.TabIndex = 88;
            // 
            // lblTyposAppendLetters
            // 
            lblTyposAppendLetters.AutoSize = true;
            lblTyposAppendLetters.Location = new System.Drawing.Point(183, 70);
            lblTyposAppendLetters.Name = "lblTyposAppendLetters";
            lblTyposAppendLetters.Size = new System.Drawing.Size(85, 15);
            lblTyposAppendLetters.TabIndex = 87;
            lblTyposAppendLetters.Text = "Append Letter:";
            // 
            // txtTyposSwapLetters
            // 
            txtTyposSwapLetters.Location = new System.Drawing.Point(88, 67);
            txtTyposSwapLetters.Name = "txtTyposSwapLetters";
            txtTyposSwapLetters.PlaceholderText = "l-r,a-e,i-y";
            txtTyposSwapLetters.Size = new System.Drawing.Size(77, 23);
            txtTyposSwapLetters.TabIndex = 86;
            // 
            // lblTyposSwapLetters
            // 
            lblTyposSwapLetters.AutoSize = true;
            lblTyposSwapLetters.Location = new System.Drawing.Point(12, 70);
            lblTyposSwapLetters.Name = "lblTyposSwapLetters";
            lblTyposSwapLetters.Size = new System.Drawing.Size(70, 15);
            lblTyposSwapLetters.TabIndex = 85;
            lblTyposSwapLetters.Text = "Letter swap:";
            // 
            // chkTyposReverseLetter
            // 
            chkTyposReverseLetter.AutoSize = true;
            chkTyposReverseLetter.Checked = true;
            chkTyposReverseLetter.CheckState = System.Windows.Forms.CheckState.Checked;
            chkTyposReverseLetter.Location = new System.Drawing.Point(121, 21);
            chkTyposReverseLetter.Name = "chkTyposReverseLetter";
            chkTyposReverseLetter.Size = new System.Drawing.Size(99, 19);
            chkTyposReverseLetter.TabIndex = 84;
            chkTyposReverseLetter.Text = "Reverse Letter";
            chkTyposReverseLetter.UseVisualStyleBackColor = true;
            // 
            // chkTyposWrongLetter
            // 
            chkTyposWrongLetter.AutoSize = true;
            chkTyposWrongLetter.Checked = true;
            chkTyposWrongLetter.CheckState = System.Windows.Forms.CheckState.Checked;
            chkTyposWrongLetter.Location = new System.Drawing.Point(121, 46);
            chkTyposWrongLetter.Name = "chkTyposWrongLetter";
            chkTyposWrongLetter.Size = new System.Drawing.Size(95, 19);
            chkTyposWrongLetter.TabIndex = 83;
            chkTyposWrongLetter.Text = "Wrong Letter";
            chkTyposWrongLetter.UseVisualStyleBackColor = true;
            // 
            // chkTyposExtraLetter
            // 
            chkTyposExtraLetter.AutoSize = true;
            chkTyposExtraLetter.Checked = true;
            chkTyposExtraLetter.CheckState = System.Windows.Forms.CheckState.Checked;
            chkTyposExtraLetter.Location = new System.Drawing.Point(12, 21);
            chkTyposExtraLetter.Name = "chkTyposExtraLetter";
            chkTyposExtraLetter.Size = new System.Drawing.Size(85, 19);
            chkTyposExtraLetter.TabIndex = 82;
            chkTyposExtraLetter.Text = "Extra Letter";
            chkTyposExtraLetter.UseVisualStyleBackColor = true;
            // 
            // chkTyposDoubleLetter
            // 
            chkTyposDoubleLetter.AutoSize = true;
            chkTyposDoubleLetter.Checked = true;
            chkTyposDoubleLetter.CheckState = System.Windows.Forms.CheckState.Checked;
            chkTyposDoubleLetter.Location = new System.Drawing.Point(236, 21);
            chkTyposDoubleLetter.Name = "chkTyposDoubleLetter";
            chkTyposDoubleLetter.Size = new System.Drawing.Size(97, 19);
            chkTyposDoubleLetter.TabIndex = 81;
            chkTyposDoubleLetter.Text = "Double Letter";
            chkTyposDoubleLetter.UseVisualStyleBackColor = true;
            // 
            // chkTyposSkipLetter
            // 
            chkTyposSkipLetter.AutoSize = true;
            chkTyposSkipLetter.Checked = true;
            chkTyposSkipLetter.CheckState = System.Windows.Forms.CheckState.Checked;
            chkTyposSkipLetter.Location = new System.Drawing.Point(12, 46);
            chkTyposSkipLetter.Name = "chkTyposSkipLetter";
            chkTyposSkipLetter.Size = new System.Drawing.Size(81, 19);
            chkTyposSkipLetter.TabIndex = 80;
            chkTyposSkipLetter.Text = "Skip Letter";
            chkTyposSkipLetter.UseVisualStyleBackColor = true;
            // 
            // chkTyposSkipDoubleLetter
            // 
            chkTyposSkipDoubleLetter.AutoSize = true;
            chkTyposSkipDoubleLetter.Checked = true;
            chkTyposSkipDoubleLetter.CheckState = System.Windows.Forms.CheckState.Checked;
            chkTyposSkipDoubleLetter.Location = new System.Drawing.Point(236, 46);
            chkTyposSkipDoubleLetter.Name = "chkTyposSkipDoubleLetter";
            chkTyposSkipDoubleLetter.Size = new System.Drawing.Size(122, 19);
            chkTyposSkipDoubleLetter.TabIndex = 79;
            chkTyposSkipDoubleLetter.Text = "Skip Double Letter";
            chkTyposSkipDoubleLetter.UseVisualStyleBackColor = true;
            // 
            // pnlDictBruteforce
            // 
            pnlDictBruteforce.Controls.Add(tabControl);
            pnlDictBruteforce.Location = new System.Drawing.Point(372, 1);
            pnlDictBruteforce.Name = "pnlDictBruteforce";
            pnlDictBruteforce.Size = new System.Drawing.Size(455, 586);
            pnlDictBruteforce.TabIndex = 87;
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabPage1);
            tabControl.Controls.Add(tabPage2);
            tabControl.Controls.Add(tabPage3);
            tabControl.Location = new System.Drawing.Point(5, 11);
            tabControl.Margin = new System.Windows.Forms.Padding(2);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new System.Drawing.Size(444, 578);
            tabControl.TabIndex = 84;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(tabMainDictionaries);
            tabPage1.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            tabPage1.Location = new System.Drawing.Point(4, 24);
            tabPage1.Margin = new System.Windows.Forms.Padding(2);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new System.Windows.Forms.Padding(2);
            tabPage1.Size = new System.Drawing.Size(436, 550);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Main Dictionary";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabMainDictionaries
            // 
            tabMainDictionaries.Controls.Add(tabMainDictionariesCommon);
            tabMainDictionaries.Controls.Add(tabMainDictionariesCustom);
            tabMainDictionaries.Controls.Add(tabMainDictionariesExcludeWords);
            tabMainDictionaries.Location = new System.Drawing.Point(0, 0);
            tabMainDictionaries.Name = "tabMainDictionaries";
            tabMainDictionaries.SelectedIndex = 0;
            tabMainDictionaries.Size = new System.Drawing.Size(436, 550);
            tabMainDictionaries.TabIndex = 85;
            // 
            // tabMainDictionariesCommon
            // 
            tabMainDictionariesCommon.Controls.Add(chkDictCacheSuffix);
            tabMainDictionariesCommon.Controls.Add(chkDictCachePrefix);
            tabMainDictionariesCommon.Controls.Add(txtDictionaryFilterFirstTo);
            tabMainDictionariesCommon.Controls.Add(lblDictionaryFilterFirstTo);
            tabMainDictionariesCommon.Controls.Add(chkDictionariesUse);
            tabMainDictionariesCommon.Controls.Add(lblDictionariesUse);
            tabMainDictionariesCommon.Controls.Add(btnDictUnselected);
            tabMainDictionariesCommon.Controls.Add(tvDictMain);
            tabMainDictionariesCommon.Controls.Add(chkDictReverseOrder);
            tabMainDictionariesCommon.Controls.Add(chkDictAddTypos);
            tabMainDictionariesCommon.Controls.Add(txtDictionaryFilterFirstFrom);
            tabMainDictionariesCommon.Controls.Add(chkDictForceLowercase);
            tabMainDictionariesCommon.Controls.Add(lblDictionaryFilterFirstFrom);
            tabMainDictionariesCommon.Controls.Add(chkDictSkipSpecials);
            tabMainDictionariesCommon.Controls.Add(chkDictSkipDigits);
            tabMainDictionariesCommon.Location = new System.Drawing.Point(4, 22);
            tabMainDictionariesCommon.Name = "tabMainDictionariesCommon";
            tabMainDictionariesCommon.Padding = new System.Windows.Forms.Padding(3);
            tabMainDictionariesCommon.Size = new System.Drawing.Size(428, 524);
            tabMainDictionariesCommon.TabIndex = 0;
            tabMainDictionariesCommon.Text = "Common Dictionaries";
            tabMainDictionariesCommon.UseVisualStyleBackColor = true;
            // 
            // chkDictCacheSuffix
            // 
            chkDictCacheSuffix.AutoSize = true;
            chkDictCacheSuffix.Location = new System.Drawing.Point(6, 472);
            chkDictCacheSuffix.Name = "chkDictCacheSuffix";
            chkDictCacheSuffix.Size = new System.Drawing.Size(89, 17);
            chkDictCacheSuffix.TabIndex = 97;
            chkDictCacheSuffix.Text = "Cache Suffix";
            chkDictCacheSuffix.UseVisualStyleBackColor = true;
            // 
            // chkDictCachePrefix
            // 
            chkDictCachePrefix.AutoSize = true;
            chkDictCachePrefix.Location = new System.Drawing.Point(6, 449);
            chkDictCachePrefix.Name = "chkDictCachePrefix";
            chkDictCachePrefix.Size = new System.Drawing.Size(88, 17);
            chkDictCachePrefix.TabIndex = 96;
            chkDictCachePrefix.Text = "Cache Prefix";
            chkDictCachePrefix.UseVisualStyleBackColor = true;
            // 
            // txtDictionaryFilterFirstTo
            // 
            txtDictionaryFilterFirstTo.Location = new System.Drawing.Point(6, 205);
            txtDictionaryFilterFirstTo.Name = "txtDictionaryFilterFirstTo";
            txtDictionaryFilterFirstTo.PlaceholderText = "zelda";
            txtDictionaryFilterFirstTo.Size = new System.Drawing.Size(98, 22);
            txtDictionaryFilterFirstTo.TabIndex = 95;
            // 
            // lblDictionaryFilterFirstTo
            // 
            lblDictionaryFilterFirstTo.AutoSize = true;
            lblDictionaryFilterFirstTo.Location = new System.Drawing.Point(9, 188);
            lblDictionaryFilterFirstTo.Name = "lblDictionaryFilterFirstTo";
            lblDictionaryFilterFirstTo.Size = new System.Drawing.Size(21, 13);
            lblDictionaryFilterFirstTo.TabIndex = 94;
            lblDictionaryFilterFirstTo.Text = "to:";
            // 
            // chkDictionariesUse
            // 
            chkDictionariesUse.AutoSize = true;
            chkDictionariesUse.Location = new System.Drawing.Point(80, 8);
            chkDictionariesUse.Name = "chkDictionariesUse";
            chkDictionariesUse.Size = new System.Drawing.Size(15, 14);
            chkDictionariesUse.TabIndex = 93;
            chkDictionariesUse.UseVisualStyleBackColor = true;
            chkDictionariesUse.CheckedChanged += chkDictionariesUse_CheckedChanged;
            // 
            // lblDictionariesUse
            // 
            lblDictionariesUse.AutoSize = true;
            lblDictionariesUse.Location = new System.Drawing.Point(6, 7);
            lblDictionariesUse.Name = "lblDictionariesUse";
            lblDictionariesUse.Size = new System.Drawing.Size(29, 13);
            lblDictionariesUse.TabIndex = 22;
            lblDictionariesUse.Text = "Use:";
            // 
            // btnDictUnselected
            // 
            btnDictUnselected.Location = new System.Drawing.Point(4, 497);
            btnDictUnselected.Margin = new System.Windows.Forms.Padding(2);
            btnDictUnselected.Name = "btnDictUnselected";
            btnDictUnselected.Size = new System.Drawing.Size(102, 22);
            btnDictUnselected.TabIndex = 55;
            btnDictUnselected.Text = "Unselect All";
            btnDictUnselected.UseVisualStyleBackColor = true;
            btnDictUnselected.Click += btnDictUnselected_Click;
            // 
            // tvDictMain
            // 
            tvDictMain.Location = new System.Drawing.Point(109, 2);
            tvDictMain.Margin = new System.Windows.Forms.Padding(2);
            tvDictMain.Name = "tvDictMain";
            tvDictMain.Size = new System.Drawing.Size(317, 520);
            tvDictMain.TabIndex = 84;
            tvDictMain.TriStateStyleProperty = RikTheVeggie.TriStateTreeView.TriStateStyles.Standard;
            // 
            // chkDictReverseOrder
            // 
            chkDictReverseOrder.AutoSize = true;
            chkDictReverseOrder.Location = new System.Drawing.Point(6, 120);
            chkDictReverseOrder.Name = "chkDictReverseOrder";
            chkDictReverseOrder.Size = new System.Drawing.Size(98, 17);
            chkDictReverseOrder.TabIndex = 54;
            chkDictReverseOrder.Text = "Reverse Order";
            chkDictReverseOrder.UseVisualStyleBackColor = true;
            // 
            // chkDictAddTypos
            // 
            chkDictAddTypos.AutoSize = true;
            chkDictAddTypos.Location = new System.Drawing.Point(6, 97);
            chkDictAddTypos.Name = "chkDictAddTypos";
            chkDictAddTypos.Size = new System.Drawing.Size(79, 17);
            chkDictAddTypos.TabIndex = 53;
            chkDictAddTypos.Text = "Add Typos";
            chkDictAddTypos.UseVisualStyleBackColor = true;
            // 
            // txtDictionaryFilterFirstFrom
            // 
            txtDictionaryFilterFirstFrom.Location = new System.Drawing.Point(6, 162);
            txtDictionaryFilterFirstFrom.Name = "txtDictionaryFilterFirstFrom";
            txtDictionaryFilterFirstFrom.PlaceholderText = "alucard";
            txtDictionaryFilterFirstFrom.Size = new System.Drawing.Size(98, 22);
            txtDictionaryFilterFirstFrom.TabIndex = 82;
            // 
            // chkDictForceLowercase
            // 
            chkDictForceLowercase.AutoSize = true;
            chkDictForceLowercase.Checked = true;
            chkDictForceLowercase.CheckState = System.Windows.Forms.CheckState.Checked;
            chkDictForceLowercase.Location = new System.Drawing.Point(6, 74);
            chkDictForceLowercase.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            chkDictForceLowercase.Name = "chkDictForceLowercase";
            chkDictForceLowercase.Size = new System.Drawing.Size(79, 17);
            chkDictForceLowercase.TabIndex = 52;
            chkDictForceLowercase.Text = "Lowercase";
            chkDictForceLowercase.UseVisualStyleBackColor = true;
            // 
            // lblDictionaryFilterFirstFrom
            // 
            lblDictionaryFilterFirstFrom.AutoSize = true;
            lblDictionaryFilterFirstFrom.Location = new System.Drawing.Point(6, 145);
            lblDictionaryFilterFirstFrom.Name = "lblDictionaryFilterFirstFrom";
            lblDictionaryFilterFirstFrom.Size = new System.Drawing.Size(91, 13);
            lblDictionaryFilterFirstFrom.TabIndex = 83;
            lblDictionaryFilterFirstFrom.Text = "First Word from:";
            // 
            // chkDictSkipSpecials
            // 
            chkDictSkipSpecials.AutoSize = true;
            chkDictSkipSpecials.Checked = true;
            chkDictSkipSpecials.CheckState = System.Windows.Forms.CheckState.Checked;
            chkDictSkipSpecials.Location = new System.Drawing.Point(6, 51);
            chkDictSkipSpecials.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            chkDictSkipSpecials.Name = "chkDictSkipSpecials";
            chkDictSkipSpecials.Size = new System.Drawing.Size(92, 17);
            chkDictSkipSpecials.TabIndex = 51;
            chkDictSkipSpecials.Text = "Skip Specials";
            chkDictSkipSpecials.UseVisualStyleBackColor = true;
            // 
            // chkDictSkipDigits
            // 
            chkDictSkipDigits.AutoSize = true;
            chkDictSkipDigits.Location = new System.Drawing.Point(6, 28);
            chkDictSkipDigits.Name = "chkDictSkipDigits";
            chkDictSkipDigits.Size = new System.Drawing.Size(81, 17);
            chkDictSkipDigits.TabIndex = 50;
            chkDictSkipDigits.Text = "Skip Digits";
            chkDictSkipDigits.UseVisualStyleBackColor = true;
            // 
            // tabMainDictionariesCustom
            // 
            tabMainDictionariesCustom.Controls.Add(chkDictionariesCustomWordsMinimumInHashUseTypos);
            tabMainDictionariesCustom.Controls.Add(chkDictionariesCustomWordsUse);
            tabMainDictionariesCustom.Controls.Add(lblDictionariesCustomWordsUse);
            tabMainDictionariesCustom.Controls.Add(lblDictionariesCustomWordsAtLeast);
            tabMainDictionariesCustom.Controls.Add(lblDictionariesCustomWordsHash);
            tabMainDictionariesCustom.Controls.Add(cbDictionariesCustomWordsMinimumInHash);
            tabMainDictionariesCustom.Controls.Add(lblDictionariesCustomWordsFiltering);
            tabMainDictionariesCustom.Controls.Add(chkDictCustomWordsAddTypos);
            tabMainDictionariesCustom.Controls.Add(chkDictCustomWordsForceLowercase);
            tabMainDictionariesCustom.Controls.Add(chkDictCustomWordsSkipSpecials);
            tabMainDictionariesCustom.Controls.Add(chkDictCustomWordsSkipDigits);
            tabMainDictionariesCustom.Controls.Add(txtDictCustWords);
            tabMainDictionariesCustom.Location = new System.Drawing.Point(4, 22);
            tabMainDictionariesCustom.Name = "tabMainDictionariesCustom";
            tabMainDictionariesCustom.Padding = new System.Windows.Forms.Padding(3);
            tabMainDictionariesCustom.Size = new System.Drawing.Size(428, 524);
            tabMainDictionariesCustom.TabIndex = 1;
            tabMainDictionariesCustom.Text = "Custom Words";
            tabMainDictionariesCustom.UseVisualStyleBackColor = true;
            // 
            // chkDictionariesCustomWordsMinimumInHashUseTypos
            // 
            chkDictionariesCustomWordsMinimumInHashUseTypos.AutoSize = true;
            chkDictionariesCustomWordsMinimumInHashUseTypos.Location = new System.Drawing.Point(6, 194);
            chkDictionariesCustomWordsMinimumInHashUseTypos.Name = "chkDictionariesCustomWordsMinimumInHashUseTypos";
            chkDictionariesCustomWordsMinimumInHashUseTypos.Size = new System.Drawing.Size(79, 17);
            chkDictionariesCustomWordsMinimumInHashUseTypos.TabIndex = 93;
            chkDictionariesCustomWordsMinimumInHashUseTypos.Text = "Add Typos";
            chkDictionariesCustomWordsMinimumInHashUseTypos.UseVisualStyleBackColor = true;
            // 
            // chkDictionariesCustomWordsUse
            // 
            chkDictionariesCustomWordsUse.AutoSize = true;
            chkDictionariesCustomWordsUse.Location = new System.Drawing.Point(80, 8);
            chkDictionariesCustomWordsUse.Name = "chkDictionariesCustomWordsUse";
            chkDictionariesCustomWordsUse.Size = new System.Drawing.Size(15, 14);
            chkDictionariesCustomWordsUse.TabIndex = 92;
            chkDictionariesCustomWordsUse.UseVisualStyleBackColor = true;
            chkDictionariesCustomWordsUse.CheckedChanged += chkDictionariesCustomWordsUse_CheckedChanged;
            // 
            // lblDictionariesCustomWordsUse
            // 
            lblDictionariesCustomWordsUse.AutoSize = true;
            lblDictionariesCustomWordsUse.Location = new System.Drawing.Point(6, 7);
            lblDictionariesCustomWordsUse.Name = "lblDictionariesCustomWordsUse";
            lblDictionariesCustomWordsUse.Size = new System.Drawing.Size(29, 13);
            lblDictionariesCustomWordsUse.TabIndex = 91;
            lblDictionariesCustomWordsUse.Text = "Use:";
            // 
            // lblDictionariesCustomWordsAtLeast
            // 
            lblDictionariesCustomWordsAtLeast.AutoSize = true;
            lblDictionariesCustomWordsAtLeast.Location = new System.Drawing.Point(9, 155);
            lblDictionariesCustomWordsAtLeast.Name = "lblDictionariesCustomWordsAtLeast";
            lblDictionariesCustomWordsAtLeast.Size = new System.Drawing.Size(45, 13);
            lblDictionariesCustomWordsAtLeast.TabIndex = 89;
            lblDictionariesCustomWordsAtLeast.Text = "At least";
            // 
            // lblDictionariesCustomWordsHash
            // 
            lblDictionariesCustomWordsHash.AutoSize = true;
            lblDictionariesCustomWordsHash.Location = new System.Drawing.Point(9, 174);
            lblDictionariesCustomWordsHash.Name = "lblDictionariesCustomWordsHash";
            lblDictionariesCustomWordsHash.Size = new System.Drawing.Size(86, 13);
            lblDictionariesCustomWordsHash.TabIndex = 88;
            lblDictionariesCustomWordsHash.Text = "word(s) in hash";
            // 
            // cbDictionariesCustomWordsMinimumInHash
            // 
            cbDictionariesCustomWordsMinimumInHash.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbDictionariesCustomWordsMinimumInHash.FormattingEnabled = true;
            cbDictionariesCustomWordsMinimumInHash.Items.AddRange(new object[] { "0", "1", "2", "3" });
            cbDictionariesCustomWordsMinimumInHash.Location = new System.Drawing.Point(57, 151);
            cbDictionariesCustomWordsMinimumInHash.Name = "cbDictionariesCustomWordsMinimumInHash";
            cbDictionariesCustomWordsMinimumInHash.Size = new System.Drawing.Size(38, 21);
            cbDictionariesCustomWordsMinimumInHash.TabIndex = 87;
            // 
            // lblDictionariesCustomWordsFiltering
            // 
            lblDictionariesCustomWordsFiltering.AutoSize = true;
            lblDictionariesCustomWordsFiltering.Location = new System.Drawing.Point(6, 130);
            lblDictionariesCustomWordsFiltering.Name = "lblDictionariesCustomWordsFiltering";
            lblDictionariesCustomWordsFiltering.Size = new System.Drawing.Size(86, 13);
            lblDictionariesCustomWordsFiltering.TabIndex = 86;
            lblDictionariesCustomWordsFiltering.Text = "Filtering (slow):";
            // 
            // chkDictCustomWordsAddTypos
            // 
            chkDictCustomWordsAddTypos.AutoSize = true;
            chkDictCustomWordsAddTypos.Location = new System.Drawing.Point(6, 97);
            chkDictCustomWordsAddTypos.Name = "chkDictCustomWordsAddTypos";
            chkDictCustomWordsAddTypos.Size = new System.Drawing.Size(79, 17);
            chkDictCustomWordsAddTypos.TabIndex = 58;
            chkDictCustomWordsAddTypos.Text = "Add Typos";
            chkDictCustomWordsAddTypos.UseVisualStyleBackColor = true;
            // 
            // chkDictCustomWordsForceLowercase
            // 
            chkDictCustomWordsForceLowercase.AutoSize = true;
            chkDictCustomWordsForceLowercase.Checked = true;
            chkDictCustomWordsForceLowercase.CheckState = System.Windows.Forms.CheckState.Checked;
            chkDictCustomWordsForceLowercase.Location = new System.Drawing.Point(6, 74);
            chkDictCustomWordsForceLowercase.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            chkDictCustomWordsForceLowercase.Name = "chkDictCustomWordsForceLowercase";
            chkDictCustomWordsForceLowercase.Size = new System.Drawing.Size(79, 17);
            chkDictCustomWordsForceLowercase.TabIndex = 57;
            chkDictCustomWordsForceLowercase.Text = "Lowercase";
            chkDictCustomWordsForceLowercase.UseVisualStyleBackColor = true;
            // 
            // chkDictCustomWordsSkipSpecials
            // 
            chkDictCustomWordsSkipSpecials.AutoSize = true;
            chkDictCustomWordsSkipSpecials.Checked = true;
            chkDictCustomWordsSkipSpecials.CheckState = System.Windows.Forms.CheckState.Checked;
            chkDictCustomWordsSkipSpecials.Location = new System.Drawing.Point(6, 51);
            chkDictCustomWordsSkipSpecials.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            chkDictCustomWordsSkipSpecials.Name = "chkDictCustomWordsSkipSpecials";
            chkDictCustomWordsSkipSpecials.Size = new System.Drawing.Size(92, 17);
            chkDictCustomWordsSkipSpecials.TabIndex = 56;
            chkDictCustomWordsSkipSpecials.Text = "Skip Specials";
            chkDictCustomWordsSkipSpecials.UseVisualStyleBackColor = true;
            // 
            // chkDictCustomWordsSkipDigits
            // 
            chkDictCustomWordsSkipDigits.AutoSize = true;
            chkDictCustomWordsSkipDigits.Location = new System.Drawing.Point(6, 28);
            chkDictCustomWordsSkipDigits.Name = "chkDictCustomWordsSkipDigits";
            chkDictCustomWordsSkipDigits.Size = new System.Drawing.Size(81, 17);
            chkDictCustomWordsSkipDigits.TabIndex = 55;
            chkDictCustomWordsSkipDigits.Text = "Skip Digits";
            chkDictCustomWordsSkipDigits.UseVisualStyleBackColor = true;
            // 
            // txtDictCustWords
            // 
            txtDictCustWords.Location = new System.Drawing.Point(109, 2);
            txtDictCustWords.Margin = new System.Windows.Forms.Padding(2);
            txtDictCustWords.Multiline = true;
            txtDictCustWords.Name = "txtDictCustWords";
            txtDictCustWords.Size = new System.Drawing.Size(317, 520);
            txtDictCustWords.TabIndex = 0;
            // 
            // tabMainDictionariesExcludeWords
            // 
            tabMainDictionariesExcludeWords.Controls.Add(chkDictExcludePartialWords);
            tabMainDictionariesExcludeWords.Controls.Add(chkDictionariesExcludeWordsUse);
            tabMainDictionariesExcludeWords.Controls.Add(lblDictionariesExcludeWordsUse);
            tabMainDictionariesExcludeWords.Controls.Add(txtDictExcludeWords);
            tabMainDictionariesExcludeWords.Location = new System.Drawing.Point(4, 22);
            tabMainDictionariesExcludeWords.Name = "tabMainDictionariesExcludeWords";
            tabMainDictionariesExcludeWords.Size = new System.Drawing.Size(428, 524);
            tabMainDictionariesExcludeWords.TabIndex = 2;
            tabMainDictionariesExcludeWords.Text = "Exclude Words";
            tabMainDictionariesExcludeWords.UseVisualStyleBackColor = true;
            // 
            // chkDictExcludePartialWords
            // 
            chkDictExcludePartialWords.AutoSize = true;
            chkDictExcludePartialWords.Location = new System.Drawing.Point(6, 28);
            chkDictExcludePartialWords.Name = "chkDictExcludePartialWords";
            chkDictExcludePartialWords.Size = new System.Drawing.Size(93, 17);
            chkDictExcludePartialWords.TabIndex = 93;
            chkDictExcludePartialWords.Text = "Partial words";
            chkDictExcludePartialWords.UseVisualStyleBackColor = true;
            // 
            // chkDictionariesExcludeWordsUse
            // 
            chkDictionariesExcludeWordsUse.AutoSize = true;
            chkDictionariesExcludeWordsUse.Location = new System.Drawing.Point(80, 8);
            chkDictionariesExcludeWordsUse.Name = "chkDictionariesExcludeWordsUse";
            chkDictionariesExcludeWordsUse.Size = new System.Drawing.Size(15, 14);
            chkDictionariesExcludeWordsUse.TabIndex = 92;
            chkDictionariesExcludeWordsUse.UseVisualStyleBackColor = true;
            chkDictionariesExcludeWordsUse.CheckedChanged += chkDictionariesExcludeWordsUse_CheckedChanged;
            // 
            // lblDictionariesExcludeWordsUse
            // 
            lblDictionariesExcludeWordsUse.AutoSize = true;
            lblDictionariesExcludeWordsUse.Location = new System.Drawing.Point(6, 7);
            lblDictionariesExcludeWordsUse.Name = "lblDictionariesExcludeWordsUse";
            lblDictionariesExcludeWordsUse.Size = new System.Drawing.Size(29, 13);
            lblDictionariesExcludeWordsUse.TabIndex = 91;
            lblDictionariesExcludeWordsUse.Text = "Use:";
            // 
            // txtDictExcludeWords
            // 
            txtDictExcludeWords.Location = new System.Drawing.Point(109, 2);
            txtDictExcludeWords.Margin = new System.Windows.Forms.Padding(2);
            txtDictExcludeWords.Multiline = true;
            txtDictExcludeWords.Name = "txtDictExcludeWords";
            txtDictExcludeWords.Size = new System.Drawing.Size(317, 520);
            txtDictExcludeWords.TabIndex = 1;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(tabFirstWordDictionaries);
            tabPage2.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            tabPage2.Location = new System.Drawing.Point(4, 24);
            tabPage2.Margin = new System.Windows.Forms.Padding(2);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new System.Windows.Forms.Padding(2);
            tabPage2.Size = new System.Drawing.Size(436, 550);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "First Word Overrides";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabFirstWordDictionaries
            // 
            tabFirstWordDictionaries.Controls.Add(tabFirstWordDictionariesCommon);
            tabFirstWordDictionaries.Controls.Add(tabFirstWordDictionariesCustom);
            tabFirstWordDictionaries.Controls.Add(tabFirstWordDictionariesExcludeWords);
            tabFirstWordDictionaries.Location = new System.Drawing.Point(0, 0);
            tabFirstWordDictionaries.Name = "tabFirstWordDictionaries";
            tabFirstWordDictionaries.SelectedIndex = 0;
            tabFirstWordDictionaries.Size = new System.Drawing.Size(436, 550);
            tabFirstWordDictionaries.TabIndex = 86;
            // 
            // tabFirstWordDictionariesCommon
            // 
            tabFirstWordDictionariesCommon.Controls.Add(lblDictionariesFirstWordUse);
            tabFirstWordDictionariesCommon.Controls.Add(tvDictFirstWord);
            tabFirstWordDictionariesCommon.Controls.Add(chkDictFirstReverseOrder);
            tabFirstWordDictionariesCommon.Controls.Add(btnCopyToDictFirst);
            tabFirstWordDictionariesCommon.Controls.Add(btnDictFirstUnselected);
            tabFirstWordDictionariesCommon.Controls.Add(chkDictFirstAddTypos);
            tabFirstWordDictionariesCommon.Controls.Add(chkDictFirstForceLowercase);
            tabFirstWordDictionariesCommon.Controls.Add(chkDictFirstSkipSpecials);
            tabFirstWordDictionariesCommon.Controls.Add(chkUseDictFirst);
            tabFirstWordDictionariesCommon.Controls.Add(chkDictFirstSkipDigits);
            tabFirstWordDictionariesCommon.Location = new System.Drawing.Point(4, 22);
            tabFirstWordDictionariesCommon.Name = "tabFirstWordDictionariesCommon";
            tabFirstWordDictionariesCommon.Padding = new System.Windows.Forms.Padding(3);
            tabFirstWordDictionariesCommon.Size = new System.Drawing.Size(428, 524);
            tabFirstWordDictionariesCommon.TabIndex = 0;
            tabFirstWordDictionariesCommon.Text = "Common Dictionaries";
            tabFirstWordDictionariesCommon.UseVisualStyleBackColor = true;
            // 
            // lblDictionariesFirstWordUse
            // 
            lblDictionariesFirstWordUse.AutoSize = true;
            lblDictionariesFirstWordUse.Location = new System.Drawing.Point(6, 7);
            lblDictionariesFirstWordUse.Name = "lblDictionariesFirstWordUse";
            lblDictionariesFirstWordUse.Size = new System.Drawing.Size(54, 13);
            lblDictionariesFirstWordUse.TabIndex = 33;
            lblDictionariesFirstWordUse.Text = "Override:";
            // 
            // tvDictFirstWord
            // 
            tvDictFirstWord.Location = new System.Drawing.Point(109, 2);
            tvDictFirstWord.Margin = new System.Windows.Forms.Padding(2);
            tvDictFirstWord.Name = "tvDictFirstWord";
            tvDictFirstWord.Size = new System.Drawing.Size(317, 520);
            tvDictFirstWord.TabIndex = 58;
            tvDictFirstWord.TriStateStyleProperty = RikTheVeggie.TriStateTreeView.TriStateStyles.Standard;
            // 
            // chkDictFirstReverseOrder
            // 
            chkDictFirstReverseOrder.AutoSize = true;
            chkDictFirstReverseOrder.Location = new System.Drawing.Point(6, 120);
            chkDictFirstReverseOrder.Name = "chkDictFirstReverseOrder";
            chkDictFirstReverseOrder.Size = new System.Drawing.Size(98, 17);
            chkDictFirstReverseOrder.TabIndex = 44;
            chkDictFirstReverseOrder.Text = "Reverse Order";
            chkDictFirstReverseOrder.UseVisualStyleBackColor = true;
            // 
            // btnCopyToDictFirst
            // 
            btnCopyToDictFirst.Location = new System.Drawing.Point(4, 471);
            btnCopyToDictFirst.Margin = new System.Windows.Forms.Padding(2);
            btnCopyToDictFirst.Name = "btnCopyToDictFirst";
            btnCopyToDictFirst.Size = new System.Drawing.Size(102, 22);
            btnCopyToDictFirst.TabIndex = 57;
            btnCopyToDictFirst.Text = "Copy from Main";
            btnCopyToDictFirst.UseVisualStyleBackColor = true;
            btnCopyToDictFirst.Click += btnCopyToDictFirst_Click;
            // 
            // btnDictFirstUnselected
            // 
            btnDictFirstUnselected.Location = new System.Drawing.Point(4, 497);
            btnDictFirstUnselected.Margin = new System.Windows.Forms.Padding(2);
            btnDictFirstUnselected.Name = "btnDictFirstUnselected";
            btnDictFirstUnselected.Size = new System.Drawing.Size(102, 22);
            btnDictFirstUnselected.TabIndex = 56;
            btnDictFirstUnselected.Text = "Unselect All";
            btnDictFirstUnselected.UseVisualStyleBackColor = true;
            btnDictFirstUnselected.Click += btnDictFirstUnselected_Click;
            // 
            // chkDictFirstAddTypos
            // 
            chkDictFirstAddTypos.AutoSize = true;
            chkDictFirstAddTypos.Location = new System.Drawing.Point(6, 97);
            chkDictFirstAddTypos.Name = "chkDictFirstAddTypos";
            chkDictFirstAddTypos.Size = new System.Drawing.Size(79, 17);
            chkDictFirstAddTypos.TabIndex = 43;
            chkDictFirstAddTypos.Text = "Add Typos";
            chkDictFirstAddTypos.UseVisualStyleBackColor = true;
            // 
            // chkDictFirstForceLowercase
            // 
            chkDictFirstForceLowercase.AutoSize = true;
            chkDictFirstForceLowercase.Location = new System.Drawing.Point(6, 74);
            chkDictFirstForceLowercase.Name = "chkDictFirstForceLowercase";
            chkDictFirstForceLowercase.Size = new System.Drawing.Size(79, 17);
            chkDictFirstForceLowercase.TabIndex = 42;
            chkDictFirstForceLowercase.Text = "Lowercase";
            chkDictFirstForceLowercase.UseVisualStyleBackColor = true;
            // 
            // chkDictFirstSkipSpecials
            // 
            chkDictFirstSkipSpecials.AutoSize = true;
            chkDictFirstSkipSpecials.Location = new System.Drawing.Point(6, 51);
            chkDictFirstSkipSpecials.Name = "chkDictFirstSkipSpecials";
            chkDictFirstSkipSpecials.Size = new System.Drawing.Size(92, 17);
            chkDictFirstSkipSpecials.TabIndex = 41;
            chkDictFirstSkipSpecials.Text = "Skip Specials";
            chkDictFirstSkipSpecials.UseVisualStyleBackColor = true;
            // 
            // chkUseDictFirst
            // 
            chkUseDictFirst.AutoSize = true;
            chkUseDictFirst.Location = new System.Drawing.Point(80, 8);
            chkUseDictFirst.Name = "chkUseDictFirst";
            chkUseDictFirst.Size = new System.Drawing.Size(15, 14);
            chkUseDictFirst.TabIndex = 38;
            chkUseDictFirst.UseVisualStyleBackColor = true;
            chkUseDictFirst.CheckedChanged += OnCustomDictFirstCheckedChanged;
            // 
            // chkDictFirstSkipDigits
            // 
            chkDictFirstSkipDigits.AutoSize = true;
            chkDictFirstSkipDigits.Location = new System.Drawing.Point(6, 28);
            chkDictFirstSkipDigits.Name = "chkDictFirstSkipDigits";
            chkDictFirstSkipDigits.Size = new System.Drawing.Size(81, 17);
            chkDictFirstSkipDigits.TabIndex = 40;
            chkDictFirstSkipDigits.Text = "Skip Digits";
            chkDictFirstSkipDigits.UseVisualStyleBackColor = true;
            // 
            // tabFirstWordDictionariesCustom
            // 
            tabFirstWordDictionariesCustom.Controls.Add(btnCopyToDictCustomFirst);
            tabFirstWordDictionariesCustom.Controls.Add(chkDictionariesFirstWordCustomWordsUse);
            tabFirstWordDictionariesCustom.Controls.Add(lblDictionariesFirstWordCustomWordsUse);
            tabFirstWordDictionariesCustom.Controls.Add(chkDictFirstWordCustomWordsAddTypos);
            tabFirstWordDictionariesCustom.Controls.Add(chkDictFirstWordCustomWordsForceLowercase);
            tabFirstWordDictionariesCustom.Controls.Add(chkDictFirstWordCustomWordsSkipSpecials);
            tabFirstWordDictionariesCustom.Controls.Add(chkDictFirstWordCustomWordsSkipDigits);
            tabFirstWordDictionariesCustom.Controls.Add(txtDictFirstCustWords);
            tabFirstWordDictionariesCustom.Location = new System.Drawing.Point(4, 22);
            tabFirstWordDictionariesCustom.Name = "tabFirstWordDictionariesCustom";
            tabFirstWordDictionariesCustom.Padding = new System.Windows.Forms.Padding(3);
            tabFirstWordDictionariesCustom.Size = new System.Drawing.Size(428, 524);
            tabFirstWordDictionariesCustom.TabIndex = 1;
            tabFirstWordDictionariesCustom.Text = "Custom Words";
            tabFirstWordDictionariesCustom.UseVisualStyleBackColor = true;
            // 
            // btnCopyToDictCustomFirst
            // 
            btnCopyToDictCustomFirst.Location = new System.Drawing.Point(4, 497);
            btnCopyToDictCustomFirst.Margin = new System.Windows.Forms.Padding(2);
            btnCopyToDictCustomFirst.Name = "btnCopyToDictCustomFirst";
            btnCopyToDictCustomFirst.Size = new System.Drawing.Size(102, 22);
            btnCopyToDictCustomFirst.TabIndex = 106;
            btnCopyToDictCustomFirst.Text = "Copy from Main";
            btnCopyToDictCustomFirst.UseVisualStyleBackColor = true;
            btnCopyToDictCustomFirst.Click += btnCopyToDictCustomFirst_Click;
            // 
            // chkDictionariesFirstWordCustomWordsUse
            // 
            chkDictionariesFirstWordCustomWordsUse.AutoSize = true;
            chkDictionariesFirstWordCustomWordsUse.Location = new System.Drawing.Point(80, 8);
            chkDictionariesFirstWordCustomWordsUse.Name = "chkDictionariesFirstWordCustomWordsUse";
            chkDictionariesFirstWordCustomWordsUse.Size = new System.Drawing.Size(15, 14);
            chkDictionariesFirstWordCustomWordsUse.TabIndex = 105;
            chkDictionariesFirstWordCustomWordsUse.UseVisualStyleBackColor = true;
            chkDictionariesFirstWordCustomWordsUse.CheckedChanged += chkDictionariesFirstWordCustomWordsUse_CheckedChanged;
            // 
            // lblDictionariesFirstWordCustomWordsUse
            // 
            lblDictionariesFirstWordCustomWordsUse.AutoSize = true;
            lblDictionariesFirstWordCustomWordsUse.Location = new System.Drawing.Point(6, 7);
            lblDictionariesFirstWordCustomWordsUse.Name = "lblDictionariesFirstWordCustomWordsUse";
            lblDictionariesFirstWordCustomWordsUse.Size = new System.Drawing.Size(54, 13);
            lblDictionariesFirstWordCustomWordsUse.TabIndex = 104;
            lblDictionariesFirstWordCustomWordsUse.Text = "Override:";
            // 
            // chkDictFirstWordCustomWordsAddTypos
            // 
            chkDictFirstWordCustomWordsAddTypos.AutoSize = true;
            chkDictFirstWordCustomWordsAddTypos.Location = new System.Drawing.Point(6, 97);
            chkDictFirstWordCustomWordsAddTypos.Name = "chkDictFirstWordCustomWordsAddTypos";
            chkDictFirstWordCustomWordsAddTypos.Size = new System.Drawing.Size(79, 17);
            chkDictFirstWordCustomWordsAddTypos.TabIndex = 98;
            chkDictFirstWordCustomWordsAddTypos.Text = "Add Typos";
            chkDictFirstWordCustomWordsAddTypos.UseVisualStyleBackColor = true;
            // 
            // chkDictFirstWordCustomWordsForceLowercase
            // 
            chkDictFirstWordCustomWordsForceLowercase.AutoSize = true;
            chkDictFirstWordCustomWordsForceLowercase.Checked = true;
            chkDictFirstWordCustomWordsForceLowercase.CheckState = System.Windows.Forms.CheckState.Checked;
            chkDictFirstWordCustomWordsForceLowercase.Location = new System.Drawing.Point(6, 74);
            chkDictFirstWordCustomWordsForceLowercase.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            chkDictFirstWordCustomWordsForceLowercase.Name = "chkDictFirstWordCustomWordsForceLowercase";
            chkDictFirstWordCustomWordsForceLowercase.Size = new System.Drawing.Size(79, 17);
            chkDictFirstWordCustomWordsForceLowercase.TabIndex = 97;
            chkDictFirstWordCustomWordsForceLowercase.Text = "Lowercase";
            chkDictFirstWordCustomWordsForceLowercase.UseVisualStyleBackColor = true;
            // 
            // chkDictFirstWordCustomWordsSkipSpecials
            // 
            chkDictFirstWordCustomWordsSkipSpecials.AutoSize = true;
            chkDictFirstWordCustomWordsSkipSpecials.Checked = true;
            chkDictFirstWordCustomWordsSkipSpecials.CheckState = System.Windows.Forms.CheckState.Checked;
            chkDictFirstWordCustomWordsSkipSpecials.Location = new System.Drawing.Point(6, 51);
            chkDictFirstWordCustomWordsSkipSpecials.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            chkDictFirstWordCustomWordsSkipSpecials.Name = "chkDictFirstWordCustomWordsSkipSpecials";
            chkDictFirstWordCustomWordsSkipSpecials.Size = new System.Drawing.Size(92, 17);
            chkDictFirstWordCustomWordsSkipSpecials.TabIndex = 96;
            chkDictFirstWordCustomWordsSkipSpecials.Text = "Skip Specials";
            chkDictFirstWordCustomWordsSkipSpecials.UseVisualStyleBackColor = true;
            // 
            // chkDictFirstWordCustomWordsSkipDigits
            // 
            chkDictFirstWordCustomWordsSkipDigits.AutoSize = true;
            chkDictFirstWordCustomWordsSkipDigits.Location = new System.Drawing.Point(6, 28);
            chkDictFirstWordCustomWordsSkipDigits.Name = "chkDictFirstWordCustomWordsSkipDigits";
            chkDictFirstWordCustomWordsSkipDigits.Size = new System.Drawing.Size(81, 17);
            chkDictFirstWordCustomWordsSkipDigits.TabIndex = 95;
            chkDictFirstWordCustomWordsSkipDigits.Text = "Skip Digits";
            chkDictFirstWordCustomWordsSkipDigits.UseVisualStyleBackColor = true;
            // 
            // txtDictFirstCustWords
            // 
            txtDictFirstCustWords.Location = new System.Drawing.Point(109, 2);
            txtDictFirstCustWords.Margin = new System.Windows.Forms.Padding(2);
            txtDictFirstCustWords.Multiline = true;
            txtDictFirstCustWords.Name = "txtDictFirstCustWords";
            txtDictFirstCustWords.Size = new System.Drawing.Size(317, 520);
            txtDictFirstCustWords.TabIndex = 0;
            // 
            // tabFirstWordDictionariesExcludeWords
            // 
            tabFirstWordDictionariesExcludeWords.Controls.Add(btnCopyToDictExcludeFirst);
            tabFirstWordDictionariesExcludeWords.Controls.Add(txtDictFirstWordExcludeWords);
            tabFirstWordDictionariesExcludeWords.Controls.Add(chkDictFirstWordExcludePartialWords);
            tabFirstWordDictionariesExcludeWords.Controls.Add(chkDictionariesFirstWordExcludeWordsUse);
            tabFirstWordDictionariesExcludeWords.Controls.Add(lblDictionariesFirstWordExcludeWordsUse);
            tabFirstWordDictionariesExcludeWords.Location = new System.Drawing.Point(4, 22);
            tabFirstWordDictionariesExcludeWords.Name = "tabFirstWordDictionariesExcludeWords";
            tabFirstWordDictionariesExcludeWords.Size = new System.Drawing.Size(428, 524);
            tabFirstWordDictionariesExcludeWords.TabIndex = 2;
            tabFirstWordDictionariesExcludeWords.Text = "Exclude Words";
            tabFirstWordDictionariesExcludeWords.UseVisualStyleBackColor = true;
            // 
            // btnCopyToDictExcludeFirst
            // 
            btnCopyToDictExcludeFirst.Location = new System.Drawing.Point(4, 497);
            btnCopyToDictExcludeFirst.Margin = new System.Windows.Forms.Padding(2);
            btnCopyToDictExcludeFirst.Name = "btnCopyToDictExcludeFirst";
            btnCopyToDictExcludeFirst.Size = new System.Drawing.Size(102, 22);
            btnCopyToDictExcludeFirst.TabIndex = 98;
            btnCopyToDictExcludeFirst.Text = "Copy from Main";
            btnCopyToDictExcludeFirst.UseVisualStyleBackColor = true;
            btnCopyToDictExcludeFirst.Click += btnCopyToDictExcludeFirst_Click;
            // 
            // txtDictFirstWordExcludeWords
            // 
            txtDictFirstWordExcludeWords.Location = new System.Drawing.Point(109, 2);
            txtDictFirstWordExcludeWords.Margin = new System.Windows.Forms.Padding(2);
            txtDictFirstWordExcludeWords.Multiline = true;
            txtDictFirstWordExcludeWords.Name = "txtDictFirstWordExcludeWords";
            txtDictFirstWordExcludeWords.Size = new System.Drawing.Size(317, 520);
            txtDictFirstWordExcludeWords.TabIndex = 97;
            // 
            // chkDictFirstWordExcludePartialWords
            // 
            chkDictFirstWordExcludePartialWords.AutoSize = true;
            chkDictFirstWordExcludePartialWords.Location = new System.Drawing.Point(6, 28);
            chkDictFirstWordExcludePartialWords.Name = "chkDictFirstWordExcludePartialWords";
            chkDictFirstWordExcludePartialWords.Size = new System.Drawing.Size(93, 17);
            chkDictFirstWordExcludePartialWords.TabIndex = 96;
            chkDictFirstWordExcludePartialWords.Text = "Partial words";
            chkDictFirstWordExcludePartialWords.UseVisualStyleBackColor = true;
            // 
            // chkDictionariesFirstWordExcludeWordsUse
            // 
            chkDictionariesFirstWordExcludeWordsUse.AutoSize = true;
            chkDictionariesFirstWordExcludeWordsUse.Location = new System.Drawing.Point(80, 8);
            chkDictionariesFirstWordExcludeWordsUse.Name = "chkDictionariesFirstWordExcludeWordsUse";
            chkDictionariesFirstWordExcludeWordsUse.Size = new System.Drawing.Size(15, 14);
            chkDictionariesFirstWordExcludeWordsUse.TabIndex = 95;
            chkDictionariesFirstWordExcludeWordsUse.UseVisualStyleBackColor = true;
            chkDictionariesFirstWordExcludeWordsUse.CheckedChanged += chkDictionariesFirstWordExcludeWordsUse_CheckedChanged;
            // 
            // lblDictionariesFirstWordExcludeWordsUse
            // 
            lblDictionariesFirstWordExcludeWordsUse.AutoSize = true;
            lblDictionariesFirstWordExcludeWordsUse.Location = new System.Drawing.Point(6, 7);
            lblDictionariesFirstWordExcludeWordsUse.Name = "lblDictionariesFirstWordExcludeWordsUse";
            lblDictionariesFirstWordExcludeWordsUse.Size = new System.Drawing.Size(54, 13);
            lblDictionariesFirstWordExcludeWordsUse.TabIndex = 94;
            lblDictionariesFirstWordExcludeWordsUse.Text = "Override:";
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(tabLastWordDictionaries);
            tabPage3.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            tabPage3.Location = new System.Drawing.Point(4, 24);
            tabPage3.Margin = new System.Windows.Forms.Padding(2);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new System.Drawing.Size(436, 550);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Last Word Overrides";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabLastWordDictionaries
            // 
            tabLastWordDictionaries.Controls.Add(tabLastWordDictionariesCommon);
            tabLastWordDictionaries.Controls.Add(tabLastWordDictionariesCustom);
            tabLastWordDictionaries.Controls.Add(tabLastWordDictionariesExcludeWords);
            tabLastWordDictionaries.Location = new System.Drawing.Point(0, 0);
            tabLastWordDictionaries.Name = "tabLastWordDictionaries";
            tabLastWordDictionaries.SelectedIndex = 0;
            tabLastWordDictionaries.Size = new System.Drawing.Size(436, 550);
            tabLastWordDictionaries.TabIndex = 87;
            // 
            // tabLastWordDictionariesCommon
            // 
            tabLastWordDictionariesCommon.Controls.Add(lblDictionaryLastWordUse);
            tabLastWordDictionariesCommon.Controls.Add(tvDictLastWord);
            tabLastWordDictionariesCommon.Controls.Add(chkDictLastForceLowercase);
            tabLastWordDictionariesCommon.Controls.Add(btnCopyToDictLast);
            tabLastWordDictionariesCommon.Controls.Add(btnDictLastUnselected);
            tabLastWordDictionariesCommon.Controls.Add(chkDictLastSkipSpecials);
            tabLastWordDictionariesCommon.Controls.Add(chkDictLastAddTypos);
            tabLastWordDictionariesCommon.Controls.Add(chkDictLastSkipDigits);
            tabLastWordDictionariesCommon.Controls.Add(chkUseDictLast);
            tabLastWordDictionariesCommon.Controls.Add(chkDictLastReverseOrder);
            tabLastWordDictionariesCommon.Location = new System.Drawing.Point(4, 22);
            tabLastWordDictionariesCommon.Name = "tabLastWordDictionariesCommon";
            tabLastWordDictionariesCommon.Padding = new System.Windows.Forms.Padding(3);
            tabLastWordDictionariesCommon.Size = new System.Drawing.Size(428, 524);
            tabLastWordDictionariesCommon.TabIndex = 0;
            tabLastWordDictionariesCommon.Text = "Common Dictionaries";
            tabLastWordDictionariesCommon.UseVisualStyleBackColor = true;
            // 
            // lblDictionaryLastWordUse
            // 
            lblDictionaryLastWordUse.AutoSize = true;
            lblDictionaryLastWordUse.Location = new System.Drawing.Point(6, 7);
            lblDictionaryLastWordUse.Name = "lblDictionaryLastWordUse";
            lblDictionaryLastWordUse.Size = new System.Drawing.Size(54, 13);
            lblDictionaryLastWordUse.TabIndex = 31;
            lblDictionaryLastWordUse.Text = "Override:";
            // 
            // tvDictLastWord
            // 
            tvDictLastWord.Location = new System.Drawing.Point(109, 2);
            tvDictLastWord.Margin = new System.Windows.Forms.Padding(2);
            tvDictLastWord.Name = "tvDictLastWord";
            tvDictLastWord.Size = new System.Drawing.Size(317, 520);
            tvDictLastWord.TabIndex = 59;
            tvDictLastWord.TriStateStyleProperty = RikTheVeggie.TriStateTreeView.TriStateStyles.Standard;
            // 
            // chkDictLastForceLowercase
            // 
            chkDictLastForceLowercase.AutoSize = true;
            chkDictLastForceLowercase.Location = new System.Drawing.Point(6, 74);
            chkDictLastForceLowercase.Name = "chkDictLastForceLowercase";
            chkDictLastForceLowercase.Size = new System.Drawing.Size(79, 17);
            chkDictLastForceLowercase.TabIndex = 47;
            chkDictLastForceLowercase.Text = "Lowercase";
            chkDictLastForceLowercase.UseVisualStyleBackColor = true;
            // 
            // btnCopyToDictLast
            // 
            btnCopyToDictLast.Location = new System.Drawing.Point(4, 471);
            btnCopyToDictLast.Margin = new System.Windows.Forms.Padding(2);
            btnCopyToDictLast.Name = "btnCopyToDictLast";
            btnCopyToDictLast.Size = new System.Drawing.Size(102, 22);
            btnCopyToDictLast.TabIndex = 58;
            btnCopyToDictLast.Text = "Copy from Main";
            btnCopyToDictLast.UseVisualStyleBackColor = true;
            btnCopyToDictLast.Click += btnCopyToDictLast_Click;
            // 
            // btnDictLastUnselected
            // 
            btnDictLastUnselected.Location = new System.Drawing.Point(4, 497);
            btnDictLastUnselected.Margin = new System.Windows.Forms.Padding(2);
            btnDictLastUnselected.Name = "btnDictLastUnselected";
            btnDictLastUnselected.Size = new System.Drawing.Size(102, 22);
            btnDictLastUnselected.TabIndex = 57;
            btnDictLastUnselected.Text = "Unselect All";
            btnDictLastUnselected.UseVisualStyleBackColor = true;
            btnDictLastUnselected.Click += btnDictLastUnselected_Click;
            // 
            // chkDictLastSkipSpecials
            // 
            chkDictLastSkipSpecials.AutoSize = true;
            chkDictLastSkipSpecials.Location = new System.Drawing.Point(6, 51);
            chkDictLastSkipSpecials.Name = "chkDictLastSkipSpecials";
            chkDictLastSkipSpecials.Size = new System.Drawing.Size(92, 17);
            chkDictLastSkipSpecials.TabIndex = 46;
            chkDictLastSkipSpecials.Text = "Skip Specials";
            chkDictLastSkipSpecials.UseVisualStyleBackColor = true;
            // 
            // chkDictLastAddTypos
            // 
            chkDictLastAddTypos.AutoSize = true;
            chkDictLastAddTypos.Location = new System.Drawing.Point(6, 97);
            chkDictLastAddTypos.Name = "chkDictLastAddTypos";
            chkDictLastAddTypos.Size = new System.Drawing.Size(79, 17);
            chkDictLastAddTypos.TabIndex = 48;
            chkDictLastAddTypos.Text = "Add Typos";
            chkDictLastAddTypos.UseVisualStyleBackColor = true;
            // 
            // chkDictLastSkipDigits
            // 
            chkDictLastSkipDigits.AutoSize = true;
            chkDictLastSkipDigits.Location = new System.Drawing.Point(6, 28);
            chkDictLastSkipDigits.Name = "chkDictLastSkipDigits";
            chkDictLastSkipDigits.Size = new System.Drawing.Size(81, 17);
            chkDictLastSkipDigits.TabIndex = 45;
            chkDictLastSkipDigits.Text = "Skip Digits";
            chkDictLastSkipDigits.UseVisualStyleBackColor = true;
            // 
            // chkUseDictLast
            // 
            chkUseDictLast.AutoSize = true;
            chkUseDictLast.Location = new System.Drawing.Point(80, 8);
            chkUseDictLast.Name = "chkUseDictLast";
            chkUseDictLast.Size = new System.Drawing.Size(15, 14);
            chkUseDictLast.TabIndex = 39;
            chkUseDictLast.UseVisualStyleBackColor = true;
            chkUseDictLast.CheckedChanged += OnCustomDictLastCheckedChanged;
            // 
            // chkDictLastReverseOrder
            // 
            chkDictLastReverseOrder.AutoSize = true;
            chkDictLastReverseOrder.Location = new System.Drawing.Point(6, 120);
            chkDictLastReverseOrder.Name = "chkDictLastReverseOrder";
            chkDictLastReverseOrder.Size = new System.Drawing.Size(98, 17);
            chkDictLastReverseOrder.TabIndex = 49;
            chkDictLastReverseOrder.Text = "Reverse Order";
            chkDictLastReverseOrder.UseVisualStyleBackColor = true;
            // 
            // tabLastWordDictionariesCustom
            // 
            tabLastWordDictionariesCustom.Controls.Add(btnCopyToDictCustomLast);
            tabLastWordDictionariesCustom.Controls.Add(chkDictionariesLastWordCustomWordsUse);
            tabLastWordDictionariesCustom.Controls.Add(lblDictionariesLastWordCustomWordsUse);
            tabLastWordDictionariesCustom.Controls.Add(chkDictLastWordCustomWordsAddTypos);
            tabLastWordDictionariesCustom.Controls.Add(chkDictLastWordCustomWordsForceLowercase);
            tabLastWordDictionariesCustom.Controls.Add(chkDictLastWordCustomWordsSkipSpecials);
            tabLastWordDictionariesCustom.Controls.Add(chkDictLastWordCustomWordsSkipDigits);
            tabLastWordDictionariesCustom.Controls.Add(txtDictLastCustWords);
            tabLastWordDictionariesCustom.Location = new System.Drawing.Point(4, 22);
            tabLastWordDictionariesCustom.Name = "tabLastWordDictionariesCustom";
            tabLastWordDictionariesCustom.Padding = new System.Windows.Forms.Padding(3);
            tabLastWordDictionariesCustom.Size = new System.Drawing.Size(428, 524);
            tabLastWordDictionariesCustom.TabIndex = 1;
            tabLastWordDictionariesCustom.Text = "Custom Words";
            tabLastWordDictionariesCustom.UseVisualStyleBackColor = true;
            // 
            // btnCopyToDictCustomLast
            // 
            btnCopyToDictCustomLast.Location = new System.Drawing.Point(4, 497);
            btnCopyToDictCustomLast.Margin = new System.Windows.Forms.Padding(2);
            btnCopyToDictCustomLast.Name = "btnCopyToDictCustomLast";
            btnCopyToDictCustomLast.Size = new System.Drawing.Size(102, 22);
            btnCopyToDictCustomLast.TabIndex = 106;
            btnCopyToDictCustomLast.Text = "Copy from Main";
            btnCopyToDictCustomLast.UseVisualStyleBackColor = true;
            btnCopyToDictCustomLast.Click += btnCopyToDictCustomLast_Click;
            // 
            // chkDictionariesLastWordCustomWordsUse
            // 
            chkDictionariesLastWordCustomWordsUse.AutoSize = true;
            chkDictionariesLastWordCustomWordsUse.Location = new System.Drawing.Point(80, 8);
            chkDictionariesLastWordCustomWordsUse.Name = "chkDictionariesLastWordCustomWordsUse";
            chkDictionariesLastWordCustomWordsUse.Size = new System.Drawing.Size(15, 14);
            chkDictionariesLastWordCustomWordsUse.TabIndex = 105;
            chkDictionariesLastWordCustomWordsUse.UseVisualStyleBackColor = true;
            chkDictionariesLastWordCustomWordsUse.CheckedChanged += chkDictionariesLastWordCustomWordsUse_CheckedChanged;
            // 
            // lblDictionariesLastWordCustomWordsUse
            // 
            lblDictionariesLastWordCustomWordsUse.AutoSize = true;
            lblDictionariesLastWordCustomWordsUse.Location = new System.Drawing.Point(6, 7);
            lblDictionariesLastWordCustomWordsUse.Name = "lblDictionariesLastWordCustomWordsUse";
            lblDictionariesLastWordCustomWordsUse.Size = new System.Drawing.Size(54, 13);
            lblDictionariesLastWordCustomWordsUse.TabIndex = 104;
            lblDictionariesLastWordCustomWordsUse.Text = "Override:";
            // 
            // chkDictLastWordCustomWordsAddTypos
            // 
            chkDictLastWordCustomWordsAddTypos.AutoSize = true;
            chkDictLastWordCustomWordsAddTypos.Location = new System.Drawing.Point(6, 97);
            chkDictLastWordCustomWordsAddTypos.Name = "chkDictLastWordCustomWordsAddTypos";
            chkDictLastWordCustomWordsAddTypos.Size = new System.Drawing.Size(79, 17);
            chkDictLastWordCustomWordsAddTypos.TabIndex = 98;
            chkDictLastWordCustomWordsAddTypos.Text = "Add Typos";
            chkDictLastWordCustomWordsAddTypos.UseVisualStyleBackColor = true;
            // 
            // chkDictLastWordCustomWordsForceLowercase
            // 
            chkDictLastWordCustomWordsForceLowercase.AutoSize = true;
            chkDictLastWordCustomWordsForceLowercase.Checked = true;
            chkDictLastWordCustomWordsForceLowercase.CheckState = System.Windows.Forms.CheckState.Checked;
            chkDictLastWordCustomWordsForceLowercase.Location = new System.Drawing.Point(6, 74);
            chkDictLastWordCustomWordsForceLowercase.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            chkDictLastWordCustomWordsForceLowercase.Name = "chkDictLastWordCustomWordsForceLowercase";
            chkDictLastWordCustomWordsForceLowercase.Size = new System.Drawing.Size(79, 17);
            chkDictLastWordCustomWordsForceLowercase.TabIndex = 97;
            chkDictLastWordCustomWordsForceLowercase.Text = "Lowercase";
            chkDictLastWordCustomWordsForceLowercase.UseVisualStyleBackColor = true;
            // 
            // chkDictLastWordCustomWordsSkipSpecials
            // 
            chkDictLastWordCustomWordsSkipSpecials.AutoSize = true;
            chkDictLastWordCustomWordsSkipSpecials.Checked = true;
            chkDictLastWordCustomWordsSkipSpecials.CheckState = System.Windows.Forms.CheckState.Checked;
            chkDictLastWordCustomWordsSkipSpecials.Location = new System.Drawing.Point(6, 51);
            chkDictLastWordCustomWordsSkipSpecials.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            chkDictLastWordCustomWordsSkipSpecials.Name = "chkDictLastWordCustomWordsSkipSpecials";
            chkDictLastWordCustomWordsSkipSpecials.Size = new System.Drawing.Size(92, 17);
            chkDictLastWordCustomWordsSkipSpecials.TabIndex = 96;
            chkDictLastWordCustomWordsSkipSpecials.Text = "Skip Specials";
            chkDictLastWordCustomWordsSkipSpecials.UseVisualStyleBackColor = true;
            // 
            // chkDictLastWordCustomWordsSkipDigits
            // 
            chkDictLastWordCustomWordsSkipDigits.AutoSize = true;
            chkDictLastWordCustomWordsSkipDigits.Location = new System.Drawing.Point(6, 28);
            chkDictLastWordCustomWordsSkipDigits.Name = "chkDictLastWordCustomWordsSkipDigits";
            chkDictLastWordCustomWordsSkipDigits.Size = new System.Drawing.Size(81, 17);
            chkDictLastWordCustomWordsSkipDigits.TabIndex = 95;
            chkDictLastWordCustomWordsSkipDigits.Text = "Skip Digits";
            chkDictLastWordCustomWordsSkipDigits.UseVisualStyleBackColor = true;
            // 
            // txtDictLastCustWords
            // 
            txtDictLastCustWords.Location = new System.Drawing.Point(109, 2);
            txtDictLastCustWords.Margin = new System.Windows.Forms.Padding(2);
            txtDictLastCustWords.Multiline = true;
            txtDictLastCustWords.Name = "txtDictLastCustWords";
            txtDictLastCustWords.Size = new System.Drawing.Size(317, 520);
            txtDictLastCustWords.TabIndex = 0;
            // 
            // tabLastWordDictionariesExcludeWords
            // 
            tabLastWordDictionariesExcludeWords.Controls.Add(btnCopyToDictExcludeLast);
            tabLastWordDictionariesExcludeWords.Controls.Add(txtDictLastWordExcludeWords);
            tabLastWordDictionariesExcludeWords.Controls.Add(chkDictLastWordExcludePartialWords);
            tabLastWordDictionariesExcludeWords.Controls.Add(chkDictionariesLastWordExcludeWordsUse);
            tabLastWordDictionariesExcludeWords.Controls.Add(lblDictionariesLastWordExcludeWordsUse);
            tabLastWordDictionariesExcludeWords.Location = new System.Drawing.Point(4, 22);
            tabLastWordDictionariesExcludeWords.Name = "tabLastWordDictionariesExcludeWords";
            tabLastWordDictionariesExcludeWords.Size = new System.Drawing.Size(428, 524);
            tabLastWordDictionariesExcludeWords.TabIndex = 2;
            tabLastWordDictionariesExcludeWords.Text = "Exclude Words";
            tabLastWordDictionariesExcludeWords.UseVisualStyleBackColor = true;
            // 
            // btnCopyToDictExcludeLast
            // 
            btnCopyToDictExcludeLast.Location = new System.Drawing.Point(4, 497);
            btnCopyToDictExcludeLast.Margin = new System.Windows.Forms.Padding(2);
            btnCopyToDictExcludeLast.Name = "btnCopyToDictExcludeLast";
            btnCopyToDictExcludeLast.Size = new System.Drawing.Size(102, 22);
            btnCopyToDictExcludeLast.TabIndex = 98;
            btnCopyToDictExcludeLast.Text = "Copy from Main";
            btnCopyToDictExcludeLast.UseVisualStyleBackColor = true;
            btnCopyToDictExcludeLast.Click += btnCopyToDictExcludeLast_Click;
            // 
            // txtDictLastWordExcludeWords
            // 
            txtDictLastWordExcludeWords.Location = new System.Drawing.Point(109, 2);
            txtDictLastWordExcludeWords.Margin = new System.Windows.Forms.Padding(2);
            txtDictLastWordExcludeWords.Multiline = true;
            txtDictLastWordExcludeWords.Name = "txtDictLastWordExcludeWords";
            txtDictLastWordExcludeWords.Size = new System.Drawing.Size(317, 520);
            txtDictLastWordExcludeWords.TabIndex = 97;
            // 
            // chkDictLastWordExcludePartialWords
            // 
            chkDictLastWordExcludePartialWords.AutoSize = true;
            chkDictLastWordExcludePartialWords.Location = new System.Drawing.Point(6, 28);
            chkDictLastWordExcludePartialWords.Name = "chkDictLastWordExcludePartialWords";
            chkDictLastWordExcludePartialWords.Size = new System.Drawing.Size(93, 17);
            chkDictLastWordExcludePartialWords.TabIndex = 96;
            chkDictLastWordExcludePartialWords.Text = "Partial words";
            chkDictLastWordExcludePartialWords.UseVisualStyleBackColor = true;
            // 
            // chkDictionariesLastWordExcludeWordsUse
            // 
            chkDictionariesLastWordExcludeWordsUse.AutoSize = true;
            chkDictionariesLastWordExcludeWordsUse.Location = new System.Drawing.Point(80, 8);
            chkDictionariesLastWordExcludeWordsUse.Name = "chkDictionariesLastWordExcludeWordsUse";
            chkDictionariesLastWordExcludeWordsUse.Size = new System.Drawing.Size(15, 14);
            chkDictionariesLastWordExcludeWordsUse.TabIndex = 95;
            chkDictionariesLastWordExcludeWordsUse.UseVisualStyleBackColor = true;
            chkDictionariesLastWordExcludeWordsUse.CheckedChanged += chkDictionariesLastWordExcludeWordsUse_CheckedChanged;
            // 
            // lblDictionariesLastWordExcludeWordsUse
            // 
            lblDictionariesLastWordExcludeWordsUse.AutoSize = true;
            lblDictionariesLastWordExcludeWordsUse.Location = new System.Drawing.Point(6, 7);
            lblDictionariesLastWordExcludeWordsUse.Name = "lblDictionariesLastWordExcludeWordsUse";
            lblDictionariesLastWordExcludeWordsUse.Size = new System.Drawing.Size(54, 13);
            lblDictionariesLastWordExcludeWordsUse.TabIndex = 94;
            lblDictionariesLastWordExcludeWordsUse.Text = "Override:";
            // 
            // chkVerbose
            // 
            chkVerbose.AutoSize = true;
            chkVerbose.Checked = true;
            chkVerbose.CheckState = System.Windows.Forms.CheckState.Checked;
            chkVerbose.Location = new System.Drawing.Point(822, 38);
            chkVerbose.Name = "chkVerbose";
            chkVerbose.Size = new System.Drawing.Size(15, 14);
            chkVerbose.TabIndex = 33;
            chkVerbose.UseVisualStyleBackColor = true;
            // 
            // mnStrip
            // 
            mnStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            mnStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { mnFile, toolsToolStripMenuItem });
            mnStrip.Location = new System.Drawing.Point(0, 0);
            mnStrip.Name = "mnStrip";
            mnStrip.Size = new System.Drawing.Size(848, 24);
            mnStrip.TabIndex = 34;
            // 
            // mnFile
            // 
            mnFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { mnNew, mnSeparator, mnRefresh, mnSeparator2, mnQuickLoad, mnQuickSave, mnQuickClean, mnSeparator3, mnLoad, mnSave });
            mnFile.Name = "mnFile";
            mnFile.Size = new System.Drawing.Size(37, 20);
            mnFile.Text = "File";
            // 
            // mnNew
            // 
            mnNew.Name = "mnNew";
            mnNew.Size = new System.Drawing.Size(138, 22);
            mnNew.Text = "New";
            // 
            // mnSeparator
            // 
            mnSeparator.Name = "mnSeparator";
            mnSeparator.Size = new System.Drawing.Size(135, 6);
            // 
            // mnRefresh
            // 
            mnRefresh.Name = "mnRefresh";
            mnRefresh.Size = new System.Drawing.Size(138, 22);
            mnRefresh.Text = "Refresh";
            // 
            // mnSeparator2
            // 
            mnSeparator2.Name = "mnSeparator2";
            mnSeparator2.Size = new System.Drawing.Size(135, 6);
            // 
            // mnQuickLoad
            // 
            mnQuickLoad.Name = "mnQuickLoad";
            mnQuickLoad.Size = new System.Drawing.Size(138, 22);
            mnQuickLoad.Text = "Quick Load";
            // 
            // mnQuickSave
            // 
            mnQuickSave.Name = "mnQuickSave";
            mnQuickSave.Size = new System.Drawing.Size(138, 22);
            mnQuickSave.Text = "Quick Save";
            // 
            // mnQuickClean
            // 
            mnQuickClean.Name = "mnQuickClean";
            mnQuickClean.Size = new System.Drawing.Size(138, 22);
            mnQuickClean.Text = "Quick Clean";
            // 
            // mnSeparator3
            // 
            mnSeparator3.Name = "mnSeparator3";
            mnSeparator3.Size = new System.Drawing.Size(135, 6);
            // 
            // mnLoad
            // 
            mnLoad.Name = "mnLoad";
            mnLoad.Size = new System.Drawing.Size(138, 22);
            mnLoad.Text = "Load...";
            // 
            // mnSave
            // 
            mnSave.Name = "mnSave";
            mnSave.Size = new System.Drawing.Size(138, 22);
            mnSave.Text = "Save...";
            // 
            // toolsToolStripMenuItem
            // 
            toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { printLatestCommandToolStripMenuItem });
            toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            toolsToolStripMenuItem.Text = "Tools";
            // 
            // printLatestCommandToolStripMenuItem
            // 
            printLatestCommandToolStripMenuItem.Name = "printLatestCommandToolStripMenuItem";
            printLatestCommandToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            printLatestCommandToolStripMenuItem.Text = "Print latest command";
            printLatestCommandToolStripMenuItem.Click += printLatestCommandToolStripMenuItem_Click;
            // 
            // openFile
            // 
            openFile.FileName = "file.hbt";
            // 
            // saveFile
            // 
            saveFile.FileName = "file.hbt";
            // 
            // lblVerbose
            // 
            lblVerbose.AutoSize = true;
            lblVerbose.Location = new System.Drawing.Point(748, 36);
            lblVerbose.Name = "lblVerbose";
            lblVerbose.Size = new System.Drawing.Size(51, 15);
            lblVerbose.TabIndex = 35;
            lblVerbose.Text = "Verbose:";
            // 
            // btnStartHashCat
            // 
            btnStartHashCat.Location = new System.Drawing.Point(409, 694);
            btnStartHashCat.Name = "btnStartHashCat";
            btnStartHashCat.Size = new System.Drawing.Size(213, 22);
            btnStartHashCat.TabIndex = 36;
            btnStartHashCat.Text = "START (HashCat)";
            btnStartHashCat.UseVisualStyleBackColor = true;
            btnStartHashCat.Click += OnStartHashCatClick;
            // 
            // btnQuickSave
            // 
            btnQuickSave.Location = new System.Drawing.Point(284, 73);
            btnQuickSave.Margin = new System.Windows.Forms.Padding(2);
            btnQuickSave.Name = "btnQuickSave";
            btnQuickSave.Size = new System.Drawing.Size(46, 20);
            btnQuickSave.TabIndex = 37;
            btnQuickSave.Text = "Save";
            btnQuickSave.UseVisualStyleBackColor = true;
            // 
            // btnQuickLoad
            // 
            btnQuickLoad.Location = new System.Drawing.Point(330, 73);
            btnQuickLoad.Margin = new System.Windows.Forms.Padding(2);
            btnQuickLoad.Name = "btnQuickLoad";
            btnQuickLoad.Size = new System.Drawing.Size(47, 20);
            btnQuickLoad.TabIndex = 38;
            btnQuickLoad.Text = "Load";
            btnQuickLoad.UseVisualStyleBackColor = true;
            // 
            // pnlCharBruteforce
            // 
            pnlCharBruteforce.Controls.Add(tbCharBruteforce);
            pnlCharBruteforce.Controls.Add(grpGeneral);
            pnlCharBruteforce.Location = new System.Drawing.Point(384, 104);
            pnlCharBruteforce.Name = "pnlCharBruteforce";
            pnlCharBruteforce.Size = new System.Drawing.Size(455, 586);
            pnlCharBruteforce.TabIndex = 32;
            // 
            // tbCharBruteforce
            // 
            tbCharBruteforce.Controls.Add(tabBruteforceMain);
            tbCharBruteforce.Controls.Add(tabBruteforceDict);
            tbCharBruteforce.Controls.Add(tabBruteforceDictFirstWord);
            tbCharBruteforce.Controls.Add(tabBruteforceDictLastWord);
            tbCharBruteforce.Location = new System.Drawing.Point(6, 150);
            tbCharBruteforce.Name = "tbCharBruteforce";
            tbCharBruteforce.SelectedIndex = 0;
            tbCharBruteforce.Size = new System.Drawing.Size(446, 432);
            tbCharBruteforce.TabIndex = 44;
            // 
            // tabBruteforceMain
            // 
            tabBruteforceMain.Controls.Add(grpSpecials);
            tabBruteforceMain.Controls.Add(grpCharsetPreview);
            tabBruteforceMain.Location = new System.Drawing.Point(4, 24);
            tabBruteforceMain.Name = "tabBruteforceMain";
            tabBruteforceMain.Padding = new System.Windows.Forms.Padding(3);
            tabBruteforceMain.Size = new System.Drawing.Size(438, 404);
            tabBruteforceMain.TabIndex = 0;
            tabBruteforceMain.Text = "Bruteforce Characters";
            tabBruteforceMain.UseVisualStyleBackColor = true;
            // 
            // grpSpecials
            // 
            grpSpecials.Controls.Add(chklCharsets);
            grpSpecials.Location = new System.Drawing.Point(0, 4);
            grpSpecials.Name = "grpSpecials";
            grpSpecials.Size = new System.Drawing.Size(215, 400);
            grpSpecials.TabIndex = 41;
            grpSpecials.TabStop = false;
            grpSpecials.Text = "Special charsets";
            // 
            // chklCharsets
            // 
            chklCharsets.FormattingEnabled = true;
            chklCharsets.Location = new System.Drawing.Point(7, 22);
            chklCharsets.Name = "chklCharsets";
            chklCharsets.Size = new System.Drawing.Size(202, 346);
            chklCharsets.TabIndex = 0;
            chklCharsets.SelectedIndexChanged += ChklCharsetsSelectedIndexChanged;
            chklCharsets.SelectedValueChanged += ChklCharsetsSelectedValueChanged;
            // 
            // grpCharsetPreview
            // 
            grpCharsetPreview.Controls.Add(lblStartingValidCharsPreview);
            grpCharsetPreview.Controls.Add(txtStartingValidCharsPreview);
            grpCharsetPreview.Controls.Add(lblValidCharsPreview);
            grpCharsetPreview.Controls.Add(txtValidCharsPreview);
            grpCharsetPreview.Location = new System.Drawing.Point(221, 4);
            grpCharsetPreview.Name = "grpCharsetPreview";
            grpCharsetPreview.Size = new System.Drawing.Size(207, 401);
            grpCharsetPreview.TabIndex = 43;
            grpCharsetPreview.TabStop = false;
            grpCharsetPreview.Text = "Charset Previews";
            // 
            // lblStartingValidCharsPreview
            // 
            lblStartingValidCharsPreview.AutoSize = true;
            lblStartingValidCharsPreview.Location = new System.Drawing.Point(9, 215);
            lblStartingValidCharsPreview.Name = "lblStartingValidCharsPreview";
            lblStartingValidCharsPreview.Size = new System.Drawing.Size(84, 15);
            lblStartingValidCharsPreview.TabIndex = 43;
            lblStartingValidCharsPreview.Text = "Starting Chars:";
            // 
            // txtStartingValidCharsPreview
            // 
            txtStartingValidCharsPreview.Location = new System.Drawing.Point(9, 236);
            txtStartingValidCharsPreview.Multiline = true;
            txtStartingValidCharsPreview.Name = "txtStartingValidCharsPreview";
            txtStartingValidCharsPreview.ReadOnly = true;
            txtStartingValidCharsPreview.Size = new System.Drawing.Size(190, 150);
            txtStartingValidCharsPreview.TabIndex = 42;
            // 
            // lblValidCharsPreview
            // 
            lblValidCharsPreview.AutoSize = true;
            lblValidCharsPreview.Location = new System.Drawing.Point(9, 21);
            lblValidCharsPreview.Name = "lblValidCharsPreview";
            lblValidCharsPreview.Size = new System.Drawing.Size(68, 15);
            lblValidCharsPreview.TabIndex = 41;
            lblValidCharsPreview.Text = "Valid Chars:";
            // 
            // txtValidCharsPreview
            // 
            txtValidCharsPreview.Location = new System.Drawing.Point(9, 43);
            txtValidCharsPreview.Multiline = true;
            txtValidCharsPreview.Name = "txtValidCharsPreview";
            txtValidCharsPreview.ReadOnly = true;
            txtValidCharsPreview.Size = new System.Drawing.Size(190, 150);
            txtValidCharsPreview.TabIndex = 0;
            // 
            // tabBruteforceDict
            // 
            tabBruteforceDict.Controls.Add(pnlHybridDict);
            tabBruteforceDict.Location = new System.Drawing.Point(4, 24);
            tabBruteforceDict.Name = "tabBruteforceDict";
            tabBruteforceDict.Padding = new System.Windows.Forms.Padding(3);
            tabBruteforceDict.Size = new System.Drawing.Size(438, 404);
            tabBruteforceDict.TabIndex = 1;
            tabBruteforceDict.Text = "Dictionnary";
            tabBruteforceDict.UseVisualStyleBackColor = true;
            // 
            // pnlHybridDict
            // 
            pnlHybridDict.Controls.Add(lblHybridHashcatThreshold2);
            pnlHybridDict.Controls.Add(cbHybridHashcatThreshold);
            pnlHybridDict.Controls.Add(lblHybridHashcatThreshold);
            pnlHybridDict.Controls.Add(chkHybridIgnoreSizeFilters);
            pnlHybridDict.Controls.Add(cbHybridBruteForceMaxCharacters);
            pnlHybridDict.Controls.Add(cbHybridBruteForceMinCharacters);
            pnlHybridDict.Controls.Add(lblHybridBruteForceFrom);
            pnlHybridDict.Controls.Add(lblHybridBruteForceUpTo);
            pnlHybridDict.Controls.Add(lblHybridWordsInHash);
            pnlHybridDict.Controls.Add(cbHybridWordsInHash);
            pnlHybridDict.Controls.Add(lblHybridCombination);
            pnlHybridDict.Controls.Add(lblHybridDictUse);
            pnlHybridDict.Controls.Add(chkHybridDictUse);
            pnlHybridDict.Controls.Add(txtHybridDictWords);
            pnlHybridDict.Controls.Add(lblHybridBruteForce);
            pnlHybridDict.Location = new System.Drawing.Point(0, 0);
            pnlHybridDict.Name = "pnlHybridDict";
            pnlHybridDict.Size = new System.Drawing.Size(435, 404);
            pnlHybridDict.TabIndex = 101;
            // 
            // lblHybridHashcatThreshold2
            // 
            lblHybridHashcatThreshold2.AutoSize = true;
            lblHybridHashcatThreshold2.Location = new System.Drawing.Point(48, 348);
            lblHybridHashcatThreshold2.Name = "lblHybridHashcatThreshold2";
            lblHybridHashcatThreshold2.Size = new System.Drawing.Size(62, 15);
            lblHybridHashcatThreshold2.TabIndex = 114;
            lblHybridHashcatThreshold2.Text = "min chars.";
            // 
            // cbHybridHashcatThreshold
            // 
            cbHybridHashcatThreshold.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbHybridHashcatThreshold.DropDownWidth = 80;
            cbHybridHashcatThreshold.FormattingEnabled = true;
            cbHybridHashcatThreshold.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" });
            cbHybridHashcatThreshold.Location = new System.Drawing.Point(8, 346);
            cbHybridHashcatThreshold.Name = "cbHybridHashcatThreshold";
            cbHybridHashcatThreshold.Size = new System.Drawing.Size(38, 23);
            cbHybridHashcatThreshold.TabIndex = 113;
            // 
            // lblHybridHashcatThreshold
            // 
            lblHybridHashcatThreshold.AutoSize = true;
            lblHybridHashcatThreshold.Location = new System.Drawing.Point(10, 325);
            lblHybridHashcatThreshold.Name = "lblHybridHashcatThreshold";
            lblHybridHashcatThreshold.Size = new System.Drawing.Size(108, 15);
            lblHybridHashcatThreshold.TabIndex = 112;
            lblHybridHashcatThreshold.Text = "Hashcat Threshold:";
            // 
            // chkHybridIgnoreSizeFilters
            // 
            chkHybridIgnoreSizeFilters.AutoSize = true;
            chkHybridIgnoreSizeFilters.Location = new System.Drawing.Point(6, 377);
            chkHybridIgnoreSizeFilters.Name = "chkHybridIgnoreSizeFilters";
            chkHybridIgnoreSizeFilters.Size = new System.Drawing.Size(119, 19);
            chkHybridIgnoreSizeFilters.TabIndex = 111;
            chkHybridIgnoreSizeFilters.Text = "Bypass Size Filters";
            chkHybridIgnoreSizeFilters.UseVisualStyleBackColor = true;
            // 
            // cbHybridBruteForceMaxCharacters
            // 
            cbHybridBruteForceMaxCharacters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbHybridBruteForceMaxCharacters.FormattingEnabled = true;
            cbHybridBruteForceMaxCharacters.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11" });
            cbHybridBruteForceMaxCharacters.Location = new System.Drawing.Point(47, 83);
            cbHybridBruteForceMaxCharacters.Name = "cbHybridBruteForceMaxCharacters";
            cbHybridBruteForceMaxCharacters.Size = new System.Drawing.Size(38, 23);
            cbHybridBruteForceMaxCharacters.TabIndex = 99;
            // 
            // cbHybridBruteForceMinCharacters
            // 
            cbHybridBruteForceMinCharacters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbHybridBruteForceMinCharacters.FormattingEnabled = true;
            cbHybridBruteForceMinCharacters.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" });
            cbHybridBruteForceMinCharacters.Location = new System.Drawing.Point(47, 55);
            cbHybridBruteForceMinCharacters.Name = "cbHybridBruteForceMinCharacters";
            cbHybridBruteForceMinCharacters.Size = new System.Drawing.Size(38, 23);
            cbHybridBruteForceMinCharacters.TabIndex = 109;
            // 
            // lblHybridBruteForceFrom
            // 
            lblHybridBruteForceFrom.AutoSize = true;
            lblHybridBruteForceFrom.Location = new System.Drawing.Point(8, 57);
            lblHybridBruteForceFrom.Name = "lblHybridBruteForceFrom";
            lblHybridBruteForceFrom.Size = new System.Drawing.Size(97, 15);
            lblHybridBruteForceFrom.TabIndex = 110;
            lblHybridBruteForceFrom.Text = "from              chrs";
            // 
            // lblHybridBruteForceUpTo
            // 
            lblHybridBruteForceUpTo.AutoSize = true;
            lblHybridBruteForceUpTo.Location = new System.Drawing.Point(9, 84);
            lblHybridBruteForceUpTo.Name = "lblHybridBruteForceUpTo";
            lblHybridBruteForceUpTo.Size = new System.Drawing.Size(96, 15);
            lblHybridBruteForceUpTo.TabIndex = 108;
            lblHybridBruteForceUpTo.Text = "up to             chrs";
            // 
            // lblHybridWordsInHash
            // 
            lblHybridWordsInHash.AutoSize = true;
            lblHybridWordsInHash.Location = new System.Drawing.Point(62, 143);
            lblHybridWordsInHash.Name = "lblHybridWordsInHash";
            lblHybridWordsInHash.Size = new System.Drawing.Size(45, 15);
            lblHybridWordsInHash.TabIndex = 103;
            lblHybridWordsInHash.Text = "in hash";
            // 
            // cbHybridWordsInHash
            // 
            cbHybridWordsInHash.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbHybridWordsInHash.DropDownWidth = 80;
            cbHybridWordsInHash.FormattingEnabled = true;
            cbHybridWordsInHash.Items.AddRange(new object[] { "1 word", "2 words", "3 words", "4 words" });
            cbHybridWordsInHash.Location = new System.Drawing.Point(8, 140);
            cbHybridWordsInHash.Name = "cbHybridWordsInHash";
            cbHybridWordsInHash.Size = new System.Drawing.Size(50, 23);
            cbHybridWordsInHash.TabIndex = 102;
            // 
            // lblHybridCombination
            // 
            lblHybridCombination.AutoSize = true;
            lblHybridCombination.Location = new System.Drawing.Point(6, 120);
            lblHybridCombination.Name = "lblHybridCombination";
            lblHybridCombination.Size = new System.Drawing.Size(85, 15);
            lblHybridCombination.TabIndex = 101;
            lblHybridCombination.Text = "Combinations:";
            // 
            // lblHybridDictUse
            // 
            lblHybridDictUse.AutoSize = true;
            lblHybridDictUse.Location = new System.Drawing.Point(6, 7);
            lblHybridDictUse.Name = "lblHybridDictUse";
            lblHybridDictUse.Size = new System.Drawing.Size(29, 15);
            lblHybridDictUse.TabIndex = 94;
            lblHybridDictUse.Text = "Use:";
            // 
            // chkHybridDictUse
            // 
            chkHybridDictUse.AutoSize = true;
            chkHybridDictUse.Location = new System.Drawing.Point(80, 8);
            chkHybridDictUse.Name = "chkHybridDictUse";
            chkHybridDictUse.Size = new System.Drawing.Size(15, 14);
            chkHybridDictUse.TabIndex = 95;
            chkHybridDictUse.UseVisualStyleBackColor = true;
            chkHybridDictUse.CheckedChanged += chkHybridDictUse_CheckedChanged;
            // 
            // txtHybridDictWords
            // 
            txtHybridDictWords.Location = new System.Drawing.Point(137, 2);
            txtHybridDictWords.Margin = new System.Windows.Forms.Padding(2);
            txtHybridDictWords.Multiline = true;
            txtHybridDictWords.Name = "txtHybridDictWords";
            txtHybridDictWords.Size = new System.Drawing.Size(297, 394);
            txtHybridDictWords.TabIndex = 93;
            // 
            // lblHybridBruteForce
            // 
            lblHybridBruteForce.AutoSize = true;
            lblHybridBruteForce.Location = new System.Drawing.Point(6, 36);
            lblHybridBruteForce.Name = "lblHybridBruteForce";
            lblHybridBruteForce.Size = new System.Drawing.Size(65, 15);
            lblHybridBruteForce.TabIndex = 96;
            lblHybridBruteForce.Text = "Bruteforce:";
            // 
            // tabBruteforceDictFirstWord
            // 
            tabBruteforceDictFirstWord.Controls.Add(pnlHybridDictFirstWord);
            tabBruteforceDictFirstWord.Location = new System.Drawing.Point(4, 24);
            tabBruteforceDictFirstWord.Name = "tabBruteforceDictFirstWord";
            tabBruteforceDictFirstWord.Size = new System.Drawing.Size(438, 404);
            tabBruteforceDictFirstWord.TabIndex = 2;
            tabBruteforceDictFirstWord.Text = "First Word Overrides";
            tabBruteforceDictFirstWord.UseVisualStyleBackColor = true;
            // 
            // pnlHybridDictFirstWord
            // 
            pnlHybridDictFirstWord.Controls.Add(lblHybridDictFirstWordUse);
            pnlHybridDictFirstWord.Controls.Add(txtHybridDictFirstWord);
            pnlHybridDictFirstWord.Controls.Add(chkHybridDictFirstWordUse);
            pnlHybridDictFirstWord.Location = new System.Drawing.Point(0, 0);
            pnlHybridDictFirstWord.Name = "pnlHybridDictFirstWord";
            pnlHybridDictFirstWord.Size = new System.Drawing.Size(435, 404);
            pnlHybridDictFirstWord.TabIndex = 99;
            // 
            // lblHybridDictFirstWordUse
            // 
            lblHybridDictFirstWordUse.AutoSize = true;
            lblHybridDictFirstWordUse.Location = new System.Drawing.Point(6, 7);
            lblHybridDictFirstWordUse.Name = "lblHybridDictFirstWordUse";
            lblHybridDictFirstWordUse.Size = new System.Drawing.Size(29, 15);
            lblHybridDictFirstWordUse.TabIndex = 97;
            lblHybridDictFirstWordUse.Text = "Use:";
            // 
            // txtHybridDictFirstWord
            // 
            txtHybridDictFirstWord.Location = new System.Drawing.Point(137, 2);
            txtHybridDictFirstWord.Margin = new System.Windows.Forms.Padding(2);
            txtHybridDictFirstWord.Multiline = true;
            txtHybridDictFirstWord.Name = "txtHybridDictFirstWord";
            txtHybridDictFirstWord.Size = new System.Drawing.Size(318, 394);
            txtHybridDictFirstWord.TabIndex = 96;
            // 
            // chkHybridDictFirstWordUse
            // 
            chkHybridDictFirstWordUse.AutoSize = true;
            chkHybridDictFirstWordUse.Location = new System.Drawing.Point(80, 8);
            chkHybridDictFirstWordUse.Name = "chkHybridDictFirstWordUse";
            chkHybridDictFirstWordUse.Size = new System.Drawing.Size(15, 14);
            chkHybridDictFirstWordUse.TabIndex = 98;
            chkHybridDictFirstWordUse.UseVisualStyleBackColor = true;
            chkHybridDictFirstWordUse.CheckedChanged += chkHybridDictFirstWordUse_CheckedChanged;
            // 
            // tabBruteforceDictLastWord
            // 
            tabBruteforceDictLastWord.Controls.Add(pnlHybridDictLastWord);
            tabBruteforceDictLastWord.Location = new System.Drawing.Point(4, 24);
            tabBruteforceDictLastWord.Name = "tabBruteforceDictLastWord";
            tabBruteforceDictLastWord.Size = new System.Drawing.Size(438, 404);
            tabBruteforceDictLastWord.TabIndex = 3;
            tabBruteforceDictLastWord.Text = "Last Word Overrides";
            tabBruteforceDictLastWord.UseVisualStyleBackColor = true;
            // 
            // pnlHybridDictLastWord
            // 
            pnlHybridDictLastWord.Controls.Add(lblHybridDictLastWordUse);
            pnlHybridDictLastWord.Controls.Add(txtHybridDictLastWord);
            pnlHybridDictLastWord.Controls.Add(chkHybridDictLastWordUse);
            pnlHybridDictLastWord.Location = new System.Drawing.Point(0, 0);
            pnlHybridDictLastWord.Name = "pnlHybridDictLastWord";
            pnlHybridDictLastWord.Size = new System.Drawing.Size(435, 404);
            pnlHybridDictLastWord.TabIndex = 99;
            // 
            // lblHybridDictLastWordUse
            // 
            lblHybridDictLastWordUse.AutoSize = true;
            lblHybridDictLastWordUse.Location = new System.Drawing.Point(6, 7);
            lblHybridDictLastWordUse.Name = "lblHybridDictLastWordUse";
            lblHybridDictLastWordUse.Size = new System.Drawing.Size(29, 15);
            lblHybridDictLastWordUse.TabIndex = 97;
            lblHybridDictLastWordUse.Text = "Use:";
            // 
            // txtHybridDictLastWord
            // 
            txtHybridDictLastWord.Location = new System.Drawing.Point(137, 2);
            txtHybridDictLastWord.Margin = new System.Windows.Forms.Padding(2);
            txtHybridDictLastWord.Multiline = true;
            txtHybridDictLastWord.Name = "txtHybridDictLastWord";
            txtHybridDictLastWord.Size = new System.Drawing.Size(318, 394);
            txtHybridDictLastWord.TabIndex = 96;
            // 
            // chkHybridDictLastWordUse
            // 
            chkHybridDictLastWordUse.AutoSize = true;
            chkHybridDictLastWordUse.Location = new System.Drawing.Point(80, 8);
            chkHybridDictLastWordUse.Name = "chkHybridDictLastWordUse";
            chkHybridDictLastWordUse.Size = new System.Drawing.Size(15, 14);
            chkHybridDictLastWordUse.TabIndex = 98;
            chkHybridDictLastWordUse.UseVisualStyleBackColor = true;
            chkHybridDictLastWordUse.CheckedChanged += chkHybridDictLastWordUse_CheckedChanged;
            // 
            // grpGeneral
            // 
            grpGeneral.Controls.Add(txtValidChars);
            grpGeneral.Controls.Add(lblValidChars);
            grpGeneral.Controls.Add(txtHashCatPath);
            grpGeneral.Controls.Add(lblUtf8Toggle);
            grpGeneral.Controls.Add(lblHashCat);
            grpGeneral.Controls.Add(lblStartingValidChars);
            grpGeneral.Controls.Add(chkUtf8Toggle);
            grpGeneral.Controls.Add(txtStartingValidChars);
            grpGeneral.Location = new System.Drawing.Point(6, 4);
            grpGeneral.Name = "grpGeneral";
            grpGeneral.Size = new System.Drawing.Size(444, 140);
            grpGeneral.TabIndex = 42;
            grpGeneral.TabStop = false;
            grpGeneral.Text = "Bruteforce Settings";
            // 
            // txtValidChars
            // 
            txtValidChars.Location = new System.Drawing.Point(120, 19);
            txtValidChars.Name = "txtValidChars";
            txtValidChars.Size = new System.Drawing.Size(317, 23);
            txtValidChars.TabIndex = 31;
            txtValidChars.Text = "etainoshrdlucmfwygpbvkqjxz0123456789_";
            txtValidChars.TextChanged += TxtValidCharsChanged;
            // 
            // lblValidChars
            // 
            lblValidChars.AutoSize = true;
            lblValidChars.Location = new System.Drawing.Point(12, 22);
            lblValidChars.Name = "lblValidChars";
            lblValidChars.Size = new System.Drawing.Size(68, 15);
            lblValidChars.TabIndex = 31;
            lblValidChars.Text = "Valid Chars:";
            // 
            // txtHashCatPath
            // 
            txtHashCatPath.Location = new System.Drawing.Point(120, 81);
            txtHashCatPath.Name = "txtHashCatPath";
            txtHashCatPath.Size = new System.Drawing.Size(317, 23);
            txtHashCatPath.TabIndex = 39;
            // 
            // lblUtf8Toggle
            // 
            lblUtf8Toggle.AutoSize = true;
            lblUtf8Toggle.Location = new System.Drawing.Point(12, 113);
            lblUtf8Toggle.Name = "lblUtf8Toggle";
            lblUtf8Toggle.Size = new System.Drawing.Size(74, 15);
            lblUtf8Toggle.TabIndex = 37;
            lblUtf8Toggle.Text = "Enable UTF8:";
            // 
            // lblHashCat
            // 
            lblHashCat.AutoSize = true;
            lblHashCat.Location = new System.Drawing.Point(12, 84);
            lblHashCat.Name = "lblHashCat";
            lblHashCat.Size = new System.Drawing.Size(80, 15);
            lblHashCat.TabIndex = 38;
            lblHashCat.Text = "Hashcat Path:";
            // 
            // lblStartingValidChars
            // 
            lblStartingValidChars.AutoSize = true;
            lblStartingValidChars.Location = new System.Drawing.Point(12, 53);
            lblStartingValidChars.Name = "lblStartingValidChars";
            lblStartingValidChars.Size = new System.Drawing.Size(84, 15);
            lblStartingValidChars.TabIndex = 32;
            lblStartingValidChars.Text = "Starting Chars:";
            // 
            // chkUtf8Toggle
            // 
            chkUtf8Toggle.AutoSize = true;
            chkUtf8Toggle.Location = new System.Drawing.Point(120, 113);
            chkUtf8Toggle.Name = "chkUtf8Toggle";
            chkUtf8Toggle.Size = new System.Drawing.Size(15, 14);
            chkUtf8Toggle.TabIndex = 40;
            chkUtf8Toggle.UseVisualStyleBackColor = true;
            chkUtf8Toggle.CheckedChanged += Utf8ToggleCheckedChanged;
            // 
            // txtStartingValidChars
            // 
            txtStartingValidChars.Location = new System.Drawing.Point(120, 50);
            txtStartingValidChars.Name = "txtStartingValidChars";
            txtStartingValidChars.Size = new System.Drawing.Size(317, 23);
            txtStartingValidChars.TabIndex = 33;
            txtStartingValidChars.Text = "etainoshrdlucmfwygpbvkqjxz_";
            txtStartingValidChars.TextChanged += TxtStartingValidCharsChanged;
            // 
            // Main
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new System.Drawing.Size(848, 730);
            Controls.Add(btnQuickLoad);
            Controls.Add(btnQuickSave);
            Controls.Add(btnStartHashCat);
            Controls.Add(lblVerbose);
            Controls.Add(chkVerbose);
            Controls.Add(txtDelimiter);
            Controls.Add(lblDelimiter);
            Controls.Add(txtSuffix);
            Controls.Add(lblSuffix);
            Controls.Add(btnStart);
            Controls.Add(cbNbThreads);
            Controls.Add(lblNbThreads);
            Controls.Add(txtPrefix);
            Controls.Add(lblPrefix);
            Controls.Add(cbMethod);
            Controls.Add(lblMethod);
            Controls.Add(txtHexValues);
            Controls.Add(lblHexValues);
            Controls.Add(mnStrip);
            Controls.Add(pnlCharBruteforce);
            Controls.Add(pnlDictionary);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MainMenuStrip = mnStrip;
            MaximizeBox = false;
            Name = "Main";
            Text = "BruteForceHash";
            pnlDictionary.ResumeLayout(false);
            grpSizeFiltering.ResumeLayout(false);
            grpSizeFiltering.PerformLayout();
            grpWordFiltering.ResumeLayout(false);
            grpWordFiltering.PerformLayout();
            grpAdvanced.ResumeLayout(false);
            grpAdvanced.PerformLayout();
            grpTypos.ResumeLayout(false);
            grpTypos.PerformLayout();
            pnlDictBruteforce.ResumeLayout(false);
            tabControl.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabMainDictionaries.ResumeLayout(false);
            tabMainDictionariesCommon.ResumeLayout(false);
            tabMainDictionariesCommon.PerformLayout();
            tabMainDictionariesCustom.ResumeLayout(false);
            tabMainDictionariesCustom.PerformLayout();
            tabMainDictionariesExcludeWords.ResumeLayout(false);
            tabMainDictionariesExcludeWords.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabFirstWordDictionaries.ResumeLayout(false);
            tabFirstWordDictionariesCommon.ResumeLayout(false);
            tabFirstWordDictionariesCommon.PerformLayout();
            tabFirstWordDictionariesCustom.ResumeLayout(false);
            tabFirstWordDictionariesCustom.PerformLayout();
            tabFirstWordDictionariesExcludeWords.ResumeLayout(false);
            tabFirstWordDictionariesExcludeWords.PerformLayout();
            tabPage3.ResumeLayout(false);
            tabLastWordDictionaries.ResumeLayout(false);
            tabLastWordDictionariesCommon.ResumeLayout(false);
            tabLastWordDictionariesCommon.PerformLayout();
            tabLastWordDictionariesCustom.ResumeLayout(false);
            tabLastWordDictionariesCustom.PerformLayout();
            tabLastWordDictionariesExcludeWords.ResumeLayout(false);
            tabLastWordDictionariesExcludeWords.PerformLayout();
            mnStrip.ResumeLayout(false);
            mnStrip.PerformLayout();
            pnlCharBruteforce.ResumeLayout(false);
            tbCharBruteforce.ResumeLayout(false);
            tabBruteforceMain.ResumeLayout(false);
            grpSpecials.ResumeLayout(false);
            grpCharsetPreview.ResumeLayout(false);
            grpCharsetPreview.PerformLayout();
            tabBruteforceDict.ResumeLayout(false);
            pnlHybridDict.ResumeLayout(false);
            pnlHybridDict.PerformLayout();
            tabBruteforceDictFirstWord.ResumeLayout(false);
            pnlHybridDictFirstWord.ResumeLayout(false);
            pnlHybridDictFirstWord.PerformLayout();
            tabBruteforceDictLastWord.ResumeLayout(false);
            pnlHybridDictLastWord.ResumeLayout(false);
            pnlHybridDictLastWord.PerformLayout();
            grpGeneral.ResumeLayout(false);
            grpGeneral.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
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
        private System.Windows.Forms.CheckBox chkDictionariesCustomWordsMinimumInHashUseTypos;
    }
}


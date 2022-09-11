
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
            this.cbMaxFours = new System.Windows.Forms.ComboBox();
            this.lblFours = new System.Windows.Forms.Label();
            this.cbMinThrees = new System.Windows.Forms.ComboBox();
            this.lblToThrees = new System.Windows.Forms.Label();
            this.cbMaxThrees = new System.Windows.Forms.ComboBox();
            this.lblThrees = new System.Windows.Forms.Label();
            this.cbMinTwos = new System.Windows.Forms.ComboBox();
            this.lblToTwos = new System.Windows.Forms.Label();
            this.cbMaxTwos = new System.Windows.Forms.ComboBox();
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
            this.groupBoxWordFiltering = new System.Windows.Forms.GroupBox();
            this.cbIncludePatternsSamples = new System.Windows.Forms.ComboBox();
            this.cbExcludePatternsSamples = new System.Windows.Forms.ComboBox();
            this.cbCombinationOrder = new System.Windows.Forms.ComboBox();
            this.chkIncludeWordNotLast = new System.Windows.Forms.CheckBox();
            this.chkIncludeWordNotFirst = new System.Windows.Forms.CheckBox();
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
            this.txtTyposSwapLetters = new System.Windows.Forms.TextBox();
            this.lblTyposSwapLetters = new System.Windows.Forms.Label();
            this.chkTyposReverseLetter = new System.Windows.Forms.CheckBox();
            this.chkTyposWrongLetter = new System.Windows.Forms.CheckBox();
            this.chkTyposExtraLetter = new System.Windows.Forms.CheckBox();
            this.chkTyposDoubleLetter = new System.Windows.Forms.CheckBox();
            this.chkTyposSkipLetter = new System.Windows.Forms.CheckBox();
            this.chkTyposSkipDoubleLetter = new System.Windows.Forms.CheckBox();
            this.txtIncludeWordsCharacter = new System.Windows.Forms.TextBox();
            this.pnlCharacter = new System.Windows.Forms.Panel();
            this.grpCharsetPreview = new System.Windows.Forms.GroupBox();
            this.lblStartingValidCharsPreview = new System.Windows.Forms.Label();
            this.txtStartingValidCharsPreview = new System.Windows.Forms.TextBox();
            this.lblValidCharsPreview = new System.Windows.Forms.Label();
            this.txtValidCharsPreview = new System.Windows.Forms.TextBox();
            this.grpGeneral = new System.Windows.Forms.GroupBox();
            this.txtValidChars = new System.Windows.Forms.TextBox();
            this.lblValidChars = new System.Windows.Forms.Label();
            this.lblUtf8Toggle = new System.Windows.Forms.Label();
            this.lblStartingValidChars = new System.Windows.Forms.Label();
            this.lblEndPosition = new System.Windows.Forms.Label();
            this.chkUtf8Toggle = new System.Windows.Forms.CheckBox();
            this.txtStartingValidChars = new System.Windows.Forms.TextBox();
            this.lblIncludeWordCharacters = new System.Windows.Forms.Label();
            this.numEndPosition = new System.Windows.Forms.NumericUpDown();
            this.lblStartPosition = new System.Windows.Forms.Label();
            this.numStartPosition = new System.Windows.Forms.NumericUpDown();
            this.grpSpecials = new System.Windows.Forms.GroupBox();
            this.chklCharsets = new System.Windows.Forms.CheckedListBox();
            this.txtHashCatPath = new System.Windows.Forms.TextBox();
            this.lblHashCat = new System.Windows.Forms.Label();
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
            this.lblTyposAppendLetters = new System.Windows.Forms.Label();
            this.txtTyposAppendLetters = new System.Windows.Forms.TextBox();
            this.pnlDictionary.SuspendLayout();
            this.grpSizeFiltering.SuspendLayout();
            this.groupBoxWordFiltering.SuspendLayout();
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
            this.grpAdvanced.SuspendLayout();
            this.grpTypos.SuspendLayout();
            this.pnlCharacter.SuspendLayout();
            this.grpCharsetPreview.SuspendLayout();
            this.grpGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numEndPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStartPosition)).BeginInit();
            this.grpSpecials.SuspendLayout();
            this.mnStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblHexValues
            // 
            this.lblHexValues.AutoSize = true;
            this.lblHexValues.Location = new System.Drawing.Point(16, 76);
            this.lblHexValues.Name = "lblHexValues";
            this.lblHexValues.Size = new System.Drawing.Size(75, 15);
            this.lblHexValues.TabIndex = 0;
            this.lblHexValues.Text = "Hex Value(s):";
            // 
            // txtHexValues
            // 
            this.txtHexValues.Location = new System.Drawing.Point(123, 74);
            this.txtHexValues.Name = "txtHexValues";
            this.txtHexValues.PlaceholderText = "0x105274ba4f";
            this.txtHexValues.Size = new System.Drawing.Size(160, 23);
            this.txtHexValues.TabIndex = 1;
            this.txtHexValues.TextChanged += new System.EventHandler(this.txtHexValues_TextChanged);
            // 
            // lblMethod
            // 
            this.lblMethod.AutoSize = true;
            this.lblMethod.Location = new System.Drawing.Point(16, 36);
            this.lblMethod.Name = "lblMethod";
            this.lblMethod.Size = new System.Drawing.Size(71, 15);
            this.lblMethod.TabIndex = 2;
            this.lblMethod.Text = "Attack Type:";
            // 
            // cbMethod
            // 
            this.cbMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMethod.FormattingEnabled = true;
            this.cbMethod.Items.AddRange(new object[] {
            "Dictionary",
            "Character"});
            this.cbMethod.Location = new System.Drawing.Point(123, 33);
            this.cbMethod.Name = "cbMethod";
            this.cbMethod.Size = new System.Drawing.Size(160, 23);
            this.cbMethod.TabIndex = 3;
            this.cbMethod.SelectedIndexChanged += new System.EventHandler(this.OnCbMethodChanged);
            // 
            // lblPrefix
            // 
            this.lblPrefix.AutoSize = true;
            this.lblPrefix.Location = new System.Drawing.Point(409, 76);
            this.lblPrefix.Name = "lblPrefix";
            this.lblPrefix.Size = new System.Drawing.Size(40, 15);
            this.lblPrefix.TabIndex = 4;
            this.lblPrefix.Text = "Prefix:";
            // 
            // txtPrefix
            // 
            this.txtPrefix.Location = new System.Drawing.Point(480, 74);
            this.txtPrefix.Name = "txtPrefix";
            this.txtPrefix.Size = new System.Drawing.Size(143, 23);
            this.txtPrefix.TabIndex = 5;
            // 
            // lblDelimiter
            // 
            this.lblDelimiter.AutoSize = true;
            this.lblDelimiter.Location = new System.Drawing.Point(599, 36);
            this.lblDelimiter.Name = "lblDelimiter";
            this.lblDelimiter.Size = new System.Drawing.Size(58, 15);
            this.lblDelimiter.TabIndex = 6;
            this.lblDelimiter.Text = "Delimiter:";
            // 
            // txtDelimiter
            // 
            this.txtDelimiter.Location = new System.Drawing.Point(680, 32);
            this.txtDelimiter.MaxLength = 1;
            this.txtDelimiter.Name = "txtDelimiter";
            this.txtDelimiter.Size = new System.Drawing.Size(27, 23);
            this.txtDelimiter.TabIndex = 7;
            this.txtDelimiter.Text = "_";
            this.txtDelimiter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblNbThreads
            // 
            this.lblNbThreads.AutoSize = true;
            this.lblNbThreads.Location = new System.Drawing.Point(409, 36);
            this.lblNbThreads.Name = "lblNbThreads";
            this.lblNbThreads.Size = new System.Drawing.Size(51, 15);
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
            this.cbNbThreads.Location = new System.Drawing.Point(480, 34);
            this.cbNbThreads.Name = "cbNbThreads";
            this.cbNbThreads.Size = new System.Drawing.Size(78, 23);
            this.cbNbThreads.TabIndex = 13;
            // 
            // lblExcludePatterns
            // 
            this.lblExcludePatterns.AutoSize = true;
            this.lblExcludePatterns.Location = new System.Drawing.Point(6, 22);
            this.lblExcludePatterns.Name = "lblExcludePatterns";
            this.lblExcludePatterns.Size = new System.Drawing.Size(97, 15);
            this.lblExcludePatterns.TabIndex = 14;
            this.lblExcludePatterns.Text = "Exclude Patterns:";
            // 
            // txtExcludePatterns
            // 
            this.txtExcludePatterns.Location = new System.Drawing.Point(121, 20);
            this.txtExcludePatterns.Name = "txtExcludePatterns";
            this.txtExcludePatterns.PlaceholderText = "{1}_{1},{2}_{2}";
            this.txtExcludePatterns.Size = new System.Drawing.Size(188, 23);
            this.txtExcludePatterns.TabIndex = 15;
            // 
            // lblIncludePatterns
            // 
            this.lblIncludePatterns.AutoSize = true;
            this.lblIncludePatterns.Location = new System.Drawing.Point(6, 53);
            this.lblIncludePatterns.Name = "lblIncludePatterns";
            this.lblIncludePatterns.Size = new System.Drawing.Size(95, 15);
            this.lblIncludePatterns.TabIndex = 16;
            this.lblIncludePatterns.Text = "Include Patterns:";
            // 
            // txtIncludePatterns
            // 
            this.txtIncludePatterns.Location = new System.Drawing.Point(121, 50);
            this.txtIncludePatterns.Name = "txtIncludePatterns";
            this.txtIncludePatterns.PlaceholderText = "{3}";
            this.txtIncludePatterns.Size = new System.Drawing.Size(188, 23);
            this.txtIncludePatterns.TabIndex = 17;
            // 
            // lblIncludeWord
            // 
            this.lblIncludeWord.AutoSize = true;
            this.lblIncludeWord.Location = new System.Drawing.Point(6, 87);
            this.lblIncludeWord.Name = "lblIncludeWord";
            this.lblIncludeWord.Size = new System.Drawing.Size(81, 15);
            this.lblIncludeWord.TabIndex = 18;
            this.lblIncludeWord.Text = "Include Word:";
            // 
            // txtIncludeWord
            // 
            this.txtIncludeWord.Location = new System.Drawing.Point(120, 83);
            this.txtIncludeWord.Name = "txtIncludeWord";
            this.txtIncludeWord.PlaceholderText = "mario,luigi";
            this.txtIncludeWord.Size = new System.Drawing.Size(114, 23);
            this.txtIncludeWord.TabIndex = 19;
            // 
            // lblWordsLimit
            // 
            this.lblWordsLimit.AutoSize = true;
            this.lblWordsLimit.Location = new System.Drawing.Point(236, 125);
            this.lblWordsLimit.Name = "lblWordsLimit";
            this.lblWordsLimit.Size = new System.Drawing.Size(74, 15);
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
            this.cbWordsLimit.Location = new System.Drawing.Point(314, 122);
            this.cbWordsLimit.Name = "cbWordsLimit";
            this.cbWordsLimit.Size = new System.Drawing.Size(38, 23);
            this.cbWordsLimit.TabIndex = 21;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(175, 694);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(213, 22);
            this.btnStart.TabIndex = 24;
            this.btnStart.Text = "START";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.OnBtnStartClick);
            // 
            // lblSuffix
            // 
            this.lblSuffix.AutoSize = true;
            this.lblSuffix.Location = new System.Drawing.Point(635, 76);
            this.lblSuffix.Name = "lblSuffix";
            this.lblSuffix.Size = new System.Drawing.Size(40, 15);
            this.lblSuffix.TabIndex = 27;
            this.lblSuffix.Text = "Suffix:";
            // 
            // txtSuffix
            // 
            this.txtSuffix.Location = new System.Drawing.Point(682, 74);
            this.txtSuffix.Name = "txtSuffix";
            this.txtSuffix.Size = new System.Drawing.Size(154, 23);
            this.txtSuffix.TabIndex = 28;
            // 
            // lblCombinationOrder
            // 
            this.lblCombinationOrder.AutoSize = true;
            this.lblCombinationOrder.Location = new System.Drawing.Point(10, 125);
            this.lblCombinationOrder.Name = "lblCombinationOrder";
            this.lblCombinationOrder.Size = new System.Drawing.Size(40, 15);
            this.lblCombinationOrder.TabIndex = 29;
            this.lblCombinationOrder.Text = "Order:";
            // 
            // pnlDictionary
            // 
            this.pnlDictionary.Controls.Add(this.grpSizeFiltering);
            this.pnlDictionary.Controls.Add(this.groupBoxWordFiltering);
            this.pnlDictionary.Controls.Add(this.tabControl);
            this.pnlDictionary.Controls.Add(this.grpAdvanced);
            this.pnlDictionary.Controls.Add(this.grpTypos);
            this.pnlDictionary.Location = new System.Drawing.Point(12, 104);
            this.pnlDictionary.Name = "pnlDictionary";
            this.pnlDictionary.Size = new System.Drawing.Size(827, 586);
            this.pnlDictionary.TabIndex = 31;
            // 
            // grpSizeFiltering
            // 
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
            this.grpSizeFiltering.Controls.Add(this.cbMaxFours);
            this.grpSizeFiltering.Controls.Add(this.lblFours);
            this.grpSizeFiltering.Controls.Add(this.cbMinThrees);
            this.grpSizeFiltering.Controls.Add(this.lblToThrees);
            this.grpSizeFiltering.Controls.Add(this.cbMaxThrees);
            this.grpSizeFiltering.Controls.Add(this.lblThrees);
            this.grpSizeFiltering.Controls.Add(this.cbMinTwos);
            this.grpSizeFiltering.Controls.Add(this.lblToTwos);
            this.grpSizeFiltering.Controls.Add(this.cbMaxTwos);
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
            this.grpSizeFiltering.Location = new System.Drawing.Point(7, 164);
            this.grpSizeFiltering.Margin = new System.Windows.Forms.Padding(2);
            this.grpSizeFiltering.Name = "grpSizeFiltering";
            this.grpSizeFiltering.Padding = new System.Windows.Forms.Padding(2);
            this.grpSizeFiltering.Size = new System.Drawing.Size(364, 182);
            this.grpSizeFiltering.TabIndex = 86;
            this.grpSizeFiltering.TabStop = false;
            this.grpSizeFiltering.Text = "Size Filtering";
            // 
            // cbAtMostUnderNbrChars
            // 
            this.cbAtMostUnderNbrChars.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAtMostUnderNbrChars.DropDownWidth = 90;
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
            this.cbAtMostUnderNbrChars.Location = new System.Drawing.Point(306, 153);
            this.cbAtMostUnderNbrChars.Name = "cbAtMostUnderNbrChars";
            this.cbAtMostUnderNbrChars.Size = new System.Drawing.Size(45, 23);
            this.cbAtMostUnderNbrChars.TabIndex = 98;
            // 
            // cbAtMostAboveNbrChars
            // 
            this.cbAtMostAboveNbrChars.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAtMostAboveNbrChars.DropDownWidth = 90;
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
            this.cbAtMostAboveNbrChars.Location = new System.Drawing.Point(306, 127);
            this.cbAtMostAboveNbrChars.Name = "cbAtMostAboveNbrChars";
            this.cbAtMostAboveNbrChars.Size = new System.Drawing.Size(45, 23);
            this.cbAtMostAboveNbrChars.TabIndex = 97;
            // 
            // cbAtMostUnderNbrWords
            // 
            this.cbAtMostUnderNbrWords.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAtMostUnderNbrWords.DropDownWidth = 70;
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
            this.cbAtMostUnderNbrWords.Location = new System.Drawing.Point(237, 153);
            this.cbAtMostUnderNbrWords.Name = "cbAtMostUnderNbrWords";
            this.cbAtMostUnderNbrWords.Size = new System.Drawing.Size(45, 23);
            this.cbAtMostUnderNbrWords.TabIndex = 96;
            // 
            // cbAtMostAboveNbrWords
            // 
            this.cbAtMostAboveNbrWords.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAtMostAboveNbrWords.DropDownWidth = 70;
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
            this.cbAtMostAboveNbrWords.Location = new System.Drawing.Point(237, 127);
            this.cbAtMostAboveNbrWords.Name = "cbAtMostAboveNbrWords";
            this.cbAtMostAboveNbrWords.Size = new System.Drawing.Size(45, 23);
            this.cbAtMostAboveNbrWords.TabIndex = 95;
            // 
            // lblAtMostUnder
            // 
            this.lblAtMostUnder.AutoSize = true;
            this.lblAtMostUnder.Location = new System.Drawing.Point(188, 157);
            this.lblAtMostUnder.Name = "lblAtMostUnder";
            this.lblAtMostUnder.Size = new System.Drawing.Size(114, 15);
            this.lblAtMostUnder.TabIndex = 94;
            this.lblAtMostUnder.Text = "At most                   ≤";
            // 
            // lblAtMostAbove
            // 
            this.lblAtMostAbove.AutoSize = true;
            this.lblAtMostAbove.Location = new System.Drawing.Point(188, 130);
            this.lblAtMostAbove.Name = "lblAtMostAbove";
            this.lblAtMostAbove.Size = new System.Drawing.Size(114, 15);
            this.lblAtMostAbove.TabIndex = 93;
            this.lblAtMostAbove.Text = "At most                   ≥";
            // 
            // cbAtLeastUnderNbrChars
            // 
            this.cbAtLeastUnderNbrChars.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAtLeastUnderNbrChars.DropDownWidth = 90;
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
            this.cbAtLeastUnderNbrChars.Location = new System.Drawing.Point(306, 101);
            this.cbAtLeastUnderNbrChars.Name = "cbAtLeastUnderNbrChars";
            this.cbAtLeastUnderNbrChars.Size = new System.Drawing.Size(45, 23);
            this.cbAtLeastUnderNbrChars.TabIndex = 92;
            // 
            // cbAtLeastUnderNbrWords
            // 
            this.cbAtLeastUnderNbrWords.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAtLeastUnderNbrWords.DropDownWidth = 70;
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
            this.cbAtLeastUnderNbrWords.Location = new System.Drawing.Point(237, 101);
            this.cbAtLeastUnderNbrWords.Name = "cbAtLeastUnderNbrWords";
            this.cbAtLeastUnderNbrWords.Size = new System.Drawing.Size(45, 23);
            this.cbAtLeastUnderNbrWords.TabIndex = 87;
            // 
            // lblAtLeastUnder
            // 
            this.lblAtLeastUnder.AutoSize = true;
            this.lblAtLeastUnder.Location = new System.Drawing.Point(188, 104);
            this.lblAtLeastUnder.Name = "lblAtLeastUnder";
            this.lblAtLeastUnder.Size = new System.Drawing.Size(114, 15);
            this.lblAtLeastUnder.TabIndex = 90;
            this.lblAtLeastUnder.Text = "At least                    ≤";
            // 
            // cbAtLeastAboveNbrChars
            // 
            this.cbAtLeastAboveNbrChars.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAtLeastAboveNbrChars.DropDownWidth = 90;
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
            this.cbAtLeastAboveNbrChars.Location = new System.Drawing.Point(306, 75);
            this.cbAtLeastAboveNbrChars.Name = "cbAtLeastAboveNbrChars";
            this.cbAtLeastAboveNbrChars.Size = new System.Drawing.Size(45, 23);
            this.cbAtLeastAboveNbrChars.TabIndex = 89;
            // 
            // cbAtLeastAboveNbrWords
            // 
            this.cbAtLeastAboveNbrWords.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAtLeastAboveNbrWords.DropDownWidth = 70;
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
            this.cbAtLeastAboveNbrWords.Location = new System.Drawing.Point(237, 75);
            this.cbAtLeastAboveNbrWords.Name = "cbAtLeastAboveNbrWords";
            this.cbAtLeastAboveNbrWords.Size = new System.Drawing.Size(45, 23);
            this.cbAtLeastAboveNbrWords.TabIndex = 86;
            // 
            // lblAtLeastAbove
            // 
            this.lblAtLeastAbove.AutoSize = true;
            this.lblAtLeastAbove.Location = new System.Drawing.Point(188, 78);
            this.lblAtLeastAbove.Name = "lblAtLeastAbove";
            this.lblAtLeastAbove.Size = new System.Drawing.Size(114, 15);
            this.lblAtLeastAbove.TabIndex = 85;
            this.lblAtLeastAbove.Text = "At least                    ≥";
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
            this.cbMinFours.Location = new System.Drawing.Point(79, 153);
            this.cbMinFours.Name = "cbMinFours";
            this.cbMinFours.Size = new System.Drawing.Size(38, 23);
            this.cbMinFours.TabIndex = 84;
            // 
            // lblToFours
            // 
            this.lblToFours.AutoSize = true;
            this.lblToFours.Location = new System.Drawing.Point(118, 157);
            this.lblToFours.Name = "lblToFours";
            this.lblToFours.Size = new System.Drawing.Size(18, 15);
            this.lblToFours.TabIndex = 83;
            this.lblToFours.Text = "to";
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
            this.cbMaxFours.Location = new System.Drawing.Point(137, 153);
            this.cbMaxFours.Name = "cbMaxFours";
            this.cbMaxFours.Size = new System.Drawing.Size(38, 23);
            this.cbMaxFours.TabIndex = 82;
            // 
            // lblFours
            // 
            this.lblFours.AutoSize = true;
            this.lblFours.Location = new System.Drawing.Point(13, 156);
            this.lblFours.Name = "lblFours";
            this.lblFours.Size = new System.Drawing.Size(42, 15);
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
            this.cbMinThrees.Location = new System.Drawing.Point(79, 127);
            this.cbMinThrees.Name = "cbMinThrees";
            this.cbMinThrees.Size = new System.Drawing.Size(38, 23);
            this.cbMinThrees.TabIndex = 80;
            // 
            // lblToThrees
            // 
            this.lblToThrees.AutoSize = true;
            this.lblToThrees.Location = new System.Drawing.Point(118, 131);
            this.lblToThrees.Name = "lblToThrees";
            this.lblToThrees.Size = new System.Drawing.Size(18, 15);
            this.lblToThrees.TabIndex = 79;
            this.lblToThrees.Text = "to";
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
            this.cbMaxThrees.Location = new System.Drawing.Point(137, 127);
            this.cbMaxThrees.Name = "cbMaxThrees";
            this.cbMaxThrees.Size = new System.Drawing.Size(38, 23);
            this.cbMaxThrees.TabIndex = 78;
            // 
            // lblThrees
            // 
            this.lblThrees.AutoSize = true;
            this.lblThrees.Location = new System.Drawing.Point(13, 130);
            this.lblThrees.Name = "lblThrees";
            this.lblThrees.Size = new System.Drawing.Size(47, 15);
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
            this.cbMinTwos.Location = new System.Drawing.Point(79, 101);
            this.cbMinTwos.Name = "cbMinTwos";
            this.cbMinTwos.Size = new System.Drawing.Size(38, 23);
            this.cbMinTwos.TabIndex = 76;
            // 
            // lblToTwos
            // 
            this.lblToTwos.AutoSize = true;
            this.lblToTwos.Location = new System.Drawing.Point(118, 104);
            this.lblToTwos.Name = "lblToTwos";
            this.lblToTwos.Size = new System.Drawing.Size(18, 15);
            this.lblToTwos.TabIndex = 75;
            this.lblToTwos.Text = "to";
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
            this.cbMaxTwos.Location = new System.Drawing.Point(137, 101);
            this.cbMaxTwos.Name = "cbMaxTwos";
            this.cbMaxTwos.Size = new System.Drawing.Size(38, 23);
            this.cbMaxTwos.TabIndex = 74;
            // 
            // lblTwos
            // 
            this.lblTwos.AutoSize = true;
            this.lblTwos.Location = new System.Drawing.Point(13, 103);
            this.lblTwos.Name = "lblTwos";
            this.lblTwos.Size = new System.Drawing.Size(39, 15);
            this.lblTwos.TabIndex = 73;
            this.lblTwos.Text = "Twos :";
            // 
            // lblMaxDelim
            // 
            this.lblMaxDelim.AutoSize = true;
            this.lblMaxDelim.Location = new System.Drawing.Point(13, 24);
            this.lblMaxDelim.Name = "lblMaxDelim";
            this.lblMaxDelim.Size = new System.Drawing.Size(89, 15);
            this.lblMaxDelim.TabIndex = 57;
            this.lblMaxDelim.Text = "Max Delimiters:";
            // 
            // lblOnes
            // 
            this.lblOnes.AutoSize = true;
            this.lblOnes.Location = new System.Drawing.Point(13, 78);
            this.lblOnes.Name = "lblOnes";
            this.lblOnes.Size = new System.Drawing.Size(40, 15);
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
            this.cbMinWordLength.Location = new System.Drawing.Point(313, 47);
            this.cbMinWordLength.Name = "cbMinWordLength";
            this.cbMinWordLength.Size = new System.Drawing.Size(38, 23);
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
            this.cbMaxOnes.Location = new System.Drawing.Point(137, 75);
            this.cbMaxOnes.Name = "cbMaxOnes";
            this.cbMaxOnes.Size = new System.Drawing.Size(38, 23);
            this.cbMaxOnes.TabIndex = 70;
            // 
            // lblMinWordLength
            // 
            this.lblMinWordLength.AutoSize = true;
            this.lblMinWordLength.Location = new System.Drawing.Point(188, 50);
            this.lblMinWordLength.Name = "lblMinWordLength";
            this.lblMinWordLength.Size = new System.Drawing.Size(106, 15);
            this.lblMinWordLength.TabIndex = 67;
            this.lblMinWordLength.Text = "Min Word Length :";
            // 
            // lblToOnes
            // 
            this.lblToOnes.AutoSize = true;
            this.lblToOnes.Location = new System.Drawing.Point(118, 78);
            this.lblToOnes.Name = "lblToOnes";
            this.lblToOnes.Size = new System.Drawing.Size(18, 15);
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
            this.cbMaxWordLength.Location = new System.Drawing.Point(137, 49);
            this.cbMaxWordLength.Name = "cbMaxWordLength";
            this.cbMaxWordLength.Size = new System.Drawing.Size(38, 23);
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
            this.cbMaxDelim.Location = new System.Drawing.Point(137, 22);
            this.cbMaxDelim.Name = "cbMaxDelim";
            this.cbMaxDelim.Size = new System.Drawing.Size(38, 23);
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
            this.cbMinOnes.Location = new System.Drawing.Point(79, 75);
            this.cbMinOnes.Name = "cbMinOnes";
            this.cbMinOnes.Size = new System.Drawing.Size(38, 23);
            this.cbMinOnes.TabIndex = 72;
            // 
            // lblMaxWordLength
            // 
            this.lblMaxWordLength.AutoSize = true;
            this.lblMaxWordLength.Location = new System.Drawing.Point(13, 52);
            this.lblMaxWordLength.Name = "lblMaxWordLength";
            this.lblMaxWordLength.Size = new System.Drawing.Size(108, 15);
            this.lblMaxWordLength.TabIndex = 65;
            this.lblMaxWordLength.Text = "Max Word Length :";
            // 
            // lblMinDelim
            // 
            this.lblMinDelim.AutoSize = true;
            this.lblMinDelim.Location = new System.Drawing.Point(188, 24);
            this.lblMinDelim.Name = "lblMinDelim";
            this.lblMinDelim.Size = new System.Drawing.Size(87, 15);
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
            this.cbMinDelim.Location = new System.Drawing.Point(313, 21);
            this.cbMinDelim.Name = "cbMinDelim";
            this.cbMinDelim.Size = new System.Drawing.Size(38, 23);
            this.cbMinDelim.TabIndex = 60;
            // 
            // groupBoxWordFiltering
            // 
            this.groupBoxWordFiltering.Controls.Add(this.cbIncludePatternsSamples);
            this.groupBoxWordFiltering.Controls.Add(this.cbExcludePatternsSamples);
            this.groupBoxWordFiltering.Controls.Add(this.lblExcludePatterns);
            this.groupBoxWordFiltering.Controls.Add(this.txtExcludePatterns);
            this.groupBoxWordFiltering.Controls.Add(this.lblIncludePatterns);
            this.groupBoxWordFiltering.Controls.Add(this.txtIncludePatterns);
            this.groupBoxWordFiltering.Controls.Add(this.cbCombinationOrder);
            this.groupBoxWordFiltering.Controls.Add(this.chkIncludeWordNotLast);
            this.groupBoxWordFiltering.Controls.Add(this.lblCombinationOrder);
            this.groupBoxWordFiltering.Controls.Add(this.cbWordsLimit);
            this.groupBoxWordFiltering.Controls.Add(this.lblIncludeWord);
            this.groupBoxWordFiltering.Controls.Add(this.lblWordsLimit);
            this.groupBoxWordFiltering.Controls.Add(this.chkIncludeWordNotFirst);
            this.groupBoxWordFiltering.Controls.Add(this.txtIncludeWord);
            this.groupBoxWordFiltering.Location = new System.Drawing.Point(7, 4);
            this.groupBoxWordFiltering.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxWordFiltering.Name = "groupBoxWordFiltering";
            this.groupBoxWordFiltering.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxWordFiltering.Size = new System.Drawing.Size(364, 155);
            this.groupBoxWordFiltering.TabIndex = 85;
            this.groupBoxWordFiltering.TabStop = false;
            this.groupBoxWordFiltering.Text = "Word Filtering";
            // 
            // cbIncludePatternsSamples
            // 
            this.cbIncludePatternsSamples.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIncludePatternsSamples.DropDownWidth = 500;
            this.cbIncludePatternsSamples.FormattingEnabled = true;
            this.cbIncludePatternsSamples.Location = new System.Drawing.Point(314, 49);
            this.cbIncludePatternsSamples.Name = "cbIncludePatternsSamples";
            this.cbIncludePatternsSamples.Size = new System.Drawing.Size(38, 23);
            this.cbIncludePatternsSamples.TabIndex = 57;
            this.cbIncludePatternsSamples.SelectedIndexChanged += new System.EventHandler(this.cbIncludePatternsSamples_SelectedIndexChanged);
            // 
            // cbExcludePatternsSamples
            // 
            this.cbExcludePatternsSamples.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbExcludePatternsSamples.DropDownWidth = 500;
            this.cbExcludePatternsSamples.FormattingEnabled = true;
            this.cbExcludePatternsSamples.Location = new System.Drawing.Point(314, 20);
            this.cbExcludePatternsSamples.Name = "cbExcludePatternsSamples";
            this.cbExcludePatternsSamples.Size = new System.Drawing.Size(38, 23);
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
            this.cbCombinationOrder.Location = new System.Drawing.Point(121, 122);
            this.cbCombinationOrder.Name = "cbCombinationOrder";
            this.cbCombinationOrder.Size = new System.Drawing.Size(112, 23);
            this.cbCombinationOrder.TabIndex = 30;
            // 
            // chkIncludeWordNotLast
            // 
            this.chkIncludeWordNotLast.AutoSize = true;
            this.chkIncludeWordNotLast.Location = new System.Drawing.Point(250, 97);
            this.chkIncludeWordNotLast.Name = "chkIncludeWordNotLast";
            this.chkIncludeWordNotLast.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkIncludeWordNotLast.Size = new System.Drawing.Size(97, 19);
            this.chkIncludeWordNotLast.TabIndex = 55;
            this.chkIncludeWordNotLast.Text = "Not last word";
            this.chkIncludeWordNotLast.UseVisualStyleBackColor = true;
            // 
            // chkIncludeWordNotFirst
            // 
            this.chkIncludeWordNotFirst.AutoSize = true;
            this.chkIncludeWordNotFirst.Location = new System.Drawing.Point(253, 74);
            this.chkIncludeWordNotFirst.Name = "chkIncludeWordNotFirst";
            this.chkIncludeWordNotFirst.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkIncludeWordNotFirst.Size = new System.Drawing.Size(94, 19);
            this.chkIncludeWordNotFirst.TabIndex = 37;
            this.chkIncludeWordNotFirst.Text = "Not 1st word";
            this.chkIncludeWordNotFirst.UseVisualStyleBackColor = true;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Controls.Add(this.tabPage3);
            this.tabControl.Location = new System.Drawing.Point(380, 4);
            this.tabControl.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(444, 578);
            this.tabControl.TabIndex = 84;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tabMainDictionaries);
            this.tabPage1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage1.Size = new System.Drawing.Size(436, 550);
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
            this.tabMainDictionaries.Name = "tabMainDictionaries";
            this.tabMainDictionaries.SelectedIndex = 0;
            this.tabMainDictionaries.Size = new System.Drawing.Size(436, 550);
            this.tabMainDictionaries.TabIndex = 85;
            // 
            // tabMainDictionariesCommon
            // 
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
            this.tabMainDictionariesCommon.Location = new System.Drawing.Point(4, 22);
            this.tabMainDictionariesCommon.Name = "tabMainDictionariesCommon";
            this.tabMainDictionariesCommon.Padding = new System.Windows.Forms.Padding(3);
            this.tabMainDictionariesCommon.Size = new System.Drawing.Size(428, 524);
            this.tabMainDictionariesCommon.TabIndex = 0;
            this.tabMainDictionariesCommon.Text = "Common Dictionaries";
            this.tabMainDictionariesCommon.UseVisualStyleBackColor = true;
            // 
            // txtDictionaryFilterFirstTo
            // 
            this.txtDictionaryFilterFirstTo.Location = new System.Drawing.Point(6, 205);
            this.txtDictionaryFilterFirstTo.Name = "txtDictionaryFilterFirstTo";
            this.txtDictionaryFilterFirstTo.PlaceholderText = "zelda";
            this.txtDictionaryFilterFirstTo.Size = new System.Drawing.Size(98, 22);
            this.txtDictionaryFilterFirstTo.TabIndex = 95;
            // 
            // lblDictionaryFilterFirstTo
            // 
            this.lblDictionaryFilterFirstTo.AutoSize = true;
            this.lblDictionaryFilterFirstTo.Location = new System.Drawing.Point(9, 188);
            this.lblDictionaryFilterFirstTo.Name = "lblDictionaryFilterFirstTo";
            this.lblDictionaryFilterFirstTo.Size = new System.Drawing.Size(21, 13);
            this.lblDictionaryFilterFirstTo.TabIndex = 94;
            this.lblDictionaryFilterFirstTo.Text = "to:";
            // 
            // chkDictionariesUse
            // 
            this.chkDictionariesUse.AutoSize = true;
            this.chkDictionariesUse.Location = new System.Drawing.Point(80, 8);
            this.chkDictionariesUse.Name = "chkDictionariesUse";
            this.chkDictionariesUse.Size = new System.Drawing.Size(15, 14);
            this.chkDictionariesUse.TabIndex = 93;
            this.chkDictionariesUse.UseVisualStyleBackColor = true;
            this.chkDictionariesUse.CheckedChanged += new System.EventHandler(this.chkDictionariesUse_CheckedChanged);
            // 
            // lblDictionariesUse
            // 
            this.lblDictionariesUse.AutoSize = true;
            this.lblDictionariesUse.Location = new System.Drawing.Point(6, 7);
            this.lblDictionariesUse.Name = "lblDictionariesUse";
            this.lblDictionariesUse.Size = new System.Drawing.Size(29, 13);
            this.lblDictionariesUse.TabIndex = 22;
            this.lblDictionariesUse.Text = "Use:";
            // 
            // btnDictUnselected
            // 
            this.btnDictUnselected.Location = new System.Drawing.Point(4, 497);
            this.btnDictUnselected.Margin = new System.Windows.Forms.Padding(2);
            this.btnDictUnselected.Name = "btnDictUnselected";
            this.btnDictUnselected.Size = new System.Drawing.Size(102, 22);
            this.btnDictUnselected.TabIndex = 55;
            this.btnDictUnselected.Text = "Unselect All";
            this.btnDictUnselected.UseVisualStyleBackColor = true;
            this.btnDictUnselected.Click += new System.EventHandler(this.btnDictUnselected_Click);
            // 
            // tvDictMain
            // 
            this.tvDictMain.Location = new System.Drawing.Point(109, 2);
            this.tvDictMain.Margin = new System.Windows.Forms.Padding(2);
            this.tvDictMain.Name = "tvDictMain";
            this.tvDictMain.Size = new System.Drawing.Size(317, 520);
            this.tvDictMain.TabIndex = 84;
            this.tvDictMain.TriStateStyleProperty = RikTheVeggie.TriStateTreeView.TriStateStyles.Standard;
            // 
            // chkDictReverseOrder
            // 
            this.chkDictReverseOrder.AutoSize = true;
            this.chkDictReverseOrder.Location = new System.Drawing.Point(6, 120);
            this.chkDictReverseOrder.Name = "chkDictReverseOrder";
            this.chkDictReverseOrder.Size = new System.Drawing.Size(98, 17);
            this.chkDictReverseOrder.TabIndex = 54;
            this.chkDictReverseOrder.Text = "Reverse Order";
            this.chkDictReverseOrder.UseVisualStyleBackColor = true;
            // 
            // chkDictAddTypos
            // 
            this.chkDictAddTypos.AutoSize = true;
            this.chkDictAddTypos.Location = new System.Drawing.Point(6, 97);
            this.chkDictAddTypos.Name = "chkDictAddTypos";
            this.chkDictAddTypos.Size = new System.Drawing.Size(79, 17);
            this.chkDictAddTypos.TabIndex = 53;
            this.chkDictAddTypos.Text = "Add Typos";
            this.chkDictAddTypos.UseVisualStyleBackColor = true;
            // 
            // txtDictionaryFilterFirstFrom
            // 
            this.txtDictionaryFilterFirstFrom.Location = new System.Drawing.Point(6, 162);
            this.txtDictionaryFilterFirstFrom.Name = "txtDictionaryFilterFirstFrom";
            this.txtDictionaryFilterFirstFrom.PlaceholderText = "alucard";
            this.txtDictionaryFilterFirstFrom.Size = new System.Drawing.Size(98, 22);
            this.txtDictionaryFilterFirstFrom.TabIndex = 82;
            // 
            // chkDictForceLowercase
            // 
            this.chkDictForceLowercase.AutoSize = true;
            this.chkDictForceLowercase.Checked = true;
            this.chkDictForceLowercase.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDictForceLowercase.Location = new System.Drawing.Point(6, 74);
            this.chkDictForceLowercase.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.chkDictForceLowercase.Name = "chkDictForceLowercase";
            this.chkDictForceLowercase.Size = new System.Drawing.Size(79, 17);
            this.chkDictForceLowercase.TabIndex = 52;
            this.chkDictForceLowercase.Text = "Lowercase";
            this.chkDictForceLowercase.UseVisualStyleBackColor = true;
            // 
            // lblDictionaryFilterFirstFrom
            // 
            this.lblDictionaryFilterFirstFrom.AutoSize = true;
            this.lblDictionaryFilterFirstFrom.Location = new System.Drawing.Point(6, 145);
            this.lblDictionaryFilterFirstFrom.Name = "lblDictionaryFilterFirstFrom";
            this.lblDictionaryFilterFirstFrom.Size = new System.Drawing.Size(91, 13);
            this.lblDictionaryFilterFirstFrom.TabIndex = 83;
            this.lblDictionaryFilterFirstFrom.Text = "First Word from:";
            // 
            // chkDictSkipSpecials
            // 
            this.chkDictSkipSpecials.AutoSize = true;
            this.chkDictSkipSpecials.Checked = true;
            this.chkDictSkipSpecials.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDictSkipSpecials.Location = new System.Drawing.Point(6, 51);
            this.chkDictSkipSpecials.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.chkDictSkipSpecials.Name = "chkDictSkipSpecials";
            this.chkDictSkipSpecials.Size = new System.Drawing.Size(92, 17);
            this.chkDictSkipSpecials.TabIndex = 51;
            this.chkDictSkipSpecials.Text = "Skip Specials";
            this.chkDictSkipSpecials.UseVisualStyleBackColor = true;
            // 
            // chkDictSkipDigits
            // 
            this.chkDictSkipDigits.AutoSize = true;
            this.chkDictSkipDigits.Location = new System.Drawing.Point(6, 28);
            this.chkDictSkipDigits.Name = "chkDictSkipDigits";
            this.chkDictSkipDigits.Size = new System.Drawing.Size(81, 17);
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
            this.tabMainDictionariesCustom.Location = new System.Drawing.Point(4, 22);
            this.tabMainDictionariesCustom.Name = "tabMainDictionariesCustom";
            this.tabMainDictionariesCustom.Padding = new System.Windows.Forms.Padding(3);
            this.tabMainDictionariesCustom.Size = new System.Drawing.Size(428, 524);
            this.tabMainDictionariesCustom.TabIndex = 1;
            this.tabMainDictionariesCustom.Text = "Custom Words";
            this.tabMainDictionariesCustom.UseVisualStyleBackColor = true;
            // 
            // chkDictionariesCustomWordsUse
            // 
            this.chkDictionariesCustomWordsUse.AutoSize = true;
            this.chkDictionariesCustomWordsUse.Location = new System.Drawing.Point(80, 8);
            this.chkDictionariesCustomWordsUse.Name = "chkDictionariesCustomWordsUse";
            this.chkDictionariesCustomWordsUse.Size = new System.Drawing.Size(15, 14);
            this.chkDictionariesCustomWordsUse.TabIndex = 92;
            this.chkDictionariesCustomWordsUse.UseVisualStyleBackColor = true;
            this.chkDictionariesCustomWordsUse.CheckedChanged += new System.EventHandler(this.chkDictionariesCustomWordsUse_CheckedChanged);
            // 
            // lblDictionariesCustomWordsUse
            // 
            this.lblDictionariesCustomWordsUse.AutoSize = true;
            this.lblDictionariesCustomWordsUse.Location = new System.Drawing.Point(6, 7);
            this.lblDictionariesCustomWordsUse.Name = "lblDictionariesCustomWordsUse";
            this.lblDictionariesCustomWordsUse.Size = new System.Drawing.Size(29, 13);
            this.lblDictionariesCustomWordsUse.TabIndex = 91;
            this.lblDictionariesCustomWordsUse.Text = "Use:";
            // 
            // lblDictionariesCustomWordsAtLeast
            // 
            this.lblDictionariesCustomWordsAtLeast.AutoSize = true;
            this.lblDictionariesCustomWordsAtLeast.Location = new System.Drawing.Point(9, 147);
            this.lblDictionariesCustomWordsAtLeast.Name = "lblDictionariesCustomWordsAtLeast";
            this.lblDictionariesCustomWordsAtLeast.Size = new System.Drawing.Size(45, 13);
            this.lblDictionariesCustomWordsAtLeast.TabIndex = 89;
            this.lblDictionariesCustomWordsAtLeast.Text = "At least";
            // 
            // lblDictionariesCustomWordsHash
            // 
            this.lblDictionariesCustomWordsHash.AutoSize = true;
            this.lblDictionariesCustomWordsHash.Location = new System.Drawing.Point(9, 166);
            this.lblDictionariesCustomWordsHash.Name = "lblDictionariesCustomWordsHash";
            this.lblDictionariesCustomWordsHash.Size = new System.Drawing.Size(86, 13);
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
            this.cbDictionariesCustomWordsMinimumInHash.Location = new System.Drawing.Point(57, 143);
            this.cbDictionariesCustomWordsMinimumInHash.Name = "cbDictionariesCustomWordsMinimumInHash";
            this.cbDictionariesCustomWordsMinimumInHash.Size = new System.Drawing.Size(38, 21);
            this.cbDictionariesCustomWordsMinimumInHash.TabIndex = 87;
            // 
            // lblDictionariesCustomWordsFiltering
            // 
            this.lblDictionariesCustomWordsFiltering.AutoSize = true;
            this.lblDictionariesCustomWordsFiltering.Location = new System.Drawing.Point(6, 122);
            this.lblDictionariesCustomWordsFiltering.Name = "lblDictionariesCustomWordsFiltering";
            this.lblDictionariesCustomWordsFiltering.Size = new System.Drawing.Size(86, 13);
            this.lblDictionariesCustomWordsFiltering.TabIndex = 86;
            this.lblDictionariesCustomWordsFiltering.Text = "Filtering (slow):";
            // 
            // chkDictCustomWordsAddTypos
            // 
            this.chkDictCustomWordsAddTypos.AutoSize = true;
            this.chkDictCustomWordsAddTypos.Location = new System.Drawing.Point(6, 97);
            this.chkDictCustomWordsAddTypos.Name = "chkDictCustomWordsAddTypos";
            this.chkDictCustomWordsAddTypos.Size = new System.Drawing.Size(79, 17);
            this.chkDictCustomWordsAddTypos.TabIndex = 58;
            this.chkDictCustomWordsAddTypos.Text = "Add Typos";
            this.chkDictCustomWordsAddTypos.UseVisualStyleBackColor = true;
            // 
            // chkDictCustomWordsForceLowercase
            // 
            this.chkDictCustomWordsForceLowercase.AutoSize = true;
            this.chkDictCustomWordsForceLowercase.Checked = true;
            this.chkDictCustomWordsForceLowercase.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDictCustomWordsForceLowercase.Location = new System.Drawing.Point(6, 74);
            this.chkDictCustomWordsForceLowercase.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.chkDictCustomWordsForceLowercase.Name = "chkDictCustomWordsForceLowercase";
            this.chkDictCustomWordsForceLowercase.Size = new System.Drawing.Size(79, 17);
            this.chkDictCustomWordsForceLowercase.TabIndex = 57;
            this.chkDictCustomWordsForceLowercase.Text = "Lowercase";
            this.chkDictCustomWordsForceLowercase.UseVisualStyleBackColor = true;
            // 
            // chkDictCustomWordsSkipSpecials
            // 
            this.chkDictCustomWordsSkipSpecials.AutoSize = true;
            this.chkDictCustomWordsSkipSpecials.Checked = true;
            this.chkDictCustomWordsSkipSpecials.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDictCustomWordsSkipSpecials.Location = new System.Drawing.Point(6, 51);
            this.chkDictCustomWordsSkipSpecials.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.chkDictCustomWordsSkipSpecials.Name = "chkDictCustomWordsSkipSpecials";
            this.chkDictCustomWordsSkipSpecials.Size = new System.Drawing.Size(92, 17);
            this.chkDictCustomWordsSkipSpecials.TabIndex = 56;
            this.chkDictCustomWordsSkipSpecials.Text = "Skip Specials";
            this.chkDictCustomWordsSkipSpecials.UseVisualStyleBackColor = true;
            // 
            // chkDictCustomWordsSkipDigits
            // 
            this.chkDictCustomWordsSkipDigits.AutoSize = true;
            this.chkDictCustomWordsSkipDigits.Location = new System.Drawing.Point(6, 28);
            this.chkDictCustomWordsSkipDigits.Name = "chkDictCustomWordsSkipDigits";
            this.chkDictCustomWordsSkipDigits.Size = new System.Drawing.Size(81, 17);
            this.chkDictCustomWordsSkipDigits.TabIndex = 55;
            this.chkDictCustomWordsSkipDigits.Text = "Skip Digits";
            this.chkDictCustomWordsSkipDigits.UseVisualStyleBackColor = true;
            // 
            // txtDictCustWords
            // 
            this.txtDictCustWords.Location = new System.Drawing.Point(109, 2);
            this.txtDictCustWords.Margin = new System.Windows.Forms.Padding(2);
            this.txtDictCustWords.Multiline = true;
            this.txtDictCustWords.Name = "txtDictCustWords";
            this.txtDictCustWords.Size = new System.Drawing.Size(317, 520);
            this.txtDictCustWords.TabIndex = 0;
            // 
            // tabMainDictionariesExcludeWords
            // 
            this.tabMainDictionariesExcludeWords.Controls.Add(this.chkDictExcludePartialWords);
            this.tabMainDictionariesExcludeWords.Controls.Add(this.chkDictionariesExcludeWordsUse);
            this.tabMainDictionariesExcludeWords.Controls.Add(this.lblDictionariesExcludeWordsUse);
            this.tabMainDictionariesExcludeWords.Controls.Add(this.txtDictExcludeWords);
            this.tabMainDictionariesExcludeWords.Location = new System.Drawing.Point(4, 22);
            this.tabMainDictionariesExcludeWords.Name = "tabMainDictionariesExcludeWords";
            this.tabMainDictionariesExcludeWords.Size = new System.Drawing.Size(428, 524);
            this.tabMainDictionariesExcludeWords.TabIndex = 2;
            this.tabMainDictionariesExcludeWords.Text = "Exclude Words";
            this.tabMainDictionariesExcludeWords.UseVisualStyleBackColor = true;
            // 
            // chkDictExcludePartialWords
            // 
            this.chkDictExcludePartialWords.AutoSize = true;
            this.chkDictExcludePartialWords.Location = new System.Drawing.Point(6, 28);
            this.chkDictExcludePartialWords.Name = "chkDictExcludePartialWords";
            this.chkDictExcludePartialWords.Size = new System.Drawing.Size(93, 17);
            this.chkDictExcludePartialWords.TabIndex = 93;
            this.chkDictExcludePartialWords.Text = "Partial words";
            this.chkDictExcludePartialWords.UseVisualStyleBackColor = true;
            // 
            // chkDictionariesExcludeWordsUse
            // 
            this.chkDictionariesExcludeWordsUse.AutoSize = true;
            this.chkDictionariesExcludeWordsUse.Location = new System.Drawing.Point(80, 8);
            this.chkDictionariesExcludeWordsUse.Name = "chkDictionariesExcludeWordsUse";
            this.chkDictionariesExcludeWordsUse.Size = new System.Drawing.Size(15, 14);
            this.chkDictionariesExcludeWordsUse.TabIndex = 92;
            this.chkDictionariesExcludeWordsUse.UseVisualStyleBackColor = true;
            this.chkDictionariesExcludeWordsUse.CheckedChanged += new System.EventHandler(this.chkDictionariesExcludeWordsUse_CheckedChanged);
            // 
            // lblDictionariesExcludeWordsUse
            // 
            this.lblDictionariesExcludeWordsUse.AutoSize = true;
            this.lblDictionariesExcludeWordsUse.Location = new System.Drawing.Point(6, 7);
            this.lblDictionariesExcludeWordsUse.Name = "lblDictionariesExcludeWordsUse";
            this.lblDictionariesExcludeWordsUse.Size = new System.Drawing.Size(29, 13);
            this.lblDictionariesExcludeWordsUse.TabIndex = 91;
            this.lblDictionariesExcludeWordsUse.Text = "Use:";
            // 
            // txtDictExcludeWords
            // 
            this.txtDictExcludeWords.Location = new System.Drawing.Point(109, 2);
            this.txtDictExcludeWords.Margin = new System.Windows.Forms.Padding(2);
            this.txtDictExcludeWords.Multiline = true;
            this.txtDictExcludeWords.Name = "txtDictExcludeWords";
            this.txtDictExcludeWords.Size = new System.Drawing.Size(317, 520);
            this.txtDictExcludeWords.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tabFirstWordDictionaries);
            this.tabPage2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage2.Size = new System.Drawing.Size(436, 550);
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
            this.tabFirstWordDictionaries.Name = "tabFirstWordDictionaries";
            this.tabFirstWordDictionaries.SelectedIndex = 0;
            this.tabFirstWordDictionaries.Size = new System.Drawing.Size(436, 550);
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
            this.tabFirstWordDictionariesCommon.Location = new System.Drawing.Point(4, 22);
            this.tabFirstWordDictionariesCommon.Name = "tabFirstWordDictionariesCommon";
            this.tabFirstWordDictionariesCommon.Padding = new System.Windows.Forms.Padding(3);
            this.tabFirstWordDictionariesCommon.Size = new System.Drawing.Size(428, 524);
            this.tabFirstWordDictionariesCommon.TabIndex = 0;
            this.tabFirstWordDictionariesCommon.Text = "Common Dictionaries";
            this.tabFirstWordDictionariesCommon.UseVisualStyleBackColor = true;
            // 
            // lblDictionariesFirstWordUse
            // 
            this.lblDictionariesFirstWordUse.AutoSize = true;
            this.lblDictionariesFirstWordUse.Location = new System.Drawing.Point(6, 7);
            this.lblDictionariesFirstWordUse.Name = "lblDictionariesFirstWordUse";
            this.lblDictionariesFirstWordUse.Size = new System.Drawing.Size(54, 13);
            this.lblDictionariesFirstWordUse.TabIndex = 33;
            this.lblDictionariesFirstWordUse.Text = "Override:";
            // 
            // tvDictFirstWord
            // 
            this.tvDictFirstWord.Location = new System.Drawing.Point(109, 2);
            this.tvDictFirstWord.Margin = new System.Windows.Forms.Padding(2);
            this.tvDictFirstWord.Name = "tvDictFirstWord";
            this.tvDictFirstWord.Size = new System.Drawing.Size(317, 520);
            this.tvDictFirstWord.TabIndex = 58;
            this.tvDictFirstWord.TriStateStyleProperty = RikTheVeggie.TriStateTreeView.TriStateStyles.Standard;
            // 
            // chkDictFirstReverseOrder
            // 
            this.chkDictFirstReverseOrder.AutoSize = true;
            this.chkDictFirstReverseOrder.Location = new System.Drawing.Point(6, 120);
            this.chkDictFirstReverseOrder.Name = "chkDictFirstReverseOrder";
            this.chkDictFirstReverseOrder.Size = new System.Drawing.Size(98, 17);
            this.chkDictFirstReverseOrder.TabIndex = 44;
            this.chkDictFirstReverseOrder.Text = "Reverse Order";
            this.chkDictFirstReverseOrder.UseVisualStyleBackColor = true;
            // 
            // btnCopyToDictFirst
            // 
            this.btnCopyToDictFirst.Location = new System.Drawing.Point(4, 471);
            this.btnCopyToDictFirst.Margin = new System.Windows.Forms.Padding(2);
            this.btnCopyToDictFirst.Name = "btnCopyToDictFirst";
            this.btnCopyToDictFirst.Size = new System.Drawing.Size(102, 22);
            this.btnCopyToDictFirst.TabIndex = 57;
            this.btnCopyToDictFirst.Text = "Copy from Main";
            this.btnCopyToDictFirst.UseVisualStyleBackColor = true;
            this.btnCopyToDictFirst.Click += new System.EventHandler(this.btnCopyToDictFirst_Click);
            // 
            // btnDictFirstUnselected
            // 
            this.btnDictFirstUnselected.Location = new System.Drawing.Point(4, 497);
            this.btnDictFirstUnselected.Margin = new System.Windows.Forms.Padding(2);
            this.btnDictFirstUnselected.Name = "btnDictFirstUnselected";
            this.btnDictFirstUnselected.Size = new System.Drawing.Size(102, 22);
            this.btnDictFirstUnselected.TabIndex = 56;
            this.btnDictFirstUnselected.Text = "Unselect All";
            this.btnDictFirstUnselected.UseVisualStyleBackColor = true;
            this.btnDictFirstUnselected.Click += new System.EventHandler(this.btnDictFirstUnselected_Click);
            // 
            // chkDictFirstAddTypos
            // 
            this.chkDictFirstAddTypos.AutoSize = true;
            this.chkDictFirstAddTypos.Location = new System.Drawing.Point(6, 97);
            this.chkDictFirstAddTypos.Name = "chkDictFirstAddTypos";
            this.chkDictFirstAddTypos.Size = new System.Drawing.Size(79, 17);
            this.chkDictFirstAddTypos.TabIndex = 43;
            this.chkDictFirstAddTypos.Text = "Add Typos";
            this.chkDictFirstAddTypos.UseVisualStyleBackColor = true;
            // 
            // chkDictFirstForceLowercase
            // 
            this.chkDictFirstForceLowercase.AutoSize = true;
            this.chkDictFirstForceLowercase.Location = new System.Drawing.Point(6, 74);
            this.chkDictFirstForceLowercase.Name = "chkDictFirstForceLowercase";
            this.chkDictFirstForceLowercase.Size = new System.Drawing.Size(79, 17);
            this.chkDictFirstForceLowercase.TabIndex = 42;
            this.chkDictFirstForceLowercase.Text = "Lowercase";
            this.chkDictFirstForceLowercase.UseVisualStyleBackColor = true;
            // 
            // chkDictFirstSkipSpecials
            // 
            this.chkDictFirstSkipSpecials.AutoSize = true;
            this.chkDictFirstSkipSpecials.Location = new System.Drawing.Point(6, 51);
            this.chkDictFirstSkipSpecials.Name = "chkDictFirstSkipSpecials";
            this.chkDictFirstSkipSpecials.Size = new System.Drawing.Size(92, 17);
            this.chkDictFirstSkipSpecials.TabIndex = 41;
            this.chkDictFirstSkipSpecials.Text = "Skip Specials";
            this.chkDictFirstSkipSpecials.UseVisualStyleBackColor = true;
            // 
            // chkUseDictFirst
            // 
            this.chkUseDictFirst.AutoSize = true;
            this.chkUseDictFirst.Location = new System.Drawing.Point(80, 8);
            this.chkUseDictFirst.Name = "chkUseDictFirst";
            this.chkUseDictFirst.Size = new System.Drawing.Size(15, 14);
            this.chkUseDictFirst.TabIndex = 38;
            this.chkUseDictFirst.UseVisualStyleBackColor = true;
            this.chkUseDictFirst.CheckedChanged += new System.EventHandler(this.OnCustomDictFirstCheckedChanged);
            // 
            // chkDictFirstSkipDigits
            // 
            this.chkDictFirstSkipDigits.AutoSize = true;
            this.chkDictFirstSkipDigits.Location = new System.Drawing.Point(6, 28);
            this.chkDictFirstSkipDigits.Name = "chkDictFirstSkipDigits";
            this.chkDictFirstSkipDigits.Size = new System.Drawing.Size(81, 17);
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
            this.tabFirstWordDictionariesCustom.Location = new System.Drawing.Point(4, 22);
            this.tabFirstWordDictionariesCustom.Name = "tabFirstWordDictionariesCustom";
            this.tabFirstWordDictionariesCustom.Padding = new System.Windows.Forms.Padding(3);
            this.tabFirstWordDictionariesCustom.Size = new System.Drawing.Size(428, 524);
            this.tabFirstWordDictionariesCustom.TabIndex = 1;
            this.tabFirstWordDictionariesCustom.Text = "Custom Words";
            this.tabFirstWordDictionariesCustom.UseVisualStyleBackColor = true;
            // 
            // btnCopyToDictCustomFirst
            // 
            this.btnCopyToDictCustomFirst.Location = new System.Drawing.Point(4, 497);
            this.btnCopyToDictCustomFirst.Margin = new System.Windows.Forms.Padding(2);
            this.btnCopyToDictCustomFirst.Name = "btnCopyToDictCustomFirst";
            this.btnCopyToDictCustomFirst.Size = new System.Drawing.Size(102, 22);
            this.btnCopyToDictCustomFirst.TabIndex = 106;
            this.btnCopyToDictCustomFirst.Text = "Copy from Main";
            this.btnCopyToDictCustomFirst.UseVisualStyleBackColor = true;
            this.btnCopyToDictCustomFirst.Click += new System.EventHandler(this.btnCopyToDictCustomFirst_Click);
            // 
            // chkDictionariesFirstWordCustomWordsUse
            // 
            this.chkDictionariesFirstWordCustomWordsUse.AutoSize = true;
            this.chkDictionariesFirstWordCustomWordsUse.Location = new System.Drawing.Point(80, 8);
            this.chkDictionariesFirstWordCustomWordsUse.Name = "chkDictionariesFirstWordCustomWordsUse";
            this.chkDictionariesFirstWordCustomWordsUse.Size = new System.Drawing.Size(15, 14);
            this.chkDictionariesFirstWordCustomWordsUse.TabIndex = 105;
            this.chkDictionariesFirstWordCustomWordsUse.UseVisualStyleBackColor = true;
            this.chkDictionariesFirstWordCustomWordsUse.CheckedChanged += new System.EventHandler(this.chkDictionariesFirstWordCustomWordsUse_CheckedChanged);
            // 
            // lblDictionariesFirstWordCustomWordsUse
            // 
            this.lblDictionariesFirstWordCustomWordsUse.AutoSize = true;
            this.lblDictionariesFirstWordCustomWordsUse.Location = new System.Drawing.Point(6, 7);
            this.lblDictionariesFirstWordCustomWordsUse.Name = "lblDictionariesFirstWordCustomWordsUse";
            this.lblDictionariesFirstWordCustomWordsUse.Size = new System.Drawing.Size(54, 13);
            this.lblDictionariesFirstWordCustomWordsUse.TabIndex = 104;
            this.lblDictionariesFirstWordCustomWordsUse.Text = "Override:";
            // 
            // chkDictFirstWordCustomWordsAddTypos
            // 
            this.chkDictFirstWordCustomWordsAddTypos.AutoSize = true;
            this.chkDictFirstWordCustomWordsAddTypos.Location = new System.Drawing.Point(6, 97);
            this.chkDictFirstWordCustomWordsAddTypos.Name = "chkDictFirstWordCustomWordsAddTypos";
            this.chkDictFirstWordCustomWordsAddTypos.Size = new System.Drawing.Size(79, 17);
            this.chkDictFirstWordCustomWordsAddTypos.TabIndex = 98;
            this.chkDictFirstWordCustomWordsAddTypos.Text = "Add Typos";
            this.chkDictFirstWordCustomWordsAddTypos.UseVisualStyleBackColor = true;
            // 
            // chkDictFirstWordCustomWordsForceLowercase
            // 
            this.chkDictFirstWordCustomWordsForceLowercase.AutoSize = true;
            this.chkDictFirstWordCustomWordsForceLowercase.Checked = true;
            this.chkDictFirstWordCustomWordsForceLowercase.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDictFirstWordCustomWordsForceLowercase.Location = new System.Drawing.Point(6, 74);
            this.chkDictFirstWordCustomWordsForceLowercase.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.chkDictFirstWordCustomWordsForceLowercase.Name = "chkDictFirstWordCustomWordsForceLowercase";
            this.chkDictFirstWordCustomWordsForceLowercase.Size = new System.Drawing.Size(79, 17);
            this.chkDictFirstWordCustomWordsForceLowercase.TabIndex = 97;
            this.chkDictFirstWordCustomWordsForceLowercase.Text = "Lowercase";
            this.chkDictFirstWordCustomWordsForceLowercase.UseVisualStyleBackColor = true;
            // 
            // chkDictFirstWordCustomWordsSkipSpecials
            // 
            this.chkDictFirstWordCustomWordsSkipSpecials.AutoSize = true;
            this.chkDictFirstWordCustomWordsSkipSpecials.Checked = true;
            this.chkDictFirstWordCustomWordsSkipSpecials.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDictFirstWordCustomWordsSkipSpecials.Location = new System.Drawing.Point(6, 51);
            this.chkDictFirstWordCustomWordsSkipSpecials.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.chkDictFirstWordCustomWordsSkipSpecials.Name = "chkDictFirstWordCustomWordsSkipSpecials";
            this.chkDictFirstWordCustomWordsSkipSpecials.Size = new System.Drawing.Size(92, 17);
            this.chkDictFirstWordCustomWordsSkipSpecials.TabIndex = 96;
            this.chkDictFirstWordCustomWordsSkipSpecials.Text = "Skip Specials";
            this.chkDictFirstWordCustomWordsSkipSpecials.UseVisualStyleBackColor = true;
            // 
            // chkDictFirstWordCustomWordsSkipDigits
            // 
            this.chkDictFirstWordCustomWordsSkipDigits.AutoSize = true;
            this.chkDictFirstWordCustomWordsSkipDigits.Location = new System.Drawing.Point(6, 28);
            this.chkDictFirstWordCustomWordsSkipDigits.Name = "chkDictFirstWordCustomWordsSkipDigits";
            this.chkDictFirstWordCustomWordsSkipDigits.Size = new System.Drawing.Size(81, 17);
            this.chkDictFirstWordCustomWordsSkipDigits.TabIndex = 95;
            this.chkDictFirstWordCustomWordsSkipDigits.Text = "Skip Digits";
            this.chkDictFirstWordCustomWordsSkipDigits.UseVisualStyleBackColor = true;
            // 
            // txtDictFirstCustWords
            // 
            this.txtDictFirstCustWords.Location = new System.Drawing.Point(109, 2);
            this.txtDictFirstCustWords.Margin = new System.Windows.Forms.Padding(2);
            this.txtDictFirstCustWords.Multiline = true;
            this.txtDictFirstCustWords.Name = "txtDictFirstCustWords";
            this.txtDictFirstCustWords.Size = new System.Drawing.Size(317, 520);
            this.txtDictFirstCustWords.TabIndex = 0;
            // 
            // tabFirstWordDictionariesExcludeWords
            // 
            this.tabFirstWordDictionariesExcludeWords.Controls.Add(this.btnCopyToDictExcludeFirst);
            this.tabFirstWordDictionariesExcludeWords.Controls.Add(this.txtDictFirstWordExcludeWords);
            this.tabFirstWordDictionariesExcludeWords.Controls.Add(this.chkDictFirstWordExcludePartialWords);
            this.tabFirstWordDictionariesExcludeWords.Controls.Add(this.chkDictionariesFirstWordExcludeWordsUse);
            this.tabFirstWordDictionariesExcludeWords.Controls.Add(this.lblDictionariesFirstWordExcludeWordsUse);
            this.tabFirstWordDictionariesExcludeWords.Location = new System.Drawing.Point(4, 22);
            this.tabFirstWordDictionariesExcludeWords.Name = "tabFirstWordDictionariesExcludeWords";
            this.tabFirstWordDictionariesExcludeWords.Size = new System.Drawing.Size(428, 524);
            this.tabFirstWordDictionariesExcludeWords.TabIndex = 2;
            this.tabFirstWordDictionariesExcludeWords.Text = "Exclude Words";
            this.tabFirstWordDictionariesExcludeWords.UseVisualStyleBackColor = true;
            // 
            // btnCopyToDictExcludeFirst
            // 
            this.btnCopyToDictExcludeFirst.Location = new System.Drawing.Point(4, 497);
            this.btnCopyToDictExcludeFirst.Margin = new System.Windows.Forms.Padding(2);
            this.btnCopyToDictExcludeFirst.Name = "btnCopyToDictExcludeFirst";
            this.btnCopyToDictExcludeFirst.Size = new System.Drawing.Size(102, 22);
            this.btnCopyToDictExcludeFirst.TabIndex = 98;
            this.btnCopyToDictExcludeFirst.Text = "Copy from Main";
            this.btnCopyToDictExcludeFirst.UseVisualStyleBackColor = true;
            this.btnCopyToDictExcludeFirst.Click += new System.EventHandler(this.btnCopyToDictExcludeFirst_Click);
            // 
            // txtDictFirstWordExcludeWords
            // 
            this.txtDictFirstWordExcludeWords.Location = new System.Drawing.Point(109, 2);
            this.txtDictFirstWordExcludeWords.Margin = new System.Windows.Forms.Padding(2);
            this.txtDictFirstWordExcludeWords.Multiline = true;
            this.txtDictFirstWordExcludeWords.Name = "txtDictFirstWordExcludeWords";
            this.txtDictFirstWordExcludeWords.Size = new System.Drawing.Size(317, 520);
            this.txtDictFirstWordExcludeWords.TabIndex = 97;
            // 
            // chkDictFirstWordExcludePartialWords
            // 
            this.chkDictFirstWordExcludePartialWords.AutoSize = true;
            this.chkDictFirstWordExcludePartialWords.Location = new System.Drawing.Point(6, 28);
            this.chkDictFirstWordExcludePartialWords.Name = "chkDictFirstWordExcludePartialWords";
            this.chkDictFirstWordExcludePartialWords.Size = new System.Drawing.Size(93, 17);
            this.chkDictFirstWordExcludePartialWords.TabIndex = 96;
            this.chkDictFirstWordExcludePartialWords.Text = "Partial words";
            this.chkDictFirstWordExcludePartialWords.UseVisualStyleBackColor = true;
            // 
            // chkDictionariesFirstWordExcludeWordsUse
            // 
            this.chkDictionariesFirstWordExcludeWordsUse.AutoSize = true;
            this.chkDictionariesFirstWordExcludeWordsUse.Location = new System.Drawing.Point(80, 8);
            this.chkDictionariesFirstWordExcludeWordsUse.Name = "chkDictionariesFirstWordExcludeWordsUse";
            this.chkDictionariesFirstWordExcludeWordsUse.Size = new System.Drawing.Size(15, 14);
            this.chkDictionariesFirstWordExcludeWordsUse.TabIndex = 95;
            this.chkDictionariesFirstWordExcludeWordsUse.UseVisualStyleBackColor = true;
            this.chkDictionariesFirstWordExcludeWordsUse.CheckedChanged += new System.EventHandler(this.chkDictionariesFirstWordExcludeWordsUse_CheckedChanged);
            // 
            // lblDictionariesFirstWordExcludeWordsUse
            // 
            this.lblDictionariesFirstWordExcludeWordsUse.AutoSize = true;
            this.lblDictionariesFirstWordExcludeWordsUse.Location = new System.Drawing.Point(6, 7);
            this.lblDictionariesFirstWordExcludeWordsUse.Name = "lblDictionariesFirstWordExcludeWordsUse";
            this.lblDictionariesFirstWordExcludeWordsUse.Size = new System.Drawing.Size(54, 13);
            this.lblDictionariesFirstWordExcludeWordsUse.TabIndex = 94;
            this.lblDictionariesFirstWordExcludeWordsUse.Text = "Override:";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.tabLastWordDictionaries);
            this.tabPage3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(436, 550);
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
            this.tabLastWordDictionaries.Name = "tabLastWordDictionaries";
            this.tabLastWordDictionaries.SelectedIndex = 0;
            this.tabLastWordDictionaries.Size = new System.Drawing.Size(436, 550);
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
            this.tabLastWordDictionariesCommon.Location = new System.Drawing.Point(4, 22);
            this.tabLastWordDictionariesCommon.Name = "tabLastWordDictionariesCommon";
            this.tabLastWordDictionariesCommon.Padding = new System.Windows.Forms.Padding(3);
            this.tabLastWordDictionariesCommon.Size = new System.Drawing.Size(428, 524);
            this.tabLastWordDictionariesCommon.TabIndex = 0;
            this.tabLastWordDictionariesCommon.Text = "Common Dictionaries";
            this.tabLastWordDictionariesCommon.UseVisualStyleBackColor = true;
            // 
            // lblDictionaryLastWordUse
            // 
            this.lblDictionaryLastWordUse.AutoSize = true;
            this.lblDictionaryLastWordUse.Location = new System.Drawing.Point(6, 7);
            this.lblDictionaryLastWordUse.Name = "lblDictionaryLastWordUse";
            this.lblDictionaryLastWordUse.Size = new System.Drawing.Size(54, 13);
            this.lblDictionaryLastWordUse.TabIndex = 31;
            this.lblDictionaryLastWordUse.Text = "Override:";
            // 
            // tvDictLastWord
            // 
            this.tvDictLastWord.Location = new System.Drawing.Point(109, 2);
            this.tvDictLastWord.Margin = new System.Windows.Forms.Padding(2);
            this.tvDictLastWord.Name = "tvDictLastWord";
            this.tvDictLastWord.Size = new System.Drawing.Size(317, 520);
            this.tvDictLastWord.TabIndex = 59;
            this.tvDictLastWord.TriStateStyleProperty = RikTheVeggie.TriStateTreeView.TriStateStyles.Standard;
            // 
            // chkDictLastForceLowercase
            // 
            this.chkDictLastForceLowercase.AutoSize = true;
            this.chkDictLastForceLowercase.Location = new System.Drawing.Point(6, 74);
            this.chkDictLastForceLowercase.Name = "chkDictLastForceLowercase";
            this.chkDictLastForceLowercase.Size = new System.Drawing.Size(79, 17);
            this.chkDictLastForceLowercase.TabIndex = 47;
            this.chkDictLastForceLowercase.Text = "Lowercase";
            this.chkDictLastForceLowercase.UseVisualStyleBackColor = true;
            // 
            // btnCopyToDictLast
            // 
            this.btnCopyToDictLast.Location = new System.Drawing.Point(4, 471);
            this.btnCopyToDictLast.Margin = new System.Windows.Forms.Padding(2);
            this.btnCopyToDictLast.Name = "btnCopyToDictLast";
            this.btnCopyToDictLast.Size = new System.Drawing.Size(102, 22);
            this.btnCopyToDictLast.TabIndex = 58;
            this.btnCopyToDictLast.Text = "Copy from Main";
            this.btnCopyToDictLast.UseVisualStyleBackColor = true;
            this.btnCopyToDictLast.Click += new System.EventHandler(this.btnCopyToDictLast_Click);
            // 
            // btnDictLastUnselected
            // 
            this.btnDictLastUnselected.Location = new System.Drawing.Point(4, 497);
            this.btnDictLastUnselected.Margin = new System.Windows.Forms.Padding(2);
            this.btnDictLastUnselected.Name = "btnDictLastUnselected";
            this.btnDictLastUnselected.Size = new System.Drawing.Size(102, 22);
            this.btnDictLastUnselected.TabIndex = 57;
            this.btnDictLastUnselected.Text = "Unselect All";
            this.btnDictLastUnselected.UseVisualStyleBackColor = true;
            this.btnDictLastUnselected.Click += new System.EventHandler(this.btnDictLastUnselected_Click);
            // 
            // chkDictLastSkipSpecials
            // 
            this.chkDictLastSkipSpecials.AutoSize = true;
            this.chkDictLastSkipSpecials.Location = new System.Drawing.Point(6, 51);
            this.chkDictLastSkipSpecials.Name = "chkDictLastSkipSpecials";
            this.chkDictLastSkipSpecials.Size = new System.Drawing.Size(92, 17);
            this.chkDictLastSkipSpecials.TabIndex = 46;
            this.chkDictLastSkipSpecials.Text = "Skip Specials";
            this.chkDictLastSkipSpecials.UseVisualStyleBackColor = true;
            // 
            // chkDictLastAddTypos
            // 
            this.chkDictLastAddTypos.AutoSize = true;
            this.chkDictLastAddTypos.Location = new System.Drawing.Point(6, 97);
            this.chkDictLastAddTypos.Name = "chkDictLastAddTypos";
            this.chkDictLastAddTypos.Size = new System.Drawing.Size(79, 17);
            this.chkDictLastAddTypos.TabIndex = 48;
            this.chkDictLastAddTypos.Text = "Add Typos";
            this.chkDictLastAddTypos.UseVisualStyleBackColor = true;
            // 
            // chkDictLastSkipDigits
            // 
            this.chkDictLastSkipDigits.AutoSize = true;
            this.chkDictLastSkipDigits.Location = new System.Drawing.Point(6, 28);
            this.chkDictLastSkipDigits.Name = "chkDictLastSkipDigits";
            this.chkDictLastSkipDigits.Size = new System.Drawing.Size(81, 17);
            this.chkDictLastSkipDigits.TabIndex = 45;
            this.chkDictLastSkipDigits.Text = "Skip Digits";
            this.chkDictLastSkipDigits.UseVisualStyleBackColor = true;
            // 
            // chkUseDictLast
            // 
            this.chkUseDictLast.AutoSize = true;
            this.chkUseDictLast.Location = new System.Drawing.Point(80, 8);
            this.chkUseDictLast.Name = "chkUseDictLast";
            this.chkUseDictLast.Size = new System.Drawing.Size(15, 14);
            this.chkUseDictLast.TabIndex = 39;
            this.chkUseDictLast.UseVisualStyleBackColor = true;
            this.chkUseDictLast.CheckedChanged += new System.EventHandler(this.OnCustomDictLastCheckedChanged);
            // 
            // chkDictLastReverseOrder
            // 
            this.chkDictLastReverseOrder.AutoSize = true;
            this.chkDictLastReverseOrder.Location = new System.Drawing.Point(6, 120);
            this.chkDictLastReverseOrder.Name = "chkDictLastReverseOrder";
            this.chkDictLastReverseOrder.Size = new System.Drawing.Size(98, 17);
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
            this.tabLastWordDictionariesCustom.Location = new System.Drawing.Point(4, 22);
            this.tabLastWordDictionariesCustom.Name = "tabLastWordDictionariesCustom";
            this.tabLastWordDictionariesCustom.Padding = new System.Windows.Forms.Padding(3);
            this.tabLastWordDictionariesCustom.Size = new System.Drawing.Size(428, 524);
            this.tabLastWordDictionariesCustom.TabIndex = 1;
            this.tabLastWordDictionariesCustom.Text = "Custom Words";
            this.tabLastWordDictionariesCustom.UseVisualStyleBackColor = true;
            // 
            // btnCopyToDictCustomLast
            // 
            this.btnCopyToDictCustomLast.Location = new System.Drawing.Point(4, 497);
            this.btnCopyToDictCustomLast.Margin = new System.Windows.Forms.Padding(2);
            this.btnCopyToDictCustomLast.Name = "btnCopyToDictCustomLast";
            this.btnCopyToDictCustomLast.Size = new System.Drawing.Size(102, 22);
            this.btnCopyToDictCustomLast.TabIndex = 106;
            this.btnCopyToDictCustomLast.Text = "Copy from Main";
            this.btnCopyToDictCustomLast.UseVisualStyleBackColor = true;
            this.btnCopyToDictCustomLast.Click += new System.EventHandler(this.btnCopyToDictCustomLast_Click);
            // 
            // chkDictionariesLastWordCustomWordsUse
            // 
            this.chkDictionariesLastWordCustomWordsUse.AutoSize = true;
            this.chkDictionariesLastWordCustomWordsUse.Location = new System.Drawing.Point(80, 8);
            this.chkDictionariesLastWordCustomWordsUse.Name = "chkDictionariesLastWordCustomWordsUse";
            this.chkDictionariesLastWordCustomWordsUse.Size = new System.Drawing.Size(15, 14);
            this.chkDictionariesLastWordCustomWordsUse.TabIndex = 105;
            this.chkDictionariesLastWordCustomWordsUse.UseVisualStyleBackColor = true;
            this.chkDictionariesLastWordCustomWordsUse.CheckedChanged += new System.EventHandler(this.chkDictionariesLastWordCustomWordsUse_CheckedChanged);
            // 
            // lblDictionariesLastWordCustomWordsUse
            // 
            this.lblDictionariesLastWordCustomWordsUse.AutoSize = true;
            this.lblDictionariesLastWordCustomWordsUse.Location = new System.Drawing.Point(6, 7);
            this.lblDictionariesLastWordCustomWordsUse.Name = "lblDictionariesLastWordCustomWordsUse";
            this.lblDictionariesLastWordCustomWordsUse.Size = new System.Drawing.Size(54, 13);
            this.lblDictionariesLastWordCustomWordsUse.TabIndex = 104;
            this.lblDictionariesLastWordCustomWordsUse.Text = "Override:";
            // 
            // chkDictLastWordCustomWordsAddTypos
            // 
            this.chkDictLastWordCustomWordsAddTypos.AutoSize = true;
            this.chkDictLastWordCustomWordsAddTypos.Location = new System.Drawing.Point(6, 97);
            this.chkDictLastWordCustomWordsAddTypos.Name = "chkDictLastWordCustomWordsAddTypos";
            this.chkDictLastWordCustomWordsAddTypos.Size = new System.Drawing.Size(79, 17);
            this.chkDictLastWordCustomWordsAddTypos.TabIndex = 98;
            this.chkDictLastWordCustomWordsAddTypos.Text = "Add Typos";
            this.chkDictLastWordCustomWordsAddTypos.UseVisualStyleBackColor = true;
            // 
            // chkDictLastWordCustomWordsForceLowercase
            // 
            this.chkDictLastWordCustomWordsForceLowercase.AutoSize = true;
            this.chkDictLastWordCustomWordsForceLowercase.Checked = true;
            this.chkDictLastWordCustomWordsForceLowercase.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDictLastWordCustomWordsForceLowercase.Location = new System.Drawing.Point(6, 74);
            this.chkDictLastWordCustomWordsForceLowercase.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.chkDictLastWordCustomWordsForceLowercase.Name = "chkDictLastWordCustomWordsForceLowercase";
            this.chkDictLastWordCustomWordsForceLowercase.Size = new System.Drawing.Size(79, 17);
            this.chkDictLastWordCustomWordsForceLowercase.TabIndex = 97;
            this.chkDictLastWordCustomWordsForceLowercase.Text = "Lowercase";
            this.chkDictLastWordCustomWordsForceLowercase.UseVisualStyleBackColor = true;
            // 
            // chkDictLastWordCustomWordsSkipSpecials
            // 
            this.chkDictLastWordCustomWordsSkipSpecials.AutoSize = true;
            this.chkDictLastWordCustomWordsSkipSpecials.Checked = true;
            this.chkDictLastWordCustomWordsSkipSpecials.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDictLastWordCustomWordsSkipSpecials.Location = new System.Drawing.Point(6, 51);
            this.chkDictLastWordCustomWordsSkipSpecials.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.chkDictLastWordCustomWordsSkipSpecials.Name = "chkDictLastWordCustomWordsSkipSpecials";
            this.chkDictLastWordCustomWordsSkipSpecials.Size = new System.Drawing.Size(92, 17);
            this.chkDictLastWordCustomWordsSkipSpecials.TabIndex = 96;
            this.chkDictLastWordCustomWordsSkipSpecials.Text = "Skip Specials";
            this.chkDictLastWordCustomWordsSkipSpecials.UseVisualStyleBackColor = true;
            // 
            // chkDictLastWordCustomWordsSkipDigits
            // 
            this.chkDictLastWordCustomWordsSkipDigits.AutoSize = true;
            this.chkDictLastWordCustomWordsSkipDigits.Location = new System.Drawing.Point(6, 28);
            this.chkDictLastWordCustomWordsSkipDigits.Name = "chkDictLastWordCustomWordsSkipDigits";
            this.chkDictLastWordCustomWordsSkipDigits.Size = new System.Drawing.Size(81, 17);
            this.chkDictLastWordCustomWordsSkipDigits.TabIndex = 95;
            this.chkDictLastWordCustomWordsSkipDigits.Text = "Skip Digits";
            this.chkDictLastWordCustomWordsSkipDigits.UseVisualStyleBackColor = true;
            // 
            // txtDictLastCustWords
            // 
            this.txtDictLastCustWords.Location = new System.Drawing.Point(109, 2);
            this.txtDictLastCustWords.Margin = new System.Windows.Forms.Padding(2);
            this.txtDictLastCustWords.Multiline = true;
            this.txtDictLastCustWords.Name = "txtDictLastCustWords";
            this.txtDictLastCustWords.Size = new System.Drawing.Size(317, 520);
            this.txtDictLastCustWords.TabIndex = 0;
            // 
            // tabLastWordDictionariesExcludeWords
            // 
            this.tabLastWordDictionariesExcludeWords.Controls.Add(this.btnCopyToDictExcludeLast);
            this.tabLastWordDictionariesExcludeWords.Controls.Add(this.txtDictLastWordExcludeWords);
            this.tabLastWordDictionariesExcludeWords.Controls.Add(this.chkDictLastWordExcludePartialWords);
            this.tabLastWordDictionariesExcludeWords.Controls.Add(this.chkDictionariesLastWordExcludeWordsUse);
            this.tabLastWordDictionariesExcludeWords.Controls.Add(this.lblDictionariesLastWordExcludeWordsUse);
            this.tabLastWordDictionariesExcludeWords.Location = new System.Drawing.Point(4, 22);
            this.tabLastWordDictionariesExcludeWords.Name = "tabLastWordDictionariesExcludeWords";
            this.tabLastWordDictionariesExcludeWords.Size = new System.Drawing.Size(428, 524);
            this.tabLastWordDictionariesExcludeWords.TabIndex = 2;
            this.tabLastWordDictionariesExcludeWords.Text = "Exclude Words";
            this.tabLastWordDictionariesExcludeWords.UseVisualStyleBackColor = true;
            // 
            // btnCopyToDictExcludeLast
            // 
            this.btnCopyToDictExcludeLast.Location = new System.Drawing.Point(4, 497);
            this.btnCopyToDictExcludeLast.Margin = new System.Windows.Forms.Padding(2);
            this.btnCopyToDictExcludeLast.Name = "btnCopyToDictExcludeLast";
            this.btnCopyToDictExcludeLast.Size = new System.Drawing.Size(102, 22);
            this.btnCopyToDictExcludeLast.TabIndex = 98;
            this.btnCopyToDictExcludeLast.Text = "Copy from Main";
            this.btnCopyToDictExcludeLast.UseVisualStyleBackColor = true;
            this.btnCopyToDictExcludeLast.Click += new System.EventHandler(this.btnCopyToDictExcludeLast_Click);
            // 
            // txtDictLastWordExcludeWords
            // 
            this.txtDictLastWordExcludeWords.Location = new System.Drawing.Point(109, 2);
            this.txtDictLastWordExcludeWords.Margin = new System.Windows.Forms.Padding(2);
            this.txtDictLastWordExcludeWords.Multiline = true;
            this.txtDictLastWordExcludeWords.Name = "txtDictLastWordExcludeWords";
            this.txtDictLastWordExcludeWords.Size = new System.Drawing.Size(317, 520);
            this.txtDictLastWordExcludeWords.TabIndex = 97;
            // 
            // chkDictLastWordExcludePartialWords
            // 
            this.chkDictLastWordExcludePartialWords.AutoSize = true;
            this.chkDictLastWordExcludePartialWords.Location = new System.Drawing.Point(6, 28);
            this.chkDictLastWordExcludePartialWords.Name = "chkDictLastWordExcludePartialWords";
            this.chkDictLastWordExcludePartialWords.Size = new System.Drawing.Size(93, 17);
            this.chkDictLastWordExcludePartialWords.TabIndex = 96;
            this.chkDictLastWordExcludePartialWords.Text = "Partial words";
            this.chkDictLastWordExcludePartialWords.UseVisualStyleBackColor = true;
            // 
            // chkDictionariesLastWordExcludeWordsUse
            // 
            this.chkDictionariesLastWordExcludeWordsUse.AutoSize = true;
            this.chkDictionariesLastWordExcludeWordsUse.Location = new System.Drawing.Point(80, 8);
            this.chkDictionariesLastWordExcludeWordsUse.Name = "chkDictionariesLastWordExcludeWordsUse";
            this.chkDictionariesLastWordExcludeWordsUse.Size = new System.Drawing.Size(15, 14);
            this.chkDictionariesLastWordExcludeWordsUse.TabIndex = 95;
            this.chkDictionariesLastWordExcludeWordsUse.UseVisualStyleBackColor = true;
            this.chkDictionariesLastWordExcludeWordsUse.CheckedChanged += new System.EventHandler(this.chkDictionariesLastWordExcludeWordsUse_CheckedChanged);
            // 
            // lblDictionariesLastWordExcludeWordsUse
            // 
            this.lblDictionariesLastWordExcludeWordsUse.AutoSize = true;
            this.lblDictionariesLastWordExcludeWordsUse.Location = new System.Drawing.Point(6, 7);
            this.lblDictionariesLastWordExcludeWordsUse.Name = "lblDictionariesLastWordExcludeWordsUse";
            this.lblDictionariesLastWordExcludeWordsUse.Size = new System.Drawing.Size(54, 13);
            this.lblDictionariesLastWordExcludeWordsUse.TabIndex = 94;
            this.lblDictionariesLastWordExcludeWordsUse.Text = "Override:";
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
            this.grpAdvanced.Location = new System.Drawing.Point(7, 451);
            this.grpAdvanced.Name = "grpAdvanced";
            this.grpAdvanced.Size = new System.Drawing.Size(364, 131);
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
            this.cbMinConcatWords.Location = new System.Drawing.Point(312, 23);
            this.cbMinConcatWords.Name = "cbMinConcatWords";
            this.cbMinConcatWords.Size = new System.Drawing.Size(38, 23);
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
            this.cbMaxConcatWords.Location = new System.Drawing.Point(128, 23);
            this.cbMaxConcatWords.Name = "cbMaxConcatWords";
            this.cbMaxConcatWords.Size = new System.Drawing.Size(38, 23);
            this.cbMaxConcatWords.TabIndex = 81;
            // 
            // lblMinConcatWords
            // 
            this.lblMinConcatWords.AutoSize = true;
            this.lblMinConcatWords.Location = new System.Drawing.Point(194, 25);
            this.lblMinConcatWords.Name = "lblMinConcatWords";
            this.lblMinConcatWords.Size = new System.Drawing.Size(112, 15);
            this.lblMinConcatWords.TabIndex = 80;
            this.lblMinConcatWords.Text = "Min Concat. Words:";
            // 
            // lblMaxConcatWords
            // 
            this.lblMaxConcatWords.AutoSize = true;
            this.lblMaxConcatWords.Location = new System.Drawing.Point(4, 25);
            this.lblMaxConcatWords.Name = "lblMaxConcatWords";
            this.lblMaxConcatWords.Size = new System.Drawing.Size(114, 15);
            this.lblMaxConcatWords.TabIndex = 79;
            this.lblMaxConcatWords.Text = "Max Concat. Words:";
            // 
            // chkDictionaryAdvanced
            // 
            this.chkDictionaryAdvanced.AutoSize = true;
            this.chkDictionaryAdvanced.Location = new System.Drawing.Point(9, 1);
            this.chkDictionaryAdvanced.Name = "chkDictionaryAdvanced";
            this.chkDictionaryAdvanced.Size = new System.Drawing.Size(15, 14);
            this.chkDictionaryAdvanced.TabIndex = 56;
            this.chkDictionaryAdvanced.UseVisualStyleBackColor = true;
            this.chkDictionaryAdvanced.CheckedChanged += new System.EventHandler(this.OnDictionaryAdvancedCheckedChanged);
            // 
            // lblOnlyLastTwoWordsConcat
            // 
            this.lblOnlyLastTwoWordsConcat.AutoSize = true;
            this.lblOnlyLastTwoWordsConcat.Location = new System.Drawing.Point(193, 106);
            this.lblOnlyLastTwoWordsConcat.Name = "lblOnlyLastTwoWordsConcat";
            this.lblOnlyLastTwoWordsConcat.Size = new System.Drawing.Size(124, 15);
            this.lblOnlyLastTwoWordsConcat.TabIndex = 78;
            this.lblOnlyLastTwoWordsConcat.Text = "Last 2 Words Concat. :";
            // 
            // chkOnlyLastTwoWordsConcat
            // 
            this.chkOnlyLastTwoWordsConcat.AutoSize = true;
            this.chkOnlyLastTwoWordsConcat.Checked = true;
            this.chkOnlyLastTwoWordsConcat.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOnlyLastTwoWordsConcat.Location = new System.Drawing.Point(335, 107);
            this.chkOnlyLastTwoWordsConcat.Name = "chkOnlyLastTwoWordsConcat";
            this.chkOnlyLastTwoWordsConcat.Size = new System.Drawing.Size(15, 14);
            this.chkOnlyLastTwoWordsConcat.TabIndex = 77;
            this.chkOnlyLastTwoWordsConcat.UseVisualStyleBackColor = true;
            // 
            // lblOnlyFirstTwoWordsConcat
            // 
            this.lblOnlyFirstTwoWordsConcat.AutoSize = true;
            this.lblOnlyFirstTwoWordsConcat.Location = new System.Drawing.Point(4, 106);
            this.lblOnlyFirstTwoWordsConcat.Name = "lblOnlyFirstTwoWordsConcat";
            this.lblOnlyFirstTwoWordsConcat.Size = new System.Drawing.Size(125, 15);
            this.lblOnlyFirstTwoWordsConcat.TabIndex = 38;
            this.lblOnlyFirstTwoWordsConcat.Text = "First 2 Words Concat. :";
            // 
            // chkOnlyFirstTwoWordsConcat
            // 
            this.chkOnlyFirstTwoWordsConcat.AutoSize = true;
            this.chkOnlyFirstTwoWordsConcat.Checked = true;
            this.chkOnlyFirstTwoWordsConcat.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOnlyFirstTwoWordsConcat.Location = new System.Drawing.Point(151, 107);
            this.chkOnlyFirstTwoWordsConcat.Name = "chkOnlyFirstTwoWordsConcat";
            this.chkOnlyFirstTwoWordsConcat.Size = new System.Drawing.Size(15, 14);
            this.chkOnlyFirstTwoWordsConcat.TabIndex = 37;
            this.chkOnlyFirstTwoWordsConcat.UseVisualStyleBackColor = true;
            // 
            // lblMaxConsecutiveConcat
            // 
            this.lblMaxConsecutiveConcat.AutoSize = true;
            this.lblMaxConsecutiveConcat.Location = new System.Drawing.Point(4, 51);
            this.lblMaxConsecutiveConcat.Name = "lblMaxConsecutiveConcat";
            this.lblMaxConsecutiveConcat.Size = new System.Drawing.Size(113, 15);
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
            this.cbMinWordsLimit.Location = new System.Drawing.Point(312, 76);
            this.cbMinWordsLimit.Name = "cbMinWordsLimit";
            this.cbMinWordsLimit.Size = new System.Drawing.Size(38, 23);
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
            this.cbMaxConsecutiveConcat.Location = new System.Drawing.Point(128, 50);
            this.cbMaxConsecutiveConcat.Name = "cbMaxConsecutiveConcat";
            this.cbMaxConsecutiveConcat.Size = new System.Drawing.Size(38, 23);
            this.cbMaxConsecutiveConcat.TabIndex = 62;
            // 
            // lblMinWordsLimit
            // 
            this.lblMinWordsLimit.AutoSize = true;
            this.lblMinWordsLimit.Location = new System.Drawing.Point(194, 79);
            this.lblMinWordsLimit.Name = "lblMinWordsLimit";
            this.lblMinWordsLimit.Size = new System.Drawing.Size(98, 15);
            this.lblMinWordsLimit.TabIndex = 75;
            this.lblMinWordsLimit.Text = "Min Words Limit:";
            // 
            // lblMinConsecutiveConcat
            // 
            this.lblMinConsecutiveConcat.AutoSize = true;
            this.lblMinConsecutiveConcat.Location = new System.Drawing.Point(194, 51);
            this.lblMinConsecutiveConcat.Name = "lblMinConsecutiveConcat";
            this.lblMinConsecutiveConcat.Size = new System.Drawing.Size(111, 15);
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
            this.cbMaxConsecutiveOnes.Location = new System.Drawing.Point(128, 76);
            this.cbMaxConsecutiveOnes.Name = "cbMaxConsecutiveOnes";
            this.cbMaxConsecutiveOnes.Size = new System.Drawing.Size(38, 23);
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
            this.cbMinConsecutiveConcat.Location = new System.Drawing.Point(312, 50);
            this.cbMinConsecutiveConcat.Name = "cbMinConsecutiveConcat";
            this.cbMinConsecutiveConcat.Size = new System.Drawing.Size(38, 23);
            this.cbMinConsecutiveConcat.TabIndex = 64;
            // 
            // lblMaxConsecutiveOnes
            // 
            this.lblMaxConsecutiveOnes.AutoSize = true;
            this.lblMaxConsecutiveOnes.Location = new System.Drawing.Point(4, 79);
            this.lblMaxConsecutiveOnes.Name = "lblMaxConsecutiveOnes";
            this.lblMaxConsecutiveOnes.Size = new System.Drawing.Size(99, 15);
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
            this.grpTypos.Location = new System.Drawing.Point(8, 351);
            this.grpTypos.Name = "grpTypos";
            this.grpTypos.Size = new System.Drawing.Size(363, 95);
            this.grpTypos.TabIndex = 80;
            this.grpTypos.TabStop = false;
            this.grpTypos.Text = "Typos";
            // 
            // txtTyposSwapLetters
            // 
            this.txtTyposSwapLetters.Location = new System.Drawing.Point(88, 67);
            this.txtTyposSwapLetters.Name = "txtTyposSwapLetters";
            this.txtTyposSwapLetters.PlaceholderText = "l-r,a-e,i-y";
            this.txtTyposSwapLetters.Size = new System.Drawing.Size(77, 23);
            this.txtTyposSwapLetters.TabIndex = 86;
            // 
            // lblTyposSwapLetters
            // 
            this.lblTyposSwapLetters.AutoSize = true;
            this.lblTyposSwapLetters.Location = new System.Drawing.Point(12, 70);
            this.lblTyposSwapLetters.Name = "lblTyposSwapLetters";
            this.lblTyposSwapLetters.Size = new System.Drawing.Size(70, 15);
            this.lblTyposSwapLetters.TabIndex = 85;
            this.lblTyposSwapLetters.Text = "Letter swap:";
            // 
            // chkTyposReverseLetter
            // 
            this.chkTyposReverseLetter.AutoSize = true;
            this.chkTyposReverseLetter.Checked = true;
            this.chkTyposReverseLetter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTyposReverseLetter.Location = new System.Drawing.Point(121, 21);
            this.chkTyposReverseLetter.Name = "chkTyposReverseLetter";
            this.chkTyposReverseLetter.Size = new System.Drawing.Size(99, 19);
            this.chkTyposReverseLetter.TabIndex = 84;
            this.chkTyposReverseLetter.Text = "Reverse Letter";
            this.chkTyposReverseLetter.UseVisualStyleBackColor = true;
            // 
            // chkTyposWrongLetter
            // 
            this.chkTyposWrongLetter.AutoSize = true;
            this.chkTyposWrongLetter.Checked = true;
            this.chkTyposWrongLetter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTyposWrongLetter.Location = new System.Drawing.Point(121, 46);
            this.chkTyposWrongLetter.Name = "chkTyposWrongLetter";
            this.chkTyposWrongLetter.Size = new System.Drawing.Size(95, 19);
            this.chkTyposWrongLetter.TabIndex = 83;
            this.chkTyposWrongLetter.Text = "Wrong Letter";
            this.chkTyposWrongLetter.UseVisualStyleBackColor = true;
            // 
            // chkTyposExtraLetter
            // 
            this.chkTyposExtraLetter.AutoSize = true;
            this.chkTyposExtraLetter.Checked = true;
            this.chkTyposExtraLetter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTyposExtraLetter.Location = new System.Drawing.Point(12, 21);
            this.chkTyposExtraLetter.Name = "chkTyposExtraLetter";
            this.chkTyposExtraLetter.Size = new System.Drawing.Size(85, 19);
            this.chkTyposExtraLetter.TabIndex = 82;
            this.chkTyposExtraLetter.Text = "Extra Letter";
            this.chkTyposExtraLetter.UseVisualStyleBackColor = true;
            // 
            // chkTyposDoubleLetter
            // 
            this.chkTyposDoubleLetter.AutoSize = true;
            this.chkTyposDoubleLetter.Checked = true;
            this.chkTyposDoubleLetter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTyposDoubleLetter.Location = new System.Drawing.Point(236, 21);
            this.chkTyposDoubleLetter.Name = "chkTyposDoubleLetter";
            this.chkTyposDoubleLetter.Size = new System.Drawing.Size(97, 19);
            this.chkTyposDoubleLetter.TabIndex = 81;
            this.chkTyposDoubleLetter.Text = "Double Letter";
            this.chkTyposDoubleLetter.UseVisualStyleBackColor = true;
            // 
            // chkTyposSkipLetter
            // 
            this.chkTyposSkipLetter.AutoSize = true;
            this.chkTyposSkipLetter.Checked = true;
            this.chkTyposSkipLetter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTyposSkipLetter.Location = new System.Drawing.Point(12, 46);
            this.chkTyposSkipLetter.Name = "chkTyposSkipLetter";
            this.chkTyposSkipLetter.Size = new System.Drawing.Size(81, 19);
            this.chkTyposSkipLetter.TabIndex = 80;
            this.chkTyposSkipLetter.Text = "Skip Letter";
            this.chkTyposSkipLetter.UseVisualStyleBackColor = true;
            // 
            // chkTyposSkipDoubleLetter
            // 
            this.chkTyposSkipDoubleLetter.AutoSize = true;
            this.chkTyposSkipDoubleLetter.Checked = true;
            this.chkTyposSkipDoubleLetter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTyposSkipDoubleLetter.Location = new System.Drawing.Point(236, 46);
            this.chkTyposSkipDoubleLetter.Name = "chkTyposSkipDoubleLetter";
            this.chkTyposSkipDoubleLetter.Size = new System.Drawing.Size(122, 19);
            this.chkTyposSkipDoubleLetter.TabIndex = 79;
            this.chkTyposSkipDoubleLetter.Text = "Skip Double Letter";
            this.chkTyposSkipDoubleLetter.UseVisualStyleBackColor = true;
            // 
            // txtIncludeWordsCharacter
            // 
            this.txtIncludeWordsCharacter.Location = new System.Drawing.Point(120, 106);
            this.txtIncludeWordsCharacter.Name = "txtIncludeWordsCharacter";
            this.txtIncludeWordsCharacter.PlaceholderText = "mario";
            this.txtIncludeWordsCharacter.Size = new System.Drawing.Size(611, 23);
            this.txtIncludeWordsCharacter.TabIndex = 31;
            this.txtIncludeWordsCharacter.TextChanged += new System.EventHandler(this.OnTxtIncludeWordsCharacterTextChanged);
            // 
            // pnlCharacter
            // 
            this.pnlCharacter.Controls.Add(this.grpCharsetPreview);
            this.pnlCharacter.Controls.Add(this.grpGeneral);
            this.pnlCharacter.Controls.Add(this.grpSpecials);
            this.pnlCharacter.Controls.Add(this.txtHashCatPath);
            this.pnlCharacter.Controls.Add(this.lblHashCat);
            this.pnlCharacter.Location = new System.Drawing.Point(12, 104);
            this.pnlCharacter.Name = "pnlCharacter";
            this.pnlCharacter.Size = new System.Drawing.Size(774, 586);
            this.pnlCharacter.TabIndex = 32;
            // 
            // grpCharsetPreview
            // 
            this.grpCharsetPreview.Controls.Add(this.lblStartingValidCharsPreview);
            this.grpCharsetPreview.Controls.Add(this.txtStartingValidCharsPreview);
            this.grpCharsetPreview.Controls.Add(this.lblValidCharsPreview);
            this.grpCharsetPreview.Controls.Add(this.txtValidCharsPreview);
            this.grpCharsetPreview.Location = new System.Drawing.Point(397, 202);
            this.grpCharsetPreview.Name = "grpCharsetPreview";
            this.grpCharsetPreview.Size = new System.Drawing.Size(364, 332);
            this.grpCharsetPreview.TabIndex = 43;
            this.grpCharsetPreview.TabStop = false;
            this.grpCharsetPreview.Text = "Charset Previews";
            // 
            // lblStartingValidCharsPreview
            // 
            this.lblStartingValidCharsPreview.AutoSize = true;
            this.lblStartingValidCharsPreview.Location = new System.Drawing.Point(11, 176);
            this.lblStartingValidCharsPreview.Name = "lblStartingValidCharsPreview";
            this.lblStartingValidCharsPreview.Size = new System.Drawing.Size(84, 15);
            this.lblStartingValidCharsPreview.TabIndex = 43;
            this.lblStartingValidCharsPreview.Text = "Starting Chars:";
            // 
            // txtStartingValidCharsPreview
            // 
            this.txtStartingValidCharsPreview.Location = new System.Drawing.Point(11, 206);
            this.txtStartingValidCharsPreview.Multiline = true;
            this.txtStartingValidCharsPreview.Name = "txtStartingValidCharsPreview";
            this.txtStartingValidCharsPreview.ReadOnly = true;
            this.txtStartingValidCharsPreview.Size = new System.Drawing.Size(345, 108);
            this.txtStartingValidCharsPreview.TabIndex = 42;
            // 
            // lblValidCharsPreview
            // 
            this.lblValidCharsPreview.AutoSize = true;
            this.lblValidCharsPreview.Location = new System.Drawing.Point(9, 22);
            this.lblValidCharsPreview.Name = "lblValidCharsPreview";
            this.lblValidCharsPreview.Size = new System.Drawing.Size(68, 15);
            this.lblValidCharsPreview.TabIndex = 41;
            this.lblValidCharsPreview.Text = "Valid Chars:";
            // 
            // txtValidCharsPreview
            // 
            this.txtValidCharsPreview.Location = new System.Drawing.Point(9, 52);
            this.txtValidCharsPreview.Multiline = true;
            this.txtValidCharsPreview.Name = "txtValidCharsPreview";
            this.txtValidCharsPreview.ReadOnly = true;
            this.txtValidCharsPreview.Size = new System.Drawing.Size(347, 108);
            this.txtValidCharsPreview.TabIndex = 0;
            // 
            // grpGeneral
            // 
            this.grpGeneral.Controls.Add(this.txtValidChars);
            this.grpGeneral.Controls.Add(this.lblValidChars);
            this.grpGeneral.Controls.Add(this.lblUtf8Toggle);
            this.grpGeneral.Controls.Add(this.lblStartingValidChars);
            this.grpGeneral.Controls.Add(this.lblEndPosition);
            this.grpGeneral.Controls.Add(this.chkUtf8Toggle);
            this.grpGeneral.Controls.Add(this.txtStartingValidChars);
            this.grpGeneral.Controls.Add(this.lblIncludeWordCharacters);
            this.grpGeneral.Controls.Add(this.txtIncludeWordsCharacter);
            this.grpGeneral.Controls.Add(this.numEndPosition);
            this.grpGeneral.Controls.Add(this.lblStartPosition);
            this.grpGeneral.Controls.Add(this.numStartPosition);
            this.grpGeneral.Location = new System.Drawing.Point(8, 4);
            this.grpGeneral.Name = "grpGeneral";
            this.grpGeneral.Size = new System.Drawing.Size(753, 192);
            this.grpGeneral.TabIndex = 42;
            this.grpGeneral.TabStop = false;
            this.grpGeneral.Text = "Bruteforce Settings";
            // 
            // txtValidChars
            // 
            this.txtValidChars.Location = new System.Drawing.Point(120, 22);
            this.txtValidChars.Name = "txtValidChars";
            this.txtValidChars.Size = new System.Drawing.Size(611, 23);
            this.txtValidChars.TabIndex = 31;
            this.txtValidChars.Text = "etainoshrdlucmfwygpbvkqjxz0123456789_";
            this.txtValidChars.TextChanged += new System.EventHandler(this.TxtValidCharsChanged);
            // 
            // lblValidChars
            // 
            this.lblValidChars.AutoSize = true;
            this.lblValidChars.Location = new System.Drawing.Point(12, 26);
            this.lblValidChars.Name = "lblValidChars";
            this.lblValidChars.Size = new System.Drawing.Size(68, 15);
            this.lblValidChars.TabIndex = 31;
            this.lblValidChars.Text = "Valid Chars:";
            // 
            // lblUtf8Toggle
            // 
            this.lblUtf8Toggle.AutoSize = true;
            this.lblUtf8Toggle.Location = new System.Drawing.Point(493, 154);
            this.lblUtf8Toggle.Name = "lblUtf8Toggle";
            this.lblUtf8Toggle.Size = new System.Drawing.Size(74, 15);
            this.lblUtf8Toggle.TabIndex = 37;
            this.lblUtf8Toggle.Text = "Enable UTF8:";
            // 
            // lblStartingValidChars
            // 
            this.lblStartingValidChars.AutoSize = true;
            this.lblStartingValidChars.Location = new System.Drawing.Point(12, 68);
            this.lblStartingValidChars.Name = "lblStartingValidChars";
            this.lblStartingValidChars.Size = new System.Drawing.Size(84, 15);
            this.lblStartingValidChars.TabIndex = 32;
            this.lblStartingValidChars.Text = "Starting Chars:";
            // 
            // lblEndPosition
            // 
            this.lblEndPosition.AutoSize = true;
            this.lblEndPosition.Location = new System.Drawing.Point(236, 152);
            this.lblEndPosition.Name = "lblEndPosition";
            this.lblEndPosition.Size = new System.Drawing.Size(76, 15);
            this.lblEndPosition.TabIndex = 36;
            this.lblEndPosition.Text = "End Position:";
            // 
            // chkUtf8Toggle
            // 
            this.chkUtf8Toggle.AutoSize = true;
            this.chkUtf8Toggle.Location = new System.Drawing.Point(601, 156);
            this.chkUtf8Toggle.Name = "chkUtf8Toggle";
            this.chkUtf8Toggle.Size = new System.Drawing.Size(15, 14);
            this.chkUtf8Toggle.TabIndex = 40;
            this.chkUtf8Toggle.UseVisualStyleBackColor = true;
            this.chkUtf8Toggle.CheckedChanged += new System.EventHandler(this.Utf8ToggleCheckedChanged);
            // 
            // txtStartingValidChars
            // 
            this.txtStartingValidChars.Location = new System.Drawing.Point(120, 64);
            this.txtStartingValidChars.Name = "txtStartingValidChars";
            this.txtStartingValidChars.Size = new System.Drawing.Size(611, 23);
            this.txtStartingValidChars.TabIndex = 33;
            this.txtStartingValidChars.Text = "etainoshrdlucmfwygpbvkqjxz_";
            this.txtStartingValidChars.TextChanged += new System.EventHandler(this.TxtStartingValidCharsChanged);
            // 
            // lblIncludeWordCharacters
            // 
            this.lblIncludeWordCharacters.AutoSize = true;
            this.lblIncludeWordCharacters.Location = new System.Drawing.Point(12, 110);
            this.lblIncludeWordCharacters.Name = "lblIncludeWordCharacters";
            this.lblIncludeWordCharacters.Size = new System.Drawing.Size(81, 15);
            this.lblIncludeWordCharacters.TabIndex = 33;
            this.lblIncludeWordCharacters.Text = "Include Word:";
            // 
            // numEndPosition
            // 
            this.numEndPosition.Location = new System.Drawing.Point(336, 148);
            this.numEndPosition.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numEndPosition.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numEndPosition.Name = "numEndPosition";
            this.numEndPosition.Size = new System.Drawing.Size(79, 23);
            this.numEndPosition.TabIndex = 37;
            // 
            // lblStartPosition
            // 
            this.lblStartPosition.AutoSize = true;
            this.lblStartPosition.Location = new System.Drawing.Point(12, 152);
            this.lblStartPosition.Name = "lblStartPosition";
            this.lblStartPosition.Size = new System.Drawing.Size(80, 15);
            this.lblStartPosition.TabIndex = 34;
            this.lblStartPosition.Text = "Start Position:";
            // 
            // numStartPosition
            // 
            this.numStartPosition.Location = new System.Drawing.Point(119, 148);
            this.numStartPosition.Name = "numStartPosition";
            this.numStartPosition.Size = new System.Drawing.Size(79, 23);
            this.numStartPosition.TabIndex = 35;
            // 
            // grpSpecials
            // 
            this.grpSpecials.Controls.Add(this.chklCharsets);
            this.grpSpecials.Location = new System.Drawing.Point(8, 202);
            this.grpSpecials.Name = "grpSpecials";
            this.grpSpecials.Size = new System.Drawing.Size(375, 332);
            this.grpSpecials.TabIndex = 41;
            this.grpSpecials.TabStop = false;
            this.grpSpecials.Text = "Special charsets";
            // 
            // chklCharsets
            // 
            this.chklCharsets.FormattingEnabled = true;
            this.chklCharsets.Location = new System.Drawing.Point(7, 22);
            this.chklCharsets.Name = "chklCharsets";
            this.chklCharsets.Size = new System.Drawing.Size(356, 256);
            this.chklCharsets.TabIndex = 0;
            this.chklCharsets.SelectedIndexChanged += new System.EventHandler(this.ChklCharsetsSelectedIndexChanged);
            this.chklCharsets.SelectedValueChanged += new System.EventHandler(this.ChklCharsetsSelectedValueChanged);
            // 
            // txtHashCatPath
            // 
            this.txtHashCatPath.Location = new System.Drawing.Point(115, 552);
            this.txtHashCatPath.Name = "txtHashCatPath";
            this.txtHashCatPath.Size = new System.Drawing.Size(379, 23);
            this.txtHashCatPath.TabIndex = 39;
            // 
            // lblHashCat
            // 
            this.lblHashCat.AutoSize = true;
            this.lblHashCat.Location = new System.Drawing.Point(8, 555);
            this.lblHashCat.Name = "lblHashCat";
            this.lblHashCat.Size = new System.Drawing.Size(80, 15);
            this.lblHashCat.TabIndex = 38;
            this.lblHashCat.Text = "Hashcat Path:";
            // 
            // chkVerbose
            // 
            this.chkVerbose.AutoSize = true;
            this.chkVerbose.Checked = true;
            this.chkVerbose.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkVerbose.Location = new System.Drawing.Point(822, 38);
            this.chkVerbose.Name = "chkVerbose";
            this.chkVerbose.Size = new System.Drawing.Size(15, 14);
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
            this.mnStrip.Size = new System.Drawing.Size(848, 24);
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
            this.mnFile.Size = new System.Drawing.Size(37, 20);
            this.mnFile.Text = "File";
            // 
            // mnNew
            // 
            this.mnNew.Name = "mnNew";
            this.mnNew.Size = new System.Drawing.Size(138, 22);
            this.mnNew.Text = "New";
            // 
            // mnSeparator
            // 
            this.mnSeparator.Name = "mnSeparator";
            this.mnSeparator.Size = new System.Drawing.Size(135, 6);
            // 
            // mnRefresh
            // 
            this.mnRefresh.Name = "mnRefresh";
            this.mnRefresh.Size = new System.Drawing.Size(138, 22);
            this.mnRefresh.Text = "Refresh";
            // 
            // mnSeparator2
            // 
            this.mnSeparator2.Name = "mnSeparator2";
            this.mnSeparator2.Size = new System.Drawing.Size(135, 6);
            // 
            // mnQuickLoad
            // 
            this.mnQuickLoad.Name = "mnQuickLoad";
            this.mnQuickLoad.Size = new System.Drawing.Size(138, 22);
            this.mnQuickLoad.Text = "Quick Load";
            // 
            // mnQuickSave
            // 
            this.mnQuickSave.Name = "mnQuickSave";
            this.mnQuickSave.Size = new System.Drawing.Size(138, 22);
            this.mnQuickSave.Text = "Quick Save";
            // 
            // mnQuickClean
            // 
            this.mnQuickClean.Name = "mnQuickClean";
            this.mnQuickClean.Size = new System.Drawing.Size(138, 22);
            this.mnQuickClean.Text = "Quick Clean";
            // 
            // mnSeparator3
            // 
            this.mnSeparator3.Name = "mnSeparator3";
            this.mnSeparator3.Size = new System.Drawing.Size(135, 6);
            // 
            // mnLoad
            // 
            this.mnLoad.Name = "mnLoad";
            this.mnLoad.Size = new System.Drawing.Size(138, 22);
            this.mnLoad.Text = "Load...";
            // 
            // mnSave
            // 
            this.mnSave.Name = "mnSave";
            this.mnSave.Size = new System.Drawing.Size(138, 22);
            this.mnSave.Text = "Save...";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.printLatestCommandToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // printLatestCommandToolStripMenuItem
            // 
            this.printLatestCommandToolStripMenuItem.Name = "printLatestCommandToolStripMenuItem";
            this.printLatestCommandToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
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
            this.lblVerbose.Location = new System.Drawing.Point(748, 36);
            this.lblVerbose.Name = "lblVerbose";
            this.lblVerbose.Size = new System.Drawing.Size(51, 15);
            this.lblVerbose.TabIndex = 35;
            this.lblVerbose.Text = "Verbose:";
            // 
            // btnStartHashCat
            // 
            this.btnStartHashCat.Location = new System.Drawing.Point(409, 694);
            this.btnStartHashCat.Name = "btnStartHashCat";
            this.btnStartHashCat.Size = new System.Drawing.Size(213, 22);
            this.btnStartHashCat.TabIndex = 36;
            this.btnStartHashCat.Text = "START (HashCat)";
            this.btnStartHashCat.UseVisualStyleBackColor = true;
            this.btnStartHashCat.Click += new System.EventHandler(this.OnStartHashCatClick);
            // 
            // btnQuickSave
            // 
            this.btnQuickSave.Location = new System.Drawing.Point(284, 73);
            this.btnQuickSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnQuickSave.Name = "btnQuickSave";
            this.btnQuickSave.Size = new System.Drawing.Size(46, 20);
            this.btnQuickSave.TabIndex = 37;
            this.btnQuickSave.Text = "Save";
            this.btnQuickSave.UseVisualStyleBackColor = true;
            // 
            // btnQuickLoad
            // 
            this.btnQuickLoad.Location = new System.Drawing.Point(330, 73);
            this.btnQuickLoad.Margin = new System.Windows.Forms.Padding(2);
            this.btnQuickLoad.Name = "btnQuickLoad";
            this.btnQuickLoad.Size = new System.Drawing.Size(47, 20);
            this.btnQuickLoad.TabIndex = 38;
            this.btnQuickLoad.Text = "Load";
            this.btnQuickLoad.UseVisualStyleBackColor = true;
            // 
            // lblTyposAppendLetters
            // 
            this.lblTyposAppendLetters.AutoSize = true;
            this.lblTyposAppendLetters.Location = new System.Drawing.Point(183, 70);
            this.lblTyposAppendLetters.Name = "lblTyposAppendLetters";
            this.lblTyposAppendLetters.Size = new System.Drawing.Size(85, 15);
            this.lblTyposAppendLetters.TabIndex = 87;
            this.lblTyposAppendLetters.Text = "Append Letter:";
            // 
            // txtTyposAppendLetters
            // 
            this.txtTyposAppendLetters.Location = new System.Drawing.Point(274, 66);
            this.txtTyposAppendLetters.Name = "txtTyposAppendLetters";
            this.txtTyposAppendLetters.PlaceholderText = "s,ed";
            this.txtTyposAppendLetters.Size = new System.Drawing.Size(77, 23);
            this.txtTyposAppendLetters.TabIndex = 88;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(848, 730);
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
            this.Controls.Add(this.pnlCharacter);
            this.MainMenuStrip = this.mnStrip;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "BruteForceHash";
            this.pnlDictionary.ResumeLayout(false);
            this.grpSizeFiltering.ResumeLayout(false);
            this.grpSizeFiltering.PerformLayout();
            this.groupBoxWordFiltering.ResumeLayout(false);
            this.groupBoxWordFiltering.PerformLayout();
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
            this.grpAdvanced.ResumeLayout(false);
            this.grpAdvanced.PerformLayout();
            this.grpTypos.ResumeLayout(false);
            this.grpTypos.PerformLayout();
            this.pnlCharacter.ResumeLayout(false);
            this.pnlCharacter.PerformLayout();
            this.grpCharsetPreview.ResumeLayout(false);
            this.grpCharsetPreview.PerformLayout();
            this.grpGeneral.ResumeLayout(false);
            this.grpGeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numEndPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStartPosition)).EndInit();
            this.grpSpecials.ResumeLayout(false);
            this.mnStrip.ResumeLayout(false);
            this.mnStrip.PerformLayout();
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
        private System.Windows.Forms.Panel pnlCharacter;
        private System.Windows.Forms.TextBox txtIncludeWordsCharacter;
        private System.Windows.Forms.Label lblValidChars;
        private System.Windows.Forms.TextBox txtValidChars;
        private System.Windows.Forms.TextBox txtStartingValidChars;
        private System.Windows.Forms.Label lblStartingValidChars;
        private System.Windows.Forms.Label lblIncludeWordCharacters;
        private System.Windows.Forms.CheckBox chkVerbose;
        private System.Windows.Forms.ComboBox cbCombinationOrder;
        private System.Windows.Forms.NumericUpDown numStartPosition;
        private System.Windows.Forms.Label lblStartPosition;
        private System.Windows.Forms.Label lblEndPosition;
        private System.Windows.Forms.NumericUpDown numEndPosition;
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
        private System.Windows.Forms.Label lblHashCat;
        private System.Windows.Forms.TextBox txtHashCatPath;
        private System.Windows.Forms.CheckBox chkIncludeWordNotLast;
        private System.Windows.Forms.Label lblUtf8Toggle;
        private System.Windows.Forms.CheckBox chkUtf8Toggle;
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
        private System.Windows.Forms.GroupBox grpSpecials;
        private System.Windows.Forms.GroupBox grpGeneral;
        private System.Windows.Forms.CheckedListBox chklCharsets;
        private System.Windows.Forms.GroupBox grpCharsetPreview;
        private System.Windows.Forms.Label lblStartingValidCharsPreview;
        private System.Windows.Forms.Label lblValidCharsPreview;
        private System.Windows.Forms.TextBox txtValidCharsPreview;
        private System.Windows.Forms.TextBox txtStartingValidCharsPreview;
        private System.Windows.Forms.Label lblDictionaryFilterFirstFrom;
        private System.Windows.Forms.TextBox txtDictionaryFilterFirstFrom;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBoxWordFiltering;
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
    }
}


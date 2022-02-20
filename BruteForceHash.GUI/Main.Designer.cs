
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
            this.lblDictionaries = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblSuffix = new System.Windows.Forms.Label();
            this.txtSuffix = new System.Windows.Forms.TextBox();
            this.lblCombinationOrder = new System.Windows.Forms.Label();
            this.pnlDictionary = new System.Windows.Forms.Panel();
            this.groupBoxWordFiltering = new System.Windows.Forms.GroupBox();
            this.cbIncludePatternsSamples = new System.Windows.Forms.ComboBox();
            this.cbExcludePatternsSamples = new System.Windows.Forms.ComboBox();
            this.cbCombinationOrder = new System.Windows.Forms.ComboBox();
            this.chkIncludeWordNotLast = new System.Windows.Forms.CheckBox();
            this.chkIncludeWordNotFirst = new System.Windows.Forms.CheckBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnDictUnselected = new System.Windows.Forms.Button();
            this.txtDictionaryFilterFirst = new System.Windows.Forms.TextBox();
            this.lblDictionaryFilterFirst = new System.Windows.Forms.Label();
            this.chklDictionaries = new System.Windows.Forms.CheckedListBox();
            this.chkDictSkipDigits = new System.Windows.Forms.CheckBox();
            this.chkDictSkipSpecials = new System.Windows.Forms.CheckBox();
            this.chkDictForceLowercase = new System.Windows.Forms.CheckBox();
            this.chkDictAddTypos = new System.Windows.Forms.CheckBox();
            this.chkDictReverseOrder = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnCopyToDictFirst = new System.Windows.Forms.Button();
            this.btnDictFirstUnselected = new System.Windows.Forms.Button();
            this.chklDictionariesFirstWord = new System.Windows.Forms.CheckedListBox();
            this.lblDictionariesFirstWord = new System.Windows.Forms.Label();
            this.chkUseCustomDictFirst = new System.Windows.Forms.CheckBox();
            this.chkDictFirstSkipDigits = new System.Windows.Forms.CheckBox();
            this.chkDictFirstSkipSpecials = new System.Windows.Forms.CheckBox();
            this.chkDictFirstForceLowercase = new System.Windows.Forms.CheckBox();
            this.chkDictFirstAddTypos = new System.Windows.Forms.CheckBox();
            this.chkDictFirstReverseOrder = new System.Windows.Forms.CheckBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnCopyToDictLast = new System.Windows.Forms.Button();
            this.btnDictLastUnselected = new System.Windows.Forms.Button();
            this.chklDictionariesLastWord = new System.Windows.Forms.CheckedListBox();
            this.lblDictionaryLastWord = new System.Windows.Forms.Label();
            this.chkUseCustomDictLast = new System.Windows.Forms.CheckBox();
            this.chkDictLastReverseOrder = new System.Windows.Forms.CheckBox();
            this.chkDictLastSkipDigits = new System.Windows.Forms.CheckBox();
            this.chkDictLastAddTypos = new System.Windows.Forms.CheckBox();
            this.chkDictLastSkipSpecials = new System.Windows.Forms.CheckBox();
            this.chkDictLastForceLowercase = new System.Windows.Forms.CheckBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.txtDictCustWords = new System.Windows.Forms.TextBox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.txtDictFirstCustWords = new System.Windows.Forms.TextBox();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.txtDictLastCustWords = new System.Windows.Forms.TextBox();
            this.grpAdvanced = new System.Windows.Forms.GroupBox();
            this.cbMinConcatWords = new System.Windows.Forms.ComboBox();
            this.cbMaxConcatWords = new System.Windows.Forms.ComboBox();
            this.lblMinConcatWords = new System.Windows.Forms.Label();
            this.lblMaxConcatWords = new System.Windows.Forms.Label();
            this.chkDictionaryAdvanced = new System.Windows.Forms.CheckBox();
            this.lblMaxDelim = new System.Windows.Forms.Label();
            this.lblOnlyLastTwoWordsConcat = new System.Windows.Forms.Label();
            this.cbMaxDelim = new System.Windows.Forms.ComboBox();
            this.chkOnlyLastTwoWordsConcat = new System.Windows.Forms.CheckBox();
            this.lblMinDelim = new System.Windows.Forms.Label();
            this.lblOnlyFirstTwoWordsConcat = new System.Windows.Forms.Label();
            this.cbMinDelim = new System.Windows.Forms.ComboBox();
            this.chkOnlyFirstTwoWordsConcat = new System.Windows.Forms.CheckBox();
            this.lblMaxConsecutiveConcat = new System.Windows.Forms.Label();
            this.cbMinWordsLimit = new System.Windows.Forms.ComboBox();
            this.cbMaxConsecutiveConcat = new System.Windows.Forms.ComboBox();
            this.lblMinWordsLimit = new System.Windows.Forms.Label();
            this.lblMinConsecutiveConcat = new System.Windows.Forms.Label();
            this.cbMaxConsecutiveOnes = new System.Windows.Forms.ComboBox();
            this.cbMinConsecutiveConcat = new System.Windows.Forms.ComboBox();
            this.lblMaxConsecutiveOnes = new System.Windows.Forms.Label();
            this.lblMaxWordLength = new System.Windows.Forms.Label();
            this.cbMinOnes = new System.Windows.Forms.ComboBox();
            this.cbMaxWordLength = new System.Windows.Forms.ComboBox();
            this.lblMinOnes = new System.Windows.Forms.Label();
            this.lblMinWordLength = new System.Windows.Forms.Label();
            this.cbMaxOnes = new System.Windows.Forms.ComboBox();
            this.cbMinWordLength = new System.Windows.Forms.ComboBox();
            this.lblMaxOnes = new System.Windows.Forms.Label();
            this.grpTypos = new System.Windows.Forms.GroupBox();
            this.chkTyposReverseLetter = new System.Windows.Forms.CheckBox();
            this.chkTyposWrongLetter = new System.Windows.Forms.CheckBox();
            this.chkTyposExtraLetter = new System.Windows.Forms.CheckBox();
            this.chkTyposDoubleLetter = new System.Windows.Forms.CheckBox();
            this.chkTyposSkipLetter = new System.Windows.Forms.CheckBox();
            this.chkTyposLetterSwap = new System.Windows.Forms.CheckBox();
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
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            this.saveFile = new System.Windows.Forms.SaveFileDialog();
            this.lblVerbose = new System.Windows.Forms.Label();
            this.btnStartHashCat = new System.Windows.Forms.Button();
            this.btnQuickSave = new System.Windows.Forms.Button();
            this.btnQuickLoad = new System.Windows.Forms.Button();
            this.pnlDictionary.SuspendLayout();
            this.groupBoxWordFiltering.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
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
            "Character"});
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
            this.txtPrefix.Location = new System.Drawing.Point(685, 123);
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
            this.txtDelimiter.Location = new System.Drawing.Point(972, 53);
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
            this.cbNbThreads.Location = new System.Drawing.Point(685, 57);
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
            this.txtIncludeWord.PlaceholderText = "mario";
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
            // lblDictionaries
            // 
            this.lblDictionaries.AutoSize = true;
            this.lblDictionaries.Location = new System.Drawing.Point(14, 13);
            this.lblDictionaries.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDictionaries.Name = "lblDictionaries";
            this.lblDictionaries.Size = new System.Drawing.Size(103, 23);
            this.lblDictionaries.TabIndex = 22;
            this.lblDictionaries.Text = "Dictionaries:";
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
            this.txtSuffix.Location = new System.Drawing.Point(975, 123);
            this.txtSuffix.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSuffix.Name = "txtSuffix";
            this.txtSuffix.Size = new System.Drawing.Size(219, 31);
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
            this.pnlDictionary.Controls.Add(this.groupBoxWordFiltering);
            this.pnlDictionary.Controls.Add(this.tabControl);
            this.pnlDictionary.Controls.Add(this.grpAdvanced);
            this.pnlDictionary.Controls.Add(this.grpTypos);
            this.pnlDictionary.Location = new System.Drawing.Point(17, 173);
            this.pnlDictionary.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlDictionary.Name = "pnlDictionary";
            this.pnlDictionary.Size = new System.Drawing.Size(1181, 977);
            this.pnlDictionary.TabIndex = 31;
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
            this.groupBoxWordFiltering.Location = new System.Drawing.Point(10, 7);
            this.groupBoxWordFiltering.Name = "groupBoxWordFiltering";
            this.groupBoxWordFiltering.Size = new System.Drawing.Size(520, 258);
            this.groupBoxWordFiltering.TabIndex = 85;
            this.groupBoxWordFiltering.TabStop = false;
            this.groupBoxWordFiltering.Text = "Word Filtering";
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
            this.cbExcludePatternsSamples.Location = new System.Drawing.Point(450, 33);
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
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Controls.Add(this.tabPage3);
            this.tabControl.Controls.Add(this.tabPage4);
            this.tabControl.Controls.Add(this.tabPage5);
            this.tabControl.Controls.Add(this.tabPage6);
            this.tabControl.Location = new System.Drawing.Point(543, 7);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(635, 963);
            this.tabControl.TabIndex = 84;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnDictUnselected);
            this.tabPage1.Controls.Add(this.txtDictionaryFilterFirst);
            this.tabPage1.Controls.Add(this.lblDictionaryFilterFirst);
            this.tabPage1.Controls.Add(this.lblDictionaries);
            this.tabPage1.Controls.Add(this.chklDictionaries);
            this.tabPage1.Controls.Add(this.chkDictSkipDigits);
            this.tabPage1.Controls.Add(this.chkDictSkipSpecials);
            this.tabPage1.Controls.Add(this.chkDictForceLowercase);
            this.tabPage1.Controls.Add(this.chkDictAddTypos);
            this.tabPage1.Controls.Add(this.chkDictReverseOrder);
            this.tabPage1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(627, 925);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Main";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnDictUnselected
            // 
            this.btnDictUnselected.Location = new System.Drawing.Point(14, 853);
            this.btnDictUnselected.Name = "btnDictUnselected";
            this.btnDictUnselected.Size = new System.Drawing.Size(174, 37);
            this.btnDictUnselected.TabIndex = 55;
            this.btnDictUnselected.Text = "Unselect All";
            this.btnDictUnselected.UseVisualStyleBackColor = true;
            this.btnDictUnselected.Click += new System.EventHandler(this.btnDictUnselected_Click);
            // 
            // txtDictionaryFilterFirst
            // 
            this.txtDictionaryFilterFirst.Location = new System.Drawing.Point(14, 265);
            this.txtDictionaryFilterFirst.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDictionaryFilterFirst.Name = "txtDictionaryFilterFirst";
            this.txtDictionaryFilterFirst.PlaceholderText = "a-b";
            this.txtDictionaryFilterFirst.Size = new System.Drawing.Size(93, 29);
            this.txtDictionaryFilterFirst.TabIndex = 82;
            // 
            // lblDictionaryFilterFirst
            // 
            this.lblDictionaryFilterFirst.AutoSize = true;
            this.lblDictionaryFilterFirst.Location = new System.Drawing.Point(10, 233);
            this.lblDictionaryFilterFirst.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDictionaryFilterFirst.Name = "lblDictionaryFilterFirst";
            this.lblDictionaryFilterFirst.Size = new System.Drawing.Size(133, 23);
            this.lblDictionaryFilterFirst.TabIndex = 83;
            this.lblDictionaryFilterFirst.Text = "First Word Filter:";
            // 
            // chklDictionaries
            // 
            this.chklDictionaries.FormattingEnabled = true;
            this.chklDictionaries.Location = new System.Drawing.Point(195, 13);
            this.chklDictionaries.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chklDictionaries.Name = "chklDictionaries";
            this.chklDictionaries.Size = new System.Drawing.Size(425, 888);
            this.chklDictionaries.TabIndex = 23;
            // 
            // chkDictSkipDigits
            // 
            this.chkDictSkipDigits.AutoSize = true;
            this.chkDictSkipDigits.Location = new System.Drawing.Point(14, 48);
            this.chkDictSkipDigits.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkDictSkipDigits.Name = "chkDictSkipDigits";
            this.chkDictSkipDigits.Size = new System.Drawing.Size(115, 27);
            this.chkDictSkipDigits.TabIndex = 50;
            this.chkDictSkipDigits.Text = "Skip Digits";
            this.chkDictSkipDigits.UseVisualStyleBackColor = true;
            // 
            // chkDictSkipSpecials
            // 
            this.chkDictSkipSpecials.AutoSize = true;
            this.chkDictSkipSpecials.Checked = true;
            this.chkDictSkipSpecials.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDictSkipSpecials.Location = new System.Drawing.Point(14, 87);
            this.chkDictSkipSpecials.Margin = new System.Windows.Forms.Padding(4, 5, 0, 5);
            this.chkDictSkipSpecials.Name = "chkDictSkipSpecials";
            this.chkDictSkipSpecials.Size = new System.Drawing.Size(132, 27);
            this.chkDictSkipSpecials.TabIndex = 51;
            this.chkDictSkipSpecials.Text = "Skip Specials";
            this.chkDictSkipSpecials.UseVisualStyleBackColor = true;
            // 
            // chkDictForceLowercase
            // 
            this.chkDictForceLowercase.AutoSize = true;
            this.chkDictForceLowercase.Checked = true;
            this.chkDictForceLowercase.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDictForceLowercase.Location = new System.Drawing.Point(14, 123);
            this.chkDictForceLowercase.Margin = new System.Windows.Forms.Padding(4, 5, 0, 5);
            this.chkDictForceLowercase.Name = "chkDictForceLowercase";
            this.chkDictForceLowercase.Size = new System.Drawing.Size(114, 27);
            this.chkDictForceLowercase.TabIndex = 52;
            this.chkDictForceLowercase.Text = "Lowercase";
            this.chkDictForceLowercase.UseVisualStyleBackColor = true;
            // 
            // chkDictAddTypos
            // 
            this.chkDictAddTypos.AutoSize = true;
            this.chkDictAddTypos.Location = new System.Drawing.Point(14, 158);
            this.chkDictAddTypos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkDictAddTypos.Name = "chkDictAddTypos";
            this.chkDictAddTypos.Size = new System.Drawing.Size(115, 27);
            this.chkDictAddTypos.TabIndex = 53;
            this.chkDictAddTypos.Text = "Add Typos";
            this.chkDictAddTypos.UseVisualStyleBackColor = true;
            // 
            // chkDictReverseOrder
            // 
            this.chkDictReverseOrder.AutoSize = true;
            this.chkDictReverseOrder.Location = new System.Drawing.Point(14, 197);
            this.chkDictReverseOrder.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkDictReverseOrder.Name = "chkDictReverseOrder";
            this.chkDictReverseOrder.Size = new System.Drawing.Size(143, 27);
            this.chkDictReverseOrder.TabIndex = 54;
            this.chkDictReverseOrder.Text = "Reverse Order";
            this.chkDictReverseOrder.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnCopyToDictFirst);
            this.tabPage2.Controls.Add(this.btnDictFirstUnselected);
            this.tabPage2.Controls.Add(this.chklDictionariesFirstWord);
            this.tabPage2.Controls.Add(this.lblDictionariesFirstWord);
            this.tabPage2.Controls.Add(this.chkUseCustomDictFirst);
            this.tabPage2.Controls.Add(this.chkDictFirstSkipDigits);
            this.tabPage2.Controls.Add(this.chkDictFirstSkipSpecials);
            this.tabPage2.Controls.Add(this.chkDictFirstForceLowercase);
            this.tabPage2.Controls.Add(this.chkDictFirstAddTypos);
            this.tabPage2.Controls.Add(this.chkDictFirstReverseOrder);
            this.tabPage2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(627, 925);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "1st Word";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnCopyToDictFirst
            // 
            this.btnCopyToDictFirst.Location = new System.Drawing.Point(14, 798);
            this.btnCopyToDictFirst.Name = "btnCopyToDictFirst";
            this.btnCopyToDictFirst.Size = new System.Drawing.Size(174, 37);
            this.btnCopyToDictFirst.TabIndex = 57;
            this.btnCopyToDictFirst.Text = "Copy fr. Main";
            this.btnCopyToDictFirst.UseVisualStyleBackColor = true;
            this.btnCopyToDictFirst.Click += new System.EventHandler(this.btnCopyToDictFirst_Click);
            // 
            // btnDictFirstUnselected
            // 
            this.btnDictFirstUnselected.Location = new System.Drawing.Point(14, 853);
            this.btnDictFirstUnselected.Name = "btnDictFirstUnselected";
            this.btnDictFirstUnselected.Size = new System.Drawing.Size(174, 37);
            this.btnDictFirstUnselected.TabIndex = 56;
            this.btnDictFirstUnselected.Text = "Unselect All";
            this.btnDictFirstUnselected.UseVisualStyleBackColor = true;
            this.btnDictFirstUnselected.Click += new System.EventHandler(this.btnDictFirstUnselected_Click);
            // 
            // chklDictionariesFirstWord
            // 
            this.chklDictionariesFirstWord.FormattingEnabled = true;
            this.chklDictionariesFirstWord.Location = new System.Drawing.Point(195, 13);
            this.chklDictionariesFirstWord.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chklDictionariesFirstWord.Name = "chklDictionariesFirstWord";
            this.chklDictionariesFirstWord.Size = new System.Drawing.Size(425, 888);
            this.chklDictionariesFirstWord.TabIndex = 34;
            // 
            // lblDictionariesFirstWord
            // 
            this.lblDictionariesFirstWord.AutoSize = true;
            this.lblDictionariesFirstWord.Location = new System.Drawing.Point(14, 13);
            this.lblDictionariesFirstWord.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDictionariesFirstWord.Name = "lblDictionariesFirstWord";
            this.lblDictionariesFirstWord.Size = new System.Drawing.Size(103, 23);
            this.lblDictionariesFirstWord.TabIndex = 33;
            this.lblDictionariesFirstWord.Text = "Dictionaries:";
            // 
            // chkUseCustomDictFirst
            // 
            this.chkUseCustomDictFirst.AutoSize = true;
            this.chkUseCustomDictFirst.Location = new System.Drawing.Point(14, 48);
            this.chkUseCustomDictFirst.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkUseCustomDictFirst.Name = "chkUseCustomDictFirst";
            this.chkUseCustomDictFirst.Size = new System.Drawing.Size(128, 27);
            this.chkUseCustomDictFirst.TabIndex = 38;
            this.chkUseCustomDictFirst.Text = "Use Custom";
            this.chkUseCustomDictFirst.UseVisualStyleBackColor = true;
            this.chkUseCustomDictFirst.CheckedChanged += new System.EventHandler(this.OnCustomDictFirstCheckedChanged);
            // 
            // chkDictFirstSkipDigits
            // 
            this.chkDictFirstSkipDigits.AutoSize = true;
            this.chkDictFirstSkipDigits.Location = new System.Drawing.Point(14, 87);
            this.chkDictFirstSkipDigits.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkDictFirstSkipDigits.Name = "chkDictFirstSkipDigits";
            this.chkDictFirstSkipDigits.Size = new System.Drawing.Size(115, 27);
            this.chkDictFirstSkipDigits.TabIndex = 40;
            this.chkDictFirstSkipDigits.Text = "Skip Digits";
            this.chkDictFirstSkipDigits.UseVisualStyleBackColor = true;
            // 
            // chkDictFirstSkipSpecials
            // 
            this.chkDictFirstSkipSpecials.AutoSize = true;
            this.chkDictFirstSkipSpecials.Location = new System.Drawing.Point(14, 123);
            this.chkDictFirstSkipSpecials.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkDictFirstSkipSpecials.Name = "chkDictFirstSkipSpecials";
            this.chkDictFirstSkipSpecials.Size = new System.Drawing.Size(132, 27);
            this.chkDictFirstSkipSpecials.TabIndex = 41;
            this.chkDictFirstSkipSpecials.Text = "Skip Specials";
            this.chkDictFirstSkipSpecials.UseVisualStyleBackColor = true;
            // 
            // chkDictFirstForceLowercase
            // 
            this.chkDictFirstForceLowercase.AutoSize = true;
            this.chkDictFirstForceLowercase.Location = new System.Drawing.Point(14, 158);
            this.chkDictFirstForceLowercase.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkDictFirstForceLowercase.Name = "chkDictFirstForceLowercase";
            this.chkDictFirstForceLowercase.Size = new System.Drawing.Size(114, 27);
            this.chkDictFirstForceLowercase.TabIndex = 42;
            this.chkDictFirstForceLowercase.Text = "Lowercase";
            this.chkDictFirstForceLowercase.UseVisualStyleBackColor = true;
            // 
            // chkDictFirstAddTypos
            // 
            this.chkDictFirstAddTypos.AutoSize = true;
            this.chkDictFirstAddTypos.Location = new System.Drawing.Point(14, 197);
            this.chkDictFirstAddTypos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkDictFirstAddTypos.Name = "chkDictFirstAddTypos";
            this.chkDictFirstAddTypos.Size = new System.Drawing.Size(115, 27);
            this.chkDictFirstAddTypos.TabIndex = 43;
            this.chkDictFirstAddTypos.Text = "Add Typos";
            this.chkDictFirstAddTypos.UseVisualStyleBackColor = true;
            // 
            // chkDictFirstReverseOrder
            // 
            this.chkDictFirstReverseOrder.AutoSize = true;
            this.chkDictFirstReverseOrder.Location = new System.Drawing.Point(14, 233);
            this.chkDictFirstReverseOrder.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkDictFirstReverseOrder.Name = "chkDictFirstReverseOrder";
            this.chkDictFirstReverseOrder.Size = new System.Drawing.Size(143, 27);
            this.chkDictFirstReverseOrder.TabIndex = 44;
            this.chkDictFirstReverseOrder.Text = "Reverse Order";
            this.chkDictFirstReverseOrder.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnCopyToDictLast);
            this.tabPage3.Controls.Add(this.btnDictLastUnselected);
            this.tabPage3.Controls.Add(this.chklDictionariesLastWord);
            this.tabPage3.Controls.Add(this.lblDictionaryLastWord);
            this.tabPage3.Controls.Add(this.chkUseCustomDictLast);
            this.tabPage3.Controls.Add(this.chkDictLastReverseOrder);
            this.tabPage3.Controls.Add(this.chkDictLastSkipDigits);
            this.tabPage3.Controls.Add(this.chkDictLastAddTypos);
            this.tabPage3.Controls.Add(this.chkDictLastSkipSpecials);
            this.tabPage3.Controls.Add(this.chkDictLastForceLowercase);
            this.tabPage3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabPage3.Location = new System.Drawing.Point(4, 34);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(627, 925);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Last Word";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnCopyToDictLast
            // 
            this.btnCopyToDictLast.Location = new System.Drawing.Point(14, 798);
            this.btnCopyToDictLast.Name = "btnCopyToDictLast";
            this.btnCopyToDictLast.Size = new System.Drawing.Size(174, 37);
            this.btnCopyToDictLast.TabIndex = 58;
            this.btnCopyToDictLast.Text = "Copy fr. Main";
            this.btnCopyToDictLast.UseVisualStyleBackColor = true;
            this.btnCopyToDictLast.Click += new System.EventHandler(this.btnCopyToDictLast_Click);
            // 
            // btnDictLastUnselected
            // 
            this.btnDictLastUnselected.Location = new System.Drawing.Point(14, 853);
            this.btnDictLastUnselected.Name = "btnDictLastUnselected";
            this.btnDictLastUnselected.Size = new System.Drawing.Size(174, 37);
            this.btnDictLastUnselected.TabIndex = 57;
            this.btnDictLastUnselected.Text = "Unselect All";
            this.btnDictLastUnselected.UseVisualStyleBackColor = true;
            this.btnDictLastUnselected.Click += new System.EventHandler(this.btnDictLastUnselected_Click);
            // 
            // chklDictionariesLastWord
            // 
            this.chklDictionariesLastWord.FormattingEnabled = true;
            this.chklDictionariesLastWord.Location = new System.Drawing.Point(195, 13);
            this.chklDictionariesLastWord.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chklDictionariesLastWord.Name = "chklDictionariesLastWord";
            this.chklDictionariesLastWord.Size = new System.Drawing.Size(425, 888);
            this.chklDictionariesLastWord.TabIndex = 32;
            // 
            // lblDictionaryLastWord
            // 
            this.lblDictionaryLastWord.AutoSize = true;
            this.lblDictionaryLastWord.Location = new System.Drawing.Point(14, 13);
            this.lblDictionaryLastWord.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDictionaryLastWord.Name = "lblDictionaryLastWord";
            this.lblDictionaryLastWord.Size = new System.Drawing.Size(103, 23);
            this.lblDictionaryLastWord.TabIndex = 31;
            this.lblDictionaryLastWord.Text = "Dictionaries:";
            // 
            // chkUseCustomDictLast
            // 
            this.chkUseCustomDictLast.AutoSize = true;
            this.chkUseCustomDictLast.Location = new System.Drawing.Point(14, 48);
            this.chkUseCustomDictLast.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkUseCustomDictLast.Name = "chkUseCustomDictLast";
            this.chkUseCustomDictLast.Size = new System.Drawing.Size(128, 27);
            this.chkUseCustomDictLast.TabIndex = 39;
            this.chkUseCustomDictLast.Text = "Use Custom";
            this.chkUseCustomDictLast.UseVisualStyleBackColor = true;
            this.chkUseCustomDictLast.CheckedChanged += new System.EventHandler(this.OnCustomDictLastCheckedChanged);
            // 
            // chkDictLastReverseOrder
            // 
            this.chkDictLastReverseOrder.AutoSize = true;
            this.chkDictLastReverseOrder.Location = new System.Drawing.Point(14, 233);
            this.chkDictLastReverseOrder.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkDictLastReverseOrder.Name = "chkDictLastReverseOrder";
            this.chkDictLastReverseOrder.Size = new System.Drawing.Size(143, 27);
            this.chkDictLastReverseOrder.TabIndex = 49;
            this.chkDictLastReverseOrder.Text = "Reverse Order";
            this.chkDictLastReverseOrder.UseVisualStyleBackColor = true;
            // 
            // chkDictLastSkipDigits
            // 
            this.chkDictLastSkipDigits.AutoSize = true;
            this.chkDictLastSkipDigits.Location = new System.Drawing.Point(14, 87);
            this.chkDictLastSkipDigits.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkDictLastSkipDigits.Name = "chkDictLastSkipDigits";
            this.chkDictLastSkipDigits.Size = new System.Drawing.Size(115, 27);
            this.chkDictLastSkipDigits.TabIndex = 45;
            this.chkDictLastSkipDigits.Text = "Skip Digits";
            this.chkDictLastSkipDigits.UseVisualStyleBackColor = true;
            // 
            // chkDictLastAddTypos
            // 
            this.chkDictLastAddTypos.AutoSize = true;
            this.chkDictLastAddTypos.Location = new System.Drawing.Point(14, 197);
            this.chkDictLastAddTypos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkDictLastAddTypos.Name = "chkDictLastAddTypos";
            this.chkDictLastAddTypos.Size = new System.Drawing.Size(115, 27);
            this.chkDictLastAddTypos.TabIndex = 48;
            this.chkDictLastAddTypos.Text = "Add Typos";
            this.chkDictLastAddTypos.UseVisualStyleBackColor = true;
            // 
            // chkDictLastSkipSpecials
            // 
            this.chkDictLastSkipSpecials.AutoSize = true;
            this.chkDictLastSkipSpecials.Location = new System.Drawing.Point(14, 123);
            this.chkDictLastSkipSpecials.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkDictLastSkipSpecials.Name = "chkDictLastSkipSpecials";
            this.chkDictLastSkipSpecials.Size = new System.Drawing.Size(132, 27);
            this.chkDictLastSkipSpecials.TabIndex = 46;
            this.chkDictLastSkipSpecials.Text = "Skip Specials";
            this.chkDictLastSkipSpecials.UseVisualStyleBackColor = true;
            // 
            // chkDictLastForceLowercase
            // 
            this.chkDictLastForceLowercase.AutoSize = true;
            this.chkDictLastForceLowercase.Location = new System.Drawing.Point(14, 158);
            this.chkDictLastForceLowercase.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkDictLastForceLowercase.Name = "chkDictLastForceLowercase";
            this.chkDictLastForceLowercase.Size = new System.Drawing.Size(114, 27);
            this.chkDictLastForceLowercase.TabIndex = 47;
            this.chkDictLastForceLowercase.Text = "Lowercase";
            this.chkDictLastForceLowercase.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.txtDictCustWords);
            this.tabPage4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabPage4.Location = new System.Drawing.Point(4, 34);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(627, 925);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Cust. Main";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // txtDictCustWords
            // 
            this.txtDictCustWords.Location = new System.Drawing.Point(12, 9);
            this.txtDictCustWords.Multiline = true;
            this.txtDictCustWords.Name = "txtDictCustWords";
            this.txtDictCustWords.Size = new System.Drawing.Size(601, 901);
            this.txtDictCustWords.TabIndex = 0;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.txtDictFirstCustWords);
            this.tabPage5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabPage5.Location = new System.Drawing.Point(4, 34);
            this.tabPage5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(627, 925);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Cust. 1st Word";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // txtDictFirstCustWords
            // 
            this.txtDictFirstCustWords.Location = new System.Drawing.Point(12, 9);
            this.txtDictFirstCustWords.Multiline = true;
            this.txtDictFirstCustWords.Name = "txtDictFirstCustWords";
            this.txtDictFirstCustWords.Size = new System.Drawing.Size(601, 901);
            this.txtDictFirstCustWords.TabIndex = 0;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.txtDictLastCustWords);
            this.tabPage6.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabPage6.Location = new System.Drawing.Point(4, 34);
            this.tabPage6.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(627, 925);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Cust. Last Word";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // txtDictLastCustWords
            // 
            this.txtDictLastCustWords.Location = new System.Drawing.Point(12, 9);
            this.txtDictLastCustWords.Multiline = true;
            this.txtDictLastCustWords.Name = "txtDictLastCustWords";
            this.txtDictLastCustWords.Size = new System.Drawing.Size(601, 901);
            this.txtDictLastCustWords.TabIndex = 0;
            // 
            // grpAdvanced
            // 
            this.grpAdvanced.Controls.Add(this.cbMinConcatWords);
            this.grpAdvanced.Controls.Add(this.cbMaxConcatWords);
            this.grpAdvanced.Controls.Add(this.lblMinConcatWords);
            this.grpAdvanced.Controls.Add(this.lblMaxConcatWords);
            this.grpAdvanced.Controls.Add(this.chkDictionaryAdvanced);
            this.grpAdvanced.Controls.Add(this.lblMaxDelim);
            this.grpAdvanced.Controls.Add(this.lblOnlyLastTwoWordsConcat);
            this.grpAdvanced.Controls.Add(this.cbMaxDelim);
            this.grpAdvanced.Controls.Add(this.chkOnlyLastTwoWordsConcat);
            this.grpAdvanced.Controls.Add(this.lblMinDelim);
            this.grpAdvanced.Controls.Add(this.lblOnlyFirstTwoWordsConcat);
            this.grpAdvanced.Controls.Add(this.cbMinDelim);
            this.grpAdvanced.Controls.Add(this.chkOnlyFirstTwoWordsConcat);
            this.grpAdvanced.Controls.Add(this.lblMaxConsecutiveConcat);
            this.grpAdvanced.Controls.Add(this.cbMinWordsLimit);
            this.grpAdvanced.Controls.Add(this.cbMaxConsecutiveConcat);
            this.grpAdvanced.Controls.Add(this.lblMinWordsLimit);
            this.grpAdvanced.Controls.Add(this.lblMinConsecutiveConcat);
            this.grpAdvanced.Controls.Add(this.cbMaxConsecutiveOnes);
            this.grpAdvanced.Controls.Add(this.cbMinConsecutiveConcat);
            this.grpAdvanced.Controls.Add(this.lblMaxConsecutiveOnes);
            this.grpAdvanced.Controls.Add(this.lblMaxWordLength);
            this.grpAdvanced.Controls.Add(this.cbMinOnes);
            this.grpAdvanced.Controls.Add(this.cbMaxWordLength);
            this.grpAdvanced.Controls.Add(this.lblMinOnes);
            this.grpAdvanced.Controls.Add(this.lblMinWordLength);
            this.grpAdvanced.Controls.Add(this.cbMaxOnes);
            this.grpAdvanced.Controls.Add(this.cbMinWordLength);
            this.grpAdvanced.Controls.Add(this.lblMaxOnes);
            this.grpAdvanced.Location = new System.Drawing.Point(10, 452);
            this.grpAdvanced.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpAdvanced.Name = "grpAdvanced";
            this.grpAdvanced.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpAdvanced.Size = new System.Drawing.Size(520, 518);
            this.grpAdvanced.TabIndex = 81;
            this.grpAdvanced.TabStop = false;
            this.grpAdvanced.Text = "Advanced Attack";
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
            this.cbMinConcatWords.Location = new System.Drawing.Point(449, 153);
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
            this.cbMaxConcatWords.Location = new System.Drawing.Point(186, 153);
            this.cbMaxConcatWords.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbMaxConcatWords.Name = "cbMaxConcatWords";
            this.cbMaxConcatWords.Size = new System.Drawing.Size(53, 33);
            this.cbMaxConcatWords.TabIndex = 81;
            // 
            // lblMinConcatWords
            // 
            this.lblMinConcatWords.AutoSize = true;
            this.lblMinConcatWords.Location = new System.Drawing.Point(280, 157);
            this.lblMinConcatWords.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMinConcatWords.Name = "lblMinConcatWords";
            this.lblMinConcatWords.Size = new System.Drawing.Size(167, 25);
            this.lblMinConcatWords.TabIndex = 80;
            this.lblMinConcatWords.Text = "Min Concat. Words:";
            // 
            // lblMaxConcatWords
            // 
            this.lblMaxConcatWords.AutoSize = true;
            this.lblMaxConcatWords.Location = new System.Drawing.Point(9, 157);
            this.lblMaxConcatWords.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMaxConcatWords.Name = "lblMaxConcatWords";
            this.lblMaxConcatWords.Size = new System.Drawing.Size(170, 25);
            this.lblMaxConcatWords.TabIndex = 79;
            this.lblMaxConcatWords.Text = "Max Concat. Words:";
            // 
            // chkDictionaryAdvanced
            // 
            this.chkDictionaryAdvanced.AutoSize = true;
            this.chkDictionaryAdvanced.Location = new System.Drawing.Point(11, 37);
            this.chkDictionaryAdvanced.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkDictionaryAdvanced.Name = "chkDictionaryAdvanced";
            this.chkDictionaryAdvanced.Size = new System.Drawing.Size(229, 29);
            this.chkDictionaryAdvanced.TabIndex = 56;
            this.chkDictionaryAdvanced.Text = "Enable Advanced Attack";
            this.chkDictionaryAdvanced.UseVisualStyleBackColor = true;
            this.chkDictionaryAdvanced.CheckedChanged += new System.EventHandler(this.OnDictionaryAdvancedCheckedChanged);
            // 
            // lblMaxDelim
            // 
            this.lblMaxDelim.AutoSize = true;
            this.lblMaxDelim.Location = new System.Drawing.Point(9, 93);
            this.lblMaxDelim.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMaxDelim.Name = "lblMaxDelim";
            this.lblMaxDelim.Size = new System.Drawing.Size(133, 25);
            this.lblMaxDelim.TabIndex = 57;
            this.lblMaxDelim.Text = "Max Delimiters:";
            // 
            // lblOnlyLastTwoWordsConcat
            // 
            this.lblOnlyLastTwoWordsConcat.AutoSize = true;
            this.lblOnlyLastTwoWordsConcat.Location = new System.Drawing.Point(279, 473);
            this.lblOnlyLastTwoWordsConcat.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOnlyLastTwoWordsConcat.Name = "lblOnlyLastTwoWordsConcat";
            this.lblOnlyLastTwoWordsConcat.Size = new System.Drawing.Size(188, 25);
            this.lblOnlyLastTwoWordsConcat.TabIndex = 78;
            this.lblOnlyLastTwoWordsConcat.Text = "Last 2 Words Concat. :";
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
            this.cbMaxDelim.Location = new System.Drawing.Point(186, 90);
            this.cbMaxDelim.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbMaxDelim.Name = "cbMaxDelim";
            this.cbMaxDelim.Size = new System.Drawing.Size(53, 33);
            this.cbMaxDelim.TabIndex = 58;
            // 
            // chkOnlyLastTwoWordsConcat
            // 
            this.chkOnlyLastTwoWordsConcat.AutoSize = true;
            this.chkOnlyLastTwoWordsConcat.Checked = true;
            this.chkOnlyLastTwoWordsConcat.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOnlyLastTwoWordsConcat.Location = new System.Drawing.Point(481, 473);
            this.chkOnlyLastTwoWordsConcat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkOnlyLastTwoWordsConcat.Name = "chkOnlyLastTwoWordsConcat";
            this.chkOnlyLastTwoWordsConcat.Size = new System.Drawing.Size(22, 21);
            this.chkOnlyLastTwoWordsConcat.TabIndex = 77;
            this.chkOnlyLastTwoWordsConcat.UseVisualStyleBackColor = true;
            // 
            // lblMinDelim
            // 
            this.lblMinDelim.AutoSize = true;
            this.lblMinDelim.Location = new System.Drawing.Point(280, 95);
            this.lblMinDelim.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMinDelim.Name = "lblMinDelim";
            this.lblMinDelim.Size = new System.Drawing.Size(130, 25);
            this.lblMinDelim.TabIndex = 59;
            this.lblMinDelim.Text = "Min Delimiters:";
            // 
            // lblOnlyFirstTwoWordsConcat
            // 
            this.lblOnlyFirstTwoWordsConcat.AutoSize = true;
            this.lblOnlyFirstTwoWordsConcat.Location = new System.Drawing.Point(9, 473);
            this.lblOnlyFirstTwoWordsConcat.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOnlyFirstTwoWordsConcat.Name = "lblOnlyFirstTwoWordsConcat";
            this.lblOnlyFirstTwoWordsConcat.Size = new System.Drawing.Size(190, 25);
            this.lblOnlyFirstTwoWordsConcat.TabIndex = 38;
            this.lblOnlyFirstTwoWordsConcat.Text = "First 2 Words Concat. :";
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
            this.cbMinDelim.Location = new System.Drawing.Point(449, 90);
            this.cbMinDelim.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbMinDelim.Name = "cbMinDelim";
            this.cbMinDelim.Size = new System.Drawing.Size(53, 33);
            this.cbMinDelim.TabIndex = 60;
            // 
            // chkOnlyFirstTwoWordsConcat
            // 
            this.chkOnlyFirstTwoWordsConcat.AutoSize = true;
            this.chkOnlyFirstTwoWordsConcat.Checked = true;
            this.chkOnlyFirstTwoWordsConcat.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOnlyFirstTwoWordsConcat.Location = new System.Drawing.Point(219, 473);
            this.chkOnlyFirstTwoWordsConcat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkOnlyFirstTwoWordsConcat.Name = "chkOnlyFirstTwoWordsConcat";
            this.chkOnlyFirstTwoWordsConcat.Size = new System.Drawing.Size(22, 21);
            this.chkOnlyFirstTwoWordsConcat.TabIndex = 37;
            this.chkOnlyFirstTwoWordsConcat.UseVisualStyleBackColor = true;
            // 
            // lblMaxConsecutiveConcat
            // 
            this.lblMaxConsecutiveConcat.AutoSize = true;
            this.lblMaxConsecutiveConcat.Location = new System.Drawing.Point(9, 218);
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
            this.cbMinWordsLimit.Location = new System.Drawing.Point(449, 412);
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
            this.cbMaxConsecutiveConcat.Location = new System.Drawing.Point(186, 217);
            this.cbMaxConsecutiveConcat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbMaxConsecutiveConcat.Name = "cbMaxConsecutiveConcat";
            this.cbMaxConsecutiveConcat.Size = new System.Drawing.Size(53, 33);
            this.cbMaxConsecutiveConcat.TabIndex = 62;
            // 
            // lblMinWordsLimit
            // 
            this.lblMinWordsLimit.AutoSize = true;
            this.lblMinWordsLimit.Location = new System.Drawing.Point(280, 417);
            this.lblMinWordsLimit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMinWordsLimit.Name = "lblMinWordsLimit";
            this.lblMinWordsLimit.Size = new System.Drawing.Size(146, 25);
            this.lblMinWordsLimit.TabIndex = 75;
            this.lblMinWordsLimit.Text = "Min Words Limit:";
            // 
            // lblMinConsecutiveConcat
            // 
            this.lblMinConsecutiveConcat.AutoSize = true;
            this.lblMinConsecutiveConcat.Location = new System.Drawing.Point(280, 222);
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
            this.cbMaxConsecutiveOnes.Location = new System.Drawing.Point(186, 412);
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
            this.cbMinConsecutiveConcat.Location = new System.Drawing.Point(449, 217);
            this.cbMinConsecutiveConcat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbMinConsecutiveConcat.Name = "cbMinConsecutiveConcat";
            this.cbMinConsecutiveConcat.Size = new System.Drawing.Size(53, 33);
            this.cbMinConsecutiveConcat.TabIndex = 64;
            // 
            // lblMaxConsecutiveOnes
            // 
            this.lblMaxConsecutiveOnes.AutoSize = true;
            this.lblMaxConsecutiveOnes.Location = new System.Drawing.Point(9, 417);
            this.lblMaxConsecutiveOnes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMaxConsecutiveOnes.Name = "lblMaxConsecutiveOnes";
            this.lblMaxConsecutiveOnes.Size = new System.Drawing.Size(149, 25);
            this.lblMaxConsecutiveOnes.TabIndex = 73;
            this.lblMaxConsecutiveOnes.Text = "Max Cons. Ones :";
            // 
            // lblMaxWordLength
            // 
            this.lblMaxWordLength.AutoSize = true;
            this.lblMaxWordLength.Location = new System.Drawing.Point(9, 287);
            this.lblMaxWordLength.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMaxWordLength.Name = "lblMaxWordLength";
            this.lblMaxWordLength.Size = new System.Drawing.Size(162, 25);
            this.lblMaxWordLength.TabIndex = 65;
            this.lblMaxWordLength.Text = "Max Word Length :";
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
            this.cbMinOnes.Location = new System.Drawing.Point(449, 347);
            this.cbMinOnes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbMinOnes.Name = "cbMinOnes";
            this.cbMinOnes.Size = new System.Drawing.Size(53, 33);
            this.cbMinOnes.TabIndex = 72;
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
            this.cbMaxWordLength.Location = new System.Drawing.Point(186, 282);
            this.cbMaxWordLength.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbMaxWordLength.Name = "cbMaxWordLength";
            this.cbMaxWordLength.Size = new System.Drawing.Size(53, 33);
            this.cbMaxWordLength.TabIndex = 66;
            // 
            // lblMinOnes
            // 
            this.lblMinOnes.AutoSize = true;
            this.lblMinOnes.Location = new System.Drawing.Point(280, 352);
            this.lblMinOnes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMinOnes.Name = "lblMinOnes";
            this.lblMinOnes.Size = new System.Drawing.Size(97, 25);
            this.lblMinOnes.TabIndex = 71;
            this.lblMinOnes.Text = "Min Ones :";
            // 
            // lblMinWordLength
            // 
            this.lblMinWordLength.AutoSize = true;
            this.lblMinWordLength.Location = new System.Drawing.Point(280, 287);
            this.lblMinWordLength.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMinWordLength.Name = "lblMinWordLength";
            this.lblMinWordLength.Size = new System.Drawing.Size(159, 25);
            this.lblMinWordLength.TabIndex = 67;
            this.lblMinWordLength.Text = "Min Word Length :";
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
            this.cbMaxOnes.Location = new System.Drawing.Point(186, 347);
            this.cbMaxOnes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbMaxOnes.Name = "cbMaxOnes";
            this.cbMaxOnes.Size = new System.Drawing.Size(53, 33);
            this.cbMaxOnes.TabIndex = 70;
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
            this.cbMinWordLength.Location = new System.Drawing.Point(449, 282);
            this.cbMinWordLength.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbMinWordLength.Name = "cbMinWordLength";
            this.cbMinWordLength.Size = new System.Drawing.Size(53, 33);
            this.cbMinWordLength.TabIndex = 68;
            // 
            // lblMaxOnes
            // 
            this.lblMaxOnes.AutoSize = true;
            this.lblMaxOnes.Location = new System.Drawing.Point(9, 352);
            this.lblMaxOnes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMaxOnes.Name = "lblMaxOnes";
            this.lblMaxOnes.Size = new System.Drawing.Size(100, 25);
            this.lblMaxOnes.TabIndex = 69;
            this.lblMaxOnes.Text = "Max Ones :";
            // 
            // grpTypos
            // 
            this.grpTypos.Controls.Add(this.chkTyposReverseLetter);
            this.grpTypos.Controls.Add(this.chkTyposWrongLetter);
            this.grpTypos.Controls.Add(this.chkTyposExtraLetter);
            this.grpTypos.Controls.Add(this.chkTyposDoubleLetter);
            this.grpTypos.Controls.Add(this.chkTyposSkipLetter);
            this.grpTypos.Controls.Add(this.chkTyposLetterSwap);
            this.grpTypos.Location = new System.Drawing.Point(10, 273);
            this.grpTypos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpTypos.Name = "grpTypos";
            this.grpTypos.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpTypos.Size = new System.Drawing.Size(519, 167);
            this.grpTypos.TabIndex = 80;
            this.grpTypos.TabStop = false;
            this.grpTypos.Text = "Typos";
            // 
            // chkTyposReverseLetter
            // 
            this.chkTyposReverseLetter.AutoSize = true;
            this.chkTyposReverseLetter.Checked = true;
            this.chkTyposReverseLetter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTyposReverseLetter.Location = new System.Drawing.Point(360, 107);
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
            this.chkTyposWrongLetter.Location = new System.Drawing.Point(186, 107);
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
            this.chkTyposExtraLetter.Location = new System.Drawing.Point(17, 107);
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
            this.chkTyposDoubleLetter.Location = new System.Drawing.Point(360, 53);
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
            this.chkTyposSkipLetter.Location = new System.Drawing.Point(186, 53);
            this.chkTyposSkipLetter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkTyposSkipLetter.Name = "chkTyposSkipLetter";
            this.chkTyposSkipLetter.Size = new System.Drawing.Size(121, 29);
            this.chkTyposSkipLetter.TabIndex = 80;
            this.chkTyposSkipLetter.Text = "Skip Letter";
            this.chkTyposSkipLetter.UseVisualStyleBackColor = true;
            // 
            // chkTyposLetterSwap
            // 
            this.chkTyposLetterSwap.AutoSize = true;
            this.chkTyposLetterSwap.Checked = true;
            this.chkTyposLetterSwap.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTyposLetterSwap.Location = new System.Drawing.Point(17, 53);
            this.chkTyposLetterSwap.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkTyposLetterSwap.Name = "chkTyposLetterSwap";
            this.chkTyposLetterSwap.Size = new System.Drawing.Size(148, 29);
            this.chkTyposLetterSwap.TabIndex = 79;
            this.chkTyposLetterSwap.Text = "L-R Swapping";
            this.chkTyposLetterSwap.UseVisualStyleBackColor = true;
            // 
            // txtIncludeWordsCharacter
            // 
            this.txtIncludeWordsCharacter.Location = new System.Drawing.Point(171, 177);
            this.txtIncludeWordsCharacter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtIncludeWordsCharacter.Name = "txtIncludeWordsCharacter";
            this.txtIncludeWordsCharacter.PlaceholderText = "mario";
            this.txtIncludeWordsCharacter.Size = new System.Drawing.Size(871, 31);
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
            this.pnlCharacter.Location = new System.Drawing.Point(17, 173);
            this.pnlCharacter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlCharacter.Name = "pnlCharacter";
            this.pnlCharacter.Size = new System.Drawing.Size(1106, 977);
            this.pnlCharacter.TabIndex = 32;
            // 
            // grpCharsetPreview
            // 
            this.grpCharsetPreview.Controls.Add(this.lblStartingValidCharsPreview);
            this.grpCharsetPreview.Controls.Add(this.txtStartingValidCharsPreview);
            this.grpCharsetPreview.Controls.Add(this.lblValidCharsPreview);
            this.grpCharsetPreview.Controls.Add(this.txtValidCharsPreview);
            this.grpCharsetPreview.Location = new System.Drawing.Point(567, 337);
            this.grpCharsetPreview.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpCharsetPreview.Name = "grpCharsetPreview";
            this.grpCharsetPreview.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpCharsetPreview.Size = new System.Drawing.Size(520, 553);
            this.grpCharsetPreview.TabIndex = 43;
            this.grpCharsetPreview.TabStop = false;
            this.grpCharsetPreview.Text = "Charset Previews";
            // 
            // lblStartingValidCharsPreview
            // 
            this.lblStartingValidCharsPreview.AutoSize = true;
            this.lblStartingValidCharsPreview.Location = new System.Drawing.Point(16, 293);
            this.lblStartingValidCharsPreview.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStartingValidCharsPreview.Name = "lblStartingValidCharsPreview";
            this.lblStartingValidCharsPreview.Size = new System.Drawing.Size(126, 25);
            this.lblStartingValidCharsPreview.TabIndex = 43;
            this.lblStartingValidCharsPreview.Text = "Starting Chars:";
            // 
            // txtStartingValidCharsPreview
            // 
            this.txtStartingValidCharsPreview.Location = new System.Drawing.Point(16, 343);
            this.txtStartingValidCharsPreview.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtStartingValidCharsPreview.Multiline = true;
            this.txtStartingValidCharsPreview.Name = "txtStartingValidCharsPreview";
            this.txtStartingValidCharsPreview.ReadOnly = true;
            this.txtStartingValidCharsPreview.Size = new System.Drawing.Size(491, 177);
            this.txtStartingValidCharsPreview.TabIndex = 42;
            // 
            // lblValidCharsPreview
            // 
            this.lblValidCharsPreview.AutoSize = true;
            this.lblValidCharsPreview.Location = new System.Drawing.Point(13, 37);
            this.lblValidCharsPreview.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblValidCharsPreview.Name = "lblValidCharsPreview";
            this.lblValidCharsPreview.Size = new System.Drawing.Size(103, 25);
            this.lblValidCharsPreview.TabIndex = 41;
            this.lblValidCharsPreview.Text = "Valid Chars:";
            // 
            // txtValidCharsPreview
            // 
            this.txtValidCharsPreview.Location = new System.Drawing.Point(13, 87);
            this.txtValidCharsPreview.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtValidCharsPreview.Multiline = true;
            this.txtValidCharsPreview.Name = "txtValidCharsPreview";
            this.txtValidCharsPreview.ReadOnly = true;
            this.txtValidCharsPreview.Size = new System.Drawing.Size(494, 177);
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
            this.grpGeneral.Location = new System.Drawing.Point(11, 7);
            this.grpGeneral.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpGeneral.Name = "grpGeneral";
            this.grpGeneral.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpGeneral.Size = new System.Drawing.Size(1076, 320);
            this.grpGeneral.TabIndex = 42;
            this.grpGeneral.TabStop = false;
            this.grpGeneral.Text = "Bruteforce Settings";
            // 
            // txtValidChars
            // 
            this.txtValidChars.Location = new System.Drawing.Point(171, 37);
            this.txtValidChars.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtValidChars.Name = "txtValidChars";
            this.txtValidChars.Size = new System.Drawing.Size(871, 31);
            this.txtValidChars.TabIndex = 31;
            this.txtValidChars.Text = "etainoshrdlucmfwygpbvkqjxz0123456789_";
            this.txtValidChars.TextChanged += new System.EventHandler(this.TxtValidCharsChanged);
            // 
            // lblValidChars
            // 
            this.lblValidChars.AutoSize = true;
            this.lblValidChars.Location = new System.Drawing.Point(17, 43);
            this.lblValidChars.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblValidChars.Name = "lblValidChars";
            this.lblValidChars.Size = new System.Drawing.Size(103, 25);
            this.lblValidChars.TabIndex = 31;
            this.lblValidChars.Text = "Valid Chars:";
            // 
            // lblUtf8Toggle
            // 
            this.lblUtf8Toggle.AutoSize = true;
            this.lblUtf8Toggle.Location = new System.Drawing.Point(704, 257);
            this.lblUtf8Toggle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUtf8Toggle.Name = "lblUtf8Toggle";
            this.lblUtf8Toggle.Size = new System.Drawing.Size(113, 25);
            this.lblUtf8Toggle.TabIndex = 37;
            this.lblUtf8Toggle.Text = "Enable UTF8:";
            // 
            // lblStartingValidChars
            // 
            this.lblStartingValidChars.AutoSize = true;
            this.lblStartingValidChars.Location = new System.Drawing.Point(17, 113);
            this.lblStartingValidChars.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStartingValidChars.Name = "lblStartingValidChars";
            this.lblStartingValidChars.Size = new System.Drawing.Size(126, 25);
            this.lblStartingValidChars.TabIndex = 32;
            this.lblStartingValidChars.Text = "Starting Chars:";
            // 
            // lblEndPosition
            // 
            this.lblEndPosition.AutoSize = true;
            this.lblEndPosition.Location = new System.Drawing.Point(337, 253);
            this.lblEndPosition.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEndPosition.Name = "lblEndPosition";
            this.lblEndPosition.Size = new System.Drawing.Size(114, 25);
            this.lblEndPosition.TabIndex = 36;
            this.lblEndPosition.Text = "End Position:";
            // 
            // chkUtf8Toggle
            // 
            this.chkUtf8Toggle.AutoSize = true;
            this.chkUtf8Toggle.Location = new System.Drawing.Point(859, 260);
            this.chkUtf8Toggle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkUtf8Toggle.Name = "chkUtf8Toggle";
            this.chkUtf8Toggle.Size = new System.Drawing.Size(22, 21);
            this.chkUtf8Toggle.TabIndex = 40;
            this.chkUtf8Toggle.UseVisualStyleBackColor = true;
            this.chkUtf8Toggle.CheckedChanged += new System.EventHandler(this.Utf8ToggleCheckedChanged);
            // 
            // txtStartingValidChars
            // 
            this.txtStartingValidChars.Location = new System.Drawing.Point(171, 107);
            this.txtStartingValidChars.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtStartingValidChars.Name = "txtStartingValidChars";
            this.txtStartingValidChars.Size = new System.Drawing.Size(871, 31);
            this.txtStartingValidChars.TabIndex = 33;
            this.txtStartingValidChars.Text = "etainoshrdlucmfwygpbvkqjxz_";
            this.txtStartingValidChars.TextChanged += new System.EventHandler(this.TxtStartingValidCharsChanged);
            // 
            // lblIncludeWordCharacters
            // 
            this.lblIncludeWordCharacters.AutoSize = true;
            this.lblIncludeWordCharacters.Location = new System.Drawing.Point(17, 183);
            this.lblIncludeWordCharacters.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIncludeWordCharacters.Name = "lblIncludeWordCharacters";
            this.lblIncludeWordCharacters.Size = new System.Drawing.Size(122, 25);
            this.lblIncludeWordCharacters.TabIndex = 33;
            this.lblIncludeWordCharacters.Text = "Include Word:";
            // 
            // numEndPosition
            // 
            this.numEndPosition.Location = new System.Drawing.Point(480, 247);
            this.numEndPosition.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
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
            this.numEndPosition.Size = new System.Drawing.Size(113, 31);
            this.numEndPosition.TabIndex = 37;
            // 
            // lblStartPosition
            // 
            this.lblStartPosition.AutoSize = true;
            this.lblStartPosition.Location = new System.Drawing.Point(17, 253);
            this.lblStartPosition.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStartPosition.Name = "lblStartPosition";
            this.lblStartPosition.Size = new System.Drawing.Size(120, 25);
            this.lblStartPosition.TabIndex = 34;
            this.lblStartPosition.Text = "Start Position:";
            // 
            // numStartPosition
            // 
            this.numStartPosition.Location = new System.Drawing.Point(170, 247);
            this.numStartPosition.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numStartPosition.Name = "numStartPosition";
            this.numStartPosition.Size = new System.Drawing.Size(113, 31);
            this.numStartPosition.TabIndex = 35;
            // 
            // grpSpecials
            // 
            this.grpSpecials.Controls.Add(this.chklCharsets);
            this.grpSpecials.Location = new System.Drawing.Point(11, 337);
            this.grpSpecials.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpSpecials.Name = "grpSpecials";
            this.grpSpecials.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpSpecials.Size = new System.Drawing.Size(536, 553);
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
            this.chklCharsets.Size = new System.Drawing.Size(507, 452);
            this.chklCharsets.TabIndex = 0;
            this.chklCharsets.SelectedIndexChanged += new System.EventHandler(this.ChklCharsetsSelectedIndexChanged);
            this.chklCharsets.SelectedValueChanged += new System.EventHandler(this.ChklCharsetsSelectedValueChanged);
            // 
            // txtHashCatPath
            // 
            this.txtHashCatPath.Location = new System.Drawing.Point(164, 920);
            this.txtHashCatPath.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtHashCatPath.Name = "txtHashCatPath";
            this.txtHashCatPath.Size = new System.Drawing.Size(540, 31);
            this.txtHashCatPath.TabIndex = 39;
            // 
            // lblHashCat
            // 
            this.lblHashCat.AutoSize = true;
            this.lblHashCat.Location = new System.Drawing.Point(11, 925);
            this.lblHashCat.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHashCat.Name = "lblHashCat";
            this.lblHashCat.Size = new System.Drawing.Size(118, 25);
            this.lblHashCat.TabIndex = 38;
            this.lblHashCat.Text = "Hashcat Path:";
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
            this.mnFile});
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
            this.btnQuickSave.Location = new System.Drawing.Point(406, 121);
            this.btnQuickSave.Name = "btnQuickSave";
            this.btnQuickSave.Size = new System.Drawing.Size(65, 34);
            this.btnQuickSave.TabIndex = 37;
            this.btnQuickSave.Text = "Save";
            this.btnQuickSave.UseVisualStyleBackColor = true;
            // 
            // btnQuickLoad
            // 
            this.btnQuickLoad.Location = new System.Drawing.Point(472, 121);
            this.btnQuickLoad.Name = "btnQuickLoad";
            this.btnQuickLoad.Size = new System.Drawing.Size(67, 34);
            this.btnQuickLoad.TabIndex = 38;
            this.btnQuickLoad.Text = "Load";
            this.btnQuickLoad.UseVisualStyleBackColor = true;
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
            this.Controls.Add(this.pnlCharacter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.mnStrip;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "BruteForceHash";
            this.pnlDictionary.ResumeLayout(false);
            this.groupBoxWordFiltering.ResumeLayout(false);
            this.groupBoxWordFiltering.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
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
        private System.Windows.Forms.Label lblDictionaries;
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
        private System.Windows.Forms.Label lblDictionaryLastWord;
        private System.Windows.Forms.CheckedListBox chklDictionariesLastWord;
        private System.Windows.Forms.Label lblDictionariesFirstWord;
        private System.Windows.Forms.CheckedListBox chklDictionariesFirstWord;
        private System.Windows.Forms.CheckBox chkIncludeWordNotFirst;
        private System.Windows.Forms.CheckBox chkUseCustomDictLast;
        private System.Windows.Forms.CheckBox chkUseCustomDictFirst;
        private System.Windows.Forms.CheckBox chkDictFirstSkipSpecials;
        private System.Windows.Forms.CheckBox chkDictFirstSkipDigits;
        private System.Windows.Forms.CheckBox chkDictFirstForceLowercase;
        private System.Windows.Forms.CheckBox chkDictFirstReverseOrder;
        private System.Windows.Forms.CheckBox chkDictLastSkipDigits;
        private System.Windows.Forms.CheckedListBox chklDictionaries;
        private System.Windows.Forms.CheckBox chkDictLastSkipSpecials;
        private System.Windows.Forms.CheckBox chkDictLastForceLowercase;
        private System.Windows.Forms.CheckBox chkDictLastAddTypos;
        private System.Windows.Forms.CheckBox chkDictLastReverseOrder;
        private System.Windows.Forms.CheckBox chkDictSkipDigits;
        private System.Windows.Forms.CheckBox chkDictSkipSpecials;
        private System.Windows.Forms.CheckBox chkDictForceLowercase;
        private System.Windows.Forms.CheckBox chkDictAddTypos;
        private System.Windows.Forms.CheckBox chkDictReverseOrder;
        private System.Windows.Forms.ToolStripMenuItem mnNew;
        private System.Windows.Forms.ToolStripSeparator mnSeparator;
        private System.Windows.Forms.Button btnStartHashCat;
        private System.Windows.Forms.Label lblHashCat;
        private System.Windows.Forms.TextBox textBox1;
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
        private System.Windows.Forms.Label lblMinOnes;
        private System.Windows.Forms.ComboBox cbMaxOnes;
        private System.Windows.Forms.Label lblMaxOnes;
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
        private System.Windows.Forms.CheckBox chkTyposLetterSwap;
        private System.Windows.Forms.GroupBox grpSpecials;
        private System.Windows.Forms.GroupBox grpGeneral;
        private System.Windows.Forms.CheckedListBox chklCharsets;
        private System.Windows.Forms.GroupBox grpCharsetPreview;
        private System.Windows.Forms.Label lblStartingValidCharsPreview;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label lblValidCharsPreview;
        private System.Windows.Forms.TextBox txtValidCharsPreview;
        private System.Windows.Forms.TextBox txtStartingValidCharsPreview;
        private System.Windows.Forms.Label lblDictionaryFilterFirst;
        private System.Windows.Forms.TextBox txtDictionaryFilterFirst;
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
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.TextBox txtDictCustWords;
        private System.Windows.Forms.TextBox txtDictLastCustWords;
        private System.Windows.Forms.TextBox txtDictFirstCustWords;
        private System.Windows.Forms.ToolStripMenuItem mnQuickClean;
        private System.Windows.Forms.Button btnQuickSave;
        private System.Windows.Forms.Button btnQuickLoad;
    }
}


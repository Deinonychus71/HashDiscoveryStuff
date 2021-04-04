
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
            this.chkSkipDigits = new System.Windows.Forms.CheckBox();
            this.lblSkipDigits = new System.Windows.Forms.Label();
            this.lblLowerCase = new System.Windows.Forms.Label();
            this.chkLowerCase = new System.Windows.Forms.CheckBox();
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
            this.chklDictionaries = new System.Windows.Forms.CheckedListBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblSkipSpecials = new System.Windows.Forms.Label();
            this.chkSpecials = new System.Windows.Forms.CheckBox();
            this.lblSuffix = new System.Windows.Forms.Label();
            this.txtSuffix = new System.Windows.Forms.TextBox();
            this.lblCombinationOrder = new System.Windows.Forms.Label();
            this.pnlDictionary = new System.Windows.Forms.Panel();
            this.cbCombinationOrder = new System.Windows.Forms.ComboBox();
            this.txtIncludeWordsCharacter = new System.Windows.Forms.TextBox();
            this.pnlCharacter = new System.Windows.Forms.Panel();
            this.numEndPosition = new System.Windows.Forms.NumericUpDown();
            this.lblEndPosition = new System.Windows.Forms.Label();
            this.numStartPosition = new System.Windows.Forms.NumericUpDown();
            this.lblStartPosition = new System.Windows.Forms.Label();
            this.lblIncludeWordCharacters = new System.Windows.Forms.Label();
            this.txtStartingValidChars = new System.Windows.Forms.TextBox();
            this.lblStartingValidChars = new System.Windows.Forms.Label();
            this.txtValidChars = new System.Windows.Forms.TextBox();
            this.lblValidChars = new System.Windows.Forms.Label();
            this.chkVerbose = new System.Windows.Forms.CheckBox();
            this.pnlDictionary.SuspendLayout();
            this.pnlCharacter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numEndPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStartPosition)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHexValues
            // 
            this.lblHexValues.AutoSize = true;
            this.lblHexValues.Location = new System.Drawing.Point(16, 61);
            this.lblHexValues.Name = "lblHexValues";
            this.lblHexValues.Size = new System.Drawing.Size(75, 15);
            this.lblHexValues.TabIndex = 0;
            this.lblHexValues.Text = "Hex Value(s):";
            // 
            // txtHexValues
            // 
            this.txtHexValues.Location = new System.Drawing.Point(123, 58);
            this.txtHexValues.Name = "txtHexValues";
            this.txtHexValues.PlaceholderText = "0x105274ba4f";
            this.txtHexValues.Size = new System.Drawing.Size(178, 23);
            this.txtHexValues.TabIndex = 1;
            // 
            // lblMethod
            // 
            this.lblMethod.AutoSize = true;
            this.lblMethod.Location = new System.Drawing.Point(16, 21);
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
            this.cbMethod.Location = new System.Drawing.Point(123, 18);
            this.cbMethod.Name = "cbMethod";
            this.cbMethod.Size = new System.Drawing.Size(114, 23);
            this.cbMethod.TabIndex = 3;
            this.cbMethod.SelectedIndexChanged += new System.EventHandler(this.OnCbMethodChanged);
            // 
            // lblPrefix
            // 
            this.lblPrefix.AutoSize = true;
            this.lblPrefix.Location = new System.Drawing.Point(16, 101);
            this.lblPrefix.Name = "lblPrefix";
            this.lblPrefix.Size = new System.Drawing.Size(40, 15);
            this.lblPrefix.TabIndex = 4;
            this.lblPrefix.Text = "Prefix:";
            // 
            // txtPrefix
            // 
            this.txtPrefix.Location = new System.Drawing.Point(123, 98);
            this.txtPrefix.Name = "txtPrefix";
            this.txtPrefix.Size = new System.Drawing.Size(114, 23);
            this.txtPrefix.TabIndex = 5;
            // 
            // lblDelimiter
            // 
            this.lblDelimiter.AutoSize = true;
            this.lblDelimiter.Location = new System.Drawing.Point(328, 61);
            this.lblDelimiter.Name = "lblDelimiter";
            this.lblDelimiter.Size = new System.Drawing.Size(58, 15);
            this.lblDelimiter.TabIndex = 6;
            this.lblDelimiter.Text = "Delimiter:";
            // 
            // txtDelimiter
            // 
            this.txtDelimiter.Location = new System.Drawing.Point(392, 58);
            this.txtDelimiter.MaxLength = 1;
            this.txtDelimiter.Name = "txtDelimiter";
            this.txtDelimiter.Size = new System.Drawing.Size(27, 23);
            this.txtDelimiter.TabIndex = 7;
            this.txtDelimiter.Text = "_";
            this.txtDelimiter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chkSkipDigits
            // 
            this.chkSkipDigits.AutoSize = true;
            this.chkSkipDigits.Location = new System.Drawing.Point(393, 14);
            this.chkSkipDigits.Name = "chkSkipDigits";
            this.chkSkipDigits.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkSkipDigits.Size = new System.Drawing.Size(15, 14);
            this.chkSkipDigits.TabIndex = 8;
            this.chkSkipDigits.UseVisualStyleBackColor = true;
            // 
            // lblSkipDigits
            // 
            this.lblSkipDigits.AutoSize = true;
            this.lblSkipDigits.Location = new System.Drawing.Point(322, 12);
            this.lblSkipDigits.Name = "lblSkipDigits";
            this.lblSkipDigits.Size = new System.Drawing.Size(65, 15);
            this.lblSkipDigits.TabIndex = 9;
            this.lblSkipDigits.Text = "Skip Digits:";
            // 
            // lblLowerCase
            // 
            this.lblLowerCase.AutoSize = true;
            this.lblLowerCase.Location = new System.Drawing.Point(5, 12);
            this.lblLowerCase.Name = "lblLowerCase";
            this.lblLowerCase.Size = new System.Drawing.Size(100, 15);
            this.lblLowerCase.TabIndex = 10;
            this.lblLowerCase.Text = "Force Lower case:";
            // 
            // chkLowerCase
            // 
            this.chkLowerCase.AutoSize = true;
            this.chkLowerCase.Checked = true;
            this.chkLowerCase.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLowerCase.Location = new System.Drawing.Point(111, 13);
            this.chkLowerCase.Name = "chkLowerCase";
            this.chkLowerCase.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkLowerCase.Size = new System.Drawing.Size(15, 14);
            this.chkLowerCase.TabIndex = 11;
            this.chkLowerCase.UseVisualStyleBackColor = true;
            // 
            // lblNbThreads
            // 
            this.lblNbThreads.AutoSize = true;
            this.lblNbThreads.Location = new System.Drawing.Point(243, 21);
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
            this.cbNbThreads.Location = new System.Drawing.Point(300, 18);
            this.cbNbThreads.Name = "cbNbThreads";
            this.cbNbThreads.Size = new System.Drawing.Size(42, 23);
            this.cbNbThreads.TabIndex = 13;
            // 
            // lblExcludePatterns
            // 
            this.lblExcludePatterns.AutoSize = true;
            this.lblExcludePatterns.Location = new System.Drawing.Point(5, 54);
            this.lblExcludePatterns.Name = "lblExcludePatterns";
            this.lblExcludePatterns.Size = new System.Drawing.Size(97, 15);
            this.lblExcludePatterns.TabIndex = 14;
            this.lblExcludePatterns.Text = "Exclude Patterns:";
            // 
            // txtExcludePatterns
            // 
            this.txtExcludePatterns.Location = new System.Drawing.Point(112, 51);
            this.txtExcludePatterns.Name = "txtExcludePatterns";
            this.txtExcludePatterns.PlaceholderText = "{1}_{1},{2}_{2}";
            this.txtExcludePatterns.Size = new System.Drawing.Size(296, 23);
            this.txtExcludePatterns.TabIndex = 15;
            // 
            // lblIncludePatterns
            // 
            this.lblIncludePatterns.AutoSize = true;
            this.lblIncludePatterns.Location = new System.Drawing.Point(5, 95);
            this.lblIncludePatterns.Name = "lblIncludePatterns";
            this.lblIncludePatterns.Size = new System.Drawing.Size(95, 15);
            this.lblIncludePatterns.TabIndex = 16;
            this.lblIncludePatterns.Text = "Include Patterns:";
            // 
            // txtIncludePatterns
            // 
            this.txtIncludePatterns.Location = new System.Drawing.Point(112, 92);
            this.txtIncludePatterns.Name = "txtIncludePatterns";
            this.txtIncludePatterns.PlaceholderText = "{3}";
            this.txtIncludePatterns.Size = new System.Drawing.Size(296, 23);
            this.txtIncludePatterns.TabIndex = 17;
            // 
            // lblIncludeWord
            // 
            this.lblIncludeWord.AutoSize = true;
            this.lblIncludeWord.Location = new System.Drawing.Point(5, 137);
            this.lblIncludeWord.Name = "lblIncludeWord";
            this.lblIncludeWord.Size = new System.Drawing.Size(81, 15);
            this.lblIncludeWord.TabIndex = 18;
            this.lblIncludeWord.Text = "Include Word:";
            // 
            // txtIncludeWord
            // 
            this.txtIncludeWord.Location = new System.Drawing.Point(112, 134);
            this.txtIncludeWord.Name = "txtIncludeWord";
            this.txtIncludeWord.PlaceholderText = "mario";
            this.txtIncludeWord.Size = new System.Drawing.Size(114, 23);
            this.txtIncludeWord.TabIndex = 19;
            // 
            // lblWordsLimit
            // 
            this.lblWordsLimit.AutoSize = true;
            this.lblWordsLimit.Location = new System.Drawing.Point(239, 137);
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
            this.cbWordsLimit.Location = new System.Drawing.Point(317, 134);
            this.cbWordsLimit.Name = "cbWordsLimit";
            this.cbWordsLimit.Size = new System.Drawing.Size(91, 23);
            this.cbWordsLimit.TabIndex = 21;
            // 
            // lblDictionaries
            // 
            this.lblDictionaries.AutoSize = true;
            this.lblDictionaries.Location = new System.Drawing.Point(5, 218);
            this.lblDictionaries.Name = "lblDictionaries";
            this.lblDictionaries.Size = new System.Drawing.Size(72, 15);
            this.lblDictionaries.TabIndex = 22;
            this.lblDictionaries.Text = "Dictionaries:";
            // 
            // chklDictionaries
            // 
            this.chklDictionaries.FormattingEnabled = true;
            this.chklDictionaries.Location = new System.Drawing.Point(112, 218);
            this.chklDictionaries.Name = "chklDictionaries";
            this.chklDictionaries.Size = new System.Drawing.Size(296, 184);
            this.chklDictionaries.TabIndex = 23;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(123, 554);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(213, 23);
            this.btnStart.TabIndex = 24;
            this.btnStart.Text = "START";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.OnBtnStartClick);
            // 
            // lblSkipSpecials
            // 
            this.lblSkipSpecials.AutoSize = true;
            this.lblSkipSpecials.Location = new System.Drawing.Point(156, 13);
            this.lblSkipSpecials.Name = "lblSkipSpecials";
            this.lblSkipSpecials.Size = new System.Drawing.Size(77, 15);
            this.lblSkipSpecials.TabIndex = 25;
            this.lblSkipSpecials.Text = "Skip Specials:";
            // 
            // chkSpecials
            // 
            this.chkSpecials.AutoSize = true;
            this.chkSpecials.Checked = true;
            this.chkSpecials.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSpecials.Location = new System.Drawing.Point(239, 13);
            this.chkSpecials.Name = "chkSpecials";
            this.chkSpecials.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkSpecials.Size = new System.Drawing.Size(15, 14);
            this.chkSpecials.TabIndex = 26;
            this.chkSpecials.UseVisualStyleBackColor = true;
            // 
            // lblSuffix
            // 
            this.lblSuffix.AutoSize = true;
            this.lblSuffix.Location = new System.Drawing.Point(250, 101);
            this.lblSuffix.Name = "lblSuffix";
            this.lblSuffix.Size = new System.Drawing.Size(40, 15);
            this.lblSuffix.TabIndex = 27;
            this.lblSuffix.Text = "Suffix:";
            // 
            // txtSuffix
            // 
            this.txtSuffix.Location = new System.Drawing.Point(305, 98);
            this.txtSuffix.Name = "txtSuffix";
            this.txtSuffix.Size = new System.Drawing.Size(114, 23);
            this.txtSuffix.TabIndex = 28;
            // 
            // lblCombinationOrder
            // 
            this.lblCombinationOrder.AutoSize = true;
            this.lblCombinationOrder.Location = new System.Drawing.Point(5, 177);
            this.lblCombinationOrder.Name = "lblCombinationOrder";
            this.lblCombinationOrder.Size = new System.Drawing.Size(40, 15);
            this.lblCombinationOrder.TabIndex = 29;
            this.lblCombinationOrder.Text = "Order:";
            // 
            // pnlDictionary
            // 
            this.pnlDictionary.Controls.Add(this.cbCombinationOrder);
            this.pnlDictionary.Controls.Add(this.lblDictionaries);
            this.pnlDictionary.Controls.Add(this.lblCombinationOrder);
            this.pnlDictionary.Controls.Add(this.chkSpecials);
            this.pnlDictionary.Controls.Add(this.lblSkipSpecials);
            this.pnlDictionary.Controls.Add(this.chklDictionaries);
            this.pnlDictionary.Controls.Add(this.cbWordsLimit);
            this.pnlDictionary.Controls.Add(this.lblWordsLimit);
            this.pnlDictionary.Controls.Add(this.txtIncludeWord);
            this.pnlDictionary.Controls.Add(this.lblIncludeWord);
            this.pnlDictionary.Controls.Add(this.txtIncludePatterns);
            this.pnlDictionary.Controls.Add(this.lblIncludePatterns);
            this.pnlDictionary.Controls.Add(this.txtExcludePatterns);
            this.pnlDictionary.Controls.Add(this.lblExcludePatterns);
            this.pnlDictionary.Controls.Add(this.chkLowerCase);
            this.pnlDictionary.Controls.Add(this.lblLowerCase);
            this.pnlDictionary.Controls.Add(this.lblSkipDigits);
            this.pnlDictionary.Controls.Add(this.chkSkipDigits);
            this.pnlDictionary.Location = new System.Drawing.Point(12, 127);
            this.pnlDictionary.Name = "pnlDictionary";
            this.pnlDictionary.Size = new System.Drawing.Size(423, 421);
            this.pnlDictionary.TabIndex = 31;
            // 
            // cbCombinationOrder
            // 
            this.cbCombinationOrder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCombinationOrder.FormattingEnabled = true;
            this.cbCombinationOrder.Items.AddRange(new object[] {
            "optimized",
            "longer_first",
            "shorter_first"});
            this.cbCombinationOrder.Location = new System.Drawing.Point(112, 174);
            this.cbCombinationOrder.Name = "cbCombinationOrder";
            this.cbCombinationOrder.Size = new System.Drawing.Size(295, 23);
            this.cbCombinationOrder.TabIndex = 30;
            // 
            // txtIncludeWordsCharacter
            // 
            this.txtIncludeWordsCharacter.Location = new System.Drawing.Point(112, 92);
            this.txtIncludeWordsCharacter.Name = "txtIncludeWordsCharacter";
            this.txtIncludeWordsCharacter.PlaceholderText = "mario";
            this.txtIncludeWordsCharacter.Size = new System.Drawing.Size(295, 23);
            this.txtIncludeWordsCharacter.TabIndex = 31;
            // 
            // pnlCharacter
            // 
            this.pnlCharacter.Controls.Add(this.numEndPosition);
            this.pnlCharacter.Controls.Add(this.lblEndPosition);
            this.pnlCharacter.Controls.Add(this.numStartPosition);
            this.pnlCharacter.Controls.Add(this.lblStartPosition);
            this.pnlCharacter.Controls.Add(this.txtIncludeWordsCharacter);
            this.pnlCharacter.Controls.Add(this.lblIncludeWordCharacters);
            this.pnlCharacter.Controls.Add(this.txtStartingValidChars);
            this.pnlCharacter.Controls.Add(this.lblStartingValidChars);
            this.pnlCharacter.Controls.Add(this.txtValidChars);
            this.pnlCharacter.Controls.Add(this.lblValidChars);
            this.pnlCharacter.Location = new System.Drawing.Point(12, 127);
            this.pnlCharacter.Name = "pnlCharacter";
            this.pnlCharacter.Size = new System.Drawing.Size(423, 421);
            this.pnlCharacter.TabIndex = 32;
            // 
            // numEndPosition
            // 
            this.numEndPosition.Location = new System.Drawing.Point(328, 135);
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
            // lblEndPosition
            // 
            this.lblEndPosition.AutoSize = true;
            this.lblEndPosition.Location = new System.Drawing.Point(238, 137);
            this.lblEndPosition.Name = "lblEndPosition";
            this.lblEndPosition.Size = new System.Drawing.Size(76, 15);
            this.lblEndPosition.TabIndex = 36;
            this.lblEndPosition.Text = "End Position:";
            // 
            // numStartPosition
            // 
            this.numStartPosition.Location = new System.Drawing.Point(111, 135);
            this.numStartPosition.Name = "numStartPosition";
            this.numStartPosition.Size = new System.Drawing.Size(79, 23);
            this.numStartPosition.TabIndex = 35;
            // 
            // lblStartPosition
            // 
            this.lblStartPosition.AutoSize = true;
            this.lblStartPosition.Location = new System.Drawing.Point(4, 137);
            this.lblStartPosition.Name = "lblStartPosition";
            this.lblStartPosition.Size = new System.Drawing.Size(80, 15);
            this.lblStartPosition.TabIndex = 34;
            this.lblStartPosition.Text = "Start Position:";
            // 
            // lblIncludeWordCharacters
            // 
            this.lblIncludeWordCharacters.AutoSize = true;
            this.lblIncludeWordCharacters.Location = new System.Drawing.Point(4, 95);
            this.lblIncludeWordCharacters.Name = "lblIncludeWordCharacters";
            this.lblIncludeWordCharacters.Size = new System.Drawing.Size(81, 15);
            this.lblIncludeWordCharacters.TabIndex = 33;
            this.lblIncludeWordCharacters.Text = "Include Word:";
            // 
            // txtStartingValidChars
            // 
            this.txtStartingValidChars.Location = new System.Drawing.Point(112, 51);
            this.txtStartingValidChars.Name = "txtStartingValidChars";
            this.txtStartingValidChars.Size = new System.Drawing.Size(295, 23);
            this.txtStartingValidChars.TabIndex = 33;
            this.txtStartingValidChars.Text = "etainoshrdlucmfwygpbvkqjxz_";
            // 
            // lblStartingValidChars
            // 
            this.lblStartingValidChars.AutoSize = true;
            this.lblStartingValidChars.Location = new System.Drawing.Point(4, 54);
            this.lblStartingValidChars.Name = "lblStartingValidChars";
            this.lblStartingValidChars.Size = new System.Drawing.Size(84, 15);
            this.lblStartingValidChars.TabIndex = 32;
            this.lblStartingValidChars.Text = "Starting Chars:";
            // 
            // txtValidChars
            // 
            this.txtValidChars.Location = new System.Drawing.Point(112, 9);
            this.txtValidChars.Name = "txtValidChars";
            this.txtValidChars.Size = new System.Drawing.Size(295, 23);
            this.txtValidChars.TabIndex = 31;
            this.txtValidChars.Text = "etainoshrdlucmfwygpbvkqjxz0123456789_";
            // 
            // lblValidChars
            // 
            this.lblValidChars.AutoSize = true;
            this.lblValidChars.Location = new System.Drawing.Point(4, 12);
            this.lblValidChars.Name = "lblValidChars";
            this.lblValidChars.Size = new System.Drawing.Size(68, 15);
            this.lblValidChars.TabIndex = 31;
            this.lblValidChars.Text = "Valid Chars:";
            // 
            // chkVerbose
            // 
            this.chkVerbose.AutoSize = true;
            this.chkVerbose.Checked = true;
            this.chkVerbose.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkVerbose.Location = new System.Drawing.Point(352, 20);
            this.chkVerbose.Name = "chkVerbose";
            this.chkVerbose.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkVerbose.Size = new System.Drawing.Size(67, 19);
            this.chkVerbose.TabIndex = 33;
            this.chkVerbose.Text = "Verbose";
            this.chkVerbose.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 597);
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
            this.Controls.Add(this.pnlDictionary);
            this.Controls.Add(this.pnlCharacter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "BruteForceHash";
            this.pnlDictionary.ResumeLayout(false);
            this.pnlDictionary.PerformLayout();
            this.pnlCharacter.ResumeLayout(false);
            this.pnlCharacter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numEndPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStartPosition)).EndInit();
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
        private System.Windows.Forms.CheckBox chkSkipDigits;
        private System.Windows.Forms.Label lblSkipDigits;
        private System.Windows.Forms.Label lblLowerCase;
        private System.Windows.Forms.CheckBox chkLowerCase;
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
        private System.Windows.Forms.CheckedListBox chklDictionaries;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txtExcludePatterns1;
        private System.Windows.Forms.Label lblSkipSpecials;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox chkSpecials;
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
    }
}


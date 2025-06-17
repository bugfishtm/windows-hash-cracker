namespace hashcracker
{
    partial class Interface
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Interface));
            Panel_Top = new Panel();
            Label_Version = new Label();
            Image_Logo = new PictureBox();
            Label_Title = new Label();
            Panel_Body = new Panel();
            button2 = new Button();
            labelStatus = new Label();
            groupDecode = new GroupBox();
            textDecodeString = new TextBox();
            label1 = new Label();
            buttonStart = new Button();
            buttonStop = new Button();
            groupEncode = new GroupBox();
            button1 = new Button();
            label3 = new Label();
            textEncodeString = new TextBox();
            groupType = new GroupBox();
            radioTypeDecode = new RadioButton();
            radioTypeEncode = new RadioButton();
            groupHash = new GroupBox();
            radioMysqlSHA = new RadioButton();
            radioSHA1 = new RadioButton();
            radioPreMySQL = new RadioButton();
            radioMd5 = new RadioButton();
            radioSHA256 = new RadioButton();
            radioSHA512 = new RadioButton();
            radioBcrypt = new RadioButton();
            groupBChar = new GroupBox();
            checkboxCustomText = new TextBox();
            checkboxSmall = new CheckBox();
            checkboxCustom = new CheckBox();
            checkBoxCapital = new CheckBox();
            checkboxNumeric = new CheckBox();
            listHistory = new ListView();
            tooltip_frame = new ToolTip(components);
            btnMinimize = new Button();
            btnMaximize = new Button();
            btnClose = new Button();
            contextMenuStrip1 = new ContextMenuStrip(components);
            copyToolStripMenuItem = new ToolStripMenuItem();
            Panel_Top.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Image_Logo).BeginInit();
            Panel_Body.SuspendLayout();
            groupDecode.SuspendLayout();
            groupEncode.SuspendLayout();
            groupType.SuspendLayout();
            groupHash.SuspendLayout();
            groupBChar.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // Panel_Top
            // 
            Panel_Top.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Panel_Top.BackColor = Color.FromArgb(32, 32, 32);
            Panel_Top.Controls.Add(Label_Version);
            Panel_Top.Controls.Add(Image_Logo);
            Panel_Top.Controls.Add(Label_Title);
            Panel_Top.Location = new Point(0, 0);
            Panel_Top.Name = "Panel_Top";
            Panel_Top.Size = new Size(887, 59);
            Panel_Top.TabIndex = 0;
            Panel_Top.MouseDown += CustomUI_Header_Panel_MouseDown;
            // 
            // Label_Version
            // 
            Label_Version.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Label_Version.AutoSize = true;
            Label_Version.BackColor = Color.Transparent;
            Label_Version.Font = new Font("Segoe UI", 10F);
            Label_Version.ForeColor = Color.White;
            Label_Version.Location = new Point(794, 36);
            Label_Version.Name = "Label_Version";
            Label_Version.Size = new Size(93, 23);
            Label_Version.TabIndex = 4;
            Label_Version.Text = "Version 1.0";
            // 
            // Image_Logo
            // 
            Image_Logo.BackgroundImage = (Image)resources.GetObject("Image_Logo.BackgroundImage");
            Image_Logo.BackgroundImageLayout = ImageLayout.Zoom;
            Image_Logo.Location = new Point(3, 5);
            Image_Logo.Name = "Image_Logo";
            Image_Logo.Padding = new Padding(5);
            Image_Logo.Size = new Size(55, 45);
            Image_Logo.TabIndex = 1;
            Image_Logo.TabStop = false;
            // 
            // Label_Title
            // 
            Label_Title.AutoSize = true;
            Label_Title.BackColor = Color.Transparent;
            Label_Title.Font = new Font("Segoe UI", 23.2F);
            Label_Title.ForeColor = Color.White;
            Label_Title.Location = new Point(61, 0);
            Label_Title.Margin = new Padding(0);
            Label_Title.Name = "Label_Title";
            Label_Title.Size = new Size(249, 52);
            Label_Title.TabIndex = 3;
            Label_Title.Text = "Hash Cracker";
            // 
            // Panel_Body
            // 
            Panel_Body.BackColor = Color.FromArgb(24, 24, 24);
            Panel_Body.Controls.Add(button2);
            Panel_Body.Controls.Add(labelStatus);
            Panel_Body.Controls.Add(groupDecode);
            Panel_Body.Controls.Add(groupEncode);
            Panel_Body.Controls.Add(groupType);
            Panel_Body.Controls.Add(groupHash);
            Panel_Body.Controls.Add(groupBChar);
            Panel_Body.Controls.Add(listHistory);
            Panel_Body.Dock = DockStyle.Fill;
            Panel_Body.Location = new Point(0, 0);
            Panel_Body.Name = "Panel_Body";
            Panel_Body.Size = new Size(887, 618);
            Panel_Body.TabIndex = 1;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button2.Location = new Point(12, 580);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 14;
            button2.Text = "Clear";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // labelStatus
            // 
            labelStatus.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            labelStatus.AutoSize = true;
            labelStatus.ForeColor = Color.Yellow;
            labelStatus.Location = new Point(824, 589);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(50, 20);
            labelStatus.TabIndex = 13;
            labelStatus.Text = "label2";
            labelStatus.TextAlign = ContentAlignment.MiddleRight;
            // 
            // groupDecode
            // 
            groupDecode.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupDecode.Controls.Add(textDecodeString);
            groupDecode.Controls.Add(label1);
            groupDecode.Controls.Add(buttonStart);
            groupDecode.Controls.Add(buttonStop);
            groupDecode.ForeColor = SystemColors.Control;
            groupDecode.Location = new Point(441, 203);
            groupDecode.Name = "groupDecode";
            groupDecode.Size = new Size(433, 128);
            groupDecode.TabIndex = 12;
            groupDecode.TabStop = false;
            groupDecode.Text = "Decode (Bruteforce)";
            // 
            // textDecodeString
            // 
            textDecodeString.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textDecodeString.Location = new Point(15, 46);
            textDecodeString.Name = "textDecodeString";
            textDecodeString.Size = new Size(399, 27);
            textDecodeString.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(15, 23);
            label1.Name = "label1";
            label1.Size = new Size(122, 20);
            label1.TabIndex = 7;
            label1.Text = "String to Decode";
            // 
            // buttonStart
            // 
            buttonStart.ForeColor = SystemColors.ActiveCaptionText;
            buttonStart.Location = new Point(15, 84);
            buttonStart.Name = "buttonStart";
            buttonStart.Size = new Size(146, 29);
            buttonStart.TabIndex = 4;
            buttonStart.Text = "Start Decryption";
            buttonStart.UseVisualStyleBackColor = true;
            buttonStart.Click += button1_Click;
            // 
            // buttonStop
            // 
            buttonStop.Enabled = false;
            buttonStop.ForeColor = SystemColors.ActiveCaptionText;
            buttonStop.Location = new Point(167, 84);
            buttonStop.Name = "buttonStop";
            buttonStop.Size = new Size(146, 29);
            buttonStop.TabIndex = 5;
            buttonStop.Text = "Stop Decryption";
            buttonStop.UseVisualStyleBackColor = true;
            buttonStop.Click += buttonStop_Click;
            // 
            // groupEncode
            // 
            groupEncode.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupEncode.Controls.Add(button1);
            groupEncode.Controls.Add(label3);
            groupEncode.Controls.Add(textEncodeString);
            groupEncode.ForeColor = SystemColors.Control;
            groupEncode.Location = new Point(441, 65);
            groupEncode.Name = "groupEncode";
            groupEncode.Size = new Size(433, 132);
            groupEncode.TabIndex = 11;
            groupEncode.TabStop = false;
            groupEncode.Text = "Encode";
            // 
            // button1
            // 
            button1.ForeColor = SystemColors.ActiveCaptionText;
            button1.Location = new Point(15, 90);
            button1.Name = "button1";
            button1.Size = new Size(146, 29);
            button1.TabIndex = 10;
            button1.Text = "Encode";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.ForeColor = SystemColors.Control;
            label3.Location = new Point(15, 23);
            label3.Name = "label3";
            label3.Size = new Size(119, 20);
            label3.TabIndex = 10;
            label3.Text = "String to Encode";
            // 
            // textEncodeString
            // 
            textEncodeString.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textEncodeString.Location = new Point(15, 46);
            textEncodeString.Name = "textEncodeString";
            textEncodeString.Size = new Size(399, 27);
            textEncodeString.TabIndex = 10;
            // 
            // groupType
            // 
            groupType.Controls.Add(radioTypeDecode);
            groupType.Controls.Add(radioTypeEncode);
            groupType.ForeColor = SystemColors.ButtonHighlight;
            groupType.Location = new Point(12, 65);
            groupType.Name = "groupType";
            groupType.Size = new Size(423, 63);
            groupType.TabIndex = 11;
            groupType.TabStop = false;
            groupType.Text = "Operation";
            // 
            // radioTypeDecode
            // 
            radioTypeDecode.AutoSize = true;
            radioTypeDecode.Location = new Point(100, 26);
            radioTypeDecode.Name = "radioTypeDecode";
            radioTypeDecode.Size = new Size(165, 24);
            radioTypeDecode.TabIndex = 10;
            radioTypeDecode.Text = "Decode (Bruteforce)";
            radioTypeDecode.UseVisualStyleBackColor = true;
            radioTypeDecode.CheckedChanged += radioTypeDecode_CheckedChanged;
            // 
            // radioTypeEncode
            // 
            radioTypeEncode.AutoSize = true;
            radioTypeEncode.Checked = true;
            radioTypeEncode.Location = new Point(15, 26);
            radioTypeEncode.Name = "radioTypeEncode";
            radioTypeEncode.Size = new Size(79, 24);
            radioTypeEncode.TabIndex = 11;
            radioTypeEncode.TabStop = true;
            radioTypeEncode.Text = "Encode";
            radioTypeEncode.UseVisualStyleBackColor = true;
            radioTypeEncode.CheckedChanged += radioTypeEncode_CheckedChanged;
            // 
            // groupHash
            // 
            groupHash.Controls.Add(radioMysqlSHA);
            groupHash.Controls.Add(radioSHA1);
            groupHash.Controls.Add(radioPreMySQL);
            groupHash.Controls.Add(radioMd5);
            groupHash.Controls.Add(radioSHA256);
            groupHash.Controls.Add(radioSHA512);
            groupHash.Controls.Add(radioBcrypt);
            groupHash.ForeColor = SystemColors.ButtonHighlight;
            groupHash.Location = new Point(12, 134);
            groupHash.Name = "groupHash";
            groupHash.Size = new Size(423, 93);
            groupHash.TabIndex = 9;
            groupHash.TabStop = false;
            groupHash.Text = "Hash Type";
            // 
            // radioMysqlSHA
            // 
            radioMysqlSHA.AutoSize = true;
            radioMysqlSHA.Location = new Point(147, 55);
            radioMysqlSHA.Name = "radioMysqlSHA";
            radioMysqlSHA.Size = new Size(240, 24);
            radioMysqlSHA.TabIndex = 9;
            radioMysqlSHA.TabStop = true;
            radioMysqlSHA.Text = "MySQL Double SHA-1 (41-char)";
            radioMysqlSHA.UseVisualStyleBackColor = true;
            radioMysqlSHA.CheckedChanged += radioMysqlSHA_CheckedChanged;
            // 
            // radioSHA1
            // 
            radioSHA1.AutoSize = true;
            radioSHA1.Location = new Point(83, 26);
            radioSHA1.Name = "radioSHA1";
            radioSHA1.Size = new Size(67, 24);
            radioSHA1.TabIndex = 2;
            radioSHA1.TabStop = true;
            radioSHA1.Text = "SHA1";
            radioSHA1.UseVisualStyleBackColor = true;
            radioSHA1.CheckedChanged += radioSHA1_CheckedChanged;
            // 
            // radioPreMySQL
            // 
            radioPreMySQL.AutoSize = true;
            radioPreMySQL.Location = new Point(15, 56);
            radioPreMySQL.Name = "radioPreMySQL";
            radioPreMySQL.Size = new Size(126, 24);
            radioPreMySQL.TabIndex = 1;
            radioPreMySQL.TabStop = true;
            radioPreMySQL.Text = "Pre-4.1 MySQL";
            radioPreMySQL.UseVisualStyleBackColor = true;
            radioPreMySQL.CheckedChanged += radioPreMySQL_CheckedChanged;
            // 
            // radioMd5
            // 
            radioMd5.AutoSize = true;
            radioMd5.Location = new Point(15, 26);
            radioMd5.Name = "radioMd5";
            radioMd5.Size = new Size(62, 24);
            radioMd5.TabIndex = 0;
            radioMd5.TabStop = true;
            radioMd5.Text = "MD5";
            radioMd5.UseVisualStyleBackColor = true;
            radioMd5.CheckedChanged += radioMd5_CheckedChanged;
            // 
            // radioSHA256
            // 
            radioSHA256.AutoSize = true;
            radioSHA256.Location = new Point(156, 26);
            radioSHA256.Name = "radioSHA256";
            radioSHA256.Size = new Size(89, 24);
            radioSHA256.TabIndex = 3;
            radioSHA256.TabStop = true;
            radioSHA256.Text = "SHA-256";
            radioSHA256.UseVisualStyleBackColor = true;
            radioSHA256.CheckedChanged += radioSHA256_CheckedChanged;
            // 
            // radioSHA512
            // 
            radioSHA512.AutoSize = true;
            radioSHA512.Location = new Point(251, 26);
            radioSHA512.Name = "radioSHA512";
            radioSHA512.Size = new Size(89, 24);
            radioSHA512.TabIndex = 4;
            radioSHA512.TabStop = true;
            radioSHA512.Text = "SHA-512";
            radioSHA512.UseVisualStyleBackColor = true;
            radioSHA512.CheckedChanged += radioSHA512_CheckedChanged;
            // 
            // radioBcrypt
            // 
            radioBcrypt.AutoSize = true;
            radioBcrypt.Location = new Point(346, 26);
            radioBcrypt.Name = "radioBcrypt";
            radioBcrypt.Size = new Size(72, 24);
            radioBcrypt.TabIndex = 5;
            radioBcrypt.TabStop = true;
            radioBcrypt.Text = "bcrypt";
            radioBcrypt.UseVisualStyleBackColor = true;
            radioBcrypt.CheckedChanged += radioBcrypt_CheckedChanged;
            // 
            // groupBChar
            // 
            groupBChar.Controls.Add(checkboxCustomText);
            groupBChar.Controls.Add(checkboxSmall);
            groupBChar.Controls.Add(checkboxCustom);
            groupBChar.Controls.Add(checkBoxCapital);
            groupBChar.Controls.Add(checkboxNumeric);
            groupBChar.ForeColor = SystemColors.ControlLightLight;
            groupBChar.Location = new Point(12, 233);
            groupBChar.Name = "groupBChar";
            groupBChar.Size = new Size(423, 98);
            groupBChar.TabIndex = 3;
            groupBChar.TabStop = false;
            groupBChar.Text = "Bruteforce: Character Set";
            // 
            // checkboxCustomText
            // 
            checkboxCustomText.Location = new Point(15, 56);
            checkboxCustomText.Name = "checkboxCustomText";
            checkboxCustomText.Size = new Size(393, 27);
            checkboxCustomText.TabIndex = 5;
            checkboxCustomText.Text = ";:_,.-öäüÖ ÄÜ#'+*~°!\"§$%&/()=?`´\\}][{<>|";
            // 
            // checkboxSmall
            // 
            checkboxSmall.AutoSize = true;
            checkboxSmall.Checked = true;
            checkboxSmall.CheckState = CheckState.Checked;
            checkboxSmall.ForeColor = SystemColors.ControlLightLight;
            checkboxSmall.Location = new Point(15, 26);
            checkboxSmall.Name = "checkboxSmall";
            checkboxSmall.Size = new Size(52, 24);
            checkboxSmall.TabIndex = 1;
            checkboxSmall.Text = "a-z";
            checkboxSmall.UseVisualStyleBackColor = true;
            // 
            // checkboxCustom
            // 
            checkboxCustom.AutoSize = true;
            checkboxCustom.Checked = true;
            checkboxCustom.CheckState = CheckState.Checked;
            checkboxCustom.ForeColor = SystemColors.ControlLightLight;
            checkboxCustom.Location = new Point(194, 26);
            checkboxCustom.Name = "checkboxCustom";
            checkboxCustom.Size = new Size(158, 24);
            checkboxCustom.TabIndex = 6;
            checkboxCustom.Text = "Custom (Text Field)";
            checkboxCustom.UseVisualStyleBackColor = true;
            // 
            // checkBoxCapital
            // 
            checkBoxCapital.AutoSize = true;
            checkBoxCapital.Checked = true;
            checkBoxCapital.CheckState = CheckState.Checked;
            checkBoxCapital.ForeColor = SystemColors.ControlLightLight;
            checkBoxCapital.Location = new Point(73, 26);
            checkBoxCapital.Name = "checkBoxCapital";
            checkBoxCapital.Size = new Size(56, 24);
            checkBoxCapital.TabIndex = 2;
            checkBoxCapital.Text = "A-Z";
            checkBoxCapital.UseVisualStyleBackColor = true;
            // 
            // checkboxNumeric
            // 
            checkboxNumeric.AutoSize = true;
            checkboxNumeric.Checked = true;
            checkboxNumeric.CheckState = CheckState.Checked;
            checkboxNumeric.ForeColor = SystemColors.ControlLightLight;
            checkboxNumeric.Location = new Point(135, 26);
            checkboxNumeric.Name = "checkboxNumeric";
            checkboxNumeric.Size = new Size(53, 24);
            checkboxNumeric.TabIndex = 4;
            checkboxNumeric.Text = "0-9";
            checkboxNumeric.UseVisualStyleBackColor = true;
            // 
            // listHistory
            // 
            listHistory.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listHistory.BackColor = Color.FromArgb(224, 224, 224);
            listHistory.ForeColor = Color.Black;
            listHistory.FullRowSelect = true;
            listHistory.GridLines = true;
            listHistory.Location = new Point(11, 337);
            listHistory.Name = "listHistory";
            listHistory.Size = new Size(863, 239);
            listHistory.TabIndex = 0;
            listHistory.UseCompatibleStateImageBehavior = false;
            // 
            // btnMinimize
            // 
            btnMinimize.Location = new Point(0, 0);
            btnMinimize.Name = "btnMinimize";
            btnMinimize.Size = new Size(75, 23);
            btnMinimize.TabIndex = 0;
            // 
            // btnMaximize
            // 
            btnMaximize.Location = new Point(0, 0);
            btnMaximize.Name = "btnMaximize";
            btnMaximize.Size = new Size(75, 23);
            btnMaximize.TabIndex = 0;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(0, 0);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 23);
            btnClose.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { copyToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(211, 56);
            // 
            // copyToolStripMenuItem
            // 
            copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            copyToolStripMenuItem.Size = new Size(210, 24);
            copyToolStripMenuItem.Text = "Copy";
            // 
            // Interface
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(32, 32, 32);
            ClientSize = new Size(887, 618);
            Controls.Add(Panel_Top);
            Controls.Add(Panel_Body);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Interface";
            Text = "Form1";
            Panel_Top.ResumeLayout(false);
            Panel_Top.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)Image_Logo).EndInit();
            Panel_Body.ResumeLayout(false);
            Panel_Body.PerformLayout();
            groupDecode.ResumeLayout(false);
            groupDecode.PerformLayout();
            groupEncode.ResumeLayout(false);
            groupEncode.PerformLayout();
            groupType.ResumeLayout(false);
            groupType.PerformLayout();
            groupHash.ResumeLayout(false);
            groupHash.PerformLayout();
            groupBChar.ResumeLayout(false);
            groupBChar.PerformLayout();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel Panel_Top;
        private Panel Panel_Body;
        private PictureBox Image_Logo;
        private Label Label_Title;
        private Label label4;
        private Label Label_Version;
        private ToolTip tooltip_frame;
        private GroupBox groupBChar;
        private CheckBox checkboxNumeric;
        private CheckBox checkboxCustom;
        private CheckBox checkboxSmall;
        private ListView listHistory;
        private CheckBox checkBoxCapital;
        private TextBox checkboxCustomText;
        private Button buttonStop;
        private Button buttonStart;
        private Label label1;
        private TextBox textDecodeString;
        private GroupBox groupHash;
        private RadioButton radioPreMySQL;
        private RadioButton radioMd5;
        private RadioButton radioSHA1;
        private RadioButton radioSHA512;
        private RadioButton radioSHA256;
        private RadioButton radioMysqlSHA;
        private RadioButton radioBcrypt;
        private GroupBox groupType;
        private RadioButton radioTypeEncode;
        private RadioButton radioTypeDecode;
        private GroupBox groupEncode;
        private GroupBox groupDecode;
        private Label label3;
        private TextBox textEncodeString;
        private Button button1;
        private Label labelStatus;
        private Button button2;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem copyToolStripMenuItem;
    }
}

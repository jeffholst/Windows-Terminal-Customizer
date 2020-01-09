namespace Windows_Terminal_Customizer
{
    partial class UserControlProfile
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxGUID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.buttonMakeDefault = new System.Windows.Forms.Button();
            this.comboBoxCommandLine = new System.Windows.Forms.ComboBox();
            this.comboBoxScheme = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxRotateSchemes = new System.Windows.Forms.CheckBox();
            this.comboBoxRotationSchedule = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.labelRotate = new System.Windows.Forms.Label();
            this.checkBoxRotateImages = new System.Windows.Forms.CheckBox();
            this.buttonRotateImageFolder = new System.Windows.Forms.Button();
            this.textBoxRotateImageFolder = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.labelBackgroundOpacity = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.trackBarBackgroundOpacity = new System.Windows.Forms.TrackBar();
            this.buttonSelectImage = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.comboBoxBackgroundImageStretchMode = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxBackgroundImageAlignment = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.labelBackgroundImageOpacity = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.trackBarBackgroundImageOpacity = new System.Windows.Forms.TrackBar();
            this.textBoxBackgroundImage = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxSource = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.linkLabelScheme = new System.Windows.Forms.LinkLabel();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBackgroundOpacity)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBackgroundImageOpacity)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "GUID";
            // 
            // textBoxGUID
            // 
            this.textBoxGUID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxGUID.Location = new System.Drawing.Point(77, 19);
            this.textBoxGUID.Name = "textBoxGUID";
            this.textBoxGUID.ReadOnly = true;
            this.textBoxGUID.Size = new System.Drawing.Size(333, 20);
            this.textBoxGUID.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Scheme";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Command";
            // 
            // textBoxName
            // 
            this.textBoxName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxName.Location = new System.Drawing.Point(77, 45);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.ReadOnly = true;
            this.textBoxName.Size = new System.Drawing.Size(333, 20);
            this.textBoxName.TabIndex = 7;
            // 
            // buttonMakeDefault
            // 
            this.buttonMakeDefault.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonMakeDefault.Location = new System.Drawing.Point(349, 13);
            this.buttonMakeDefault.Name = "buttonMakeDefault";
            this.buttonMakeDefault.Size = new System.Drawing.Size(100, 23);
            this.buttonMakeDefault.TabIndex = 8;
            this.buttonMakeDefault.Text = "Make Default";
            this.buttonMakeDefault.UseVisualStyleBackColor = true;
            this.buttonMakeDefault.Click += new System.EventHandler(this.buttonMakeDefault_Click);
            // 
            // comboBoxCommandLine
            // 
            this.comboBoxCommandLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxCommandLine.FormattingEnabled = true;
            this.comboBoxCommandLine.Location = new System.Drawing.Point(77, 98);
            this.comboBoxCommandLine.Name = "comboBoxCommandLine";
            this.comboBoxCommandLine.Size = new System.Drawing.Size(333, 21);
            this.comboBoxCommandLine.TabIndex = 9;
            // 
            // comboBoxScheme
            // 
            this.comboBoxScheme.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxScheme.FormattingEnabled = true;
            this.comboBoxScheme.Location = new System.Drawing.Point(77, 127);
            this.comboBoxScheme.Name = "comboBoxScheme";
            this.comboBoxScheme.Size = new System.Drawing.Size(333, 21);
            this.comboBoxScheme.TabIndex = 10;
            this.comboBoxScheme.SelectedValueChanged += new System.EventHandler(this.comboBoxScheme_SelectedValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.checkBoxRotateSchemes);
            this.groupBox1.Controls.Add(this.comboBoxRotationSchedule);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.labelRotate);
            this.groupBox1.Controls.Add(this.checkBoxRotateImages);
            this.groupBox1.Controls.Add(this.buttonRotateImageFolder);
            this.groupBox1.Controls.Add(this.textBoxRotateImageFolder);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.labelBackgroundOpacity);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.trackBarBackgroundOpacity);
            this.groupBox1.Controls.Add(this.buttonSelectImage);
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Controls.Add(this.labelBackgroundImageOpacity);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.trackBarBackgroundImageOpacity);
            this.groupBox1.Controls.Add(this.textBoxBackgroundImage);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(28, 238);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(427, 247);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Background";
            // 
            // checkBoxRotateSchemes
            // 
            this.checkBoxRotateSchemes.AutoSize = true;
            this.checkBoxRotateSchemes.Location = new System.Drawing.Point(110, 179);
            this.checkBoxRotateSchemes.Name = "checkBoxRotateSchemes";
            this.checkBoxRotateSchemes.Size = new System.Drawing.Size(105, 17);
            this.checkBoxRotateSchemes.TabIndex = 29;
            this.checkBoxRotateSchemes.Text = "Rotate Schemes";
            this.checkBoxRotateSchemes.UseVisualStyleBackColor = true;
            this.checkBoxRotateSchemes.CheckedChanged += new System.EventHandler(this.checkBoxRotateSchemes_CheckedChanged);
            // 
            // comboBoxRotationSchedule
            // 
            this.comboBoxRotationSchedule.FormattingEnabled = true;
            this.comboBoxRotationSchedule.Location = new System.Drawing.Point(281, 177);
            this.comboBoxRotationSchedule.Name = "comboBoxRotationSchedule";
            this.comboBoxRotationSchedule.Size = new System.Drawing.Size(130, 21);
            this.comboBoxRotationSchedule.TabIndex = 28;
            this.comboBoxRotationSchedule.SelectedValueChanged += new System.EventHandler(this.comboBoxRotationSchedule_SelectedValueChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(223, 181);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 13);
            this.label11.TabIndex = 27;
            this.label11.Text = "Schedule";
            // 
            // labelRotate
            // 
            this.labelRotate.AutoSize = true;
            this.labelRotate.Location = new System.Drawing.Point(383, 218);
            this.labelRotate.Name = "labelRotate";
            this.labelRotate.Size = new System.Drawing.Size(0, 13);
            this.labelRotate.TabIndex = 26;
            // 
            // checkBoxRotateImages
            // 
            this.checkBoxRotateImages.AutoSize = true;
            this.checkBoxRotateImages.Location = new System.Drawing.Point(6, 179);
            this.checkBoxRotateImages.Name = "checkBoxRotateImages";
            this.checkBoxRotateImages.Size = new System.Drawing.Size(95, 17);
            this.checkBoxRotateImages.TabIndex = 24;
            this.checkBoxRotateImages.Text = "Rotate Images";
            this.checkBoxRotateImages.UseVisualStyleBackColor = true;
            this.checkBoxRotateImages.CheckedChanged += new System.EventHandler(this.checkBoxRotateImages_CheckedChanged);
            // 
            // buttonRotateImageFolder
            // 
            this.buttonRotateImageFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRotateImageFolder.Location = new System.Drawing.Point(384, 209);
            this.buttonRotateImageFolder.Name = "buttonRotateImageFolder";
            this.buttonRotateImageFolder.Size = new System.Drawing.Size(30, 23);
            this.buttonRotateImageFolder.TabIndex = 23;
            this.buttonRotateImageFolder.Text = "...";
            this.buttonRotateImageFolder.UseVisualStyleBackColor = true;
            this.buttonRotateImageFolder.Click += new System.EventHandler(this.buttonRotateImageFolder_Click);
            // 
            // textBoxRotateImageFolder
            // 
            this.textBoxRotateImageFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxRotateImageFolder.Location = new System.Drawing.Point(81, 211);
            this.textBoxRotateImageFolder.Name = "textBoxRotateImageFolder";
            this.textBoxRotateImageFolder.Size = new System.Drawing.Size(296, 20);
            this.textBoxRotateImageFolder.TabIndex = 22;
            this.textBoxRotateImageFolder.TextChanged += new System.EventHandler(this.textBoxRotateImageFolder_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 214);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Image Folder";
            // 
            // labelBackgroundOpacity
            // 
            this.labelBackgroundOpacity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelBackgroundOpacity.AutoSize = true;
            this.labelBackgroundOpacity.Location = new System.Drawing.Point(383, 137);
            this.labelBackgroundOpacity.Name = "labelBackgroundOpacity";
            this.labelBackgroundOpacity.Size = new System.Drawing.Size(28, 13);
            this.labelBackgroundOpacity.TabIndex = 20;
            this.labelBackgroundOpacity.Text = "(1.0)";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 137);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(104, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "Background Opacity";
            // 
            // trackBarBackgroundOpacity
            // 
            this.trackBarBackgroundOpacity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarBackgroundOpacity.Location = new System.Drawing.Point(116, 137);
            this.trackBarBackgroundOpacity.Maximum = 100;
            this.trackBarBackgroundOpacity.Name = "trackBarBackgroundOpacity";
            this.trackBarBackgroundOpacity.Size = new System.Drawing.Size(261, 45);
            this.trackBarBackgroundOpacity.TabIndex = 18;
            this.trackBarBackgroundOpacity.Value = 100;
            this.trackBarBackgroundOpacity.Scroll += new System.EventHandler(this.trackBarBackgroundOpacity_Scroll);
            // 
            // buttonSelectImage
            // 
            this.buttonSelectImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSelectImage.Location = new System.Drawing.Point(384, 17);
            this.buttonSelectImage.Name = "buttonSelectImage";
            this.buttonSelectImage.Size = new System.Drawing.Size(30, 23);
            this.buttonSelectImage.TabIndex = 17;
            this.buttonSelectImage.Text = "...";
            this.buttonSelectImage.UseVisualStyleBackColor = true;
            this.buttonSelectImage.Click += new System.EventHandler(this.buttonSelectImage_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 57F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.comboBoxBackgroundImageStretchMode, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label7, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxBackgroundImageAlignment, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 51);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(408, 38);
            this.tableLayoutPanel1.TabIndex = 16;
            // 
            // comboBoxBackgroundImageStretchMode
            // 
            this.comboBoxBackgroundImageStretchMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxBackgroundImageStretchMode.FormattingEnabled = true;
            this.comboBoxBackgroundImageStretchMode.Location = new System.Drawing.Point(275, 8);
            this.comboBoxBackgroundImageStretchMode.Name = "comboBoxBackgroundImageStretchMode";
            this.comboBoxBackgroundImageStretchMode.Size = new System.Drawing.Size(130, 21);
            this.comboBoxBackgroundImageStretchMode.TabIndex = 12;
            this.comboBoxBackgroundImageStretchMode.SelectedValueChanged += new System.EventHandler(this.comboBoxBackgroundImageStretchMode_SelectedValueChanged);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.Location = new System.Drawing.Point(195, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Stretch Mode";
            // 
            // comboBoxBackgroundImageAlignment
            // 
            this.comboBoxBackgroundImageAlignment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxBackgroundImageAlignment.FormattingEnabled = true;
            this.comboBoxBackgroundImageAlignment.Location = new System.Drawing.Point(60, 8);
            this.comboBoxBackgroundImageAlignment.Name = "comboBoxBackgroundImageAlignment";
            this.comboBoxBackgroundImageAlignment.Size = new System.Drawing.Size(129, 21);
            this.comboBoxBackgroundImageAlignment.TabIndex = 10;
            this.comboBoxBackgroundImageAlignment.SelectedValueChanged += new System.EventHandler(this.comboBoxBackgroundImageAlignment_SelectedValueChanged);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.Location = new System.Drawing.Point(3, 12);
            this.label6.MinimumSize = new System.Drawing.Size(60, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Alignment";
            // 
            // labelBackgroundImageOpacity
            // 
            this.labelBackgroundImageOpacity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelBackgroundImageOpacity.AutoSize = true;
            this.labelBackgroundImageOpacity.Location = new System.Drawing.Point(383, 101);
            this.labelBackgroundImageOpacity.Name = "labelBackgroundImageOpacity";
            this.labelBackgroundImageOpacity.Size = new System.Drawing.Size(28, 13);
            this.labelBackgroundImageOpacity.TabIndex = 15;
            this.labelBackgroundImageOpacity.Text = "(1.0)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(35, 101);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Image Opacity";
            // 
            // trackBarBackgroundImageOpacity
            // 
            this.trackBarBackgroundImageOpacity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarBackgroundImageOpacity.Location = new System.Drawing.Point(116, 101);
            this.trackBarBackgroundImageOpacity.Maximum = 100;
            this.trackBarBackgroundImageOpacity.Name = "trackBarBackgroundImageOpacity";
            this.trackBarBackgroundImageOpacity.Size = new System.Drawing.Size(261, 45);
            this.trackBarBackgroundImageOpacity.TabIndex = 13;
            this.trackBarBackgroundImageOpacity.Value = 100;
            this.trackBarBackgroundImageOpacity.Scroll += new System.EventHandler(this.trackBarBackgroundImageOpacity_Scroll);
            // 
            // textBoxBackgroundImage
            // 
            this.textBoxBackgroundImage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxBackgroundImage.Location = new System.Drawing.Point(65, 19);
            this.textBoxBackgroundImage.Name = "textBoxBackgroundImage";
            this.textBoxBackgroundImage.Size = new System.Drawing.Size(312, 20);
            this.textBoxBackgroundImage.TabIndex = 8;
            this.textBoxBackgroundImage.TextChanged += new System.EventHandler(this.textBoxBackgroundImage_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Image";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Images|*.png;*.jpg;*.gif;*.jpeg|All files|*.*";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.textBoxSource);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.linkLabelScheme);
            this.groupBox2.Controls.Add(this.textBoxGUID);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.comboBoxScheme);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.comboBoxCommandLine);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.textBoxName);
            this.groupBox2.Location = new System.Drawing.Point(28, 42);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(426, 180);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "General";
            // 
            // textBoxSource
            // 
            this.textBoxSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSource.Location = new System.Drawing.Point(77, 71);
            this.textBoxSource.Name = "textBoxSource";
            this.textBoxSource.Size = new System.Drawing.Size(333, 20);
            this.textBoxSource.TabIndex = 14;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(23, 74);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 13);
            this.label12.TabIndex = 13;
            this.label12.Text = "Source";
            // 
            // linkLabelScheme
            // 
            this.linkLabelScheme.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabelScheme.AutoSize = true;
            this.linkLabelScheme.Location = new System.Drawing.Point(338, 154);
            this.linkLabelScheme.Name = "linkLabelScheme";
            this.linkLabelScheme.Size = new System.Drawing.Size(72, 13);
            this.linkLabelScheme.TabIndex = 13;
            this.linkLabelScheme.TabStop = true;
            this.linkLabelScheme.Text = "View Scheme";
            this.linkLabelScheme.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelScheme_LinkClicked);
            // 
            // UserControlProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonMakeDefault);
            this.Name = "UserControlProfile";
            this.Size = new System.Drawing.Size(483, 498);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBackgroundOpacity)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBackgroundImageOpacity)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxGUID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Button buttonMakeDefault;
        private System.Windows.Forms.ComboBox comboBoxCommandLine;
        private System.Windows.Forms.ComboBox comboBoxScheme;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBoxBackgroundImageAlignment;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxBackgroundImage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar trackBarBackgroundImageOpacity;
        private System.Windows.Forms.ComboBox comboBoxBackgroundImageStretchMode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label labelBackgroundImageOpacity;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button buttonSelectImage;
        private System.Windows.Forms.Label labelBackgroundOpacity;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TrackBar trackBarBackgroundOpacity;
        private System.Windows.Forms.Button buttonRotateImageFolder;
        private System.Windows.Forms.TextBox textBoxRotateImageFolder;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox checkBoxRotateImages;
        private System.Windows.Forms.ComboBox comboBoxRotationSchedule;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label labelRotate;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.CheckBox checkBoxRotateSchemes;
        private System.Windows.Forms.LinkLabel linkLabelScheme;
        private System.Windows.Forms.TextBox textBoxSource;
        private System.Windows.Forms.Label label12;
    }
}

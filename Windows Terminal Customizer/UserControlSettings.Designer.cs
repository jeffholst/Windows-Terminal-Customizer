namespace Windows_Terminal_Customizer
{
    partial class UserControlSettings
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
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxSchemeFolder = new System.Windows.Forms.TextBox();
            this.buttonSchemeFolder = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxRemoveUnusedSchemes = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxWindowsTerminalEXE = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonWindowsTerminal = new System.Windows.Forms.Button();
            this.textBoxWindowsTerminalFolder = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog2 = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Folder";
            // 
            // textBoxSchemeFolder
            // 
            this.textBoxSchemeFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSchemeFolder.Location = new System.Drawing.Point(60, 32);
            this.textBoxSchemeFolder.Name = "textBoxSchemeFolder";
            this.textBoxSchemeFolder.ReadOnly = true;
            this.textBoxSchemeFolder.Size = new System.Drawing.Size(278, 20);
            this.textBoxSchemeFolder.TabIndex = 1;
            // 
            // buttonSchemeFolder
            // 
            this.buttonSchemeFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSchemeFolder.Location = new System.Drawing.Point(363, 30);
            this.buttonSchemeFolder.Name = "buttonSchemeFolder";
            this.buttonSchemeFolder.Size = new System.Drawing.Size(27, 23);
            this.buttonSchemeFolder.TabIndex = 2;
            this.buttonSchemeFolder.Text = "...";
            this.buttonSchemeFolder.UseVisualStyleBackColor = true;
            this.buttonSchemeFolder.Click += new System.EventHandler(this.buttonSchemeFolder_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.checkBoxRemoveUnusedSchemes);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.buttonSchemeFolder);
            this.groupBox1.Controls.Add(this.textBoxSchemeFolder);
            this.groupBox1.Location = new System.Drawing.Point(22, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(405, 143);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Schemes";
            // 
            // checkBoxRemoveUnusedSchemes
            // 
            this.checkBoxRemoveUnusedSchemes.AutoSize = true;
            this.checkBoxRemoveUnusedSchemes.Checked = true;
            this.checkBoxRemoveUnusedSchemes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxRemoveUnusedSchemes.Location = new System.Drawing.Point(21, 104);
            this.checkBoxRemoveUnusedSchemes.Name = "checkBoxRemoveUnusedSchemes";
            this.checkBoxRemoveUnusedSchemes.Size = new System.Drawing.Size(270, 17);
            this.checkBoxRemoveUnusedSchemes.TabIndex = 4;
            this.checkBoxRemoveUnusedSchemes.Text = "Remove unused Schemes from JSON file on saves.";
            this.checkBoxRemoveUnusedSchemes.UseVisualStyleBackColor = true;
            this.checkBoxRemoveUnusedSchemes.CheckedChanged += new System.EventHandler(this.checkBoxRemoveUnusedSchemes_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(249, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "This is the folder containing the scheme JSON files.";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.textBoxWindowsTerminalEXE);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.buttonWindowsTerminal);
            this.groupBox2.Controls.Add(this.textBoxWindowsTerminalFolder);
            this.groupBox2.Location = new System.Drawing.Point(22, 182);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(405, 173);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Windows Terminal";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(18, 141);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(262, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "This is the name of the Windows Terminal executable.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "EXE";
            // 
            // textBoxWindowsTerminalEXE
            // 
            this.textBoxWindowsTerminalEXE.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxWindowsTerminalEXE.Location = new System.Drawing.Point(60, 102);
            this.textBoxWindowsTerminalEXE.Name = "textBoxWindowsTerminalEXE";
            this.textBoxWindowsTerminalEXE.Size = new System.Drawing.Size(278, 20);
            this.textBoxWindowsTerminalEXE.TabIndex = 5;
            this.textBoxWindowsTerminalEXE.TextChanged += new System.EventHandler(this.textBoxWindowsTerminalEXE_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(302, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "This is the folder containing the Windows Terminal executable.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Folder";
            // 
            // buttonWindowsTerminal
            // 
            this.buttonWindowsTerminal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonWindowsTerminal.Location = new System.Drawing.Point(363, 31);
            this.buttonWindowsTerminal.Name = "buttonWindowsTerminal";
            this.buttonWindowsTerminal.Size = new System.Drawing.Size(27, 23);
            this.buttonWindowsTerminal.TabIndex = 2;
            this.buttonWindowsTerminal.Text = "...";
            this.buttonWindowsTerminal.UseVisualStyleBackColor = true;
            this.buttonWindowsTerminal.Click += new System.EventHandler(this.buttonWindowsTerminal_Click);
            // 
            // textBoxWindowsTerminalFolder
            // 
            this.textBoxWindowsTerminalFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxWindowsTerminalFolder.Location = new System.Drawing.Point(60, 33);
            this.textBoxWindowsTerminalFolder.Name = "textBoxWindowsTerminalFolder";
            this.textBoxWindowsTerminalFolder.ReadOnly = true;
            this.textBoxWindowsTerminalFolder.Size = new System.Drawing.Size(278, 20);
            this.textBoxWindowsTerminalFolder.TabIndex = 1;
            // 
            // UserControlSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "UserControlSettings";
            this.Size = new System.Drawing.Size(454, 380);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxSchemeFolder;
        private System.Windows.Forms.Button buttonSchemeFolder;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonWindowsTerminal;
        private System.Windows.Forms.TextBox textBoxWindowsTerminalFolder;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxWindowsTerminalEXE;
        private System.Windows.Forms.CheckBox checkBoxRemoveUnusedSchemes;
    }
}

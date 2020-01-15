namespace Windows_Terminal_Customizer
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Global");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Profiles");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Schemes");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("KeyBindings");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Settings", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4});
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("All Schemes");
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLaunch = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNext = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSchedule = new System.Windows.Forms.ToolStripMenuItem();
            this.nextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.previousToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRotatePauseStart = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.contextMenuProfilesNode = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.profileAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuProfilesChildNode = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.profileCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.profileDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuAllSchemesAdd = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuAllSchemesChildNode = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.allSchemeseCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.allSchemesDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.newSchemeDialog = new System.Windows.Forms.SaveFileDialog();
            this.userControlSettings1 = new Windows_Terminal_Customizer.UserControlSettings();
            this.userControlHelp1 = new Windows_Terminal_Customizer.UserControlHelp();
            this.userControlKeyBinding1 = new Windows_Terminal_Customizer.UserControlKeyBinding();
            this.userControlScheme1 = new Windows_Terminal_Customizer.UserControlScheme();
            this.userControlDefault1 = new Windows_Terminal_Customizer.UserControlDefault();
            this.userControlProfile1 = new Windows_Terminal_Customizer.UserControlProfile();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.contextMenuProfilesNode.SuspendLayout();
            this.contextMenuProfilesChildNode.SuspendLayout();
            this.contextMenuAllSchemesAdd.SuspendLayout();
            this.contextMenuAllSchemesChildNode.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuEdit,
            this.menuSettings,
            this.menuLaunch,
            this.menuNext,
            this.menuSchedule,
            this.menuHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(695, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFileOpen});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(37, 20);
            this.menuFile.Text = "File";
            // 
            // menuFileOpen
            // 
            this.menuFileOpen.Name = "menuFileOpen";
            this.menuFileOpen.Size = new System.Drawing.Size(103, 22);
            this.menuFileOpen.Text = "Open";
            this.menuFileOpen.Click += new System.EventHandler(this.menuFileOpen_Click);
            // 
            // menuEdit
            // 
            this.menuEdit.Name = "menuEdit";
            this.menuEdit.Size = new System.Drawing.Size(39, 20);
            this.menuEdit.Text = "Edit";
            // 
            // menuSettings
            // 
            this.menuSettings.Name = "menuSettings";
            this.menuSettings.Size = new System.Drawing.Size(61, 20);
            this.menuSettings.Text = "Settings";
            this.menuSettings.Click += new System.EventHandler(this.menuSettings_Click);
            // 
            // menuLaunch
            // 
            this.menuLaunch.Name = "menuLaunch";
            this.menuLaunch.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.menuLaunch.Size = new System.Drawing.Size(64, 20);
            this.menuLaunch.Text = "Terminal";
            this.menuLaunch.Click += new System.EventHandler(this.menuLaunch_Click);
            // 
            // menuNext
            // 
            this.menuNext.Name = "menuNext";
            this.menuNext.Size = new System.Drawing.Size(53, 20);
            this.menuNext.Text = "Rotate";
            this.menuNext.Click += new System.EventHandler(this.menuNext_Click);
            // 
            // menuSchedule
            // 
            this.menuSchedule.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nextToolStripMenuItem,
            this.previousToolStripMenuItem,
            this.menuRotatePauseStart});
            this.menuSchedule.Name = "menuSchedule";
            this.menuSchedule.Size = new System.Drawing.Size(67, 20);
            this.menuSchedule.Text = "Schedule";
            // 
            // nextToolStripMenuItem
            // 
            this.nextToolStripMenuItem.Name = "nextToolStripMenuItem";
            this.nextToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Right)));
            this.nextToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.nextToolStripMenuItem.Text = "Rotate Next";
            this.nextToolStripMenuItem.Click += new System.EventHandler(this.nextToolStripMenuItem_Click_1);
            // 
            // previousToolStripMenuItem
            // 
            this.previousToolStripMenuItem.Name = "previousToolStripMenuItem";
            this.previousToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Left)));
            this.previousToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.previousToolStripMenuItem.Text = "Rotate Previous";
            // 
            // menuRotatePauseStart
            // 
            this.menuRotatePauseStart.Name = "menuRotatePauseStart";
            this.menuRotatePauseStart.Size = new System.Drawing.Size(210, 22);
            this.menuRotatePauseStart.Text = "Pause";
            this.menuRotatePauseStart.Click += new System.EventHandler(this.menuRotatePauseStart_Click);
            // 
            // menuHelp
            // 
            this.menuHelp.Name = "menuHelp";
            this.menuHelp.Size = new System.Drawing.Size(44, 20);
            this.menuHelp.Text = "Help";
            this.menuHelp.Click += new System.EventHandler(this.menuHelp_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 914);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(695, 22);
            this.statusStrip1.TabIndex = 1;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Size = new System.Drawing.Size(695, 890);
            this.splitContainer1.SplitterDistance = 200;
            this.splitContainer1.TabIndex = 2;
            // 
            // treeView1
            // 
            this.treeView1.AllowDrop = true;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "Node0";
            treeNode1.Text = "Global";
            treeNode2.Name = "Node1";
            treeNode2.Text = "Profiles";
            treeNode3.Name = "Node2";
            treeNode3.Text = "Schemes";
            treeNode4.Name = "Node3";
            treeNode4.Text = "KeyBindings";
            treeNode5.Name = "Node0";
            treeNode5.Text = "Settings";
            treeNode6.Name = "Node1";
            treeNode6.Text = "All Schemes";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode6});
            this.treeView1.Size = new System.Drawing.Size(200, 890);
            this.treeView1.TabIndex = 0;
            this.treeView1.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.treeView1_ItemDrag);
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            this.treeView1.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeView1_DragDrop);
            this.treeView1.DragOver += new System.Windows.Forms.DragEventHandler(this.treeView1_DragOver);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "JSON files|*.json|All files|*.*";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // contextMenuProfilesNode
            // 
            this.contextMenuProfilesNode.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.profileAdd});
            this.contextMenuProfilesNode.Name = "contextMenuStrip1";
            this.contextMenuProfilesNode.Size = new System.Drawing.Size(97, 26);
            // 
            // profileAdd
            // 
            this.profileAdd.Name = "profileAdd";
            this.profileAdd.Size = new System.Drawing.Size(96, 22);
            this.profileAdd.Text = "Add";
            this.profileAdd.Click += new System.EventHandler(this.profileAdd_Click);
            // 
            // contextMenuProfilesChildNode
            // 
            this.contextMenuProfilesChildNode.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.profileCopy,
            this.profileDelete});
            this.contextMenuProfilesChildNode.Name = "contextMenuProfilesChildNode";
            this.contextMenuProfilesChildNode.Size = new System.Drawing.Size(108, 48);
            // 
            // profileCopy
            // 
            this.profileCopy.Name = "profileCopy";
            this.profileCopy.Size = new System.Drawing.Size(107, 22);
            this.profileCopy.Text = "Copy";
            this.profileCopy.Click += new System.EventHandler(this.profileCopy_Click);
            // 
            // profileDelete
            // 
            this.profileDelete.Name = "profileDelete";
            this.profileDelete.Size = new System.Drawing.Size(107, 22);
            this.profileDelete.Text = "Delete";
            this.profileDelete.Click += new System.EventHandler(this.profileDelete_Click);
            // 
            // contextMenuAllSchemesAdd
            // 
            this.contextMenuAllSchemesAdd.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem});
            this.contextMenuAllSchemesAdd.Name = "contextMenuAllSchemesNode";
            this.contextMenuAllSchemesAdd.Size = new System.Drawing.Size(97, 26);
            this.contextMenuAllSchemesAdd.Click += new System.EventHandler(this.allSchemesAdd_Click);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(96, 22);
            this.addToolStripMenuItem.Text = "Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // contextMenuAllSchemesChildNode
            // 
            this.contextMenuAllSchemesChildNode.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.allSchemeseCopy,
            this.allSchemesDelete});
            this.contextMenuAllSchemesChildNode.Name = "contextMenuAllSchemesChildNode";
            this.contextMenuAllSchemesChildNode.Size = new System.Drawing.Size(108, 48);
            // 
            // allSchemeseCopy
            // 
            this.allSchemeseCopy.Name = "allSchemeseCopy";
            this.allSchemeseCopy.Size = new System.Drawing.Size(107, 22);
            this.allSchemeseCopy.Text = "Copy";
            this.allSchemeseCopy.Click += new System.EventHandler(this.allSchemeseCopy_Click);
            // 
            // allSchemesDelete
            // 
            this.allSchemesDelete.Name = "allSchemesDelete";
            this.allSchemesDelete.Size = new System.Drawing.Size(107, 22);
            this.allSchemesDelete.Text = "Delete";
            this.allSchemesDelete.Click += new System.EventHandler(this.allSchemesDelete_Click);
            // 
            // newSchemeDialog
            // 
            this.newSchemeDialog.Filter = "JSON Files|*.json";
            this.newSchemeDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.newSchemeDialog_FileOk);
            // 
            // userControlSettings1
            // 
            this.userControlSettings1.AutoScroll = true;
            this.userControlSettings1.AutoSize = true;
            this.userControlSettings1.Location = new System.Drawing.Point(386, 218);
            this.userControlSettings1.Name = "userControlSettings1";
            this.userControlSettings1.Size = new System.Drawing.Size(136, 298);
            this.userControlSettings1.TabIndex = 5;
            // 
            // userControlHelp1
            // 
            this.userControlHelp1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.userControlHelp1.Location = new System.Drawing.Point(168, 262);
            this.userControlHelp1.Name = "userControlHelp1";
            this.userControlHelp1.Size = new System.Drawing.Size(114, 93);
            this.userControlHelp1.TabIndex = 4;
            // 
            // userControlKeyBinding1
            // 
            this.userControlKeyBinding1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.userControlKeyBinding1.Location = new System.Drawing.Point(244, 134);
            this.userControlKeyBinding1.Name = "userControlKeyBinding1";
            this.userControlKeyBinding1.Size = new System.Drawing.Size(87, 102);
            this.userControlKeyBinding1.TabIndex = 3;
            // 
            // userControlScheme1
            // 
            this.userControlScheme1.AutoScroll = true;
            this.userControlScheme1.AutoSize = true;
            this.userControlScheme1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.userControlScheme1.Location = new System.Drawing.Point(53, 150);
            this.userControlScheme1.Name = "userControlScheme1";
            this.userControlScheme1.Size = new System.Drawing.Size(486, 817);
            this.userControlScheme1.TabIndex = 2;
            // 
            // userControlDefault1
            // 
            this.userControlDefault1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.userControlDefault1.Location = new System.Drawing.Point(53, 25);
            this.userControlDefault1.Name = "userControlDefault1";
            this.userControlDefault1.Size = new System.Drawing.Size(107, 85);
            this.userControlDefault1.TabIndex = 0;
            // 
            // userControlProfile1
            // 
            this.userControlProfile1.AutoScroll = true;
            this.userControlProfile1.AutoSize = true;
            this.userControlProfile1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.userControlProfile1.Location = new System.Drawing.Point(0, 0);
            this.userControlProfile1.Name = "userControlProfile1";
            this.userControlProfile1.Size = new System.Drawing.Size(483, 498);
            this.userControlProfile1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 936);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Windows Terminal Customizer";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.contextMenuProfilesNode.ResumeLayout(false);
            this.contextMenuProfilesChildNode.ResumeLayout(false);
            this.contextMenuAllSchemesAdd.ResumeLayout(false);
            this.contextMenuAllSchemesChildNode.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem menuEdit;
        private System.Windows.Forms.ToolStripMenuItem menuHelp;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ToolStripMenuItem menuFileOpen;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private UserControlHelp userControlHelp1;
        private UserControlKeyBinding userControlKeyBinding1;
        private UserControlScheme userControlScheme1;
        private UserControlProfile userControlProfile1;
        private UserControlDefault userControlDefault1;
        private UserControlSettings userControlSettings1;
        private System.Windows.Forms.ToolStripMenuItem menuSettings;
        private System.Windows.Forms.ToolStripMenuItem menuLaunch;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ContextMenuStrip contextMenuProfilesNode;
        private System.Windows.Forms.ToolStripMenuItem profileAdd;
        private System.Windows.Forms.ToolStripMenuItem menuSchedule;
        private System.Windows.Forms.ToolStripMenuItem nextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuRotatePauseStart;
        private System.Windows.Forms.ToolStripMenuItem menuNext;
        private System.Windows.Forms.ToolStripMenuItem previousToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuProfilesChildNode;
        private System.Windows.Forms.ToolStripMenuItem profileCopy;
        private System.Windows.Forms.ToolStripMenuItem profileDelete;
        private System.Windows.Forms.ContextMenuStrip contextMenuAllSchemesAdd;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuAllSchemesChildNode;
        private System.Windows.Forms.ToolStripMenuItem allSchemeseCopy;
        private System.Windows.Forms.ToolStripMenuItem allSchemesDelete;
        private System.Windows.Forms.SaveFileDialog newSchemeDialog;
    }
}


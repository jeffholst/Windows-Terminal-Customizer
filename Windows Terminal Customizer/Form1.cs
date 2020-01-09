using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Windows_Terminal_Customizer
{
    enum Dialogs { None, Help, Settings, Global, Profile, Scheme, KeyBinding };

    public partial class Form1 : Form
    {
        private bool debug = false;             // debug session or not
        Settings settings;                      // settings object
        private string fileName;                // name of profile file
        private Dialogs currentDialog;          // current dialog being displayed
        private string schemesFolder;           // folder containing schemes JSON files 
        private List<Scheme> schemes;           // available schemes found in schemesFolder
        private string windowsTerminalFolder;   // location of Windows Terminal EXE
        private string windowsTerminalEXE;      // windows terminal exe read from config file
        private string windowsTerminalFQP;      // fully qualified path of windows terminal
        private TreeNode profileNode;           // profile parent node
        private TreeNode schemeNode;            // scheme parent node
        private TreeNode keyBindNode;           // keybind parent node
        private bool removeUnusedSchemes;       // remove unused schemes from JSON file
        private bool writeToFile = false;       // write to file on next timer interval
        private Timer writeToFileTimer;         // timer used to write to file
        private CustomizerTimer myTimer;
        private CustomProfile myCustomProfile;
        private int minutesRunning;
        private bool pauseRotations;

        private delegate void SafeCallDelegate(TreeNodeCollection nodes, string schemeName);
        private delegate void SafeCallDelegateRemoveNode(TreeNodeCollection nodes, TreeNode node);

        public Form1()
        {
            InitializeComponent();
            Setup();
        }

        private void Setup()
        {
            string lastFile;

            minutesRunning = 0;
            pauseRotations = false;

            debug = GetTrueOrFalseAppSetting("Debug", false);

            LogIt("Application Started");
            LogIt(string.Format("Debug set to {0}", debug));

            treeView1.Nodes[0].Expand();
            userControlHelp1.Dock = DockStyle.Fill;
            userControlSettings1.Dock = DockStyle.Fill;
            userControlDefault1.Dock = DockStyle.Fill;
            userControlProfile1.Dock = DockStyle.Fill;
            userControlScheme1.Dock = DockStyle.Fill;
            userControlKeyBinding1.Dock = DockStyle.Fill;

            lastFile = ConfigurationManager.AppSettings["LastFile"];
            LogIt(string.Format(string.Format("Read parameter 'LastFile' = '{0}'", lastFile)));

            if (!string.IsNullOrEmpty(lastFile) && File.Exists(lastFile))
            {
                fileName = lastFile;
                OpenFile();
            }

            schemesFolder = ConfigurationManager.AppSettings["SchemesFolder"];
            windowsTerminalFolder = ConfigurationManager.AppSettings["WindowsTerminalFolder"];
            windowsTerminalEXE = ConfigurationManager.AppSettings["WindowsTerminalEXE"];
            removeUnusedSchemes = GetTrueOrFalseAppSetting("RemoveUnusedSchemes", true);

            userControlSettings1.Setup(this, schemesFolder, windowsTerminalFolder, windowsTerminalEXE, removeUnusedSchemes);
            userControlProfile1.Setup(this);
            userControlScheme1.Setup(this);

            myCustomProfile = LoadCustomProfile();
            ReconcileCustomProfile();

            myTimer = new CustomizerTimer(this, userControlProfile1);

            writeToFileTimer = new Timer();
            writeToFileTimer.Tick += new EventHandler(WriteToFile);
            writeToFileTimer.Interval = 1000; // in milliseconds
            writeToFileTimer.Start();
        }

        private void LogIt(string message, bool force = false)
        {
            if (debug || force)
            {
                //textBox1.AppendText(string.Format("{0}\r\n", message));
            }
        }

        private void menuHelp_Click(object sender, EventArgs e)
        {
            userControlHelp1.Populate();
            SetCurrentDialog(Dialogs.Help);
        }

        private void SetCurrentDialog(Dialogs dialog)
        {
            if (currentDialog != dialog)
            {
                currentDialog = dialog;

                userControlHelp1.Visible = false;
                userControlSettings1.Visible = false;
                userControlDefault1.Visible = false;
                userControlProfile1.Visible = false;
                userControlScheme1.Visible = false;
                userControlKeyBinding1.Visible = false;

                switch (currentDialog)
                {
                    case Dialogs.Help:
                        userControlHelp1.Visible = true;
                        break;
                    case Dialogs.Settings:
                        userControlSettings1.Visible = true;
                        break;
                    case Dialogs.Global:
                        userControlDefault1.Visible = true;
                        break;
                    case Dialogs.Profile:
                        userControlProfile1.Visible = true;
                        break;
                    case Dialogs.Scheme:
                        userControlScheme1.Visible = true;
                        break;
                    case Dialogs.KeyBinding:
                        userControlKeyBinding1.Visible = true;
                        break;
                }
            }
        }

        private bool GetTrueOrFalseAppSetting(string appString, bool defaultValue)
        {
            bool rval;
            string tmp;

            rval = defaultValue;

            tmp = ConfigurationManager.AppSettings[appString].ToString();

            if ((string.Compare(tmp, "1", true) == 0)
                || (string.Compare(tmp, "true", true) == 0))
            {
                rval = true;
            }

            return (rval);
        }

        private void menuFileOpen_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void menuSettings_Click(object sender, EventArgs e)
        {
            SetCurrentDialog(Dialogs.Settings);
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            fileName = openFileDialog1.FileName;

            Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);

            config.AppSettings.Settings.Remove("LastFile");
            config.AppSettings.Settings.Add("LastFile", fileName);

            config.Save(ConfigurationSaveMode.Modified);

            OpenFile();
        }

        private void OpenFile()
        {
            LogIt(string.Format("Opening file '{0}'", fileName));

            using (StreamReader file = File.OpenText(fileName))
            {
                JsonSerializer serializer = new JsonSerializer();
                settings = (Settings)serializer.Deserialize(file, typeof(Settings));
            }

            toolStripStatusLabel1.Text = fileName;

            InitializeTree(settings);
        }

        private void InitializeTree(Settings settings)
        {
            TreeNode newNode;
            profileNode = treeView1.Nodes[0].Nodes[1];    // Profiles

            profileNode.Nodes.Clear();

            foreach (Profile profile in settings.profiles)
            {
                newNode = new TreeNode(profile.name);
                newNode.Tag = profile;
                profileNode.Nodes.Add(newNode);
            }

            schemeNode = treeView1.Nodes[0].Nodes[2];    // Schemes

            schemeNode.Nodes.Clear();

            foreach (Scheme scheme in settings.schemes)
            {
                schemeNode.Nodes.Add(scheme.name);
            }

            keyBindNode = treeView1.Nodes[0].Nodes[3];    // KeyBindings

            keyBindNode.Nodes.Clear();

            foreach (KeyBinding keyBinding in settings.keybindings)
            {
                keyBindNode.Nodes.Add(keyBinding.command);
            }
        }

        private void TreeViewNodeClicked()
        {
            CustomItem customItem;

            treeView1.ContextMenuStrip = null;

            if (treeView1.SelectedNode != null)
            {
                if (treeView1.SelectedNode.Level == 1 && treeView1.SelectedNode.Parent.Index == 0)
                {
                    SetCurrentDialog(Dialogs.Global);
                }
                else if (treeView1.SelectedNode.Level == 2 && treeView1.SelectedNode.Parent.Level == 1 && treeView1.SelectedNode.Parent.Parent.Index == 0)
                {
                    switch (treeView1.SelectedNode.Parent.Index)
                    {
                        case 1:
                            SetCurrentDialog(Dialogs.Profile);
                            customItem = GetCustomItemByGUID(settings.profiles[treeView1.SelectedNode.Index].guid);
                            userControlProfile1.Populate(settings.profiles[treeView1.SelectedNode.Index], treeView1.SelectedNode, customItem);
                            break;
                        case 2:
                            SetCurrentDialog(Dialogs.Scheme);
                            userControlScheme1.Populate(settings.schemes[treeView1.SelectedNode.Index], treeView1.SelectedNode);
                            break;
                        case 3:
                            SetCurrentDialog(Dialogs.KeyBinding);
                            break;
                    }
                }
                else if (treeView1.SelectedNode.Level == 0 && treeView1.SelectedNode.Index == 1)
                {
                    contextMenuStripAllSchemes.Items[1].Enabled = false;
                    treeView1.ContextMenuStrip = contextMenuStripAllSchemes;
                }
                else if (treeView1.SelectedNode.Level == 1 && treeView1.SelectedNode.Parent.Index == 1)
                {
                    contextMenuStripAllSchemes.Items[1].Enabled = true;
                    treeView1.ContextMenuStrip = contextMenuStripAllSchemes;

                    SetCurrentDialog(Dialogs.Scheme);
                    userControlScheme1.Populate(schemes[treeView1.SelectedNode.Index], null);
                }
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeViewNodeClicked();
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeViewNodeClicked();
        }

        public void schemesFolderSelected(string folder)
        {
            Scheme myScheme;
            TreeNode allSchemes;
            string[] schemeFiles;
            schemes = new List<Scheme>();

            if (!string.IsNullOrEmpty(folder) && Directory.Exists(folder))
            {
                allSchemes = treeView1.Nodes[1];

                Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);

                config.AppSettings.Settings.Remove("SchemesFolder");
                config.AppSettings.Settings.Add("SchemesFolder", folder);

                config.Save(ConfigurationSaveMode.Modified);

                schemeFiles = Directory.GetFiles(folder, "*.json");
                Array.Sort(schemeFiles, StringComparer.InvariantCulture);

                foreach (string scheme in schemeFiles)
                {
                    using (StreamReader file = File.OpenText(scheme))
                    {
                        JsonSerializer serializer = new JsonSerializer();
                        myScheme = (Scheme)serializer.Deserialize(file, typeof(Scheme));
                        schemes.Add(myScheme);
                        allSchemes.Nodes.Add(myScheme.name);
                    }
                }

                userControlProfile1.UpdateSchemes(schemes);
            }
        }

        public void windowsTerminalSelected(string folder, string exe)
        {
            string fqp;

            if (!string.IsNullOrEmpty(folder) && Directory.Exists(folder) && !string.IsNullOrEmpty(exe))
            {
                windowsTerminalEXE = exe;
                fqp = Path.Combine(folder, windowsTerminalEXE);

                if (File.Exists(fqp))
                {
                    windowsTerminalFQP = fqp;

                    menuLaunch.Enabled = true;
                    menuLaunch.ToolTipText = "";
                    windowsTerminalFolder = folder;

                    Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);

                    config.AppSettings.Settings.Remove("WindowsTerminalFolder");
                    config.AppSettings.Settings.Add("WindowsTerminalFolder", folder);
                    config.AppSettings.Settings.Remove("WindowsTerminalEXE");
                    config.AppSettings.Settings.Add("WindowsTerminalEXE", windowsTerminalEXE);

                    config.Save(ConfigurationSaveMode.Modified);
                }
            }
            else
            {
                menuLaunch.Enabled = false;
                menuLaunch.ToolTipText = "Set in 'Settings'";
            }
        }

        public void removeUnusedSchemesChange(bool isChecked)
        {
            removeUnusedSchemes = isChecked;

            Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);

            config.AppSettings.Settings.Remove("RemoveUnusedSchemes");
            config.AppSettings.Settings.Add("RemoveUnusedSchemes", removeUnusedSchemes.ToString());

            config.Save(ConfigurationSaveMode.Modified);
        }

        private void menuLaunch_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(windowsTerminalFQP);
        }

        public void profileUpdated(Profile profile, TreeNode treeNode)
        {
            if (treeNode != null)
            {
                treeNode.Text = profile.name;
            }

            if (!string.IsNullOrEmpty(profile.colorScheme))
            {
                var foundScheme = settings.schemes.Where(s => s.name == profile.colorScheme);

                if (foundScheme.Count() != 1)  // Add Scheme if not already present
                {
                    var scheme = schemes.Where(s => s.name == profile.colorScheme);

                    settings.schemes.Add(scheme.First());
                    //schemeNode.Nodes.Add(profile.colorScheme);
                    AddSchemeNode(schemeNode.Nodes, profile.colorScheme);
                }

                if (removeUnusedSchemes)
                {
                    RemoveUnusedSchemes();
                }

                QueueWriteToFile();
            }
            
        }

        public void AddSchemeNode(TreeNodeCollection nodes, string schemeName)
        {
            if (treeView1.InvokeRequired)
            {
                var d = new SafeCallDelegate(AddSchemeNode);
                treeView1.Invoke(d, new object[] { nodes, schemeName });
            }
            else
            {
                nodes.Add(schemeName);
            }
        }

        public void schemeUpdated()
        {
            QueueWriteToFile();
        }

        private void QueueWriteToFile()
        {
            if (!writeToFile)
            {
                writeToFile = true;
            }
        }

        private void WriteToFile(object sender, EventArgs e)
        {
            string json;

            if (writeToFile)
            {
                writeToFile = false;

                json = JsonConvert.SerializeObject(settings,
                    Formatting.Indented,
                    new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

                File.WriteAllText(fileName, json);
            }
        }

        private TreeNode FindNode(TreeNode parent, string text)
        {
            int loop;
            TreeNode myTreeNode;

            myTreeNode = null;

            loop = 0;

            while (myTreeNode == null && loop < parent.Nodes.Count)
            {
                if (parent.Nodes[loop].Text == text)
                {
                    myTreeNode = parent.Nodes[loop];
                }

                loop++;
            }

            return (myTreeNode);
        }

        private void RemoveUnusedSchemes()
        {
            TreeNode nodeToRemove;
            List<Scheme> schemesToRemove;

            schemesToRemove = new List<Scheme>();

            foreach(Scheme scheme in settings.schemes)
            {
                var profile = settings.profiles.Where(p => p.colorScheme == scheme.name);

                if (profile.Count() < 1)
                {
                    schemesToRemove.Add(scheme);
                }
            }

            foreach(Scheme scheme in schemesToRemove)
            {
                settings.schemes.Remove(scheme);

                nodeToRemove = FindNode(schemeNode, scheme.name);

                if (nodeToRemove != null )
                {
                    RemoveNode(schemeNode.Nodes, nodeToRemove);
                }
            }
        }

        public void RemoveNode(TreeNodeCollection nodes, TreeNode nodeToRemove)
        {
            if (treeView1.InvokeRequired)
            {
                var d = new SafeCallDelegateRemoveNode(RemoveNode);
                treeView1.Invoke(d, new object[] { nodes, nodeToRemove });
            }
            else
            {
                nodes.Remove(nodeToRemove);
            }
        }

        public void  addSchemeFile(string fileName)
        {
            Scheme scheme;

            using (StreamReader file = File.OpenText(fileName))
            {
                JsonSerializer serializer = new JsonSerializer();
                scheme = (Scheme)serializer.Deserialize(file, typeof(Scheme));
                schemes.Add(scheme);
                settings.schemes.Add(scheme);
            }

            userControlProfile1.UpdateSchemes(schemes);
            schemeNode.Nodes.Add(scheme.name);
        }

        public string GetSchemesFolder
        {
            get { return schemesFolder; }
        }

        private Scheme FindScheme(string schemeName)
        {
            int loop;
            Scheme tmpScheme;
            Scheme foundScheme;

            loop = 0;
            foundScheme = null;
            
            while (foundScheme == null && loop < schemes.Count)
            {
                tmpScheme = schemes[loop];

                if (tmpScheme.name == schemeName)
                {
                    foundScheme = tmpScheme;
                }

                loop++;
            }

            return (foundScheme);
        }

        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string msg;
            string fileName;
            Scheme schemeToDelete;

            msg = string.Format("Really delete '{0}'?", treeView1.SelectedNode.Text);

            var confirmDelete = MessageBox.Show(msg, "Delete Scheme?", MessageBoxButtons.YesNo);

            if (confirmDelete == DialogResult.Yes)
            {
                fileName = Path.Combine(GetSchemesFolder, string.Format("{0}.json", treeView1.SelectedNode.Text));
                File.Delete(fileName);
                schemeToDelete = FindScheme(treeView1.SelectedNode.Text);
                if (schemeToDelete != null )
                {
                    schemes.Remove(schemeToDelete);
                }

                treeView1.SelectedNode.Remove();
            }
        }

        public void SaveRotationInformation(string GUID, bool rotateImages, bool rotateSchemes, string folder, int rotateMinutes)
        {
            CustomItem item;

            item = GetCustomItemByGUID(GUID);

            if (item != null)
            {
                item.rotateImages = rotateImages;
                item.rotateSchemes = rotateSchemes;
                item.rotationFolder = folder;
                item.rotationMinutes = rotateMinutes;

                SaveCustomProfile(myCustomProfile);
            }
        }

        private void SaveCustomProfile(CustomProfile cp)
        {
            string fqp;
            string json;

            fqp = GetCustomProfilePath();

            json = JsonConvert.SerializeObject(cp,
                    Formatting.Indented,
                    new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

            File.WriteAllText(fqp, json);
        }

        private CustomProfile LoadCustomProfile()
        {
            string fqp;
            CustomProfile cp = null;

            fqp = GetCustomProfilePath();

            if ( !File.Exists(fqp))
            {
                CreateDefaultCustomProfile(fqp);
            }

            using (StreamReader file = File.OpenText(fqp))
            {
                JsonSerializer serializer = new JsonSerializer();
                cp = (CustomProfile)serializer.Deserialize(file, typeof(CustomProfile));
            }

            return (cp);
        }

        private void ReconcileCustomProfile()
        {
            CustomItem item;
            bool madeChange = false;
            List<CustomItem> deleteItems;

            // Add profiles found in settings.profiles that are not in myCustomProfile

            foreach (Profile profile in settings.profiles)
            {
                if ( GetCustomItemByGUID(profile.guid) == null )
                {
                    madeChange = true;
                    item = NewDefaultCustomItem(profile.guid);
                    myCustomProfile.items.Add(item);
                }
            }

            // Remove items in myCustomProfile that are not in settings.profiles

            deleteItems = new List<CustomItem>();

            foreach(CustomItem ci in myCustomProfile.items)
            {
                if (GetProfileByGUID(ci.guid) == null)
                {
                    madeChange = true;
                    deleteItems.Add(ci);
                }
            }

            foreach(CustomItem di in deleteItems)
            {
                myCustomProfile.items.Remove(di);
            }

            if (madeChange)
            {
                SaveCustomProfile(myCustomProfile);
            }
        }

        private CustomItem NewDefaultCustomItem(string guid)
        {
            CustomItem item;

            item = new CustomItem();

            item.guid = guid;
            item.rotateImages = false;
            item.rotateSchemes = false;
            item.rotationMinutes = 15;
            item.rotationFolder = string.Empty;

            return (item);

        }

        private void CreateDefaultCustomProfile(string fqp)
        {
            CustomItem item;
            CustomProfile cp;
            
            cp = new CustomProfile();
            cp.items = new List<CustomItem>();

            foreach(Profile profile in settings.profiles)
            {
                item = NewDefaultCustomItem(profile.guid);
                cp.items.Add(item);
            }

            SaveCustomProfile(cp);
        }

        private string GetCustomProfilePath()
        {
            string path;
            string exePath;

            exePath = System.Reflection.Assembly.GetEntryAssembly().Location;

            path = Path.Combine(Path.GetDirectoryName(exePath), "custom-profile.json");

            return (path);
        }

        public void CheckRotations(bool forceRotation)
        {
            int mod;
            Profile profile;
            bool didRotation;
            string randomImage;
            string randomScheme;

            minutesRunning++;

            foreach(CustomItem item in myCustomProfile.items)
            {
                didRotation = false;

                if ( item.rotationMinutes != null )
                {
                    mod = minutesRunning % (int)item.rotationMinutes;

                    if (forceRotation || mod == 0)
                    {
                        profile = GetProfileByGUID(item.guid);

                        if (profile != null)
                        {

                            if (item.rotateImages != null && item.rotateImages == true)
                            {
                                randomImage = GetRandomImage(item.rotationFolder);

                                if (!string.IsNullOrEmpty(randomImage) && File.Exists(randomImage))
                                {
                                    profile.backgroundImage = randomImage;

                                    if (currentDialog == Dialogs.Profile)
                                    {
                                        userControlProfile1.UpdateImageTextbox(randomImage, item.guid);
                                    }

                                    didRotation = true;
                                }

                            }

                            if (item.rotateSchemes != null && item.rotateSchemes == true)
                            {
                                randomScheme = GetRandomSchemeName();

                                profile.colorScheme = randomScheme;

                                if (currentDialog == Dialogs.Profile)
                                {
                                    userControlProfile1.UpdateSchemeCombo(randomScheme, item.guid);
                                }

                                didRotation = true;
                            }

                            if (didRotation)
                            {
                                profileUpdated(profile, null);
                            }
                        }

                    }
                }
                
            }
        }

        private string GetRandomSchemeName()
        {
            Random random;
            int randomIndex;
            string schemeName;

            schemeName = string.Empty;

            random = new Random();

            randomIndex = random.Next(0, schemes.Count() - 1);

            schemeName = schemes[randomIndex].name;

            return (schemeName);
        }

        private CustomItem GetCustomItemByGUID(string GUID)
        {
            CustomItem customItem = null;

            var customItems = myCustomProfile.items.Where(i => i.guid == GUID);

            if (customItems != null && customItems.Count() > 0)
            {
                customItem = customItems.First();
            }

            return (customItem);
        }

        private Profile GetProfileByGUID(string GUID)
        {
            Profile profile = null;

            var foundProfiles = settings.profiles.Where(p => p.guid == GUID);

            if ( foundProfiles != null && foundProfiles.Count() > 0)
            {
                profile = foundProfiles.First();
            }

            return (profile);
        }

        private string GetRandomImage(string imagePath)
        {
            Random random;
            int randomIndex;
            FileInfo[] files;
            string randomImage;
            string[] extensions;

            extensions = new string[] { ".jpg", ".gif", ".png", ".jpeg" };

            randomImage = string.Empty;

            if (!string.IsNullOrEmpty(imagePath) && Directory.Exists(imagePath))
            {
                files = new DirectoryInfo(imagePath).EnumerateFiles()
                    .Where(f => extensions.Contains(f.Extension.ToLower()))
                    .ToArray();

                random = new Random();

                randomIndex = random.Next(0, files.Length - 1);

                randomImage = files[randomIndex].FullName;
            }

            return (randomImage);
        }

        private void nextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckRotations(true);
        }

        private void menuRotatePauseStart_Click(object sender, EventArgs e)
        {
            if (pauseRotations)
            {
                pauseRotations = false;
                menuRotatePauseStart.Text = "Pause";
                myTimer.Start();
            }
            else
            {
                pauseRotations = true;
                menuRotatePauseStart.Text = "Continue";
                myTimer.Stop();
            }
        }

        public void ViewScheme(string schemeName)
        {
            int index;
            TreeNode foundScheme;
            TreeNode allSchemesNode;

            index = 0;
            foundScheme = null;
            allSchemesNode = treeView1.Nodes[1];

            while (foundScheme == null && index < allSchemesNode.Nodes.Count)
            {
                if (allSchemesNode.Nodes[index].Text == schemeName)
                {
                    foundScheme = allSchemesNode.Nodes[index];
                }

                index++;
            }

            if ( foundScheme != null )
            {
                treeView1.SelectedNode = foundScheme;
            }
        }

        private void nextToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            CheckRotations(true);
        }

        private void menuNext_Click(object sender, EventArgs e)
        {
            CheckRotations(true);
        }

        private void treeView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            TreeNode draggedNode = (TreeNode)e.Item;

            if (draggedNode.Level == 2 && draggedNode.Parent == profileNode)
            {

                DoDragDrop(e.Item, DragDropEffects.Move);
            }
        }

        private void treeView1_DragOver(object sender, DragEventArgs e)
        {
            // Retrieve the client coordinates of the mouse position.  
            Point targetPoint = treeView1.PointToClient(new Point(e.X, e.Y));

            // Select the node at the mouse position.  
            treeView1.SelectedNode = treeView1.GetNodeAt(targetPoint);

            if (treeView1.SelectedNode != null && treeView1.SelectedNode.Parent != null && treeView1.SelectedNode.Parent == profileNode)
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void treeView1_DragDrop(object sender, DragEventArgs e)
        {
            // Retrieve the client coordinates of the drop location.  
            Point targetPoint = treeView1.PointToClient(new Point(e.X, e.Y));

            // Retrieve the node at the drop location.  
            TreeNode targetNode = treeView1.GetNodeAt(targetPoint);

            // Retrieve the node that was dragged.  
            TreeNode draggedNode = (TreeNode)e.Data.GetData(typeof(TreeNode));

            if (!draggedNode.Equals(targetNode))
            {
                // If it is a move operation, remove the node from its current   
                // location and add it to the node at the drop location.  
                if (e.Effect == DragDropEffects.Move)
                {
                    draggedNode.Remove();
                    targetNode.Parent.Nodes.Insert(targetNode.Index, draggedNode);
                    ReorderProfiles(draggedNode.Index, targetNode.Index);
                }
            }
        }

        private void ReorderProfiles(int index1, int index2)
        {
            settings.profiles.Clear();

            foreach(TreeNode node in profileNode.Nodes)
            {
                settings.profiles.Add((Profile)node.Tag);
            }

            QueueWriteToFile();
        }
    }

    public class Source
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }

    public class CustomProfile
    {
        public List<CustomItem> items { get; set; }
    }

    public class CustomItem
    {
        public string guid { get; set; }
        public bool? rotateImages { get; set; }
        public int? rotationMinutes { get; set; }
        public string rotationFolder { get; set; }
        public bool? rotateSchemes { get; set; }
    }
}

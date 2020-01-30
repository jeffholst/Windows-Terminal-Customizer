using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Windows_Terminal_Customizer
{
    public partial class UserControlProfile : UserControl
    {
        Form1 _parent;
        Profile profile;
        TreeNode treeNode;
        Controls _controls;
        bool populating = false;
        private delegate void SafeCallDelegate(string text, string guid);

        public UserControlProfile()
        {
            InitializeComponent(); 
        }

        public void Setup(Form1 parent, Controls controls, Startup startup)
        {
            _parent = parent;
            _controls = controls;

            populating = true;

            PopulateCommandlineCombo();
            startup.Next();
            PopulateBackgroundImageAlignment();
            startup.Next();
            PopulateBackgroundImageStretchMode();
            startup.Next();
            PopulateRotationSchedule();
            startup.Next();
            _parent.SetComboBoxDataSource(comboBoxFontFace, _controls.profile.fontFaces);
            _parent.SetComboBoxDataSource(comboBoxFontSize, _controls.profile.fontSizes);

            populating = false;
        }

        private void PopulateCommandlineCombo()
        {
            var dataSource = new List<Source>();
            dataSource.Add(new Source() { Name = "Azure Cloud Shell", Value = "Azure" });
            dataSource.Add(new Source() { Name = "Cmd", Value = "cmd.exe" });
            dataSource.Add(new Source() { Name = "PowerShell", Value = "powershell.exe" });
            dataSource.Add(new Source() { Name = "WSL", Value = "wsl.exe" });
            comboBoxCommandLine.DataSource = dataSource;
            comboBoxCommandLine.DisplayMember = "Name";
            comboBoxCommandLine.ValueMember = "Value";
        }

        private void PopulateBackgroundImageAlignment()
        {
            var dataSource = new List<Source>();
            dataSource.Add(new Source() { Name = "center", Value = "center" });
            dataSource.Add(new Source() { Name = "left", Value = "left" });
            dataSource.Add(new Source() { Name = "top", Value = "top" });
            dataSource.Add(new Source() { Name = "right", Value = "right" });
            dataSource.Add(new Source() { Name = "bottom", Value = "bottom" });
            dataSource.Add(new Source() { Name = "topLeft", Value = "topLeft" });
            dataSource.Add(new Source() { Name = "topRight", Value = "topRight" });
            dataSource.Add(new Source() { Name = "bottomLeft", Value = "bottomLeft" });
            dataSource.Add(new Source() { Name = "bottomRight", Value = "bottomRight" });
            comboBoxBackgroundImageAlignment.DataSource = dataSource;
            comboBoxBackgroundImageAlignment.DisplayMember = "Name";
            comboBoxBackgroundImageAlignment.ValueMember = "Value";

            comboBoxBackgroundImageAlignment.SelectedItem = "center";
        }

        private void PopulateBackgroundImageStretchMode()
        {
            var dataSource = new List<Source>();
            dataSource.Add(new Source() { Name = "none", Value = "none" });
            dataSource.Add(new Source() { Name = "fill", Value = "fill" });
            dataSource.Add(new Source() { Name = "uniform", Value = "uniform" });
            dataSource.Add(new Source() { Name = "uniformToFill", Value = "uniformToFill" });
            comboBoxBackgroundImageStretchMode.DataSource = dataSource;
            comboBoxBackgroundImageStretchMode.DisplayMember = "Name";
            comboBoxBackgroundImageStretchMode.ValueMember = "Value";

            comboBoxBackgroundImageStretchMode.SelectedValue = "uniformToFill";
        }

        private void PopulateRotationSchedule()
        {
            var dataSource = new List<Source>();
            dataSource.Add(new Source() { Name = "Every Minute", Value = "1" });
            dataSource.Add(new Source() { Name = "Every 5 Minutes", Value = "5" });
            dataSource.Add(new Source() { Name = "Every 10 Minutes", Value = "10" });
            dataSource.Add(new Source() { Name = "Every 15 Minutes", Value = "15" });
            dataSource.Add(new Source() { Name = "Every 30 Minutes", Value = "30" });
            dataSource.Add(new Source() { Name = "Every Hour", Value = "60" });
            dataSource.Add(new Source() { Name = "Every 2 Hours", Value = "120" });
            dataSource.Add(new Source() { Name = "Every 4 Hours", Value = "240" });
            comboBoxRotationSchedule.DataSource = dataSource;
            comboBoxRotationSchedule.DisplayMember = "Name";
            comboBoxRotationSchedule.ValueMember = "Value";

            comboBoxRotationSchedule.SelectedValue = "15";
        }

        public void Populate(Profile profile, TreeNode selectedTreeNode, CustomItem customItem)
        {
            populating = true;

            this.profile = profile;
            treeNode = selectedTreeNode;

            textBoxGUID.Text = profile.guid;
            textBoxName.Text = profile.name;

            if (!string.IsNullOrEmpty(profile.source))
            {
                textBoxSource.Text = profile.source;
            }

            if (!string.IsNullOrEmpty(profile.commandLine))
            {
                comboBoxCommandLine.SelectedValue = profile.commandLine;
            }
            else
            {
                comboBoxCommandLine.SelectedIndex = 0;
                profile.commandLine = comboBoxCommandLine.SelectedValue.ToString();
            }

            if ( !string.IsNullOrEmpty(profile.colorScheme) )
            {
                if (comboBoxScheme.Items.Contains(profile.colorScheme))
                {
                    comboBoxScheme.SelectedItem = profile.colorScheme;
                }
                else
                {
                    // custom theme
                    comboBoxScheme.SelectedItem = null;
                }
            }
            else
            {
                // No scheme selected
                comboBoxScheme.SelectedIndex = 0;
                profile.colorScheme = comboBoxScheme.SelectedItem.ToString();
            }

            if (!string.IsNullOrEmpty(profile.backgroundImage))
            {
                if ( File.Exists(profile.backgroundImage))
                {
                    textBoxBackgroundImage.Text = profile.backgroundImage;
                }
                else
                {
                    textBoxBackgroundImage.Text = string.Empty;
                }
                
            }
            else
            {
                textBoxBackgroundImage.Text = string.Empty;
            }

            if (!string.IsNullOrEmpty(profile.backgroundImageAlignment))
            {
                comboBoxBackgroundImageAlignment.SelectedValue = profile.backgroundImageAlignment;
            }

            if (!string.IsNullOrEmpty(profile.backgroundImageStretchMode))
            {
                comboBoxBackgroundImageStretchMode.SelectedValue = profile.backgroundImageStretchMode;
            }

            if (profile.backgroundImageOpacity != null)
            {
                trackBarBackgroundImageOpacity.Value = (int)(profile.backgroundImageOpacity * 100);
                SetTrackBarImageOpacityLabel();
            }

            if (profile.acrylicOpacity != null)
            {
                trackBarBackgroundOpacity.Value = (int)(profile.acrylicOpacity * 100);
                SetTrackBarBackgroundOpacityLabel();
            }

            if (customItem != null)
            {
                checkBoxRotateImages.Checked = (customItem.rotateImages != null && customItem.rotateImages == true) ? true : false;
                checkBoxRotateSchemes.Checked = (customItem.rotateSchemes != null && customItem.rotateSchemes == true) ? true : false;
                comboBoxRotationSchedule.SelectedValue = customItem.rotationMinutes.ToString();
                textBoxRotateImageFolder.Text = customItem.rotationFolder;
            }
            else
            {
                checkBoxRotateImages.Checked = false;
                checkBoxRotateSchemes.Checked = false;
                comboBoxRotationSchedule.SelectedItem = "15";
                textBoxRotateImageFolder.Text = string.Empty;
            }

            if ( !string.IsNullOrEmpty(profile.fontFace))
            {
                comboBoxFontFace.SelectedValue = profile.fontFace;
            }
            else
            {
                comboBoxFontFace.SelectedValue = _parent.DefaultComboBoxValue;
            }

            if (profile.fontSize != null)
            {
                comboBoxFontSize.SelectedValue = profile.fontSize.ToString();
            }
            else
            {
                comboBoxFontSize.SelectedValue = _parent.DefaultComboBoxValue;
            }

            populating = false;
        }

        public void UpdateSchemeCombo(string schemeName, string guid)
        {
            populating = true;

            if (comboBoxScheme.InvokeRequired)
            {
                var d = new SafeCallDelegate(UpdateSchemeCombo);
                comboBoxScheme.Invoke(d, new object[] { schemeName, guid });
            }
            else
            {
                if (comboBoxScheme.Items.Contains(schemeName))
                {
                    comboBoxScheme.SelectedItem = schemeName;
                }
            }

            populating = false;
        }

        public void UpdateImageTextbox(string imagePath, string guid)
        {
            if (guid == textBoxGUID.Text)
            {
                populating = true;

                if (textBoxBackgroundImage.InvokeRequired)
                {
                    var d = new SafeCallDelegate(UpdateImageTextbox);
                    textBoxBackgroundImage.Invoke(d, new object[] { imagePath, guid });
                }
                else
                {
                    textBoxBackgroundImage.Text = imagePath;
                }

                populating = false;
            }
        }

        public void UpdateSchemes(TreeNode allSchemesNode)
        {
            comboBoxScheme.Items.Clear();

            foreach (TreeNode tn in allSchemesNode.Nodes)
            {
                comboBoxScheme.Items.Add(((Scheme)tn.Tag).name);
            }
        }

        private void comboBoxScheme_SelectedValueChanged(object sender, EventArgs e)
        {
            if (FormIsValid())
            {
                profile.colorScheme = comboBoxScheme.SelectedItem.ToString();

                ProfileUpdated();
            }
        }

        private bool FormIsValid()
        {
            bool isValid = true;

            if ( populating )
            {
                isValid = false;
            }

            return (isValid);
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            textBoxBackgroundImage.Text = openFileDialog1.FileName;
        }

        private void trackBarBackgroundImageOpacity_Scroll(object sender, EventArgs e)
        {
            SetTrackBarImageOpacityLabel();
            profile.backgroundImageOpacity = trackBarBackgroundImageOpacity.Value / 100.0;
            ProfileUpdated();
        }

        private void SetTrackBarImageOpacityLabel()
        {
            double myVal;

            myVal = trackBarBackgroundImageOpacity.Value / 100.0;
            labelBackgroundImageOpacity.Text = string.Format("({0:0.00})", myVal);
        }

        private void SetTrackBarBackgroundOpacityLabel()
        {
            double myVal;

            myVal = trackBarBackgroundOpacity.Value / 100.0;
            labelBackgroundOpacity.Text = string.Format("({0:0.00})", myVal);
        }

        private void buttonSelectImage_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void textBoxBackgroundImage_TextChanged(object sender, EventArgs e)
        {
            if ( string.IsNullOrEmpty(textBoxBackgroundImage.Text) || !File.Exists(textBoxBackgroundImage.Text))
            {
                profile.backgroundImage = null;
            }
            else
            {
                profile.backgroundImage = textBoxBackgroundImage.Text;
            }

            ProfileUpdated();
        }

        private void comboBoxBackgroundImageAlignment_SelectedValueChanged(object sender, EventArgs e)
        {
            if (FormIsValid())
            {
                profile.backgroundImageAlignment = comboBoxBackgroundImageAlignment.SelectedValue.ToString();

                ProfileUpdated();
            }
        }

        private void comboBoxBackgroundImageStretchMode_SelectedValueChanged(object sender, EventArgs e)
        {
            if (FormIsValid())
            {
                // JKH
                //profile.backgroundImageStretchMode = comboBoxBackgroundImageStretchMode.SelectedValue.ToString();

                ProfileUpdated();
            }
        }

        private void ProfileUpdated()
        {
            if (!populating)
            {
                _parent.profileUpdated(profile, treeNode);
            }
        }

        private void trackBarBackgroundOpacity_Scroll(object sender, EventArgs e)
        {
            double myValue;

            SetTrackBarBackgroundOpacityLabel();
            myValue = trackBarBackgroundOpacity.Value / 100.0;
            profile.acrylicOpacity = myValue;

            if (myValue >= 1.0)
            {
                profile.useAcrylic = false;
            }
            else
            {
                profile.useAcrylic = true;
            }

            ProfileUpdated();
        }

        private void buttonRotateImageFolder_Click(object sender, EventArgs e)
        {
            var result = folderBrowserDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                textBoxRotateImageFolder.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void checkBoxRotateImages_CheckedChanged(object sender, EventArgs e)
        {
            if (!populating)
            {
                CheckImageFolder();
                SaveRotationInformation();
            }
        }

        private void checkBoxRotateSchemes_CheckedChanged(object sender, EventArgs e)
        {
            if (!populating)
            {
                SaveRotationInformation();
            }
        }

        private void comboBoxRotationSchedule_SelectedValueChanged(object sender, EventArgs e)
        {
            SaveRotationInformation();
        }

        private void textBoxRotateImageFolder_TextChanged(object sender, EventArgs e)
        {
            if (!populating)
            {
                CheckImageFolder();
                SaveRotationInformation();
            }
        }

        private void CheckImageFolder()
        {
            FileInfo[] files;
            string[] extensions;

            labelImageFolderError.Visible = false;

            if (string.IsNullOrEmpty(textBoxRotateImageFolder.Text))
            {
                labelImageFolderError.Text = "Cannot be blank";
                labelImageFolderError.Visible = true;
            }
            else if (!Directory.Exists(textBoxRotateImageFolder.Text))
            {
                labelImageFolderError.Text = "Invalid directory";
                labelImageFolderError.Visible = true;
            }
            else
            {
                extensions = new string[] { ".jpg", ".gif", ".png", ".jpeg" };

                files = new DirectoryInfo(textBoxRotateImageFolder.Text).EnumerateFiles()
                        .Where(f => extensions.Contains(f.Extension.ToLower()))
                        .ToArray();

                if (files.Length < 1)
                {
                    labelImageFolderError.Text = "No .jpg, .gif, .png, or .jpeg images found";
                    labelImageFolderError.Visible = true;
                }
            }
        }

        private void SaveRotationInformation()
        {
            int minutes;

            if (Directory.Exists(textBoxRotateImageFolder.Text))
            {
                minutes = System.Convert.ToInt32(comboBoxRotationSchedule.SelectedValue.ToString());

                _parent.SaveRotationInformation(textBoxGUID.Text, checkBoxRotateImages.Checked, checkBoxRotateSchemes.Checked,
                    textBoxRotateImageFolder.Text, minutes);
            }
        }

        private void linkLabelScheme_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _parent.ViewScheme(comboBoxScheme.SelectedItem.ToString(), comboBoxFontFace, comboBoxFontSize);
        }

        private void buttonMakeDefault_Click(object sender, EventArgs e)
        {
            _parent.MakeProfileDefault(textBoxGUID.Text);
        }

        private void comboBoxCommandLine_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!populating)
            {
                profile.commandLine = comboBoxCommandLine.SelectedValue.ToString();
                ProfileUpdated();
            }
        }

        private void textBoxName_Leave(object sender, EventArgs e)
        {
            if (!populating)
            {
                profile.name = textBoxName.Text;
                ProfileUpdated();
            }
        }

        private void comboBoxFontFace_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!populating)
            {
                profile.fontFace = _parent.GetSelectedComboBoxItemString(comboBoxFontFace);
                ProfileUpdated();
            }
        }

        private void comboBoxFontSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!populating)
            {
                profile.fontSize = _parent.GetSelectedComboBoxItemInt(comboBoxFontSize);
                ProfileUpdated();
            }
        }
    }
}

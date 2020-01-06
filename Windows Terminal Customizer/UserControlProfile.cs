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
        bool populating = false;
        private delegate void SafeCallDelegate(string text);

        public UserControlProfile()
        {
            InitializeComponent();

            populating = true;
            PopulateSourceCombo();
            PopulateBackgroundImageAlignment();
            PopulateBackgroundImageStretchMode();
            PopulateRotationSchedule();

            populating = false;
        }

        public void Setup(Form1 parent)
        {
            this._parent = parent;
        }

        private void PopulateSourceCombo()
        {
            var dataSource = new List<Source>();
            dataSource.Add(new Source() { Name = "Azure", Value = "Windows.Terminal.Azure" });
            dataSource.Add(new Source() { Name = "Cmd", Value = "Windows.Terminal.Cmd" });
            dataSource.Add(new Source() { Name = "PowerShell", Value = "Windows.Terminal.PowerShell" });
            dataSource.Add(new Source() { Name = "Wsl", Value = "Windows.Terminal.Wsl" });
            comboBoxSource.DataSource = dataSource;
            comboBoxSource.DisplayMember = "Name";
            comboBoxSource.ValueMember = "Value";
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

            comboBoxSource.SelectedValue = profile.source;

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
                comboBoxScheme.SelectedItem = null;
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

            checkBoxRotateImages.Checked = customItem.rotateImages;
            comboBoxRotationSchedule.SelectedValue = customItem.rotationMinutes.ToString();
            textBoxRotateImageFolder.Text = customItem.rotationFolder;

            populating = false;
        }

        public void UpdateImageTextbox(string imagePath)
        {
            populating = true;

            if (textBoxBackgroundImage.InvokeRequired)
            {
                var d = new SafeCallDelegate(UpdateImageTextbox);
                textBoxBackgroundImage.Invoke(d, new object[] { imagePath });
            }
            else
            {
                textBoxBackgroundImage.Text = imagePath;
            }

            populating = false;
        }

        public void UpdateSchemes(List<Scheme> schemes)
        {
            comboBoxScheme.Items.Clear();

            List<Scheme> sortedSchemes = schemes.OrderBy(o => o.name).ToList();

            foreach (Scheme scheme in sortedSchemes)
            {
                comboBoxScheme.Items.Add(scheme.name);
            }
        }

        private void comboBoxScheme_SelectedValueChanged(object sender, EventArgs e)
        {
            if (FormIsValid())
            {
                profile.colorScheme = comboBoxScheme.SelectedItem.ToString();

                _parent.profileUpdated(profile, treeNode);
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
            _parent.profileUpdated(profile, treeNode);
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

            _parent.profileUpdated(profile, treeNode);
        }

        private void comboBoxBackgroundImageAlignment_SelectedValueChanged(object sender, EventArgs e)
        {
            if (FormIsValid())
            {
                profile.backgroundImageAlignment = comboBoxBackgroundImageAlignment.SelectedValue.ToString();

                _parent.profileUpdated(profile, treeNode);
            }
        }

        private void comboBoxBackgroundImageStretchMode_SelectedValueChanged(object sender, EventArgs e)
        {
            if (FormIsValid())
            {
                profile.backgroundImageStretchMode = comboBoxBackgroundImageStretchMode.SelectedValue.ToString();

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

            _parent.profileUpdated(profile, treeNode);
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
            SaveRotationInformation();
        }

        private void comboBoxRotationSchedule_SelectedValueChanged(object sender, EventArgs e)
        {
            SaveRotationInformation();
        }

        private void textBoxRotateImageFolder_TextChanged(object sender, EventArgs e)
        {
            if (!populating)
            {
                SaveRotationInformation();
            }
        }

        private void SaveRotationInformation()
        {
            int minutes;

            if (Directory.Exists(textBoxRotateImageFolder.Text))
            {
                minutes = System.Convert.ToInt32(comboBoxRotationSchedule.SelectedValue.ToString());

                _parent.SaveRotationInformation(textBoxGUID.Text, checkBoxRotateImages.Checked, 
                    textBoxRotateImageFolder.Text, minutes);
            }
        }
    }
}

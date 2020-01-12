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
    public partial class UserControlSettings : UserControl
    {
        Form1 _parent;
        string windowsTerminalFolder;

        public UserControlSettings()
        {
            InitializeComponent();
        }

        public void Setup(Form1 parent, string schemeFolder, string wtFolder, string windowsTerminalEXE, bool removeUnusedSchemes)
        {
            this._parent = parent;

            textBoxSchemeFolder.Text = schemeFolder;
            //parentSchemesFolderSelected(schemeFolder);
            windowsTerminalFolder = wtFolder;
            textBoxWindowsTerminalEXE.Text = windowsTerminalEXE;
            parentWindowsTerminalSelected(windowsTerminalFolder, windowsTerminalEXE);
            checkBoxRemoveUnusedSchemes.Checked = removeUnusedSchemes;
        }

        private void buttonSchemeFolder_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = folderBrowserDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                textBoxSchemeFolder.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void textBoxSchemeFolder_TextChanged(object sender, EventArgs e)
        {
            string msg;

            if (Directory.Exists(textBoxSchemeFolder.Text))
            {
                parentSchemesFolderSelected(textBoxSchemeFolder.Text);
            }
            else
            {
                msg = string.Format("The folder '{0}' does not exist or is not accessible.", textBoxSchemeFolder.Text);

                MessageBox.Show(msg, "Folder does not exist", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void parentSchemesFolderSelected(string folder)
        {
            //textBoxSchemeFolder.Text = folder;

            _parent.schemesFolderSelected(folder);
        }

        private void buttonWindowsTerminal_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = folderBrowserDialog2.ShowDialog();

            if (result == DialogResult.OK)
            {
                windowsTerminalFolder = folderBrowserDialog2.SelectedPath;
                textBoxWindowsTerminalFolder.Text = folderBrowserDialog2.SelectedPath;
            }
        }

        private void textBoxWindowsTerminalFolder_TextChanged(object sender, EventArgs e)
        {
            windowsTerminalFolder = textBoxWindowsTerminalFolder.Text;
            
            string msg;

            if (Directory.Exists(windowsTerminalFolder))
            {
                parentWindowsTerminalSelected(windowsTerminalFolder, textBoxWindowsTerminalEXE.Text);
            }
            else
            {
                msg = string.Format("The folder '{0}' does not exist or is not accessible.", windowsTerminalFolder);

                MessageBox.Show(msg, "Folder does not exist", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBoxWindowsTerminalEXE_TextChanged(object sender, EventArgs e)
        {
            parentWindowsTerminalSelected(windowsTerminalFolder, textBoxWindowsTerminalEXE.Text);
        }

        private void parentWindowsTerminalSelected(string folder, string exe)
        {
            textBoxWindowsTerminalFolder.Text = folder;
            _parent.windowsTerminalSelected(folder, exe);
        }

        private void checkBoxRemoveUnusedSchemes_CheckedChanged(object sender, EventArgs e)
        {
            _parent.removeUnusedSchemesChange(checkBoxRemoveUnusedSchemes.Checked);
        }
    }
}

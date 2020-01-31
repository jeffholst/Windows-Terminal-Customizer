using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Windows_Terminal_Customizer
{
    public partial class StartupForm : Form
    {
        public StartupForm()
        {
            InitializeComponent();
        }

        public void UpdateMessage(string message)
        {
            labelMessage.Text = message;
            labelMessage.Refresh();
        }

        public void UpdateProgressBar(int value)
        {
            progressBar1.Value = value;
            progressBar1.Refresh();
        }
    }
}

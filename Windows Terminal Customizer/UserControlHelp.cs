using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Windows_Terminal_Customizer
{
    public partial class UserControlHelp : UserControl
    {
        public UserControlHelp()
        {
            InitializeComponent();

            //Create a new instance in code or add via the designer
            //Set the ChromiumWebBrowser.Address property if to your Url if you use the designer.
            //webBrowser1.Url = new Uri("https://jeffholst.github.io/wtc/");
        }

        public void Populate()
        {
            webViewCompatible1.Navigate("https://jeffholst.github.io/wtc/");
        }
    }
}

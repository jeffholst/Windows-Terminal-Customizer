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
    public partial class UserControlDefault : UserControl
    {
        Form1 _parent;
        bool populating = false;

        public UserControlDefault()
        {
            InitializeComponent();
        }

        public void Setup(Form1 parent)
        {
            this._parent = parent;
        }

        public void RefreshDefaultProfileCombo(Settings settings)
        {
            populating = true;

            var dataSource = new List<Source>();

            comboBoxDefaultProfile.DataSource = null;
            comboBoxDefaultProfile.Items.Clear();

            foreach(Profile profile in settings.profiles)
            {
                dataSource.Add(new Source() { Name = profile.name, Value = profile.guid });
            }
           
            comboBoxDefaultProfile.DataSource = dataSource;
            comboBoxDefaultProfile.DisplayMember = "Name";
            comboBoxDefaultProfile.ValueMember = "Value";

            comboBoxDefaultProfile.SelectedValue = settings.defaultProfile;

            populating = false;
        }

        private void comboBoxDefaultProfile_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!populating)
            {
                _parent.MakeProfileDefault(comboBoxDefaultProfile.SelectedValue.ToString());
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;
using System.Text.RegularExpressions;

namespace Windows_Terminal_Customizer
{
    enum SchemeColors { Black, Red, Green, Yellow, Blue, Purple, Cyan, White, BrightBlack, BrightRed, 
        BrightGreen, BrightYellow, BrightBlue, BrightPurple, BrightCyan, BrightWhite, Background, Foreground};

    public partial class UserControlScheme : UserControl
    {
        Form1 _parent;
        Scheme scheme;
        TreeNode treeNode;
        Scheme savedScheme;
        bool populating = false;
        ControlGrouping activeControl;
        Dictionary<SchemeColors, ControlGrouping> myControlGrouping;

        public UserControlScheme()
        {
            InitializeComponent();
            PopulateSizeCombo();
            PopulateFontCombo();
        }

        private void PopulateSizeCombo()
        {
            var dataSource = new List<Source>();
            dataSource.Add(new Source() { Name = "8px", Value = "8px" });
            dataSource.Add(new Source() { Name = "10px", Value = "10px" });
            dataSource.Add(new Source() { Name = "12px", Value = "12px" });
            dataSource.Add(new Source() { Name = "14px", Value = "14px" });
            dataSource.Add(new Source() { Name = "18px", Value = "18px" });
            dataSource.Add(new Source() { Name = "20px", Value = "20px" });
            comboBoxSize.DataSource = dataSource;
            comboBoxSize.DisplayMember = "Name";
            comboBoxSize.ValueMember = "Value";

            comboBoxSize.SelectedIndex = 3;
        }

        private void PopulateFontCombo()
        {
            var dataSource = new List<Source>();
            dataSource.Add(new Source() { Name = "Arial", Value = "Arial" });
            dataSource.Add(new Source() { Name = "Cambria", Value = "Cambria" });
            dataSource.Add(new Source() { Name = "Georgia", Value = "Georgia" });
            dataSource.Add(new Source() { Name = "Impact", Value = "Impact" });
            dataSource.Add(new Source() { Name = "Monospace", Value = "monospace" });
            dataSource.Add(new Source() { Name = "Times", Value = "times" });

            comboBoxFont.DataSource = dataSource;
            comboBoxFont.DisplayMember = "Name";
            comboBoxFont.ValueMember = "Value";

            comboBoxFont.SelectedIndex = 0;
        }

        public void Setup(Form1 parent)
        {
            this._parent = parent;
            InitializeSchemeColors();
            PopulateSizeCombo();
        }

        private void InitializeSchemeColors()
        {
            myControlGrouping = new Dictionary<SchemeColors, ControlGrouping>();

            myControlGrouping.Add(SchemeColors.Black, new ControlGrouping() { button = buttonBlack, label = labelBlack, textBox = textBoxBlack });
            myControlGrouping.Add(SchemeColors.Red, new ControlGrouping() { button = buttonRed, label = labelRed, textBox =  textBoxRed});
            myControlGrouping.Add(SchemeColors.Green, new ControlGrouping() { button = buttonGreen, label = labelGreen, textBox = textBoxGreen});
            myControlGrouping.Add(SchemeColors.Yellow, new ControlGrouping() { button = buttonYellow, label = labelYellow, textBox = textBoxYellow});
            myControlGrouping.Add(SchemeColors.Blue, new ControlGrouping() { button = buttonBlue, label = labelBlue, textBox = textBoxBlue});
            myControlGrouping.Add(SchemeColors.Purple, new ControlGrouping() { button = buttonPurple, label = labelPurple, textBox = textBoxPurple});
            myControlGrouping.Add(SchemeColors.Cyan, new ControlGrouping() { button = buttonCyan, label = labelCyan, textBox = textBoxCyan});
            myControlGrouping.Add(SchemeColors.White, new ControlGrouping() { button = buttonWhite, label = labelWhite, textBox = textBoxWhite});
            myControlGrouping.Add(SchemeColors.BrightBlack, new ControlGrouping() { button = buttonBrightBlack, label = labelBrightBlack, textBox = textBoxBrightBlack});
            myControlGrouping.Add(SchemeColors.BrightRed, new ControlGrouping() { button = buttonBrightRed, label = labelBrightRed, textBox = textBoxBrightRed});
            myControlGrouping.Add(SchemeColors.BrightGreen, new ControlGrouping() { button = buttonBrightGreen, label = labelBrightGreen, textBox =  textBoxBrightGreen});
            myControlGrouping.Add(SchemeColors.BrightYellow, new ControlGrouping() { button = buttonBrightYellow, label = labelBrightYellow, textBox = textBoxBrightYellow});
            myControlGrouping.Add(SchemeColors.BrightBlue, new ControlGrouping() { button = buttonBrightBlue, label = labelBrightBlue, textBox = textBoxBrightBlue});
            myControlGrouping.Add(SchemeColors.BrightPurple, new ControlGrouping() { button = buttonBrightPurple, label = labelBrightPurple, textBox = textBoxBrightPurple});
            myControlGrouping.Add(SchemeColors.BrightCyan, new ControlGrouping() { button = buttonBrightCyan, label = labelBrightCyan, textBox = textBoxBrightCyan});
            myControlGrouping.Add(SchemeColors.BrightWhite, new ControlGrouping() { button = buttonBrightWhite, label = labelBrightWhite, textBox = textBoxBrightWhite});
            myControlGrouping.Add(SchemeColors.Background, new ControlGrouping() { button = buttonBackground, label = labelBackground, textBox = textBoxBackground});
            myControlGrouping.Add(SchemeColors.Foreground, new ControlGrouping() { button = buttonForeground, label = labelForeground, textBox = textBoxForeground});
        }

        public void Populate(Scheme myScheme, TreeNode selectedTreeNode)
        {
            treeNode = selectedTreeNode;

            scheme = myScheme;

            savedScheme = LoadScheme(myScheme.name); // load scheme saved on disk

            PopulateLocal(myScheme);

            UpdateResetButton();
            UpdateSaveButtons();
            UpdatePreview();
        }

        private void PopulateLocal(Scheme myScheme)
        {
            populating = true;

            textBoxName.Text = scheme.name;

            textBoxBlack.Text = scheme.black;
            buttonBlack.BackColor = System.Drawing.ColorTranslator.FromHtml(scheme.black);

            textBoxRed.Text = scheme.red;
            buttonRed.BackColor = System.Drawing.ColorTranslator.FromHtml(scheme.red);

            textBoxGreen.Text = scheme.green;
            buttonGreen.BackColor = System.Drawing.ColorTranslator.FromHtml(scheme.green);

            textBoxYellow.Text = scheme.yellow;
            buttonYellow.BackColor = System.Drawing.ColorTranslator.FromHtml(scheme.yellow);

            textBoxBlue.Text = scheme.blue;
            buttonBlue.BackColor = System.Drawing.ColorTranslator.FromHtml(scheme.blue);

            textBoxPurple.Text = scheme.purple;
            buttonPurple.BackColor = System.Drawing.ColorTranslator.FromHtml(scheme.purple);

            textBoxCyan.Text = scheme.cyan;
            buttonCyan.BackColor = System.Drawing.ColorTranslator.FromHtml(scheme.cyan);

            textBoxWhite.Text = scheme.white;
            buttonWhite.BackColor = System.Drawing.ColorTranslator.FromHtml(scheme.white);

            textBoxBrightBlack.Text = scheme.brightBlack;
            buttonBrightBlack.BackColor = System.Drawing.ColorTranslator.FromHtml(scheme.brightBlack);

            textBoxBrightRed.Text = scheme.brightRed;
            buttonBrightRed.BackColor = System.Drawing.ColorTranslator.FromHtml(scheme.brightRed);

            textBoxBrightGreen.Text = scheme.brightGreen;
            buttonBrightGreen.BackColor = System.Drawing.ColorTranslator.FromHtml(scheme.brightGreen);

            textBoxBrightYellow.Text = scheme.brightYellow;
            buttonBrightYellow.BackColor = System.Drawing.ColorTranslator.FromHtml(scheme.brightYellow);

            textBoxBrightBlue.Text = scheme.brightBlue;
            buttonBrightBlue.BackColor = System.Drawing.ColorTranslator.FromHtml(scheme.brightBlue);

            textBoxBrightPurple.Text = scheme.brightPurple;
            buttonBrightPurple.BackColor = System.Drawing.ColorTranslator.FromHtml(scheme.brightPurple);

            textBoxBrightCyan.Text = scheme.brightCyan;
            buttonBrightCyan.BackColor = System.Drawing.ColorTranslator.FromHtml(scheme.brightCyan);

            textBoxBrightWhite.Text = scheme.brightWhite;
            buttonBrightWhite.BackColor = System.Drawing.ColorTranslator.FromHtml(scheme.brightWhite);

            textBoxBackground.Text = scheme.background;
            buttonBackground.BackColor = System.Drawing.ColorTranslator.FromHtml(scheme.background);

            textBoxForeground.Text = scheme.foreground;
            buttonForeground.BackColor = System.Drawing.ColorTranslator.FromHtml(scheme.foreground);

            populating = false;
        }

        #region Change Button Color Clicks
        private void buttonBlack_Click(object sender, EventArgs e)
        {
            activeControl = myControlGrouping[SchemeColors.Black];
            SelectColor();
        }

        private void buttonRed_Click(object sender, EventArgs e)
        {
            activeControl = myControlGrouping[SchemeColors.Red];
            SelectColor();
        }

        private void buttonGreen_Click(object sender, EventArgs e)
        {
            activeControl = myControlGrouping[SchemeColors.Green];
            SelectColor();
        }

        private void buttonYellow_Click(object sender, EventArgs e)
        {
            activeControl = myControlGrouping[SchemeColors.Yellow];
            SelectColor();
        }

        private void buttonBlue_Click(object sender, EventArgs e)
        {
            activeControl = myControlGrouping[SchemeColors.Blue];
            SelectColor();
        }

        private void buttonPurple_Click(object sender, EventArgs e)
        {
            activeControl = myControlGrouping[SchemeColors.Purple];
            SelectColor();
        }

        private void buttonCyan_Click(object sender, EventArgs e)
        {
            activeControl = myControlGrouping[SchemeColors.Cyan];
            SelectColor();
        }

        private void buttonWhite_Click(object sender, EventArgs e)
        {
            activeControl = myControlGrouping[SchemeColors.White];
            SelectColor();
        }

        private void buttonBrightBlack_Click(object sender, EventArgs e)
        {
            activeControl = myControlGrouping[SchemeColors.BrightBlack];
            SelectColor();
        }

        private void buttonBrightRed_Click(object sender, EventArgs e)
        {
            activeControl = myControlGrouping[SchemeColors.BrightRed];
            SelectColor();
        }

        private void buttonBrightGreen_Click(object sender, EventArgs e)
        {
            activeControl = myControlGrouping[SchemeColors.BrightGreen];
            SelectColor();
        }

        private void buttonBrightYellow_Click(object sender, EventArgs e)
        {
            activeControl = myControlGrouping[SchemeColors.BrightYellow];
            SelectColor();
        }

        private void buttonBrightBlue_Click(object sender, EventArgs e)
        {
            activeControl = myControlGrouping[SchemeColors.BrightBlue];
            SelectColor();
        }

        private void buttonBrightPurple_Click(object sender, EventArgs e)
        {
            activeControl = myControlGrouping[SchemeColors.BrightPurple];
            SelectColor();
        }

        private void buttonBrightCyan_Click(object sender, EventArgs e)
        {
            activeControl = myControlGrouping[SchemeColors.BrightCyan];
            SelectColor();
        }

        private void buttonBrightWhite_Click(object sender, EventArgs e)
        {
            activeControl = myControlGrouping[SchemeColors.BrightWhite];
            SelectColor();
        }

        private void buttonBackground_Click(object sender, EventArgs e)
        {
            activeControl = myControlGrouping[SchemeColors.Background];
            SelectColor();
        }

        private void buttonForeground_Click(object sender, EventArgs e)
        {
            activeControl = myControlGrouping[SchemeColors.Foreground];
            SelectColor();
        }
        #endregion

        #region Textbox Changes
        private void textBoxBlack_TextChanged(object sender, EventArgs e)
        {
            activeControl = myControlGrouping[SchemeColors.Black];

            if (IsTextBoxChangeValid())
            {
                scheme.black = activeControl.textBox.Text;
                ColorChanged();
            }

            UpdateResetButton();
            UpdateSaveButtons();
        }

        private void textBoxRed_TextChanged(object sender, EventArgs e)
        {
            activeControl = myControlGrouping[SchemeColors.Red];

            if (IsTextBoxChangeValid())
            {
                scheme.red = activeControl.textBox.Text;
                ColorChanged();
            }
        }

        private void textBoxGreen_TextChanged(object sender, EventArgs e)
        {
            activeControl = myControlGrouping[SchemeColors.Green];

            if (IsTextBoxChangeValid())
            {
                scheme.green = activeControl.textBox.Text;
                ColorChanged();
            }
        }

        private void textBoxYellow_TextChanged(object sender, EventArgs e)
        {
            activeControl = myControlGrouping[SchemeColors.Yellow];

            if (IsTextBoxChangeValid())
            {
                scheme.yellow = activeControl.textBox.Text;
                ColorChanged();
            }
        }

        private void textBoxBlue_TextChanged(object sender, EventArgs e)
        {
            activeControl = myControlGrouping[SchemeColors.Blue];

            if (IsTextBoxChangeValid())
            {
                scheme.blue = activeControl.textBox.Text;
                ColorChanged();
            }
        }

        private void textBoxPurple_TextChanged(object sender, EventArgs e)
        {
            activeControl = myControlGrouping[SchemeColors.Purple];

            if (IsTextBoxChangeValid())
            {
                scheme.purple = activeControl.textBox.Text;
                ColorChanged();
            }
        }

        private void textBoxCyan_TextChanged(object sender, EventArgs e)
        {
            activeControl = myControlGrouping[SchemeColors.Cyan];

            if (IsTextBoxChangeValid())
            {
                scheme.cyan = activeControl.textBox.Text;
                ColorChanged();
            }
        }

        private void textBoxWhite_TextChanged(object sender, EventArgs e)
        {
            activeControl = myControlGrouping[SchemeColors.White];

            if (IsTextBoxChangeValid())
            {
                scheme.white = activeControl.textBox.Text;
                ColorChanged();
            }
        }

        private void textBoxBrightBlack_TextChanged(object sender, EventArgs e)
        {
            activeControl = myControlGrouping[SchemeColors.BrightBlack];

            if (IsTextBoxChangeValid())
            {
                scheme.brightBlack = activeControl.textBox.Text;
                ColorChanged();
            }
        }
        private void textBoxBrightRed_TextChanged(object sender, EventArgs e)
        {
            activeControl = myControlGrouping[SchemeColors.BrightRed];

            if (IsTextBoxChangeValid())
            {
                scheme.brightRed = activeControl.textBox.Text;
                ColorChanged();
            }
        }

        private void textBoxBrightGreen_TextChanged(object sender, EventArgs e)
        {
            activeControl = myControlGrouping[SchemeColors.BrightGreen];

            if (IsTextBoxChangeValid())
            {
                scheme.brightGreen = activeControl.textBox.Text;
                ColorChanged();
            }
        }

        private void textBoxBrightYellow_TextChanged(object sender, EventArgs e)
        {
            activeControl = myControlGrouping[SchemeColors.BrightYellow];

            if (IsTextBoxChangeValid())
            {
                scheme.brightYellow = activeControl.textBox.Text;
                ColorChanged();
            }
        }

        private void textBoxBrightBlue_TextChanged(object sender, EventArgs e)
        {
            activeControl = myControlGrouping[SchemeColors.BrightBlue];

            if (IsTextBoxChangeValid())
            {
                scheme.brightBlue = activeControl.textBox.Text;
                ColorChanged();
            }
        }
        private void textBoxBrightPurple_TextChanged(object sender, EventArgs e)
        {
            activeControl = myControlGrouping[SchemeColors.BrightPurple];

            if (IsTextBoxChangeValid())
            {
                scheme.brightPurple = activeControl.textBox.Text;
                ColorChanged();
            }
        }

        private void textBoxBrightCyan_TextChanged(object sender, EventArgs e)
        {
            activeControl = myControlGrouping[SchemeColors.BrightCyan];

            if (IsTextBoxChangeValid())
            {
                scheme.brightCyan = activeControl.textBox.Text;
                ColorChanged();
            }
        }

        private void textBoxBrightWhite_TextChanged(object sender, EventArgs e)
        {
            activeControl = myControlGrouping[SchemeColors.BrightWhite];

            if (IsTextBoxChangeValid())
            {
                scheme.brightWhite = activeControl.textBox.Text;
                ColorChanged();
            }
        }

        private void textBoxBackground_TextChanged(object sender, EventArgs e)
        {
            activeControl = myControlGrouping[SchemeColors.Background];

            if (IsTextBoxChangeValid())
            {
                scheme.background = activeControl.textBox.Text;
                ColorChanged();
            }
        }

        private void textBoxForeground_TextChanged(object sender, EventArgs e)
        {
            activeControl = myControlGrouping[SchemeColors.Foreground];

            if (IsTextBoxChangeValid())
            {
                scheme.foreground = activeControl.textBox.Text;
                ColorChanged();
            }
        }
        #endregion

        private void SelectColor()
        {
            DialogResult result;

            colorDialog1.Color = System.Drawing.ColorTranslator.FromHtml(activeControl.textBox.Text);

            result = colorDialog1.ShowDialog();

            if (result.ToString() == "OK")
            {
                activeControl.textBox.Text = string.Format("#{0}", (colorDialog1.Color.ToArgb() & 0x00FFFFFF).ToString("X6"));
            }
        }

        private void ColorChanged()
        {
            if (!populating)
            {
                _parent.schemeUpdated();
                UpdateResetButton();
                UpdateSaveButtons();
                UpdatePreview();
            }
        }

        private void UpdateSaveButtons()
        {
            if ( FormIsValid() )
            {
                buttonSaveAs.Enabled = true;

               buttonSave.Enabled = !scheme.IsEqual(savedScheme);
            }
            else
            {
                buttonSave.Enabled = buttonSaveAs.Enabled = false;
            }
        }

        private void UpdateResetButton()
        {
            if (!populating)
            {
                if ( !FormIsValid() || !scheme.IsEqual(savedScheme))
                {
                    buttonReset.Enabled = true;
                }
                else
                {
                    buttonReset.Enabled = false;
                }
            }
        }

        private bool FormIsValid()
        {
            int loop;
            SchemeColors sc;
            bool valid = true;

            if (populating)
            {
                valid = false;
            }
            else
            {
                loop = 0;

                while (valid && loop < ((SchemeColors[])Enum.GetValues(typeof(SchemeColors))).Length )
                {
                    sc = ((SchemeColors[])Enum.GetValues(typeof(SchemeColors)))[loop];
                    valid = IsColorValid(myControlGrouping[sc].textBox.Text);
                    loop++;
                }
            }

            return (valid);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            saveFileDialog1.InitialDirectory = _parent.GetSchemesFolder;
            saveFileDialog1.FileName = textBoxName.Text;
            saveFileDialog1.ShowDialog();
        }

        private void buttonSaveAs_Click(object sender, EventArgs e)
        {
            saveFileDialog1.InitialDirectory = _parent.GetSchemesFolder;
            saveFileDialog1.FileName = string.Empty;
            saveFileDialog1.ShowDialog();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string json;
            string schemeName;

            schemeName = Path.GetFileNameWithoutExtension(saveFileDialog1.FileName);

            if ( string.Compare(schemeName, textBoxName.Text, true) != 0)
            {
                // write new scheme file to disk
                scheme = (Scheme)scheme.ShallowCopy();
                scheme.name = schemeName;

                json = JsonConvert.SerializeObject(scheme, 
                    Formatting.Indented,
                    new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

                File.WriteAllText(saveFileDialog1.FileName, json);

                textBoxName.Text = schemeName;
                _parent.addSchemeFile(saveFileDialog1.FileName);
            }
            else
            {
                // overwrite existing scheme file
                json = JsonConvert.SerializeObject(scheme, 
                    Formatting.Indented,
                    new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

                File.WriteAllText(saveFileDialog1.FileName, json);
            }

            savedScheme = LoadScheme(schemeName); // load scheme saved on disk
            UpdateResetButton();
            UpdateSaveButtons();
        }
        
        private bool IsColorValid(string text)
        {
            Regex rg;
            bool okay;
            Match match;
            string pattern;

            okay = false;
            pattern = @"^#[0-9A-F]{6}$";

            rg = new Regex(pattern);

            match = Regex.Match(text, pattern, RegexOptions.IgnoreCase);

            if (!string.IsNullOrEmpty(text) && match.Success)
            {
                okay = true;
            }

            return (okay);
        }

        private bool IsTextBoxChangeValid()
        {
            bool okay;
            string withHash;

            if (!activeControl.textBox.Text.StartsWith("#"))
            {
                withHash = string.Format("#{0}", activeControl.textBox.Text);

                if (IsColorValid(withHash))
                {
                    activeControl.textBox.Text = withHash;
                }
            }

            okay = IsColorValid(activeControl.textBox.Text);

            if ( okay )
            {
                activeControl.textBox.BackColor = System.Drawing.SystemColors.Window;
                activeControl.button.BackColor = System.Drawing.ColorTranslator.FromHtml(activeControl.textBox.Text);
            }
            else
            {
                activeControl.textBox.BackColor = System.Drawing.Color.MistyRose;
            }

            return okay;
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            this.scheme.Update(savedScheme);
            PopulateLocal(savedScheme);
            ColorChanged();
            UpdateResetButton();
        }

        private Scheme LoadScheme(string name)
        {
            string fileName;
            Scheme newScheme;

            newScheme = null;
            fileName = Path.Combine(_parent.GetSchemesFolder, string.Format("{0}.json", name));

            using (StreamReader file = File.OpenText(fileName))
            {
                JsonSerializer serializer = new JsonSerializer();
                newScheme = (Scheme)serializer.Deserialize(file, typeof(Scheme));
            }

            return (newScheme);
        }

        private void comboBoxFont_SelectedValueChanged(object sender, EventArgs e)
        {
            UpdatePreview();
        }

        private void comboBoxSize_SelectedValueChanged(object sender, EventArgs e)
        {
            UpdatePreview();
        }

        private void UpdatePreview()
        {
            int rows, cols;
            string text, tmp;
            string html, style, table; ;

            string[] labels = new string[] {"Foreground", "Background", "White", "BrightWhite", "Black", "BrightBlack",
                "Purple", "BrightPurple", "Blue", "BrightBlue", "Cyan", "BrightCyan",
                "Green", "BrightGreen", "Yellow", "BrightYellow", "Red", "BrightRed"};

            html = "<html>[REPLACE_STYLE]<body class='bodyStyle'>[REPLACE_TABLE]</body></html>";

            style = string.Format(@"<style type='text/css'>
                    .bodystyle {{
                        background-color: {0};
                    }}
                    .tc0 {{
                        color: {1};
                    }}
                    .tc1 {{
                        color: {2};
                    }}
                    .tc2 {{
                        color: {3};
                    }}
                    .tc3 {{
                        color: {4};
                    }}
                    .tc4 {{
                        color: {5};
                    }}
                    .tc5 {{
                        color: {6};
                    }}
                    .tc6 {{
                        color: {7};
                    }}
                    .tc7 {{
                        color: {8};
                    }}
                    .tc8 {{
                        color: {9};
                    }}
                    .tc9 {{
                        color: {10};
                    }}
                    .tc10 {{
                        color: {11};
                    }}
                    .tc11 {{
                        color: {12};
                    }}
                    .tc12 {{
                        color: {13};
                    }}
                    .tc13 {{
                        color: {14};
                    }}
                    .tc14 {{
                        color: {15};
                    }}
                    .tc15 {{
                        color: {16};
                    }}
                    .tc16 {{
                        color: {17};
                    }}
                    .tc17 {{
                        color: {18};
                    }}
                    .cc0 {{
                        background-color: {19};
                        text-align: left;
                        padding-right: 5px;
                    }}
                    .cc1 {{
                        background-color: {20};
                    }}
                    .cc2 {{
                        background-color: {21};
                    }}
                    .cc3 {{
                        background-color: {22};
                    }}
                    .cc4 {{
                        background-color: {23};
                    }}
                    .cc5 {{
                        background-color: {24};
                    }}
                    .cc6 {{
                        background-color: {25};
                    }}
                    .cc7 {{
                        background-color: {26};
                    }}
                    .cc8 {{
                        background-color: {27};
                    }}
                    table {{
                        font-size: {28};
                        font-family: {29};
                    }}
                </style>", textBoxBackground.Text, 
                    textBoxForeground.Text, textBoxBackground.Text,
                    textBoxWhite.Text, textBoxBrightWhite.Text,
                    textBoxBlack.Text, textBoxBrightBlack.Text,
                    textBoxPurple.Text, textBoxBrightPurple.Text,
                    textBoxBlue.Text, textBoxBrightBlue.Text,
                    textBoxCyan.Text, textBoxBrightCyan.Text,
                    textBoxGreen.Text, textBoxBrightGreen.Text,
                    textBoxYellow.Text, textBoxBrightYellow.Text,
                    textBoxRed.Text, textBoxBrightRed.Text,
                    textBoxBackground.Text,
                    textBoxWhite.Text,
                    textBoxBlack.Text,
                    textBoxPurple.Text,
                    textBoxBlue.Text,
                    textBoxCyan.Text,
                    textBoxGreen.Text,
                    textBoxYellow.Text,
                    textBoxRed.Text,
                    comboBoxSize.SelectedValue,
                    comboBoxFont.SelectedValue);

            table = "<table width='100%'>";

            for (rows = 0; rows < 18; rows++)
            {
                table += string.Format("<tr class='tc{0}'>", rows);

                for (cols = 0; cols < 9; cols++)
                {
                    tmp = (cols == 0) ? labels[rows] : string.Format("{0}:{1}", rows, cols);

                    table += string.Format("<td class='cc{0}'>{1}</td>", cols, tmp);
                }
                table += "<tr>";
            }

            table += "</table>";

            html = html.Replace("[REPLACE_STYLE]", style);
            html = html.Replace("[REPLACE_TABLE]", table);

            webBrowser1.DocumentText = html;
        }
    }

    public class ControlGrouping
    {
        public TextBox textBox { get; set; }
        public Label label { get; set; }
        public Button button { get; set; }
    }
}

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
        Controls _controls;
        Scheme savedScheme;
        bool populating = false;
        ControlGrouping activeControl;
        Dictionary<SchemeColors, ControlGrouping> myControlGrouping;
        Dictionary<string, StringBuilder> previews = new Dictionary<string, StringBuilder>();

        public UserControlScheme()
        {
            InitializeComponent();
        }

        public void Setup(Form1 parent, Controls controls)
        {
            _parent = parent;
            _controls = controls;

            populating = true;

            InitializeSchemeColors();
            _parent.SetComboBoxDataSource(comboBoxSize, _controls.profile.fontSizes);
            _parent.SetComboBoxDataSource(comboBoxFont, _controls.profile.fontFaces);
            _parent.SetComboBoxDataSource(comboBoxStyle, new List<string>() { "Palette|100", "C#|PreviewCSharp.html", "HTML|PreviewHTML.html", "Lorem ipsum|200", "Code|300", "All Characters|400" });
            comboBoxStyle.SelectedValue = "100";

            populating = false;
        }

        private void InitializeSchemeColors()
        {
            myControlGrouping = new Dictionary<SchemeColors, ControlGrouping>();

            myControlGrouping.Add(SchemeColors.Black, new ControlGrouping() { button = buttonBlack, label = labelBlack, textBox = textBoxBlack });
            myControlGrouping.Add(SchemeColors.Red, new ControlGrouping() { button = buttonRed, label = labelRed, textBox = textBoxRed });
            myControlGrouping.Add(SchemeColors.Green, new ControlGrouping() { button = buttonGreen, label = labelGreen, textBox = textBoxGreen });
            myControlGrouping.Add(SchemeColors.Yellow, new ControlGrouping() { button = buttonYellow, label = labelYellow, textBox = textBoxYellow });
            myControlGrouping.Add(SchemeColors.Blue, new ControlGrouping() { button = buttonBlue, label = labelBlue, textBox = textBoxBlue });
            myControlGrouping.Add(SchemeColors.Purple, new ControlGrouping() { button = buttonPurple, label = labelPurple, textBox = textBoxPurple });
            myControlGrouping.Add(SchemeColors.Cyan, new ControlGrouping() { button = buttonCyan, label = labelCyan, textBox = textBoxCyan });
            myControlGrouping.Add(SchemeColors.White, new ControlGrouping() { button = buttonWhite, label = labelWhite, textBox = textBoxWhite });
            myControlGrouping.Add(SchemeColors.BrightBlack, new ControlGrouping() { button = buttonBrightBlack, label = labelBrightBlack, textBox = textBoxBrightBlack });
            myControlGrouping.Add(SchemeColors.BrightRed, new ControlGrouping() { button = buttonBrightRed, label = labelBrightRed, textBox = textBoxBrightRed });
            myControlGrouping.Add(SchemeColors.BrightGreen, new ControlGrouping() { button = buttonBrightGreen, label = labelBrightGreen, textBox = textBoxBrightGreen });
            myControlGrouping.Add(SchemeColors.BrightYellow, new ControlGrouping() { button = buttonBrightYellow, label = labelBrightYellow, textBox = textBoxBrightYellow });
            myControlGrouping.Add(SchemeColors.BrightBlue, new ControlGrouping() { button = buttonBrightBlue, label = labelBrightBlue, textBox = textBoxBrightBlue });
            myControlGrouping.Add(SchemeColors.BrightPurple, new ControlGrouping() { button = buttonBrightPurple, label = labelBrightPurple, textBox = textBoxBrightPurple });
            myControlGrouping.Add(SchemeColors.BrightCyan, new ControlGrouping() { button = buttonBrightCyan, label = labelBrightCyan, textBox = textBoxBrightCyan });
            myControlGrouping.Add(SchemeColors.BrightWhite, new ControlGrouping() { button = buttonBrightWhite, label = labelBrightWhite, textBox = textBoxBrightWhite });
            myControlGrouping.Add(SchemeColors.Background, new ControlGrouping() { button = buttonBackground, label = labelBackground, textBox = textBoxBackground });
            myControlGrouping.Add(SchemeColors.Foreground, new ControlGrouping() { button = buttonForeground, label = labelForeground, textBox = textBoxForeground });
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

        public void SetPreview(ComboBox cbFontFace, ComboBox cbFontSize)
        {
            comboBoxFont.SelectedValue = cbFontFace.SelectedValue;
            comboBoxSize.SelectedValue = cbFontSize.SelectedValue;
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
            if (FormIsValid())
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
                if (!FormIsValid() || !scheme.IsEqual(savedScheme))
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

                while (valid && loop < ((SchemeColors[])Enum.GetValues(typeof(SchemeColors))).Length)
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

            if (string.Compare(schemeName, textBoxName.Text, true) != 0)
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

            if (okay)
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
            if (!populating)
            {
                UpdatePreview();
            }
        }

        private void comboBoxSize_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!populating)
            {
                UpdatePreview();
            }
        }

        private void comboBoxStyle_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!populating)
            {
                UpdatePreview();
            }
        }

        private void LoadPreviewFile(string key)
        {
            String path;
            string fileContent;
            StringBuilder mySB;

            path = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Preview Files", key);

            using (StreamReader sr = new StreamReader(path))
            {
                //This allows you to do one Read operation.
                fileContent = sr.ReadToEnd();
            }

            mySB = new StringBuilder();
            mySB.Append(fileContent);

            previews.Add(key, mySB);
        }

        private void Preview(string key)
        {
            StringBuilder html;
            string replaceString;

            if (!previews.ContainsKey(key))
            {
                LoadPreviewFile(key);
            }

            html = new StringBuilder();
            html.Append(previews[key].ToString());

            html.Replace("[REPLACE_FONTSIZE]", string.Format("{0}px", comboBoxSize.SelectedValue.ToString()));
            html.Replace("[REPLACE_FONT]", comboBoxFont.SelectedValue.ToString());

            foreach (KeyValuePair<SchemeColors, ControlGrouping> control in myControlGrouping)
            {
                replaceString = string.Format("[REPLACE_{0}]", control.Key.ToString().ToUpper());
                html.Replace(replaceString, control.Value.textBox.Text);
            }

            webBrowser1.DocumentText = html.ToString();
        }

        private string GetRandomColor(Random random)
        {
            int count;
            string rval;
            int randomIndex;

            count = myControlGrouping.Count();

            randomIndex = random.Next(count);

            rval = myControlGrouping[myControlGrouping.ElementAt(randomIndex).Key].textBox.Text;

            return (rval);
        }

        private string GenerateAllCharacters(string[] colors)
        {
            char c;
            StringBuilder html;

            html = new StringBuilder();

            html.Append("<p>");

            for (int outer = 0; outer < colors.Length; outer++)
            {
                html.Append(string.Format("<span style='color: {0};'>", colors[outer]));

                for (int loop = 32; loop < 127; loop++)
                {
                    c = (char)loop;
                    html.Append(c.ToString());
                }

                html.Append("</span>");
            }

            html.Append("</p>");

            return (html.ToString());
        }

        private void AllCharacters()
        {
            string style;
            Random random;
            StringBuilder html;

            random = new Random();

            html = new StringBuilder();

            style = string.Format(@"<style type='text/css'>
                .bodystyle {{
                    background-color: {0};
                    font-size: {1};
                    font-family: {2};
                }}
                </style>", textBoxBackground.Text, comboBoxSize.SelectedValue, comboBoxFont.SelectedValue);

            html.Append("<html>[REPLACE_STYLE]<body class='bodyStyle'>");

            html.Append(GenerateAllCharacters(new string[] { textBoxWhite.Text, textBoxBrightWhite.Text }));
            html.Append(GenerateAllCharacters(new string[] { textBoxPurple.Text, textBoxBrightPurple.Text }));
            html.Append(GenerateAllCharacters(new string[] { textBoxBlue.Text, textBoxBrightBlue.Text }));
            html.Append(GenerateAllCharacters(new string[] { textBoxCyan.Text, textBoxBrightCyan.Text }));
            html.Append(GenerateAllCharacters(new string[] { textBoxGreen.Text, textBoxBrightGreen.Text }));
            html.Append(GenerateAllCharacters(new string[] { textBoxYellow.Text, textBoxBrightYellow.Text }));
            html.Append(GenerateAllCharacters(new string[] { textBoxRed.Text, textBoxBrightRed.Text }));

            html.Append("</body></html>");
            html.Replace("[REPLACE_STYLE]", style);

            webBrowser1.DocumentText = html.ToString();
        }

        private void PreviewCSharp()
        {
            string style;
            StringBuilder html;

            html = new StringBuilder();

            style = string.Format(@"<style type='text/css'>
                .bodystyle {{
                    background-color: {0};
                    font-size: {1};
                    font-family: {2};
                    color: {3};
                }}
                .c1 {{
                    color: {4};
                }}
                .c2 {{
                    color: {5};
                }}
                .c3 {{
                    color: {6};
                }}
                </style>", textBoxBackground.Text, comboBoxSize.SelectedValue, comboBoxFont.SelectedValue, 
                    textBoxForeground.Text, textBoxBlue.Text, textBoxGreen.Text, textBoxRed.Text);

            html.Append("<html>[REPLACE_STYLE]<body class='bodyStyle'>");

            html.Append(@"<span class=""c1"">using</span> System;<br/>
<span class=""c1"">public class Bubble_Sort</span><br/>
{<br/>
&nbsp;&nbsp;&nbsp;<span class=""c1"">public static void</span> <span class=""c2"">Main</span>(<span class=""c1"">string</span>[] args)<br/>
&nbsp;&nbsp;&nbsp;{<br/>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""c1"">int</span>[] a = { <span class=""c3"">3</span>, <span class=""c3"">0</span>, <span class=""c3"">2</span>, <span class=""c3"">5</span>, <span class=""c3"">-1</span>, <span class=""c3"">4</span>, <span class=""c3"">1</span> };<br/>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""c1"">int</span> t;<br/>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.<span class=""c2"">WriteLine</span>(<span class=""c2"">""Original array :""</span>);<br/>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""c1"">foreach</span> (<span class=""c1"">int</span> aa <span class=""c1"">in</span> a)<br/>           
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.<span class=""c2"">Write</span>(aa + "" "");<br/>          
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""c1"">for</span> (<span class=""c1"">int</span> p = <span class=""c3"">0</span>; p <= a.Length - <span class=""c3"">2</span>; p++)<br/>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{<br/>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""c1"">for</span> (<span class=""c1"">int</span> i = <span class=""c3"">0</span>; i <= a.Length - <span class=""c3"">2</span>; i++)<br/>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{<br/>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""c1"">if</span> (a[i] > a[i + <span class=""c3"">1</span>])<br/>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{<br/>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;t = a[i + <span class=""c3"">1</span>];<br/>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;a[i + <span class=""c3"">1</span>] = a[i];<br/>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;a[i] = t;<br/>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<br/>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<br/>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<br/>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.<span class=""c2"">WriteLine</span>(<span class=""c2"">""\n""</span>+<span class=""c2"">""Sorted array :""</span>);<br/>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""c1"">foreach</span> (<span class=""c1"">int</span> aa <span class=""c1"">in</span> a)<br/>             
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.<span class=""c2"">Write</span>(aa + "" "");<br/>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.<span class=""c2"">Write</span>(<span class=""c2"">""\n""</span>);<br/>    
&nbsp;&nbsp;&nbsp;}<br/>
}<br/></html>");
            html.Append("</body></html>");
            html.Replace("[REPLACE_STYLE]", style);

            webBrowser1.DocumentText = html.ToString();
        }

        private void PreviewLorem()
        {
            Ipsum li;
            string style;
            StringBuilder html;
            
            li = new Ipsum();
            html = new StringBuilder();

            style = string.Format(@"<style type='text/css'>
                .bodystyle {{
                    background-color: {0};
                    font-size: {1};
                    font-family: {2};
                }}
                </style>", textBoxBackground.Text, comboBoxSize.SelectedValue, comboBoxFont.SelectedValue);

            html.Append("<html>[REPLACE_STYLE]<body class='bodyStyle'>");

            html.Append(string.Format("<p><span style='color: {0};'>{1}</span><span style='color:{2};'>{3}</span></p>", 
                textBoxWhite.Text, li.GetWords(5), textBoxBrightWhite.Text, li.GetWords(5)));
            html.Append(string.Format("<p><span style='color: {0};'>{1}</span><span style='color:{2};'>{3}</span></p>",
                textBoxPurple.Text, li.GetWords(5), textBoxBrightPurple.Text, li.GetWords(5)));
            html.Append(string.Format("<p><span style='color: {0};'>{1}</span><span style='color:{2};'>{3}</span></p>",
                textBoxBlue.Text, li.GetWords(5), textBoxBrightBlue.Text, li.GetWords(5)));
            html.Append(string.Format("<p><span style='color: {0};'>{1}</span><span style='color:{2};'>{3}</span></p>",
                textBoxCyan.Text, li.GetWords(5), textBoxBrightCyan.Text, li.GetWords(5)));
            html.Append(string.Format("<p><span style='color: {0};'>{1}</span><span style='color:{2};'>{3}</span></p>",
                textBoxGreen.Text, li.GetWords(5), textBoxBrightGreen.Text, li.GetWords(5)));
            html.Append(string.Format("<p><span style='color: {0};'>{1}</span><span style='color:{2};'>{3}</span></p>",
                textBoxYellow.Text, li.GetWords(5), textBoxBrightYellow.Text, li.GetWords(5)));
            html.Append(string.Format("<p><span style='color: {0};'>{1}</span><span style='color:{2};'>{3}</span></p>",
                textBoxRed.Text, li.GetWords(5), textBoxBrightRed.Text, li.GetWords(5)));

            html.Append("</body></html>");
            html.Replace("[REPLACE_STYLE]", style);

            webBrowser1.DocumentText = html.ToString();
        }

        private void PreviewPalette()
        {
            string tmp;
            int rows, cols;
            StringBuilder html;
            string style, table;

            string[] labels = new string[] {"Foreground", "Background", "White", "BrightWhite", "Black", "BrightBlack",
                "Purple", "BrightPurple", "Blue", "BrightBlue", "Cyan", "BrightCyan",
                "Green", "BrightGreen", "Yellow", "BrightYellow", "Red", "BrightRed"};

            html = new StringBuilder();

            html.Append("<html>[REPLACE_STYLE]<body class='bodyStyle'>[REPLACE_TABLE]</body></html>");

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

            html.Replace("[REPLACE_STYLE]", style);
            html.Replace("[REPLACE_TABLE]", table);

            webBrowser1.DocumentText = html.ToString();
        }

        private void UpdatePreview()
        {
            string key;

            key = comboBoxStyle.SelectedValue.ToString();

            switch (key)
            {
                case "PreviewCSharp.html":
                case "PreviewHTML.html":
                    Preview(key);
                    break;
                case "100":
                    PreviewPalette();
                    break;
                case "200":
                    PreviewLorem();
                    break;
                case "300":
                    PreviewCSharp();
                    break;
                case "400":
                    AllCharacters();
                    break;
            }

        }
    }

    public class ControlGrouping
    {
        public TextBox textBox { get; set; }
        public Label label { get; set; }
        public Button button { get; set; }
    }

    /// <summary>
    /// Lorem Ipsum generator class for C#
    /// Courtesty Tim Trott https://lonewolfonline.net/csharp-lorem-ipsum-generator/
    /// </summary>
    public class Ipsum
    {
        private string[] words = new string[] { "consetetur", "sadipscing", "elitr", "sed", "diam", "nonumy", "eirmod",
    "tempor", "invidunt", "ut", "labore", "et", "dolore", "magna", "aliquyam", "erat", "sed", "diam", "voluptua",
    "at", "vero", "eos", "et", "accusam", "et", "justo", "duo", "dolores", "et", "ea", "rebum", "stet", "clita",
    "kasd", "gubergren", "no", "sea", "takimata", "sanctus", "est", "lorem", "ipsum", "dolor", "sit", "amet",
    "lorem", "ipsum", "dolor", "sit", "amet", "consetetur", "sadipscing", "elitr", "sed", "diam", "nonumy", "eirmod",
    "tempor", "invidunt", "ut", "labore", "et", "dolore", "magna", "aliquyam", "erat", "sed", "diam", "voluptua",
    "at", "vero", "eos", "et", "accusam", "et", "justo", "duo", "dolores", "et", "ea", "rebum", "stet", "clita",
    "kasd", "gubergren", "no", "sea", "takimata", "sanctus", "est", "lorem", "ipsum", "dolor", "sit", "amet",
    "lorem", "ipsum", "dolor", "sit", "amet", "consetetur", "sadipscing", "elitr", "sed", "diam", "nonumy", "eirmod",
    "tempor", "invidunt", "ut", "labore", "et", "dolore", "magna", "aliquyam", "erat", "sed", "diam", "voluptua",
    "at", "vero", "eos", "et", "accusam", "et", "justo", "duo", "dolores", "et", "ea", "rebum", "stet", "clita",
    "kasd", "gubergren", "no", "sea", "takimata", "sanctus", "est", "lorem", "ipsum", "dolor", "sit", "amet", "duis",
    "autem", "vel", "eum", "iriure", "dolor", "in", "hendrerit", "in", "vulputate", "velit", "esse", "molestie",
    "consequat", "vel", "illum", "dolore", "eu", "feugiat", "nulla", "facilisis", "at", "vero", "eros", "et",
    "accumsan", "et", "iusto", "odio", "dignissim", "qui", "blandit", "praesent", "luptatum", "zzril", "delenit",
    "augue", "duis", "dolore", "te", "feugait", "nulla", "facilisi", "lorem", "ipsum", "dolor", "sit", "amet",
    "consectetuer", "adipiscing", "elit", "sed", "diam", "nonummy", "nibh", "euismod", "tincidunt", "ut", "laoreet",
    "dolore", "magna", "aliquam", "erat", "volutpat", "ut", "wisi", "enim", "ad", "minim", "veniam", "quis",
    "nostrud", "exerci", "tation", "ullamcorper", "suscipit", "lobortis", "nisl", "ut", "aliquip", "ex", "ea",
    "commodo", "consequat", "duis", "autem", "vel", "eum", "iriure", "dolor", "in", "hendrerit", "in", "vulputate",
    "velit", "esse", "molestie", "consequat", "vel", "illum", "dolore", "eu", "feugiat", "nulla", "facilisis", "at",
    "vero", "eros", "et", "accumsan", "et", "iusto", "odio", "dignissim", "qui", "blandit", "praesent", "luptatum",
    "zzril", "delenit", "augue", "duis", "dolore", "te", "feugait", "nulla", "facilisi", "nam", "liber", "tempor",
    "cum", "soluta", "nobis", "eleifend", "option", "congue", "nihil", "imperdiet", "doming", "id", "quod", "mazim",
    "placerat", "facer", "possim", "assum", "lorem", "ipsum", "dolor", "sit", "amet", "consectetuer", "adipiscing",
    "elit", "sed", "diam", "nonummy", "nibh", "euismod", "tincidunt", "ut", "laoreet", "dolore", "magna", "aliquam",
    "erat", "volutpat", "ut", "wisi", "enim", "ad", "minim", "veniam", "quis", "nostrud", "exerci", "tation",
    "ullamcorper", "suscipit", "lobortis", "nisl", "ut", "aliquip", "ex", "ea", "commodo", "consequat", "duis",
    "autem", "vel", "eum", "iriure", "dolor", "in", "hendrerit", "in", "vulputate", "velit", "esse", "molestie",
    "consequat", "vel", "illum", "dolore", "eu", "feugiat", "nulla", "facilisis", "at", "vero", "eos", "et", "accusam",
    "et", "justo", "duo", "dolores", "et", "ea", "rebum", "stet", "clita", "kasd", "gubergren", "no", "sea",
    "takimata", "sanctus", "est", "lorem", "ipsum", "dolor", "sit", "amet", "lorem", "ipsum", "dolor", "sit",
    "amet", "consetetur", "sadipscing", "elitr", "sed", "diam", "nonumy", "eirmod", "tempor", "invidunt", "ut",
    "labore", "et", "dolore", "magna", "aliquyam", "erat", "sed", "diam", "voluptua", "at", "vero", "eos", "et",
    "accusam", "et", "justo", "duo", "dolores", "et", "ea", "rebum", "stet", "clita", "kasd", "gubergren", "no",
    "sea", "takimata", "sanctus", "est", "lorem", "ipsum", "dolor", "sit", "amet", "lorem", "ipsum", "dolor", "sit",
    "amet", "consetetur", "sadipscing", "elitr", "at", "accusam", "aliquyam", "diam", "diam", "dolore", "dolores",
    "duo", "eirmod", "eos", "erat", "et", "nonumy", "sed", "tempor", "et", "et", "invidunt", "justo", "labore",
    "stet", "clita", "ea", "et", "gubergren", "kasd", "magna", "no", "rebum", "sanctus", "sea", "sed", "takimata",
    "ut", "vero", "voluptua", "est", "lorem", "ipsum", "dolor", "sit", "amet", "lorem", "ipsum", "dolor", "sit",
    "amet", "consetetur", "sadipscing", "elitr", "sed", "diam", "nonumy", "eirmod", "tempor", "invidunt", "ut",
    "labore", "et", "dolore", "magna", "aliquyam", "erat", "consetetur", "sadipscing", "elitr", "sed", "diam",
    "nonumy", "eirmod", "tempor", "invidunt", "ut", "labore", "et", "dolore", "magna", "aliquyam", "erat", "sed",
    "diam", "voluptua", "at", "vero", "eos", "et", "accusam", "et", "justo", "duo", "dolores", "et", "ea",
    "rebum", "stet", "clita", "kasd", "gubergren", "no", "sea", "takimata", "sanctus", "est", "lorem", "ipsum" };

        public string GetWords(int NumWords)
        {
            StringBuilder Result = new StringBuilder();
            Result.Append("Lorem ipsum dolor sit amet");

            Random random = new Random();

            for (int i = 0; i <= NumWords; i++)
            {
                Result.Append(" " + words[random.Next(words.Length - 1)]);
            }

            Result.Append(".");
            return Result.ToString();
        }
    }
}

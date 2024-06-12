using System;
using System.IO;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Speech.Synthesis;
using Microsoft.VisualBasic;

namespace Super_Text_Editor
{
    public partial class Form1 : Form
    {
        bool isedited = false;
        string path = string.Empty;

        ToolStripMenuItem[] allMenuItems;
        ToolStripSeparator[] allSeperators;

        public Form1(string[] args)
        {
            InitializeComponent();

            if(args.Length != 0)
            {
                Content.Text = File.ReadAllText(args[0]);
                path = args[0];
                isedited = false;
            }
        }

        private void Initialize(object sender, EventArgs e)
        {
            allMenuItems = new ToolStripMenuItem[] {
                fileToolStripMenuItem,
                newWindowToolStripMenuItem,
                newToolStripMenuItem,
                openToolStripMenuItem,
                saveToolStripMenuItem,
                saveAsToolStripMenuItem,
                clearToolStripMenuItem,
                quitToolStripMenuItem,
                editToolStripMenuItem,
                undoToolStripMenuItem,
                redoToolStripMenuItem,
                copyToolStripMenuItem,
                cutToolStripMenuItem,
                pasteToolStripMenuItem,
                removeToolStripMenuItem,
                selectAllToolStripMenuItem,
                searchToolStripMenuItem,
                goToToolStripMenuItem,
                dateAndTimeToolStripMenuItem,
                programmingCodesToolStripMenuItem,
                cToolStripMenuItem,
                cToolStripMenuItem1,
                cToolStripMenuItem2,
                javaToolStripMenuItem,
                javaScriptToolStripMenuItem,
                phytonToolStripMenuItem,
                hTMLToolStripMenuItem,
                xMLToolStripMenuItem,
                structuredQueryLanguageToolStripMenuItem,
                mathematicalEquationToolStripMenuItem,
                viewToolStripMenuItem,
                fontToolStripMenuItem,
                lucidaConsole12ptRegularToolStripMenuItem,
                timesNewRoman12ptRegularToolStripMenuItem,
                microsoftYaHeiUI10ptReqularToolStripMenuItem,
                otherToolStripMenuItem,
                colorModeToolStripMenuItem,
                darkToolStripMenuItem,
                lightToolStripMenuItem,
                statusBarToolStripMenuItem,
                helpToolStripMenuItem,
                aboutTheProgramToolStripMenuItem,
                helpToolStripMenuItem1,
                escapeSituationToolStripMenuItem,
                nToolStripMenuItem,
                tToolStripMenuItem,
                rToolStripMenuItem,
                toolStripMenuItem2,
                toolStripMenuItem3,
                toolStripMenuItem4
            };
            allSeperators = new ToolStripSeparator[] {
                    toolStripSeparator4,
                    toolStripSeparator5,
                    toolStripSeparator1,
                    toolStripSeparator2,
                    toolStripSeparator3,
                    toolStripSeparator,
                    toolStripSeparator6
            };

            Settings settings = new Settings();
            settings.Load();
            Content.Font = settings.Font;
            statusBarToolStripMenuItem.Checked = settings.StatusBar;
            statusStrip1.Visible = settings.StatusBar;

            if(settings.ColorMode == "LIGHT")
            {
                Lightmode(lightToolStripMenuItem, null);
            }
            else if (settings.ColorMode == "DARK")
            {
                Darkmode(darkToolStripMenuItem, null);
            }
            else
            {
                Lightmode(lightToolStripMenuItem, null);
            }

            isedited = false;
        }

        private void IsClosing(object sender, FormClosingEventArgs e)
        {
            if (isedited)
            {
                DialogResult dr = MessageBox.Show("Do you want to save your changes?", "My Ultimate Editor", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                    Save(sender, e);
                else if (dr == DialogResult.Cancel)
                    e.Cancel = true;
            }

            Settings settings = new Settings();
            settings.Font = Content.Font;
            settings.StatusBar = statusStrip1.Visible;

            if (lightToolStripMenuItem.Checked)
                settings.ColorMode = "LIGHT";
            else if (darkToolStripMenuItem.Checked)
                settings.ColorMode = "DARK";

            settings.Save();
        }

        private void IsEditing(object sender, EventArgs e)
        {
            isedited = true;
        }

        private void ActualInformation(object sender, EventArgs e)
        {
            FullLeght.Text = "Full Lenght: " + Content.TextLength;
            CursorAt.Text = "Cursor at char: " + Content.SelectionStart + "          ";
        }

        private void NewWindow(object sender, EventArgs e)
        {
            Thread t = new Thread(new ThreadStart(() => 
            {
                Application.Run(new Form1(new string[] { }));
            }));

            t.Start();
        }

        private void New(object sender, EventArgs e)
        {
            if(isedited)
            {
                DialogResult dr = MessageBox.Show("Do you want to save your changes?", "My Ultimate Editor", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                    Save(sender, e);
                else if (dr == DialogResult.Cancel)
                    return;
            }

            SaveFileDialog sf = new SaveFileDialog();
            sf.Title = "Create new file";
            sf.Filter = "Text document |*.txt|All Files |*.*|C Source Code |*.c|C++ Source Code |*.cpp|C# Source Code |*.cs|Java Source |*.java|JavaScript |*.js|Phyton Source Code |*.py|HTML Document |*.html|XML Document |.xml|Structured Query Language Script |*.sql";
            
            if(sf.ShowDialog() == DialogResult.OK)
            {
                int pointindex = sf.FileName.LastIndexOf('.');
                string text;

                if (pointindex != -1)
                    text = ProgrammingCodes.GetByDataType(sf.FileName.Substring(pointindex));
                else
                    text = "";


                File.WriteAllText(sf.FileName, text);
                path = sf.FileName;
                Text = "My Ultimate Editor - " + Path.GetFileName(path);
                Content.Text = File.ReadAllText(sf.FileName);
                isedited = false;
            }
        }

        private void Open(object sender, EventArgs e)
        {
            if (isedited)
            {
                DialogResult dr = MessageBox.Show("Do you want to save your changes?", "My Ultimate Editor", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                    Save(sender, e);
                else if (dr == DialogResult.Cancel)
                    return;
            }

            OpenFileDialog of = new OpenFileDialog();
            of.Title = "Open a file you like";
            of.Filter = "Text document |*.txt|All Files |*.*|C Source Code |*.c|C++ Source Code |*.cpp|C# Source Code |*.cs|Java Source |*.java|JavaScript |*.js|Phyton Source Code |*.py|HTML Document |*.html|XML Document |.xml|Structured Query Language Script |*.sql";
            of.Multiselect = false;

            if(of.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Content.Text = File.ReadAllText(of.FileName);
                    path = of.FileName;
                    Text = "My Ultimate Editor - " + Path.GetFileName(path);
                    isedited = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Save(object sender, EventArgs e)
        {
            if (path == String.Empty)
            {
                SaveAs(sender, e);
                return;
            }

            try
            {
                File.WriteAllText(path, Content.Text);
                isedited = false;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveAs(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.Title = "Choose a filepath you like";
            sf.Filter = "Text document |*.txt|All Files |*.*|C Source Code |*.c|C++ Source Code |*.cpp|C# Source Code |*.cs|Java Source |*.java|JavaScript |*.js|Phyton Source Code |*.py|HTML Document |*.html|XML Document |.xml|Structured Query Language Script |*.sql";

            if(sf.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    File.WriteAllText(sf.FileName, Content.Text);
                    path = sf.FileName;
                    Text = "My Ultimate Editor - " + Path.GetFileName(path);
                    isedited = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Clear(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Do you really want to remove the complete text?", "My Ultimate Editor", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                Content.Text = "";
                IsEditing(sender, e);
            }
        }

        private void Quit(object sender, EventArgs e)
        {
            Close();
        }

        private void Undo(object sender, EventArgs e)
        {
            Content.Undo();
        }

        private void Redo(object sender, EventArgs e)
        {
            Content.Redo();
        }

        private void Copy(object sender, EventArgs e)
        {
            Content.Copy();
        }

        private void Cut(object sender, EventArgs e)
        {
            Content.Cut();
        }

        private void Paste(object sender, EventArgs e)
        {
            Content.Paste();
        }

        private void Remove(object sender, EventArgs e)
        {
            Content.SelectedText = "";
        }

        private void SelectAll(object sender, EventArgs e)
        {
            Content.SelectAll();
        }

        private void Search(object sender, EventArgs e)
        {
            try
            {
                Content.SelectionStart = Content.Find(Interaction.InputBox("Enter searching text.", "Search"));
            }
            catch
            {
                MessageBox.Show("The text was not found.", "My Ultimate Editor", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GoTo(object sender, EventArgs e)
        {
            try
            {
                Content.SelectionStart = Content.Text.IndexOf(Interaction.InputBox("Enter text you want to go to.", "Go to"));
            }
            catch
            {
                MessageBox.Show("The text was not found.", "My Ultimate Editor", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DateTime(object sender, EventArgs e)
        {
            Content.Text = Content.Text.Insert(Content.SelectionStart, System.DateTime.Now.ToString(" hh:mm:ss dd.MM.yyyy "));
        }

        private void CodeC(object sender, EventArgs e)
        {
            Content.Text = Content.Text.Insert(Content.SelectionStart, ProgrammingCodes.C);
        }

        private void CodeCPP(object sender, EventArgs e)
        {
            Content.Text = Content.Text.Insert(Content.SelectionStart, ProgrammingCodes.CPP);
        }

        private void CodeCS(object sender, EventArgs e)
        {
            Content.Text = Content.Text.Insert(Content.SelectionStart, ProgrammingCodes.CS);
        }

        private void CodeJava(object sender, EventArgs e)
        {
            Content.Text = Content.Text.Insert(Content.SelectionStart, ProgrammingCodes.JAVA);
        }

        private void CodeJS(object sender, EventArgs e)
        {
            Content.Text = Content.Text.Insert(Content.SelectionStart, ProgrammingCodes.JAVASCRIPT);
        }

        private void CodePY(object sender, EventArgs e)
        {
            Content.Text = Content.Text.Insert(Content.SelectionStart, ProgrammingCodes.PYTHON);
        }

        private void CodeHTML(object sender, EventArgs e)
        {
            Content.Text = Content.Text.Insert(Content.SelectionStart, ProgrammingCodes.HTML);
        }

        private void CodeXML(object sender, EventArgs e)
        {
            Content.Text = Content.Text.Insert(Content.SelectionStart, ProgrammingCodes.XML);
        }

        private void CodeSQL(object sender, EventArgs e)
        {
            Content.Text = Content.Text.Insert(Content.SelectionStart, ProgrammingCodes.SQL);
        }

        private void SimpleEquation(object sender, EventArgs e)
        {
            try
            {
                string expression = Interaction.InputBox("Enter a simple mathematical equation.", "My Ultimate Editor", "0");

                if(expression != string.Empty)
                {
                    double result = Convert.ToDouble(new DataTable().Compute(expression, string.Empty));
                    string resultstring = $"{expression} = {result}";
                    Content.Text = Content.Text.Insert(Content.SelectionStart, resultstring);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ScientificEquation(object sender, EventArgs e)
        {
            try
            {
                string expression = Interaction.InputBox("Enter a scientific or simple mathematical equation.", "My Ultimate Editor", "0");

                if (expression != string.Empty)
                {
                    double result = ScientificEvaluter.Evalute(expression);

                    if (result == double.NaN)
                        return;

                    string resultstring = $"{expression} = {result}";
                    Content.Text = Content.Text.Insert(Content.SelectionStart, resultstring);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EscapeSituation(object sender, EventArgs e)
        {
            string esc = ((ToolStripItem)sender).Text;

            switch(esc)
            {
                case "\\n":
                    Content.Text = Content.Text.Insert(Content.SelectionStart, "\n");
                    break;
                case "\\t":
                    Content.Text = Content.Text.Insert(Content.SelectionStart, "\t");
                    break;
                case "\\r":
                    Content.Text = Content.Text.Insert(Content.SelectionStart, "\r");
                    break;
                case "\\\"":
                    Content.Text = Content.Text.Insert(Content.SelectionStart, "\"");
                    break;
                case "\\'":
                    Content.Text = Content.Text.Insert(Content.SelectionStart, "\'");
                    break;
                case "\\\\":
                    Content.Text = Content.Text.Insert(Content.SelectionStart, "\\");
                    break;
            }
        }

        private void Read(object sender, EventArgs e)
        {
            Thread t = new Thread(new ThreadStart(
                () => {
                    SpeechSynthesizer sp = new SpeechSynthesizer();
                    sp.Rate = 3;
                    sp.Speak(Content.Text);
                }));
            t.Start();
        }

        private void LucidaConsole(object sender, EventArgs e)
        {
            Content.Font = new Font("Lucida Console", 12F, FontStyle.Regular);
        }

        private void TimesNewRoman(object sender, EventArgs e)
        {
            Content.Font = new Font("Times New Roman", 12F, FontStyle.Regular);
        }

        private void YaHeiUI(object sender, EventArgs e)
        {
            Content.Font = new Font("Microsoft YaHei UI", 10F, FontStyle.Regular);
        }

        private void OtherFont(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            if(fd.ShowDialog() == DialogResult.OK)
            {
                Content.Font = fd.Font;
            }
        }

        private void Darkmode(object sender, EventArgs e)
        {
            ColorStyles.Dark.Append(menuStrip1,
            allMenuItems,
            toolStrip1, Content, statusStrip1,
            new ToolStripStatusLabel[] { CursorAt, FullLeght },
            allSeperators);

            darkToolStripMenuItem.Checked = true;
            lightToolStripMenuItem.Checked = false;
        }

        private void Lightmode(object sender, EventArgs e)
        {
            ColorStyles.Light.Append(menuStrip1,
            allMenuItems,
            toolStrip1, Content, statusStrip1,
            new ToolStripStatusLabel[] { CursorAt, FullLeght },
            allSeperators);

            darkToolStripMenuItem.Checked = false;
            lightToolStripMenuItem.Checked = true;
        }

        private void Statusbar(object sender, EventArgs e)
        {
            ((ToolStripMenuItem)sender).Checked = !((ToolStripMenuItem)sender).Checked;
            statusStrip1.Visible = ((ToolStripMenuItem)sender).Checked;
        }

        private void About(object sender, EventArgs e)
        {
            MessageBox.Show("My Ultimate Editor 1.0\nProgrammed by Christian Schlei\n(c) 2022, Christian Schlei\nProgramming Language C# 7.0\n", "My Ultimate Editor", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Help(object sender, EventArgs e)
        {
            MessageBox.Show("Write a text you like.\nYou can use functions from the Menu Strip.\nThe Shortcuts are next to the functions", "My Ultimate Editor", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

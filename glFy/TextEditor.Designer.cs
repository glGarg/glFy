using System.IO;
using System.Windows.Forms;

namespace glFy
{
    partial class TextEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MenuStrip menuStrip = null;
        private System.Windows.Forms.ToolStripMenuItem file = null;
        private System.Windows.Forms.ToolStripDropDown fileDropDown = null;
        private System.Windows.Forms.ToolStripMenuItem open = null;
        private System.Windows.Forms.ToolStripMenuItem save = null;
        private System.Windows.Forms.ToolStripMenuItem exit = null;
        private System.Windows.Forms.OpenFileDialog openFileDialog = null;
        private System.Windows.Forms.SaveFileDialog saveFileDialog = null;
        private ScintillaNET.Scintilla scintilla = null;
        private string fileLocation = null;
        private bool updated = false;
        private bool textChanged = false;

        public string FileLocation
        {
            get
            {
                return fileLocation;
            }
        }

        public bool Updated
        {
            get
            {
                if (updated == true)
                {
                    updated = false;
                    return true;
                }

                return false;
            }
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Text = "TextEditor";
            this.MinimumSize = new System.Drawing.Size(400, 500);
            this.SuspendLayout();

            openFileDialog = new System.Windows.Forms.OpenFileDialog();
            openFileDialog.Filter = "Shader Files|*.glsl;*.frag";

            open = new System.Windows.Forms.ToolStripMenuItem();
            open.Text = "Open    Ctrl-O";
            open.Click += (delegate (object sender, System.EventArgs e) 
            {
                OpenFile();
            });

            saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            saveFileDialog.Filter = "Shader Files|*.glsl;*.frag";

            save = new System.Windows.Forms.ToolStripMenuItem();
            save.Text = "Save      Ctrl-S";
            save.Click += (delegate (object sender, System.EventArgs e)
            {
                SaveFile();
            });

            exit = new System.Windows.Forms.ToolStripMenuItem();
            exit.Text = "Exit             Esc";
            exit.Click += Exit_Click;

            fileDropDown = new System.Windows.Forms.ToolStripDropDown();
            fileDropDown.Items.Add(open);
            fileDropDown.Items.Add(save);
            fileDropDown.Items.Add(exit);

            file = new System.Windows.Forms.ToolStripMenuItem();
            file.Text = "File";
            file.DropDown = fileDropDown;

            menuStrip = new System.Windows.Forms.MenuStrip();
            menuStrip.Items.Add(file);
            menuStrip.KeyDown += MenuStrip_KeyDown;

            scintilla = new ScintillaNET.Scintilla();
            scintilla.ConfigurationManager.Language = "cpp";
            scintilla.Font = new System.Drawing.Font("Consolas", 10f, System.Drawing.FontStyle.Regular);
            scintilla.Size = new System.Drawing.Size(this.Size.Width - 20, this.Size.Height - menuStrip.Size.Height - 43);
            scintilla.MinimumSize = scintilla.Size;
            scintilla.Location = new System.Drawing.Point(0, menuStrip.Size.Height);
            scintilla.Margins[0].Width = 16 + 8 * scintilla.Lines.Count.ToString().Length;
            scintilla.RawText = System.Text.Encoding.ASCII.GetBytes(
                "#version 430" + System.Environment.NewLine +
                "in vec2 fPos;" + System.Environment.NewLine + System.Environment.NewLine +
                "// Provided Uniforms" + System.Environment.NewLine +
                "uniform float time;" + System.Environment.NewLine
            );

            scintilla.TextChanged += (delegate (object sender, System.EventArgs e)
            {
                scintilla.Margins[0].Width = 16 + 8 * scintilla.Lines.Count.ToString().Length;
                textChanged = true;
            });
            scintilla.KeyDown += (delegate (object sender, System.Windows.Forms.KeyEventArgs e)
            {
                if (e.KeyCode == System.Windows.Forms.Keys.Escape)
                {
                    Exit_Click(sender, e);
                }

                if (e.KeyCode == System.Windows.Forms.Keys.ControlKey)
                {
                    this.ActiveControl = menuStrip;
                }
            });

            this.SizeChanged += (delegate (object sender, System.EventArgs e)
            {
                scintilla.Size = new System.Drawing.Size(this.Size.Width - 20, this.Size.Height - menuStrip.Size.Height - 43);
            });
            this.Controls.Add(menuStrip);
            this.Controls.Add(scintilla);
            this.SizeChanged += TextEditor_SizeChanged;

            this.ResumeLayout();
        }

        public bool CloseEditor()
        {
            // ask user if they need to save
            if (textChanged)
            {
                System.Windows.Forms.DialogResult result = System.Windows.Forms.MessageBox.Show("Save chages?", "Save Changes",
                                                                                                System.Windows.Forms.MessageBoxButtons.YesNoCancel,
                                                                                                System.Windows.Forms.MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (SaveFile())
                    {
                        System.Windows.Forms.Application.Exit();
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (result == DialogResult.No)
                {
                    textChanged = false;
                    System.Windows.Forms.Application.Exit();
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        private void Exit_Click(object sender, System.EventArgs e)
        {
            if (CloseEditor())
            {
                Application.Exit();
            }
        }

        private void MenuStrip_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.Modifiers == System.Windows.Forms.Keys.Control)
            {
                if (e.KeyCode == System.Windows.Forms.Keys.O)
                {
                    OpenFile();
                }
                else if (e.KeyCode == System.Windows.Forms.Keys.S)
                {
                    SaveFile();
                }
            }

            this.ActiveControl = scintilla;
        }

        private void OpenFile()
        {
            if (textChanged)
            {
                System.Windows.Forms.DialogResult result = System.Windows.Forms.MessageBox.Show("Save chages?", "Save Changes",
                                                                                        System.Windows.Forms.MessageBoxButtons.YesNoCancel,
                                                                                        System.Windows.Forms.MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (!SaveFile())
                    {
                        return;
                    }
                }
                else if (result == DialogResult.Cancel)
                {
                    return;
                }
            }

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                fileLocation = openFileDialog.FileName;
                scintilla.RawText = File.ReadAllBytes(fileLocation);
                updated = true;
                textChanged = false;
            }
        }

        private bool SaveFile()
        {
            if (null == fileLocation)
            {
                if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    // write file at this location with given name
                    fileLocation = saveFileDialog.FileName;
                    WriteTextToFile(fileLocation);
                    return true;
                }
            }
            else
            {
                // use saved name
                WriteTextToFile(fileLocation);
                return true;
            }

            return false;
        }

        private void WriteTextToFile(string filepath)
        {
            using (StreamWriter sw = File.CreateText(filepath))
            {
                sw.Write(scintilla.Text);
            }
            updated = true;
            textChanged = false;
        }

        private void TextEditor_SizeChanged(object sender, System.EventArgs e)
        {
            scintilla.Size = new System.Drawing.Size(this.Size.Width - 20, this.Size.Height - menuStrip.Size.Height - 43);
        }
    }
}

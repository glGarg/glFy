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
        private System.Windows.Forms.OpenFileDialog openFileDialog = null;
        private System.Windows.Forms.SaveFileDialog saveFileDialog = null;
        private ScintillaNET.Scintilla scintilla = null;
        private string fileLocation = null;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Text = "TextEditor";
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.SuspendLayout();

            openFileDialog = new System.Windows.Forms.OpenFileDialog();
            openFileDialog.Filter = "Shader Files|*.glsl;*.frag";

            open = new System.Windows.Forms.ToolStripMenuItem();
            open.Text = "Open";
            open.Click += (delegate (object sender, System.EventArgs e) 
            {
                if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    // open text in textbox
                }
            });

            saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            saveFileDialog.Filter = "Shader Files|*.glsl;*.frag";

            fileDropDown = new System.Windows.Forms.ToolStripDropDown();
            fileDropDown.Items.Add(open);

            file = new System.Windows.Forms.ToolStripMenuItem();
            file.Text = "File";
            file.DropDown = fileDropDown;

            menuStrip = new System.Windows.Forms.MenuStrip();
            menuStrip.Items.Add(file);

            scintilla = new ScintillaNET.Scintilla();
            scintilla.ConfigurationManager.Language = "cpp";
            scintilla.Font = new System.Drawing.Font("Consolas", 10f, System.Drawing.FontStyle.Regular);
            scintilla.Size = new System.Drawing.Size(this.Size.Width - 20, this.Size.Height - menuStrip.Size.Height - 43);
            scintilla.MinimumSize = scintilla.Size;
            scintilla.Location = new System.Drawing.Point(0, menuStrip.Size.Height);
            scintilla.Margins[0].Width = 16 + 8 * scintilla.Lines.Count.ToString().Length;
            scintilla.TextChanged += (delegate (object sender, System.EventArgs e)
            {
                scintilla.Margins[0].Width = 16 + 8 * scintilla.Lines.Count.ToString().Length;
            });
            scintilla.KeyDown += (delegate (object sender, System.Windows.Forms.KeyEventArgs e)
            {
                if (e.KeyCode == System.Windows.Forms.Keys.ControlKey)
                {
                    this.ActiveControl = null;
                }
            });

            this.KeyDown += TextEditor_KeyDown;
            this.Controls.Add(menuStrip);
            this.Controls.Add(scintilla);
            this.SizeChanged += TextEditor_SizeChanged;

            this.ResumeLayout();
        }

        private void TextEditor_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.Modifiers == System.Windows.Forms.Keys.Control)
            {
                if (e.KeyCode == System.Windows.Forms.Keys.O)
                {
                    if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        fileLocation = openFileDialog.FileName;
                    }
                }
                else if (e.KeyCode == System.Windows.Forms.Keys.S)
                {
                    if (null == fileLocation)
                    {
                        if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            // write file at this location with given name
                            fileLocation = saveFileDialog.FileName;
                        }
                    }
                    else
                    {
                        // use saved name
                    }
                }
            }

            this.ActiveControl = scintilla;
        }

        private void TextEditor_SizeChanged(object sender, System.EventArgs e)
        {
            scintilla.Size = new System.Drawing.Size(this.Size.Width - 20, this.Size.Height - menuStrip.Size.Height - 43);
        }

        #endregion
    }
}
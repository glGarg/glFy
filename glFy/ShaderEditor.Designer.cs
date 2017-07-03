using System.Windows.Forms;

namespace glFy
{
    partial class ShaderEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private TextEditor textEditor = null;
        private PreviewPanel panel = null;

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

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (!textEditor.CloseEditor())
            {
                e.Cancel = true;
                return;
            }
            base.OnFormClosing(e);
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Text = "ShaderEditor";
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.SuspendLayout();

            textEditor = new TextEditor();

            panel = new PreviewPanel(textEditor);
            panel.Location = new System.Drawing.Point(400, 0);

            this.SizeChanged += (delegate (object sender, System.EventArgs e)
            {
                panel.Location = new System.Drawing.Point(this.Size.Width / 2, 0);
                panel.Size = new System.Drawing.Size(this.Size.Width/2, this.Size.Height);
                textEditor.Size = panel.Size;
            });

            this.Controls.Add(textEditor);
            this.Controls.Add(panel);
            this.ActiveControl = textEditor;
            this.ResumeLayout();
        }
    }
}
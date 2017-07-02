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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Text = "ShaderEditor";
            this.Size = new System.Drawing.Size(800, 500);
            this.SuspendLayout();

            panel = new PreviewPanel();
            panel.Location = new System.Drawing.Point(400, 0);

            textEditor = new TextEditor();

            this.Controls.Add(panel);
            this.Controls.Add(textEditor);

            this.ResumeLayout();
        }

        #endregion
    }
}
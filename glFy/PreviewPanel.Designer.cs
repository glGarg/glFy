using System;
using OpenTK.Graphics.OpenGL;

namespace glFy
{
    partial class PreviewPanel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private OpenTK.GLControl control = null;
        private Scene preview = null;
        private VertexBuffer vertexBuffer = null;
        private VertexArray vertexArray = null;
        private System.Windows.Forms.Timer timer = null;

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
            this.Text = "PreviewPanel";
            this.Size = new System.Drawing.Size(400, 500);

            control = new OpenTK.GLControl();
            control.Size = this.Size;
            control.MinimumSize = this.Size;
            control.Resize += Control_Resize;
            control.Paint += Control_Paint;
            control.MakeCurrent();

            float[,] position = new float[6, 2]{
                { -1,    1 },
                {  1,   -1 },
                { -1,   -1 },
                {  1,    1 },
                {  1,   -1 },
                { -1,    1 }
            };

            Shader fragment = new Shader("../../../assets/fragment.glsl", ShaderType.FragmentShader);
            Shader vertex = new Shader("../../../assets/vertex.glsl", ShaderType.VertexShader);
            preview = new Scene(new Shader[] { fragment, vertex });

            vertexBuffer = new VertexBuffer(position);
            vertexArray = new VertexArray();

            vertexArray.Bind();
            vertexBuffer.Bind();
            vertexBuffer.BufferData();
            GL.VertexAttribPointer(0, 2, VertexAttribPointerType.Float, false, 0, 0);
            GL.EnableVertexAttribArray(0);
            GL.BindVertexArray(0);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);

            this.Controls.Add(control);
            
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 50;
            timer.Tick += (delegate (object sender, EventArgs t)
            {
                Control_Paint(this, null);
            });
            timer.Start();
        }
        
        private void Control_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            GL.ClearColor(System.Drawing.Color.SkyBlue);
            GL.Clear(ClearBufferMask.ColorBufferBit);
            preview.Use();
            vertexBuffer.Bind();
            vertexArray.Bind();
            GL.DrawArrays(PrimitiveType.TriangleStrip, 0, vertexBuffer.VertexCount());
            GL.BindVertexArray(0);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.UseProgram(0);
            control.SwapBuffers();
        }

        private void Control_Resize(object sender, EventArgs e)
        {
            GL.ClearColor(System.Drawing.Color.Crimson);
            GL.Viewport(0, 0, this.Width, this.Height);
        }
        
        #endregion
    }
}
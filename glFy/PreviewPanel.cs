using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenTK.Graphics.OpenGL;
using OpenTK;

namespace glFy
{
    public partial class PreviewPanel : UserControl
    {
        public PreviewPanel(TextEditor textEditor)
        {
            editor = textEditor;
            InitializeComponent();
        }
    }
}

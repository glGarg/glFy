using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;

namespace glFy
{
    class VertexArray
    {
        int id;
        public VertexArray()
        {
            id = GL.GenVertexArray();
        }

        public void Bind()
        {
            GL.BindVertexArray(id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;

namespace glFy
{
    class Scene
    {
        private int program;

        public int Program
        {
            get
            {
                return program;
            }
        }

        public Scene(Shader[] shaders)
        {
            program = GL.CreateProgram();

            foreach (Shader shader in shaders)
            {
                GL.AttachShader(program, shader.Id);
            }

            GL.LinkProgram(program);
        }

        public void Use()
        {
            GL.UseProgram(program);
        }
    }
}

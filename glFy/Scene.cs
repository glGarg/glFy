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
        private int id;

        public int Id
        {
            get
            {
                return id;
            }
        }

        public Scene(Shader[] shaders)
        {
            id = GL.CreateProgram();
            AttachShaders(shaders);
        }

        public void AttachShaders(Shader[] shaders)
        {
            foreach (Shader shader in shaders)
            {
                GL.AttachShader(id, shader.Id);
            }

            GL.LinkProgram(id);

            foreach (Shader shader in shaders)
            {
                GL.DetachShader(id, shader.Id);
            }
        }

        public void Use()
        {
            GL.UseProgram(id);
        }
    }
}

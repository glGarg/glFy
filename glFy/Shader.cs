using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using OpenTK.Graphics.OpenGL;

namespace glFy
{
    class Shader
    {
        private int id;
        private ShaderType type;
        public ShaderType Type
        {
            get
            {
                return type;
            }
        }

        public int Id
        {
            get
            {
                return id;
            }
        }

        public Shader(string filepath, ShaderType shaderType)
        {
            type = shaderType;
            id = GL.CreateShader(type);

            if (!File.Exists(filepath))
            {
                // Invalid filepath
            }
            else
            {
                GL.ShaderSource(id, File.ReadAllText(filepath));
                GL.CompileShader(id);
            }   
        }
    }
}

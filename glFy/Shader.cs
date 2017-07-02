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
        private static string defaultFragmentShader = "../../../assets/fragment.glsl";
        private static string defaultVertexShader = "../../../assets/vertex.glsl";
        private bool valid = false;
        private int id;
        private ShaderType type;
        private string fileLocation = null;

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

        public bool Valid
        {
            get
            {
                return valid;
            }
        }

        public string FileLocation
        {
            get
            {
                return fileLocation;
            }
            set
            {
                fileLocation = value;
            }
        }

        public Shader(string filepath, ShaderType shaderType)
        {
            type = shaderType;
            id = GL.CreateShader(type);

            if (!File.Exists(filepath))
            {
                fileLocation = shaderType == ShaderType.FragmentShader ? defaultFragmentShader : defaultVertexShader;
                GL.ShaderSource(id, File.ReadAllText(fileLocation));
                GL.CompileShader(id);
                // Invalid filepath
            }
            else
            {
                fileLocation = filepath;
                Compile();
            }
        }

        public void Compile()
        {
            GL.ShaderSource(id, File.ReadAllText(fileLocation));
            GL.CompileShader(id);
            int[] status = new int[1] { 0 };
            GL.GetShader(id, OpenTK.Graphics.OpenGL.ShaderParameter.CompileStatus, status);
            valid = status[0] != 0;
        }
    }
}

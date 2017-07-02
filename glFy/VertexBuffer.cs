using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using OpenTK.Graphics.OpenGL;

namespace glFy
{
    class VertexBuffer
    {
        private float[,] points;
        private int id;
        GCHandle handle;
        public IntPtr pointer;

        public int Id
        {
            get
            {
                return id;
            }
        }

        public VertexBuffer(float[,] vertices)
        {
            id = GL.GenBuffer();
            points = vertices;
            GCHandle handle = GCHandle.Alloc(vertices, GCHandleType.Pinned);
            pointer = handle.AddrOfPinnedObject();
        }
        
        ~VertexBuffer()
        {
            if (handle.IsAllocated)
            {
                handle.Free();
            }
        }

        public void Bind()
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, id);
        }

        public int VertexCount()
        {
            return points.GetLength(0);
        }

        public int VertexSize()
        {
            return points.GetLength(1);
        }

        public void BufferData()
        {
            GL.BufferData(BufferTarget.ArrayBuffer, (IntPtr)(sizeof(float) * VertexCount() * VertexSize()), pointer, BufferUsageHint.StreamDraw);
        }
    }
}

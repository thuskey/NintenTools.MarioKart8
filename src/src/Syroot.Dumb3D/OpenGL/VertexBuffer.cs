using System.Runtime.InteropServices;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;

namespace Syroot.Dumb3D.OpenGL
{
    /// <summary>
    /// Represents a vertex buffer object (VBO) which stores vertices in GPU memory.
    /// </summary>
    public class VertexBuffer : OpenGLObject
    {
        // ---- CONSTRUCTORS & DESTRUCTOR ------------------------------------------------------------------------------

        public VertexBuffer(IGraphicsContext context) : base(context)
        {
        }

        // ---- METHODS (PUBLIC) ---------------------------------------------------------------------------------------

        /// <summary>
        /// Copies the given <paramref name="data"/> into the vertex buffer object.
        /// </summary>
        /// <typeparam name="T">The type of the data, which must be a structure.</typeparam>
        /// <param name="data">The data to copy into the vertex buffer.</param>
        /// <param name="usageHint">The usage type of the data.</param>
        public void SetData<T>(T[] data, BufferUsageHint usageHint)
            where T : struct
        {
            ValidateContext();
            GL.NamedBufferData(ID, Marshal.SizeOf<T>() * data.Length, data, usageHint);
        }

        // ---- METHODS (PROTECTED) ------------------------------------------------------------------------------------

        protected override int Generate()
        {
            ValidateContext();
            return GL.GenBuffer();
        }

        protected override void Delete()
        {
            ValidateContext();
            GL.DeleteBuffer(ID);
        }
    }
}

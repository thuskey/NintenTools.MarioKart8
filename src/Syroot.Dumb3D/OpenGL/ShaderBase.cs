using System;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;

namespace Syroot.Dumb3D.OpenGL
{
    public abstract class ShaderBase : OpenGLObject
    {
        // ---- CONSTRUCTORS & DESTRUCTOR ------------------------------------------------------------------------------

        public ShaderBase(ShaderType type, IGraphicsContext context) : base(context)
        {
            Type = type;
        }

        // ---- PROPERTIES ---------------------------------------------------------------------------------------------

        protected ShaderType Type
        {
            get;
            private set;
        }

        // ---- METHODS (PUBLIC) ---------------------------------------------------------------------------------------

        public void SetSource(string source)
        {
            ValidateContext();
            GL.ShaderSource(ID, source);
        }

        public void Compile()
        {
            ValidateContext();
            GL.CompileShader(ID);
#if DEBUG
            // Check if the compilation was successful, and if not, throw an exception with the error messages.
            int success;
            GL.GetShader(ID, ShaderParameter.CompileStatus, out success);
            if (success == 0)
            {
                string infoLog = GL.GetShaderInfoLog(ID);
                throw new InvalidOperationException(infoLog);
            }
#endif
        }

        // ---- METHODS (PROTECTED) ------------------------------------------------------------------------------------

        protected override int Generate()
        {
            ValidateContext();
            return GL.CreateShader(Type);
        }

        protected override void Delete()
        {
            ValidateContext();
            GL.DeleteShader(ID);
        }
    }
}

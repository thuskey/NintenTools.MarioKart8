using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;

namespace Syroot.Dumb3D.OpenGL
{
    public class VertexShader : ShaderBase
    {
        // ---- CONSTRUCTORS & DESTRUCTOR ------------------------------------------------------------------------------

        public VertexShader(IGraphicsContext context) : base(ShaderType.VertexShader, context)
        {
        }
    }
}

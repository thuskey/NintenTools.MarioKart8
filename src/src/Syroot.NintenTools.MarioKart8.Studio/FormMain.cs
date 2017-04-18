using System;
using System.Drawing;
using System.Windows.Forms;
using OpenTK.Graphics.OpenGL4;
using Syroot.Dumb3D;
using Syroot.Dumb3D.OpenGL;

namespace Syroot.NintenTools.MarioKart8.Studio
{
    /// <summary>
    /// Represents the main window of the application.
    /// </summary>
    public partial class FormMain : Form
    {
        // ---- MEMBERS ------------------------------------------------------------------------------------------------

        private ResourceLoader _resources;

        private float[] vertices = {
             0.0f,  0.5f, 0f,
             0.5f, -0.5f, 0f,
            -0.5f,  0.5f, 0f
        };

        // ---- CONSTRUCTORS & DESTRUCTOR ------------------------------------------------------------------------------

        /// <summary>
        /// Initializes a new instance of the <see cref="FormMain"/> class.
        /// </summary>
        public FormMain()
        {
            InitializeComponent();
            _resources = new ResourceLoader();
        }

        // ---- EVENTHANDLERS ------------------------------------------------------------------------------------------

        private void _dumbControl_Load(object sender, EventArgs e)
        {
            GL.ClearColor(Color.CornflowerBlue);

            VertexBuffer vertexBuffer = new VertexBuffer(_dumbControl.Context);
            vertexBuffer.SetData(vertices, BufferUsageHint.StaticDraw);

            VertexShader vertexShader = new VertexShader(_dumbControl.Context);
        }

        private void _dumbControl_Render(object sender, EventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);
            _dumbControl.SwapBuffers();
        }
    }
}

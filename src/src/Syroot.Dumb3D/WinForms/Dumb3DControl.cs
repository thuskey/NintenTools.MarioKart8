using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using OpenTK;

namespace Syroot.Dumb3D.WinForms
{
    public class Dumb3DControl : GLControl
    {
        // ---- CONSTRUCTORS & DESTRUCTOR ------------------------------------------------------------------------------

        public Dumb3DControl()
        {
        }

        // ---- PROPERTIES ---------------------------------------------------------------------------------------------

        [DefaultValue(typeof(Color), "Black")]
        public override Color BackColor
        {
            get { return base.BackColor; }
            set { base.BackColor = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether <see cref="Redraw()"/> is called immediately when the control was
        /// resized.
        /// </summary>
        [DefaultValue(false)]
        public bool RedrawOnResize { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether <see cref="Redraw()"/> is called continuously while the application
        /// is idle. It is recommended to enable <see cref="VSync"/> with it.
        /// </summary>
        [DefaultValue(false)]
        public bool RedrawContinuously { get; set; }

        // ---- EVENTS -------------------------------------------------------------------------------------------------

        /// <summary>
        /// Occurs when the contents have to be rendered.
        /// </summary>
        public event EventHandler Render;

        // ---- METHODS (PUBLIC) ---------------------------------------------------------------------------------------

        /// <summary>
        /// Causes <see cref="Render"/> to be raised.
        /// </summary>
        public void Redraw()
        {
            Render?.Invoke(this, EventArgs.Empty);
        }

        // ---- METHODS (PROTECTED) ------------------------------------------------------------------------------------

        protected override void OnLoad(EventArgs e)
        {
            if (!DesignMode)
            {
                Application.Idle += Application_Idle;
            }

            base.OnLoad(e);
        }

        protected override void OnResize(EventArgs e)
        {
            if (RedrawOnResize)
            {
                Redraw();
            }
            base.OnResize(e);
        }

        protected void OnRender(EventArgs e)
        {
            Render?.Invoke(this, e);
        }

        // ---- EVENTHANDLERS ------------------------------------------------------------------------------------------

        private void Application_Idle(object sender, EventArgs e)
        {
            while (RedrawContinuously && IsIdle)
            {
                Redraw();
            }
        }
    }
}

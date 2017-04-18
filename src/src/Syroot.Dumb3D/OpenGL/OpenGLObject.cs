using System;
using System.Diagnostics;
using OpenTK.Graphics;

namespace Syroot.Dumb3D.OpenGL
{
    public abstract class OpenGLObject : IDisposable
    {
        // ---- MEMBERS ------------------------------------------------------------------------------------------------

        private bool _isDisposed;

        // ---- CONSTRUCTORS & DESTRUCTOR ------------------------------------------------------------------------------

        public OpenGLObject(IGraphicsContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");
            if (context != GraphicsContext.CurrentContext)
                throw new InvalidOperationException("Context must be current.");

            Context = context;
            ID = Generate();
        }

        // ---- PROPERTIES ---------------------------------------------------------------------------------------------

        /// <summary>
        /// Gets the <see cref="IGraphicsContext"/> for which this object has been created.
        /// </summary>
        protected IGraphicsContext Context { get; private set; }

        /// <summary>
        /// Gets the OpenGL object ID.
        /// </summary>
        protected int ID { get; private set; }

        // ---- METHODS (PUBLIC) ---------------------------------------------------------------------------------------

        public void Dispose()
        {
            Dispose(true);
        }

        // ---- METHODS (PROTECTED) ------------------------------------------------------------------------------------

        /// <summary>
        /// Generates the OpenGL object and returns its ID.
        /// </summary>
        /// <returns>The ID of the generated OpenGL object.</returns>
        protected abstract int Generate();

        /// <summary>
        /// Deletes the OpenGL object.
        /// </summary>
        protected abstract void Delete();

        [Conditional("DEBUG")]
        protected void ValidateContext()
        {
            Debug.Assert(Context == GraphicsContext.CurrentContext, "Invalid GraphicsContext.");
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                {
                    ValidateContext();
                    Delete();
                }

                _isDisposed = true;
            }
        }
    }
}

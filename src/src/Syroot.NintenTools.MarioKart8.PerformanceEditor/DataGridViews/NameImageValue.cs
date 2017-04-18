using System.Drawing;

namespace Syroot.NintenTools.MarioKart8.PerformanceEditor
{
    /// <summary>
    /// Represents a class holding an <see cref="Image"/> and <see cref="string"/> instance.
    /// </summary>
    public class NameImageValue
    {
        // ---- CONSTRUCTORS & DESTRUCTOR ------------------------------------------------------------------------------

        internal NameImageValue(string name, Image image = null)
        {
            Name = name;
            Image = image;
        }

        // ---- PROPERTIES ---------------------------------------------------------------------------------------------

        internal Image Image
        {
            get;
            private set;
        }

        internal string Name
        {
            get;
            private set;
        }
    }
}

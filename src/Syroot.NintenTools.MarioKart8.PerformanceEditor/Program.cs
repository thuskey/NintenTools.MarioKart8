using System;
using System.Windows.Forms;

namespace Syroot.NintenTools.MarioKart8.PerformanceEditor
{
    /// <summary>
    /// The main class of the program.
    /// </summary>
    internal static class Program
    {
        // ---- METHODS (PRIVATE) --------------------------------------------------------------------------------------

        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ToolStripManager.Renderer = new VisualStudioRenderer();
            Application.Run(new FormMain());
        }
    }
}

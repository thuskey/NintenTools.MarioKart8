using System;
using System.Windows.Forms;

namespace Syroot.NintenTools.MarioKart8.Studio
{
    /// <summary>
    /// Represents the main class of the application containing the program entry point.
    /// </summary>
    internal static class Program
    {
        // ---- METHODS (PRIVATE) --------------------------------------------------------------------------------------

        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
    }
}

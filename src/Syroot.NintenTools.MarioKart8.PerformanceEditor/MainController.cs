using System;
using Syroot.NintenTools.MarioKart8.BinData.Performance;

namespace Syroot.NintenTools.MarioKart8.PerformanceEditor
{
    /// <summary>
    /// Represents the main application controller.
    /// </summary>
    internal class MainController
    {
        // ---- EVENTS -------------------------------------------------------------------------------------------------

        internal event EventHandler FileChanged;

        // ---- PROPERTIES ---------------------------------------------------------------------------------------------

        internal string FileName
        {
            get;
            private set;
        }

        internal PerformanceData PerformanceData
        {
            get;
            private set;
        }

        // ---- METHODS (INTERNAL) -------------------------------------------------------------------------------------

        internal void NewFile()
        {
        }

        internal void OpenFile(string fileName)
        {
            PerformanceData = new PerformanceData(fileName);
            FileChanged?.Invoke(this, EventArgs.Empty);
        }

        internal void SaveFile(string fileName)
        {
            //PerformanceData = new PerformanceData(fileName);
            //FileChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}

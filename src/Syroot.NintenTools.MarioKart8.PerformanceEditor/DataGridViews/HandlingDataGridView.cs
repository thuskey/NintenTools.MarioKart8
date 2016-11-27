using System;
using Syroot.NintenTools.MarioKart8.BinData.Performance;

namespace Syroot.NintenTools.MarioKart8.PerformanceEditor
{
    /// <summary>
    /// Represents a <see cref="PointRankDataGridView"/> displaying PRTL, PRTW or PRTA values.
    /// </summary>
    public class HandlingDataGridView : PointRankDataGridView
    {
        // ---- MEMBERS ------------------------------------------------------------------------------------------------

        private HandlingStat[] _data;

        // ---- CONSTRUCTORS & DESTRUCTOR ------------------------------------------------------------------------------

        public HandlingDataGridView()
        {
            AddColumn("Auto-Drift");
            AddColumn("Drift");
            AddColumn("Normal");
            AddPointRankRows();
        }

        // ---- PROPERTIES ---------------------------------------------------------------------------------------------

        public string SectionToDisplay
        {
            get;
            set;
        }

        // ---- METHODS (PROTECTED) ------------------------------------------------------------------------------------

        protected override void FillData()
        {
            _data = GetSectionToDisplay();
            for (int y = 0; y < _data.Length; y++)
            {
                HandlingStat handlingStat = _data[y];
                for (int x = 0; x < 3; x++)
                {
                    Rows[y].Cells[x].Value = handlingStat[x];
                }
            }
        }

        protected override void SetDataValue(int row, int column, float value)
        {
            _data[row][column] = value;
        }

        private HandlingStat[] GetSectionToDisplay()
        {
            switch (SectionToDisplay)
            {
                case "PRTL":
                    return PerformanceData.HandlingGroundStats;
                case "PRTW":
                    return PerformanceData.HandlingWaterStats;
                case "PRTA":
                    return PerformanceData.HandlingAntigravityStats;
                default:
                    throw new InvalidOperationException();
            }
        }
    }
}

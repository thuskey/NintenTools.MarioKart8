using System;
using Syroot.NintenTools.MarioKart8.BinData.Performance;

namespace Syroot.NintenTools.MarioKart8.PerformanceEditor
{
    /// <summary>
    /// Represents a <see cref="PointRankDataGridView"/> displaying PRSL, PRSW or PRSA values.
    /// </summary>
    public class SpeedDataGridView : PointRankDataGridView
    {
        // ---- MEMBERS ------------------------------------------------------------------------------------------------

        private SpeedStat[] _data;

        // ---- CONSTRUCTORS & DESTRUCTOR ------------------------------------------------------------------------------

        public SpeedDataGridView()
        {
            AddColumn("No Coins");
            AddColumn("10 Coins");
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
                SpeedStat speedStat = _data[y];
                for (int x = 0; x < 2; x++)
                {
                    Rows[y].Cells[x].Value = speedStat[x];
                }
            }
        }

        protected override void SetDataValue(int row, int column, float value)
        {
            _data[row][column] = value;
        }

        private SpeedStat[] GetSectionToDisplay()
        {
            switch (SectionToDisplay)
            {
                case "PRSL":
                    return PerformanceData.SpeedGroundStats;
                case "PRSW":
                    return PerformanceData.SpeedWaterStats;
                case "PRSA":
                    return PerformanceData.SpeedAntigravityStats;
                default:
                    throw new InvalidOperationException();
            }
        }
    }
}

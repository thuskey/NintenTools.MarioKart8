using Syroot.NintenTools.MarioKart8.BinData.Performance;

namespace Syroot.NintenTools.MarioKart8.PerformanceEditor
{
    /// <summary>
    /// Represents a <see cref="PointRankDataGridView"/> displaying PRTG values.
    /// </summary>
    public class HandlingAirDataGridView : PointRankDataGridView
    {
        // ---- MEMBERS ------------------------------------------------------------------------------------------------

        private HandlingAirStat[] _data;

        // ---- CONSTRUCTORS & DESTRUCTOR ------------------------------------------------------------------------------

        public HandlingAirDataGridView()
        {
            AddColumn("Auto-Drift");
            AddColumn("Drift");
            AddPointRankRows();
        }

        // ---- METHODS (PROTECTED) ------------------------------------------------------------------------------------

        protected override void FillData()
        {
            _data = PerformanceData.HandlingAirStats;
            for (int y = 0; y < _data.Length; y++)
            {
                HandlingAirStat handlingAirStat = _data[y];
                for (int x = 0; x < 2; x++)
                {
                    Rows[y].Cells[x].Value = handlingAirStat[x];
                }
            }
        }

        protected override void SetDataValue(int row, int column, float value)
        {
            _data[row][column] = value;
        }
    }
}

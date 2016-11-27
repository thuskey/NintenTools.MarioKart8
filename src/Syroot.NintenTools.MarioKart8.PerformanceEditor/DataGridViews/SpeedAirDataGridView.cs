using Syroot.NintenTools.MarioKart8.BinData.Performance;

namespace Syroot.NintenTools.MarioKart8.PerformanceEditor
{
    /// <summary>
    /// Represents a <see cref="PointRankDataGridView"/> displaying PRSG values.
    /// </summary>
    public class SpeedAirDataGridView : PointRankDataGridView
    {
        // ---- MEMBERS ------------------------------------------------------------------------------------------------

        private SpeedAirStat[] _data;

        // ---- CONSTRUCTORS & DESTRUCTOR ------------------------------------------------------------------------------

        public SpeedAirDataGridView()
        {
            AddColumn("Any Coins");
            AddPointRankRows();
        }

        // ---- METHODS (PROTECTED) ------------------------------------------------------------------------------------

        protected override void FillData()
        {
            _data = PerformanceData.SpeedAirStats;
            for (int y = 0; y < _data.Length; y++)
            {
                SpeedAirStat speedAirStat = _data[y];
                Rows[y].Cells[0].Value = speedAirStat.Speed;
            }
        }

        protected override void SetDataValue(int row, int column, float value)
        {
            _data[row][column] = value;
        }
    }
}

using Syroot.NintenTools.MarioKart8.BinData.Performance;

namespace Syroot.NintenTools.MarioKart8.PerformanceEditor
{
    /// <summary>
    /// Represents a <see cref="PointRankDataGridView"/> displaying PRAC values.
    /// </summary>
    public class PhysicsAccelerationDataGridView : PointRankDataGridView
    {
        // ---- MEMBERS ------------------------------------------------------------------------------------------------

        private AccelerationStat[] _data;

        // ---- CONSTRUCTORS & DESTRUCTOR ------------------------------------------------------------------------------

        public PhysicsAccelerationDataGridView()
        {
            AddColumn("First Value");
            AddColumn("Second Value");
            AddPointRankRows();
        }

        // ---- METHODS (PROTECTED) ------------------------------------------------------------------------------------

        protected override void FillData()
        {
            _data = PerformanceData.AccelerationStats;
            for (int y = 0; y < _data.Length; y++)
            {
                AccelerationStat accelerationStat = _data[y];
                for (int x = 0; x < 2; x++)
                {
                    Rows[y].Cells[x].Value = accelerationStat[x];
                }
            }
        }

        protected override void SetDataValue(int row, int column, float value)
        {
            _data[row][column] = value;
        }
    }
}

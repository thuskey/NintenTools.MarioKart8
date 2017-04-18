using Syroot.NintenTools.MarioKart8.BinData.Performance;

namespace Syroot.NintenTools.MarioKart8.PerformanceEditor
{
    /// <summary>
    /// Represents a <see cref="PointRankDataGridView"/> displaying PRWG values.
    /// </summary>
    public class PhysicsWeightDataGridView : PointRankDataGridView
    {
        // ---- MEMBERS ------------------------------------------------------------------------------------------------

        private WeightStat[] _data;

        // ---- CONSTRUCTORS & DESTRUCTOR ------------------------------------------------------------------------------

        public PhysicsWeightDataGridView()
        {
            AddColumn("Bumped");
            AddColumn("Bumping");
            AddColumn("Unknown");
            AddPointRankRows();
        }

        // ---- METHODS (PROTECTED) ------------------------------------------------------------------------------------

        protected override void FillData()
        {
            _data = PerformanceData.WeightStats;
            for (int y = 0; y < _data.Length; y++)
            {
                WeightStat weightStat = _data[y];
                for (int x = 0; x < 3; x++)
                {
                    Rows[y].Cells[x].Value = weightStat[x];
                }
            }
        }

        protected override void SetDataValue(int row, int column, float value)
        {
            _data[row][column] = value;
        }
    }
}

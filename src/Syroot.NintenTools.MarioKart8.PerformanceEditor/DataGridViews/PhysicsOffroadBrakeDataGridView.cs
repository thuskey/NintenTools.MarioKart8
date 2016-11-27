using Syroot.NintenTools.MarioKart8.BinData.Performance;

namespace Syroot.NintenTools.MarioKart8.PerformanceEditor
{
    /// <summary>
    /// Represents a <see cref="PointRankDataGridView"/> displaying PROF values.
    /// </summary>
    public class PhysicsOffroadBrakeDataGridView : PointRankDataGridView
    {
        // ---- MEMBERS ------------------------------------------------------------------------------------------------

        private OffroadStat[] _data;

        // ---- CONSTRUCTORS & DESTRUCTOR ------------------------------------------------------------------------------

        public PhysicsOffroadBrakeDataGridView()
        {
            AddColumn("Light Dirt");
            AddColumn("Medium Dirt");
            AddColumn("Heavy Dirt");
            AddColumn("Light Sand");
            AddColumn("Medium Sand");
            AddColumn("Heavy Sand");
            AddColumn("Light Ice");
            AddColumn("Medium Ice");
            AddColumn("Heavy Ice");
            AddPointRankRows();
        }

        // ---- METHODS (PROTECTED) ------------------------------------------------------------------------------------

        protected override void FillData()
        {
            _data = PerformanceData.OffroadStats;
            for (int y = 0; y < _data.Length; y++)
            {
                OffroadStat offroadStat = _data[y];
                for (int x = 0; x < 9; x++)
                {
                    Rows[y].Cells[x].Value = offroadStat[x];
                }
            }
        }

        protected override void SetDataValue(int row, int column, float value)
        {
            _data[row][column] = value;
        }
    }
}

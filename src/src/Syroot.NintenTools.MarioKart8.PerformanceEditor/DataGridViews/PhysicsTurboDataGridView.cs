using Syroot.NintenTools.MarioKart8.BinData.Performance;

namespace Syroot.NintenTools.MarioKart8.PerformanceEditor
{
    /// <summary>
    /// Represents a <see cref="PointRankIntegerDataGridView"/> displaying PRMT values.
    /// </summary>
    public class PhysicsTurboDataGridView : PointRankIntegerDataGridView
    {
        // ---- MEMBERS ------------------------------------------------------------------------------------------------

        private TurboStat[] _data;

        // ---- CONSTRUCTORS & DESTRUCTOR ------------------------------------------------------------------------------

        public PhysicsTurboDataGridView()
        {
            AddColumn("Mini-Turbo");
            AddColumn("Super-Turbo");
            AddPointRankRows();
        }

        // ---- METHODS (PROTECTED) ------------------------------------------------------------------------------------

        protected override void FillData()
        {
            _data = PerformanceData.TurboStats;
            for (int y = 0; y < _data.Length; y++)
            {
                TurboStat turboStat = _data[y];
                for (int x = 0; x < 2; x++)
                {
                    Rows[y].Cells[x].Value = turboStat[x];
                }
            }
        }

        protected override void SetDataValue(int row, int column, int value)
        {
            _data[row][column] = value;
        }
    }
}

using Syroot.NintenTools.MarioKart8.BinData.Performance;

namespace Syroot.NintenTools.MarioKart8.PerformanceEditor
{
    /// <summary>
    /// Represents a <see cref="PointRankDataGridView"/> displaying PRON values.
    /// </summary>
    public class PhysicsOuterslipDataGridView : PointRankDataGridView
    {
        // ---- MEMBERS ------------------------------------------------------------------------------------------------

        private OuterslipStat[] _data;

        // ---- CONSTRUCTORS & DESTRUCTOR ------------------------------------------------------------------------------

        public PhysicsOuterslipDataGridView()
        {
            AddColumn("Factor");
            AddPointRankRows();
        }

        // ---- METHODS (PROTECTED) ------------------------------------------------------------------------------------

        protected override void FillData()
        {
            _data = PerformanceData.OuterslipStats;
            for (int y = 0; y < _data.Length; y++)
            {
                OuterslipStat outerslipStat = _data[y];
                Rows[y].Cells[0].Value = outerslipStat.Factor;
            }
        }

        protected override void SetDataValue(int row, int column, float value)
        {
            _data[row][column] = value;
        }
    }
}

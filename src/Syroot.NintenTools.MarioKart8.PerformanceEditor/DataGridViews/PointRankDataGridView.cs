namespace Syroot.NintenTools.MarioKart8.PerformanceEditor
{
    /// <summary>
    /// Represents a <see cref="FloatSectionDataGridView"/> which has 21 rows to display the values for each point rank.
    /// </summary>
    public class PointRankDataGridView : FloatSectionDataGridView
    {
        // ---- METHODS (PROTECTED) ------------------------------------------------------------------------------------

        protected void AddPointRankRows()
        {
            // Add 20 rows for the valid point ranks.
            for (int i = 0; i < 20; i++)
            {
                Rows.Add();
                Rows[i].HeaderCell.Value = $"{i + 1} Point{(i == 0 ? null : "s")}";
            }
            // Add the additional row for invalid point ranks.
            Rows.Add();
            Rows[20].HeaderCell.Value = "Fallback";
        }
    }
}

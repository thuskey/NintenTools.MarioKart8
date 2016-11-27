using Syroot.NintenTools.MarioKart8.BinData.Performance;

namespace Syroot.NintenTools.MarioKart8.PerformanceEditor
{
    /// <summary>
    /// Represents a <see cref="PointRankDataGridView"/> displaying PTWG values.
    /// </summary>
    public class PointGlidersDataGridView : PointSetDataGridView
    {
        // ---- METHODS (PROTECTED) ------------------------------------------------------------------------------------

        protected override string[] GetRowNames()
        {
            return new string[]
            {
                "Super Glider",
                "Cloud Glider",
                "Wario Wing",
                "Waddle Wing",
                "Peach Parasol",
                "Parachute",
                "Parafoil",
                "Flower Glider",
                "Bowser Kite",
                "Plane Glider",
                "MKTV Parafoil",
                "Gold Glider",
                "Hylian Kite",
                "Paper Glider"
            };
        }

        protected override PointSetCollection GetSectionToDisplay()
        {
            return PerformanceData.GliderPoints;
        }
    }
}

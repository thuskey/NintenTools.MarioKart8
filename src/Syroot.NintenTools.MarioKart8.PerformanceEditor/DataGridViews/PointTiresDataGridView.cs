using Syroot.NintenTools.MarioKart8.BinData.Performance;

namespace Syroot.NintenTools.MarioKart8.PerformanceEditor
{
    /// <summary>
    /// Represents a <see cref="PointRankDataGridView"/> displaying PTTR values.
    /// </summary>
    public class PointTiresDataGridView : PointSetDataGridView
    {
        // ---- METHODS (PROTECTED) ------------------------------------------------------------------------------------

        protected override string[] GetRowNames()
        {
            return new string[]
            {
                "Standard",
                "Monster",
                "Roller",
                "Slim",
                "Slick",
                "Metal",
                "Button",
                "Off-Road",
                "Sponge",
                "Wood",
                "Cushion",
                "Blue Standard",
                "Hot Monster",
                "Azure Roller",
                "Crimson Slim",
                "Cyber Slick",
                "Retro Off-Road",
                "Gold Tires",
                "GLA Tires",
                "Triforce Tires",
                "Leaf Tires"
            };
        }

        protected override PointSetCollection GetSectionToDisplay()
        {
            return PerformanceData.TirePoints;
        }
    }
}

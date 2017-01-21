using Syroot.NintenTools.MarioKart8.BinData.Performance;
using Syroot.NintenTools.MarioKart8.PerformanceEditor.Properties;

namespace Syroot.NintenTools.MarioKart8.PerformanceEditor
{
    /// <summary>
    /// Represents a <see cref="PointRankDataGridView"/> displaying PTTR values.
    /// </summary>
    public class PointTiresDataGridView : PointSetDataGridView
    {
        // ---- METHODS (PROTECTED) ------------------------------------------------------------------------------------

        protected override NameImageValue[] GetRowNameImageValues()
        {
            return new NameImageValue[]
            {
                new NameImageValue("Standard", Resources.Tire_Standard),
                new NameImageValue("Monster", Resources.Tire_Monster),
                new NameImageValue("Roller", Resources.Tire_Roller),
                new NameImageValue("Slim", Resources.Tire_Slim),
                new NameImageValue("Slick", Resources.Tire_Slick),
                new NameImageValue("Metal", Resources.Tire_Metal),
                new NameImageValue("Button", Resources.Tire_Button),
                new NameImageValue("Off-Road", Resources.Tire_OffRoad),
                new NameImageValue("Sponge", Resources.Tire_Sponge),
                new NameImageValue("Wood", Resources.Tire_Wood),
                new NameImageValue("Cushion", Resources.Tire_Cushion),
                new NameImageValue("Blue Standard", Resources.Tire_BlueStandard),
                new NameImageValue("Hot Monster", Resources.Tire_HotMonster),
                new NameImageValue("Azure Roller", Resources.Tire_AzureRoller),
                new NameImageValue("Crimson Slim", Resources.Tire_CrimsonSlim),
                new NameImageValue("Cyber Slick", Resources.Tire_CyberSlick),
                new NameImageValue("Retro Off-Road", Resources.Tire_RetroOffRoad),
                new NameImageValue("Gold Tires", Resources.Tire_GoldTires),
                new NameImageValue("GLA Tires", Resources.Tire_GlaTires),
                new NameImageValue("Triforce Tires", Resources.Tire_TriforceTires),
                new NameImageValue("Leaf Tires", Resources.Tire_LeafTires)
            };
        }

        protected override PointSetCollection GetSectionToDisplay()
        {
            return PerformanceData.TirePoints;
        }
    }
}

using Syroot.NintenTools.MarioKart8.BinData.Performance;
using Syroot.NintenTools.MarioKart8.PerformanceEditor.Properties;

namespace Syroot.NintenTools.MarioKart8.PerformanceEditor
{
    /// <summary>
    /// Represents a <see cref="PointRankDataGridView"/> displaying PTWG values.
    /// </summary>
    public class PointGlidersDataGridView : PointSetDataGridView
    {
        // ---- METHODS (PROTECTED) ------------------------------------------------------------------------------------

        protected override NameImageValue[] GetRowNameImageValues()
        {
            return new NameImageValue[]
            {
                new NameImageValue("Super Glider", Resources.Glider_SuperGlider),
                new NameImageValue("Cloud Glider", Resources.Glider_CloudGlider),
                new NameImageValue("Wario Wing", Resources.Glider_WarioWing),
                new NameImageValue("Waddle Wing", Resources.Glider_WaddleWing),
                new NameImageValue("Peach Parasol", Resources.Glider_PeachParasol),
                new NameImageValue("Parachute", Resources.Glider_Parachute),
                new NameImageValue("Parafoil", Resources.Glider_Parafoil),
                new NameImageValue("Flower Glider", Resources.Glider_FlowerGlider),
                new NameImageValue("Bowser Kite", Resources.Glider_BowserKite),
                new NameImageValue("Plane Glider", Resources.Glider_PlaneGlider),
                new NameImageValue("MKTV Parafoil", Resources.Glider_MktvParafoil),
                new NameImageValue("Gold Glider", Resources.Glider_GoldGlider),
                new NameImageValue("Hylian Kite", Resources.Glider_HylianKite),
                new NameImageValue("Paper Glider", Resources.Glider_PaperGlider)
            };
        }

        protected override PointSetCollection GetSectionToDisplay()
        {
            return PerformanceData.GliderPoints;
        }
    }
}

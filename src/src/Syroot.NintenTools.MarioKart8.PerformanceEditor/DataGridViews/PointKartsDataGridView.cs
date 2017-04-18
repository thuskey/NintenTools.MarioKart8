using Syroot.NintenTools.MarioKart8.BinData.Performance;
using Syroot.NintenTools.MarioKart8.PerformanceEditor.Properties;

namespace Syroot.NintenTools.MarioKart8.PerformanceEditor
{
    /// <summary>
    /// Represents a <see cref="PointRankDataGridView"/> displaying PTBD values.
    /// </summary>
    public class PointKartsDataGridView : PointSetDataGridView
    {
        // ---- METHODS (PROTECTED) ------------------------------------------------------------------------------------

        protected override NameImageValue[] GetRowNameImageValues()
        {
            return new NameImageValue[]
            {
                new NameImageValue("Standard Kart", Resources.Kart_StandardKart),
                new NameImageValue("Pipe Frame", Resources.Kart_PipeFrame),
                new NameImageValue("Mach 8", Resources.Kart_Mach8),
                new NameImageValue("Steel Driver", Resources.Kart_SteelDriver),
                new NameImageValue("Cat Cruiser", Resources.Kart_CatCruiser),
                new NameImageValue("Circuit Special", Resources.Kart_CircuitSpecial),
                new NameImageValue("Tri-Speeder", Resources.Kart_TriSpeeder),
                new NameImageValue("Badwagon", Resources.Kart_Badwagon),
                new NameImageValue("Prancer", Resources.Kart_Prancer),
                new NameImageValue("Biddybuggy", Resources.Kart_Biddybuggy),
                new NameImageValue("Landship", Resources.Kart_Landship),
                new NameImageValue("Sneeker", Resources.Kart_Sneeker),
                new NameImageValue("Sports Coupe", Resources.Kart_SportsCoupe),
                new NameImageValue("Gold Standard", Resources.Kart_GoldStandard),
                new NameImageValue("Standard Bike", Resources.Kart_StandardBike),
                new NameImageValue("Comet", Resources.Kart_Comet),
                new NameImageValue("Sport Bike", Resources.Kart_SportBike),
                new NameImageValue("The Duke", Resources.Kart_TheDuke),
                new NameImageValue("Flame Rider", Resources.Kart_FlameRider),
                new NameImageValue("Varmint", Resources.Kart_Varmint),
                new NameImageValue("Mr. Scooty", Resources.Kart_MrScooty),
                new NameImageValue("Jet Bike", Resources.Kart_JetBike),
                new NameImageValue("Yoshi Bike", Resources.Kart_YoshiBike),
                new NameImageValue("Standard ATV", Resources.Kart_StandardAtv),
                new NameImageValue("Wild Wiggler", Resources.Kart_WildWiggler),
                new NameImageValue("Teddy Buggy", Resources.Kart_TeddyBuggy),
                new NameImageValue("GLA", Resources.Kart_Gla),
                new NameImageValue("W 25 Silver Arrow", Resources.Kart_W25SilverArrow),
                new NameImageValue("300 SL Roadster", Resources.Kart_300SlRoadster),
                new NameImageValue("Blue Falcon", Resources.Kart_BlueFalcon),
                new NameImageValue("Tanooki Kart", Resources.Kart_TanookiKart),
                new NameImageValue("B Dasher", Resources.Kart_BDasher),
                new NameImageValue("Master Cycle", Resources.Kart_MasterCycle),
                new NameImageValue("Unused 1", Resources.Kart_Unknown),
                new NameImageValue("Unused 2", Resources.Kart_Unknown),
                new NameImageValue("Streetle", Resources.Kart_Streetle),
                new NameImageValue("P-Wing", Resources.Kart_PWing),
                new NameImageValue("City Tripper", Resources.Kart_CityTripper),
                new NameImageValue("Bone Rattler", Resources.Kart_BoneRattler),
            };
        }

        protected override PointSetCollection GetSectionToDisplay()
        {
            return PerformanceData.KartPoints;
        }
    }
}

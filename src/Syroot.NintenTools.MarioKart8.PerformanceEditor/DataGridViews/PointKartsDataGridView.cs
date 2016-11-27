using Syroot.NintenTools.MarioKart8.BinData.Performance;

namespace Syroot.NintenTools.MarioKart8.PerformanceEditor
{
    /// <summary>
    /// Represents a <see cref="PointRankDataGridView"/> displaying PTBD values.
    /// </summary>
    public class PointKartsDataGridView : PointSetDataGridView
    {
        // ---- METHODS (PROTECTED) ------------------------------------------------------------------------------------

        protected override string[] GetRowNames()
        {
            return new string[]
            {
                "Standard Kart",
                "Pipe Frame",
                "Mach 8",
                "Steel Driver",
                "Cat Cruiser",
                "Circuit Special",
                "Tri-Speeder",
                "Badwagon",
                "Prancer",
                "Biddybuggy",
                "Landship",
                "Sneeker",
                "Sports Coupe",
                "Gold Standard",
                "Standard Bike",
                "Comet",
                "Sport Bike",
                "The Duke",
                "Flame Rider",
                "Varmint",
                "Mr. Scooty",
                "Jet Bike",
                "Yoshi Bike",
                "Standard ATV",
                "Wild Wiggler",
                "Teddy Buggy",
                "GLA",
                "W 25 Silver Arrow",
                "300 SL Roadster",
                "Blue Falcon",
                "Tanooki Kart",
                "B Dasher",
                "Master Cycle",
                "Unused 1",
                "Unused 2",
                "Streetle",
                "P-Wing",
                "City Tripper",
                "Bone Rattler"
            };
        }

        protected override PointSetCollection GetSectionToDisplay()
        {
            return PerformanceData.KartPoints;
        }
    }
}

using Syroot.NintenTools.MarioKart8.BinData.Performance;

namespace Syroot.NintenTools.MarioKart8.PerformanceEditor
{
    /// <summary>
    /// Represents a <see cref="PointRankDataGridView"/> displaying PTDV values.
    /// </summary>
    public class PointDriversDataGridView : PointSetDataGridView
    {
        // ---- METHODS (PROTECTED) ------------------------------------------------------------------------------------

        protected override string[] GetRowNames()
        {
            return new string[]
            {
                "Mario",
                "Luigi",
                "Peach",
                "Daisy",
                "Yoshi",
                "Toad",
                "Toadette",
                "Koopa Troopa",
                "Bowser",
                "Donkey Kong",
                "Wario",
                "Waluigi",
                "Rosalina",
                "Metal Mario",
                "Pink Gold Peach",
                "Lakitu",
                "Shy Guy",
                "Baby Mario",
                "Baby Luigi",
                "Baby Peach",
                "Baby Daisy",
                "Baby Rosalina",
                "Larry",
                "Lemmy",
                "Wendy",
                "Ludwig",
                "Iggy",
                "Roy",
                "Morton",
                "Mii",
                "Tanook Mario",
                "Link",
                "Villager Male",
                "Isabelle",
                "Cat Peach",
                "Dry Bowser",
                "Villager Female"
            };
        }

        protected override PointSetCollection GetSectionToDisplay()
        {
            return PerformanceData.DriverPoints;
        }
    }
}

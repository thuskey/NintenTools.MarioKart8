using Syroot.NintenTools.MarioKart8.BinData.Performance;
using Syroot.NintenTools.MarioKart8.PerformanceEditor.Properties;

namespace Syroot.NintenTools.MarioKart8.PerformanceEditor
{
    /// <summary>
    /// Represents a <see cref="PointRankDataGridView"/> displaying PTDV values.
    /// </summary>
    public class PointDriversDataGridView : PointSetDataGridView
    {
        // ---- METHODS (PROTECTED) ------------------------------------------------------------------------------------

        protected override NameImageValue[] GetRowNameImageValues()
        {
            return new NameImageValue[]
            {
                new NameImageValue("Mario", Resources.Driver_Mario),
                new NameImageValue("Luigi", Resources.Driver_Luigi),
                new NameImageValue("Peach", Resources.Driver_Peach),
                new NameImageValue("Daisy", Resources.Driver_Daisy),
                new NameImageValue("Yoshi", Resources.Driver_Yoshi),
                new NameImageValue("Toad", Resources.Driver_Toad),
                new NameImageValue("Toadette", Resources.Driver_Toadette),
                new NameImageValue("Koopa", Resources.Driver_Koopa),
                new NameImageValue("Bowser", Resources.Driver_Bowser),
                new NameImageValue("Donkey Kong", Resources.Driver_DonkeyKong),
                new NameImageValue("Wario", Resources.Driver_Wario),
                new NameImageValue("Waluigi", Resources.Driver_Waluigi),
                new NameImageValue("Rosalina", Resources.Driver_Rosalina),
                new NameImageValue("Metal Mario", Resources.Driver_MetalMario),
                new NameImageValue("Pink Gold Peach", Resources.Driver_PinkGoldPeach),
                new NameImageValue("Lakitu", Resources.Driver_Lakitu),
                new NameImageValue("Shy Guy", Resources.Driver_ShyGuy),
                new NameImageValue("Baby Mario", Resources.Driver_BabyMario),
                new NameImageValue("Baby Luigi", Resources.Driver_BabyLuigi),
                new NameImageValue("Baby Peach", Resources.Driver_BabyPeach),
                new NameImageValue("Baby Daisy", Resources.Driver_BabyDaisy),
                new NameImageValue("Baby Rosalina", Resources.Driver_BabyRosalina),
                new NameImageValue("Larry", Resources.Driver_Larry),
                new NameImageValue("Lemmy", Resources.Driver_Lemmy),
                new NameImageValue("Wendy", Resources.Driver_Wendy),
                new NameImageValue("Ludwig", Resources.Driver_Ludwig),
                new NameImageValue("Iggy", Resources.Driver_Iggy),
                new NameImageValue("Roy", Resources.Driver_Roy),
                new NameImageValue("Morton", Resources.Driver_Morton),
                new NameImageValue("Mii", Resources.Driver_Mii),
                new NameImageValue("Tanooki Mario", Resources.Driver_TanookiMario),
                new NameImageValue("Link", Resources.Driver_Link),
                new NameImageValue("Villager Male", Resources.Driver_VillagerMale),
                new NameImageValue("Isabelle", Resources.Driver_Isabelle),
                new NameImageValue("Cat Peach", Resources.Driver_CatPeach),
                new NameImageValue("Dry Bowser", Resources.Driver_DryBowser),
                new NameImageValue("Villager Female", Resources.Driver_VillagerFemale)
            };
        }

        protected override PointSetCollection GetSectionToDisplay()
        {
            return PerformanceData.DriverPoints;
        }
    }
}

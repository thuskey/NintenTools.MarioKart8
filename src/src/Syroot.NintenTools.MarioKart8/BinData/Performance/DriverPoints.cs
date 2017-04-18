using System;

namespace Syroot.NintenTools.MarioKart8.BinData.Performance
{
    /// <summary>
    /// Represents the available driver <see cref="PointSet"/> instances in the PTDV section of the
    /// &quot;Performance.bin&quot; file.
    /// </summary>
    public class DriverPoints : PointSetCollection
    {
        // ---- MEMBERS ------------------------------------------------------------------------------------------------

        /// <summary>
        /// The <see cref="PointSet"/> of Mario.
        /// </summary>
        public PointSet Mario;

        /// <summary>
        /// The <see cref="PointSet"/> of Luigi.
        /// </summary>
        public PointSet Luigi;

        /// <summary>
        /// The <see cref="PointSet"/> of Peach.
        /// </summary>
        public PointSet Peach;

        /// <summary>
        /// The <see cref="PointSet"/> of Daisy.
        /// </summary>
        public PointSet Daisy;

        /// <summary>
        /// The <see cref="PointSet"/> of Yoshi.
        /// </summary>
        public PointSet Yoshi;

        /// <summary>
        /// The <see cref="PointSet"/> of Toad
        /// </summary>
        public PointSet Toad;

        /// <summary>
        /// The <see cref="PointSet"/> of Toadette.
        /// </summary>
        public PointSet Toadette;

        /// <summary>
        /// The <see cref="PointSet"/> of Koopa Troopa.
        /// </summary>
        public PointSet KoopaTroopa;

        /// <summary>
        /// The <see cref="PointSet"/> of Bowser.
        /// </summary>
        public PointSet Bowser;

        /// <summary>
        /// The <see cref="PointSet"/> of Donkey Kong.
        /// </summary>
        public PointSet DonkeyKong;

        /// <summary>
        /// The <see cref="PointSet"/> of Wario.
        /// </summary>
        public PointSet Wario;

        /// <summary>
        /// The <see cref="PointSet"/> of Waluigi.
        /// </summary>
        public PointSet Waluigi;

        /// <summary>
        /// The <see cref="PointSet"/> of Rosalina.
        /// </summary>
        public PointSet Rosalina;

        /// <summary>
        /// The <see cref="PointSet"/> of Metal Mario.
        /// </summary>
        public PointSet MetalMario;

        /// <summary>
        /// The <see cref="PointSet"/> of Pink Gold Peach.
        /// </summary>
        public PointSet PinkGoldPeach;

        /// <summary>
        /// The <see cref="PointSet"/> of Lakitu.
        /// </summary>
        public PointSet Lakitu;

        /// <summary>
        /// The <see cref="PointSet"/> of Shy Guy.
        /// </summary>
        public PointSet ShyGuy;

        /// <summary>
        /// The <see cref="PointSet"/> of Baby Mario.
        /// </summary>
        public PointSet BabyMario;

        /// <summary>
        /// The <see cref="PointSet"/> of Baby Luigi.
        /// </summary>
        public PointSet BabyLuigi;

        /// <summary>
        /// The <see cref="PointSet"/> of Baby Peach.
        /// </summary>
        public PointSet BabyPeach;

        /// <summary>
        /// The <see cref="PointSet"/> of Baby Daisy.
        /// </summary>
        public PointSet BabyDaisy;

        /// <summary>
        /// The <see cref="PointSet"/> of Baby Rosalina.
        /// </summary>
        public PointSet BabyRosalina;

        /// <summary>
        /// The <see cref="PointSet"/> of Larry.
        /// </summary>
        public PointSet Larry;

        /// <summary>
        /// The <see cref="PointSet"/> of Lemmy.
        /// </summary>
        public PointSet Lemmy;

        /// <summary>
        /// The <see cref="PointSet"/> of Wendy.
        /// </summary>
        public PointSet Wendy;

        /// <summary>
        /// The <see cref="PointSet"/> of Ludwig.
        /// </summary>
        public PointSet Ludwig;

        /// <summary>
        /// The <see cref="PointSet"/> of Iggy.
        /// </summary>
        public PointSet Iggy;

        /// <summary>
        /// The <see cref="PointSet"/> of Roy.
        /// </summary>
        public PointSet Roy;

        /// <summary>
        /// The <see cref="PointSet"/> of Morton.
        /// </summary>
        public PointSet Morton;

        /// <summary>
        /// The <see cref="PointSet"/> of a Mii.
        /// </summary>
        public PointSet Mii;

        /// <summary>
        /// The <see cref="PointSet"/> of Tanooki Mario.
        /// </summary>
        public PointSet TanookiMario;

        /// <summary>
        /// The <see cref="PointSet"/> of Link.
        /// </summary>
        public PointSet Link;

        /// <summary>
        /// The <see cref="PointSet"/> of the male Villager.
        /// </summary>
        public PointSet VillagerMale;

        /// <summary>
        /// The <see cref="PointSet"/> of Isabelle.
        /// </summary>
        public PointSet Isabelle;

        /// <summary>
        /// The <see cref="PointSet"/> of Cat Peach.
        /// </summary>
        public PointSet CatPeach;

        /// <summary>
        /// The <see cref="PointSet"/> of Dry Bowser.
        /// </summary>
        public PointSet DryBowser;

        /// <summary>
        /// The <see cref="PointSet"/> of the female Villager.
        /// </summary>
        public PointSet VillagerFemale;

        // ---- CONSTRUCTORS & DESTRUCTOR ------------------------------------------------------------------------------

        /// <summary>
        /// Initializes a new instance of the <see cref="DriverPoints"/> class with the data read from the given
        /// <paramref name="group"/>.
        /// </summary>
        /// <param name="group">The <see cref="ByteArraysGroup"/> to read the data from.</param>
        public DriverPoints(ByteArraysGroup group) : base(group)
        {
        }

        // ---- OPERATORS ----------------------------------------------------------------------------------------------

        /// <summary>
        /// Gets or sets the element at the index as it appears in the original file.
        /// </summary>
        /// <param name="index">The index at which the value appears.</param>
        /// <returns>The value which appears at index <paramref name="index"/>.</returns>
        public override PointSet this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0: return Mario;
                    case 1: return Luigi;
                    case 2: return Peach;
                    case 3: return Daisy;
                    case 4: return Yoshi;
                    case 5: return Toad;
                    case 6: return Toadette;
                    case 7: return KoopaTroopa;
                    case 8: return Bowser;
                    case 9: return DonkeyKong;
                    case 10: return Wario;
                    case 11: return Waluigi;
                    case 12: return Rosalina;
                    case 13: return MetalMario;
                    case 14: return PinkGoldPeach;
                    case 15: return Lakitu;
                    case 16: return ShyGuy;
                    case 17: return BabyMario;
                    case 18: return BabyLuigi;
                    case 19: return BabyPeach;
                    case 20: return BabyDaisy;
                    case 21: return BabyRosalina;
                    case 22: return Larry;
                    case 23: return Lemmy;
                    case 24: return Wendy;
                    case 25: return Ludwig;
                    case 26: return Iggy;
                    case 27: return Roy;
                    case 28: return Morton;
                    case 29: return Mii;
                    case 30: return TanookiMario;
                    case 31: return Link;
                    case 32: return VillagerMale;
                    case 33: return Isabelle;
                    case 34: return CatPeach;
                    case 35: return DryBowser;
                    case 36: return VillagerFemale;
                    default: throw new ArgumentOutOfRangeException(nameof(index));
                }
            }
            set
            {
                switch (index)
                {
                    case 0: Mario = value; break;
                    case 1: Luigi = value; break;
                    case 2: Peach = value; break;
                    case 3: Daisy = value; break;
                    case 4: Yoshi = value; break;
                    case 5: Toad = value; break;
                    case 6: Toadette = value; break;
                    case 7: KoopaTroopa = value; break;
                    case 8: Bowser = value; break;
                    case 9: DonkeyKong = value; break;
                    case 10: Wario = value; break;
                    case 11: Waluigi = value; break;
                    case 12: Rosalina = value; break;
                    case 13: MetalMario = value; break;
                    case 14: PinkGoldPeach = value; break;
                    case 15: Lakitu = value; break;
                    case 16: ShyGuy = value; break;
                    case 17: BabyMario = value; break;
                    case 18: BabyLuigi = value; break;
                    case 19: BabyPeach = value; break;
                    case 20: BabyDaisy = value; break;
                    case 21: BabyRosalina = value; break;
                    case 22: Larry = value; break;
                    case 23: Lemmy = value; break;
                    case 24: Wendy = value; break;
                    case 25: Ludwig = value; break;
                    case 26: Iggy = value; break;
                    case 27: Roy = value; break;
                    case 28: Morton = value; break;
                    case 29: Mii = value; break;
                    case 30: TanookiMario = value; break;
                    case 31: Link = value; break;
                    case 32: VillagerMale = value; break;
                    case 33: Isabelle = value; break;
                    case 34: CatPeach = value; break;
                    case 35: DryBowser = value; break;
                    case 36: VillagerFemale = value; break;
                    default: throw new ArgumentOutOfRangeException(nameof(index));
                }
            }
        }
    }
}

using System;

namespace Syroot.NintenTools.MarioKart8.BinData.Performance
{
    /// <summary>
    /// Represents the available tire <see cref="PointSet"/> instances in the PTTR section of the
    /// &quot;Performance.bin&quot; file.
    /// </summary>
    public class TirePoints : PointSetCollection
    {
        // ---- MEMBERS ------------------------------------------------------------------------------------------------

        /// <summary>
        /// The <see cref="PointSet"/> of the Standard tires.
        /// </summary>
        public PointSet Standard;

        /// <summary>
        /// The <see cref="PointSet"/> of the Monster tires.
        /// </summary>
        public PointSet Monster;

        /// <summary>
        /// The <see cref="PointSet"/> of the Roller tires.
        /// </summary>
        public PointSet Roller;

        /// <summary>
        /// The <see cref="PointSet"/> of the Slim tires.
        /// </summary>
        public PointSet Slim;

        /// <summary>
        /// The <see cref="PointSet"/> of the Slick tires.
        /// </summary>
        public PointSet Slick;

        /// <summary>
        /// The <see cref="PointSet"/> of the Metal tires.
        /// </summary>
        public PointSet Metal;

        /// <summary>
        /// The <see cref="PointSet"/> of the Button tires.
        /// </summary>
        public PointSet Button;

        /// <summary>
        /// The <see cref="PointSet"/> of the Off-Road tires.
        /// </summary>
        public PointSet OffRoad;

        /// <summary>
        /// The <see cref="PointSet"/> of the Sponge tires.
        /// </summary>
        public PointSet Sponge;

        /// <summary>
        /// The <see cref="PointSet"/> of the Wood tires.
        /// </summary>
        public PointSet Wood;

        /// <summary>
        /// The <see cref="PointSet"/> of the Cushion tires.
        /// </summary>
        public PointSet Cushion;

        /// <summary>
        /// The <see cref="PointSet"/> of the Blue Standard tires.
        /// </summary>
        public PointSet BlueStandard;

        /// <summary>
        /// The <see cref="PointSet"/> of the Hot Monster tires.
        /// </summary>
        public PointSet HotMonster;

        /// <summary>
        /// The <see cref="PointSet"/> of the Azure Roller tires.
        /// </summary>
        public PointSet AzureRoller;

        /// <summary>
        /// The <see cref="PointSet"/> of the Crimson Slim tires.
        /// </summary>
        public PointSet CrimsonSlim;

        /// <summary>
        /// The <see cref="PointSet"/> of the Cyber Slick tires.
        /// </summary>
        public PointSet CyberSlick;

        /// <summary>
        /// The <see cref="PointSet"/> of the Retro Off-Road tires.
        /// </summary>
        public PointSet RetroOffRoad;

        /// <summary>
        /// The <see cref="PointSet"/> of the Gold Tires.
        /// </summary>
        public PointSet GoldTires;

        /// <summary>
        /// The <see cref="PointSet"/> of the GLA Tires.
        /// </summary>
        public PointSet GlaTires;

        /// <summary>
        /// The <see cref="PointSet"/> of the Triforce Tires.
        /// </summary>
        public PointSet TriforceTires;

        /// <summary>
        /// The <see cref="PointSet"/> of the Leaf Tires.
        /// </summary>
        public PointSet LeafTires;

        // ---- CONSTRUCTORS & DESTRUCTOR ------------------------------------------------------------------------------

        /// <summary>
        /// Initializes a new instance of the <see cref="TirePoints"/> class with the data read from the given
        /// <paramref name="group"/>.
        /// </summary>
        /// <param name="group">The <see cref="ByteArraysGroup"/> to read the data from.</param>
        public TirePoints(ByteArraysGroup group) : base(group)
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
                    case 0: return Standard;
                    case 1: return Monster;
                    case 2: return Roller;
                    case 3: return Slim;
                    case 4: return Slick;
                    case 5: return Metal;
                    case 6: return Button;
                    case 7: return OffRoad;
                    case 8: return Sponge;
                    case 9: return Wood;
                    case 10: return Cushion;
                    case 11: return BlueStandard;
                    case 12: return HotMonster;
                    case 13: return AzureRoller;
                    case 14: return CrimsonSlim;
                    case 15: return CyberSlick;
                    case 16: return RetroOffRoad;
                    case 17: return GoldTires;
                    case 18: return GlaTires;
                    case 19: return TriforceTires;
                    case 20: return LeafTires;
                    default: throw new ArgumentOutOfRangeException(nameof(index));
                }
            }
            set
            {
                switch (index)
                {
                    case 0: Standard = value; break;
                    case 1: Monster = value; break;
                    case 2: Roller = value; break;
                    case 3: Slim = value; break;
                    case 4: Slick = value; break;
                    case 5: Metal = value; break;
                    case 6: Button = value; break;
                    case 7: OffRoad = value; break;
                    case 8: Sponge = value; break;
                    case 9: Wood = value; break;
                    case 10: Cushion = value; break;
                    case 11: BlueStandard = value; break;
                    case 12: HotMonster = value; break;
                    case 13: AzureRoller = value; break;
                    case 14: CrimsonSlim = value; break;
                    case 15: CyberSlick = value; break;
                    case 16: RetroOffRoad = value; break;
                    case 17: GoldTires = value; break;
                    case 18: GlaTires = value; break;
                    case 19: TriforceTires = value; break;
                    case 20: LeafTires = value; break;
                    default: throw new ArgumentOutOfRangeException(nameof(index));
                }
            }
        }
    }
}

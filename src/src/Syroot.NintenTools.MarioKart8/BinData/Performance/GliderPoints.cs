using System;

namespace Syroot.NintenTools.MarioKart8.BinData.Performance
{
    /// <summary>
    /// Represents the available glider <see cref="PointSet"/> instances in the PTWG section of the
    /// &quot;Performance.bin&quot; file.
    /// </summary>
    public class GliderPoints : PointSetCollection
    {
        // ---- MEMBERS ------------------------------------------------------------------------------------------------

        /// <summary>
        /// The <see cref="PointSet"/> of the Super Glider.
        /// </summary>
        public PointSet SuperGlider;

        /// <summary>
        /// The <see cref="PointSet"/> of the Cloud Glider.
        /// </summary>
        public PointSet CloudGlider;

        /// <summary>
        /// The <see cref="PointSet"/> of the Wario Wing.
        /// </summary>
        public PointSet WarioWing;

        /// <summary>
        /// The <see cref="PointSet"/> of the Waddle Wing.
        /// </summary>
        public PointSet WaddleWing;

        /// <summary>
        /// The <see cref="PointSet"/> of the Peach Parasol.
        /// </summary>
        public PointSet PeachParasol;

        /// <summary>
        /// The <see cref="PointSet"/> of the Parachute.
        /// </summary>
        public PointSet Parachute;

        /// <summary>
        /// The <see cref="PointSet"/> of the Parafoil.
        /// </summary>
        public PointSet Parafoil;

        /// <summary>
        /// The <see cref="PointSet"/> of the Flower Glider.
        /// </summary>
        public PointSet FlowerGlider;

        /// <summary>
        /// The <see cref="PointSet"/> of the Bowser Kite.
        /// </summary>
        public PointSet BowserKite;

        /// <summary>
        /// The <see cref="PointSet"/> of the Plane Glider.
        /// </summary>
        public PointSet PlaneGlider;

        /// <summary>
        /// The <see cref="PointSet"/> of the MKTV Parafoil.
        /// </summary>
        public PointSet MktvParafoil;

        /// <summary>
        /// The <see cref="PointSet"/> of the Gold Glider.
        /// </summary>
        public PointSet GoldGlider;

        /// <summary>
        /// The <see cref="PointSet"/> of the Hylian Kite.
        /// </summary>
        public PointSet HylianKite;

        /// <summary>
        /// The <see cref="PointSet"/> of the Paper Glider.
        /// </summary>
        public PointSet PaperGlider;

        // ---- CONSTRUCTORS & DESTRUCTOR ------------------------------------------------------------------------------

        /// <summary>
        /// Initializes a new instance of the <see cref="GliderPoints"/> class with the data read from the given
        /// <paramref name="group"/>.
        /// </summary>
        /// <param name="group">The <see cref="ByteArraysGroup"/> to read the data from.</param>
        public GliderPoints(ByteArraysGroup group) : base(group)
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
                    case 0: return SuperGlider;
                    case 1: return CloudGlider;
                    case 2: return WarioWing;
                    case 3: return WaddleWing;
                    case 4: return PeachParasol;
                    case 5: return Parachute;
                    case 6: return Parafoil;
                    case 7: return FlowerGlider;
                    case 8: return BowserKite;
                    case 9: return PlaneGlider;
                    case 10: return MktvParafoil;
                    case 11: return GoldGlider;
                    case 12: return HylianKite;
                    case 13: return PaperGlider;
                    default: throw new ArgumentOutOfRangeException(nameof(index));
                }
            }
            set
            {
                switch (index)
                {
                    case 0: SuperGlider = value; break;
                    case 1: CloudGlider = value; break;
                    case 2: WarioWing = value; break;
                    case 3: WaddleWing = value; break;
                    case 4: PeachParasol = value; break;
                    case 5: Parachute = value; break;
                    case 6: Parafoil = value; break;
                    case 7: FlowerGlider = value; break;
                    case 8: BowserKite = value; break;
                    case 9: PlaneGlider = value; break;
                    case 10: MktvParafoil = value; break;
                    case 11: GoldGlider = value; break;
                    case 12: HylianKite = value; break;
                    case 13: PaperGlider = value; break;
                    default: throw new ArgumentOutOfRangeException(nameof(index));
                }
            }
        }
    }
}

using System;

namespace Syroot.NintenTools.MarioKart8.BinData.Performance
{
    /// <summary>
    /// Represents the available kart body <see cref="PointSet"/> instances in the PTBD section of the
    /// &quot;Performance.bin&quot; file.
    /// </summary>
    public class KartPoints : PointSetCollection
    {
        // ---- MEMBERS ------------------------------------------------------------------------------------------------

        /// <summary>
        /// The <see cref="PointSet"/> of the Standard Kart.
        /// </summary>
        public PointSet StandardKart;

        /// <summary>
        /// The <see cref="PointSet"/> of the Pipe Frame.
        /// </summary>
        public PointSet PipeFrame;

        /// <summary>
        /// The <see cref="PointSet"/> of the Mach 8.
        /// </summary>
        public PointSet Mach8;

        /// <summary>
        /// The <see cref="PointSet"/> of the Steel Driver.
        /// </summary>
        public PointSet SteelDriver;

        /// <summary>
        /// The <see cref="PointSet"/> of the Cat Cruiser.
        /// </summary>
        public PointSet CatCruiser;

        /// <summary>
        /// The <see cref="PointSet"/> of the Circuit Special
        /// </summary>
        public PointSet CircuitSpecial;

        /// <summary>
        /// The <see cref="PointSet"/> of the Tri-Speeder.
        /// </summary>
        public PointSet TriSpeeder;

        /// <summary>
        /// The <see cref="PointSet"/> of the Badwagon.
        /// </summary>
        public PointSet Badwagon;

        /// <summary>
        /// The <see cref="PointSet"/> of the Prancer.
        /// </summary>
        public PointSet Prancer;

        /// <summary>
        /// The <see cref="PointSet"/> of the Biddybuggy.
        /// </summary>
        public PointSet Biddybuggy;

        /// <summary>
        /// The <see cref="PointSet"/> of the Landship.
        /// </summary>
        public PointSet Landship;

        /// <summary>
        /// The <see cref="PointSet"/> of the Sneeker.
        /// </summary>
        public PointSet Sneeker;

        /// <summary>
        /// The <see cref="PointSet"/> of the Sports Coupe.
        /// </summary>
        public PointSet SportsCoupe;

        /// <summary>
        /// The <see cref="PointSet"/> of the Gold Standard.
        /// </summary>
        public PointSet GoldStandard;

        /// <summary>
        /// The <see cref="PointSet"/> of the Standard Bike.
        /// </summary>
        public PointSet StandardBike;

        /// <summary>
        /// The <see cref="PointSet"/> of the Comet.
        /// </summary>
        public PointSet Comet;

        /// <summary>
        /// The <see cref="PointSet"/> of the Sport bike.
        /// </summary>
        public PointSet SportBike;

        /// <summary>
        /// The <see cref="PointSet"/> of The Duke.
        /// </summary>
        public PointSet TheDuke;

        /// <summary>
        /// The <see cref="PointSet"/> of the Flame Rider.
        /// </summary>
        public PointSet FlameRider;

        /// <summary>
        /// The <see cref="PointSet"/> of the Varmint.
        /// </summary>
        public PointSet Varmint;

        /// <summary>
        /// The <see cref="PointSet"/> of Mr. Scooty.
        /// </summary>
        public PointSet MrScooty;

        /// <summary>
        /// The <see cref="PointSet"/> of the Jet Bike.
        /// </summary>
        public PointSet JetBike;

        /// <summary>
        /// The <see cref="PointSet"/> of the Yoshi Bike.
        /// </summary>
        public PointSet YoshiBike;

        /// <summary>
        /// The <see cref="PointSet"/> of the Standard ATV.
        /// </summary>
        public PointSet StandardAtv;

        /// <summary>
        /// The <see cref="PointSet"/> of the Wild Wiggler.
        /// </summary>
        public PointSet WildWiggler;

        /// <summary>
        /// The <see cref="PointSet"/> of the Teddy Buggy.
        /// </summary>
        public PointSet TeddyBuggy;

        /// <summary>
        /// The <see cref="PointSet"/> of the Mercedes GLA.
        /// </summary>
        public PointSet Gla;

        /// <summary>
        /// The <see cref="PointSet"/> of the Mercedes W 25 Silver Arrow.
        /// </summary>
        public PointSet SilverArrow;

        /// <summary>
        /// The <see cref="PointSet"/> of the Mercedes 300 SL Roadster.
        /// </summary>
        public PointSet SlRoadster;

        /// <summary>
        /// The <see cref="PointSet"/> of the Blue Falcon.
        /// </summary>
        public PointSet BlueFalcon;

        /// <summary>
        /// The <see cref="PointSet"/> of the Tanooki Kart.
        /// </summary>
        public PointSet TanookiKart;

        /// <summary>
        /// The <see cref="PointSet"/> of B Dasher.
        /// </summary>
        public PointSet BDasher;

        /// <summary>
        /// The <see cref="PointSet"/> of the Master Cycle.
        /// </summary>
        public PointSet MasterCycle;

        /// <summary>
        /// The <see cref="PointSet"/> of the first unused kart body.
        /// </summary>
        public PointSet Unused1;

        /// <summary>
        /// The <see cref="PointSet"/> of the second unused kart body.
        /// </summary>
        public PointSet Unused2;

        /// <summary>
        /// The <see cref="PointSet"/> of Streetle.
        /// </summary>
        public PointSet Streetle;

        /// <summary>
        /// The <see cref="PointSet"/> of the P-Wing.
        /// </summary>
        public PointSet PWing;

        /// <summary>
        /// The <see cref="PointSet"/> of the City Tripper.
        /// </summary>
        public PointSet CityTripper;

        /// <summary>
        /// The <see cref="PointSet"/> of the Bone Rattler.
        /// </summary>
        public PointSet BoneRattler;

        // ---- CONSTRUCTORS & DESTRUCTOR ------------------------------------------------------------------------------

        /// <summary>
        /// Initializes a new instance of the <see cref="KartPoints"/> struct with the data read from the given
        /// <paramref name="group"/>.
        /// </summary>
        /// <param name="group">The <see cref="ByteArraysGroup"/> to read the data from.</param>
        public KartPoints(ByteArraysGroup group) : base(group)
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
                    case 0: return StandardKart;
                    case 1: return PipeFrame;
                    case 2: return Mach8;
                    case 3: return SteelDriver;
                    case 4: return CatCruiser;
                    case 5: return CircuitSpecial;
                    case 6: return TriSpeeder;
                    case 7: return Badwagon;
                    case 8: return Prancer;
                    case 9: return Biddybuggy;
                    case 10: return Landship;
                    case 11: return Sneeker;
                    case 12: return SportsCoupe;
                    case 13: return GoldStandard;
                    case 14: return StandardBike;
                    case 15: return Comet;
                    case 16: return SportBike;
                    case 17: return TheDuke;
                    case 18: return FlameRider;
                    case 19: return Varmint;
                    case 20: return MrScooty;
                    case 21: return JetBike;
                    case 22: return YoshiBike;
                    case 23: return StandardAtv;
                    case 24: return WildWiggler;
                    case 25: return TeddyBuggy;
                    case 26: return Gla;
                    case 27: return SilverArrow;
                    case 28: return SlRoadster;
                    case 29: return BlueFalcon;
                    case 30: return TanookiKart;
                    case 31: return BDasher;
                    case 32: return MasterCycle;
                    case 33: return Unused1;
                    case 34: return Unused2;
                    case 35: return Streetle;
                    case 36: return PWing;
                    case 37: return CityTripper;
                    case 38: return BoneRattler;
                    default: throw new ArgumentOutOfRangeException(nameof(index));
                }
            }
            set
            {
                switch (index)
                {
                    case 0: StandardKart = value; break;
                    case 1: PipeFrame = value; break;
                    case 2: Mach8 = value; break;
                    case 3: SteelDriver = value; break;
                    case 4: CatCruiser = value; break;
                    case 5: CircuitSpecial = value; break;
                    case 6: TriSpeeder = value; break;
                    case 7: Badwagon = value; break;
                    case 8: Prancer = value; break;
                    case 9: Biddybuggy = value; break;
                    case 10: Landship = value; break;
                    case 11: Sneeker = value; break;
                    case 12: SportsCoupe = value; break;
                    case 13: GoldStandard = value; break;
                    case 14: StandardBike = value; break;
                    case 15: Comet = value; break;
                    case 16: SportBike = value; break;
                    case 17: TheDuke = value; break;
                    case 18: FlameRider = value; break;
                    case 19: Varmint = value; break;
                    case 20: MrScooty = value; break;
                    case 21: JetBike = value; break;
                    case 22: YoshiBike = value; break;
                    case 23: StandardAtv = value; break;
                    case 24: WildWiggler = value; break;
                    case 25: TeddyBuggy = value; break;
                    case 26: Gla = value; break;
                    case 27: SilverArrow = value; break;
                    case 28: SlRoadster = value; break;
                    case 29: BlueFalcon = value; break;
                    case 30: TanookiKart = value; break;
                    case 31: BDasher = value; break;
                    case 32: MasterCycle = value; break;
                    case 33: Unused1 = value; break;
                    case 34: Unused2 = value; break;
                    case 35: Streetle = value; break;
                    case 36: PWing = value; break;
                    case 37: CityTripper = value; break;
                    case 38: BoneRattler = value; break;
                    default: throw new ArgumentOutOfRangeException(nameof(index));
                }
            }
        }
    }
}

using System;
using System.Runtime.InteropServices;

namespace Syroot.NintenTools.MarioKart8.BinData.Performance
{
    /// <summary>
    /// Represents the traction settings for a specific set of total points in the PROF section of the
    /// &quot;Performance.bin&quot; file.
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 72, Pack = 1)]
    public class OffroadStat
    {
        // ---- MEMBERS ------------------------------------------------------------------------------------------------
        
        /// <summary>
        /// The speed factor on light dirt off-road.
        /// </summary>
        [FieldOffset(0)]
        public float BrakeDirtLight;

        /// <summary>
        /// The speed factor on medium dirt off-road.
        /// </summary>
        [FieldOffset(4)]
        public float BrakeDirtMedium;

        /// <summary>
        /// The speed factor on heavy dirt off-road.
        /// </summary>
        [FieldOffset(8)]
        public float BrakeDirtHeavy;

        /// <summary>
        /// The speed factor on light sand off-road.
        /// </summary>
        [FieldOffset(12)]
        public float BrakeSandLight;

        /// <summary>
        /// The speed factor on medium sand off-road.
        /// </summary>
        [FieldOffset(16)]
        public float BrakeSandMedium;

        /// <summary>
        /// The speed factor on heavy sand off-road.
        /// </summary>
        [FieldOffset(20)]
        public float BrakeSandHeavy;

        /// <summary>
        /// The speed factor on light ice off-road.
        /// </summary>
        [FieldOffset(24)]
        public float BrakeIceLight;

        /// <summary>
        /// The speed factor on medium ice off-road.
        /// </summary>
        [FieldOffset(28)]
        public float BrakeIceMedium;

        /// <summary>
        /// The speed factor on heavy ice off-road.
        /// </summary>
        [FieldOffset(32)]
        public float BrakeIceHeavy;

        /// <summary>
        /// The slip factor on light dirt off-road.
        /// </summary>
        [FieldOffset(36)]
        public float SlipDirtLight;

        /// <summary>
        /// The slip factor on medium dirt off-road.
        /// </summary>
        [FieldOffset(40)]
        public float SlipDirtMedium;

        /// <summary>
        /// The slip factor on heavy dirt off-road.
        /// </summary>
        [FieldOffset(44)]
        public float SlipDirtHeavy;

        /// <summary>
        /// The slip factor on light sand off-road.
        /// </summary>
        [FieldOffset(48)]
        public float SlipSandLight;

        /// <summary>
        /// The slip factor on medium sand off-road.
        /// </summary>
        [FieldOffset(52)]
        public float SlipSandMedium;

        /// <summary>
        /// The slip factor on heavy sand off-road.
        /// </summary>
        [FieldOffset(56)]
        public float SlipSandHeavy;

        /// <summary>
        /// The slip factor on light ice off-road.
        /// </summary>
        [FieldOffset(60)]
        public float SlipIceLight;

        /// <summary>
        /// The slip factor on medium ice off-road.
        /// </summary>
        [FieldOffset(64)]
        public float SlipIceMedium;

        /// <summary>
        /// The slip factor on heavy ice off-road.
        /// </summary>
        [FieldOffset(68)]
        public float SlipIceHeavy;

        // ---- OPERATORS ----------------------------------------------------------------------------------------------

        /// <summary>
        /// Gets or sets the element at the index as it appears in the original file.
        /// </summary>
        /// <param name="index">The index at which the value appears.</param>
        /// <returns>The value which appears at index <paramref name="index"/>.</returns>
        public float this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0: return BrakeDirtLight;
                    case 1: return BrakeDirtMedium;
                    case 2: return BrakeDirtHeavy;
                    case 3: return BrakeSandLight;
                    case 4: return BrakeSandMedium;
                    case 5: return BrakeSandHeavy;
                    case 6: return BrakeIceLight;
                    case 7: return BrakeIceMedium;
                    case 8: return BrakeIceHeavy;
                    case 9: return SlipDirtLight;
                    case 10: return SlipDirtMedium;
                    case 11: return SlipDirtHeavy;
                    case 12: return SlipSandLight;
                    case 13: return SlipSandMedium;
                    case 14: return SlipSandHeavy;
                    case 15: return SlipIceLight;
                    case 16: return SlipIceMedium;
                    case 17: return SlipIceHeavy;
                    default: throw new ArgumentOutOfRangeException(nameof(index));
                }
            }
            set
            {
                switch (index)
                {
                    case 0: BrakeDirtLight = value; break;
                    case 1: BrakeDirtMedium = value; break;
                    case 2: BrakeDirtHeavy = value; break;
                    case 3: BrakeSandLight = value; break;
                    case 4: BrakeSandMedium = value; break;
                    case 5: BrakeSandHeavy = value; break;
                    case 6: BrakeIceLight = value; break;
                    case 7: BrakeIceMedium = value; break;
                    case 8: BrakeIceHeavy = value; break;
                    case 9: SlipDirtLight = value; break;
                    case 10: SlipDirtMedium = value; break;
                    case 11: SlipDirtHeavy = value; break;
                    case 12: SlipSandLight = value; break;
                    case 13: SlipSandMedium = value; break;
                    case 14: SlipSandHeavy = value; break;
                    case 15: SlipIceLight = value; break;
                    case 16: SlipIceMedium = value; break;
                    case 17: SlipIceHeavy = value; break;
                    default: throw new ArgumentOutOfRangeException(nameof(index));
                }
            }
        }
    }
}

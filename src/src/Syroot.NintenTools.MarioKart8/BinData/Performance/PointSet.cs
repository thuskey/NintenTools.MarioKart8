using System;
using System.Runtime.InteropServices;

namespace Syroot.NintenTools.MarioKart8.BinData.Performance
{
    /// <summary>
    /// Represents the set of points a driver, kart body, wheel or glider provides to the sum of performance points.
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 52, Pack = 1)]
    public class PointSet
    {
        // ---- MEMBERS ------------------------------------------------------------------------------------------------

        /// <summary>
        /// The points attributed to weight.
        /// </summary>
        [FieldOffset(0)]
        public int Weight;

        /// <summary>
        /// The points attributed to acceleration.
        /// </summary>
        [FieldOffset(4)]
        public int Acceleration;

        /// <summary>
        /// The points attributed to outerslip.
        /// </summary>
        [FieldOffset(8)]
        public int Outerslip;

        /// <summary>
        /// The points attributed to traction.
        /// </summary>
        [FieldOffset(12)]
        public int Traction;

        /// <summary>
        /// The points attributed to mini turbos.
        /// </summary>
        [FieldOffset(16)]
        public int MiniTurbo;

        /// <summary>
        /// The points attributed to speed on normal ground.
        /// </summary>
        [FieldOffset(20)]
        public int SpeedGround;

        /// <summary>
        /// The points attributed to speed when underwater.
        /// </summary>
        [FieldOffset(24)]
        public int SpeedWater;

        /// <summary>
        /// The points attributed to speed in anti-gravity sections.
        /// </summary>
        [FieldOffset(28)]
        public int SpeedAntigravity;

        /// <summary>
        /// The points attributed to speed while gliding.
        /// </summary>
        [FieldOffset(32)]
        public int SpeedAir;

        /// <summary>
        /// The points attributed to handling on normal ground.
        /// </summary>
        [FieldOffset(36)]
        public int HandlingGround;

        /// <summary>
        /// The points attributed to handling when underwater.
        /// </summary>
        [FieldOffset(40)]
        public int HandlingWater;

        /// <summary>
        /// The points attributed to handling in anti-gravity sections.
        /// </summary>
        [FieldOffset(44)]
        public int HandlingAntigravity;

        /// <summary>
        /// The points attributed to handling while gliding.
        /// </summary>
        [FieldOffset(48)]
        public int HandlingAir;

        // ---- OPERATORS ----------------------------------------------------------------------------------------------

        /// <summary>
        /// Gets or sets the element at the index as it appears in the original file.
        /// </summary>
        /// <param name="index">The index at which the value appears.</param>
        /// <returns>The value which appears at index <paramref name="index"/>.</returns>
        public int this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0: return Weight;
                    case 1: return Acceleration;
                    case 2: return Outerslip;
                    case 3: return Traction;
                    case 4: return MiniTurbo;
                    case 5: return SpeedGround;
                    case 6: return SpeedWater;
                    case 7: return SpeedAntigravity;
                    case 8: return SpeedAir;
                    case 9: return HandlingGround;
                    case 10: return HandlingWater;
                    case 11: return HandlingAntigravity;
                    case 12: return HandlingAir;
                    default: throw new ArgumentOutOfRangeException(nameof(index));
                }
            }
            set
            {
                switch (index)
                {
                    case 0: Weight = value; break;
                    case 1: Acceleration = value; break;
                    case 2: Outerslip = value; break;
                    case 3: Traction = value; break;
                    case 4: MiniTurbo = value; break;
                    case 5: SpeedGround = value; break;
                    case 6: SpeedWater = value; break;
                    case 7: SpeedAntigravity = value; break;
                    case 8: SpeedAir = value; break;
                    case 9: HandlingGround = value; break;
                    case 10: HandlingWater = value; break;
                    case 11: HandlingAntigravity = value; break;
                    case 12: HandlingAir = value; break;
                    default: throw new ArgumentOutOfRangeException(nameof(index));
                }
            }
        }
    }
}

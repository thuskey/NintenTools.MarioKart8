using System;
using System.Runtime.InteropServices;

namespace Syroot.NintenTools.MarioKart8.BinData.Performance
{
    /// <summary>
    /// Represents speed settings providing a higher value for when having 10 coins collected for a specific sum of
    /// total points in the PRS? sections of the &quot;Performance.bin&quot; file.
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 8, Pack = 1)]
    public class SpeedStat
    {
        // ---- MEMBERS ------------------------------------------------------------------------------------------------

        /// <summary>
        /// The highest speed achievable when having 0 coins collected.
        /// </summary>
        [FieldOffset(0)]
        public float Speed;

        /// <summary>
        /// The highest speed achievable when having 10 coins collected.
        /// </summary>
        [FieldOffset(4)]
        public float MaxSpeed;

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
                    case 0: return Speed;
                    case 1: return MaxSpeed;
                    default: throw new ArgumentOutOfRangeException(nameof(index));
                }
            }
            set
            {
                switch (index)
                {
                    case 0: Speed = value; break;
                    case 1: MaxSpeed = value; break;
                    default: throw new ArgumentOutOfRangeException(nameof(index));
                }
            }
        }
    }
}

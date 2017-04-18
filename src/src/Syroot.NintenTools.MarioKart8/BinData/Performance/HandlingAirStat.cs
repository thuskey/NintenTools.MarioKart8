using System;
using System.Runtime.InteropServices;

namespace Syroot.NintenTools.MarioKart8.BinData.Performance
{
    /// <summary>
    /// Represents handling settings providing different values depending on the current drift for a specific sum of
    /// total points in the PRTG section of the &quot;Performance.bin&quot; file.
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 8, Pack = 1)]
    public class HandlingAirStat
    {
        // ---- MEMBERS ------------------------------------------------------------------------------------------------

        /// <summary>
        /// The highest turn rate achievable when rolling.
        /// </summary>
        [FieldOffset(0)]
        public float Roll;

        /// <summary>
        /// The highest turn rate achievable when moving.
        /// </summary>
        [FieldOffset(4)]
        public float Move;
        
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
                    case 0: return Roll;
                    case 1: return Move;
                    default: throw new ArgumentOutOfRangeException(nameof(index));
                }
            }
            set
            {
                switch (index)
                {
                    case 0: Roll = value; break;
                    case 1: Move = value; break;
                    default: throw new ArgumentOutOfRangeException(nameof(index));
                }
            }
        }
    }
}

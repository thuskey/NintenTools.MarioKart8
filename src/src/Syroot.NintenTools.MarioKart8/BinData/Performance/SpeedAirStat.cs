using System;
using System.Runtime.InteropServices;

namespace Syroot.NintenTools.MarioKart8.BinData.Performance
{
    /// <summary>
    /// Represents speed settings for a specific sum of total points in the PRSG section of the
    /// &quot;Performance.bin&quot; file.
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 4, Pack = 1)]
    public class SpeedAirStat
    {
        // ---- MEMBERS ------------------------------------------------------------------------------------------------

        /// <summary>
        /// The highest speed achievable.
        /// </summary>
        [FieldOffset(0)]
        public float Speed;
        
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
                    default: throw new ArgumentOutOfRangeException(nameof(index));
                }
            }
            set
            {
                switch (index)
                {
                    case 0: Speed = value; break;
                    default: throw new ArgumentOutOfRangeException(nameof(index));
                }
            }
        }
    }
}

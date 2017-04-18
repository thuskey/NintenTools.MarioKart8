using System;
using System.Runtime.InteropServices;

namespace Syroot.NintenTools.MarioKart8.BinData.Performance
{
    /// <summary>
    /// Represents the acceleration settings for a specific set of total points in the PRAC section of the
    /// &quot;Performance.bin&quot; file.
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 8, Pack = 1)]
    public class AccelerationStat
    {
        // ---- MEMBERS ------------------------------------------------------------------------------------------------

        /// <summary>
        /// The first acceleration value.
        /// </summary>
        [FieldOffset(0)]
        public float First;

        /// <summary>
        /// The second acceleration value.
        /// </summary>
        [FieldOffset(4)]
        public float Second;
        
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
                    case 0: return First;
                    case 1: return Second;
                    default: throw new ArgumentOutOfRangeException(nameof(index));
                }
            }
            set
            {
                switch (index)
                {
                    case 0: First = value; break;
                    case 1: Second = value; break;
                    default: throw new ArgumentOutOfRangeException(nameof(index));
                }
            }
        }
    }
}

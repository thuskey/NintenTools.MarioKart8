using System;
using System.Runtime.InteropServices;

namespace Syroot.NintenTools.MarioKart8.BinData.Performance
{
    /// <summary>
    /// Represents the weight settings for a specific sum of total points in the PRWG section of the
    /// &quot;Performance.bin&quot; file.
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 12, Pack = 1)]
    public class WeightStat
    {
        // ---- MEMBERS ------------------------------------------------------------------------------------------------

        /// <summary>
        /// The weight stats while being bumped.
        /// </summary>
        [FieldOffset(0)]
        public float Bumped;

        /// <summary>
        /// The weight stats while bumping.
        /// </summary>
        [FieldOffset(4)]
        public float Bumping;

        /// <summary>
        /// An unknown value.
        /// </summary>
        [FieldOffset(8)]
        public float Unknown;
        
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
                    case 0: return Bumped;
                    case 1: return Bumping;
                    case 2: return Unknown;
                    default: throw new ArgumentOutOfRangeException(nameof(index));
                }
            }
            set
            {
                switch (index)
                {
                    case 0: Bumped = value; break;
                    case 1: Bumping = value; break;
                    case 2: Unknown = value; break;
                    default: throw new ArgumentOutOfRangeException(nameof(index));
                }
            }
        }
    }
}

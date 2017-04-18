using System;
using System.Runtime.InteropServices;

namespace Syroot.NintenTools.MarioKart8.BinData.Performance
{
    /// <summary>
    /// Represents the outerslip settings for a specific set of total points in the PRON section of the
    /// &quot;Performance.bin&quot; file.
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 4, Pack = 1)]
    public class OuterslipStat
    {
        // ---- MEMBERS ------------------------------------------------------------------------------------------------

        /// <summary>
        /// The strength of the outerslip.
        /// </summary>
        [FieldOffset(0)]
        public float Factor;
        
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
                    case 0: return Factor;
                    default: throw new ArgumentOutOfRangeException(nameof(index));
                }
            }
            set
            {
                switch (index)
                {
                    case 0: Factor = value; break;
                    default: throw new ArgumentOutOfRangeException(nameof(index));
                }
            }
        }
    }
}

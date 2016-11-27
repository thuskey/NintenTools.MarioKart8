using System;
using System.Runtime.InteropServices;

namespace Syroot.NintenTools.MarioKart8.BinData.Performance
{
    /// <summary>
    /// Represents handling settings providing different values depending on the current drift for a specific sum of
    /// total points in the PRT? sections of the &quot;Performance.bin&quot; file.
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 12, Pack = 1)]
    public class HandlingStat
    {
        // ---- MEMBERS ------------------------------------------------------------------------------------------------

        /// <summary>
        /// The highest turn rate achievable when not drifting.
        /// </summary>
        [FieldOffset(0)]
        public float Normal;

        /// <summary>
        /// The highest turn rate achievable when drifting.
        /// </summary>
        [FieldOffset(4)]
        public float Drift;

        /// <summary>
        /// The highest turn rate achievable when being auto-driftedg.
        /// </summary>
        [FieldOffset(8)]
        public float AutoDrift;

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
                    case 0: return Normal;
                    case 1: return Drift;
                    case 2: return AutoDrift;
                    default: throw new ArgumentOutOfRangeException(nameof(index));
                }
            }
            set
            {
                switch (index)
                {
                    case 0: Normal = value; break;
                    case 1: Drift = value; break;
                    case 2: AutoDrift = value; break;
                    default: throw new ArgumentOutOfRangeException(nameof(index));
                }
            }
        }
    }
}

using System;
using System.Runtime.InteropServices;

namespace Syroot.NintenTools.MarioKart8.BinData.Performance
{
    /// <summary>
    /// Represents the turbo settings for a specific set of total points in the PRMT section of the
    /// &quot;Performance.bin&quot; file.
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 8, Pack = 1)]
    public class TurboStat
    {
        // ---- MEMBERS ------------------------------------------------------------------------------------------------

        /// <summary>
        /// The number of frames a mini turbo lasts.
        /// </summary>
        [FieldOffset(0)]
        public int MiniTurboFrames;

        /// <summary>
        /// The number of frames a super turbo lasts.
        /// </summary>
        [FieldOffset(4)]
        public int SuperTurboFrames;

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
                    case 0: return MiniTurboFrames;
                    case 1: return SuperTurboFrames;
                    default: throw new ArgumentOutOfRangeException(nameof(index));
                }
            }
            set
            {
                switch (index)
                {
                    case 0: MiniTurboFrames = value; break;
                    case 1: SuperTurboFrames = value; break;
                    default: throw new ArgumentOutOfRangeException(nameof(index));
                }
            }
        }
    }
}

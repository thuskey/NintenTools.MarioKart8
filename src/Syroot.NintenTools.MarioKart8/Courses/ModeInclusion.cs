using System;
using System.Collections.Generic;
using Syroot.NintenTools.Byaml;

namespace Syroot.NintenTools.MarioKart8.Courses
{
    /// <summary>
    /// Represents the possible game modes in which a unit object can appear.
    /// </summary>
    [Flags]
    public enum ModeInclusion
    {
        /// <summary>
        /// No mode.
        /// </summary>
        None = 0,

        /// <summary>
        /// Singleplayer mode. Has been added with the DLC courses.
        /// </summary>
        Single = 1 << 0,

        /// <summary>
        /// Multiplayer mode with 2 players (vertical splitscreen).
        /// </summary>
        Multi2P = 1 << 1,

        /// <summary>
        /// Multiplayer mode with 3 or 4 players (quad splitscreen).
        /// </summary>
        Multi4P = 1 << 2,

        /// <summary>
        /// Online 1-player mode.
        /// </summary>
        WiFi = 1 << 3,

        /// <summary>
        /// Online 2-player mode (vertical splitscreen).
        /// </summary>
        WiFi2P = 1 << 4
    }

    /// <summary>
    /// Represents a set of extension methods for the <see cref="ModeInclusion"/> enumeration.
    /// </summary>
    public static class ModeInclusionExtensions
    {
        // ---- METHODS (PUBLIC) ---------------------------------------------------------------------------------------

        /// <summary>
        /// Gets a <see cref="ModeInclusion"/> value according to the (optional) Single, Multi2P, Multi4P, WiFi2P and
        /// WiFi4P dictionary entries of the given BYAML <paramref name="node"/>.
        /// </summary>
        /// <param name="node">The BYAML node to retrieve the dictionary entries from.</param>
        /// <returns>A <see cref="ModeInclusion"/> value according to the BYAML node.</returns>
        public static ModeInclusion GetFromByaml(IDictionary<string, dynamic> node)
        {
            ModeInclusion modeInclusion = ModeInclusion.None;

            // Note that the BYAML values are negated, they are true if an object is excluded from track.

            // Single is optional (was added with the DLC courses), but can default to be available if not set.
            bool? single = ByamlFile.GetValue(node, "Single");
            if (!single.HasValue || single == false) modeInclusion |= ModeInclusion.Single;

            // Other modes are always set.
            if (!node["Multi2P"]) modeInclusion |= ModeInclusion.Multi2P;
            if (!node["Multi4P"]) modeInclusion |= ModeInclusion.Multi4P;
            if (!node["WiFi"]) modeInclusion |= ModeInclusion.WiFi;
            if (!node["WiFi2P"]) modeInclusion |= ModeInclusion.WiFi2P;

            return modeInclusion;
        }

        /// <summary>
        /// Sets the dictionary entries of the given BYAML <paramref name="node"/> according to the current instance.
        /// </summary>
        /// <param name="modeInclusion">The extended <see cref="ModeInclusion"/> instance.</param>
        /// <param name="node">The BYAML node to configure.</param>
        public static void SetForByaml(this ModeInclusion modeInclusion, IDictionary<string, dynamic> node)
        {
            // Note that the BYAML values are negated, they are true if an object is excluded from track.
            node["Single"] = !modeInclusion.HasFlag(ModeInclusion.Single); // Can be set even in non-DLC courses.
            node["Multi2P"] = !modeInclusion.HasFlag(ModeInclusion.Multi2P);
            node["Multi4P"] = !modeInclusion.HasFlag(ModeInclusion.Multi4P);
            node["WiFi"] = !modeInclusion.HasFlag(ModeInclusion.WiFi);
            node["WiFi2P"] = !modeInclusion.HasFlag(ModeInclusion.WiFi2P);
        }
    }
}

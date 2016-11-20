using System.Collections.Generic;
using Syroot.NintenTools.Byaml.Serialization;

namespace Syroot.NintenTools.MarioKart8.Courses
{
    /// <summary>
    /// Represents a path a gliding driver is flying along.
    /// </summary>
    [ByamlObject]
    public class GlidePath : PathBase<GlidePath, GlidePathPoint>
    {
        // ---- PROPERTIES ---------------------------------------------------------------------------------------------

        /// <summary>
        /// Gets or sets a value indicating the type of gliding.
        /// </summary>
        [ByamlMember]
        public int GlideType { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this is an updraft glide.
        /// </summary>
        [ByamlMember]
        public bool IsUp { get; set; }
    }
}

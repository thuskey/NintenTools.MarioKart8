using System.Collections.Generic;
using Syroot.NintenTools.Byaml.Serialization;

namespace Syroot.NintenTools.MarioKart8.Courses
{
    /// <summary>
    /// Represents an object on a course which is translated, rotated and scaled in space.
    /// </summary>
    [ByamlObject]
    public abstract class PrmObject : SpatialObject
    {
        // ---- PROPERTIES ---------------------------------------------------------------------------------------------

        /// <summary>
        /// Gets or sets the first parameter.
        /// </summary>
        [ByamlMember("prm1")]
        public float Prm1 { get; set; }

        /// <summary>
        /// Gets or sets the second parameter.
        /// </summary>
        [ByamlMember("prm2")]
        public float Prm2 { get; set; }
    }
}

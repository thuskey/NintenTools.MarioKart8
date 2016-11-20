using System.Collections.Generic;
using Syroot.NintenTools.Byaml;
using Syroot.NintenTools.Byaml.Serialization;

namespace Syroot.NintenTools.MarioKart8.Courses
{
    /// <summary>
    /// Represents a path for Objs.
    /// </summary>
    [ByamlObject]
    public class ObjPath : PathBase<ObjPath, ObjPathPoint>
    {
        // ---- PROPERTIES ---------------------------------------------------------------------------------------------

        /// <summary>
        /// Gets or sets a value indicating whether this path is circular and that the last point connects to the first.
        /// </summary>
        [ByamlMember]
        public bool IsClosed { get; set; }

        /// <summary>
        /// Gets or sets an unknown value.
        /// </summary>
        [ByamlMember]
        public int PtNum { get; set; }

        /// <summary>
        /// Gets or sets a value possibly indicating the thickness of the path.
        /// </summary>
        [ByamlMember]
        public float SplitWidth { get; set; }

        /// <summary>
        /// Gets a BYAML path point embedded in this path for unknown reasons.
        /// </summary>
        [ByamlMember]
        public List<ByamlPathPoint> ObjPt { get; set; }
    }
}

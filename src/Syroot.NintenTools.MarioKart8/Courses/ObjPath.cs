using System.Collections.Generic;
using Syroot.NintenTools.Byaml;

namespace Syroot.NintenTools.MarioKart8.Courses
{
    /// <summary>
    /// Represents a path for Objs.
    /// </summary>
    public class ObjPath : PathBase<ObjPath, ObjPathPoint>
    {
        // ---- PROPERTIES ---------------------------------------------------------------------------------------------

        /// <summary>
        /// Gets or sets a value indicating whether this path is circular and that the last point connects to the first.
        /// </summary>
        public bool IsClosed { get; set; }

        /// <summary>
        /// Gets or sets an unknown value.
        /// </summary>
        public int PtNum { get; set; }

        /// <summary>
        /// Gets or sets a value possibly indicating the thickness of the path.
        /// </summary>
        public float SplitWidth { get; set; }

        /// <summary>
        /// Gets a <see cref="ByamlPath"/> embedded in this path for unknown reasons.
        /// </summary>
        public ByamlPath ObjPt { get; set; }

        // ---- METHODS (PUBLIC) ---------------------------------------------------------------------------------------

        /// <summary>
        /// Reads the data from the given dynamic BYAML node into the instance.
        /// </summary>
        /// <param name="node">The dynamic BYAML node to deserialize.</param>
        /// <returns>The instance itself.</returns>
        public override dynamic DeserializeByaml(dynamic node)
        {
            base.DeserializeByaml((IDictionary<string, dynamic>)node);
            IsClosed = node["IsClosed"];
            PtNum = node["PtNum"];
            SplitWidth = node["SplitWidth"];
            ObjPt = node["ObjPt"];
            return this;
        }

        /// <summary>
        /// Creates a dynamic BYAML node from the instance's data.
        /// </summary>
        /// <returns>The dynamic BYAML node.</returns>
        public override dynamic SerializeByaml()
        {
            dynamic node = base.SerializeByaml();
            node["IsClosed"] = IsClosed;
            node["PtNum"] = PtNum;
            node["SplitWidth"] = SplitWidth;
            node["ObjPt"] = ObjPt;
            return node;
        }
    }
}

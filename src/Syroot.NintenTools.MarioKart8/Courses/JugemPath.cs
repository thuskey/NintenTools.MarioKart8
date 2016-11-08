﻿using System.Collections.Generic;
using Syroot.NintenTools.Byaml;

namespace Syroot.NintenTools.MarioKart8.Courses
{
    /// <summary>
    /// Represents a path possibly determining where Lakitu resets drivers back to.
    /// </summary>
    public class JugemPath : PathBase<JugemPath, JugemPathPoint>
    {
        // ---- PROPERTIES ---------------------------------------------------------------------------------------------

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
        public override void DeserializeByaml(dynamic node)
        {
            base.DeserializeByaml((IDictionary<string, dynamic>)node);
            ObjPt = node["ObjPt"];
            SplitWidth = node["SplitWidth"];
        }

        /// <summary>
        /// Creates a dynamic BYAML node from the instance's data.
        /// </summary>
        /// <returns>The dynamic BYAML node.</returns>
        public override dynamic SerializeByaml()
        {
            dynamic node = base.SerializeByaml();
            node["ObjPt"] = ObjPt;
            node["SplitWidth"] = SplitWidth;
            return node;
        }
    }
}
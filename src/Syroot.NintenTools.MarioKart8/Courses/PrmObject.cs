﻿using System.Collections.Generic;

namespace Syroot.NintenTools.MarioKart8.Courses
{
    /// <summary>
    /// Represents an object on a course which is translated, rotated and scaled in space.
    /// </summary>
    public abstract class PrmObject : SpatialObject
    {
        // ---- PROPERTIES ---------------------------------------------------------------------------------------------

        /// <summary>
        /// Gets or sets the first parameter.
        /// </summary>
        public float prm1 { get; set; }

        /// <summary>
        /// Gets or sets the second parameter.
        /// </summary>
        public float prm2 { get; set; }

        // ---- METHODS (PUBLIC) ---------------------------------------------------------------------------------------

        /// <summary>
        /// Reads the data from the given dynamic BYAML node into the instance.
        /// </summary>
        /// <param name="node">The dynamic BYAML node to deserialize.</param>
        public override void DeserializeByaml(dynamic node)
        {
            base.DeserializeByaml((IDictionary<string, dynamic>)node);
            prm1 = node["prm1"];
            prm2 = node["prm2"];
        }

        /// <summary>
        /// Creates a dynamic BYAML node from the instance's data.
        /// </summary>
        /// <returns>The dynamic BYAML node.</returns>
        public override dynamic SerializeByaml()
        {
            IDictionary<string, dynamic> node = base.SerializeByaml();
            node["prm1"] = prm1;
            node["prm2"] = prm2;
            return node;
        }
    }
}

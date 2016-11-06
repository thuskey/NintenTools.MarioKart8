using System.Collections.Generic;
using Syroot.NintenTools.Maths;

namespace Syroot.NintenTools.MarioKart8.Courses
{
    /// <summary>
    /// Represents an object on a course which is translated, rotated and scaled in space.
    /// </summary>
    public abstract class SpatialObject : UnitObject
    {
        // ---- PROPERTIES ---------------------------------------------------------------------------------------------

        /// <summary>
        /// Gets or sets the rotation of the object in radian.
        /// </summary>
        public Vector3F Rotate { get; set; }

        /// <summary>
        /// Gets or sets the scale of the object.
        /// </summary>
        public Vector3F Scale { get; set; }

        /// <summary>
        /// Gets or sets the position at which the object is placed.
        /// </summary>
        public Vector3F Translate { get; set; }

        // ---- METHODS (PUBLIC) ---------------------------------------------------------------------------------------

        /// <summary>
        /// Reads the data from the given dynamic BYAML node into the instance.
        /// </summary>
        /// <param name="node">The dynamic BYAML node to deserialize.</param>
        public override void DeserializeByaml(dynamic node)
        {
            base.DeserializeByaml((IDictionary<string, dynamic>)node);
            Rotate = new Vector3F(node["Rotate"]);
            Scale = new Vector3F(node["Scale"]);
            Translate = new Vector3F(node["Translate"]);
        }

        /// <summary>
        /// Creates a dynamic BYAML node from the instance's data.
        /// </summary>
        /// <returns>The dynamic BYAML node.</returns>
        public override dynamic SerializeByaml()
        {
            IDictionary<string, dynamic> node = base.SerializeByaml();
            node["Rotate"] = Rotate.SerializeByaml();
            node["Scale"] = Scale.SerializeByaml();
            node["Translate"] = Translate.SerializeByaml();
            return node;
        }
    }
}

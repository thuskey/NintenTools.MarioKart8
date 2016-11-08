using System.Collections.Generic;

namespace Syroot.NintenTools.MarioKart8.Courses
{
    /// <summary>
    /// Represents an clip area controlling model clipping.
    /// </summary>
    public class ClipArea : PrmObject
    {
        // ---- PROPERTIES ---------------------------------------------------------------------------------------------

        /// <summary>
        /// Gets or set the shape the outer form of this clip area spans. Only <see cref="AreaShape.Cube"/> is known for
        /// these to be valid.
        /// </summary>
        public AreaShape AreaShape { get; set; }

        /// <summary>
        /// Gets or sets the action taken for this clip area. Only <see cref="AreaType.Clip"/> is valid for clip areas.
        /// </summary>
        public AreaType AreaType { get; set; }

        // ---- METHODS (PUBLIC) ---------------------------------------------------------------------------------------

        /// <summary>
        /// Reads the data from the given dynamic BYAML node into the instance.
        /// </summary>
        /// <param name="node">The dynamic BYAML node to deserialize.</param>
        /// <returns>The instance itself.</returns>
        public override dynamic DeserializeByaml(dynamic node)
        {
            base.DeserializeByaml((IDictionary<string, dynamic>)node);
            AreaShape = (AreaShape)node["AreaShape"];
            AreaType = (AreaType)node["AreaType"];
            return this;
        }

        /// <summary>
        /// Creates a dynamic BYAML node from the instance's data.
        /// </summary>
        /// <returns>The dynamic BYAML node.</returns>
        public override dynamic SerializeByaml()
        {
            IDictionary<string, dynamic> node = base.SerializeByaml();
            node["AreaShape"] = (int)AreaShape;
            node["AreaType"] = (int)AreaType;
            return node;
        }
    }
}

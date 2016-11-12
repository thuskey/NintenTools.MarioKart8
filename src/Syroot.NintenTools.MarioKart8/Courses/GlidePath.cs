using System.Collections.Generic;

namespace Syroot.NintenTools.MarioKart8.Courses
{
    /// <summary>
    /// Represents a path a gliding driver is flying along.
    /// </summary>
    public class GlidePath : PathBase<GlidePath, GlidePathPoint>
    {
        // ---- PROPERTIES ---------------------------------------------------------------------------------------------

        /// <summary>
        /// Gets or sets a value indicating the type of gliding.
        /// </summary>
        public int GlideType { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this is an updraft glide.
        /// </summary>
        public bool IsUp { get; set; }

        // ---- METHODS (PUBLIC) ---------------------------------------------------------------------------------------

        /// <summary>
        /// Reads the data from the given dynamic BYAML node into the instance.
        /// </summary>
        /// <param name="node">The dynamic BYAML node to deserialize.</param>
        /// <returns>The instance itself.</returns>
        public override dynamic DeserializeByaml(dynamic node)
        {
            base.DeserializeByaml((IDictionary<string, dynamic>)node);
            GlideType = node["GlideType"];
            IsUp = node["IsUp"];
            return this;
        }

        /// <summary>
        /// Creates a dynamic BYAML node from the instance's data.
        /// </summary>
        /// <returns>The dynamic BYAML node.</returns>
        public override dynamic SerializeByaml()
        {
            dynamic node = base.SerializeByaml();
            node["GlideType"] = GlideType;
            node["IsUp"] = IsUp;
            return node;
        }
    }
}

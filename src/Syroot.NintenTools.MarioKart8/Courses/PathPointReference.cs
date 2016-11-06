using System.Collections.Generic;
using Syroot.NintenTools.Byaml;

namespace Syroot.NintenTools.MarioKart8.Courses
{
    /// <summary>
    /// Represents the serialized index to a path and a point in it from the course definition.
    /// </summary>
    public class PathPointReference : IByamlSerializable
    {
        // ---- CONSTRUCTORS & DESTRUCTOR ------------------------------------------------------------------------------

        /// <summary>
        /// Initializes a new instance of the <see cref="PathPointReference"/> class.
        /// </summary>
        public PathPointReference()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PathPointReference"/> class with the given indices.
        /// </summary>
        /// <param name="pathIndex">The path index.</param>
        /// <param name="pointIndex">The point index.</param>
        internal PathPointReference(int pathIndex, int pointIndex)
        {
            PathIndex = pathIndex;
            PointIndex = pointIndex;
        }

        // ---- PROPERTIES ---------------------------------------------------------------------------------------------

        /// <summary>
        /// Gets or sets the index of the path instance referenced from the list of enemy paths in the course
        /// definition.
        /// </summary>
        internal int PathIndex { get; set; }

        /// <summary>
        /// Gets or sets the index of the path point of the path referenced by <see cref="PathIndex"/>.
        /// </summary>
        internal int PointIndex { get; set; }

        // ---- METHODS (PUBLIC) ---------------------------------------------------------------------------------------

        /// <summary>
        /// Reads the data from the given dynamic BYAML node into the instance.
        /// </summary>
        /// <param name="node">The dynamic BYAML node to deserialize.</param>
        public void DeserializeByaml(dynamic node)
        {
            PathIndex = node["PathId"];
            PointIndex = node["PtId"];
        }

        /// <summary>
        /// Creates a dynamic BYAML node from the instance's data.
        /// </summary>
        /// <returns>The dynamic BYAML node.</returns>
        public dynamic SerializeByaml()
        {
            return new Dictionary<string, dynamic>()
            {
                ["PathId"] = PathIndex,
                ["PtId"] = PointIndex
            };
        }
    }
}
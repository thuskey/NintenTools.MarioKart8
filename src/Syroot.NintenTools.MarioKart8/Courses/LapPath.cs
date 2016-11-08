using System.Collections.Generic;
using Syroot.NintenTools.Byaml;

namespace Syroot.NintenTools.MarioKart8.Courses
{
    /// <summary>
    /// Represents a path which drivers need to taken to complete a lap.
    /// </summary>
    public class LapPath : PathBase<LapPath, LapPathPoint>
    {
        // ---- PROPERTIES ---------------------------------------------------------------------------------------------

        /// <summary>
        /// Gets or sets a value indicating the group the lap path belongs to, possibly for multiple routes.
        /// </summary>
        public int Group { get; set; }

        /// <summary>
        /// Gets or sets an unknown value, possibly handling Lakitu return locations and referencing
        /// <see cref="ReturnPoint"/> instances.
        /// </summary>
        public bool ReturnPointsError { get; set; }

        /// <summary>
        /// Gets or sets the list of <see cref="ReturnPoint"/> instances.
        /// </summary>
        public List<ReturnPoint> ReturnPoints { get; set; }

        // ---- METHODS (PUBLIC) ---------------------------------------------------------------------------------------

        /// <summary>
        /// Reads the data from the given dynamic BYAML node into the instance.
        /// </summary>
        /// <param name="node">The dynamic BYAML node to deserialize.</param>
        public override void DeserializeByaml(dynamic node)
        {
            base.DeserializeByaml((IDictionary<string, dynamic>)node);
            Group = node["LapPathGroup"];
            ReturnPointsError = node["ReturnPointsError"];
            ReturnPoints = ByamlFile.DeserializeList<ReturnPoint>(node["ReturnPoints"]);
        }

        /// <summary>
        /// Creates a dynamic BYAML node from the instance's data.
        /// </summary>
        /// <returns>The dynamic BYAML node.</returns>
        public override dynamic SerializeByaml()
        {
            dynamic node = base.SerializeByaml();
            node["LapPathGroup"] = Group;
            node["ReturnPointsError"] = ReturnPointsError;
            node["ReturnPoints"] = ReturnPoints;
            return node;
        }
    }
}

using System.Collections.Generic;
using Syroot.NintenTools.Byaml;

namespace Syroot.NintenTools.MarioKart8.Courses
{
    /// <summary>
    /// Represents a path which drivers need to taken to complete a lap.
    /// </summary>
    public class LapPath : PathBase<LapPath, LapPathPoint>
    {
        // ---- MEMBERS ------------------------------------------------------------------------------------------------

        private List<int> _gravityPathIndices;

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

        /// <summary>
        /// Gets or sets a list of <see cref="GravityPaths"/> instances used by this lap path.
        /// </summary>
        public List<GravityPath> GravityPaths { get; set; }

        // ---- METHODS (PUBLIC) ---------------------------------------------------------------------------------------

        /// <summary>
        /// Reads the data from the given dynamic BYAML node into the instance.
        /// </summary>
        /// <param name="node">The dynamic BYAML node to deserialize.</param>
        /// <returns>The instance itself.</returns>
        public override dynamic DeserializeByaml(dynamic node)
        {
            base.DeserializeByaml((IDictionary<string, dynamic>)node);
            Group = node["LapPathGroup"];
            ReturnPointsError = node["ReturnPointsError"];
            ReturnPoints = ByamlFile.DeserializeList<ReturnPoint>(node["ReturnPoints"]);
            _gravityPathIndices = ByamlFile.GetList<int>(ByamlFile.GetValue(node, "LapPath_GravityPath"));
            return this;
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
            node["ReturnPoints"] = ByamlFile.SerializeList(ReturnPoints);
            ByamlFile.SetValue(node, "LapPath_GravityPath", _gravityPathIndices);
            return node;
        }

        /// <summary>
        /// Allows references of course data objects to be resolved to provide real instances instead of the raw values
        /// in the BYAML.
        /// </summary>
        /// <param name="courseDefinition">The <see cref="CourseDefinition"/> providing the objects.</param>
        public override void DeserializeReferences(CourseDefinition courseDefinition)
        {
            base.DeserializeReferences(courseDefinition);

            // Gravity paths.
            if (_gravityPathIndices == null)
            {
                GravityPaths = null;
            }
            else
            {
                GravityPaths = new List<GravityPath>();
                foreach (int index in _gravityPathIndices)
                {
                    GravityPaths.Add(courseDefinition.GravityPaths[index]);
                }
            }
        }

        /// <summary>
        /// Allows references between course objects to be serialized into raw values stored in the BYAML.
        /// </summary>
        /// <param name="courseDefinition">The <see cref="CourseDefinition"/> providing the objects.</param>
        public override void SerializeReferences(CourseDefinition courseDefinition)
        {
            base.SerializeReferences(courseDefinition);

            // Gravity paths.
            if (GravityPaths == null)
            {
                _gravityPathIndices = null;
            }
            else
            {
                _gravityPathIndices = new List<int>();
                foreach (GravityPath path in GravityPaths)
                {
                    _gravityPathIndices.Add(courseDefinition.GravityPaths.IndexOf(path));
                }
            }
        }
    }
}

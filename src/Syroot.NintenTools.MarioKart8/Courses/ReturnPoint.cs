using System.Collections.Generic;
using Syroot.NintenTools.Byaml;
using Syroot.NintenTools.Maths;

namespace Syroot.NintenTools.MarioKart8.Courses
{
    /// <summary>
    /// Represents a return point of a <see cref="LapPath"/>.
    /// </summary>
    public class ReturnPoint : IByamlSerializable, IByamlReferencable
    {
        // ---- MEMBERS ------------------------------------------------------------------------------------------------

        private int _jugemPathIndex;
        private int _jugemPathPointIndex;

        // ---- PROPERTIES ---------------------------------------------------------------------------------------------

        /// <summary>
        /// Gets or sets an unknown return type.
        /// </summary>
        public int ReturnType { get; set; }

        /// <summary>
        /// Gets or sets an unknown value.
        /// </summary>
        public int HasError { get; set; }

        /// <summary>
        /// Gets or sets a referenced <see cref="JugemPathPoint"/>.
        /// </summary>
        public JugemPathPoint JugemPathPoint { get; set; }

        /// <summary>
        /// Gets or sets the spatial normal.
        /// </summary>
        public Vector3F Normal { get; set; }

        /// <summary>
        /// Gets or sets the spatial position.
        /// </summary>
        public Vector3F Position { get; set; }

        /// <summary>
        /// Gets or sets the spatial tangent.
        /// </summary>
        public Vector3F Tangent { get; set; }

        // ---- METHODS (PUBLIC) ---------------------------------------------------------------------------------------

        /// <summary>
        /// Reads the data from the given dynamic BYAML node into the instance.
        /// </summary>
        /// <param name="node">The dynamic BYAML node to deserialize.</param>
        /// <returns>The instance itself.</returns>
        public dynamic DeserializeByaml(dynamic node)
        {
            _jugemPathIndex = node["JugemPath"];
            _jugemPathPointIndex = node["JugemIndex"];
            ReturnType = node["ReturnType"];
            HasError = node["hasError"];
            Normal = new Vector3F(node["Normal"]);
            Position = new Vector3F(node["Position"]);
            Tangent = new Vector3F(node["Tangent"]);
            return this;
        }

        /// <summary>
        /// Creates a dynamic BYAML node from the instance's data.
        /// </summary>
        /// <returns>The dynamic BYAML node.</returns>
        public dynamic SerializeByaml()
        {
            return new Dictionary<string, dynamic>()
            {
                ["JugemPath"] = _jugemPathIndex,
                ["JugemIndex"] = _jugemPathPointIndex,
                ["ReturnType"] = ReturnType,
                ["hasError"] = HasError,
                ["Normal"] = Normal,
                ["Position"] = Position,
                ["Tangent"] = Tangent
            };
        }

        /// <summary>
        /// Allows references between BYAML instances to be resolved to provide real instances instead of the raw values
        /// in the BYAML.
        /// </summary>
        /// <param name="courseDefinition">The <see cref="CourseDefinition"/> providing the objects.</param>
        public void DeserializeReferences(CourseDefinition courseDefinition)
        {
            JugemPath jugemPath = courseDefinition.JugemPaths[_jugemPathIndex];
            JugemPathPoint = jugemPath.Points[_jugemPathPointIndex];
        }

        /// <summary>
        /// Allows references between BYAML instances to be serialized into raw values stored in the BYAML.
        /// </summary>
        /// <param name="courseDefinition">The <see cref="CourseDefinition"/> providing the objects.</param>
        public void SerializeReferences(CourseDefinition courseDefinition)
        {
            _jugemPathIndex = courseDefinition.JugemPaths.IndexOf(JugemPathPoint.Path);
            _jugemPathPointIndex = JugemPathPoint.Index;
        }
    }
}
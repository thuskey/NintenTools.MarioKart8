using System.Collections.Generic;
using Syroot.NintenTools.Byaml;

namespace Syroot.NintenTools.MarioKart8.Courses
{
    /// <summary>
    /// Represents an area controlling different things inside of it.
    /// </summary>
    public class Area : PrmObject, IByamlReferencable
    {
        // ---- MEMBERS ------------------------------------------------------------------------------------------------

        /// <summary>
        /// Gets or sets a path used when <see cref="AreaType"/> is set to <see cref="AreaType.None"/> or
        /// <see cref="AreaType.Unknown2"/>.
        /// </summary>
        private int? _pathIndex;
        /// <summary>
        /// Gets or sets the path objects are moved along when the <see cref="AreaType"/> is set to
        /// <see cref="AreaType.Pull"/>.
        /// </summary>
        private int? _pullPathIndex;

        // ---- PROPERTIES ---------------------------------------------------------------------------------------------

        /// <summary>
        /// Gets or set the shape the outer form of this area spans.
        /// </summary>
        public AreaShape AreaShape { get; set; }

        /// <summary>
        /// Gets or sets the action taken for objects in this area.
        /// </summary>
        public AreaType AreaType { get; set; }
        
        public List<int> CameraAreas { get; set; }

        // TODO: Paths

        // ---- METHODS (PUBLIC) ---------------------------------------------------------------------------------------

        /// <summary>
        /// Reads the data from the given dynamic BYAML node into the instance.
        /// </summary>
        /// <param name="node">The dynamic BYAML node to deserialize.</param>
        public override void DeserializeByaml(dynamic node)
        {
            base.DeserializeByaml((IDictionary<string, dynamic>)node);
            AreaShape = (AreaShape)node["AreaShape"];
            AreaType = (AreaType)node["AreaType"];
            _pathIndex = ByamlFile.GetValue(node, "Area_Path");
            _pullPathIndex = ByamlFile.GetValue(node, "Area_PullPath");
            CameraAreas = ByamlFile.GetList<int>(ByamlFile.GetValue(node, "Camera_Area"));
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
            ByamlFile.SetValue(node, "Area_Path", _pathIndex);
            ByamlFile.SetValue(node, "Area_PullPath", _pullPathIndex);
            ByamlFile.SetValue(node, "Camera_Area", CameraAreas);
            return node;
        }

        /// <summary>
        /// Allows references between BYAML instances to be resolved to provide real instances
        /// instead of the raw values in the BYAML.
        /// </summary>
        /// <param name="courseDefinition">The <see cref="CourseDefinition"/> providing the objects.</param>
        public void DeserializeReferences(CourseDefinition courseDefinition)
        {
            // TODO: Paths
        }

        /// <summary>
        /// Allows references between BYAML instances to be serialized into raw values stored in the
        /// BYAML.
        /// </summary>
        /// <param name="courseDefinition">The <see cref="CourseDefinition"/> providing the objects.</param>
        public void SerializeReferences(CourseDefinition courseDefinition)
        {
            // TODO: Paths
        }
    }
}

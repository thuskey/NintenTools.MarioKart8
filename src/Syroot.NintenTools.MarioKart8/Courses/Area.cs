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
        
        private int? _pathIndex;
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
        
        /// <summary>
        /// Gets or sets a list of indices to unknown areas, possibly triggering replay cameras.
        /// </summary>
        public List<int> CameraAreas { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="Path"/> instance used by this area when <see cref="AreaType"/>  is set to
        /// <see cref="AreaType.None"/> or <see cref="AreaType.Unknown2"/>.
        /// </summary>
        public Path Path { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="Path"/> instance determining the direction objects in this area are pulled along
        /// when the <see cref="AreaType"/> is set to <see cref="AreaType.Pull"/>.
        /// </summary>
        public Path PullPath { get; set; }

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
            Path = _pathIndex == null ? null : courseDefinition.Paths[_pathIndex.Value];
            PullPath = _pullPathIndex == null ? null : courseDefinition.Paths[_pullPathIndex.Value];
        }

        /// <summary>
        /// Allows references between BYAML instances to be serialized into raw values stored in the
        /// BYAML.
        /// </summary>
        /// <param name="courseDefinition">The <see cref="CourseDefinition"/> providing the objects.</param>
        public void SerializeReferences(CourseDefinition courseDefinition)
        {
            _pathIndex = Path == null ? null : (int?)courseDefinition.Paths.IndexOf(Path);
            _pullPathIndex = PullPath == null ? null : (int?)courseDefinition.Paths.IndexOf(PullPath);
        }
    }
}

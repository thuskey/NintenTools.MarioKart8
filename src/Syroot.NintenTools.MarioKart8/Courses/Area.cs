using System.Collections.Generic;
using Syroot.NintenTools.Byaml.Serialization;

namespace Syroot.NintenTools.MarioKart8.Courses
{
    /// <summary>
    /// Represents an area controlling different things inside of it.
    /// </summary>
    [ByamlObject]
    public class Area : PrmObject, ICourseReferencable
    {
        // ---- MEMBERS ------------------------------------------------------------------------------------------------

        [ByamlMember("Area_Path", Optional = true)]
        private int? _pathIndex;
        [ByamlMember("Area_PullPath", Optional = true)]
        private int? _pullPathIndex;

        // ---- PROPERTIES ---------------------------------------------------------------------------------------------

        /// <summary>
        /// Gets or set the shape the outer form of this area spans.
        /// </summary>
        [ByamlMember]
        public AreaShape AreaShape { get; set; }

        /// <summary>
        /// Gets or sets the action taken for objects in this area.
        /// </summary>
        [ByamlMember]
        public AreaType AreaType { get; set; }

        /// <summary>
        /// Gets or sets a list of indices to unknown areas, possibly triggering replay cameras.
        /// </summary>
        [ByamlMember("Camera_Area", Optional = true)]
        public List<int> CameraAreas { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="Path"/> instance used by this area when <see cref="AreaType"/> is set to
        /// <see cref="AreaType.None"/> or <see cref="AreaType.Unknown2"/>.
        /// </summary>
        public Path Path { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="PullPath"/> instance determining the direction objects in this area are pulled
        /// along when the <see cref="AreaType"/> is set to <see cref="AreaType.Pull"/>.
        /// </summary>
        public PullPath PullPath { get; set; }

        // ---- METHODS (PUBLIC) ---------------------------------------------------------------------------------------
        
        /// <summary>
        /// Allows references between BYAML instances to be resolved to provide real instances
        /// instead of the raw values in the BYAML.
        /// </summary>
        /// <param name="courseDefinition">The <see cref="CourseDefinition"/> providing the objects.</param>
        public void DeserializeReferences(CourseDefinition courseDefinition)
        {
            Path = _pathIndex == null ? null : courseDefinition.Paths[_pathIndex.Value];
            PullPath = _pullPathIndex == null ? null : courseDefinition.PullPaths[_pullPathIndex.Value];
        }

        /// <summary>
        /// Allows references between BYAML instances to be serialized into raw values stored in the
        /// BYAML.
        /// </summary>
        /// <param name="courseDefinition">The <see cref="CourseDefinition"/> providing the objects.</param>
        public void SerializeReferences(CourseDefinition courseDefinition)
        {
            _pathIndex = Path == null ? null : (int?)courseDefinition.Paths.IndexOf(Path);
            _pullPathIndex = PullPath == null ? null : (int?)courseDefinition.PullPaths.IndexOf(PullPath);
        }
    }
}

using Syroot.NintenTools.Byaml.Serialization;

namespace Syroot.NintenTools.MarioKart8.Courses
{
    /// <summary>
    /// Represents the camera movements and cuts triggered by drivers in the replay video.
    /// </summary>
    [ByamlObject]
    public class ReplayCamera : SpatialObject
    {
        // ---- MEMBERS ------------------------------------------------------------------------------------------------

        [ByamlMember("Camera_Path", Optional = true)]
        private int? _pathIndex;

        // ---- PROPERTIES ---------------------------------------------------------------------------------------------

        /// <summary>
        /// Gets or sets an unknown angle on the X axis.
        /// </summary>
        [ByamlMember]
        public int AngleX { get; set; }

        /// <summary>
        /// Gets or sets an unknown angle on the Y axis.
        /// </summary>
        [ByamlMember]
        public int AngleY { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the field of view angle is computed in accordance to the distance to
        /// the driver who triggered the camera.
        /// </summary>
        [ByamlMember]
        public bool AutoFovy { get; set; }

        /// <summary>
        /// Gets or sets an unknown camera type.
        /// </summary>
        [ByamlMember("CameraType")]
        public int Type { get; set; }
        
        /// <summary>
        /// Gets or sets the <see cref="Path"/> this camera moves along.
        /// </summary>
        public Path Path { get; set; }

        /// <summary>
        /// Gets or sets a value indicating the blur effect for far-away geometry.
        /// </summary>
        [ByamlMember]
        public int DepthOfField { get; set; }

        /// <summary>
        /// Gets or sets the distance of the camera to the driver.
        /// </summary>
        [ByamlMember]
        public int Distance { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to lock the view target onto the driver who triggered the camera.
        /// </summary>
        [ByamlMember]
        public bool Follow { get; set; }

        /// <summary>
        /// Gets or sets the field of view angle possibly at the start of the move.
        /// </summary>
        [ByamlMember]
        public int Fovy { get; set; }

        /// <summary>
        /// Gets or sets the field of view angle possibly at the end of the move.
        /// </summary>
        [ByamlMember]
        public int Fovy2 { get; set; }

        /// <summary>
        /// Gets or sets a speed possibly controlling how the FoV change is done.
        /// </summary>
        [ByamlMember]
        public int FovySpeed { get; set; }

        /// <summary>
        /// Gets or sets the group this camera belongs to.
        /// </summary>
        [ByamlMember]
        public int Group { get; set; }

        /// <summary>
        /// Gets or sets the first parameter.
        /// </summary>
        [ByamlMember("prm1")]
        public int Prm1 { get; set; }

        /// <summary>
        /// Gets or sets the second parameter.
        /// </summary>
        [ByamlMember("prm2")]
        public int Prm2 { get; set; }

        /// <summary>
        /// Gets or sets the rotation around the X axis.
        /// </summary>
        [ByamlMember]
        public int Pitch { get; set; }

        /// <summary>
        /// Gets or sets the rotation around the Y axis.
        /// </summary>
        [ByamlMember]
        public int Yaw { get; set; }

        /// <summary>
        /// Gets or sets the rotation around the Z axis.
        /// </summary>
        [ByamlMember]
        public int Roll { get; set; }

        // ---- METHODS (PUBLIC) ---------------------------------------------------------------------------------------
        
        /// <summary>
        /// Allows references between BYAML instances to be resolved to provide real instances
        /// instead of the raw values in the BYAML.
        /// </summary>
        /// <param name="courseDefinition">The <see cref="CourseDefinition"/> providing the objects.</param>
        public void DeserializeReferences(CourseDefinition courseDefinition)
        {
            Path = _pathIndex == null ? null : courseDefinition.Paths[_pathIndex.Value];
        }

        /// <summary>
        /// Allows references between BYAML instances to be serialized into raw values stored in the
        /// BYAML.
        /// </summary>
        /// <param name="courseDefinition">The <see cref="CourseDefinition"/> providing the objects.</param>
        public void SerializeReferences(CourseDefinition courseDefinition)
        {
            _pathIndex = Path == null ? null : (int?)courseDefinition.Paths.IndexOf(Path);
        }
    }
}

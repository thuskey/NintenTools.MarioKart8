using Syroot.NintenTools.Byaml.Serialization;

namespace Syroot.NintenTools.MarioKart8.Courses
{
    /// <summary>
    /// Represents a camera move played in the introductionary course video played at the start of offline races.
    /// </summary>
    [ByamlObject]
    public class IntroCamera : SpatialObject, ICourseReferencable
    {
        // ---- MEMBERS ------------------------------------------------------------------------------------------------

        [ByamlMember("Camera_Path")]
        private int _pathIndex;

        // ---- PROPERTIES ---------------------------------------------------------------------------------------------

        /// <summary>
        /// Gets or sets the index of the camera in the intro camera array.
        /// </summary>
        [ByamlMember("CameraNum")]
        public int Num { get; set; }

        /// <summary>
        /// Gets or sets the number of frames the camera is active.
        /// </summary>
        [ByamlMember("CameraTime")]
        public int Time { get; set; }

        /// <summary>
        /// Gets or sets an unknown camera type.
        /// </summary>
        [ByamlMember("CameraType")]
        public int Type { get; set; }

        /// <summary>
        /// Gets or sets a value referencing an unknown path property.
        /// </summary>
        [ByamlMember("Camera_AtPath")]
        public int AtPath { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="Path"/> on which this camera moves along.
        /// </summary>
        public Path Path { get; set; }

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

        // ---- METHODS (PUBLIC) ---------------------------------------------------------------------------------------
        
        /// <summary>
        /// Allows references of course file objects to be resolved to provide real instances instead of the raw values
        /// in the BYAML.
        /// </summary>
        /// <param name="courseDefinition">The <see cref="CourseDefinition"/> providing the objects.</param>
        public void DeserializeReferences(CourseDefinition courseDefinition)
        {
            Path = courseDefinition.Paths[_pathIndex];
        }

        /// <summary>
        /// Allows references between course objects to be serialized into raw values stored in the BYAML.
        /// </summary>
        /// <param name="courseDefinition">The <see cref="CourseDefinition"/> providing the objects.</param>
        public void SerializeReferences(CourseDefinition courseDefinition)
        {
            _pathIndex = courseDefinition.Paths.IndexOf(Path);
        }
    }
}

using Syroot.NintenTools.Byaml.Serialization;

namespace Syroot.NintenTools.MarioKart8.Courses
{
    /// <summary>
    /// Represents a return point of a <see cref="LapPath"/>.
    /// </summary>
    [ByamlObject]
    public class ReturnPoint : ICourseReferencable
    {
        // ---- MEMBERS ------------------------------------------------------------------------------------------------

        [ByamlMember("JugemPath")]
        private int _jugemPathIndex; // TODO: JugemPath member in ReturnPointEnemy is a string with "rail2" etc.
        [ByamlMember("JugemIndex")]
        private int _jugemPathPointIndex;

        // ---- PROPERTIES ---------------------------------------------------------------------------------------------

        /// <summary>
        /// Gets or sets an unknown return type.
        /// </summary>
        [ByamlMember]
        public int ReturnType { get; set; }

        /// <summary>
        /// Gets or sets an unknown value.
        /// </summary>
        [ByamlMember("hasError")]
        public ReturnPointErrorType HasError { get; set; }

        /// <summary>
        /// Gets or sets a referenced <see cref="JugemPathPoint"/>.
        /// </summary>
        public JugemPathPoint JugemPathPoint { get; set; }

        /// <summary>
        /// Gets or sets the spatial normal.
        /// </summary>
        [ByamlMember]
        public ByamlVector3F Normal { get; set; }

        /// <summary>
        /// Gets or sets the spatial position.
        /// </summary>
        [ByamlMember]
        public ByamlVector3F Position { get; set; }

        /// <summary>
        /// Gets or sets the spatial tangent.
        /// </summary>
        [ByamlMember]
        public ByamlVector3F Tangent { get; set; }

        // ---- METHODS (PUBLIC) ---------------------------------------------------------------------------------------
        
        /// <summary>
        /// Allows references of course data objects to be resolved to provide real instances instead of the raw values
        /// in the BYAML.
        /// </summary>
        /// <param name="courseDefinition">The <see cref="CourseDefinition"/> providing the objects.</param>
        public void DeserializeReferences(CourseDefinition courseDefinition)
        {
            JugemPath jugemPath = courseDefinition.JugemPaths[_jugemPathIndex];
            JugemPathPoint = jugemPath.Points[_jugemPathPointIndex];
        }

        /// <summary>
        /// Allows references between course objects to be serialized into raw values stored in the BYAML.
        /// </summary>
        /// <param name="courseDefinition">The <see cref="CourseDefinition"/> providing the objects.</param>
        public void SerializeReferences(CourseDefinition courseDefinition)
        {
            _jugemPathIndex = courseDefinition.JugemPaths.IndexOf(JugemPathPoint.Path);
            _jugemPathPointIndex = JugemPathPoint.Index;
        }
    }
}
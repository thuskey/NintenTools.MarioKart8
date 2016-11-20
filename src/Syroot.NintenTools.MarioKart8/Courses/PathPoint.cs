using System.Collections.Generic;
using Syroot.Maths;
using Syroot.NintenTools.Byaml.Serialization;

namespace Syroot.NintenTools.MarioKart8.Courses
{
    /// <summary>
    /// Represents a point of a <see cref="Path"/>.
    /// </summary>
    [ByamlObject]
    public class PathPoint : PathPointBase<Path, PathPoint>
    {
        // ---- PROPERTIES ---------------------------------------------------------------------------------------------

        /// <summary>
        /// Gets or sets the first parameter.
        /// </summary>
        [ByamlMember("prm1")]
        public float Prm1 { get; set; }

        /// <summary>
        /// Gets or sets the second parameter.
        /// </summary>
        [ByamlMember("prm2")]
        public float Prm2 { get; set; }

        /// <summary>
        /// Gets or sets the list of tangential smoothing points (must be exactly 2).
        /// </summary>
        [ByamlMember]
        public List<ByamlVector3F> ControlPoints { get; set; }

        // ---- METHODS (PROTECTED) ------------------------------------------------------------------------------------

        /// <summary>
        /// Returns the array of paths in the <see cref="CourseDefinition"/> which can be referenced by previous and
        /// next points.
        /// </summary>
        /// <param name="courseDefinition">The <see cref="CourseDefinition"/> to get the paths from.</param>
        /// <returns>The array of paths which can be referenced.</returns>
        protected override IList<Path> GetPathReferenceList(CourseDefinition courseDefinition)
        {
            return courseDefinition.Paths;
        }
    }
}

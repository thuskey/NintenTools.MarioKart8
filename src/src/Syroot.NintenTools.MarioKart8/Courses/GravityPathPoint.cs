using System.Collections.Generic;
using Syroot.NintenTools.Byaml.Serialization;

namespace Syroot.NintenTools.MarioKart8.Courses
{
    /// <summary>
    /// Represents a point of a <see cref="GravityPath"/>.
    /// </summary>
    [ByamlObject]
    public class GravityPathPoint : PathPointBase<GravityPath, GravityPathPoint>
    {
        // ---- PROPERTIES ---------------------------------------------------------------------------------------------

        /// <summary>
        /// Gets or sets a distance possibly controlling how far from the ground the camera is positioned.
        /// </summary>
        [ByamlMember]
        public int CameraHeight { get; set; }

        /// <summary>
        /// Gets or sets a value possibly indicating whether this gravity path is only effective when gliding.
        /// </summary>
        [ByamlMember]
        public bool GlideOnly { get; set; }

        /// <summary>
        /// Gets or sets an unknown value.
        /// </summary>
        [ByamlMember]
        public bool Transform { get; set; }

        // ---- METHODS (PROTECTED) ------------------------------------------------------------------------------------

        /// <summary>
        /// Returns the array of paths in the <see cref="CourseDefinition"/> which can be referenced by previous and
        /// next points.
        /// </summary>
        /// <param name="courseDefinition">The <see cref="CourseDefinition"/> to get the paths from.</param>
        /// <returns>The array of paths which can be referenced.</returns>
        protected override IList<GravityPath> GetPathReferenceList(CourseDefinition courseDefinition)
        {
            return courseDefinition.GravityPaths;
        }
    }
}

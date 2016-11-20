using System.Collections.Generic;
using Syroot.NintenTools.Byaml.Serialization;

namespace Syroot.NintenTools.MarioKart8.Courses
{
    /// <summary>
    /// Represents a point of a <see cref="GlidePath"/>.
    /// </summary>
    [ByamlObject]
    public class GlidePathPoint : PathPointBase<GlidePath, GlidePathPoint>
    {
        // ---- PROPERTIES ---------------------------------------------------------------------------------------------

        /// <summary>
        /// Gets or sets a value indicating whether the driver is pulled as if shot through a cannon.
        /// </summary>
        [ByamlMember]
        public bool Cannon { get; set; }

        // ---- METHODS (PROTECTED) ------------------------------------------------------------------------------------

        /// <summary>
        /// Returns the array of paths in the <see cref="CourseDefinition"/> which can be referenced by previous and
        /// next points.
        /// </summary>
        /// <param name="courseDefinition">The <see cref="CourseDefinition"/> to get the paths from.</param>
        /// <returns>The array of paths which can be referenced.</returns>
        protected override IList<GlidePath> GetPathReferenceList(CourseDefinition courseDefinition)
        {
            return courseDefinition.GlidePaths;
        }
    }
}

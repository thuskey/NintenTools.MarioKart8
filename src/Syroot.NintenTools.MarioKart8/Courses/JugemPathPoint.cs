using System;
using System.Collections.Generic;
using Syroot.NintenTools.Byaml;

namespace Syroot.NintenTools.MarioKart8.Courses
{
    /// <summary>
    /// Represents a point of a <see cref="JugemPath"/>.
    /// </summary>
    public class JugemPathPoint : PathPoint<JugemPath, JugemPathPoint>
    {
        // ---- METHODS (PROTECTED) ------------------------------------------------------------------------------------

        /// <summary>
        /// Returns the array of paths in the <see cref="CourseDefinition"/> which can be referenced by previous and
        /// next points.
        /// </summary>
        /// <param name="courseDefinition">The <see cref="CourseDefinition"/> to get the paths from.</param>
        /// <returns>The array of paths which can be referenced.</returns>
        protected override IList<JugemPath> GetPathReferenceList(CourseDefinition courseDefinition)
        {
            return courseDefinition.JugemPaths;
        }
    }
}

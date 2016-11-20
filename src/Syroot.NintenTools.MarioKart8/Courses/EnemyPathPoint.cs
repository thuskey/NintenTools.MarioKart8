using System.Collections.Generic;
using Syroot.NintenTools.Byaml.Serialization;

namespace Syroot.NintenTools.MarioKart8.Courses
{
    /// <summary>
    /// Represents a point of an <see cref="EnemyPath"/>.
    /// </summary>
    [ByamlObject]
    public class EnemyPathPoint : PathPointBase<EnemyPath, EnemyPathPoint>
    {
        // ---- PROPERTIES ---------------------------------------------------------------------------------------------

        /// <summary>
        /// Gets or sets an unknown battle flag.
        /// </summary>
        [ByamlMember]
        public int BattleFlag { get; set; }

        /// <summary>
        /// Gets or sets an unknown point direction.
        /// </summary>
        [ByamlMember]
        public int PathDir { get; set; }

        /// <summary>
        /// Gets or sets an unknown point priority.
        /// </summary>
        [ByamlMember]
        public int Priority { get; set; }

        // ---- METHODS (PROTECTED) ------------------------------------------------------------------------------------

        /// <summary>
        /// Returns the array of paths in the <see cref="CourseDefinition"/> which can be referenced by previous and
        /// next points.
        /// </summary>
        /// <param name="courseDefinition">The <see cref="CourseDefinition"/> to get the paths from.</param>
        /// <returns>The array of paths which can be referenced.</returns>
        protected override IList<EnemyPath> GetPathReferenceList(CourseDefinition courseDefinition)
        {
            return courseDefinition.EnemyPaths;
        }
    }
}
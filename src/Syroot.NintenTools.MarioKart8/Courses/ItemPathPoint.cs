using System.Collections.Generic;
using Syroot.NintenTools.Byaml.Serialization;

namespace Syroot.NintenTools.MarioKart8.Courses
{
    /// <summary>
    /// Represents a point of an <see cref="ItemPath"/>.
    /// </summary>
    [ByamlObject]
    public class ItemPathPoint : PathPointBase<ItemPath, ItemPathPoint>
    {
        // ---- PROPERTIES ---------------------------------------------------------------------------------------------

        /// <summary>
        /// Gets or sets a value possibly indicating whether the item is allowed to move above the original path.
        /// </summary>
        [ByamlMember]
        public int Hover { get; set; }

        /// <summary>
        /// Gets or sets an unknown priority.
        /// </summary>
        [ByamlMember]
        public int ItemPriority { get; set; }

        /// <summary>
        /// Gets or sets a value indicating an unknown search area.
        /// </summary>
        [ByamlMember]
        public int SearchArea { get; set; }

        // ---- METHODS (PROTECTED) ------------------------------------------------------------------------------------

        /// <summary>
        /// Returns the array of paths in the <see cref="CourseDefinition"/> which can be referenced by previous and
        /// next points.
        /// </summary>
        /// <param name="courseDefinition">The <see cref="CourseDefinition"/> to get the paths from.</param>
        /// <returns>The array of paths which can be referenced.</returns>
        protected override IList<ItemPath> GetPathReferenceList(CourseDefinition courseDefinition)
        {
            return courseDefinition.ItemPaths;
        }
    }
}

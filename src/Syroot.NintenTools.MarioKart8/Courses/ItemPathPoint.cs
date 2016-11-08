using System;
using System.Collections.Generic;
using Syroot.NintenTools.Byaml;

namespace Syroot.NintenTools.MarioKart8.Courses
{
    /// <summary>
    /// Represents a point of an <see cref="ItemPath"/>.
    /// </summary>
    public class ItemPathPoint : PathPointBase<ItemPath, ItemPathPoint>
    {
        // ---- PROPERTIES ---------------------------------------------------------------------------------------------

        /// <summary>
        /// Gets or sets a value possibly indicating whether the item is allowed to move above the original path.
        /// </summary>
        public int Hover { get; set; }

        /// <summary>
        /// Gets or sets an unknown priority.
        /// </summary>
        public int ItemPriority { get; set; }

        /// <summary>
        /// Gets or sets a value indicating an unknown search area.
        /// </summary>
        public int SearchArea { get; set; }

        // ---- METHODS (PUBLIC) ---------------------------------------------------------------------------------------

        /// <summary>
        /// Reads the data from the given dynamic BYAML node into the instance.
        /// </summary>
        /// <param name="node">The dynamic BYAML node to deserialize.</param>
        /// <returns>The instance itself.</returns>
        public override dynamic DeserializeByaml(dynamic node)
        {
            base.DeserializeByaml((IDictionary<string, dynamic>)node);
            Hover = node["Hover"];
            ItemPriority = node["ItemPriority"];
            SearchArea = node["SearchArea"];
            return this;
        }

        /// <summary>
        /// Creates a dynamic BYAML node from the instance's data.
        /// </summary>
        /// <returns>The dynamic BYAML node.</returns>
        public override dynamic SerializeByaml()
        {
            dynamic node = base.SerializeByaml();
            node["Hover"] = Hover;
            node["ItemPriority"] = ItemPriority;
            node["SearchArea"] = SearchArea;
            return node;
        }
        
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

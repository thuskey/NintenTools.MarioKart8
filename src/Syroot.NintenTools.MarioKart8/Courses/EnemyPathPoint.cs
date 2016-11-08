using System.Collections.Generic;

namespace Syroot.NintenTools.MarioKart8.Courses
{
    /// <summary>
    /// Represents a point of an <see cref="EnemyPath"/>.
    /// </summary>
    public class EnemyPathPoint : PathPointBase<EnemyPath, EnemyPathPoint>
    {
        // ---- PROPERTIES ---------------------------------------------------------------------------------------------

        /// <summary>
        /// Gets or sets an unknown battle flag.
        /// </summary>
        public int BattleFlag { get; set; }

        /// <summary>
        /// Gets or sets an unknown point direction.
        /// </summary>
        public int PathDir { get; set; }

        /// <summary>
        /// Gets or sets an unknown point priority.
        /// </summary>
        public int Priority { get; set; }

        // ---- METHODS (PUBLIC) ---------------------------------------------------------------------------------------

        /// <summary>
        /// Reads the data from the given dynamic BYAML node into the instance.
        /// </summary>
        /// <param name="node">The dynamic BYAML node to deserialize.</param>
        public override void DeserializeByaml(dynamic node)
        {
            base.DeserializeByaml((IDictionary<string, dynamic>)node);
            BattleFlag = node["BattleFlag"];
            PathDir = node["PathDir"];
            Priority = node["Priority"];
        }

        /// <summary>
        /// Creates a dynamic BYAML node from the instance's data.
        /// </summary>
        /// <returns>The dynamic BYAML node.</returns>
        public override dynamic SerializeByaml()
        {
            dynamic node = base.SerializeByaml();
            node["BattleFlag"] = BattleFlag;
            node["PathDir"] = PathDir;
            node["Priority"] = Priority;
            return node;
        }

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
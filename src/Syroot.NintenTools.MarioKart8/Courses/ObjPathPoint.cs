using System.Collections.Generic;
using Syroot.NintenTools.Byaml;

namespace Syroot.NintenTools.MarioKart8.Courses
{
    /// <summary>
    /// Represents a point of an <see cref="ObjPath"/>.
    /// </summary>
    public class ObjPathPoint : PathPointBase<ObjPath, ObjPathPoint>
    {
        // ---- PROPERTIES ---------------------------------------------------------------------------------------------

        /// <summary>
        /// Gets or sets an index into the points of the parents <see cref="ByamlPath"/>.
        /// </summary>
        public int PathIndex { get; set; }

        /// <summary>
        /// Gets or sets the first parameter.
        /// </summary>
        public float Prm1 { get; set; }

        /// <summary>
        /// Gets or sets the second parameter.
        /// </summary>
        public float Prm2 { get; set; }

        // ---- METHODS (PUBLIC) ---------------------------------------------------------------------------------------

        /// <summary>
        /// Reads the data from the given dynamic BYAML node into the instance.
        /// </summary>
        /// <param name="node">The dynamic BYAML node to deserialize.</param>
        /// <returns>The instance itself.</returns>
        public override dynamic DeserializeByaml(dynamic node)
        {
            base.DeserializeByaml((IDictionary<string, dynamic>)node);
            PathIndex = node["Index"];
            Prm1 = node["prm1"];
            Prm2 = node["prm2"];
            return this;
        }

        /// <summary>
        /// Creates a dynamic BYAML node from the instance's data.
        /// </summary>
        /// <returns>The dynamic BYAML node.</returns>
        public override dynamic SerializeByaml()
        {
            dynamic node = base.SerializeByaml();
            node["Index"] = PathIndex;
            node["prm1"] = Prm1;
            node["prm2"] = Prm2;
            return node;
        }
        
        // ---- METHODS (PROTECTED) ------------------------------------------------------------------------------------

        /// <summary>
        /// Returns the array of paths in the <see cref="CourseDefinition"/> which can be referenced by previous and
        /// next points.
        /// </summary>
        /// <param name="courseDefinition">The <see cref="CourseDefinition"/> to get the paths from.</param>
        /// <returns>The array of paths which can be referenced.</returns>
        protected override IList<ObjPath> GetPathReferenceList(CourseDefinition courseDefinition)
        {
            return courseDefinition.ObjPaths;
        }
    }
}

using System;
using System.Collections.Generic;
using Syroot.NintenTools.Byaml;
using Syroot.NintenTools.Maths;

namespace Syroot.NintenTools.MarioKart8.Courses
{
    /// <summary>
    /// Represents a point of a <see cref="Path"/>.
    /// </summary>
    public class PathPoint : PathPointBase<Path, PathPoint>
    {
        // ---- PROPERTIES ---------------------------------------------------------------------------------------------

        /// <summary>
        /// Gets or sets the first parameter.
        /// </summary>
        public float Prm1 { get; set; }

        /// <summary>
        /// Gets or sets the second parameter.
        /// </summary>
        public float Prm2 { get; set; }

        /// <summary>
        /// Gets or sets the list of tangential smoothing points (must be exactly 2).
        /// </summary>
        public List<Vector3F> ControlPoints { get; set; }

        // ---- METHODS (PUBLIC) ---------------------------------------------------------------------------------------

        /// <summary>
        /// Reads the data from the given dynamic BYAML node into the instance.
        /// </summary>
        /// <param name="node">The dynamic BYAML node to deserialize.</param>
        public override void DeserializeByaml(dynamic node)
        {
            base.DeserializeByaml((IDictionary<string, dynamic>)node);
            Prm1 = node["prm1"];
            Prm2 = node["prm2"];

            // Deserialize the two control points.
            ControlPoints = new List<Vector3F>();
            ControlPoints.Add(new Vector3F(node["ControlPoints"][0]));
            ControlPoints.Add(new Vector3F(node["ControlPoints"][1]));
        }

        /// <summary>
        /// Creates a dynamic BYAML node from the instance's data.
        /// </summary>
        /// <returns>The dynamic BYAML node.</returns>
        public override dynamic SerializeByaml()
        {
            dynamic node = base.SerializeByaml();
            node["prm1"] = Prm1;
            node["prm2"] = Prm2;
            node["ControlPoints"] = ControlPoints;
            return node;
        }
        
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

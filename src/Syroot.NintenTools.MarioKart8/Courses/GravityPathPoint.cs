using System;
using System.Collections.Generic;
using Syroot.NintenTools.Byaml;

namespace Syroot.NintenTools.MarioKart8.Courses
{
    /// <summary>
    /// Represents a point of a <see cref="GravityPath"/>.
    /// </summary>
    public class GravityPathPoint : PathPointBase<GravityPath, GravityPathPoint>
    {
        // ---- PROPERTIES ---------------------------------------------------------------------------------------------

        /// <summary>
        /// Gets or sets a distance possibly controlling how far from the ground the camera is positioned.
        /// </summary>
        public int CameraHeight { get; set; }

        /// <summary>
        /// Gets or sets a value possibly indicating whether this gravity path is only effective when gliding.
        /// </summary>
        public bool GlideOnly { get; set; }

        /// <summary>
        /// Gets or sets an unknown value.
        /// </summary>
        public bool Transform { get; set; }

        // ---- METHODS (PUBLIC) ---------------------------------------------------------------------------------------

        /// <summary>
        /// Reads the data from the given dynamic BYAML node into the instance.
        /// </summary>
        /// <param name="node">The dynamic BYAML node to deserialize.</param>
        /// <returns>The instance itself.</returns>
        public override dynamic DeserializeByaml(dynamic node)
        {
            base.DeserializeByaml((IDictionary<string, dynamic>)node);
            CameraHeight = node["CameraHeight"];
            GlideOnly = node["GlideOnly"];
            Transform = node["Transform"];
            return this;
        }

        /// <summary>
        /// Creates a dynamic BYAML node from the instance's data.
        /// </summary>
        /// <returns>The dynamic BYAML node.</returns>
        public override dynamic SerializeByaml()
        {
            dynamic node = base.SerializeByaml();
            node["CameraHeight"] = CameraHeight;
            node["GlideOnly"] = GlideOnly;
            node["Transform"] = Transform;
            return node;
        }
        
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

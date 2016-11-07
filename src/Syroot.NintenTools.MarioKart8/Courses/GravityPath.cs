using System.Collections.Generic;
using Syroot.NintenTools.Byaml;

namespace Syroot.NintenTools.MarioKart8.Courses
{
    /// <summary>
    /// Represents a path controlling the gravity direction of the course.
    /// </summary>
    public class GravityPath : Path<GravityPath, GravityPathPoint>
    {
        // ---- MEMBERS ------------------------------------------------------------------------------------------------

        private List<int> _gCameraPathIndices;

        // ---- PROPERTIES ---------------------------------------------------------------------------------------------

        /// <summary>
        /// Gets or sets the list of <see cref="GCameraPath"/> instances this gravity path uses.
        /// </summary>
        public List<GCameraPath> GCameraPaths { get; set; }

        // ---- METHODS (PUBLIC) ---------------------------------------------------------------------------------------

        /// <summary>
        /// Reads the data from the given dynamic BYAML node into the instance.
        /// </summary>
        /// <param name="node">The dynamic BYAML node to deserialize.</param>
        public override void DeserializeByaml(dynamic node)
        {
            base.DeserializeByaml((IDictionary<string, dynamic>)node);
            _gCameraPathIndices = ByamlFile.GetList<int>(ByamlFile.GetValue(node, "GravityPath_GCameraPath"));
        }

        /// <summary>
        /// Creates a dynamic BYAML node from the instance's data.
        /// </summary>
        /// <returns>The dynamic BYAML node.</returns>
        public override dynamic SerializeByaml()
        {
            dynamic node = base.SerializeByaml();
            ByamlFile.SetValue(node, "GravityPath_GCameraPath", _gCameraPathIndices);
            return node;
        }

        /// <summary>
        /// Allows references between BYAML instances to be resolved to provide real instances instead of the raw values
        /// in the BYAML.
        /// </summary>
        /// <param name="courseDefinition">The <see cref="CourseDefinition"/> providing the objects.</param>
        public override void DeserializeReferences(CourseDefinition courseDefinition)
        {
            // Solve the point references.
            base.DeserializeReferences(courseDefinition);

            // Solve the GCamera path references.
            if (_gCameraPathIndices != null)
            {
                GCameraPaths = new List<GCameraPath>();
                foreach (int index in _gCameraPathIndices)
                {
                    GCameraPaths.Add(courseDefinition.GCameraPaths[index]);
                }
            }
        }

        /// <summary>
        /// Allows references between BYAML instances to be serialized into raw values stored in the BYAML.
        /// </summary>
        /// <param name="courseDefinition">The <see cref="CourseDefinition"/> providing the objects.</param>
        public override void SerializeReferences(CourseDefinition courseDefinition)
        {
            // Solve the point references.
            base.SerializeReferences(courseDefinition);

            // Solve the GCamera path references.
            if (GCameraPaths != null)
            {
                _gCameraPathIndices = new List<int>();
                foreach (GCameraPath path in GCameraPaths)
                {
                    _gCameraPathIndices.Add(courseDefinition.GCameraPaths.IndexOf(path));
                }
            }
        }
    }
}

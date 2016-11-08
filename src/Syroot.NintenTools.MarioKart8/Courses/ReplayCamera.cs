using System.Collections.Generic;
using Syroot.NintenTools.Byaml;

namespace Syroot.NintenTools.MarioKart8.Courses
{
    /// <summary>
    /// Represents the camera movements and cuts triggered by drivers in the replay video.
    /// </summary>
    public class ReplayCamera : PrmObject
    {
        // ---- MEMBERS ------------------------------------------------------------------------------------------------

        private int? _pathIndex;

        // ---- PROPERTIES ---------------------------------------------------------------------------------------------

        /// <summary>
        /// Gets or sets an unknown angle on the X axis.
        /// </summary>
        public int AngleX { get; set; }

        /// <summary>
        /// Gets or sets an unknown angle on the Y axis.
        /// </summary>
        public int AngleY { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the field of view angle is computed in accordance to the distance to
        /// the driver who triggered the camera.
        /// </summary>
        public bool AutoFovy { get; set; }

        /// <summary>
        /// Gets or sets an unknown camera type.
        /// </summary>
        public int Type { get; set; }
        
        /// <summary>
        /// Gets or sets the <see cref="Path"/> this camera moves along.
        /// </summary>
        public Path Path { get; set; }

        /// <summary>
        /// Gets or sets a value indicating the blur effect for far-away geometry.
        /// </summary>
        public int DepthOfField { get; set; }

        /// <summary>
        /// Gets or sets the distance of the camera to the driver.
        /// </summary>
        public int Distance { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to lock the view target onto the driver who triggered the camera.
        /// </summary>
        public bool Follow { get; set; }

        /// <summary>
        /// Gets or sets the field of view angle possibly at the start of the move.
        /// </summary>
        public int Fovy { get; set; }

        /// <summary>
        /// Gets or sets the field of view angle possibly at the end of the move.
        /// </summary>
        public int Fovy2 { get; set; }
        
        /// <summary>
        /// Gets or sets a speed possibly controlling how the FoV change is done.
        /// </summary>
        public int FovySpeed { get; set; }

        /// <summary>
        /// Gets or sets the group this camera belongs to.
        /// </summary>
        public int Group { get; set; }

        /// <summary>
        /// Gets or sets the rotation around the X axis.
        /// </summary>
        public int Pitch { get; set; }

        /// <summary>
        /// Gets or sets the rotation around the Y axis.
        /// </summary>
        public int Yaw { get; set; }

        /// <summary>
        /// Gets or sets the rotation around the Z axis.
        /// </summary>
        public int Roll { get; set; }

        // ---- METHODS (PUBLIC) ---------------------------------------------------------------------------------------

        /// <summary>
        /// Reads the data from the given dynamic BYAML node into the instance.
        /// </summary>
        /// <param name="node">The dynamic BYAML node to deserialize.</param>
        /// <returns>The instance itself.</returns>
        public override dynamic DeserializeByaml(dynamic node)
        {
            base.DeserializeByaml((IDictionary<string, dynamic>)node);
            AngleX = node["AngleX"];
            AngleY = node["AngleY"];
            AutoFovy = node["AutoFovy"];
            Type = node["CameraType"];
            _pathIndex = ByamlFile.GetValue(node, "Camera_Path");
            DepthOfField = node["DepthOfField"];
            Follow = node["Follow"];
            Fovy = node["Fovy"];
            Fovy2 = node["Fovy2"];
            FovySpeed = node["FovySpeed"];
            Group = node["Group"];
            Pitch = node["Pitch"];
            Yaw = node["Yaw"];
            Roll = node["Roll"];
            return this;
        }

        /// <summary>
        /// Creates a dynamic BYAML node from the instance's data.
        /// </summary>
        /// <returns>The dynamic BYAML node.</returns>
        public override dynamic SerializeByaml()
        {
            IDictionary<string, dynamic> node = base.SerializeByaml();
            node["AngleX"] = AngleX;
            node["AngleY"] = AngleY;
            node["AutoFovy"] = AutoFovy;
            node["CameraType"] = Type;
            node["Camera_Path"] = _pathIndex;
            node["DepthOfField"] = DepthOfField;
            node["Follow"] = Follow;
            node["Fovy"] = Fovy;
            node["Fovy2"] = Fovy2;
            node["FovySpeed"] = FovySpeed;
            node["Group"] = Group;
            node["Pitch"] = Pitch;
            node["Yaw"] = Yaw;
            node["Roll"] = Roll;
            return node;
        }

        /// <summary>
        /// Allows references between BYAML instances to be resolved to provide real instances
        /// instead of the raw values in the BYAML.
        /// </summary>
        /// <param name="courseDefinition">The <see cref="CourseDefinition"/> providing the objects.</param>
        public void DeserializeReferences(CourseDefinition courseDefinition)
        {
            Path = _pathIndex == null ? null : courseDefinition.Paths[_pathIndex.Value];
        }

        /// <summary>
        /// Allows references between BYAML instances to be serialized into raw values stored in the
        /// BYAML.
        /// </summary>
        /// <param name="courseDefinition">The <see cref="CourseDefinition"/> providing the objects.</param>
        public void SerializeReferences(CourseDefinition courseDefinition)
        {
            _pathIndex = Path == null ? null : (int?)courseDefinition.Paths.IndexOf(Path);
        }
    }
}

using System.Collections.Generic;
using Syroot.NintenTools.Byaml;

namespace Syroot.NintenTools.MarioKart8.Courses
{
    /// <summary>
    /// Represents a point of a <see cref="LapPath"/>.
    /// </summary>
    public class LapPathPoint : PathPointBase<LapPath, LapPathPoint>
    {
        // ---- PROPERTIES ---------------------------------------------------------------------------------------------

        /// <summary>
        /// Gets or sets a value possibly indicating whether this is a required point to complete a lap.
        /// </summary>
        public int CheckPoint { get; set; }

        /// <summary>
        /// Gets or sets a possible index into a <see cref="Clip"/> instance.
        /// </summary>
        public int? ClipIndex { get; set; }
        
        /// <summary>
        /// Gets or sets a possible index into a <see cref="Clip"/> instance. DLC courses use this index, stored in
        /// &quot;ClipNum&quot; instead of &quot;ClipIdx&quot;.
        /// </summary>
        public int? ClipIndexDlc { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether headlights are turned on on this part of the path when
        /// <see cref="CourseDefinition.HeadLight"/> is set to <see cref="CourseHeadLight.ByLapPath"/>.
        /// </summary>
        public bool HeadLightSW { get; set; }

        /// <summary>
        /// Gets or sets a value possibly indicating whether this point increases the lap count.
        /// </summary>
        public int LapCheck { get; set; }

        /// <summary>
        /// Gets or sets the field of view angle of the camera at this part of the path.
        /// </summary>
        public int MapCameraFovy { get; set; }

        /// <summary>
        /// Gets or sets the height distance of the camera at this part of the path.
        /// </summary>
        public int MapCameraY { get; set; }

        /// <summary>
        /// Gets or sets a value handling a <see cref="ReturnPoint"/> or -1 if there is no return point.
        /// </summary>
        public int ReturnPosition { get; set; }

        /// <summary>
        /// Gets or sets an index to a sound effect played at this part of the path or -1 if there is no additional
        /// effect.
        /// </summary>
        public int SoundSW { get; set; }

        // ---- METHODS (PUBLIC) ---------------------------------------------------------------------------------------

        /// <summary>
        /// Reads the data from the given dynamic BYAML node into the instance.
        /// </summary>
        /// <param name="node">The dynamic BYAML node to deserialize.</param>
        /// <returns>The instance itself.</returns>
        public override dynamic DeserializeByaml(dynamic node)
        {
            base.DeserializeByaml((IDictionary<string, dynamic>)node);
            CheckPoint = node["CheckPoint"];
            ClipIndex = ByamlFile.GetValue(node, "ClipIdx");
            ClipIndexDlc = ByamlFile.GetValue(node, "ClipNum");
            HeadLightSW = node["HeadLightSW"];
            LapCheck = node["LapCheck"];
            MapCameraFovy = node["MapCameraFovy"];
            MapCameraY = node["MapCameraY"];
            ReturnPosition = node["ReturnPosition"];
            SoundSW = node["SoundSW"];
            return this;
        }

        /// <summary>
        /// Creates a dynamic BYAML node from the instance's data.
        /// </summary>
        /// <returns>The dynamic BYAML node.</returns>
        public override dynamic SerializeByaml()
        {
            dynamic node = base.SerializeByaml();
            node["CheckPoint"] = CheckPoint;
            ByamlFile.SetValue(node, "ClipIdx", ClipIndex);
            ByamlFile.SetValue(node, "ClipNum", ClipIndexDlc);
            node["HeadLightSW"] = HeadLightSW;
            node["LapCheck"] = LapCheck;
            node["MapCameraFovy"] = MapCameraFovy;
            node["MapCameraY"] = MapCameraY;
            node["ReturnPosition"] = ReturnPosition;
            node["SoundSW"] = SoundSW;
            return node;
        }
        
        // ---- METHODS (PROTECTED) ------------------------------------------------------------------------------------

        /// <summary>
        /// Returns the array of paths in the <see cref="CourseDefinition"/> which can be referenced by previous and
        /// next points.
        /// </summary>
        /// <param name="courseDefinition">The <see cref="CourseDefinition"/> to get the paths from.</param>
        /// <returns>The array of paths which can be referenced.</returns>
        protected override IList<LapPath> GetPathReferenceList(CourseDefinition courseDefinition)
        {
            return courseDefinition.LapPaths;
        }

        /// <summary>
        /// Allows references between BYAML instances to be resolved to provide real instances instead of the raw values
        /// in the BYAML.
        /// </summary>
        /// <param name="courseDefinition">The <see cref="CourseDefinition"/> providing the objects.</param>
        public override void DeserializeReferences(CourseDefinition courseDefinition)
        {
            base.DeserializeReferences(courseDefinition);
            // TODO: Find out what ClipIndex references exactly and resolve the reference.
        }

        /// <summary>
        /// Allows references between BYAML instances to be serialized into raw values stored in the BYAML.
        /// </summary>
        /// <param name="courseDefinition">The <see cref="CourseDefinition"/> providing the objects.</param>
        public override void SerializeReferences(CourseDefinition courseDefinition)
        {
            base.SerializeReferences(courseDefinition);
            // TODO: Find out what ClipIndex references exactly and resolve the reference.
        }
    }
}

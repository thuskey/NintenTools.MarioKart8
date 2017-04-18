using System.Collections.Generic;
using Syroot.NintenTools.Byaml.Serialization;

namespace Syroot.NintenTools.MarioKart8.Courses
{
    /// <summary>
    /// Represents a point of a <see cref="LapPath"/>.
    /// </summary>
    [ByamlObject]
    public class LapPathPoint : PathPointBase<LapPath, LapPathPoint>
    {
        // ---- PROPERTIES ---------------------------------------------------------------------------------------------

        /// <summary>
        /// Gets or sets a value possibly indicating whether this is a required point to complete a lap.
        /// </summary>
        [ByamlMember]
        public int CheckPoint { get; set; }

        /// <summary>
        /// Gets or sets a possible index into a <see cref="Clip"/> instance.
        /// </summary>
        [ByamlMember("ClipIdx", Optional = true)]
        public int? ClipIndex { get; set; }

        /// <summary>
        /// Gets or sets a possible index into a <see cref="Clip"/> instance. DLC courses use this index, stored in
        /// &quot;ClipNum&quot; instead of &quot;ClipIdx&quot;.
        /// </summary>
        [ByamlMember("ClipNum", Optional = true)]
        public int? ClipIndexDlc { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether headlights are turned on on this part of the path when
        /// <see cref="CourseDefinition.HeadLight"/> is set to <see cref="CourseHeadLight.ByLapPath"/>.
        /// </summary>
        [ByamlMember]
        public bool HeadLightSW { get; set; }

        /// <summary>
        /// Gets or sets a value possibly indicating whether this point increases the lap count.
        /// </summary>
        [ByamlMember]
        public int LapCheck { get; set; }

        /// <summary>
        /// Gets or sets the field of view angle of the camera at this part of the path.
        /// </summary>
        [ByamlMember]
        public int MapCameraFovy { get; set; }

        /// <summary>
        /// Gets or sets the height distance of the camera at this part of the path.
        /// </summary>
        [ByamlMember]
        public int MapCameraY { get; set; }

        /// <summary>
        /// Gets or sets a value handling a <see cref="ReturnPoint"/> or -1 if there is no return point.
        /// </summary>
        [ByamlMember]
        public int ReturnPosition { get; set; }

        /// <summary>
        /// Gets or sets an index to a sound effect played at this part of the path or -1 if there is no additional
        /// effect.
        /// </summary>
        [ByamlMember]
        public int SoundSW { get; set; }
        
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
        /// Allows references of course data objects to be resolved to provide real instances instead of the raw values
        /// in the BYAML.
        /// </summary>
        /// <param name="courseDefinition">The <see cref="CourseDefinition"/> providing the objects.</param>
        public override void DeserializeReferences(CourseDefinition courseDefinition)
        {
            base.DeserializeReferences(courseDefinition);
            // TODO: Find out what ClipIndex references exactly and resolve the reference.
        }

        /// <summary>
        /// Allows references between course objects to be serialized into raw values stored in the BYAML.
        /// </summary>
        /// <param name="courseDefinition">The <see cref="CourseDefinition"/> providing the objects.</param>
        public override void SerializeReferences(CourseDefinition courseDefinition)
        {
            base.SerializeReferences(courseDefinition);
            // TODO: Find out what ClipIndex references exactly and resolve the reference.
        }
    }
}

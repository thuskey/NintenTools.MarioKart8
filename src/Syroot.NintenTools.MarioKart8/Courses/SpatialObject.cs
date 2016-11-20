using Syroot.NintenTools.Byaml.Serialization;

namespace Syroot.NintenTools.MarioKart8.Courses
{
    /// <summary>
    /// Represents an object on a course which is translated, rotated and scaled in space.
    /// </summary>
    [ByamlObject]
    public abstract class SpatialObject : UnitObject
    {
        // ---- PROPERTIES ---------------------------------------------------------------------------------------------

        /// <summary>
        /// Gets or sets the rotation of the object in radians.
        /// </summary>
        [ByamlMember]
        public ByamlVector3F Rotate { get; set; }

        /// <summary>
        /// Gets or sets the scale of the object.
        /// </summary>
        [ByamlMember]
        public ByamlVector3F Scale { get; set; }

        /// <summary>
        /// Gets or sets the position at which the object is placed.
        /// </summary>
        [ByamlMember]
        public ByamlVector3F Translate { get; set; }
    }
}

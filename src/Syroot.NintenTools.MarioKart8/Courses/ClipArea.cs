using Syroot.NintenTools.Byaml.Serialization;

namespace Syroot.NintenTools.MarioKart8.Courses
{
    /// <summary>
    /// Represents an clip area controlling model clipping.
    /// </summary>
    [ByamlObject]
    public class ClipArea : PrmObject
    {
        // ---- PROPERTIES ---------------------------------------------------------------------------------------------

        /// <summary>
        /// Gets or set the shape the outer form of this clip area spans. Only <see cref="AreaShape.Cube"/> is known for
        /// these to be valid.
        /// </summary>
        [ByamlMember]
        public AreaShape AreaShape { get; set; }

        /// <summary>
        /// Gets or sets the action taken for this clip area. Only <see cref="AreaType.Clip"/> is valid for clip areas.
        /// </summary>
        [ByamlMember]
        public AreaType AreaType { get; set; }
    }
}

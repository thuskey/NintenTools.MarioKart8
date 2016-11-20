using Syroot.NintenTools.Byaml.Serialization;

namespace Syroot.NintenTools.MarioKart8.Courses
{
    /// <summary>
    /// Represents an effect area controlling visual effects inside of it.
    /// </summary>
    [ByamlObject]
    public class EffectArea : PrmObject
    {
        // ---- PROPERTIES ---------------------------------------------------------------------------------------------

        /// <summary>
        /// Gets or sets the index of the effect played in this area.
        /// </summary>
        [ByamlMember]
        public int EffectSW { get; set; }
    }
}

using Syroot.NintenTools.Byaml.Serialization;

namespace Syroot.NintenTools.MarioKart8.Courses
{
    /// <summary>
    /// Represents a tangentially smoothed path used for different aspects in the game.
    /// </summary>
    [ByamlObject]
    public class Path : PathBase<Path, PathPoint>
    {
        // ---- PROPERTIES ---------------------------------------------------------------------------------------------
        
        /// <summary>
        /// Gets or sets a value possibly indicating whether Objs using this path are dispoed after reaching the end
        /// of the (non-closed) path.
        /// </summary>
        [ByamlMember]
        public bool Delete { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this path is circular and that the last point connects to the first.
        /// </summary>
        [ByamlMember]
        public bool IsClosed { get; set; }

        /// <summary>
        /// Gets or sets an unknown rail type.
        /// </summary>
        [ByamlMember]
        public int RailType { get; set; }
    }
}

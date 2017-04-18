using System.Collections.Generic;
using Syroot.NintenTools.Byaml.Serialization;

namespace Syroot.NintenTools.MarioKart8.Courses
{
    /// <summary>
    /// Represents the clip pattern node in a course definition file.
    /// </summary>
    [ByamlObject]
    public class ClipPattern
    {
        // ---- PROPERTIES ---------------------------------------------------------------------------------------------

        /// <summary>
        /// Gets or sets the unknown &quot;StartOnly&quot; value.
        /// </summary>
        [ByamlMember(Optional = true)]
        public int? StartOnly { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="AreaFlag"/> instance.
        /// </summary>
        [ByamlMember]
        public List<AreaFlag> AreaFlag { get; set; }
    }
}

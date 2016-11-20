using System.Collections.Generic;
using Syroot.NintenTools.Byaml.Serialization;

namespace Syroot.NintenTools.MarioKart8.Courses
{
    /// <summary>
    /// Represents the &quot;AreaFlag&quot; list of 4 integer values inside of a <see cref="ClipPattern"/>.
    /// </summary>
    [ByamlObject]
    public class AreaFlag : List<int>
    {
    }
}
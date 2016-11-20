using System.Collections.Generic;
using Syroot.NintenTools.Byaml.Serialization;

namespace Syroot.NintenTools.MarioKart8.Courses
{
    /// <summary>
    /// Represents an element of the Clip array, which consists of 4 integer values.
    /// </summary>
    [ByamlObject]
    public class Clip : List<int>
    {
    }
}

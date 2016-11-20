using System.Collections.Generic;
using Syroot.NintenTools.Byaml.Serialization;

namespace Syroot.NintenTools.MarioKart8.Courses
{
    /// <summary>
    /// Represents a path a driver is pulled along.
    /// </summary>
    [ByamlObject]
    public class PullPath : PathBase<PullPath, PullPathPoint>
    {
    }
}

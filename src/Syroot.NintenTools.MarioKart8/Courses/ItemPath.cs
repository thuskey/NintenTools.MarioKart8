using System.Collections.Generic;
using Syroot.NintenTools.Byaml.Serialization;

namespace Syroot.NintenTools.MarioKart8.Courses
{
    /// <summary>
    /// Represents a path an item like a red shell takes.
    /// </summary>
    [ByamlObject]
    public class ItemPath : PathBase<ItemPath, ItemPathPoint>
    {
    }
}

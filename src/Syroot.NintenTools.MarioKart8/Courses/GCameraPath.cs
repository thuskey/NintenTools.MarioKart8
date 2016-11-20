using Syroot.NintenTools.Byaml.Serialization;

namespace Syroot.NintenTools.MarioKart8.Courses
{
    /// <summary>
    /// Represents a path of the game camera.
    /// </summary>
    [ByamlObject]
    public class GCameraPath : PathBase<GCameraPath, GCameraPathPoint>
    {
    }
}

using System.Collections.Generic;

namespace Syroot.NintenTools.MarioKart8.Courses
{
    /// <summary>
    /// Represents a camera move played in the introductionary course video played at the start of offline races.
    /// </summary>
    public class IntroCamera : SpatialObject
    {
        // ---- PROPERTIES ---------------------------------------------------------------------------------------------

        /// <summary>
        /// Gets or sets the index of the camera in the intro camera array.
        /// </summary>
        public int Num { get; set; }

        /// <summary>
        /// Gets or sets the number of frames the camera is active.
        /// </summary>
        public int Time { get; set; }
        
        /// <summary>
        /// Gets or sets an unknown camera type.
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// Gets or sets a value referencing an unknown path property.
        /// </summary>
        public int AtPath { get; set; }

        // TODO: Check what kind of path is referenced.
        /// <summary>
        /// Gets or sets an index referencing an unknown path.
        /// </summary>
        public int Path { get; set; }

        /// <summary>
        /// Gets or sets the field of view angle possibly at the start of the move.
        /// </summary>
        public int FovY { get; set; }

        /// <summary>
        /// Gets or sets the field of view angle possibly at the end of the move.
        /// </summary>
        public int FovY2 { get; set; }

        /// <summary>
        /// Gets or sets a speed possibly controlling how the FoV change is done.
        /// </summary>
        public int FovYSpeed { get; set; }

        // ---- METHODS (PUBLIC) ---------------------------------------------------------------------------------------

        /// <summary>
        /// Reads the data from the given dynamic BYAML node into the instance.
        /// </summary>
        /// <param name="node">The dynamic BYAML node to deserialize.</param>
        public override void DeserializeByaml(dynamic node)
        {
            base.DeserializeByaml((IDictionary<string, dynamic>)node);
            Num = node["CameraNum"];
            Time = node["CameraTime"];
            AtPath = node["Camera_AtPath"];
            Path = node["Camera_Path"];
            FovY = node["Fovy"];
            FovY2 = node["Fovy2"];
            FovYSpeed = node["FovySpeed"];
        }

        /// <summary>
        /// Creates a dynamic BYAML node from the instance's data.
        /// </summary>
        /// <returns>The dynamic BYAML node.</returns>
        public override dynamic SerializeByaml()
        {
            IDictionary<string, dynamic> node = base.SerializeByaml();
            node["CameraNum"] = Num;
            node["CameraTime"] = Time;
            node["Camera_AtPath"] = AtPath;
            node["Camera_Path"] = Path;
            node["Fovy"] = FovY;
            node["Fovy2"] = FovY2;
            node["FovySpeed"] = FovYSpeed;
            return node;
        }
    }
}

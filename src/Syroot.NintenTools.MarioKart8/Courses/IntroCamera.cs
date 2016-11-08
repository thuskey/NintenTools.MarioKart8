using System;
using System.Collections.Generic;

namespace Syroot.NintenTools.MarioKart8.Courses
{
    /// <summary>
    /// Represents a camera move played in the introductionary course video played at the start of offline races.
    /// </summary>
    public class IntroCamera : SpatialObject, ICourseReferencable
    {
        // ---- MEMBERS ------------------------------------------------------------------------------------------------

        private int _pathIndex;

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
        
        /// <summary>
        /// Gets or sets a <see cref="Path"/> on which this camera moves along.
        /// </summary>
        public Path Path { get; set; }

        /// <summary>
        /// Gets or sets the field of view angle possibly at the start of the move.
        /// </summary>
        public int Fovy { get; set; }

        /// <summary>
        /// Gets or sets the field of view angle possibly at the end of the move.
        /// </summary>
        public int Fovy2 { get; set; }

        /// <summary>
        /// Gets or sets a speed possibly controlling how the FoV change is done.
        /// </summary>
        public int FovySpeed { get; set; }

        // ---- METHODS (PUBLIC) ---------------------------------------------------------------------------------------

        /// <summary>
        /// Reads the data from the given dynamic BYAML node into the instance.
        /// </summary>
        /// <param name="node">The dynamic BYAML node to deserialize.</param>
        /// <returns>The instance itself.</returns>
        public override dynamic DeserializeByaml(dynamic node)
        {
            base.DeserializeByaml((IDictionary<string, dynamic>)node);
            Num = node["CameraNum"];
            Time = node["CameraTime"];
            Type = node["CameraType"];
            AtPath = node["Camera_AtPath"];
            _pathIndex = node["Camera_Path"];
            Fovy = node["Fovy"];
            Fovy2 = node["Fovy2"];
            FovySpeed = node["FovySpeed"];
            return this;
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
            node["CameraType"] = Type;
            node["Camera_AtPath"] = AtPath;
            node["Camera_Path"] = _pathIndex;
            node["Fovy"] = Fovy;
            node["Fovy2"] = Fovy2;
            node["FovySpeed"] = FovySpeed;
            return node;
        }

        /// <summary>
        /// Allows references of course file objects to be resolved to provide real instances instead of the raw values
        /// in the BYAML.
        /// </summary>
        /// <param name="courseDefinition">The <see cref="CourseDefinition"/> providing the objects.</param>
        public void DeserializeReferences(CourseDefinition courseDefinition)
        {
            Path = courseDefinition.Paths[_pathIndex];
        }

        /// <summary>
        /// Allows references between course objects to be serialized into raw values stored in the BYAML.
        /// </summary>
        /// <param name="courseDefinition">The <see cref="CourseDefinition"/> providing the objects.</param>
        public void SerializeReferences(CourseDefinition courseDefinition)
        {
            _pathIndex = courseDefinition.Paths.IndexOf(Path);
        }
    }
}

using System.Collections.Generic;

namespace Syroot.NintenTools.MarioKart8.Courses
{
    /// <summary>
    /// Represents a tangentially smoothed path used for different aspects in the game.
    /// </summary>
    public class Path : PathBase<Path, PathPoint>
    {
        // ---- PROPERTIES ---------------------------------------------------------------------------------------------
        
        /// <summary>
        /// Gets or sets a value possibly indicating whether Objs using this path are dispoed after reaching the end
        /// of the (non-closed) path.
        /// </summary>
        public bool Delete { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this path is circular and that the last point connects to the first.
        /// </summary>
        public bool IsClosed { get; set; }

        /// <summary>
        /// Gets or sets an unknown rail type.
        /// </summary>
        public int RailType { get; set; }
        
        // ---- METHODS (PUBLIC) ---------------------------------------------------------------------------------------

        /// <summary>
        /// Reads the data from the given dynamic BYAML node into the instance.
        /// </summary>
        /// <param name="node">The dynamic BYAML node to deserialize.</param>
        public override void DeserializeByaml(dynamic node)
        {
            base.DeserializeByaml((IDictionary<string, dynamic>)node);
            Delete = node["Delete"];
            IsClosed = node["IsClosed"];
            RailType = node["RailType"];
        }

        /// <summary>
        /// Creates a dynamic BYAML node from the instance's data.
        /// </summary>
        /// <returns>The dynamic BYAML node.</returns>
        public override dynamic SerializeByaml()
        {
            dynamic node = base.SerializeByaml();
            node["Delete"] = Delete;
            node["IsClosed"] = IsClosed;
            node["RailType"] = RailType;
            return node;
        }
    }
}

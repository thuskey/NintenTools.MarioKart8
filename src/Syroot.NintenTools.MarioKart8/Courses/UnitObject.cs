using System.Collections.Generic;
using System.Diagnostics;
using Syroot.NintenTools.Byaml;

namespace Syroot.NintenTools.MarioKart8.Courses
{
    /// <summary>
    /// Represents an object in the course which can be referenced by its <see cref="UnitIdNum"/>.
    /// </summary>
    [DebuggerDisplay("UnitIdNum={UnitIdNum}")]
    public abstract class UnitObject : IByamlSerializable
    {
        // ---- PROPERTIES ---------------------------------------------------------------------------------------------

        /// <summary>
        /// Gets or sets a number identifying this object. Can be non-unique or 0 without any issues.
        /// </summary>
        public int UnitIdNum { get; set; }

        // ---- METHODS (PUBLIC) ---------------------------------------------------------------------------------------

        /// <summary>
        /// Reads the data from the given dynamic BYAML node into the instance.
        /// </summary>
        /// <param name="node">The dynamic BYAML node to deserialize.</param>
        public virtual void DeserializeByaml(dynamic node)
        {
            UnitIdNum = node["UnitIdNum"];
        }

        /// <summary>
        /// Creates a dynamic BYAML node from the instance's data.
        /// </summary>
        /// <returns>The dynamic BYAML node.</returns>
        public virtual dynamic SerializeByaml()
        {
            return new Dictionary<string, dynamic>
            {
                ["UnitIdNum"] = UnitIdNum
            };
        }
    }
}

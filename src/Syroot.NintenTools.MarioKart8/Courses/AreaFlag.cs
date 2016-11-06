using System.Collections.Generic;
using Syroot.NintenTools.Byaml;

namespace Syroot.NintenTools.MarioKart8.Courses
{
    /// <summary>
    /// Represents the &quot;AreaFlag&quot; node inside of a <see cref="ClipPattern"/>.
    /// </summary>
    public class AreaFlag : IByamlSerializable
    {
        // ---- PROPERTIES ---------------------------------------------------------------------------------------------

        /// <summary>
        /// Gets or sets a list holding lists of 4 unknown integers.
        /// </summary>
        public List<List<int>> Values { get; set; }

        // ---- METHODS (PUBLIC) ---------------------------------------------------------------------------------------

        /// <summary>
        /// Reads the data from the given dynamic BYAML node into the instance.
        /// </summary>
        /// <param name="node">The dynamic BYAML node to deserialize.</param>
        public void DeserializeByaml(dynamic node)
        {
            Values = new List<List<int>>();
            foreach (dynamic array in node)
            {
                Values.Add(ByamlFile.GetList<int>(array));
            }
        }

        /// <summary>
        /// Creates a dynamic BYAML node from the instance's data.
        /// </summary>
        /// <returns>The dynamic BYAML node.</returns>
        public dynamic SerializeByaml()
        {
            return Values;
        }
    }
}
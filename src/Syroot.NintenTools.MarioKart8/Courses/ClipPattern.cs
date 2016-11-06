using System.Collections.Generic;
using Syroot.NintenTools.Byaml;

namespace Syroot.NintenTools.MarioKart8.Courses
{
    /// <summary>
    /// Represents the clip pattern node in a course definition file.
    /// </summary>
    public class ClipPattern : IByamlSerializable
    {
        // ---- PROPERTIES ---------------------------------------------------------------------------------------------

        /// <summary>
        /// Gets or sets the unknown &quot;StartOnly&quot; value.
        /// </summary>
        public int StartOnly { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="AreaFlag"/> instance.
        /// </summary>
        public AreaFlag AreaFlag { get; set; }

        // ---- METHODS (PUBLIC) ---------------------------------------------------------------------------------------

        /// <summary>
        /// Reads the data from the given dynamic BYAML node into the instance.
        /// </summary>
        /// <param name="node">The dynamic BYAML node to deserialize.</param>
        public void DeserializeByaml(dynamic node)
        {
            StartOnly = node["StartOnly"];
            AreaFlag = ByamlFile.Deserialize<AreaFlag>(node["AreaFlag"]);
        }

        /// <summary>
        /// Creates a dynamic BYAML node from the instance's data.
        /// </summary>
        /// <returns>The dynamic BYAML node.</returns>
        public dynamic SerializeByaml()
        {
            return new Dictionary<string, dynamic>()
            {
                ["StartOnly"] = StartOnly,
                ["AreaFlag"] = AreaFlag.SerializeByaml()
            };
        }
    }
}

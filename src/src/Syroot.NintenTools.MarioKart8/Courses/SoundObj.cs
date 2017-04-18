using System;
using System.Collections.Generic;
using Syroot.NintenTools.Byaml.Serialization;

namespace Syroot.NintenTools.MarioKart8.Courses
{
    /// <summary>
    /// Represents a region in which a sound is emitted.
    /// </summary>
    [ByamlObject]
    public class SoundObj : SpatialObject, IByamlSerializable
    {
        // ---- PROPERTIES ---------------------------------------------------------------------------------------------

        /// <summary>
        /// Gets or sets the game modes in which this Obj will appear.
        /// </summary>
        public ModeInclusion ModeInclusion { get; set; }

        /// <summary>
        /// Gets or sets the first parameter.
        /// </summary>
        [ByamlMember("prm1")]
        public int Prm1 { get; set; }

        /// <summary>
        /// Gets or sets the second parameter.
        /// </summary>
        [ByamlMember("prm2")]
        public int Prm2 { get; set; }

        /// <summary>
        /// Gets or sets an unknown setting.
        /// </summary>
        public bool? Single { get; set; }

        /// <summary>
        /// Gets or sets an unknown setting which has never been used in the original courses.
        /// </summary>
        public bool TopView { get; set; }

        // ---- METHODS (PUBLIC) ---------------------------------------------------------------------------------------

        /// <summary>
        /// Reads data from the given <paramref name="dictionary"/> to satisfy members.
        /// </summary>
        /// <param name="dictionary">The <see cref="IDictionary{String, Object}"/> to read the data from.</param>
        public void DeserializeByaml(IDictionary<string, object> dictionary)
        {
            TopView = (string)dictionary["TopView"] == "true";

            object single;
            if (dictionary.TryGetValue("Single", out single)) Single = (string)single == "true";
        }

        /// <summary>
        /// Writes instance members into the given <paramref name="dictionary"/> to store them as BYAML data.
        /// </summary>
        /// <param name="dictionary">The <see cref="Dictionary{String, Object}"/> to store the data in.</param>
        public void SerializeByaml(IDictionary<string, object> dictionary)
        {
            dictionary["TopView"] = TopView ? "true" : "false";

            if (Single.HasValue) dictionary["Single"] = Single.Value ? "true" : "false";
        }
    }
}

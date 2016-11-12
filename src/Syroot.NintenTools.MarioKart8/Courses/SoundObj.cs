using System.Collections.Generic;

namespace Syroot.NintenTools.MarioKart8.Courses
{
    /// <summary>
    /// Represents a region in which a sound is emitted.
    /// </summary>
    public class SoundObj : SpatialObject
    {
        // ---- PROPERTIES ---------------------------------------------------------------------------------------------

        /// <summary>
        /// Gets or sets the game modes in which this Obj will appear.
        /// </summary>
        public ModeInclusion ModeInclusion { get; set; }

        /// <summary>
        /// Gets or sets the first parameter.
        /// </summary>
        public int Prm1 { get; set; }

        /// <summary>
        /// Gets or sets the second parameter.
        /// </summary>
        public int Prm2 { get; set; }

        /// <summary>
        /// Gets or sets an unknown setting which has never been used in the original courses.
        /// </summary>
        public bool TopView { get; set; }

        // ---- METHODS (PUBLIC) ---------------------------------------------------------------------------------------
        
        /// <summary>
        /// Reads the data from the given dynamic BYAML node into the instance.
        /// </summary>
        /// <param name="node">The dynamic BYAML node to deserialize.</param>
        /// <returns>The instance itself.</returns>
        public override dynamic DeserializeByaml(dynamic node)
        {
            base.DeserializeByaml((IDictionary<string, dynamic>)node);
            ModeInclusion = ModeInclusionExtensions.GetFromByamlAlternative(node);
            Prm1 = node["prm1"];
            Prm2 = node["prm2"];
            TopView = node["TopView"] == "True";
            return this;
        }

        /// <summary>
        /// Creates a dynamic BYAML node from the instance's data.
        /// </summary>
        /// <returns>The dynamic BYAML node.</returns>
        public override dynamic SerializeByaml()
        {
            IDictionary<string, dynamic> node = base.SerializeByaml();
            ModeInclusion.SetForByamlAlternative(node);
            node["prm1"] = Prm1;
            node["prm2"] = Prm2;
            node["TopView"] = TopView ? "True" : "False";
            return node;
        }
    }
}

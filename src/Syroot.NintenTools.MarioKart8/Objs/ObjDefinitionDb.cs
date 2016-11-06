using System.Collections.Generic;
using System.IO;
using Syroot.NintenTools.Byaml;

namespace Syroot.NintenTools.MarioKart8.Objs
{
    /// <summary>
    /// Represents the contents of the objflow.byaml file, holding <see cref="ObjDefinition"/> entries describing all
    /// the available Objs in-game.
    /// </summary>
    public class ObjDefinitionDb
    {
        // ---- CONSTRUCTORS & DESTRUCTOR ------------------------------------------------------------------------------

        /// <summary>
        /// Initializes a new instance of the <see cref="ObjDefinitionDb"/> class from the file with the given name.
        /// </summary>
        /// <param name="fileName">The name of the file from which the instance will be loaded.</param>
        public ObjDefinitionDb(string fileName)
        {
            using (FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                Load(stream);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ObjDefinitionDb"/> class from the given stream.
        /// </summary>
        /// <param name="stream">The stream from which the instance will be loaded.</param>
        public ObjDefinitionDb(Stream stream)
        {
            Load(stream);
        }

        // ---- PROPERTIES ---------------------------------------------------------------------------------------------

        /// <summary>
        /// Gets or sets the list of <see cref="ObjDefinition"/> instances in this database.
        /// </summary>
        public List<ObjDefinition> Definitions
        {
            get;
            set;
        }

        // ---- METHODS (PUBLIC) ---------------------------------------------------------------------------------------

        /// <summary>
        /// Saves the definitions into the file with the given name.
        /// </summary>
        /// <param name="fileName">The name of the file in which the definitions will be stored.</param>
        public void Save(string fileName)
        {
            using (FileStream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                Save(stream);
            }
        }

        /// <summary>
        /// Saves the definitions into the the given stream.
        /// </summary>
        /// <param name="stream">The stream in which the definitions will be stored.</param>
        public void Save(Stream stream)
        {
            dynamic node = ByamlFile.SerializeList(Definitions);
            ByamlFile.Save(stream, node);
        }

        // ---- METHODS (PRIVATE) --------------------------------------------------------------------------------------

        private void Load(Stream stream)
        {
            dynamic node = ByamlFile.Load(stream);
            Definitions = ByamlFile.DeserializeList<ObjDefinition>(node);
        }
    }
}

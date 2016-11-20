using System.Collections.Generic;
using System.Diagnostics;
using Syroot.IO;

namespace Syroot.NintenTools.MarioKart8.BinData
{
    /// <summary>
    /// Represents a section in a <see cref="BinFile"/>. A section is identified by a 4 character string and then
    /// consists of 1 or more groups of elements of a specific structure which is known by the game's code.
    /// </summary>
    [DebuggerDisplay("BinSection Identifier={Identifier}")]
    public class BinSection
    {
        // ---- CONSTANTS ----------------------------------------------------------------------------------------------

        private const int _headerSize = 12;

        // ---- CONSTRUCTORS & DESTRUCTOR ------------------------------------------------------------------------------

        /// <summary>
        /// Initializes a new instance of the <see cref="BinSection"/> class, read from the given
        /// <paramref name="reader"/> and having the provided size in bytes.
        /// </summary>
        /// <param name="reader">The <see cref="BinaryDataReader"/> to read the section from.</param>
        /// <param name="sectionSize">The size of the section in bytes.</param>
        public BinSection(BinaryDataReader reader, int sectionSize)
        {
            // Read the section header providing information about the number of groups and elements per groups.
            Identifier = reader.ReadString(4);
            ElementCount = reader.ReadInt16();
            GroupCount = reader.ReadInt16();
            Unknown = reader.ReadInt32();
            ElementSize = (sectionSize - _headerSize) / (GroupCount * ElementCount);

            // Read the groups and their elements.
            Groups = new List<List<byte[]>>(GroupCount);
            for (int i = 0; i < GroupCount; i++)
            {
                List<byte[]> group = new List<byte[]>(ElementCount);
                // Read the elements into the group.
                for (int j = 0; j < ElementCount; j++)
                {
                    group.Add(reader.ReadBytes(ElementSize));
                }
                Groups.Add(group);
            }
        }

        // ---- PROPERTIES ---------------------------------------------------------------------------------------------
        
        /// <summary>
        /// Gets or sets a 4 character long ASCII section identifier. It basically determines the type of the entries.
        /// </summary>
        public string Identifier { get; set; }

        /// <summary>
        /// Gets or sets an unknown value which always seems to be 0.
        /// </summary>
        public int Unknown { get; set; }

        /// <summary>
        /// Gets or sets the number of groups this section must have. This number is not enforced in the API, but must
        /// be respected to create valid files.
        /// </summary>
        public short GroupCount { get; set; }

        /// <summary>
        /// Gets the (in this class non-enforced) number of elements each group must have. This number is not enforced
        /// in the API, but must be respected to create valid files.
        /// </summary>
        public short ElementCount { get; set; }

        /// <summary>
        /// Gets the size of each element in bytes. This size is not enforced in the API, but must be respected to
        /// create valid files.
        /// </summary>
        public int ElementSize { get; set; }

        /// <summary>
        /// Gets the groups holding a fixed number of elements.
        /// </summary>
        public List<List<byte[]>> Groups { get; set; }
    }
}

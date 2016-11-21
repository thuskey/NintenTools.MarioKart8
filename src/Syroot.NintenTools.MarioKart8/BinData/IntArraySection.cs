using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Syroot.IO;

namespace Syroot.NintenTools.MarioKart8.BinData
{
    /// <summary>
    /// Represents a section in a <see cref="BinFile"/> consisting of byte array elements of a specific structure which
    /// is known by the game's code.
    /// </summary>
    [DebuggerDisplay("IntArraySection Header.Identifier={Header.Identifier}")]
    public class IntArraySection : SectionBase
    {
        // ---- CONSTANTS ----------------------------------------------------------------------------------------------

        /// <summary>
        /// The integer identifying this section type in the <see cref="SectionHeader"/>.
        /// </summary>
        internal const int TypeID = 0x00000000;

        // ---- CONSTRUCTORS & DESTRUCTOR ------------------------------------------------------------------------------

        /// <summary>
        /// Initializes a new instance of the <see cref="IntArraySection"/> class, read from the given
        /// <paramref name="reader"/> and having the provided size in bytes.
        /// </summary>
        /// <param name="reader">The <see cref="BinaryDataReader"/> to read the section from.</param>
        /// <param name="header">The <see cref="SectionHeader"/> providing information about this section.</param>
        /// <param name="dataSize">The size of the section data (excluding the header) in bytes.</param>
        public IntArraySection(BinaryDataReader reader, SectionHeader header, int dataSize)
            : base(reader, header, dataSize)
        {
            Header = header;

            // Compute the element size with the size of the section.
            int totalElements = Header.GroupCount * Header.ElementCount;
            if (dataSize % totalElements != 0)
            {
                throw new InvalidDataException("Could not compute element size without a remainder.");
            }
            ElementSize = dataSize / totalElements;

            // Read the groups and their elements.
            Groups = new List<List<int[]>>(Header.GroupCount);
            for (int i = 0; i < Header.GroupCount; i++)
            {
                List<int[]> group = new List<int[]>(Header.ElementCount);
                // Read the elements into the group.
                for (int j = 0; j < Header.ElementCount; j++)
                {
                    group.Add(reader.ReadInt32s(ElementSize / sizeof(int)));
                }
                Groups.Add(group);
            }
        }

        // ---- PROPERTIES ---------------------------------------------------------------------------------------------
        
        /// <summary>
        /// Gets the size of each element in bytes. This size is not enforced in the API, but must be respected to
        /// create valid files.
        /// </summary>
        public int ElementSize { get; set; }

        /// <summary>
        /// Gets the groups holding a fixed number of elements.
        /// </summary>
        public List<List<int[]>> Groups { get; set; }
    }
}

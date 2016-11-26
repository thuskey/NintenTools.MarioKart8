using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Syroot.IO;

namespace Syroot.NintenTools.MarioKart8.BinData
{
    /// <summary>
    /// Represents the header of any <see cref="Section"/> in a <see cref="BinFile"/>, providing the required
    /// information to load it into memory.
    /// </summary>
    [DebuggerDisplay("BinSectionHeader Identifier={Identifier}")]
    public struct SectionHeader
    {
        // ---- CONSTANTS ----------------------------------------------------------------------------------------------

        /// <summary>
        /// The size of the header in bytes.
        /// </summary>
        internal const int SizeInBytes = 12;

        // ---- CONSTRUCTORS & DESTRUCTOR ------------------------------------------------------------------------------

        /// <summary>
        /// Initializes a new instance of the <see cref="Section"/> class, read from the given
        /// <paramref name="reader"/> and having the provided size in bytes.
        /// </summary>
        /// <param name="reader">The <see cref="BinaryDataReader"/> to read the section from.</param>
        public SectionHeader(BinaryDataReader reader)
        {
            Name = reader.ReadString(4);
            ElementCount = reader.ReadInt16();
            GroupCount = reader.ReadInt16();
            SectionType = (SectionType)reader.ReadInt32();
        }

        // ---- PROPERTIES ---------------------------------------------------------------------------------------------
        
        /// <summary>
        /// Gets or sets a 4 character long ASCII section identifier. It basically determines the type of the entries.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a value determining the section data type.
        /// </summary>
        public SectionType SectionType { get; set; }

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
    }
}

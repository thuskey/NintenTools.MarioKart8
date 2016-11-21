using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Syroot.IO;

namespace Syroot.NintenTools.MarioKart8.BinData
{
    /// <summary>
    /// Represents a section holding strings in a <see cref="BinFile"/>. A section is identified by a 4 character string
    /// and then consists of 1 or more groups. Each group consists of an index of offsets to strings which follow right
    /// after the offsets. The end of the group seems to be aligned to the next 4 bytes.
    /// </summary>
    [DebuggerDisplay("BinStringSection Header.Identifier={Header.Identifier}")]
    public class StringSection : SectionBase
    {
        // ---- CONSTANTS ----------------------------------------------------------------------------------------------

        /// <summary>
        /// The integer identifying this section type in the <see cref="SectionHeader"/>.
        /// </summary>
        internal const int TypeID = 0x000000A0;

        // ---- CONSTRUCTORS & DESTRUCTOR ------------------------------------------------------------------------------

        /// <summary>
        /// Initializes a new instance of the <see cref="StringSection"/> class, read from the given
        /// <paramref name="reader"/> and having the provided size in bytes.
        /// </summary>
        /// <param name="reader">The <see cref="BinaryDataReader"/> to read the section from.</param>
        /// <param name="header">The <see cref="SectionHeader"/> providing information about this section.</param>
        /// <param name="sectionSize">The size of the section in bytes.</param>
        public StringSection(BinaryDataReader reader, SectionHeader header, int sectionSize)
            : base(reader, header, sectionSize)
        {
            Strings = new List<string>();
            
            // Get the offsets and read the strings at them.
            int[] offsets = reader.ReadInt32s(Header.ElementCount);
            long stringArrayOffset = reader.Position;
            for (int i = 0; i < offsets.Length; i++)
            {
                reader.Seek(stringArrayOffset + offsets[i], SeekOrigin.Begin);
                Strings.Add(reader.ReadString(BinaryStringFormat.ZeroTerminated));
            }
            reader.Align(4);
        }

        // ---- PROPERTIES ---------------------------------------------------------------------------------------------
        
        /// <summary>
        /// Gets or sets the array of strings.
        /// </summary>
        public List<string> Strings { get; set; }
    }
}

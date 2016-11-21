using System.Diagnostics;
using Syroot.IO;

namespace Syroot.NintenTools.MarioKart8.BinData
{
    /// <summary>
    /// Represents a section in a <see cref="BinFile"/>. A section is identified by a 4 character string and then
    /// consists of 1 or more groups. Each section can contain elements of a different type as specified in the header.
    /// </summary>
    [DebuggerDisplay("BinSectionBase Header.Identifier={Header.Identifier}")]
    public abstract class SectionBase
    {
        // ---- CONSTRUCTORS & DESTRUCTOR ------------------------------------------------------------------------------

        /// <summary>
        /// Initializes a new instance of the <see cref="SectionBase"/> class, read from the given
        /// <paramref name="reader"/> and having the provided size in bytes.
        /// </summary>
        /// <param name="reader">The <see cref="BinaryDataReader"/> to read the section from.</param>
        /// <param name="header">The <see cref="SectionHeader"/> providing information about this section.</param>
        /// <param name="sectionSize">The size of the section in bytes.</param>
        public SectionBase(BinaryDataReader reader, SectionHeader header, int sectionSize)
        {
            Header = header;
        }

        // ---- PROPERTIES ---------------------------------------------------------------------------------------------

        /// <summary>
        /// Gets or sets the <see cref="SectionHeader"/> providing general information.
        /// </summary>
        public SectionHeader Header { get; set; }
    }
}

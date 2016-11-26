using System;
using System.Collections.Generic;
using System.Diagnostics;
using Syroot.IO;

namespace Syroot.NintenTools.MarioKart8.BinData
{
    /// <summary>
    /// Represents a section in a <see cref="BinFile"/>. A section is identified by a name and then consists of 1 or
    /// more groups holding specific elements.
    /// </summary>
    [DebuggerDisplay("{Name}")]
    public class Section
    {
        // ---- CONSTRUCTORS & DESTRUCTOR ------------------------------------------------------------------------------

        /// <summary>
        /// Initializes a new instance of the <see cref="Section"/> class, reading groups and elements from the
        /// given <paramref name="reader"/> and having the provided size in bytes.
        /// </summary>
        /// <param name="reader">The <see cref="BinaryDataReader"/> to read the section from.</param>
        /// <param name="header">The <see cref="SectionHeader"/> providing information about this section.</param>
        /// <param name="sectionLength">The size of the section data in bytes.</param>
        public Section(BinaryDataReader reader, SectionHeader header, int sectionLength)
        {
            Name = header.Name;
            SectionType = header.SectionType;

            if (Enum.IsDefined(typeof(SectionType), SectionType))
            {
                // Known section, read the groups and elements.
                Groups = new List<GroupBase>(header.GroupCount);
                for (int i = 0; i < header.GroupCount; i++)
                {
                    Groups.Add(header.SectionType.Instantiate(reader, header, sectionLength));
                }
            }
            else
            {
                // Unknown section, simply store the raw data.
                DataIfUnknown = reader.ReadBytes(sectionLength);
            }
        }

        // ---- PROPERTIES ---------------------------------------------------------------------------------------------

        /// <summary>
        /// Gets or sets a 4 character long ASCII section identifier. It basically determines the meaning of the
        /// entries.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets the <see cref="SectionType"/>, determining the data this section provides.
        /// </summary>
        public SectionType SectionType { get; private set; }

        /// <summary>
        /// Gets or sets the list of groups.
        /// </summary>
        public List<GroupBase> Groups { get; set; }

        /// <summary>
        /// If this section is of an unknown <see cref="SectionType"/>, this property holds the raw section data. No
        /// groups were loaded.
        /// </summary>
        public byte[] DataIfUnknown { get; set; }
    }
}

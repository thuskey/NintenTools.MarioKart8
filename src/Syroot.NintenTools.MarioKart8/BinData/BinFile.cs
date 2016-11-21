using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using Syroot.IO;

namespace Syroot.NintenTools.MarioKart8.BinData
{
    /// <summary>
    /// Represents the untyped contents of a *.bin file. Such files consist of several <see cref="SectionBase"/>
    /// instances which consist of a set number of groups (sometimes just 1). Those in turn contain several elements,
    /// all of same structure per section.
    /// </summary>
    /// <remarks>
    /// The meaning of the elements is hardcoded in the game as it simply pulls the untyped data into C structures, with
    /// which it also determines the size of each such element. Thanks to the main header containing the offsets to each
    /// section, the size of the elements can be computed by this class to provide at least untyped byte arrays.
    /// </remarks>
    [DebuggerDisplay("BinFile Identifier={Identifier}")]
    public class BinFile
    {
        // ---- CONSTRUCTORS & DESTRUCTOR ------------------------------------------------------------------------------

        /// <summary>
        /// Initializes a new instance of the <see cref="BinFile"/> class from the file with the given name.
        /// </summary>
        /// <param name="fileName">The name of the file from which the instance will be loaded.</param>
        public BinFile(string fileName)
        {
            using (FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                Load(stream);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BinFile"/> class from the given stream.
        /// </summary>
        /// <param name="stream">The stream from which the instance will be loaded.</param>
        public BinFile(Stream stream)
        {
            Load(stream);
        }

        // ---- PROPERTIES ---------------------------------------------------------------------------------------------

        /// <summary>
        /// Gets or sets a 4 character long ASCII file identifier.
        /// </summary>
        public string Identifier { get; set; }

        /// <summary>
        /// Gets the reported size of the file in bytes. Might not be accurate.
        /// </summary>
        public int FileSize { get; set; }

        /// <summary>
        /// Gets or sets an unknown value.
        /// </summary>
        public short Unknown { get; set; }

        /// <summary>
        /// Gets or sets the version of the file format. Only 0x1000 is known.
        /// </summary>
        public int Version { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="SectionBase"/> instances following the header.
        /// </summary>
        public SectionBase[] Sections { get; set; }

        // ---- METHODS (PRIVATE) --------------------------------------------------------------------------------------

        private void Load(Stream stream)
        {
            using (BinaryDataReader reader = new BinaryDataReader(stream, Encoding.ASCII, true))
            {
                reader.ByteOrder = ByteOrder.BigEndian;

                // Read the file header providing information about the section count and offsets.
                Identifier = reader.ReadString(4);
                FileSize = reader.ReadInt32();
                Sections = new SectionBase[reader.ReadInt16()];
                Unknown = reader.ReadInt16();
                Version = reader.ReadInt32();
                int[] sectionOffsets = reader.ReadInt32s(Sections.Length); // All possibly 4-byte aligned.

                int fileHeaderSize = (int)reader.Position;

                // Read in all the sections.
                for (int i = 0; i < Sections.Length; i++)
                {
                    // Compute the length of the section data (without its header) and instantiate it.
                    int dataStart = fileHeaderSize + sectionOffsets[i] + SectionHeader.SizeInBytes;
                    int dataEnd;
                    if (i < Sections.Length - 1)
                    {
                        dataEnd = fileHeaderSize + sectionOffsets[i + 1];
                    }
                    else
                    {
                        dataEnd = (int)reader.Length;
                    }
                    int dataSize = dataEnd - dataStart;
                    Sections[i] = LoadSection(reader, dataSize);
                }
            }
        }

        private SectionBase LoadSection(BinaryDataReader reader, int dataSize)
        {
            // Read the section header.
            SectionHeader header = new SectionHeader(reader);

            // Instantiate a section of the correct type.
            switch (header.TypeID)
            {
                case IntArraySection.TypeID:
                    return new IntArraySection(reader, header, dataSize);
                case StringSection.TypeID:
                    return new StringSection(reader, header, dataSize);
                default:
                    throw new NotImplementedException($"Unknown section type {header.TypeID}.");
            }
        }
    }
}

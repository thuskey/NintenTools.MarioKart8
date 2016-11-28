using System.Diagnostics;
using System.IO;
using System.Text;
using Syroot.IO;

namespace Syroot.NintenTools.MarioKart8.BinData
{
    /// <summary>
    /// Represents the untyped contents of a *.bin file. Such files consist of several <see cref="Section"/>
    /// instances which consist of a set number of groups (sometimes just 1). Those in turn contain several elements,
    /// all of same structure per section.
    /// </summary>
    /// <remarks>
    /// The meaning of the elements is hardcoded in the game as it simply pulls the untyped data into C structures, with
    /// which it also determines the size of each such element. Thanks to the main header containing the offsets to each
    /// section, the size of the elements can be computed by this class to provide at least untyped byte arrays.
    /// </remarks>
    [DebuggerDisplay("{Identifier}")]
    public class BinFile
    {
        // ---- CONSTRUCTORS & DESTRUCTOR ------------------------------------------------------------------------------

        /// <summary>
        /// Initializes a new instance of the <see cref="BinFile"/> class with the given <paramref name="identifier"/>,
        /// <paramref name="unknown"/> value and <paramref name="version"/>.
        /// </summary>
        public BinFile(string identifier, short unknown, int version)
        {
            Identifier = identifier;
            Unknown = unknown;
            Version = version;
            Sections = new SectionCollection();
        }

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
        /// Gets or sets an unknown value.
        /// </summary>
        public short Unknown { get; set; }

        /// <summary>
        /// Gets or sets the version of the file format. Only 1000 is known.
        /// </summary>
        public int Version { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Section"/> instances following the header.
        /// </summary>
        public SectionCollection Sections { get; set; }

        // ---- METHODS (PUBLIC) ---------------------------------------------------------------------------------------

        /// <summary>
        /// Saves the data into the file with the given name.
        /// </summary>
        /// <param name="fileName">The name of the file in which the data will be stored.</param>
        public void Save(string fileName)
        {
            using (FileStream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                Save(stream);
            }
        }

        /// <summary>
        /// Saves the data into the the given stream.
        /// </summary>
        /// <param name="stream">The stream in which the data will be stored.</param>
        public void Save(Stream stream)
        {
            using (BinaryDataWriter writer = new BinaryDataWriter(stream, Encoding.ASCII, true))
            {
                writer.ByteOrder = ByteOrder.BigEndian;

                // Write the file header.
                writer.Write(Identifier, BinaryStringFormat.NoPrefixOrTermination);
                Offset fileSizeOffset = writer.ReserveOffset();
                writer.Write((short)Sections.Count);
                writer.Write(Unknown);
                writer.Write(Version);
                Offset[] sectionOffsets = new Offset[Sections.Count];
                for (int i = 0; i < sectionOffsets.Length; i++)
                {
                    sectionOffsets[i] = writer.ReserveOffset();
                }
                int headerLength = (int)writer.Position;

                // Write all the sections.
                int sectionIndex = 0;
                foreach (Section section in Sections)
                {
                    // Fill in the offset to this section.
                    sectionOffsets[sectionIndex].Satisfy((int)writer.Position - headerLength);

                    // Write the section header.
                    writer.Write(section.Name, BinaryStringFormat.NoPrefixOrTermination);
                    writer.Write((short)section.Groups[0].ElementCount);
                    writer.Write((short)section.Groups.Count);
                    writer.Write((int)section.SectionType);

                    // Write the section groups, each of them is 4-byte aligned.
                    foreach (GroupBase group in section.Groups)
                    {
                        writer.Write(group.GetData());
                        writer.Align(4);
                    }

                    sectionIndex++;
                }
                
                fileSizeOffset.Satisfy();
            }
        }

        // ---- METHODS (PRIVATE) --------------------------------------------------------------------------------------

        private void Load(Stream stream)
        {
            using (BinaryDataReader reader = new BinaryDataReader(stream, Encoding.ASCII, true))
            {
                reader.ByteOrder = ByteOrder.BigEndian;

                // Read the file header providing information about the section count and offsets.
                Identifier = reader.ReadString(4);
                int fileSize = reader.ReadInt32(); // Slightly off at times. Not stored in the class.
                int sectionCount = reader.ReadInt16();
                Unknown = reader.ReadInt16();
                Version = reader.ReadInt32();
                int[] sectionOffsets = reader.ReadInt32s(sectionCount);
                
                // Read in all the sections.
                Sections = new SectionCollection();
                int fileHeaderSize = (int)reader.Position;
                for (int i = 0; i < sectionCount; i++)
                {
                    // Compute the length of the section data (without its header) and instantiate it.
                    int dataStart = fileHeaderSize + sectionOffsets[i] + SectionHeader.SizeInBytes;
                    int dataEnd;
                    if (i < sectionCount - 1)
                    {
                        dataEnd = fileHeaderSize + sectionOffsets[i + 1];
                    }
                    else
                    {
                        dataEnd = (int)reader.Length;
                    }
                    SectionHeader header = new SectionHeader(reader);
                    Sections.Add(new Section(reader, header, dataEnd - dataStart));
                }
            }
        }
    }
}

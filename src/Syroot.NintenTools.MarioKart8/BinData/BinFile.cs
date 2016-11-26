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

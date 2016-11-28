using System.Collections.Generic;
using System.IO;
using System.Text;
using Syroot.IO;

namespace Syroot.NintenTools.MarioKart8.BinData
{
    /// <summary>
    /// Represents a group consisting of string elements.
    /// </summary>
    public class StringsGroup : GroupBase<string>
    {
        // ---- METHODS (PUBLIC) ---------------------------------------------------------------------------------------

        /// <summary>
        /// Gets the raw data of this group as a byte array.
        /// </summary>
        /// <returns>The data of this group.</returns>
        public override byte[] GetData()
        {
            using (MemoryStream stream = new MemoryStream())
            {
                using (BinaryDataWriter writer = new BinaryDataWriter(stream, Encoding.ASCII, true))
                {
                    // Write the offsets to the strings.
                    int offset = 0;
                    foreach (string element in Elements)
                    {
                        writer.Write(offset);
                        offset += element.Length + 1;
                    }
                    // Write the strings.
                    foreach (string element in Elements)
                    {
                        writer.Write(element, BinaryStringFormat.ZeroTerminated);
                    }
                }
                return stream.ToArray();
            }
        }

        // ---- METHODS (PROTECTED INTERNAL) ---------------------------------------------------------------------------

        /// <summary>
        /// Loads the data from the elements and stores them in the elements list.
        /// </summary>
        /// <param name="reader">The <see cref="BinaryDataReader"/> to read the data from.</param>
        /// <param name="header">The <see cref="SectionHeader"/> providing information about the section.</param>
        /// <param name="sectionLength">The size of the section data in bytes.</param>
        protected internal override void LoadElements(BinaryDataReader reader, SectionHeader header, int sectionLength)
        {
            Elements = new List<string>(header.ElementCount);

            // Get the offsets and read the strings at them.
            int[] offsets = reader.ReadInt32s(header.ElementCount);
            long stringArrayOffset = reader.Position;
            for (int i = 0; i < offsets.Length; i++)
            {
                reader.Seek(stringArrayOffset + offsets[i], SeekOrigin.Begin);
                Elements.Add(reader.ReadString(BinaryStringFormat.ZeroTerminated));
            }
            reader.Align(4);
        }
    }
}

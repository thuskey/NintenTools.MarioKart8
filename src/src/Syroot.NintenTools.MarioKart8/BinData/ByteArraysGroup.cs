using System;
using System.Collections.Generic;
using System.IO;
using Syroot.IO;

namespace Syroot.NintenTools.MarioKart8.BinData
{
    /// <summary>
    /// Represents a group consisting of byte array elements of a specific structure which is known by the game's code.
    /// </summary>
    public class ByteArraysGroup : GroupBase<byte[]>
    {
        // ---- METHODS (PUBLIC) ---------------------------------------------------------------------------------------

        /// <summary>
        /// Converts the byte arrays to a struct with fixed format.
        /// </summary>
        /// <typeparam name="T">The type of the struct to convert to.</typeparam>
        /// <returns>An array of struct instances created from the byte array elements.</returns>
        public T[] ToStructArray<T>()
        {
            T[] structs = new T[Elements.Count];

            int i = 0;
            foreach (byte[] element in Elements)
            {
                structs[i] = MarshalEndian.BytesToStruct<T>(element, ByteOrder.BigEndian);
                i++;
            }

            return structs;
        }

        /// <summary>
        /// Converts the given array with a structure of fixed format to the data of this byte array.
        /// </summary>
        /// <typeparam name="T">The type of the struct to convert to.</typeparam>
        public void FromStructArray<T>(T[] instances)
        {
            Elements = new List<byte[]>(instances.Length);
            foreach (T instance in instances)
            {
                Elements.Add(MarshalEndian.StructToBytes<T>(instance, ByteOrder.BigEndian));
            }
        }

        /// <summary>
        /// Gets the raw data of this group as a byte array.
        /// </summary>
        /// <returns>The data of this group.</returns>
        public override byte[] GetData()
        {
            int size = 0;
            for (int i = 0; i < Elements.Count; i++)
            {
                size += Elements[i].Length;
            }

            byte[] data = new byte[size];
            int offset = 0;
            for (int i = 0; i < Elements.Count; i++)
            {
                Buffer.BlockCopy(Elements[i], 0, data, offset, Elements[i].Length);
                offset += Elements[i].Length;
            }

            return data;
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
            Elements = new List<byte[]>(header.ElementCount);

            // Compute the element size with the size of the section.
            int totalElements = header.GroupCount * header.ElementCount;
            if (sectionLength % totalElements != 0)
            {
                throw new InvalidDataException("Could not compute element size without a remainder.");
            }
            int elementLength = sectionLength / totalElements;

            // Read the elements.
            for (int i = 0; i < header.ElementCount; i++)
            {
                Elements.Add(reader.ReadBytes(elementLength));
            }
        }
    }
}

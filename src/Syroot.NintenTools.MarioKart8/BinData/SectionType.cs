using System;
using System.Collections.Generic;
using System.IO;
using Syroot.IO;

namespace Syroot.NintenTools.MarioKart8.BinData
{
    /// <summary>
    /// Represents the known <see cref="Section"/> types.
    /// </summary>
    public enum SectionType
    {
        /// <summary>
        /// A section containing <see cref="ByteArraysGroup"/> instances.
        /// </summary>
        ByteArrays = 0x00000000,

        /// <summary>
        /// A section containing <see cref="StringsGroup"/> instances.
        /// </summary>
        Strings = 0x000000A0
    }

    /// <summary>
    /// Represents extension methods for the <see cref="SectionType"/> type.
    /// </summary>
    public static class SectionTypeExtensions
    {
        // ---- CONSTANTS ----------------------------------------------------------------------------------------------

        private static readonly Dictionary<SectionType, Type> _knownTypes = new Dictionary<SectionType, Type>()
        {
            [SectionType.ByteArrays] = typeof(ByteArraysGroup),
            [SectionType.Strings] = typeof(StringsGroup)
        };

        // ---- METHODS (PUBLIC) ---------------------------------------------------------------------------------------

        /// <summary>
        /// Instantiates the section according to this type.
        /// </summary>
        /// <param name="sectionType">The extended <see cref="SectionType"/>.</param>
        /// <param name="reader">The <see cref="BinaryDataReader"/> to read the section from.</param>
        /// <param name="header">The <see cref="SectionHeader"/> providing information about this section.</param>
        /// <param name="sectionLength">The size of the section data in bytes.</param>
        /// <returns>The instantiated <see cref="GroupBase"/> instance.</returns>
        public static GroupBase Instantiate(this SectionType sectionType, BinaryDataReader reader, SectionHeader header,
            int sectionLength)
        {
            Type groupType;
            if (_knownTypes.TryGetValue(sectionType, out groupType))
            {
                GroupBase group = (GroupBase)Activator.CreateInstance(groupType);
                group.LoadElements(reader, header, sectionLength);
                return group;
            }
            else
            {
                // TODO: This might be instantiated as a raw byte array "section".
                throw new InvalidDataException($"Cannot instantiate unknown section type {sectionType}.");
            }
        }
    }
}

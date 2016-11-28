using System;
using System.Collections.Generic;
using Syroot.IO;

namespace Syroot.NintenTools.MarioKart8.BinData
{
    /// <summary>
    /// Represents the non-generic base class for all <see cref="GroupBase{T}"/>.
    /// </summary>
    public abstract class GroupBase
    {
        // ---- PROPERTIES ---------------------------------------------------------------------------------------------

        /// <summary>
        /// Gets the number of elements in this group.
        /// </summary>
        public abstract int ElementCount
        {
            get;
        }

        // ---- METHODS (PUBLIC) ---------------------------------------------------------------------------------------

        /// <summary>
        /// Gets the raw data of this group as a byte array.
        /// </summary>
        /// <returns>The data of this group.</returns>
        public abstract byte[] GetData();

        // ---- METHODS (PROTECTED INTERNAL) ---------------------------------------------------------------------------

        /// <summary>
        /// Loads the data from the elements and stores them in the elements list.
        /// </summary>
        /// <param name="reader">The <see cref="BinaryDataReader"/> to read the data from.</param>
        /// <param name="header">The <see cref="SectionHeader"/> providing information about the section.</param>
        /// <param name="sectionLength">The size of the section data in bytes.</param>
        protected internal abstract void LoadElements(BinaryDataReader reader, SectionHeader header, int sectionLength);
    }

    /// <summary>
    /// Represents a group in a <see cref="Section"/>. There are 1 or more groups in each section. The number of
    /// elements and their data has to be specified by the group.
    /// </summary>
    /// <typeparam name="T">The type of the elements.</typeparam>
    public abstract class GroupBase<T> : GroupBase
    {
        // ---- PROPERTIES ---------------------------------------------------------------------------------------------

        /// <summary>
        /// Gets or sets the list of elements.
        /// </summary>
        public List<T> Elements { get; set; }

        /// <summary>
        /// Gets the number of elements in this group.
        /// </summary>
        public override int ElementCount
        {
            get
            {
                return Elements.Count;
            }
        }
    }
}

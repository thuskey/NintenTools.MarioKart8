using System;
using System.Collections.Generic;

namespace Syroot.NintenTools.MarioKart8.BinData
{
    /// <summary>
    /// Represents a list of <see cref="Section"/> instances.
    /// </summary>
    public class SectionCollection : List<Section>
    {
        // ---- PROPERTIES ---------------------------------------------------------------------------------------------

        /// <summary>
        /// Gets or sets the <see cref="Section"/> with the given <paramref name="name"/>.
        /// </summary>
        /// <param name="name">The name of the <see cref="Section"/> to get or set.</param>
        /// <returns>The <see cref="Section"/> with the given name.</returns>
        public Section this[string name]
        {
            get
            {
                Section section = GetSectionByName(name);
                if (section == null)
                {
                    throw new IndexOutOfRangeException(nameof(name));
                }
                return section;
            }
            set
            {
                int index = GetSectionIndexByName(name);
                if (index == -1)
                {
                    throw new IndexOutOfRangeException(nameof(name));
                }
                this[index] = value;
            }
        }

        // ---- METHODS (PUBLIC) ---------------------------------------------------------------------------------------

        /// <summary>
        /// Gets a value indicating whether a <see cref="Section"/> with the given <paramref name="name"/> exists.
        /// </summary>
        /// <param name="name">The name of the <see cref="Section"/> to check for existence.</param>
        /// <returns><c>true</c> if the <see cref="Section"/> exists, otherwise <c>false</c>.</returns>
        public bool Contains(string name)
        {
            return GetSectionByName(name) != null;
        }
        
        // ---- METHODS (PRIVATE) --------------------------------------------------------------------------------------

        private Section GetSectionByName(string name)
        {
            foreach (Section section in this)
            {
                if (section.Name == name)
                {
                    return section;
                }
            }
            return null;
        }

        private int GetSectionIndexByName(string name)
        {
            int i = 0;
            foreach (Section section in this)
            {
                if (section.Name == name)
                {
                    return i;
                }
                i++;
            }
            return -1;
        }
    }
}

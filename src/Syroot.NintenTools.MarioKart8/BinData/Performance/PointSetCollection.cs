namespace Syroot.NintenTools.MarioKart8.BinData.Performance
{
    /// <summary>
    /// Represents the base class for <see cref="PointSet"/> collections.
    /// </summary>
    public abstract class PointSetCollection
    {
        // ---- CONSTRUCTORS & DESTRUCTOR ------------------------------------------------------------------------------

        /// <summary>
        /// Initializes a new instance of the <see cref="PointSetCollection"/> struct with the data read from the given
        /// <paramref name="group"/>.
        /// </summary>
        /// <param name="group">The <see cref="ByteArraysGroup"/> to read the data from.</param>
        public PointSetCollection(ByteArraysGroup group)
        {
            PointSet[] pointSets = group.ToStructArray<PointSet>();
            for (int i = 0; i < pointSets.Length; i++)
            {
                this[i] = pointSets[i];
            }
        }

        // ---- OPERATORS ----------------------------------------------------------------------------------------------

        /// <summary>
        /// Gets or sets the element at the index as it appears in the original file.
        /// </summary>
        /// <param name="index">The index at which the value appears.</param>
        /// <returns>The value which appears at index <paramref name="index"/>.</returns>
        public abstract PointSet this[int index]
        {
            get; set;
        }
    }
}

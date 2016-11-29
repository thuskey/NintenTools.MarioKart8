namespace Syroot.NintenTools.MarioKart8.PerformanceEditor
{
    /// <summary>
    /// Represents a <see cref="SectionDataGridView"/> which only allows the input of float values.
    /// </summary>
    public abstract class FloatSectionDataGridView : SectionDataGridView<float>
    {
        // ---- METHODS (PROTECTED) ------------------------------------------------------------------------------------

        /// <summary>
        /// Adds a column to the grid with the given title.
        /// </summary>
        /// <param name="text">The title of the column.</param>
        /// <returns>The index of the created column.</returns>
        protected override int AddColumn(string text)
        {
            int index = base.AddColumn(text);
            Columns[index].DefaultCellStyle.Format = "0.0000";
            return index;
        }

        /// <summary>
        /// Called when the user inputs a character and it has to be validated.
        /// </summary>
        /// <param name="character">The character which was input.</param>
        /// <returns><c>true</c> to allow the character, otherwise <c>false</c>.</returns>
        protected override bool ValidateCharacterInput(char character)
        {
            return char.IsControl(character) && (char.IsDigit(character) || char.IsPunctuation(character));
        }

        /// <summary>
        /// Called when the cell value text has to be validated.
        /// </summary>
        /// <param name="text">The value to validate.</param>
        /// <returns><c>true</c> to allow the text, otherwise <c>false</c>.</returns>
        protected override bool ValidateTextValue(string text)
        {
            float f;
            return float.TryParse(text, out f);
        }
    }
}

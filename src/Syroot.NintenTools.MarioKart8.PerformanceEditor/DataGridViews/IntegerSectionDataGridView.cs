namespace Syroot.NintenTools.MarioKart8.PerformanceEditor
{
    /// <summary>
    /// Represents a <see cref="SectionDataGridView"/> which only allows the input of integer values.
    /// </summary>
    public abstract class IntegerSectionDataGridView : SectionDataGridView<int>
    {
        // ---- METHODS (PROTECTED) ------------------------------------------------------------------------------------

        /// <summary>
        /// Called when the user inputs a character and it has to be validated.
        /// </summary>
        /// <param name="character">The character which was input.</param>
        /// <returns><c>true</c> to allow the character, otherwise <c>false</c>.</returns>
        protected override bool ValidateCharacterInput(char character)
        {
            return char.IsControl(character) && char.IsDigit(character);
        }

        /// <summary>
        /// Called when the cell value text has to be validated.
        /// </summary>
        /// <param name="text">The value to validate.</param>
        /// <returns><c>true</c> to allow the text, otherwise <c>false</c>.</returns>
        protected override bool ValidateTextValue(string text)
        {
            int i;
            return int.TryParse(text, out i);
        }
    }
}

using System.Windows.Forms;

namespace Syroot.NintenTools.MarioKart8.PerformanceEditor
{
    /// <summary>
    /// Represents a <see cref="SectionDataGridView"/> which only allows the input of float values.
    /// </summary>
    public class FloatSectionDataGridView : SectionDataGridView
    {
        // ---- METHODS (PROTECTED) ------------------------------------------------------------------------------------

        protected override int AddColumn(string text)
        {
            int index = base.AddColumn(text);
            Columns[index].DefaultCellStyle.Format = "0.0000";
            return index;
        }

        protected virtual void SetDataValue(int row, int column, float value)
        {
        }

        protected override void OnEditingControlShowing(DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= EditingControlTextBox_KeyPress;
            TextBox textBox = e.Control as TextBox;
            if (textBox != null)
            {
                textBox.KeyPress += EditingControlTextBox_KeyPress;
            }
        }

        protected override void OnCellValidating(DataGridViewCellValidatingEventArgs e)
        {
            float f;
            e.Cancel = !float.TryParse(e.FormattedValue.ToString(), out f);
        }

        protected override void OnCellValidated(DataGridViewCellEventArgs e)
        {
            base.OnCellValidated(e);
            SetDataValue(e.RowIndex, e.ColumnIndex,
                float.Parse(Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()));
        }

        protected override void OnCellValueChanged(DataGridViewCellEventArgs e)
        {
            base.OnCellValueChanged(e);
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                SetDataValue(e.RowIndex, e.ColumnIndex,
                    float.Parse(Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()));
            }
        }

        // ---- EVENTHANDLERS ------------------------------------------------------------------------------------------

        private void EditingControlTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsControl(e.KeyChar) && !(char.IsDigit(e.KeyChar) || char.IsPunctuation(e.KeyChar));
        }
    }
}

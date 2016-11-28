using System.Windows.Forms;

namespace Syroot.NintenTools.MarioKart8.PerformanceEditor
{
    /// <summary>
    /// Represents a <see cref="SectionDataGridView"/> which only allows the input of integer values.
    /// </summary>
    public class IntegerSectionDataGridView : SectionDataGridView
    {
        // ---- METHODS (PROTECTED) ------------------------------------------------------------------------------------

        protected virtual void SetDataValue(int row, int column, int value)
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
            int i;
            e.Cancel = !int.TryParse(e.FormattedValue.ToString(), out i);
        }

        protected override void OnCellValidated(DataGridViewCellEventArgs e)
        {
            base.OnCellValidated(e);
            SetDataValue(e.RowIndex, e.ColumnIndex,
                int.Parse(Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()));
        }

        protected override void OnCellValueChanged(DataGridViewCellEventArgs e)
        {
            base.OnCellValueChanged(e);
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                SetDataValue(e.RowIndex, e.ColumnIndex,
                    int.Parse(Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()));
            }
        }

        // ---- EVENTHANDLERS ------------------------------------------------------------------------------------------

        private void EditingControlTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }
    }
}

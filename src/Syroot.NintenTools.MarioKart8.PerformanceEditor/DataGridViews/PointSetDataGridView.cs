using System;
using System.Windows.Forms;
using Syroot.NintenTools.MarioKart8.BinData.Performance;

namespace Syroot.NintenTools.MarioKart8.PerformanceEditor
{
    /// <summary>
    /// Represents a <see cref="PointSetDataGridView"/> which has columns for displaying points of a driver, kart, tire
    /// or glider.
    /// </summary>
    public class PointSetDataGridView : IntegerSectionDataGridView
    {
        // ---- MEMBERS ------------------------------------------------------------------------------------------------

        private PointSetCollection _data;

        // ---- CONSTRUCTORS & DESTRUCTOR ------------------------------------------------------------------------------

        public PointSetDataGridView()
        {
            ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            ColumnHeadersHeight = 60;

            AddColumn("Weight");
            AddColumn("Acceleration");
            AddColumn("Outerslip");
            AddColumn("Traction");
            AddColumn("Turbo");
            AddColumn($"Speed{Environment.NewLine}Ground");
            AddColumn($"Speed{Environment.NewLine}Water");
            AddColumn($"Speed{Environment.NewLine}Anti-Gravity");
            AddColumn($"Speed{Environment.NewLine}Gliding");
            AddColumn($"Handling{Environment.NewLine}Ground");
            AddColumn($"Handling{Environment.NewLine}Water");
            AddColumn($"Handling{Environment.NewLine}Anti-Gravity");
            AddColumn($"Handling{Environment.NewLine}Gliding");

            string[] rowNames = GetRowNames();
            Rows.Add(rowNames.Length);
            for (int i = 0; i < rowNames.Length; i++)
            {
                Rows[i].HeaderCell.Value = rowNames[i];
            }
        }

        // ---- METHODS (PROTECTED) ------------------------------------------------------------------------------------

        protected virtual string[] GetRowNames()
        {
            return null;
        }

        protected virtual PointSetCollection GetSectionToDisplay()
        {
            return null;
        }

        protected sealed override void FillData()
        {
            _data = GetSectionToDisplay();
            for (int y = 0; y < Rows.Count; y++)
            {
                PointSet pointSet = _data[y];
                for (int x = 0; x < 13; x++)
                {
                    Rows[y].Cells[x].Value = pointSet[x];
                }
            }
        }

        protected override void SetDataValue(int row, int column, int value)
        {
            _data[row][column] = value;
        }
    }
}

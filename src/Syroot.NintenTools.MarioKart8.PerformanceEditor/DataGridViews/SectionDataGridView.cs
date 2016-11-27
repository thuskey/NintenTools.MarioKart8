using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Syroot.NintenTools.MarioKart8.BinData.Performance;

namespace Syroot.NintenTools.MarioKart8.PerformanceEditor
{
    /// <summary>
    /// Represents a <see cref="DataGridView"/> showing data from a <see cref="Section"/>.
    /// </summary>
    public class SectionDataGridView : DataGridView
    {
        // ---- MEMBERS ------------------------------------------------------------------------------------------------

        private PerformanceData _performanceData;

        // ---- CONSTRUCTORS & DESTRUCTOR ------------------------------------------------------------------------------

        /// <summary>
        /// Initializes a new instance of the <see cref="SectionDataGridView"/> class.
        /// </summary>
        public SectionDataGridView()
        {
            // General
            base.BackgroundColor = Color.White;
            base.BorderStyle = BorderStyle.None;
            DoubleBuffered = true;
            base.GridColor = Color.FromArgb(255, 255, 255);
            base.Margin = Padding.Empty;
            base.SelectionMode = DataGridViewSelectionMode.CellSelect;

            // Columns
            base.AllowUserToResizeColumns = false;
            base.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            base.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            base.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle()
            {
                Alignment = DataGridViewContentAlignment.MiddleCenter,
                BackColor = Color.FromArgb(236, 236, 236),
                ForeColor = Color.FromArgb(64, 64, 64)
            };
            base.ColumnHeadersHeight = 30;
            base.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            base.EnableHeadersVisualStyles = false;

            // Rows
            base.AllowUserToAddRows = false;
            base.AllowUserToDeleteRows = false;
            base.AllowUserToResizeRows = false;
            base.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle()
            {
                BackColor = Color.FromArgb(250, 250, 250),
                SelectionBackColor = Color.FromArgb(184, 207, 255),
                SelectionForeColor = ForeColor
            };
            base.RowTemplate.Height = 30;
            base.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            base.RowHeadersDefaultCellStyle = new DataGridViewCellStyle()
            {
                Alignment = DataGridViewContentAlignment.MiddleCenter,
                BackColor = Color.FromArgb(236, 236, 236),
                ForeColor = Color.FromArgb(64, 64, 64)
            };
            base.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            base.RowsDefaultCellStyle = new DataGridViewCellStyle()
            {
                BackColor = Color.FromArgb(255, 255, 255)
            };
            base.ShowEditingIcon = false;

            // Cells
            base.CellBorderStyle = DataGridViewCellBorderStyle.None;
            base.DefaultCellStyle = new DataGridViewCellStyle()
            {
                Alignment = DataGridViewContentAlignment.MiddleRight,
                BackColor = Color.FromArgb(255, 255, 255),
                SelectionBackColor = Color.FromArgb(192, 213, 255),
                SelectionForeColor = ForeColor
            };
        }

        // ---- PROPERTIES ---------------------------------------------------------------------------------------------

        #region New Default Values

        // General

        [DefaultValue(typeof(Color), "0xFFFFFF")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Color BackgroundColor
        {
            get { return base.BackgroundColor; }
        }

        [DefaultValue(BorderStyle.None)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new BorderStyle BorderStyle
        {
            get { return base.BorderStyle; }
        }

        [DefaultValue(typeof(Color), "0xFFFFFF")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Color GridColor
        {
            get { return base.GridColor; }
        }

        [DefaultValue(typeof(Padding), "0,0,0,0")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Padding Margin
        {
            get { return base.Margin; }
        }

        [DefaultValue(DataGridViewSelectionMode.CellSelect)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new DataGridViewSelectionMode SelectionMode
        {
            get { return base.SelectionMode; }
        }

        // Columns

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new DataGridViewColumnCollection Columns
        {
            get { return base.Columns; }
        }

        [DefaultValue(DataGridViewSelectionMode.CellSelect)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new bool AllowUserToResizeColumns
        {
            get { return base.AllowUserToResizeColumns; }
        }

        [DefaultValue(DataGridViewAutoSizeColumnsMode.Fill)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new DataGridViewAutoSizeColumnsMode AutoSizeColumnsMode
        {
            get { return base.AutoSizeColumnsMode; }
        }

        [DefaultValue(DataGridViewHeaderBorderStyle.None)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new DataGridViewHeaderBorderStyle ColumnHeadersBorderStyle
        {
            get { return base.ColumnHeadersBorderStyle; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new DataGridViewCellStyle ColumnHeadersDefaultCellStyle
        {
            get { return base.ColumnHeadersDefaultCellStyle; }
        }

        [DefaultValue(DataGridViewColumnHeadersHeightSizeMode.DisableResizing)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new DataGridViewColumnHeadersHeightSizeMode ColumnHeadersHeightSizeMode
        {
            get { return base.ColumnHeadersHeightSizeMode; }
        }

        [DefaultValue(30)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new int ColumnHeadersHeight
        {
            get { return base.ColumnHeadersHeight; }
            protected set { base.ColumnHeadersHeight = value; }
        }

        [DefaultValue(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new bool EnableHeadersVisualStyles
        {
            get { return base.EnableHeadersVisualStyles; }
        }

        // Rows

        [DefaultValue(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new bool AllowUserToAddRows
        {
            get { return base.AllowUserToAddRows; }
        }

        [DefaultValue(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new bool AllowUserToDeleteRows
        {
            get { return base.AllowUserToDeleteRows; }
        }

        [DefaultValue(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new bool AllowUserToResizeRows
        {
            get { return base.AllowUserToResizeRows; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new DataGridViewCellStyle AlternatingRowsDefaultCellStyle
        {
            get { return base.AlternatingRowsDefaultCellStyle; }
        }

        [DefaultValue(DataGridViewHeaderBorderStyle.None)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new DataGridViewHeaderBorderStyle RowHeadersBorderStyle
        {
            get { return base.RowHeadersBorderStyle; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new DataGridViewCellStyle RowHeadersDefaultCellStyle
        {
            get { return base.RowHeadersDefaultCellStyle; }
        }

        [DefaultValue(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new DataGridViewRowHeadersWidthSizeMode RowHeadersWidthSizeMode
        {
            get { return base.RowHeadersWidthSizeMode; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new DataGridViewCellStyle RowsDefaultCellStyle
        {
            get { return base.RowsDefaultCellStyle; }
        }

        [DefaultValue(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new bool ShowEditingIcon
        {
            get { return base.ShowEditingIcon; }
        }

        // Cells

        [DefaultValue(DataGridViewCellBorderStyle.None)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new DataGridViewCellBorderStyle CellBorderStyle
        {
            get { return base.CellBorderStyle; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new DataGridViewCellStyle DefaultCellStyle
        {
            get { return base.DefaultCellStyle; }
        }

        #endregion

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual PerformanceData PerformanceData
        {
            get
            {
                return _performanceData;
            }
            set
            {
                _performanceData = value;
                if (_performanceData != null)
                {
                    FillData();
                }
            }
        }

        // ---- METHODS (PROTECTED) ------------------------------------------------------------------------------------

        protected virtual int AddColumn(string text)
        {
            int index = Columns.Add($"_dgvc{text}", text);
            Columns[index].SortMode = DataGridViewColumnSortMode.NotSortable;
            return index;
        }

        protected virtual void FillData()
        {
        }

        protected override void OnRowPostPaint(DataGridViewRowPostPaintEventArgs e)
        {
            e.PaintHeader(DataGridViewPaintParts.Background);
            object headerValue = Rows[e.RowIndex].HeaderCell.Value;
            Rectangle headerRect = new Rectangle(e.RowBounds.Left, e.RowBounds.Top,
                RowHeadersWidth, e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, $"{headerValue}", RowHeadersDefaultCellStyle.Font, headerRect,
                RowHeadersDefaultCellStyle.ForeColor,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }
    }
}

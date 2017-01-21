using System;
using System.Windows.Forms;

namespace Syroot.NintenTools.MarioKart8.PerformanceEditor
{
    /// <summary>
    /// The main window of the application.
    /// </summary>
    public partial class FormMain : Form
    {
        // ---- MEMBERS ------------------------------------------------------------------------------------------------

        private MainController _controller;

        // ---- CONSTRUCTORS & DESTRUCTOR ------------------------------------------------------------------------------

        /// <summary>
        /// Initializes a new instance of the <see cref="FormMain"/> class.
        /// </summary>
        public FormMain()
        {
            InitializeComponent();

            _controller = new MainController();
            _controller.FileChanged += _controller_FileChanged;
        }

        // ---- METHODS (PRIVATE) --------------------------------------------------------------------------------------

        private void UpdateDataGrids(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is ContainerControl)
                {
                    UpdateDataGrids(control);
                }
                else
                {
                    SectionDataGridView sectionDataGridView = control as SectionDataGridView;
                    if (sectionDataGridView != null)
                    {
                        sectionDataGridView.PerformanceData = _controller.PerformanceData;
                    }
                }
            }
        }

        // ---- EVENTHANDLERS ------------------------------------------------------------------------------------------

        private void FormMain_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void FormMain_DragDrop(object sender, DragEventArgs e)
        {
            string file = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
            _controller.OpenFile(file);
        }

        private void _controller_FileChanged(object sender, EventArgs e)
        {
            if (_controller.PerformanceData == null)
            {
                Text = Application.ProductName;
                _ccPhysics.Enabled = false;
                _ccSpeed.Enabled = false;
                _ccHandling.Enabled = false;
                _ccPoints.Enabled = false;
                _ccMain.SelectedControl = _tlpFile;
                _btSave.Visible = false;
                _btSaveAs.Visible = false;
            }
            else
            {
                Text = $"{_controller.FileName} - {Application.ProductName}";
                _ccPhysics.Enabled = true;
                _ccSpeed.Enabled = true;
                _ccHandling.Enabled = true;
                _ccPoints.Enabled = true;
                _ccMain.SelectedControl = _ccPhysics;
                _btSave.Visible = true;
                _btSaveAs.Visible = true;
            }
            UpdateDataGrids(this);
        }

        private void _btOpen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Open File";
                openFileDialog.FileName = _controller.FileName;
                openFileDialog.Filter = "All BIN Files|*.bin|All Files|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _controller.OpenFile(openFileDialog.FileName);
                }
            }
        }

        private void _btSave_Click(object sender, EventArgs e)
        {
            _controller.SaveFile(_controller.FileName);
        }

        private void _btSaveAs_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Title = "Save File";
                saveFileDialog.FileName = _controller.FileName;
                saveFileDialog.Filter = "All BIN Files|*.bin|All Files|*.*";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _controller.SaveFile(saveFileDialog.FileName);
                }
            }
        }

        private void _cmsGridAdd_Click(object sender, EventArgs e)
        {
            DataGridView dataGridView = _cmsGrid.SourceControl as DataGridView;
            bool isFloatGrid = dataGridView is FloatSectionDataGridView;

            float? value = FormCalculation.Show("Add", isFloatGrid);
            if (value != null)
            {
                if (isFloatGrid)
                {
                    foreach (DataGridViewCell cell in dataGridView.SelectedCells)
                    {
                        cell.Value = (float)cell.Value + value;
                    }
                }
                else
                {
                    foreach (DataGridViewCell cell in dataGridView.SelectedCells)
                    {
                        cell.Value = (int)cell.Value + (int)value;
                    }
                }
            }
        }

        private void _cmsGridSubtract_Click(object sender, EventArgs e)
        {
            DataGridView dataGridView = _cmsGrid.SourceControl as DataGridView;
            bool isFloatGrid = dataGridView is FloatSectionDataGridView;

            float? value = FormCalculation.Show("Subtract", isFloatGrid);
            if (value != null)
            {
                if (isFloatGrid)
                {
                    foreach (DataGridViewCell cell in dataGridView.SelectedCells)
                    {
                        cell.Value = (float)cell.Value - value;
                    }
                }
                else
                {
                    foreach (DataGridViewCell cell in dataGridView.SelectedCells)
                    {
                        cell.Value = (int)cell.Value - (int)value;
                    }
                }
            }

        }

        private void _cmsGridMultiply_Click(object sender, EventArgs e)
        {
            DataGridView dataGridView = _cmsGrid.SourceControl as DataGridView;
            bool isFloatGrid = dataGridView is FloatSectionDataGridView;

            float? value = FormCalculation.Show("Multiply", isFloatGrid);
            if (value != null)
            {
                if (isFloatGrid)
                {
                    foreach (DataGridViewCell cell in dataGridView.SelectedCells)
                    {
                        cell.Value = (float)cell.Value * value;
                    }
                }
                else
                {
                    foreach (DataGridViewCell cell in dataGridView.SelectedCells)
                    {
                        cell.Value = (int)cell.Value * (int)value;
                    }
                }
            }
        }

        private void _cmsGridDivide_Click(object sender, EventArgs e)
        {
            DataGridView dataGridView = _cmsGrid.SourceControl as DataGridView;
            bool isFloatGrid = dataGridView is FloatSectionDataGridView;

            float? value = FormCalculation.Show("Divide", isFloatGrid);
            if (value != null)
            {
                if (isFloatGrid)
                {
                    foreach (DataGridViewCell cell in dataGridView.SelectedCells)
                    {
                        cell.Value = (float)cell.Value / value;
                    }
                }
                else
                {
                    foreach (DataGridViewCell cell in dataGridView.SelectedCells)
                    {
                        cell.Value = (int)cell.Value / (int)value;
                    }
                }
            }
        }
    }
}

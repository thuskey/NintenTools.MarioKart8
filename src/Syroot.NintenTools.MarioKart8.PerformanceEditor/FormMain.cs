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

        private void _controller_FileChanged(object sender, EventArgs e)
        {
            if (_controller.PerformanceData == null)
            {
                _btSave.Enabled = false;
                _btSaveAs.Enabled = false;
                _ccPhysics.Enabled = false;
                _ccSpeed.Enabled = false;
                _ccHandling.Enabled = false;
                _ccPoints.Enabled = false;
                _ccMain.SelectedControl = _tlpFile;
            }
            else
            {
                _btSave.Enabled = true;
                _btSaveAs.Enabled = true;
                _ccPhysics.Enabled = true;
                _ccSpeed.Enabled = true;
                _ccHandling.Enabled = true;
                _ccPoints.Enabled = true;
                _ccMain.SelectedControl = _ccPhysics;
            }
            UpdateDataGrids(this);
        }

        private void _btNew_Click(object sender, EventArgs e)
        {

        }

        private void _btOpen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Open File";
                openFileDialog.FileName = _controller.FileName;
                openFileDialog.Filter = "Performance Files|performance.bin|All BIN Files|*.bin|All Files|*.*";
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
                saveFileDialog.Filter = "Performance.bin Files|performance.bin|All BIN Files|*.bin|All Files|*.*";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _controller.SaveFile(saveFileDialog.FileName);
                }
            }
        }
    }
}

using System.Windows.Forms;

namespace Syroot.NintenTools.MarioKart8.PerformanceEditor
{
    /// <summary>
    /// Represents a small input dialog to enter a calculation number.
    /// </summary>
    public partial class FormCalculation : Form
    {
        // ---- CONSTRUCTORS & DESTRUCTOR ------------------------------------------------------------------------------

        /// <summary>
        /// Initializes a new instance of the <see cref="FormCalculation"/> class.
        /// </summary>
        public FormCalculation()
        {
            InitializeComponent();
        }

        // ---- PROPERTIES ---------------------------------------------------------------------------------------------

        internal bool AllowFloat
        {
            get;
            set;
        }

        internal float Value
        {
            get { return float.Parse(_tbValue.Text); }
            set { _tbValue.Text = value.ToString(); }
        }

        // ---- METHODS (INTERNAL) -------------------------------------------------------------------------------------

        internal static float? Show(string text, bool allowFloat, float defaultValue)
        {
            FormCalculation form = new FormCalculation();
            form.Text = text;
            form.AllowFloat = allowFloat;
            form.Value = defaultValue;
            if (form.ShowDialog() == DialogResult.OK)
            {
                return form.Value;
            }
            return null;
        }

        private void _tbValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsControl(e.KeyChar)
                && !(char.IsDigit(e.KeyChar) || (AllowFloat && char.IsPunctuation(e.KeyChar)));
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Layout;

namespace Syroot.NintenTools.MarioKart8.PerformanceEditor
{
    /// <summary>
    /// Represents tab-like control with an array of entries at the top and changing content depending on the selected
    /// control.
    /// </summary>
    [ProvideProperty("Title", typeof(Control))]
    public partial class CategoryControl : ContainerControl, IExtenderProvider
    {
        // ---- MEMBERS ------------------------------------------------------------------------------------------------

        private CategoryControlLayoutEngine _layoutEngine;
        private Dictionary<Control, string> _controlTitles;
        private Control _selectedControl;
        private Control _hoveredControl;
        private int _headerHeight;
        private Color _headerBackColor;
        private Color _headerHoveredBackColor;
        private Color _headerSelectedBackColor;
        private Color _headerForeColor;
        private Color _headerDisabledForeColor;
        private SolidBrush _brHeaderBackColor;
        private SolidBrush _brHeaderHoveredBackColor;
        private SolidBrush _brHeaderSelectedBackColor;
        private SolidBrush _brHeaderForeColor;
        private SolidBrush _brHeaderDisabledForeColor;
        private StringFormat _sfText;

        // ---- CONSTRUCTORS & DESTRUCTOR ------------------------------------------------------------------------------

        public CategoryControl()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer
                | ControlStyles.ResizeRedraw, true);

            _controlTitles = new Dictionary<Control, string>();

            _headerHeight = 30;
            _headerBackColor = SystemColors.Control;
            _headerSelectedBackColor = SystemColors.Highlight;
            _headerForeColor = SystemColors.ControlText;
            _headerDisabledForeColor = SystemColors.GrayText;
            _sfText = new StringFormat(StringFormatFlags.NoWrap)
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            CreateHeaderBackColorBrush();
            CreateHeaderHoveredBackColorBrush();
            CreateHeaderSelectedBackColorBrush();
            CreateHeaderForeColorBrush();
            CreateHeaderDisabledForeColorBrush();
        }

        // ---- PROPERTIES ---------------------------------------------------------------------------------------------

        [DefaultValue(30)]
        public int HeaderHeight
        {
            get
            {
                return _headerHeight;
            }
            set
            {
                _headerHeight = value;
                Refresh();
                PerformLayout();
            }
        }

        [DefaultValue(typeof(Color), "Control")]
        public Color HeaderBackColor
        {
            get
            {
                return _headerBackColor;
            }
            set
            {
                _headerBackColor = value;
                CreateHeaderBackColorBrush();
                Refresh();
            }
        }

        [DefaultValue(typeof(Color), "Transparent")]
        public Color HeaderHoveredBackColor
        {
            get
            {
                return _headerHoveredBackColor;
            }
            set
            {
                _headerHoveredBackColor = value;
                CreateHeaderHoveredBackColorBrush();
                Refresh();
            }
        }

        [DefaultValue(typeof(Color), "Highlight")]
        public Color HeaderSelectedBackColor
        {
            get
            {
                return _headerSelectedBackColor;
            }
            set
            {
                _headerSelectedBackColor = value;
                CreateHeaderSelectedBackColorBrush();
                Refresh();
            }
        }

        [DefaultValue(typeof(Color), "ControlText")]
        public Color HeaderForeColor
        {
            get
            {
                return _headerForeColor;
            }
            set
            {
                _headerForeColor = value;
                CreateHeaderForeColorBrush();
                Refresh();
            }
        }

        [DefaultValue(typeof(Color), "GrayText")]
        public Color HeaderDisabledForeColor
        {
            get
            {
                return _headerDisabledForeColor;
            }
            set
            {
                _headerDisabledForeColor = value;
                CreateHeaderDisabledForeColorBrush();
                Refresh();
            }
        }

        public Control SelectedControl
        {
            get
            {
                return _selectedControl;
            }
            set
            {
                _selectedControl = value;
                Refresh();
                PerformLayout();
            }
        }

        public override LayoutEngine LayoutEngine
        {
            get
            {
                if (DesignMode)
                {
                    return base.LayoutEngine;
                }
                else
                {
                    if (_layoutEngine == null)
                    {
                        _layoutEngine = new CategoryControlLayoutEngine();
                    }
                    return _layoutEngine;
                }
            }
        }

        private Control HoveredControl
        {
            get
            {
                return _hoveredControl;
            }
            set
            {
                if (_hoveredControl != value)
                {
                    _hoveredControl = value;
                    Refresh();
                }
            }
        }

        // ---- METHODS (PUBLIC) ---------------------------------------------------------------------------------------

        // ---- IExtenderProvider ----

        /// <summary>
        /// Gets a value indicating whether the title property will be made available for the given object.
        /// </summary>
        /// <param name="extendee">The object to check for.</param>
        /// <returns><c>true</c> to provide the property for this object, otherwise <c>false</c>.</returns>
        public bool CanExtend(object extendee)
        {
            Control extendedControl = extendee as Control;
            return extendedControl != null && extendedControl.Parent == this;
        }

        /// <summary>
        /// Gets the title property for the extended control.
        /// </summary>
        /// <param name="control">The control to retrieve the title property for.</param>
        /// <returns>The title for the control or <c>null</c> if it has not set a title yet.</returns>
        public string GetTitle(Control control)
        {
            string title;
            if (_controlTitles.TryGetValue(control, out title))
            {
                return title;
            }
            return null;
        }

        /// <summary>
        /// Sets the title property for the extended control.
        /// </summary>
        /// <param name="control">The control to remember the title property for.</param>
        /// <param name="value">The title to set.</param>
        public void SetTitle(Control control, string value)
        {
            _controlTitles[control] = value;
            Refresh();
        }

        /// <summary>
        /// Returns a value indicating whether the designer should store the title for the given control or not.
        /// </summary>
        /// <param name="control">The control to check for.</param>
        /// <returns><c>true</c> to serialize the property, otherwise <c>false</c>.</returns>
        private bool ShouldSerializeTitle(Control control)
        {
            return _controlTitles.ContainsKey(control);
        }

        /// <summary>
        /// Resets the title property for the given control.
        /// </summary>
        /// <param name="control">The control which title will be reset.</param>
        private void ResetTitle(Control control)
        {
            _controlTitles.Remove(control);
            Refresh();
        }

        // ---- METHODS (PROTECTED) ------------------------------------------------------------------------------------

        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);

            e.Control.EnabledChanged += Control_EnabledChanged;
            if (SelectedControl == null)
            {
                SelectedControl = e.Control;
            }
            else
            {
                Refresh();
            }
        }

        protected override void OnControlRemoved(ControlEventArgs e)
        {
            base.OnControlRemoved(e);

            e.Control.EnabledChanged -= Control_EnabledChanged;
            if (SelectedControl == e.Control)
            {
                SelectedControl = null;
            }
            else
            {
                Refresh();
            }
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            HoveredControl = GetCategoryAt(PointToClient(Cursor.Position));
            base.OnMouseEnter(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            HoveredControl = GetCategoryAt(e.Location);
            base.OnMouseMove(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            HoveredControl = null;
            base.OnMouseLeave(e);
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            // Must be inside the header.
            if (e.Location.Y >= 0 && e.Location.Y < HeaderHeight
                && HoveredControl?.Enabled == true)
            {
                SelectedControl = HoveredControl;
            }

            base.OnMouseClick(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            float buttonWidth = Width / (float)Controls.Count;
            float currentX = 0;
            for (int i = Controls.Count - 1; i >= 0; i--)
            {
                Control control = Controls[i];
                Rectangle buttonRect = new Rectangle(
                    (int)Math.Ceiling(currentX), 0, (int)Math.Ceiling(buttonWidth), HeaderHeight);

                SolidBrush br = control == SelectedControl ? _brHeaderSelectedBackColor : _brHeaderBackColor;
                e.Graphics.FillRectangle(br, buttonRect);
                if (control.Enabled && HoveredControl == control)
                {
                    e.Graphics.FillRectangle(_brHeaderHoveredBackColor, buttonRect);
                }

                SolidBrush brFore = control.Enabled ? _brHeaderForeColor : _brHeaderDisabledForeColor;
                string text = GetTitle(control) ?? control.Text ?? control.Name;
                e.Graphics.DrawString(text, Font, brFore, buttonRect, _sfText);

                currentX += buttonWidth;
            }
        }

        // ---- METHODS (PRIVATE) --------------------------------------------------------------------------------------

        private void CreateHeaderBackColorBrush()
        {
            _brHeaderBackColor = new SolidBrush(HeaderBackColor);
        }

        private void CreateHeaderHoveredBackColorBrush()
        {
            _brHeaderHoveredBackColor = new SolidBrush(HeaderHoveredBackColor);
        }

        private void CreateHeaderSelectedBackColorBrush()
        {
            _brHeaderSelectedBackColor = new SolidBrush(HeaderSelectedBackColor);
        }

        private void CreateHeaderForeColorBrush()
        {
            _brHeaderForeColor = new SolidBrush(HeaderForeColor);
        }

        private void CreateHeaderDisabledForeColorBrush()
        {
            _brHeaderDisabledForeColor = new SolidBrush(HeaderDisabledForeColor);
        }

        private Control GetCategoryAt(Point position)
        {
            // Must be inside the header.
            if (position.Y < 0 || position.Y >= HeaderHeight)
            {
                return null;
            }

            // Must be on a category button.
            int index = position.X / (int)Math.Ceiling(Width / (float)Controls.Count);
            if (index < 0 || index >= Controls.Count)
            {
                return null;
            }
            return Controls[Controls.Count - 1 - index];
        }

        // ---- EVENTHANDLERS ------------------------------------------------------------------------------------------

        private void Control_EnabledChanged(object sender, EventArgs e)
        {
            Refresh();
        }
    }

    public class CategoryControlLayoutEngine : LayoutEngine
    {
        // ---- METHODS (PUBLIC) ---------------------------------------------------------------------------------------

        public override bool Layout(object container, LayoutEventArgs layoutEventArgs)
        {
            CategoryControl parent = (CategoryControl)container;

            foreach (Control control in parent.Controls)
            {
                if (parent.SelectedControl == control)
                {
                    control.Visible = true;
                    control.Location = new Point(
                        parent.Padding.Left + control.Margin.Left,
                        parent.Padding.Top + parent.HeaderHeight + control.Margin.Top);
                    control.Size = new Size(
                        parent.Width - parent.Padding.Horizontal - control.Margin.Horizontal,
                        parent.Height - parent.Padding.Vertical - parent.HeaderHeight - control.Margin.Vertical);
                }
                else
                {
                    control.Visible = false;
                }
            }

            return false;
        }
    }
}

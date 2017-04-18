namespace Syroot.NintenTools.MarioKart8.PerformanceEditor
{
    partial class FormCalculation
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCalculation));
            this._pnButtons = new System.Windows.Forms.Panel();
            this._btOK = new System.Windows.Forms.Button();
            this._btCancel = new System.Windows.Forms.Button();
            this._lbText = new System.Windows.Forms.Label();
            this._tbValue = new System.Windows.Forms.TextBox();
            this._pnButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // _pnButtons
            // 
            this._pnButtons.BackColor = System.Drawing.SystemColors.Control;
            this._pnButtons.Controls.Add(this._btOK);
            this._pnButtons.Controls.Add(this._btCancel);
            this._pnButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._pnButtons.Location = new System.Drawing.Point(0, 78);
            this._pnButtons.Name = "_pnButtons";
            this._pnButtons.Size = new System.Drawing.Size(384, 43);
            this._pnButtons.TabIndex = 1;
            // 
            // _btOK
            // 
            this._btOK.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._btOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._btOK.Location = new System.Drawing.Point(214, 10);
            this._btOK.Margin = new System.Windows.Forms.Padding(0, 10, 10, 10);
            this._btOK.Name = "_btOK";
            this._btOK.Size = new System.Drawing.Size(75, 23);
            this._btOK.TabIndex = 0;
            this._btOK.Text = "&OK";
            this._btOK.UseVisualStyleBackColor = true;
            // 
            // _btCancel
            // 
            this._btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._btCancel.Location = new System.Drawing.Point(299, 10);
            this._btCancel.Margin = new System.Windows.Forms.Padding(0, 10, 10, 10);
            this._btCancel.Name = "_btCancel";
            this._btCancel.Size = new System.Drawing.Size(75, 23);
            this._btCancel.TabIndex = 1;
            this._btCancel.Text = "&Cancel";
            this._btCancel.UseVisualStyleBackColor = true;
            // 
            // _lbText
            // 
            this._lbText.AutoSize = true;
            this._lbText.Location = new System.Drawing.Point(10, 10);
            this._lbText.Name = "_lbText";
            this._lbText.Size = new System.Drawing.Size(280, 15);
            this._lbText.TabIndex = 2;
            this._lbText.Text = "Please enter the number you want to calculate with:";
            // 
            // _tbValue
            // 
            this._tbValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._tbValue.Location = new System.Drawing.Point(13, 38);
            this._tbValue.MaxLength = 10;
            this._tbValue.Name = "_tbValue";
            this._tbValue.Size = new System.Drawing.Size(361, 23);
            this._tbValue.TabIndex = 0;
            this._tbValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._tbValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._tbValue_KeyPress);
            this._tbValue.Validating += new System.ComponentModel.CancelEventHandler(this._tbValue_Validating);
            // 
            // FormCalculation
            // 
            this.AcceptButton = this._btOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.CancelButton = this._btCancel;
            this.ClientSize = new System.Drawing.Size(384, 121);
            this.Controls.Add(this._tbValue);
            this.Controls.Add(this._lbText);
            this.Controls.Add(this._pnButtons);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCalculation";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Calculation";
            this._pnButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel _pnButtons;
        private System.Windows.Forms.Button _btOK;
        private System.Windows.Forms.Button _btCancel;
        private System.Windows.Forms.Label _lbText;
        private System.Windows.Forms.TextBox _tbValue;
    }
}
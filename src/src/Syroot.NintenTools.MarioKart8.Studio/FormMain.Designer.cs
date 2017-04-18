namespace Syroot.NintenTools.MarioKart8.Studio
{
    partial class FormMain
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
            this._dumbControl = new Syroot.Dumb3D.WinForms.Dumb3DControl();
            this.SuspendLayout();
            // 
            // _dumbControl
            // 
            this._dumbControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dumbControl.Location = new System.Drawing.Point(12, 12);
            this._dumbControl.Name = "_dumbControl";
            this._dumbControl.RedrawContinuously = true;
            this._dumbControl.Size = new System.Drawing.Size(600, 417);
            this._dumbControl.TabIndex = 0;
            this._dumbControl.VSync = true;
            this._dumbControl.Render += new System.EventHandler(this._dumbControl_Render);
            this._dumbControl.Load += new System.EventHandler(this._dumbControl_Load);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this._dumbControl);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FormMain";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Dumb3D.WinForms.Dumb3DControl _dumbControl;
    }
}


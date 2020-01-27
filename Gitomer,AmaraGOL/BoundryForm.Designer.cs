namespace Gitomer_AmaraGOL
{
    partial class BoundryForm
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
            this.OK = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.ToroidalBoundry = new System.Windows.Forms.RadioButton();
            this.FiniteBoundry = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // OK
            // 
            this.OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OK.Location = new System.Drawing.Point(34, 78);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(138, 30);
            this.OK.TabIndex = 0;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = true;
            // 
            // Cancel
            // 
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.Location = new System.Drawing.Point(34, 114);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(141, 30);
            this.Cancel.TabIndex = 1;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // ToroidalBoundry
            // 
            this.ToroidalBoundry.AutoSize = true;
            this.ToroidalBoundry.Location = new System.Drawing.Point(34, 12);
            this.ToroidalBoundry.Name = "ToroidalBoundry";
            this.ToroidalBoundry.Size = new System.Drawing.Size(105, 17);
            this.ToroidalBoundry.TabIndex = 2;
            this.ToroidalBoundry.TabStop = true;
            this.ToroidalBoundry.Text = "Toroidal Boundry";
            this.ToroidalBoundry.UseVisualStyleBackColor = true;
            this.ToroidalBoundry.CheckedChanged += new System.EventHandler(this.ToroidalBoundry_CheckedChanged);
            // 
            // FiniteBoundry
            // 
            this.FiniteBoundry.AutoSize = true;
            this.FiniteBoundry.Location = new System.Drawing.Point(34, 45);
            this.FiniteBoundry.Name = "FiniteBoundry";
            this.FiniteBoundry.Size = new System.Drawing.Size(92, 17);
            this.FiniteBoundry.TabIndex = 3;
            this.FiniteBoundry.TabStop = true;
            this.FiniteBoundry.Text = "Finite Boundry";
            this.FiniteBoundry.UseVisualStyleBackColor = true;
            this.FiniteBoundry.CheckedChanged += new System.EventHandler(this.FiniteBoundry_CheckedChanged);
            // 
            // BoundryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(220, 156);
            this.Controls.Add(this.FiniteBoundry);
            this.Controls.Add(this.ToroidalBoundry);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.OK);
            this.Name = "BoundryForm";
            this.Text = "BoundryForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.RadioButton ToroidalBoundry;
        private System.Windows.Forms.RadioButton FiniteBoundry;
    }
}
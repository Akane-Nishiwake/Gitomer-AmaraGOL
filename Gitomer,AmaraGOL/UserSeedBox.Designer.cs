namespace Gitomer_AmaraGOL
{
    partial class UserSeedBox
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
            this.UserSeedGenerator = new System.Windows.Forms.NumericUpDown();
            this.Randomize = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.UserSeedGenerator)).BeginInit();
            this.SuspendLayout();
            // 
            // OK
            // 
            this.OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OK.Location = new System.Drawing.Point(26, 130);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(112, 42);
            this.OK.TabIndex = 0;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = true;
            // 
            // Cancel
            // 
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.Location = new System.Drawing.Point(225, 130);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(109, 42);
            this.Cancel.TabIndex = 1;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            // 
            // UserSeedGenerator
            // 
            this.UserSeedGenerator.Location = new System.Drawing.Point(26, 58);
            this.UserSeedGenerator.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.UserSeedGenerator.Minimum = new decimal(new int[] {
            100000000,
            0,
            0,
            -2147483648});
            this.UserSeedGenerator.Name = "UserSeedGenerator";
            this.UserSeedGenerator.Size = new System.Drawing.Size(112, 20);
            this.UserSeedGenerator.TabIndex = 2;
            this.UserSeedGenerator.ValueChanged += new System.EventHandler(this.UserSeedGenerator_ValueChanged);
            // 
            // Randomize
            // 
            this.Randomize.Location = new System.Drawing.Point(225, 58);
            this.Randomize.Name = "Randomize";
            this.Randomize.Size = new System.Drawing.Size(109, 23);
            this.Randomize.TabIndex = 3;
            this.Randomize.Text = "Randomize";
            this.Randomize.UseVisualStyleBackColor = true;
            this.Randomize.Click += new System.EventHandler(this.Randomize_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(351, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Please either make a seed or have the computer generate a seed for you";
            // 
            // UserSeedBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 184);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Randomize);
            this.Controls.Add(this.UserSeedGenerator);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.OK);
            this.Name = "UserSeedBox";
            this.Text = "UserSeedBox";
            ((System.ComponentModel.ISupportInitialize)(this.UserSeedGenerator)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.NumericUpDown UserSeedGenerator;
        private System.Windows.Forms.Button Randomize;
        private System.Windows.Forms.Label label1;
    }
}
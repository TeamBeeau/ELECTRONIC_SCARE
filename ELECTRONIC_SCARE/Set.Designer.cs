namespace ELECTRONIC_SCARE
{
    partial class Set
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.NumericUpDown numericUpDownDays;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

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

        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblDescription = new Label();
            numericUpDownDays = new NumericUpDown();
            btnSave = new Button();
            btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDownDays).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Arial", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(19, 17);
            lblTitle.Margin = new Padding(6, 0, 6, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(191, 51);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Settings";
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDescription.Location = new Point(19, 100);
            lblDescription.Margin = new Padding(6, 0, 6, 0);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(338, 36);
            lblDescription.TabIndex = 1;
            lblDescription.Text = "Choose retention days:";
            // 
            // numericUpDownDays
            // 
            numericUpDownDays.Font = new Font("Arial", 12F);
            numericUpDownDays.Location = new Point(26, 171);
            numericUpDownDays.Margin = new Padding(6, 6, 6, 6);
            numericUpDownDays.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numericUpDownDays.Name = "numericUpDownDays";
            numericUpDownDays.Size = new Size(195, 44);
            numericUpDownDays.TabIndex = 2;
            numericUpDownDays.Value = new decimal(new int[] { 1000, 0, 0, 0 });
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Arial", 12F, FontStyle.Bold);
            btnSave.Location = new Point(26, 260);
            btnSave.Margin = new Padding(6, 6, 6, 6);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(195, 81);
            btnSave.TabIndex = 3;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("Arial", 12F, FontStyle.Bold);
            btnCancel.Location = new Point(260, 260);
            btnCancel.Margin = new Padding(6, 6, 6, 6);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(195, 81);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // Set
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(487, 401);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(numericUpDownDays);
            Controls.Add(lblDescription);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(6, 6, 6, 6);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Set";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Settings";
            FormClosing += Set_FormClosing;
            ((System.ComponentModel.ISupportInitialize)numericUpDownDays).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}

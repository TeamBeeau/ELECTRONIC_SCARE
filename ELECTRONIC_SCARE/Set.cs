using System;
using System.Windows.Forms;

namespace ELECTRONIC_SCARE
{
    public partial class Set : Form
    {
        public int RetentionDays { get; private set; }

        public Set(int currentRetentionDays)
        {
            InitializeComponent();
            numericUpDownDays.Value = currentRetentionDays;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveRetentionDays();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void Set_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult != DialogResult.OK)
            {
                SaveRetentionDays();
            }
        }

        private void SaveRetentionDays()
        {
            RetentionDays = (int)numericUpDownDays.Value;
            // Save the RetentionDays to a file or settings
            System.IO.File.WriteAllText("settings.txt", RetentionDays.ToString());
        }
    }
}

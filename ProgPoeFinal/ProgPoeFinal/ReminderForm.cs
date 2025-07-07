using System;
using System.Windows.Forms;

namespace ProgPoeFinal
{
    public partial class ReminderForm : Form
    {
        public DateTime SelectedDate { get; private set; }

        public ReminderForm()
        {
            InitializeComponent();
            SelectedDate = DateTime.Now;
            datePicker.Value = DateTime.Now; // Initialize with current date/time
            this.btnSet.Click += btnSet_Click;
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            string message = txtReminderMessage.Text.Trim();
            DateTime reminderTime = datePicker.Value;

            if (string.IsNullOrEmpty(message))
            {
                MessageBox.Show("Please enter a reminder message.",
                    "Input Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            SelectedDate = reminderTime;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // Handle window close (X button) as cancel
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (this.DialogResult != DialogResult.OK)
            {
                this.DialogResult = DialogResult.Cancel;
            }
            base.OnFormClosing(e);
        }
    }
}
using System.Windows.Forms;
using System.Drawing; // Added for Color

namespace ProgPoeFinal
{
    public partial class ActivityLogForm : Form
    {
        public ActivityLogForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Chatbot Activity Log";
        }

        public void SetLog(string logContent)
        {
            rtbActivityLog.Clear();
            // Assuming logContent has newlines for each entry, just append it
            rtbActivityLog.AppendText(logContent);
            rtbActivityLog.SelectionStart = 0; // Scroll to top
            rtbActivityLog.ScrollToCaret(); // Ensure the scrollbar is at the top
        }
    }
}
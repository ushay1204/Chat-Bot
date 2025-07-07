using System;
using System.Windows.Forms;
using System.Drawing;

namespace ProgPoeFinal
{
    public partial class MainForm : Form
    {
        private CyberSecurityBot bot;
        private TaskManagerForm taskManagerForm;
        private ReminderForm reminderForm;
        private QuizForm quizForm;
        private ActivityLogForm activityLogForm;
        private string userName;

        public MainForm(string userName)
        {
            InitializeComponent();
            this.userName = userName;

            // Initialize forms with proper ownership
            taskManagerForm = new TaskManagerForm();
            reminderForm = new ReminderForm();
            quizForm = new QuizForm();
            activityLogForm = new ActivityLogForm();

            // Pass all necessary forms to the bot
            bot = new CyberSecurityBot(this, taskManagerForm, reminderForm, quizForm);
            bot.SetUserName(userName);

            // Set up quiz form reference
            quizForm.SetBotReference(bot);

            // Display initial messages
            DisplayHelper.DisplayCyberSecurityLogo(chatDisplay);
            UpdateConversation($"Bot: Hello {this.userName}! I'm your cybersecurity assistant. How can I help you today?");
            UpdateConversation("Bot: You can ask me 'menu' to see all available options.");
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string userMessage = userInput.Text;

            if (!string.IsNullOrWhiteSpace(userMessage))
            {
                UpdateConversation($"You: {userMessage}");

                if (userMessage.Trim().Equals("show activity log", StringComparison.OrdinalIgnoreCase) ||
                    userMessage.Trim().Equals("what have you done for me?", StringComparison.OrdinalIgnoreCase))
                {
                    string logContent = bot.ShowActivityLog();
                    activityLogForm.SetLog(logContent);
                    activityLogForm.Show(this); // Show with owner
                    activityLogForm.BringToFront();
                    userInput.Clear();
                    return;
                }

                string botResponse = bot.ProcessInput(userMessage);
                UpdateConversation($"Bot: {botResponse}");
                userInput.Clear();
            }
        }

        private void userInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                btnSend_Click(sender, e);
            }
        }

        private void UpdateConversation(string message)
        {
            if (message.StartsWith("Bot:"))
            {
                DisplayHelper.AppendColoredText(chatDisplay, message + Environment.NewLine, Color.Green);
            }
            else if (message.StartsWith("You:"))
            {
                DisplayHelper.AppendColoredText(chatDisplay, message + Environment.NewLine, Color.White);
            }
            else
            {
                chatDisplay.AppendText(message + Environment.NewLine);
            }
            chatDisplay.ScrollToCaret();
        }

        private void btnTaskManager_Click(object sender, EventArgs e)
        {
            taskManagerForm.Show(this); // Show with owner
            taskManagerForm.BringToFront();
            UpdateConversation("Bot: Opening Task Manager...");
            bot.LogActivity($"User opened Task Manager.");
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Confirm Exit",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                // Clean up forms
                taskManagerForm?.Close();
                reminderForm?.Close();
                quizForm?.Close();
                activityLogForm?.Close();
            }
        }
    }
}
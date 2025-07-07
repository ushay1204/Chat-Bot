using System;
using System.Windows.Forms;

namespace ProgPoeFinal
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string userName = "User"; // Default name

            // Show NameInputForm to get the user's name
            using (NameInputForm nameForm = new NameInputForm())
            {
                if (nameForm.ShowDialog() == DialogResult.OK)
                {
                    userName = nameForm.UserName;
                    if (string.IsNullOrWhiteSpace(userName))
                    {
                        userName = "User"; // Fallback if user enters blank
                    }
                }
            }

            // Pass the userName to MainForm
            Application.Run(new MainForm(userName));
        }
    }
}
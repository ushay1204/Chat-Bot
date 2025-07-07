using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProgPoeFinal
{
    static class DisplayHelper
    {
        public static string GetCyberSecurityLogo()
        {
            // Re-aligned and formatted ASCII art
            return @"
             @      @
     / \     { _____}      / \
   /  |  \___/*******\___/  |  \
  (   I  /   ~   '   ~   \  I   )
   \  |  |   0       0   |  |  /
     \   |       A       |   /
       \__    _______    __/
          \_____________/
    _-------*         *-------_
   /  /---   CYBER  ---       \  \
 /  /     (  SECURITY )     \  \
{  (     (    BOT    )     )  }
 \  \    |           |    /  /
   \  \  |           |  /  /
    **** |           | ****
   //|\\  \___________/  //|\\
   *         '*** ***'         *
  ***.       .*** ***.       .***
  '*************' '*************'
"; // The verbatim string ends here.
        }

        public static void AppendColoredText(RichTextBox box, string text, Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;
            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor; 
        }

        public static void DisplayCyberSecurityLogo(RichTextBox outputRichTextBox)
        {
            outputRichTextBox.Clear();

          
        
            outputRichTextBox.Font = new Font("Consolas", 10, FontStyle.Regular); 

            string logo = GetCyberSecurityLogo();

         
            AppendColoredText(outputRichTextBox, logo + Environment.NewLine, Color.Cyan); 

           
            AppendColoredText(outputRichTextBox, "\n\tWelcome to Ushay Cyber Secure - Your Cybersecurity Awareness Bot\n\n", Color.Magenta);
        }

        public static void ShowError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
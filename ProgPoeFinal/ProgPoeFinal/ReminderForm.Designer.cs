namespace ProgPoeFinal
{
    partial class ReminderForm
    {
        private System.ComponentModel.IContainer components = null;

        // Existing controls
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.Button btnSet;

        // NEW controls for the reminder message
        private System.Windows.Forms.TextBox txtReminderMessage;
        private System.Windows.Forms.Label lblReminderMessage;


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            // Initialize NEW controls first (good practice)
            this.txtReminderMessage = new System.Windows.Forms.TextBox();
            this.lblReminderMessage = new System.Windows.Forms.Label();

            // Existing controls
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.btnSet = new System.Windows.Forms.Button();

            this.SuspendLayout();

            //
            // lblReminderMessage
            //
            this.lblReminderMessage.AutoSize = true;
            this.lblReminderMessage.Location = new System.Drawing.Point(12, 15);
            this.lblReminderMessage.Name = "lblReminderMessage";
            this.lblReminderMessage.Size = new System.Drawing.Size(95, 13);
            this.lblReminderMessage.TabIndex = 0; // Adjust TabIndex if needed
            this.lblReminderMessage.Text = "Reminder Message:";
            //
            // txtReminderMessage
            //
            this.txtReminderMessage.Location = new System.Drawing.Point(15, 31);
            this.txtReminderMessage.Multiline = true; // Allow multiple lines for longer messages
            this.txtReminderMessage.Name = "txtReminderMessage"; // This is the name your .cs code will use
            this.txtReminderMessage.Size = new System.Drawing.Size(270, 50); // Adjusted size
            this.txtReminderMessage.TabIndex = 1; // Adjust TabIndex if needed
            //
            // datePicker
            //
            this.datePicker.Location = new System.Drawing.Point(15, 95); // Adjusted position
            this.datePicker.Name = "datePicker"; // Ensure this name is correct
            this.datePicker.Size = new System.Drawing.Size(270, 20); // Adjusted size
            this.datePicker.TabIndex = 2; // Adjust TabIndex if needed
            //
            // btnSet
            //
            this.btnSet.Location = new System.Drawing.Point(95, 130); // Adjusted position
            this.btnSet.Name = "btnSet"; // Ensure this name is correct
            this.btnSet.Size = new System.Drawing.Size(100, 30);
            this.btnSet.TabIndex = 3; // Adjust TabIndex if needed
            this.btnSet.Text = "Set Reminder";
            this.btnSet.UseVisualStyleBackColor = true; // Recommended for buttons
            // Hook up the Click event for the button (you'll handle this in ReminderForm.cs)
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click); // Make sure this line is present and matches your event handler name


            //
            // ReminderForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 180); // Adjusted form size
            this.Controls.Add(this.lblReminderMessage); // Add new label to controls
            this.Controls.Add(this.txtReminderMessage); // Add new textbox to controls
            this.Controls.Add(this.datePicker);
            this.Controls.Add(this.btnSet);

            this.Name = "ReminderForm";
            this.Text = "Set Reminder"; // Changed default title for clarity
            this.ResumeLayout(false);
            this.PerformLayout(); // Required if AutoSize or Anchor/Dock properties are used
        }
    }
}
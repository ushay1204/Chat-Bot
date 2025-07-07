namespace ProgPoeFinal
{
    partial class TaskManagerForm
    {
        private System.ComponentModel.IContainer components = null;

        // Existing controls
        private System.Windows.Forms.ListBox taskListBox;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button btnAddTask;
        private System.Windows.Forms.Button btnDeleteTask;
        private System.Windows.Forms.Button btnMarkComplete;
        private System.Windows.Forms.Button btnSetReminder;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDescription;

        // NEW control for Due Date
        private System.Windows.Forms.DateTimePicker dtpDueDate;
        private System.Windows.Forms.Label lblDueDate; // Label for the due date picker


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            // Initialize NEW controls
            this.dtpDueDate = new System.Windows.Forms.DateTimePicker();
            this.lblDueDate = new System.Windows.Forms.Label();

            // Initialize existing controls
            this.taskListBox = new System.Windows.Forms.ListBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.btnAddTask = new System.Windows.Forms.Button();
            this.btnDeleteTask = new System.Windows.Forms.Button();
            this.btnMarkComplete = new System.Windows.Forms.Button();
            this.btnSetReminder = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();

            this.SuspendLayout();

            //
            // taskListBox
            //
            this.taskListBox.FormattingEnabled = true;
            this.taskListBox.Location = new System.Drawing.Point(12, 12);
            this.taskListBox.Name = "taskListBox"; // Ensure this name is correct
            this.taskListBox.Size = new System.Drawing.Size(260, 147);
            this.taskListBox.TabIndex = 0; // Set TabIndex
            //
            // lblTitle
            //
            this.lblTitle.Location = new System.Drawing.Point(12, 170);
            this.lblTitle.Name = "lblTitle"; // Ensure this name is correct
            this.lblTitle.Size = new System.Drawing.Size(100, 15);
            this.lblTitle.TabIndex = 1; // Set TabIndex
            this.lblTitle.Text = "Task Title:";
            //
            // txtTitle
            //
            this.txtTitle.Location = new System.Drawing.Point(12, 190);
            this.txtTitle.Name = "txtTitle"; // Ensure this name is correct
            this.txtTitle.Size = new System.Drawing.Size(260, 20);
            this.txtTitle.TabIndex = 2; // Set TabIndex
            //
            // lblDescription
            //
            this.lblDescription.Location = new System.Drawing.Point(12, 215);
            this.lblDescription.Name = "lblDescription"; // Ensure this name is correct
            this.lblDescription.Size = new System.Drawing.Size(100, 15);
            this.lblDescription.TabIndex = 3; // Set TabIndex
            this.lblDescription.Text = "Description:";
            //
            // txtDescription
            //
            this.txtDescription.Location = new System.Drawing.Point(12, 235);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription"; // Ensure this name is correct
            this.txtDescription.Size = new System.Drawing.Size(260, 60);
            this.txtDescription.TabIndex = 4; // Set TabIndex
            //
            // lblDueDate
            //
            this.lblDueDate.Location = new System.Drawing.Point(12, 300); // New position for label
            this.lblDueDate.Name = "lblDueDate";
            this.lblDueDate.Size = new System.Drawing.Size(100, 15);
            this.lblDueDate.TabIndex = 5; // Set TabIndex
            this.lblDueDate.Text = "Due Date:";
            //
            // dtpDueDate
            //
            this.dtpDueDate.Format = System.Windows.Forms.DateTimePickerFormat.Short; // Display only date
            this.dtpDueDate.Location = new System.Drawing.Point(12, 320); // New position for picker
            this.dtpDueDate.Name = "dtpDueDate"; // This is the name your .cs code will use
            this.dtpDueDate.Size = new System.Drawing.Size(260, 20);
            this.dtpDueDate.TabIndex = 6; // Set TabIndex
            //
            // btnAddTask
            //
            this.btnAddTask.Location = new System.Drawing.Point(12, 355); // Adjusted position
            this.btnAddTask.Name = "btnAddTask"; // Ensure this name is correct
            this.btnAddTask.Size = new System.Drawing.Size(120, 30);
            this.btnAddTask.TabIndex = 7; // Set TabIndex
            this.btnAddTask.Text = "Add Task";
            this.btnAddTask.UseVisualStyleBackColor = true;
            this.btnAddTask.Click += new System.EventHandler(this.btnAddTask_Click); // Hook up click event
            //
            // btnDeleteTask
            //
            this.btnDeleteTask.Location = new System.Drawing.Point(152, 355); // Adjusted position
            this.btnDeleteTask.Name = "btnDeleteTask"; // Ensure this name is correct
            this.btnDeleteTask.Size = new System.Drawing.Size(120, 30);
            this.btnDeleteTask.TabIndex = 8; // Set TabIndex
            this.btnDeleteTask.Text = "Delete Selected"; // Changed text for clarity
            this.btnDeleteTask.UseVisualStyleBackColor = true;
            this.btnDeleteTask.Click += new System.EventHandler(this.btnDeleteTask_Click); // Hook up click event
            //
            // btnMarkComplete
            //
            this.btnMarkComplete.Location = new System.Drawing.Point(12, 395); // Adjusted position
            this.btnMarkComplete.Name = "btnMarkComplete"; // Ensure this name is correct
            this.btnMarkComplete.Size = new System.Drawing.Size(120, 30);
            this.btnMarkComplete.TabIndex = 9; // Set TabIndex
            this.btnMarkComplete.Text = "Toggle Complete";
            this.btnMarkComplete.UseVisualStyleBackColor = true;
            this.btnMarkComplete.Click += new System.EventHandler(this.btnMarkComplete_Click); // Hook up click event
            //
            // btnSetReminder
            //
            this.btnSetReminder.Location = new System.Drawing.Point(152, 395); // Adjusted position
            this.btnSetReminder.Name = "btnSetReminder"; // Ensure this name is correct
            this.btnSetReminder.Size = new System.Drawing.Size(120, 30);
            this.btnSetReminder.TabIndex = 10; // Set TabIndex
            this.btnSetReminder.Text = "Set Reminder";
            this.btnSetReminder.UseVisualStyleBackColor = true;
            // You might want to add a click event here, if it should do something on this form
            // e.g., this.btnSetReminder.Click += new System.EventHandler(this.btnSetReminder_Click);
            //
            // TaskManagerForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 435); // Adjusted client size to accommodate new controls
            this.Controls.Add(this.dtpDueDate); // Add new DateTimePicker
            this.Controls.Add(this.lblDueDate); // Add new Label
            this.Controls.Add(this.taskListBox);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.btnAddTask);
            this.Controls.Add(this.btnDeleteTask);
            this.Controls.Add(this.btnMarkComplete);
            this.Controls.Add(this.btnSetReminder);
            this.Name = "TaskManagerForm";
            this.Text = "Task Manager";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ProgPoeFinal
{
    // This form provides a GUI for managing tasks: adding, deleting, completing, and setting reminders
    public partial class TaskManagerForm : Form
    {
        private List<TaskItem> tasks = new List<TaskItem>(); // Internal task list

        // Public property used by other classes like CyberSecurityBot
        public int TaskCount => tasks.Count;

        public TaskManagerForm() 
        {
            InitializeComponent(); // Designer-generated UI setup

            // Connect UI buttons to their event handlers
            this.btnAddTask.Click += new EventHandler(this.btnAddTask_Click);
            this.btnDeleteTask.Click += new EventHandler(this.btnDeleteTask_Click);
            this.btnMarkComplete.Click += new EventHandler(this.btnMarkComplete_Click);

            // Prevent the form from being disposed when closed
            this.FormClosing += TaskManagerForm_FormClosing;

            // Preload some sample tasks for demonstration/testing
            tasks.Add(new TaskItem("Review security logs", "Check daily logs for anomalies", DateTime.Now.AddDays(-2), true));
            tasks.Add(new TaskItem("Update antivirus", "Install latest definitions and run full scan", DateTime.Now.AddDays(1)));
            tasks.Add(new TaskItem("Attend security training", "Online course on phishing awareness", DateTime.Now.AddDays(5)));

            DisplayTasks(); // Display the tasks in the UI
        }

        // Prevents full form disposal when user clicks X — hides instead
        private void TaskManagerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        // Adds a new task to the list and refreshes the display
        public void AddTask(TaskItem task)
        {
            tasks.Add(task);
            DisplayTasks();
        }

        // Opens the task manager form and refreshes the display
        public void ShowForm()
        {
            this.Show();
            this.BringToFront();
            DisplayTasks();
        }

        // Clears all tasks from the list
        public void ClearTasks()
        {
            tasks.Clear();
            DisplayTasks();
            MessageBox.Show("All tasks cleared.", "Tasks", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Marks the task at the given index as completed
        public bool CompleteTask(int index)
        {
            if (index >= 0 && index < tasks.Count)
            {
                tasks[index].IsCompleted = true;
                DisplayTasks();
                return true;
            }
            return false;
        }

        // Sets a due date reminder for the task at the given index
        public void SetTaskReminder(int index, DateTime dueDate)
        {
            if (index >= 0 && index < tasks.Count)
            {
                tasks[index].DueDate = dueDate;
                DisplayTasks();
            }
        }

        // Returns the title of the task at the given index
        public string GetTaskTitle(int index)
        {
            if (index >= 0 && index < tasks.Count)
            {
                return tasks[index].Title;
            }
            return "Invalid Task";
        }

        // Returns the full string representation of a task
        public string GetTaskDetails(int index)
        {
            if (index >= 0 && index < tasks.Count)
            {
                return tasks[index].ToString(); // Uses TaskItem's ToString()
            }
            return "Invalid Task";
        }

        // Populates the list box with current task data
        private void DisplayTasks()
        {
            taskListBox.Items.Clear();

            if (tasks.Count == 0)
            {
                taskListBox.Items.Add("No tasks available.");
                return;
            }

            for (int i = 0; i < tasks.Count; i++)
            {
                taskListBox.Items.Add($"{i + 1}. {tasks[i]}");
            }
        }

        // Event: Add task from text fields
        private void btnAddTask_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text.Trim();
            string description = txtDescription.Text.Trim();
            DateTime dueDate = dtpDueDate.Value;

            if (string.IsNullOrEmpty(title))
            {
                MessageBox.Show("Please enter a task title.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            AddTask(new TaskItem(title, description, dueDate));

            txtTitle.Clear();
            txtDescription.Clear();

            MessageBox.Show("Task added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Event: Delete selected task or prompt to clear all
        private void btnDeleteTask_Click(object sender, EventArgs e)
        {
            if (taskListBox.SelectedIndex != -1)
            {
                int selectedIndex = taskListBox.SelectedIndex;
                tasks.RemoveAt(selectedIndex);
                DisplayTasks();
                MessageBox.Show("Selected task deleted.", "Task Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DialogResult result = MessageBox.Show("No task selected. Do you want to clear ALL tasks?", "Delete Tasks", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    ClearTasks();
                }
            }
        }

        // Event: Toggle completion status of selected task
        private void btnMarkComplete_Click(object sender, EventArgs e)
        {
            if (taskListBox.SelectedIndex != -1)
            {
                int selectedIndex = taskListBox.SelectedIndex;

                if (selectedIndex >= 0 && selectedIndex < tasks.Count)
                {
                    // Toggle between complete and incomplete
                    tasks[selectedIndex].IsCompleted = !tasks[selectedIndex].IsCompleted;
                    DisplayTasks();
                    MessageBox.Show($"Task '{tasks[selectedIndex].Title}' completion status toggled.", "Task Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Please select a task to toggle completion status.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}

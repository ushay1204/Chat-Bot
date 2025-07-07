// TaskItem.cs
using System;

namespace ProgPoeFinal // Ensure this namespace is correct
{
    public class TaskItem
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime? DueDate { get; set; } // Nullable DateTime

        // Constructor to match common usage if needed
        public TaskItem() { }

        public TaskItem(string title, string description, DateTime? dueDate = null, bool isCompleted = false)
        {
            Title = title;
            Description = description;
            DueDate = dueDate;
            IsCompleted = isCompleted;
        }

        // Override ToString for display in ListBox etc.
        public override string ToString()
        {
            string status = IsCompleted ? "[Done]" : "";
            string due = DueDate.HasValue ? $" (Due: {DueDate.Value.ToShortDateString()})" : "";
            // Combine Title and Description for display, perhaps
            string displayContent = string.IsNullOrEmpty(Description) ? Title : $"{Title}: {Description}";
            return $"{displayContent} {status}{due}".Trim();
        }
    }
}
using System;
using System.Text.RegularExpressions;
using System.Linq;

namespace ProgPoeFinal
{
    // A helper class for basic Natural Language Processing (NLP) functions
    public static class NlpHelper
    {
   
        public static (string intent, string entity) ParseInput(string input)
        {
            input = input.ToLower().Trim();

            // Detect intent to complete a task
            if (input.Contains("complete task") || input.Contains("mark done") || input.Contains("task complete") ||
                input.Contains("finished task") || input.Contains("done with task"))
                return ("complete task", input
                    .Replace("complete task", "")
                    .Replace("mark done", "")
                    .Replace("task complete", "")
                    .Replace("finished task", "")
                    .Replace("done with task", "")
                    .Trim());

            // Detect intent to add a task and extract task description
            if (input.StartsWith("add task") || input.StartsWith("create task") || input.Contains("new task") ||
                input.Contains("remind me to") || input.Contains("set up a") || input.Contains("make a"))
            {
                string entity = input;

                if (input.StartsWith("add task")) entity = input.Substring("add task".Length);
                else if (input.StartsWith("create task")) entity = input.Substring("create task".Length);
                else if (input.Contains("new task")) entity = input.Substring(input.IndexOf("new task") + "new task".Length);

                return ("add task", entity.Trim());
            }

            // Detect intent to set a reminder and extract related details
            if (input.StartsWith("set reminder") || input.StartsWith("remind me") || input.Contains("due date") ||
                input.Contains("notify me") || input.Contains("alert me") || input.Contains("schedule for"))
            {
                string entity = input;

                if (input.StartsWith("set reminder")) entity = input.Substring("set reminder".Length);
                else if (input.StartsWith("remind me")) entity = input.Substring("remind me".Length);

                return ("set reminder", entity.Trim());
            }

            // Detect intent to start a quiz
            if (input.Contains("start quiz") || input.Contains("begin quiz") || input.Contains("take quiz") ||
                input.Contains("begin test") || input.Contains("start test") || input.Contains("cybersecurity quiz"))
                return ("start quiz", "");

            // Detect intent to show activity log
            if (input.Contains("show log") || input.Contains("activity log") || input.Contains("my history") ||
                input.Contains("what have you done") || input.Contains("view log"))
                return ("show log", "");

            // No known intent matched
            return (null, null);
        }

       
    
        public static DateTime? ParseDate(string input)
        {
            input = input.ToLower();

            // Handle relative dates
            if (input.Contains("tomorrow"))
                return DateTime.Now.AddDays(1);

            if (input.Contains("next week") || input.Contains("in a week"))
                return DateTime.Now.AddDays(7);

            if (input.Contains("next month") || input.Contains("in a month"))
                return DateTime.Now.AddMonths(1);

            // Parse phrases like "in 3 days"
            if (input.Contains("in ") && input.Contains("days"))
            {
                var match = Regex.Match(input, @"in (\d+) days?");
                if (match.Success && int.TryParse(match.Groups[1].Value, out int days))
                    return DateTime.Now.AddDays(days);
            }

            // Parse phrases like "in 2 hours"
            if (input.Contains("in ") && input.Contains("hours"))
            {
                var match = Regex.Match(input, @"in (\d+) hours?");
                if (match.Success && int.TryParse(match.Groups[1].Value, out int hours))
                    return DateTime.Now.AddHours(hours);
            }

            // Handle "on YYYY-MM-DD" format
            var onDateMatch = Regex.Match(input, @"on (\d{4}-\d{2}-\d{2})");
            if (onDateMatch.Success && DateTime.TryParse(onDateMatch.Groups[1].Value, out DateTime onDate))
                return onDate;

            // General date parsing (e.g., "July 1", "1/7/2025")
            if (DateTime.TryParse(input, out DateTime generalDate))
                return generalDate;

            // No recognizable date found
            return null;
        }
    }
}

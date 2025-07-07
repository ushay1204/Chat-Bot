using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ProgPoeFinal
{
    public class CyberSecurityBot
    {
        private readonly Dictionary<string, string> responses;
        private readonly Dictionary<string, string[]> keywordMap;
        private string currentTopic = null;
        private int followUpCount = 0;
        private string rememberedTopic = null;
        private readonly Random random = new Random();
        private readonly MainForm mainForm;
        private readonly TaskManagerForm taskManagerForm;
        private readonly ReminderForm reminderForm;
        private readonly QuizForm quizForm;
        private List<string> activityLog = new List<string>();
        private const int MaxLogEntries = 10;
        private string userName = "User";

        public CyberSecurityBot(MainForm mainForm, TaskManagerForm taskManagerForm,
            ReminderForm reminderForm, QuizForm quizForm)
        {
            this.mainForm = mainForm;
            this.taskManagerForm = taskManagerForm;
            this.reminderForm = reminderForm;
            this.quizForm = quizForm;
            responses = BotData.GetResponses();
            keywordMap = InitializeKeywordMap();
        }

        public void SetUserName(string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                userName = name;
                LogActivity($"User's name set to: {userName}");
            }
        }

        private Dictionary<string, string[]> InitializeKeywordMap()
        {
            return new Dictionary<string, string[]>(StringComparer.OrdinalIgnoreCase)
            {
                { "wifi", new[] { "wifi", "wi fi", "wireless", "router", "network", "internet", "home network" } },
                { "shopping", new[] { "shop", "buy", "purchase", "online store", "ecommerce", "amazon", "ebay", "online shopping" } },
                { "malware", new[] { "malware", "virus", "antivirus", "ransomware", "trojan", "spyware", "computer virus" } },
                { "two factor authentication", new[] { "two factor", "2fa", "authenticator", "multi factor", "password", "verification code", "login security", "account security" } },
                { "social engineering", new[] { "social engineering", "phishing", "scam", "impersonation", "email scam", "online scam", "fake email" } },
                { "device encryption", new[] { "device encryption", "encrypt", "bitlocker", "filevault", "secure device", "data protection", "hard drive security" } },
                { "mobile security", new[] { "mobile security", "app permissions", "phone safety", "android security", "ios security", "smartphone", "tablet security" } },
                { "cloud storage", new[] { "cloud storage", "google drive", "dropbox", "onedrive", "privacy", "online storage", "file storage", "backup" } },
                { "social media", new[] { "social media", "facebook", "instagram", "twitter", "privacy settings", "privacy", "social network", "online profile" } },
                { "public wifi", new[] { "public wifi", "coffee shop wifi", "hotel wifi", "free wifi", "airport wifi", "public network", "unsecured wifi" } },
                { "how are you", new[] { "how are you", "hows it going", "how's everything", "how you doing" } },
                { "what's your purpose", new[] { "whats your purpose", "what is your purpose", "whats ur purpose", "what is ur purpose", "why were you made", "what do you do" } },
                { "what can I ask", new[] { "what can i ask", "what can you do", "what do you know", "what topics" } },
                { "menu", new[] { "menu", "options", "choices", "topics", "help" } },
                { "explain more", new[] { "explain", "more", "details", "elaborate", "clarify", "confused", "confusing", "don't understand", "i'm lost", "lost", "can you explain again", "explain again", "go deeper" } },
                { "continue", new[] { "continue", "go on", "what else", "next", "more info", "keep going" } },
                { "add task", GetTaskPhrases() },
                { "tasks", GetTaskListPhrases() },
                { "reminder", GetReminderPhrases() },
                { "quiz", GetQuizPhrases() },
                { "start quiz", GetStartQuizPhrases() },
                { "activity log", GetActivityLogPhrases() },
                { "complete task", GetCompleteTaskPhrases() }
            };
        }

        private string[] GetTaskPhrases() => new[]
        {
            "add task", "create task", "new task", "need to", "want to", "remind me to",
            "set up a", "make a", "i should", "remember to", "can you add", "please create",
            "i need to", "help me with", "task to add", "create a reminder to"
        };

        private string[] GetTaskListPhrases() => new[]
        {
            "show tasks", "task list", "my tasks", "view tasks", "what tasks", "list tasks",
            "current tasks", "existing tasks", "tasks i have", "show my tasks", "what do i have to do"
        };

        private string[] GetReminderPhrases() => new[]
        {
            "set reminder", "remind me", "due date", "notify me", "alert me",
            "schedule for", "set alert", "remember to", "can you remind", "please remind",
            "i need a reminder", "create reminder", "add reminder", "reminder for", "when should i"
        };

        private string[] GetQuizPhrases() => new[]
        {
            "quiz", "test", "cybersecurity quiz", "knowledge test", "security questions",
            "cyber quiz", "test me", "challenge me", "security quiz", "questionnaire"
        };

        private string[] GetStartQuizPhrases() => new[]
        {
            "start quiz", "begin quiz", "take quiz", "begin test", "start test",
            "take test", "begin questions", "start challenge", "i want to quiz",
            "can we quiz", "let's test", "ready for quiz", "do the quiz", "begin the test"
        };

        private string[] GetActivityLogPhrases() => new[]
        {
            "activity log", "what have you done", "recent actions", "my history",
            "show history", "view log", "see activity", "past actions",
            "what did i do", "show my activity", "action log", "my past questions"
        };

        private string[] GetCompleteTaskPhrases() => new[]
        {
            "complete task", "mark done", "task complete", "finished task",
            "done with task", "task finished", "completed", "mark as complete"
        };

        public string ProcessInput(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return "Please type a question or 'menu'";
            }

            Match nameMatch = Regex.Match(input, @"my name is (\w+)", RegexOptions.IgnoreCase);

            if (nameMatch.Success)
            {
                this.userName = nameMatch.Groups[1].Value;
                LogActivity($"User changed name to: {this.userName}");
                return $"Nice to meet you, {this.userName}! How can I help you with cybersecurity today?";
            }

            LogActivity($"User input: '{input}'");

            var (intent, entity) = NlpHelper.ParseInput(input);

            switch (intent)
            {
                case "add task":
                    return HandleTaskCommand(entity);
                case "set reminder":
                    return HandleReminderCommand(entity);
                case "start quiz":
                    return StartQuiz();
                case "show log":
                    return ShowActivityLog();
                case "complete task":
                    return HandleCompleteTask(entity);
            }

            string normalizedInput = NormalizeInput(input);

            string commandResponse = ProcessCommands(normalizedInput);

            if (commandResponse != null)
            {
                return commandResponse;
            }

            string sentimentMessage = GetSentimentMessage(normalizedInput);
            bool hasSentiment = !string.IsNullOrEmpty(sentimentMessage);

            if (normalizedInput.StartsWith("i am interested in ") || normalizedInput.StartsWith("im interested in "))
            {
                return HandleInterestExpression(normalizedInput);
            }

            if (normalizedInput.Equals("menu"))
            {
                currentTopic = null;
                followUpCount = 0;
                LogActivity($"User requested 'menu'.");
                return responses["menu"];
            }

            if (currentTopic != null)
            {
                if (keywordMap["explain more"].Any(phrase => normalizedInput.Contains(phrase)))
                {
                    return ProvideFollowUp(currentTopic);
                }
                if (keywordMap["continue"].Any(phrase => normalizedInput.Contains(phrase)))
                {
                    return ContinueTopic(currentTopic);
                }
            }

            var topicResponse = MatchTopic(normalizedInput, hasSentiment, sentimentMessage);

            if (topicResponse != null)
            {
                return topicResponse;
            }

            return GenerateFallbackResponse(hasSentiment, sentimentMessage);
        }

        private string NormalizeInput(string input)
        {
            return new string(input.ToLower()
                .Where(c => char.IsLetterOrDigit(c) || char.IsWhiteSpace(c) || c == '-')
                .ToArray());
        }

        private string ProcessCommands(string normalizedInput)
        {
            if (keywordMap["tasks"].Any(phrase => normalizedInput.StartsWith(phrase.Replace("^", ""))))
            {
                return ShowTaskList();
            }
            return null;
        }

        private string HandleInterestExpression(string normalizedInput)
        {
            string interest = normalizedInput.Replace("i am interested in", "").Replace("im interested in", "").Trim();
            foreach (var topic in keywordMap.Keys)
            {
                if (topic.Contains(interest) || interest.Contains(topic))
                {
                    rememberedTopic = topic;
                    LogActivity($"User expressed interest in: {topic}");
                    return $"Great, {userName}! I'll remember that you're interested in {topic}. It's a crucial part of staying safe online.";
                }
            }
            return "Thanks for sharing your interest! I'll try to remember that.";
        }

        private string MatchTopic(string normalizedInput, bool hasSentiment, string sentimentMessage)
        {
            foreach (var entry in keywordMap)
            {
                foreach (var keyword in entry.Value)
                {
                    if (normalizedInput.Contains(keyword.Replace("^", "")))
                    {
                        if (responses.TryGetValue(entry.Key, out string response))
                        {
                            currentTopic = entry.Key;
                            followUpCount = 0;
                            var responseText = new StringBuilder();

                            if (hasSentiment)
                            {
                                responseText.AppendLine(sentimentMessage);
                                responseText.AppendLine();
                            }

                            if (!string.IsNullOrEmpty(rememberedTopic) && entry.Key != rememberedTopic && IsCybersecurityTopic(entry.Key))
                            {
                                responseText.AppendLine($"Since you're interested in {rememberedTopic}, this topic might also be useful.");
                                responseText.AppendLine();
                            }

                            responseText.Append(response);

                            if (IsCybersecurityTopic(entry.Key))
                            {
                                responseText.AppendLine();
                                responseText.AppendLine("Would you like me to explain more about this topic? (Type 'explain more' or 'continue')");
                            }

                            LogActivity($"Discussing topic: {entry.Key}");

                            return responseText.ToString();
                        }
                    }
                }
            }
            return null;
        }

        private string GenerateFallbackResponse(bool hasSentiment, string sentimentMessage)
        {
            if (hasSentiment)
            {
                var response = new StringBuilder(sentimentMessage);
                response.AppendLine();
                response.AppendLine();
                if (currentTopic != null)
                {
                    response.AppendLine($"We were discussing {currentTopic}. Would you like to continue with that?");
                }
                else
                {
                    response.AppendLine("You can ask me about any cybersecurity concerns you have. Type 'menu' to see topics I can help with.");
                }
                return response.ToString();
            }
            if (currentTopic != null)
            {
                return $"I'm still discussing {currentTopic}. Type 'explain more' for details or ask about another topic.";
            }
            return "I'm not sure I understand. Can you try rephrasing or type 'menu' to see what I can help with?";
        }

        private string HandleTaskCommand(string input)
        {
            if (!taskManagerForm.Visible)
            {
                taskManagerForm.Show(mainForm);
                taskManagerForm.BringToFront();
            }
            else
            {
                taskManagerForm.BringToFront();
            }

            if (!input.StartsWith("add task") && !input.StartsWith("create task"))
            {
                try
                {
                    string title = input;
                    string description = "Cybersecurity task";
                    DateTime? dueDate = NlpHelper.ParseDate(input);

                    if (input.Contains("-"))
                    {
                        var parts = input.Split(new[] { '-' }, 2);
                        title = parts[0].Trim();
                        description = parts.Length > 1 ? parts[1].Trim() : description;
                    }

                    taskManagerForm.AddTask(new TaskItem(title, description, dueDate));
                    string response = $"Task added: '{title}' - {description}" + (dueDate.HasValue ? $" (Due: {dueDate.Value.ToShortDateString()})" : "");
                    LogActivity($"Task added: '{title}' (Description: {description}, Due: {dueDate?.ToShortDateString() ?? "None"})");
                    return response;
                }
                catch
                {
                    return "I couldn't understand the task format. Please try: 'Add task - Title - Description'";
                }
            }
            else
            {
                try
                {
                    string taskInfo = input.Replace("add task", "").Replace("create task", "").Trim();
                    string title = taskInfo;
                    string description = "Cybersecurity task";
                    if (taskInfo.Contains("-"))
                    {
                        var parts = taskInfo.Split(new[] { '-' }, 2);
                        title = parts[0].Trim();
                        description = parts.Length > 1 ? parts[1].Trim() : description;
                    }
                    taskManagerForm.AddTask(new TaskItem(title, description));
                    string response = $"Task added: '{title}' - {description}";
                    LogActivity($"Task added: '{title}' (Description: {description})");
                    return response;
                }
                catch
                {
                    return "I couldn't understand the task format. Please try: 'Add task - Title - Description'";
                }
            }
        }

        private string HandleReminderCommand(string input)
        {
            if (!taskManagerForm.Visible)
            {
                taskManagerForm.Show(mainForm);
                taskManagerForm.BringToFront();
            }
            else
            {
                taskManagerForm.BringToFront();
            }

            if (taskManagerForm.TaskCount == 0)
                return "You don't have any tasks to set reminders for. Add a task first.";

            try
            {
                int taskNumber = taskManagerForm.TaskCount - 1;
                var numberMatch = Regex.Match(input, @"\d+");
                if (numberMatch.Success)
                {
                    taskNumber = int.Parse(numberMatch.Value) - 1;
                }
                // Only show ReminderForm if not already visible
                if (!reminderForm.Visible)
                {
                    reminderForm.StartPosition = FormStartPosition.CenterParent;
                    DialogResult result = reminderForm.ShowDialog(mainForm); // Safe call
                    if (result == DialogResult.OK)
                    {
                        taskManagerForm.SetTaskReminder(taskNumber, reminderForm.SelectedDate);
                        string response = $"Reminder set for task '{taskManagerForm.GetTaskTitle(taskNumber)}' for {reminderForm.SelectedDate.ToShortDateString()}.";
                        LogActivity($"Reminder set for task '{taskManagerForm.GetTaskTitle(taskNumber)}' on {reminderForm.SelectedDate.ToShortDateString()}");
                        return response;
                    }
                    return "Reminder not set.";
                }
                else
                {
                    return "Reminder form is already open. Please close it before setting another.";
                }
            }
            catch (Exception ex)
            {
                LogActivity($"Error handling reminder: {ex.Message}");
                return "An error occurred while setting the reminder. Please try again.";
            }
        }

        private string HandleCompleteTask(string input)
        {
            if (taskManagerForm.TaskCount == 0)
            {
                return "You don't have any tasks to complete.";
            }
            try
            {
                int taskNumber = taskManagerForm.TaskCount - 1;
                var numberMatch = Regex.Match(input, @"\d+");
                if (numberMatch.Success)
                {
                    taskNumber = int.Parse(numberMatch.Value) - 1;
                }
                if (taskManagerForm.CompleteTask(taskNumber))
                {
                    string completedTaskTitle = taskManagerForm.GetTaskTitle(taskNumber);
                    LogActivity($"Task completed: '{completedTaskTitle}'");
                    return $"Marked task '{completedTaskTitle}' as completed. Great job, {userName}!";
                }
                return "Invalid task number. Please try again.";
            }
            catch
            {
                return "I couldn't understand which task to complete. Please try: 'Complete task [task number]'";
            }
        }

        private string ShowTaskList()
        {
            if (!taskManagerForm.Visible)
            {
                taskManagerForm.Show(mainForm);
                taskManagerForm.BringToFront();
            }
            else
            {
                taskManagerForm.BringToFront();
            }
            if (taskManagerForm.TaskCount == 0)
            {
                return "You don't have any tasks yet. Add one with 'Add task - [title] - [description]'";
            }
            var sb = new StringBuilder();
            sb.AppendLine("Your current tasks:");
            for (int i = 0; i < taskManagerForm.TaskCount; i++)
            {
                sb.AppendLine($"{i + 1}. {taskManagerForm.GetTaskDetails(i)}");
            }
            sb.AppendLine();
            sb.AppendLine("You can complete a task by saying 'complete task [number]' or set a reminder with 'set reminder for [number]'");
            LogActivity("Displayed task list.");
            return sb.ToString();
        }

        public void LogActivity(string activity)
        {
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            activityLog.Insert(0, $"[{timestamp}] {activity}");
            while (activityLog.Count > MaxLogEntries)
            {
                activityLog.RemoveAt(activityLog.Count - 1);
            }
        }

        public string ShowActivityLog()
        {
            if (activityLog.Count == 0)
            {
                return "No activities have been logged yet.";
            }
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Here's a summary of recent actions:");
            for (int i = 0; i < activityLog.Count; i++)
            {
                sb.AppendLine($"{i + 1}. {activityLog[i]}");
            }
            return sb.ToString();
        }

        private string StartQuiz()
        {
            quizForm.StartNewQuiz();

            if (!quizForm.Visible)
            {
                quizForm.Show(mainForm);
                quizForm.BringToFront();
                LogActivity("User started the Cybersecurity Quiz.");
                return "Starting the Cybersecurity Quiz! A new window should appear. Good luck!";
            }
            else
            {
                quizForm.BringToFront();
                return "Quiz is already open! Please close it before starting a new quiz.";
            }
        }

        private string GetSentimentMessage(string input)
        {
            if (input.Contains("worried") || input.Contains("concerned") || input.Contains("anxious"))
                return "It's completely understandable to feel that way about cybersecurity. Let me help address your concerns. What specifically are you worried about?";
            if (input.Contains("curious") || input.Contains("interested") || input.Contains("wondering"))
                return "Curiosity is a great mindset when it comes to cybersecurity. What would you like to know more about?";
            if (input.Contains("frustrated") || input.Contains("angry") || input.Contains("annoyed"))
                return "I understand your frustration. Cybersecurity can be confusing, but I'm here to help. What's bothering you?";
            if (input.Contains("happy") || input.Contains("excited") || input.Contains("good"))
                return "Great to hear you're feeling positive! How can I help you with your cybersecurity today?";
            return null;
        }

        private string ProvideFollowUp(string topic)
        {
            followUpCount++;
            string followUpResponse = GetFollowUpResponse(topic, followUpCount);

            if (followUpCount < 3)
            {
                followUpResponse += "\n\nWould you like to continue with this topic? (Type 'continue' or ask something else)";
            }
            else
            {
                followUpResponse += "\n\nI've covered the main points. You can ask about another topic or type 'menu'.";
                currentTopic = null;
                followUpCount = 0;
            }
            LogActivity($"Provided follow-up on {topic} (depth {followUpCount}).");
            return followUpResponse;
        }

        private string ContinueTopic(string topic)
        {
            string continuationResponse = GetContinuationResponse(topic);
            continuationResponse += "\n\nWould you like more details? (Type 'explain more' or ask something else)";
            LogActivity($"Continued discussion on {topic}.");
            return continuationResponse;
        }

        private string GetFollowUpResponse(string topic, int depth)
        {
            switch (topic.ToLower())
            {
                case "wifi":
                    return depth == 1 ?
                        "More on WiFi Security:\n• Change default admin credentials immediately\n• WPA3 is the most secure encryption available today\n• Guest networks prevent visitors from accessing your main devices" :
                        "Advanced WiFi Tips:\n• Place router centrally for better coverage\n• Disable WPS (WiFi Protected Setup) as it's vulnerable\n• Regularly check for firmware updates from manufacturer";
                case "shopping":
                    return depth == 1 ?
                        "Online Shopping Details:\n• HTTPS ensures encryption during transmission\n• Credit cards offer better fraud protection than debit\n• Check seller ratings and read recent reviews" :
                        "E-commerce Security Deep Dive:\n• Virtual credit cards provide extra security\n• Enable purchase alerts from your bank\n• Be wary of 'limited time' offers creating urgency";
                case "malware":
                    return depth == 1 ?
                        "Malware Defense:\n• Use real-time antivirus\n• Avoid untrusted sources\n• Keep OS and apps updated" :
                        "Deeper Malware Protection:\n• Beware of phishing links\n• Use sandbox environments for testing\n• Enable browser protection";
                case "two factor authentication":
                    return depth == 1 ?
                        "2FA Insights:\n• Use apps like Google Authenticator\n• Backup recovery codes\n• Enable on emails and banking accounts" :
                        "Advanced 2FA Tips:\n• Avoid SMS when possible\n• Use hardware tokens (e.g. YubiKey)\n• Monitor for unauthorized access";
                case "social engineering":
                    return depth == 1 ?
                        "Protecting Against Social Engineering:\n• Always verify sender identity\n• Be cautious with links and attachments\n• Watch for emotional manipulation" :
                        "Advanced Defense:\n• Use code words with family\n• Avoid oversharing on social media\n• Report suspicious interactions";
                case "device encryption":
                    return depth == 1 ?
                        "Encrypting Your Devices:\n• Use BitLocker (Windows) or FileVault (macOS)\n• Encrypt external drives too\n• Set strong boot passwords" :
                        "More on Encryption:\n• Turn on encryption for mobile devices\n• Avoid using weak passwords\n• Don't store keys unencrypted";
                case "mobile security":
                    return depth == 1 ?
                        "Mobile Safety:\n• Only install apps from trusted stores\n• Check app permissions\n• Use strong screen lock" :
                        "More Mobile Tips:\n• Enable remote wipe\n• Avoid rooting or jailbreaking\n• Keep your OS and apps up to date";
                case "cloud storage":
                    return depth == 1 ?
                        "Securing Cloud Storage:\n• Use strong, unique passwords\n• Enable 2FA\n• Be selective with what you upload" :
                        "Extra Cloud Security:\n• Encrypt files before uploading\n• Audit third-party access\n• Regularly review file-sharing links";
                case "social media":
                    return depth == 1 ?
                        "Social Media Privacy:\n• Limit who sees your posts\n• Don't share personal info\n• Review privacy settings regularly" :
                        "Extra Social Media Tips:\n• Disable location sharing\n• Remove unused third-party app connections\n• Beware of impersonators";
                case "public wifi":
                    return depth == 1 ?
                        "Public WiFi Risks:\n• Avoid entering credentials\n• Use VPNs for encryption\n• Turn off file sharing" :
                        "More WiFi Protection:\n• Don't auto-connect to networks\n• Use HTTPS everywhere extensions\n• Disable Bluetooth and AirDrop\n• Reconnect only when necessary";
                default:
                    return "Let me explain more about " + topic + "...";
            }
        }

        private string GetContinuationResponse(string topic)
        {
            switch (topic.ToLower())
            {
                case "wifi": return "Continuing WiFi Security:\n• MAC filtering adds security\n• Reduce transmission power to limit signal range\n• Schedule WiFi to turn off during unused hours";
                case "shopping": return "More Shopping Safety Tips:\n• Use browser extensions like HTTPS Everywhere\n• Check return policies before purchasing\n• Consider using a separate email for shopping";
                case "malware": return "More on Malware:\n• Schedule regular scans\n• Block autorun features\n• Use firewalls for additional protection";
                case "two factor authentication": return "Continuing 2FA Info:\n• Enable for all social media accounts\n• Periodically update backup methods\n• Don't share authentication codes";
                case "social engineering": return "Further Social Engineering Tips:\n• Trust your instincts\n• Never feel rushed\n• Use caller ID verification tools";
                case "device encryption": return "Encryption Continued:\n• Use full-disk encryption\n• Disable booting from external media\n• Ensure BIOS/UEFI password is set";
                case "mobile security": return "Continuing Mobile Security:\n• Avoid suspicious SMS and links\n• Don't install APKs from unknown sources\n• Enable SIM PIN";
                case "cloud storage": return "More Cloud Security:\n• Use enterprise-level services for business data\n• Log out of accounts on shared devices\n• Store sensitive data locally";
                case "social media": return "Further Social Media Privacy:\n• Monitor friend/follower lists\n• Avoid quizzes that harvest data\n• Report fake accounts";
                case "public wifi": return "More Public WiFi Tips:\n• Use HTTPS everywhere extensions\n• Disable Bluetooth and AirDrop\n• Reconnect only when necessary";
                default: return "Here's more information about " + topic + "...";
            }
        }

        private bool IsCybersecurityTopic(string topic)
        {
            return !(topic.Equals("how are you") ||
                   topic.Equals("what's your purpose") ||
                   topic.Equals("menu") ||
                   topic.Equals("what can I ask") ||
                   topic.Equals("add task") ||
                   topic.Equals("tasks") ||
                   topic.Equals("reminder") ||
                   topic.Equals("activity log") ||
                   topic.Equals("complete task") ||
                   topic.Equals("quiz") ||
                   topic.Equals("start quiz"));
        }
    }
}
# Ushay Cyber Secure - Cybersecurity Awareness Chatbot

Ushay Cyber Secure is a Windows Forms application designed to help users learn about cybersecurity topics while managing tasks, setting reminders, and taking interactive quizzes. Built with C# and .NET Framework, it combines educational content with productivity tools in an engaging interface.

## Project Structure

### Main Entry Point
- Program.cs
  - Launches the application by opening the MainForm.

### Main Form
- MainForm.cs + MainForm.Designer.cs
  - Hosts the chatbot UI using a RichTextBox, TextBox, and buttons.
  - Handles user input and routes it to the bot.
  - Integrates buttons to open the Task Manager.

### Chatbot Logic
- CyberSecurityBot.cs
  - Core logic for processing user input.
  - Handles intent recognition, topic matching, sentiment responses, and conversation flow.
  - Routes commands to task manager, reminder, and quiz modules.

- BotData.cs
  - Contains pre-defined responses for cybersecurity topics.
  - Handles command lookups and menu content.

- NlpHelper.cs
  - Provides basic NLP parsing to detect user intent and entities (e.g., tasks, reminders).
  - Supports natural phrasing like "remind me to..." or "add task...".

### Quiz System
- QuizForm.cs + QuizForm.Designer.cs
  - Displays the cybersecurity quiz in a separate form.
  - Handles question navigation, feedback, scoring, and explanations.

- QuizData.cs
  - Provides a list of predefined multiple-choice questions and answers.
  - Includes correct answer indices and explanations.

- QuizQuestion.cs
  - Represents a single quiz question.
  - Includes the question, answer options, correct answer index, and an explanation.

### Task Management System
- TaskManagerForm.cs + TaskManagerForm.Designer.cs
  - Form to manage a list of tasks.
  - Allows adding, deleting, marking as complete, and setting due dates.

- TaskItem.cs
  - Model class for each task.
  - Contains title, description, due date, and completion status.

### Reminder System
- ReminderForm.cs + ReminderForm.Designer.cs
  - Form to let users set a reminder date and a reminder message.
  - Communicates selected dates back to the main chatbot logic.

### UI Helpers
- DisplayHelper.cs
  - Handles colored text output to RichTextBox.
  - Displays an ASCII-style cybersecurity logo and welcome message.

- AudioHelper.cs
  - Plays an audio welcome message from a .wav file on app startup.

### Optional Enhancements
- NameInputForm.cs
  - Asks the user for their name before starting.
  - Stores and uses the name for personalized chatbot replies.

## Features
- Ask cybersecurity questions and receive topic explanations.
- Manage personal cybersecurity tasks with due dates.
- Set reminders for specific tasks.
- Take an interactive cybersecurity quiz.
- Personalized interaction with sentiment-aware responses.

## Technologies
- Language: C#
- Framework: .NET Framework
- UI: Windows Forms (WinForms)


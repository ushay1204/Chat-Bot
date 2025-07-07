using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ProgPoeFinal
{
    // Form to handle the interactive cybersecurity quiz
    public partial class QuizForm : Form
    {
        private List<QuizQuestion> questions;       // List of quiz questions
        private int currentQuestionIndex;           // Tracks current question number
        private int score;                          // Tracks user's quiz score
        private CyberSecurityBot bot;               // Reference to the main bot (for logging)

        public QuizForm()
        {
            InitializeComponent();
            questions = QuizData.GetQuestions();     // Load questions from QuizData source
            this.StartPosition = FormStartPosition.CenterParent; // Center the form on open
            InitializeQuizControls();               // Set up button click handlers
        }

        // Allows the main bot to be linked to this form for activity logging
        public void SetBotReference(CyberSecurityBot botInstance)
        {
            this.bot = botInstance;
        }

        // Starts a new quiz session (or restarts it)
        public void StartNewQuiz()
        {
            currentQuestionIndex = 0;
            score = 0;
            ShuffleQuestions();                    // Randomize question order
            DisplayQuestion();                     // Show first question
            UpdateProgress();                      // Update label showing progress

            lblFeedback.Text = "";                 // Clear previous feedback
            btnSubmit.Enabled = true;
            btnNext.Enabled = false;
            btnRestart.Visible = false;            // Hide restart button initially
            Show();                                // Display the form
            BringToFront();                        // Ensure it's on top
        }

        // Randomly shuffles the order of the quiz questions
        private void ShuffleQuestions()
        {
            Random rng = new Random();
            int n = questions.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                QuizQuestion value = questions[k];
                questions[k] = questions[n];
                questions[n] = value;
            }
        }

        // Displays the current question and its answer options
        private void DisplayQuestion()
        {
            if (currentQuestionIndex < questions.Count)
            {
                QuizQuestion currentQuestion = questions[currentQuestionIndex];
                lblQuestion.Text = currentQuestion.Question;
                flpOptions.Controls.Clear();       // Remove old answer options

                // Add radio buttons for each answer option
                for (int i = 0; i < currentQuestion.Options.Count; i++)
                {
                    RadioButton rb = new RadioButton
                    {
                        Text = currentQuestion.Options[i],
                        Tag = i, // Store answer index
                        AutoSize = true,
                        ForeColor = Color.White,
                        Font = new Font("Microsoft Sans Serif", 9F)
                    };
                    flpOptions.Controls.Add(rb);
                }

                btnSubmit.Enabled = true;
                btnNext.Enabled = false;
                lblFeedback.Text = "";
                UpdateProgress();
            }
            else
            {
                EndQuiz(); // No more questions left
            }
        }

        // Connects button click events to their respective methods
        private void InitializeQuizControls()
        {
            btnSubmit.Click += btnSubmit_Click;
            btnNext.Click += btnNext_Click;
            btnRestart.Click += btnRestart_Click;
            btnClose.Click += btnClose_Click;
        }

        // Handles the logic when the user clicks "Submit"
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (currentQuestionIndex >= questions.Count) return;

            QuizQuestion currentQuestion = questions[currentQuestionIndex];
            int selectedAnswer = -1;

            // Get selected answer index from checked radio button
            foreach (Control control in flpOptions.Controls)
            {
                if (control is RadioButton rb && rb.Checked)
                {
                    selectedAnswer = (int)rb.Tag;
                    break;
                }
            }

            if (selectedAnswer == -1)
            {
                MessageBox.Show("Please select an answer.", "No Answer Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check if the selected answer is correct
            if (selectedAnswer == currentQuestion.CorrectAnswerIndex)
            {
                score++;
                lblFeedback.ForeColor = Color.Green;
                lblFeedback.Text = $"Correct! {currentQuestion.Explanation}";
            }
            else
            {
                lblFeedback.ForeColor = Color.Red;
                lblFeedback.Text = $"Incorrect. The correct answer was '{currentQuestion.Options[currentQuestion.CorrectAnswerIndex]}'. {currentQuestion.Explanation}";
            }

            btnSubmit.Enabled = false;
            btnNext.Enabled = true;

            // Disable all radio buttons after answering
            foreach (Control control in flpOptions.Controls)
            {
                if (control is RadioButton rb)
                {
                    rb.Enabled = false;
                }
            }
        }

        // Moves to the next question
        private void btnNext_Click(object sender, EventArgs e)
        {
            currentQuestionIndex++;
            DisplayQuestion();
        }

        // Restarts the quiz from the beginning
        private void btnRestart_Click(object sender, EventArgs e)
        {
            StartNewQuiz();
        }

        // Hides the quiz form instead of closing the whole app
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        // Updates the question progress label
        private void UpdateProgress()
        {
            lblProgress.Text = $"Question {currentQuestionIndex + 1} of {questions.Count}";
            if (currentQuestionIndex >= questions.Count)
            {
                lblProgress.Text = "Quiz Completed!";
            }
        }

        // Called when the quiz is finished; shows score and feedback
        private void EndQuiz()
        {
            lblQuestion.Text = "Quiz Completed!";
            flpOptions.Controls.Clear();
            lblFeedback.ForeColor = Color.Yellow;

            string finalFeedback;

            // Choose message based on performance
            if (score == questions.Count)
            {
                finalFeedback = $"Fantastic job, {score}/{questions.Count}! You're a cybersecurity pro!";
            }
            else if (score >= questions.Count / 2)
            {
                finalFeedback = $"Good effort, {score}/{questions.Count}! Keep learning to stay safe online.";
            }
            else
            {
                finalFeedback = $"You scored {score}/{questions.Count}. There's always room to improve your cybersecurity knowledge!";
            }

            lblFeedback.Text = finalFeedback;

            btnSubmit.Enabled = false;
            btnNext.Enabled = false;
            btnRestart.Visible = true;

            MessageBox.Show(finalFeedback, "Quiz Results", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Log the score using the chatbot if it's connected
            if (this.bot != null)
            {
                this.bot.LogActivity($"Quiz completed with score: {score}/{questions.Count}.");
            }
        }
    }
}

using System.Collections.Generic;

public class QuizQuestion
{
    public string Question { get; set; }
    public List<string> Options { get; set; }
    public int CorrectAnswerIndex { get; set; }
    public string Explanation { get; set; }

    public QuizQuestion(string question, List<string> options, int correctIndex, string explanation)
    {
        Question = question;
        Options = options;
        CorrectAnswerIndex = correctIndex;
        Explanation = explanation;
    }
}
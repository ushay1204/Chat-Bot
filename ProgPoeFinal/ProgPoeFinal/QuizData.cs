using System.Collections.Generic;

public static class QuizData
{
    public static List<QuizQuestion> GetQuestions()
    {
        return new List<QuizQuestion>
        {
            new QuizQuestion(
                "What should you do if you receive an email asking for your password?",
                new List<string> {
                    "Reply with your password",
                    "Delete the email",
                    "Report the email as phishing",
                    "Ignore it"
                },
                2,
                "Reporting phishing emails helps prevent scams and protects others."
            ),
            new QuizQuestion(
                "Which of these is the strongest password?",
                new List<string> {
                    "password123",
                    "P@ssw0rd!",
                    "CorrectHorseBatteryStaple",
                    "12345678"
                },
                2,
                "Long passphrases with multiple words are stronger than complex but short passwords."
            ),
            new QuizQuestion(
                "True or False: You should use the same password for multiple important accounts.",
                new List<string> { "True", "False" },
                1,
                "Using unique passwords for each account prevents a breach on one site from compromising others."
            ),
            new QuizQuestion(
                "What does HTTPS indicate about a website?",
                new List<string> {
                    "It's always safe to enter personal information",
                    "The connection is encrypted",
                    "The site is government-approved",
                    "The site has no malware"
                },
                1,
                "HTTPS encrypts data in transit but doesn't guarantee the site's overall safety."
            ),
            new QuizQuestion(
                "What's the best way to handle a suspicious link in an email?",
                new List<string> {
                    "Click it to see where it goes",
                    "Forward it to friends to warn them",
                    "Hover over it to see the URL first",
                    "Report it and don't click"
                },
                3,
                "Never click suspicious links - report them to your IT department or email provider."
            ),
            new QuizQuestion(
                "How often should you update your software and apps?",
                new List<string> {
                    "Only when new features are added",
                    "When the app stops working",
                    "As soon as updates are available",
                    "Once a year"
                },
                2,
                "Security updates patch vulnerabilities - install them promptly."
            ),
            new QuizQuestion(
                "What's two-factor authentication (2FA)?",
                new List<string> {
                    "Using two passwords",
                    "Verifying identity with two methods",
                    "Logging in from two devices",
                    "Having two security questions"
                },
                1,
                "2FA combines something you know (password) with something you have (phone/device)."
            ),
            new QuizQuestion(
                "True or False: Public WiFi networks are safe for online banking.",
                new List<string> { "True", "False" },
                1,
                "Public WiFi can be monitored - use mobile data or VPN for sensitive activities."
            ),
            new QuizQuestion(
                "What should you do before downloading an attachment?",
                new List<string> {
                    "Scan it with antivirus software",
                    "Check the sender's email address",
                    "Verify the sender intended to send it",
                    "All of the above"
                },
                3,
                "All these steps help prevent malware infections from email attachments."
            ),
            new QuizQuestion(
                "What information should you avoid sharing on social media?",
                new List<string> {
                    "Your pet's name",
                    "Your mother's maiden name",
                    "Your birth date",
                    "All of the above"
                },
                3,
                "These are common security question answers that could compromise your accounts."
            )
        };
    }
}
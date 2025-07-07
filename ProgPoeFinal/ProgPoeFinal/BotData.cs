using System.Collections.Generic;
using System;

namespace ProgPoeFinal
{
    public static class BotData
    {
        // Returns a dictionary of bot responses mapped to user inputs
        public static Dictionary<string, string> GetResponses()
        {
            return new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                // Basic bot information responses
                {"how are you", "I'm functioning at optimal security levels! Ready to discuss cybersecurity."},
                {"what's your purpose", "I'm Ushay Cyber Secure, designed to educate about:\n- WiFi security\n- Safe shopping\n- Malware prevention\n- Two-Factor Authentication\n- Social Engineering\n- Device Encryption\n- Mobile Security\n- Cloud Storage Safety\n- Social Media Privacy\n- Public Wi-Fi Safety"},
                {"what is your purpose", "I'm Ushay Cyber Secure, designed to educate about:\n- WiFi security\n- Safe shopping\n- Malware prevention\n- Two-Factor Authentication\n- Social Engineering\n- Device Encryption\n- Mobile Security\n- Cloud Storage Safety\n- Social Media Privacy\n- Public Wi-Fi Safety"},
                {"whats your purpose", "I'm Ushay Cyber Secure, designed to educate about:\n- WiFi security\n- Safe shopping\n- Malware prevention\n- Two-Factor Authentication\n- Social Engineering\n- Device Encryption\n- Mobile Security\n- Cloud Storage Safety\n- Social Media Privacy\n- Public Wi-Fi Safety"},
                
                // Navigation and help responses
                {"what can I ask", "You can ask me about:\n• Securing your home network\n• Safe online shopping\n• Avoiding viruses\n• Two-Factor Authentication\n• Social Engineering scams\n• Device Encryption\n• Mobile Security\n• Cloud Storage Safety\n• Social Media Privacy\n• Public Wi-Fi Safety\nOr type 'menu' for options"},
                {"what can you do", "I can explain:\n1. WiFi Security\n2. Online Shopping\n3. Malware\n4. Two-Factor Authentication\n5. Social Engineering\n6. Device Encryption\n7. Mobile Security\n8. Cloud Storage\n9. Social Media Privacy\n10. Public Wi-Fi\nJust ask about these topics!"},
                {"menu", "MAIN MENU:\n1. WiFi Security\n2. Online Shopping\n3. Malware\n4. Two-Factor Authentication\n5. Social Engineering\n6. Device Encryption\n7. Mobile Security\n8. Cloud Storage\n9. Social Media Privacy\n10. Public Wi-Fi\n\nTask Management:\n- Add task - [title] - [description]\n- Show tasks\n- Set reminder for [task number] [date] [time]\n- Delete task [task number]\n- Open task manager\n\nQuiz:\n- Start quiz\n\n11. Exit"},
                
                // Cybersecurity topic responses
                {"wifi", "WiFi Security Summary:\nSecure your network by changing default credentials, enabling WPA3 encryption, and using strong passwords. Regularly update firmware and monitor connected devices."},
                {"shopping", "Online Shopping Safety:\nAlways verify website security (HTTPS), use credit cards, and enable 2FA. Avoid public WiFi for transactions."},
                {"malware", "Malware Protection:\nUse updated antivirus software, avoid suspicious downloads, and maintain regular backups."},
                {"two factor authentication", "2FA Best Practices:\nEnable on all critical accounts, prefer authenticator apps over SMS, and store recovery codes securely."},
                {"social engineering", "Social Engineering Defense:\nVerify unexpected requests, never share sensitive info, and educate vulnerable contacts."},
                {"device encryption", "Device Encryption Guide:\nEncrypt all devices and external storage, using strong passwords."},
                {"mobile security", "Mobile Protection:\nDownload only from official stores, review app permissions, and enable device tracking."},
                {"cloud storage", "Cloud Security:\nUse strong unique passwords, enable 2FA, and encrypt sensitive files before upload."},
                {"social media", "Social Media Privacy:\nLimit post visibility, disable location tagging, and audit third-party apps."},
                {"public wifi", "Public WiFi Safety:\nAvoid sensitive activities, use VPNs, and disable auto-connect."},
                
                // Conversation flow responses
                {"explain more", "I'll provide more details about the current topic."},
                {"continue", "Continuing with more information about this topic..."},
                
                // Task management responses
                {"add task", "You can add tasks in several ways:\n• Formal command: 'Add task - [title] - [description]'\n• Natural language: 'Remind me to update my passwords'\n• 'I need to review privacy settings'\n• 'Create task: enable 2FA'\nIf you don't provide a description, I'll use a default one."},
                {"tasks", "Task Management Options:\n• View tasks: 'Show tasks' or 'What are my current tasks?'\n• Add task: 'Add task to [description]' or 'I need to [action]'\n• Set reminder: 'Remind me about [task] [time]' or 'Set reminder for task 1 tomorrow'\n• Delete task: 'Delete task 2' or 'Remove the third task'\n• Full manager: 'Open task manager' for advanced options"},
                {"reminder", "Set reminders using various formats:\n• Exact: 'Set reminder for 1 2024-12-31 10:00'\n• Relative: 'Remind me about [task] [time]' or 'Set reminder for task 1 tomorrow'\n• Natural: 'I need a reminder to update software next week'\n• Implied: 'Task 2 needs to be done tomorrow'"},
                
                // Quiz responses
                {"quiz", "Test your cybersecurity knowledge with our interactive quiz!\nType 'start quiz' or 'begin test' to get started.\nYou'll answer 10 questions and receive a score at the end."},
                {"start quiz", "You can begin the quiz with phrases like:\n• 'Begin cybersecurity quiz'\n• 'I want to take the test'\n• 'Start the questions'\n• 'Let's test my knowledge'\n• 'Ready for the security quiz'\n\nThe quiz covers all major cybersecurity topics we've discussed."},
                
                // Activity log responses
                {"activity log", "View your recent activities with commands like:\n• 'Show activity log'\n• 'What have we done'\n• 'View my history'\n• 'Show recent actions'\n\nI'll display your last 10 interactions including tasks, reminders, and quiz attempts."}
            };
        }
    }
}
using ExaminationSystem.Models;
using System;

namespace ExaminationSystem.Models
{
    public class FinalExam : Exam
    {
        public FinalExam(string title, TimeSpan duration, Subject subject,string LogType) : base(title, duration, subject, LogType)
        {
        }

        public FinalExam(string title, TimeSpan duration, Subject subject,string LogType, QuestionList list) : base(title, duration, subject,LogType, list)
        {
        }

        public override void ShowExam()
        {
            Console.WriteLine(ToString());
            Console.WriteLine("=== Final Exam ===");
            int i = 1;
            foreach (var q in Questions)
            {
                Console.WriteLine($"\nQuestion {i++}:");
                q.Show();
                // No answers shown in final exam
                Console.WriteLine("Answer (input disabled in this demo) -> (press Enter to continue)");
                Console.ReadLine();
            }

            Console.WriteLine("\n-- End of Exam. Answers will not be shown in Final Exam --");
        }
    }
}

using ExaminationSystem.Models;
using System;
using System.Linq;

namespace ExaminationSystem.Models
{
    public class PracticeExam : Exam
    {
        public PracticeExam(string title, TimeSpan duration, Subject subject, string LogType) : base(title, duration, subject,LogType)
        {
        }

        public PracticeExam(string title, TimeSpan duration, Subject subject,string LogType, QuestionList list) : base(title, duration, subject,LogType, list)
        {
        }

        public override void ShowExam()
        {
            Console.WriteLine(ToString());
            Console.WriteLine("=== Practice Exam ===");
            int i = 1;
            foreach (var q in Questions)
            {
                Console.WriteLine($"\nQuestion {i++}:");
                q.Show();
                // For simulation: optionally accept an answer - here we just show answers
                Console.WriteLine("Your answer (simulated) -> (press Enter to continue)");
                Console.ReadLine();
            }

            Console.WriteLine("\n-- Correct Answers --");
            foreach (var kv in QuestionsAnswers)
            {
                Console.WriteLine($"\n{kv.Key.Header}:");
                foreach (var a in kv.Value)
                    Console.WriteLine($"- {a.Text}");
            }
        }
    }
}

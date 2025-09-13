using System;

namespace ExaminationSystem.Models
{
    public class Student
    {
        public string Name { get; set; }

        public Student(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        // Event handler for Exam started
        public void OnExamStarted(object sender, ExamEventArgs e)
        {
            Console.WriteLine($"[Notification] Student '{Name}' notified: Exam '{e.Exam.Title}' for subject '{e.Exam.Subject?.Name}' has started at {e.Timestamp:O}");
        }

        public override string ToString() => $"Student: {Name}";
    }
}

using System;
using System.Collections.Generic;
using ExaminationSystem.Models;

namespace ExaminationSystem
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Welcome to the Examination System\n");

            Console.WriteLine("Create an Exam\n");
            #region CreateExam
            Console.Write("Enter subject name: ");
            var subject = new Subject(Console.ReadLine() ?? "General");

            Console.WriteLine("Select Exam Type:\n1 - Practice Exam\n2 - Final Exam");
            var choice = Console.ReadLine();
            bool isPractice = choice == "1";

            Console.Write("Enter exam title: ");
            string title = Console.ReadLine() ?? "Untitled";

            Console.Write("Enter duration in minutes: ");
            var mins = int.TryParse(Console.ReadLine(), out int m) ? m : 30;
            Exam exam = isPractice
                ? new PracticeExam(title, TimeSpan.FromMinutes(mins), subject, "practice_questions")
                : new FinalExam(title, TimeSpan.FromMinutes(mins), subject,"final_questions");

            Console.WriteLine("\n--- Add Questions ---");
            while (true)
            {
                Console.WriteLine("Choose question type: 1-True/False  2-Choose One  3-Choose All  (or Enter to finish)");
                var type = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(type)) break;

                Console.Write("Enter question header: ");
                var header = Console.ReadLine() ?? "";

                Console.Write("Enter question body: ");
                var body = Console.ReadLine() ?? "";

                Console.Write("Enter question marks: ");
                double marks = double.TryParse(Console.ReadLine(), out double mk) ? mk : 1;

                var answers = new AnswerList();
                if (type == "1")
                {
                    answers.Add(new Answer("True", AskIsCorrect("True")));
                    answers.Add(new Answer("False", AskIsCorrect("False")));
                    TrueFalseQuestion question = new TrueFalseQuestion(header, body, marks, answers);
                    exam.AddQuestion(question);

                }
                else
                {
                    Console.Write("How many answers/options? ");
                    int count = int.TryParse(Console.ReadLine(), out int c) ? c : 2;
                    for (int i = 0; i < count; i++)
                    {
                        Console.Write($"Option {i + 1} text: ");
                        string txt = Console.ReadLine() ?? "";
                        bool correct = AskIsCorrect(txt);
                        answers.Add(new Answer(txt, correct));
                    }
                    Question q = type == "2"
                        ? new ChooseOneQuestion(header, body, marks, answers)
                        : new ChooseAllQuestion(header, body, marks, answers);
                    exam.AddQuestion(q);
                }
            }
            #endregion
            Console.Clear();
            Console.WriteLine("Exam Created Successfully!\n");
            Console.Write("Take Exam as a student? (y/n): ");
            var take = Console.ReadLine().ToLower();
            if (take == "y")
            { 
                Console.Write("Enter your name: ");
                var studentName = Console.ReadLine()??"Student1";
                var student = new Student(studentName);
                exam.ExamStarted += student.OnExamStarted;
                #region StartExam
                exam.Mode = ExamMode.Starting;
                Console.Clear();
                Console.WriteLine("\n--- Begin Exam ---");
                exam.TakeExam();
                #endregion
                Console.Write("\nProceed to score (Press Enter)...");
                Console.ReadLine();
                Console.Clear();
                #region ShowScoreAndFinish
                if (isPractice)
                {
                    Console.WriteLine("\nCorrect Answers:");
                    foreach (var kv in exam.QuestionsAnswers)
                    {
                        Console.WriteLine($"{kv.Key.Body}: {string.Join(", ", kv.Value)}");
                    }
                }
                exam.ShowScore();

                exam.Mode = ExamMode.Finished;
                Console.WriteLine("\nExam Finished.");
                #endregion
            }
            else if (take == "n")
            {
                Console.Write("You can take the exam later then (Press Enter to exit)...");
                Console.ReadLine();
                return;
            }


        }
        static bool AskIsCorrect(string option)
        {
            Console.Write($"Is \"{option}\" a correct answer? (y/n): ");
            return Console.ReadLine()?.Trim().ToLower().StartsWith("y") ?? false;
        }
    }
}

using ExaminationSystem.Models;
using System;

namespace ExaminationSystem.Models
{
    public class ChooseOneQuestion : Question
    {
        public ChooseOneQuestion(string header, string body, double marks) : base(header, body, marks)
        {
        }

        public ChooseOneQuestion(string header, string body, double marks, AnswerList answers) : base(header, body, marks, answers)
        {
        }

        public override void Show()
        {
            Console.WriteLine($"[Single Choice] {Header} ({Marks} pts)");
            Console.WriteLine(Body);
            for (int i = 0; i < Answers.Count; i++)
            {
                Console.WriteLine($"{(char)('A' + i)}. {Answers[i].Text}");
            }
        }

        public override object Clone()
        {
            return new ChooseOneQuestion(Header, Body, Marks, (AnswerList)Answers.Clone());
        }
    }
}

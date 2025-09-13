using ExaminationSystem.Models;
using System;

namespace ExaminationSystem.Models
{
    public class ChooseAllQuestion : Question
    {
        public ChooseAllQuestion(string header, string body, double marks) : base(header, body, marks)
        {
        }

        public ChooseAllQuestion(string header, string body, double marks, AnswerList answers) : base(header, body, marks, answers)
        {
        }

        public override void Show()
        {
            Console.WriteLine($"[Multiple Choice] {Header} ({Marks} pts) - (Choose all that apply)");
            Console.WriteLine(Body);
            for (int i = 0; i < Answers.Count; i++)
            {
                Console.WriteLine($"{(char)('A' + i)}. {Answers[i].Text}");
            }
        }

        public override object Clone()
        {
            return new ChooseAllQuestion(Header, Body, Marks, (AnswerList)Answers.Clone());
        }
    }
}

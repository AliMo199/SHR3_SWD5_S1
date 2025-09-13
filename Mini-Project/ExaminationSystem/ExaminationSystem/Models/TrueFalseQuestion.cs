using ExaminationSystem.Models;
using System;

namespace ExaminationSystem.Models
{
    public class TrueFalseQuestion : Question
    {
        public TrueFalseQuestion(string header, string body, double marks) : base(header, body, marks)
        {
            // default answers may be added externally, but if none provided, add default TF
            if (Answers.Count == 0)
            {
                Answers.Add(new Answer("True", false));
                Answers.Add(new Answer("False", false));
            }
        }

        public TrueFalseQuestion(string header, string body, double marks, AnswerList answers) : base(header, body, marks, answers)
        {
        }

        public override void Show()
        {
            Console.WriteLine($"[T/F] {Header} ({Marks} pts)");
            Console.WriteLine(Body);
            for (int i = 0; i < Answers.Count; i++)
            {
                Console.WriteLine($"{(char)('A' + i)}. {Answers[i].Text}");
            }
        }

        public override object Clone()
        {
            return new TrueFalseQuestion(Header, Body, Marks, (AnswerList)Answers.Clone());
        }
    }
}

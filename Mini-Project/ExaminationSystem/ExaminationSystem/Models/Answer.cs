using System;

namespace ExaminationSystem.Models
{
    public class Answer : ICloneable
    {
        public string Text { get; set; }
        public bool IsCorrect { get; set; }

        public Answer(string text, bool isCorrect)
        {
            Text = text ?? throw new ArgumentNullException(nameof(text));
            IsCorrect = isCorrect;
        }

        public override string ToString()
        {
            return $"{Text} {(IsCorrect ? "(Correct)" : "")}";
        }

        public object Clone()
        {
            return new Answer(Text, IsCorrect);
        }

        public override bool Equals(object obj)
        {
            if (obj is not Answer a) return false;
            return Text == a.Text && IsCorrect == a.IsCorrect;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Text, IsCorrect);
        }
    }
}

using ExaminationSystem.Models;
using System;
using System.Collections.Generic;

namespace ExaminationSystem.Models
{
    public abstract class Question : ICloneable, IComparable<Question>
    {
        public string Header { get; set; }
        public string Body { get; set; }
        public double Marks { get; set; }
        public AnswerList Answers { get; set; }

        // Constructor chaining
        protected Question(string header) : this(header, string.Empty, 0, new AnswerList()) { }

        protected Question(string header, string body, double marks) : this(header, body, marks, new AnswerList()) { }

        protected Question(string header, string body, double marks, AnswerList answers)
        {
            Header = header ?? throw new ArgumentNullException(nameof(header));
            Body = body ?? string.Empty;
            Marks = marks;
            Answers = answers ?? new AnswerList();
        }

        public abstract void Show();

        public virtual object Clone()
        {
            // Deep clone
            var clonedAnswers = new AnswerList();
            foreach (var a in Answers)
            {
                clonedAnswers.Add((Answer)a.Clone());
            }

            var clone = (Question)MemberwiseClone();
            clone.Answers = clonedAnswers;
            return clone;
        }

        public virtual int CompareTo(Question other)
        {
            if (other == null) return 1;
            // Default comparison by Marks descending, then Header
            int m = -Marks.CompareTo(other.Marks); // higher marks first
            return m != 0 ? m : string.Compare(Header, other.Header, StringComparison.Ordinal);
        }

        public override string ToString()
        {
            return $"{Header} | Marks: {Marks} | {Body}\nAnswers:\n{Answers}";
        }

        public override bool Equals(object obj)
        {
            if (obj is not Question q) return false;
            return Header == q.Header && Body == q.Body && Marks.Equals(q.Marks);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Header, Body, Marks);
        }
    }
}

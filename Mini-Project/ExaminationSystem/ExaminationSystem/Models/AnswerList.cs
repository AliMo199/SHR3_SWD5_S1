using System;
using System.Collections.Generic;
using System.Text;

namespace ExaminationSystem.Models
{
    public class AnswerList : List<Answer>, ICloneable
    {
        public object Clone()
        {
            var copy = new AnswerList();
            foreach (var a in this)
                copy.Add((Answer)a.Clone());
            return copy;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < Count; i++)
            {
                sb.AppendLine($"{(char)('A' + i)}. {this[i].Text} {(this[i].IsCorrect ? "(Correct)" : "")}");
            }
            return sb.ToString();
        }
    }
}

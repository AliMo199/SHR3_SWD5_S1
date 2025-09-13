using ExaminationSystem.Models;
using System;
using System.Collections.Generic;

namespace ExaminationSystem.Models
{
    public enum ExamMode { Starting, Queued, Finished }

    public class ExamEventArgs : EventArgs
    {
        public Exam Exam { get; }
        public DateTime Timestamp { get; }

        public ExamEventArgs(Exam exam)
        {
            Exam = exam;
            Timestamp = DateTime.UtcNow;
        }
    }

    public abstract class Exam : ICloneable, IComparable<Exam>
    {
        public string Title { get; }
        public TimeSpan Duration { get; }
        public Subject Subject { get; }
        public string LogType { get; }
        public ExamMode Mode
        {
            get => _mode;
            set
            {
                _mode = value;
                if (_mode == ExamMode.Starting)
                {
                    OnExamStarted();
                }
            }
        }
        private ExamMode _mode;

        // Map each Question to the (correct) answer list - used for correction
        public Dictionary<Question, AnswerList> QuestionsAnswers { get; } = new();
        public Dictionary<Question, List<int>> UserAnswers { get; } = new();

        // Underlying question list (composition)
        public QuestionList Questions { get; }
        public object Log { get; }

        // Event to notify students when the exam starts
        public event EventHandler<ExamEventArgs> ExamStarted;

        // Constructors (chaining)
        protected Exam(string title, TimeSpan duration, Subject subject,string LogType) : this(title, duration, subject,LogType, new QuestionList($"{LogType.Replace(' ', '_')}.log")) { }

        protected Exam(string title, TimeSpan duration, Subject subject,string LogType, QuestionList questionList)
        {
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Duration = duration;
            Subject = subject ?? throw new ArgumentNullException(nameof(subject));
            Questions = questionList ?? new QuestionList($"{LogType.Replace(' ', '_')}.log");
            Mode = ExamMode.Queued;
        }

        public void TakeExam()
        {
            int qNum = 1;
            foreach (var q in Questions)
            {
                Console.WriteLine($"\nQuestion {qNum++}:");
                q.Show();

                Console.Write("Enter your answer(s) as letters (e.g. A or A,C): ");
                var input = Console.ReadLine()?.Trim().ToUpper();
                var selected = new List<int>();
                if (!string.IsNullOrEmpty(input))
                {
                    var parts = input.Split(',', StringSplitOptions.RemoveEmptyEntries);
                    foreach (var p in parts)
                    {
                        char c = p.Trim()[0];
                        int idx = c - 'A';
                        if (idx >= 0 && idx < q.Answers.Count)
                            selected.Add(idx);
                    }
                }
                UserAnswers[q] = selected;
            }
        }

        public void ShowScore()
        {
            double totalMarks = 0;
            double gained = 0;
            foreach (var kv in QuestionsAnswers)
            {
                totalMarks += kv.Key.Marks;

                var correctIndices = new HashSet<int>();
                for (int i = 0; i < kv.Key.Answers.Count; i++)
                    if (kv.Key.Answers[i].IsCorrect)
                        correctIndices.Add(i);

                var user = UserAnswers.ContainsKey(kv.Key) ? new HashSet<int>(UserAnswers[kv.Key]) : new HashSet<int>();

                if (correctIndices.SetEquals(user))
                    gained += kv.Key.Marks;
            }

            Console.WriteLine($"\nYour score: {gained} / {totalMarks}");
        }

        protected virtual void OnExamStarted()
        {
            ExamStarted?.Invoke(this, new ExamEventArgs(this));
        }

        // Add question and store correct answers into QuestionsAnswers
        public virtual void AddQuestion(Question q)
        {
            Questions.Add(q);
            // Find correct answers and store them for correction
            var correct = new AnswerList();
            foreach (var a in q.Answers)
                if (a.IsCorrect) correct.Add((Answer)a.Clone());

            QuestionsAnswers[q] = correct;
        }

        // ShowExam implementation is dependent on derived classes
        public abstract void ShowExam();

        public virtual object Clone()
        {
            var clone = (Exam)MemberwiseClone();
            // deep copy the Questions and QuestionsAnswers
            var qListCopy = new QuestionList(Questions.LogFilePath);
            foreach (var q in Questions)
                qListCopy.Add((Question)q.Clone());

            clone.QuestionsAnswers.Clear();
            foreach (var kv in QuestionsAnswers)
            {
                clone.QuestionsAnswers[(Question)kv.Key.Clone()] = (AnswerList)kv.Value.Clone();
            }

            return clone;
        }

        public virtual int CompareTo(Exam other)
        {
            if (other == null) return 1;
            // Compare by duration then title
            int cmp = Duration.CompareTo(other.Duration);
            return cmp != 0 ? cmp : string.Compare(Title, other.Title, StringComparison.Ordinal);
        }

        public override string ToString()
        {
            return $"{Title} | Subject: {Subject?.Name} | Duration: {Duration} | Mode: {Mode} | Questions: {Questions.Count}";
        }

        public override bool Equals(object obj)
        {
            if (obj is not Exam e) return false;
            return Title == e.Title && Subject?.Name == e.Subject?.Name && Duration.Equals(e.Duration);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Title, Subject?.Name, Duration);
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ExaminationSystem.Models
{
    // Inherit List<Question>. Add logging to a file when adding items.
    public class QuestionList : List<Question>
    {
        public string LogFilePath { get; }

        public QuestionList(string logFilePath)
        {
            LogFilePath = logFilePath ?? throw new ArgumentNullException(nameof(logFilePath));
        }

        // List<T>.Add is not virtual; hide it with 'new'.
        public new void Add(Question q)
        {
            base.Add(q); // keep default behavior
            try
            {
                LogQuestion(q);
            }
            catch (Exception ex)
            {
                // logging should not break app; here we write to console (or could throw / handle)
                Console.WriteLine($"Failed to log question: {ex.Message}");
            }
        }

        private void LogQuestion(Question q)
        {
            // Append to the file. Use TextWriter/StreamWriter
            using var writer = new StreamWriter(LogFilePath, append: true, encoding: Encoding.UTF8);
            writer.WriteLine("----- Question Log Entry -----");
            writer.WriteLine($"Timestamp: {DateTime.UtcNow:O}");
            writer.WriteLine(q.ToString());
            writer.WriteLine();
        }

        // Optional: load questions from file (rudimentary)
        public static QuestionList FromFile(string logFilePath)
        {
            // This method is a placeholder to show how you'd use TextReader.
            // Because logs are human readable but not structured, reading back to reconstruct objects
            // would require a structured format (JSON/XML). For this demo we return an empty list.
            return new QuestionList(logFilePath);
        }
    }
}

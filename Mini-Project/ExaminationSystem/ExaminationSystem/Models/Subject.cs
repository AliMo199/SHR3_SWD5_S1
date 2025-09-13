using ExaminationSystem.Models;
using System;
using System.Collections.Generic;

namespace ExaminationSystem.Models
{
    public class Subject
    {
        public string Name { get; set; }
        public List<Student> EnrolledStudents { get; } = new();

        public Subject(string name)
        {
            Name = name;
        }

        public void Enroll(Student s)
        {
            if (s == null) throw new ArgumentNullException(nameof(s));
            EnrolledStudents.Add(s);
        }

        public override string ToString() => $"Subject: {Name} (Students: {EnrolledStudents.Count})";
    }
}

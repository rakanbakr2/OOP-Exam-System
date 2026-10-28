using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Exam
{
    internal class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public Exam Exam { get; set; }

        public Subject(int subjectId, string subjectName)
        {
            if (string.IsNullOrWhiteSpace(subjectName))
                throw new ArgumentException("Subject name cannot be empty.");

            SubjectId = subjectId;
            SubjectName = subjectName;
        }

        public void CreateExam(ExamType examType, int duration, int numberOfQuestions, List<Question> questions)
        {
            switch (examType)
            {
                case ExamType.Final:
                    Exam = new FinalExam(duration, numberOfQuestions, questions, this);
                    break;
                case ExamType.Practical:
                    Exam = new PracticalExam(duration, numberOfQuestions, questions, this);
                    break;
                default:
                    throw new ArgumentException("Invalid exam type.");
            }
        }

        public override string ToString()
        {
            return $"Subject [{SubjectId}] {SubjectName}";
        }

    }
}

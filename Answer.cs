using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Exam
{
    internal class Answer
    {
        public int AnswerId { get; set; }
        public string AnswerText { get; set; }

        public Answer(int answerId, string answerText)
        {
            if (string.IsNullOrWhiteSpace(answerText))
                throw new ArgumentException("Answer text cannot be empty.");

            if (answerId <= 0)
                throw new ArgumentException("Answer ID must be a positive number.");

            AnswerId = answerId;
            AnswerText = answerText;
        }

        public override string ToString()
        {
            return $"{AnswerId}: {AnswerText}";
        }


    }
}

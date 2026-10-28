using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Exam
{
    internal class MCQQuestion : Question
    {
        public MCQQuestion(string header, string body, int mark, List<Answer> answerList, Answer rightAnswer)
            : base(header, body, mark, answerList, rightAnswer)
        {
            if (!ValidateAnswers())
                throw new ArgumentException("MCQ questions must have at least 3 choices.");
        }

        public override string QuestionType => "MCQ Question";

        public override bool ValidateAnswers()
        {
            return AnswerList.Count >= 3;
        }
    }
}

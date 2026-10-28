using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Exam
{
    internal class TrueOrFalseQuestion : Question
    {
        public TrueOrFalseQuestion(string header, string body, int mark, List<Answer> answerList, Answer rightAnswer)
            : base(header, body, mark, answerList, rightAnswer)
        {
            if (!ValidateAnswers())
                throw new ArgumentException("True/False questions must have exactly two answers: 'True' and 'False'.");
        }

        public override string QuestionType => "True Or False Question";

        public override bool ValidateAnswers()
        {
            return AnswerList.Count == 2 && AnswerList.Exists(a => a.AnswerText.ToLower() == "true")&& AnswerList.Exists(a => a.AnswerText.ToLower() == "false");
        }
    }
}

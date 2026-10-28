using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Exam
{
    internal class PracticalExam : Exam
    {
        public PracticalExam(int duration, int numberOfQuestions, List<Question> questions, Subject subject)
            : base(duration, numberOfQuestions, questions, subject)
        {
              //object-level validation to not vreate an abject of PracticalExam with True or False questions
              if (questions.Any(q => q is TrueOrFalseQuestion))
                throw new ArgumentException("Practical Exam can only contain MCQ questions.");
        }

        public override void ShowExam()
        {
            PrintResults("Practical Exam Results:");
        }
    }
}

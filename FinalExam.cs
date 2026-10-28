using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Exam
{
    internal class FinalExam : Exam
    {
        public FinalExam(int duration, int numberOfQuestions, List<Question> questions, Subject subject)
            : base(duration, numberOfQuestions, questions, subject)
        {

        }

        public override void ShowExam()
        {
            PrintResults("Final Exam Results:");
        }

    }
}

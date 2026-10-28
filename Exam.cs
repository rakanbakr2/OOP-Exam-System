using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace OOP_Exam
{
    internal abstract class Exam
    {
        public int Duration { get; set; }
        public int NumberOfQuestions { get; set; }
        public List<Question> Questions { get; set; }
        public Subject Subject { get; set; }

        protected Exam(int duration, int numberOfQuestions, List<Question> questions, Subject subject)
        {
            

            if (questions == null || questions.Count == 0)
                throw new ArgumentException("An exam must contain at least one question.");

            if (numberOfQuestions != questions.Count)
                throw new ArgumentException("Number of questions does not match the actual questions provided.");

            if (subject == null)
                throw new ArgumentException("Exam must be associated with a subject.");

            Duration = duration;
            NumberOfQuestions = numberOfQuestions;
            Questions = questions;
            Subject = subject;
        }


        public void RunExam()
        {
            Console.Clear();
            int qNum = 1;
            foreach (var question in Questions)
            {
                question.AskStudentAnswer(qNum);
                qNum++;
            }
        }


        public abstract void ShowExam();


        protected void PrintResults(string title)
        {
            Console.Clear();
            var stopwatch = Stopwatch.StartNew();

            Console.WriteLine(title);
            int totalMark = 0;
            int earnedMark = 0;
            int qNum = 1;

            foreach (var question in Questions)
            {
                Console.WriteLine($"Question {qNum}: {question.Body}");
                Console.WriteLine($"Your Answer --> {question.StudentAnswer?.AnswerText}");
                Console.WriteLine($"Correct Answer --> {question.RightAnswer.AnswerText}");
                Console.WriteLine();

                totalMark += question.Mark;
                if (question.StudentAnswer != null && question.StudentAnswer.AnswerId == question.RightAnswer.AnswerId)
                {
                    earnedMark += question.Mark;
                }
                qNum++;
            }

            stopwatch.Stop();

            Console.WriteLine($"Your Grade is {earnedMark} from {totalMark}");
            Console.WriteLine($"Time = {stopwatch.Elapsed}");
            Console.WriteLine("Thank you");
        }


    }
}

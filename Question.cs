using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Text;

namespace OOP_Exam
{
    internal abstract class Question : ICloneable, IComparable<Question>
    {
        public string Header { get; set; }
        public string Body { get; set; }
        public int Mark { get; set; }
        public List<Answer> AnswerList { get; set; }
        public Answer RightAnswer { get; set; }
        public Answer StudentAnswer { get; set; }

        protected Question(string header, string body, int mark, List<Answer> answerList, Answer rightAnswer)
        {
            if (string.IsNullOrWhiteSpace(header))
                throw new ArgumentException("Question header cannot be empty.");

            if (string.IsNullOrWhiteSpace(body))
                throw new ArgumentException("Question body cannot be empty.");

            if (mark <= 0)
                throw new ArgumentException("Mark must be a positive number.");

            if (answerList == null || answerList.Count == 0)
                throw new ArgumentException("A question must have at least one answer.");

            // Check for duplicate answers 
            var ExistedAnswers = new HashSet<string>();
            foreach (var answer in answerList)
            {
                string CurrentText = answer.AnswerText.Trim().ToLower();
                if (!ExistedAnswers.Add(CurrentText))
                {
                    throw new ArgumentException($"Duplicate answer choice found: '{answer.AnswerText}' , Choices must be unique.");
                }
            }


            if (rightAnswer == null)
                throw new ArgumentException("The right answer must be specified.");

            if (!answerList.Any(a => a.AnswerId == rightAnswer.AnswerId))
                throw new ArgumentException("The right answer must be one of the provided choices.");

            Header = header;
            Body = body;
            Mark = mark;
            AnswerList = answerList;
            RightAnswer = rightAnswer;
        }

        public abstract bool ValidateAnswers();

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public int CompareTo(Question other)
        {
            if (other == null) return 1;
            return this.Mark.CompareTo(other.Mark);
        }

        public override string ToString()
        {
            return $"[{GetType().Name}] {Header} - {Body} (Mark: {Mark})";
        }

        public Answer GetAnswerById(int id)
        {
            return AnswerList.Find(a => a.AnswerId == id);
        }

        public abstract string QuestionType { get; }
        public void AskStudentAnswer(int questionNumber)
        {
            Console.WriteLine($"Question {questionNumber}: {Body}");
            Console.WriteLine($"{QuestionType}:  Mark {Mark}");
            foreach (var answer in AnswerList)
            {
                Console.WriteLine($"{answer.AnswerId}- {answer.AnswerText}");
            }

            int chosenId;
            Answer selectedAnswer;
            //validation
            while (true)
            {
                Console.WriteLine("Enter your answer ID:");
                string input = Console.ReadLine();

                if (!int.TryParse(input, out chosenId))
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    continue;
                }

                selectedAnswer = GetAnswerById(chosenId);

                if (selectedAnswer == null)
                {
                    Console.WriteLine("This ID doesn't match any of the available choices. Please try again.");
                    continue;
                }

                break;
            }

            StudentAnswer = selectedAnswer;
        }

    }
}

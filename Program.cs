using System;
using System.Collections.Generic;

namespace OOP_Exam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int examTypeChoice = ReadValidInt("Enter the type of exam (1 for Practical, 2 for Final):", 1, 2);
            ExamType examType;
            if(examTypeChoice == 1)
            {
                examType = ExamType.Practical;
            }
            else
            {
                examType = ExamType.Final;
            }

            int duration = ReadValidInt("Please enter the time for the exam (30 to 180 minutes):", 30, 180);

            int numberOfQuestions = ReadValidInt("Please enter the number of questions:", 1, int.MaxValue);

            var questions = new List<Question>();



            for (int i = 1; i <= numberOfQuestions; i++)
            {
                Question question = ReadOneQuestion(i, examType);
                questions.Add(question);
            }



            Subject subject;
            try
            {
                subject = new Subject(1, "OOP");
                subject.CreateExam(examType, duration, numberOfQuestions, questions);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.ReadLine();
                return;
            }

            string startChoice = ReadYesNo("Do You Want To Start Exam (Y | N)");

            if (startChoice == "Y")
            {
                Console.WriteLine(examType == ExamType.Practical ? "Practical Exam" : "Final Exam");
                subject.Exam.RunExam();
                subject.Exam.ShowExam();
            }
            else
            {
                Console.WriteLine("Exam cancelled.");
            }

            Console.ReadLine();
        }

        static Question ReadOneQuestion(int questionNumber, ExamType examType)
        {
            while (true)
            {
                Console.WriteLine($"Enter details for question {questionNumber}:");

                int qType;
                while (true)
                {
                    qType = ReadValidInt("Choose question type: 1 for MCQ, 2 for True/False:", 1, 2);

                        //user-experiense -level valiidation
                    if (examType == ExamType.Practical && qType == 2)
                    {
                        Console.WriteLine("Sorry, Practical Exam can contain MCQ questions only. True/False is not allowed here. Please enter 1.");
                        continue;
                    }
                    break;
                }

                string body = ReadNonEmptyString("Please enter the question body:");
                int mark = ReadValidInt("Please enter the question mark:", 1, int.MaxValue);

                try
                {
                    if (qType == 1)
                    {
                        Console.WriteLine("Choices of Question:");
                        int choiceCount = ReadValidInt("How many choices does this question have?", 1, int.MaxValue);

                        var answers = new List<Answer>();
                        for (int c = 1; c <= choiceCount; c++)
                        {
                            string text = ReadNonEmptyString($"Please enter choice number {c}:");
                            answers.Add(new Answer(c, text));
                        }


                        int correctId = ReadValidInt($"Please enter the ID of the correct answer (1 to {choiceCount}):", 1, choiceCount);
                        Answer rightAnswer = answers.Find(a => a.AnswerId == correctId);

                        return new MCQQuestion($"Q{questionNumber}", body, mark, answers, rightAnswer);
                    }
                    else
                    {
                        var answers = new List<Answer>
                        {
                            new Answer(1, "True"),
                            new Answer(2, "False")
                        };

                        int correctId = ReadValidInt("Please enter the ID of the correct answer (1 for True, 2 for False):", 1, 2);
                        Answer rightAnswer = answers.Find(a => a.AnswerId == correctId);

                        return new TrueOrFalseQuestion($"Q{questionNumber}", body, mark, answers, rightAnswer);
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    Console.WriteLine("Let's re-enter this question.");
                }
            }
        }


        static int ReadValidInt(string prompt, int min, int max)
        {
            while (true)
            {
                Console.WriteLine(prompt);
                string input = Console.ReadLine();

                if (!int.TryParse(input, out int value))
                {
                    Console.WriteLine("Invalid input. Please enter a whole number.");
                    continue;
                }

                if (value < min || value > max)
                {
                    Console.WriteLine($"Please enter a number between {min} and {max}.");
                    continue;
                }

                return value;
            }
        }

        static string ReadNonEmptyString(string prompt)
        {
            while (true)
            {
                Console.WriteLine(prompt);
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("This field cannot be empty. Please try again.");
                    continue;
                }

                return input;
            }
        }

        static string ReadYesNo(string prompt)
        {
            while (true)
            {
                Console.WriteLine(prompt);
                string input = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(input))
                {
                    string upper = input.Trim().ToUpper();
                    if (upper == "Y" || upper == "N")
                        return upper;
                }

                Console.WriteLine("Please enter Y or N.");
            }
        }
    }
}
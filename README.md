# OOP Exam System

A console application written in C# (.NET) that lets a user create an exam, take it, and get an automatic grade.

## Features

- Choose the exam type: **Practical** (MCQ questions only) or **Final** (MCQ and True/False)
- Set the exam duration (30 to 180 minutes) and the number of questions
- Add questions with a mark, the choices, and the correct answer
- Take the exam in the console and see your answers, the correct answers, and your grade out of the total marks
- Input validation:
  - duplicate choices are rejected
  - marks must be positive
  - MCQ questions need at least 3 choices
  - True/False questions need exactly two answers: True and False
  - the correct answer must be one of the choices
  - Practical exams reject True/False questions

## OOP concepts used

| Concept | Where |
|---|---|
| Abstraction | abstract classes `Exam` and `Question` |
| Inheritance | `FinalExam` and `PracticalExam` extend `Exam`; `MCQQuestion` and `TrueOrFalseQuestion` extend `Question` |
| Polymorphism | overridden `ShowExam()`, `ValidateAnswers()` and `QuestionType` |
| Encapsulation | properties and constructors that validate their input |
| Interfaces | `ICloneable` and `IComparable<Question>` on `Question` |

## Project structure

| File | Purpose |
|---|---|
| `Program.cs` | console input, validation loops, and the program flow |
| `Subject.cs` | creates the exam for a subject |
| `Exam.cs`, `FinalExam.cs`, `PracticalExam.cs` | exam base class and its two types |
| `Question.cs`, `MCQQuestion.cs`, `TrueOrFalseQuestion.cs` | question base class and its two types |
| `Answer.cs` | a single answer choice |
| `ExamType.cs` | enum for the exam types |

## How to run

You need the .NET SDK installed.

```
git clone https://github.com/rakanbakr2/OOP-Exam-System.git
cd OOP-Exam-System
dotnet run
```

## Known limitations

- The exam duration is stored, but a countdown timer is not implemented yet.
- The time shown at the end measures only how long the results took to print.

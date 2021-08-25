using System;
using System.Collections.Generic;

namespace FunWithQuizzes
{
    public class Program
        {
            private static void CreateAndAddQuestions(Quiz quiz)
            {
                // Create a multiple-choice question object
                Question q1 = new MultipleChoiceQuestion("Which language is not a strongly typed language?",
                    new Dictionary<int, string>() {
                    {1, "Java" },
                    {2, "Javascript" },
                    {3, "C#" },
                    {4, "None of the above" }
                    },
                    2);

                // Create a checkbox question object
                Question q2 = new CheckBoxQuestion("Select the planets:",
                    new Dictionary<int, KeyValuePair<bool, string>>() {
                    {1, new KeyValuePair<bool, string>(true, "Earth") },
                    {2, new KeyValuePair<bool, string>(false, "Canopus") },
                    {3, new KeyValuePair<bool, string>(false, "Capella") },
                    {4, new KeyValuePair<bool, string>(false, "Vega") },
                    {5, new KeyValuePair<bool, string>(true, "Saturn") },
                    {6, new KeyValuePair<bool, string>(true, "Pluto") }
                    }
                );

                // Create a truefalse question object
                Question q3 = new TrueFalseQuestion("Coffee is made from berries.", true);

                // Create a short answer question object
                Question q4 = new ShortAnswerQuestion("What's the keyword to create an instance of an class?", "new");

                // Create a linear range question object
                Question q5 = new ScaleQuestion("Provide the low and high numbers (in mg/dL) of the range of blood glucose that is prediabetes (see https://www.mayoclinic.org/diseases-conditions/diabetes/diagnosis-treatment/drc-20371451).", 140, 199);

                // Add the question objects to the quiz
                quiz.AddQuestion(q1);
                quiz.AddQuestion(q2);
                quiz.AddQuestion(q3);
                quiz.AddQuestion(q4);
                quiz.AddQuestion(q5);
            }

            static void Main(string[] args)
            {
                // Create a new quiz
                Quiz quiz = new Quiz();

                CreateAndAddQuestions(quiz);

                // Display all questions, answer choices, & correct answers
                //quiz.ShowAllQuestionsAndCorrectAnswers();

                Console.WriteLine("\nA Quiz For You");
                for (int i = 0; i < quiz.Questions.Count; i++)
                {
                    Console.Write("\nQuestion " + (i + 1) + " - ");
                    Question q = quiz.Questions[i];
                    q.PresentQuestion();
                    q.PromptAndCheckAnswer();
                    Console.WriteLine();
                }
            }
        }
    }
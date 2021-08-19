using System;
using System.Collections.Generic;
using System.Text;

namespace FunWithQuizzes
{
    public class ShortAnswerQuestion : Question
    {
        public string CorrectAnswer { get; set; }

        public ShortAnswerQuestion(string questionText) : base(questionText)
        {

        }

        public ShortAnswerQuestion(string questionText, string correctAnswer) : base(questionText)
        {
            CorrectAnswer = correctAnswer;
        }

        public override void DisplayCorrectAnswers()
        {
            Console.WriteLine(CorrectAnswer);
        }

        private void CheckAnswers(string userAnswer)
        {
            userAnswer = userAnswer.Trim().ToLower();
            if (userAnswer.Length >= 80)
            {
                Console.WriteLine("Sorry, you entered 80 or more characters.");
                return;
            }
            if (userAnswer.Equals(CorrectAnswer))
            {
                Console.WriteLine("You are correct!");
            }
            else
            {
                Console.WriteLine("Sorry, you're incorrect. The answer is '" + CorrectAnswer + "'.");
            }
        }

        public override void PresentQuestion()
        {
            DisplayQuestion();
        }

        public override void PromptAndCheckAnswer()
        {
            Console.WriteLine();
            Console.WriteLine("Your answer (fewer than 80 characters)");
            string userInput = Console.ReadLine();
            Console.WriteLine();
            CheckAnswers(userInput);
        }
    } // class
} // namespace

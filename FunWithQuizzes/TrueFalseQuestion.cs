using System;
using System.Collections.Generic;
using System.Text;

namespace FunWithQuizzes
{
    class TrueFalseQuestion : Question
    {
        public bool Answer { get; set; }

        public TrueFalseQuestion(string questionText, bool answer) : base(questionText)
        {
            Answer = answer;
        }

        public override void DisplayCorrectAnswers()
        {
            Console.WriteLine("Answer: " + Answer);
        }

        private void CheckAnswers(string userAnswer)
        {
            userAnswer = userAnswer.Trim().ToLower();
            string allcapsAnswer = Answer.ToString().ToUpper();

            Console.WriteLine();
            if (userAnswer.Equals("t") && Answer || userAnswer.Equals("f") && !Answer)
            {
                Console.Write("You are correct! It is ");
            }
            else
            {
                Console.Write("Sorry, you are incorrect. The correct answer is ");
            }
            Console.WriteLine(allcapsAnswer + ".");
        }

        public void DisplayAnswerChoices()
        {
            Console.WriteLine();
            Console.WriteLine("(T)rue or (F)alse: ");
        }

        public override void PresentQuestion()
        {
            DisplayQuestion();
            DisplayAnswerChoices();
        }

        public override void PromptAndCheckAnswer()
        {
            Console.WriteLine();
            Console.WriteLine("Your answer:");
            string userInput = Console.ReadLine();
            //Console.WriteLine();
            CheckAnswers(userInput);
        }
    } // class
} // namespace
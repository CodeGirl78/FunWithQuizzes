using System;
using System.Collections.Generic;
using System.Text;

namespace FunWithQuizzes
{
    public class ScaleQuestion : Question
    {
        public int AnswerScaleBegin { get; set; }
        public int AnswerScaleEnd { get; set; }

        public ScaleQuestion(string questionText) : base(questionText)
        {

        }

        public ScaleQuestion(string questionText, int answerScaleBegin, int answerScaleEnd) : base(questionText)
        {
            AnswerScaleBegin = answerScaleBegin;
            AnswerScaleEnd = answerScaleEnd;
        }

        private void CheckAnswers(string userAnswer)
        {
            bool answerIsCorrect = true;
            string[] userAnswers = userAnswer.Split(" ");
            //int userAnswerCount = userAnswers.Length; 
            if (userAnswers.Length != 2)
            {
                answerIsCorrect = false;
            }
            else
                if (int.Parse(userAnswers[0]) != AnswerScaleBegin || int.Parse(userAnswers[1]) != AnswerScaleEnd)
                answerIsCorrect = false;

            if (answerIsCorrect)
                Console.WriteLine("You're correct!");
            else
                Console.WriteLine("Sorry, the correct range is " + AnswerScaleBegin + " - " + AnswerScaleEnd + ".");
        }

        public override void DisplayCorrectAnswers()
        {
            throw new NotImplementedException();
        }

        /*      
                public override void DisplayQuestion()
                {
                    base.DisplayQuestion();
                }
        */

        public override void PresentQuestion()
        {
            base.DisplayQuestion();
            Console.WriteLine();
        }

        public override void PromptAndCheckAnswer()
        {
            Console.WriteLine();
            Console.WriteLine("Type 2 numbers, separated by space, then <Enter>");
            string userInput = Console.ReadLine();
            Console.WriteLine();
            CheckAnswers(userInput);
        }
    } // class
} // namespace
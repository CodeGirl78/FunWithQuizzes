using System;
using System.Collections.Generic;
using System.Text;

namespace FunWithQuizzes
{
    public abstract class Question
    {
        public string QuestionText { get; set; }

        public Question(string questionText)
        {
            QuestionText = questionText;
        }

        public virtual void DisplayQuestion()
        {
            Console.WriteLine(QuestionText);
        }

        public abstract void PresentQuestion();

        public abstract void PromptAndCheckAnswer();

        //public abstract void DisplayAnswerChoices();

        public abstract void DisplayCorrectAnswers();

        //public abstract void DisplayPromptForAnswer();

        //public abstract void CheckAnswers(string userAnswer);
    }
}
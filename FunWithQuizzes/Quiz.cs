using System;
using System.Collections.Generic;
using System.Text;

namespace FunWithQuizzes
{
    public class Quiz
    {
        private const string ASTERISK_LINE = "******************************************";
        public List<Question> Questions { get; set; }// = new List<Question> { };

        public Quiz()
        {
            Questions = new List<Question> { };
        }

        public Quiz(List<Question> questions)
        {
            Questions = questions;
        }

        public void AddQuestion(Question question)
        {
            Questions.Add(question);
        }

        public void ShowAllQuestionsAndAnswers()
        {

        }

        public void ShowAllQuestionsAndCorrectAnswers()
        {
            Console.WriteLine(ASTERISK_LINE + "\nQuestions & Correct Answers\n" + ASTERISK_LINE + "\n");
            for (int i = 0; i < Questions.Count; i++)
            {
                Console.Write("\nQuestion " + (i + 1) + " - ");
                Question q = Questions[i];
                q.DisplayQuestion();
                Console.WriteLine();
                if (q is MultipleChoiceQuestion)
                {
                    (q as MultipleChoiceQuestion).DisplayAnswerChoices();
                    Console.WriteLine();
                    q.DisplayCorrectAnswers();
                }
                if (q is CheckBoxQuestion)
                {
                    q.DisplayCorrectAnswers();
                    Console.WriteLine();
                }
                if (q is TrueFalseQuestion)
                {
                    (q as TrueFalseQuestion).DisplayAnswerChoices();
                    Console.WriteLine();
                    q.DisplayCorrectAnswers();
                }
                if (q is ShortAnswerQuestion)
                {
                    q.DisplayCorrectAnswers();
                }
                if (q is ScaleQuestion)
                {
                    q.DisplayCorrectAnswers();
                }
                Console.WriteLine("\n" + ASTERISK_LINE);
            }
        }
    } // class
} // namespace

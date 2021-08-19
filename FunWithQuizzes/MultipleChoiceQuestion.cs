using System;
//using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FunWithQuizzes
{
    public class MultipleChoiceQuestion : Question
    {
        public Dictionary<int, string> AnswerChoices { get; set; }
        public int CorrectAnswer { get; set; }


        public MultipleChoiceQuestion(string questionText) : base(questionText)
        {

        }

        public MultipleChoiceQuestion(string questionText, int correctAnswer) : base(questionText)
        {
            CorrectAnswer = correctAnswer;
        }

        public MultipleChoiceQuestion(string questionText, Dictionary<int, string> answerChoices, int correctAnswer) : base(questionText)
        {
            CorrectAnswer = correctAnswer;
            AnswerChoices = answerChoices;
        }

        private int GetNextUnusedAnswerChoice() 
        {
            List<int> keyChoices = AnswerChoices.Keys.ToList();
            keyChoices.Sort();
            return keyChoices[keyChoices.Count];
        }

        private List<int> GetSortedKeys()
        {
            List<int> keyChoices = AnswerChoices.Keys.ToList();
            keyChoices.Sort();
            return keyChoices;
        }

        public string AddChoice(string choiceText)
        {
            List<int> sortedKeys = GetSortedKeys();
            int keyNum = sortedKeys[sortedKeys.Count];
            return AddChoice(keyNum, choiceText);
        }

        public string AddChoice(int choiceNumber, string choiceText)
        {
            if (AnswerChoices == null)
            {
                AnswerChoices = new Dictionary<int, string> { };
            }

            if (AnswerChoices.TryAdd(choiceNumber, choiceText))
            {
                return "'" + choiceText + "' was added successfully as choice # " + choiceNumber;
            }
            return "Failed: '" + choiceText + "' was NOT ADDED.";
        }

        public string SetCorrectChoice(int correctChoice)
        {
            List<int> keyChoices = GetSortedKeys();
            if (keyChoices.Contains(correctChoice))
            {
                return "Correct answer set to choice # " + correctChoice;
            }
            return "Failed to set correct answer: Choice # " + correctChoice + " NOT FOUND";
        }

        public void DisplayAnswerChoices()
        {
            Console.WriteLine();
            foreach (KeyValuePair<int, string> answer in AnswerChoices)
            {
                Console.WriteLine(answer.Key + ". " + answer.Value);
            }
        }

        public override void PresentQuestion()
        {
            DisplayQuestion();
            DisplayAnswerChoices();
        }

        public override void PromptAndCheckAnswer()
        {
            Console.WriteLine();
            Console.WriteLine("Your answer (type a number, then <Enter>): ");
            string userInput = Console.ReadLine();
            Console.WriteLine();

            // Check answer
            int userAnswerInt = int.Parse(userInput);
            if (userAnswerInt == CorrectAnswer)
            {
                Console.Write("You are correct. It is choice # ");
            }
            else
            {
                Console.Write("Sorry, you are incorrect. The correct choice is # ");
            }
            Console.WriteLine(CorrectAnswer + ".");
        }

        public override void DisplayCorrectAnswers()
        {
            Console.WriteLine("Correct answer is choice : " + CorrectAnswer);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FunWithQuizzes
{
    public class CheckBoxQuestion : Question
    {
        public Dictionary<int, KeyValuePair<bool, string>> Answers { get; set; } = new Dictionary<int, KeyValuePair<bool, string>>();
        private Dictionary<int, string> correctAnswers;

        private void SetCorrectAnswers()
        {
            if (Answers != null)
            {
                correctAnswers = new Dictionary<int, string>();
                foreach (KeyValuePair<int, KeyValuePair<bool, string>> answer in Answers)
                {
                    if (answer.Value.Key)
                    {
                        correctAnswers.Add(answer.Key, answer.Value.Value);
                    }
                }
            }
        }

        public CheckBoxQuestion(string questionText) : base(questionText)
        {
            SetCorrectAnswers();
        }

        public CheckBoxQuestion(string questionText, Dictionary<int, KeyValuePair<bool, string>> answers) : base(questionText)
        {
            Answers = answers;
            SetCorrectAnswers();
        }

        private int GetNextDictionaryIndex()
        {
            // Note we will assume dictionary index will start with 1, and NOT 0
            // because we don't want users to display a 0-index next to an answer choice

            // assume dictionary is sorted
            int dictionarySize = Answers.Count;
            if (!Answers.ContainsKey(dictionarySize))
            {
                return dictionarySize;
            }

            // here, dictionary is not sorted, so sort, & add 1 to largest index
            int[] dictionaryIndices = Answers.Keys.ToArray();
            Array.Sort(dictionaryIndices);
            return dictionaryIndices[dictionaryIndices.Length - 1] + 1;
        }

        public void AddChoice(bool check, string answerText)
        {
            KeyValuePair<bool, string> answer = new KeyValuePair<bool, string>(check, answerText);
            int dictionaryIndex = GetNextDictionaryIndex();
            Answers.Add(dictionaryIndex, answer);
            SetCorrectAnswers();
        }

        public void AddChoice(KeyValuePair<bool, string> answer)
        {
            AddChoice(answer.Key, answer.Value);
        }

        public override void DisplayCorrectAnswers()
        {
            foreach (KeyValuePair<int, string> correctAnswer in correctAnswers)
            {
                Console.WriteLine(correctAnswer.Key + ". " + correctAnswer.Value);
            }
        }

        private void CheckAnswers(string userAnswer)
        {
            // Logic:
            // 1. Convert user's choices to a sorted int array
            // 2. Convert correct answers to a sorted int array of indices
            // 3. If arrays different length, then incorrect, so set answerIsCorrect to false
            // 4. Arrays same length, so compare each element. If any element is different,
            //    set answerIsCorrect to false.

            bool answerIsCorrect = true;

            string[] userAnswers = userAnswer.Split(" ");
            int userAnswerCount = userAnswers.Length; // an int array of user's answers

            if (correctAnswers.Count == userAnswerCount)
            {
                int[] userIntAnswers = new int[userAnswerCount];
                for (int i = 0; i < userAnswerCount; i++)
                {
                    userIntAnswers[i] = int.Parse(userAnswers[i]);
                }
                Array.Sort(userIntAnswers);

                int[] correctIntAnswers = correctAnswers.Keys.ToList().ToArray();
                Array.Sort(correctIntAnswers);

                for (int j = 0; j < userAnswerCount; j++)
                {
                    if (userIntAnswers[j] != correctIntAnswers[j])
                    {
                        answerIsCorrect = false;
                        break;
                    }
                }
            }
            else
            {
                answerIsCorrect = false;
            }

            if (answerIsCorrect)
            {
                Console.WriteLine("You are correct!");
            }
            else
            {
                Console.WriteLine("Sorry. The correct answers are: ");
                DisplayCorrectAnswers();
            }
        }

        public override void PresentQuestion()
        {
            DisplayQuestion();

            // Display answer choices
            Console.WriteLine();
            foreach (KeyValuePair<int, KeyValuePair<bool, string>> answer in Answers)
            {
                Console.WriteLine(answer.Key + ". " + answer.Value.Value);
            }
        }

        public override void PromptAndCheckAnswer()
        {
            Console.WriteLine();
            Console.WriteLine("Your answer (type 1 or more numbers separated by space, then <Enter>):");
            string userInput = Console.ReadLine();
            Console.WriteLine();
            CheckAnswers(userInput);
        }
    } // class
} // namespace
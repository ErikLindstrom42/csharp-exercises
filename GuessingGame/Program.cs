using System;

namespace GuessingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int secretNumber = new Random().Next(1, 101);
            int attempts = 0;
            int attemptsAvailable = 0;
            bool difficultySet = false;
            bool isCheater = false;
            Console.WriteLine("Welcome to the Guessing Game!");

            while (!difficultySet)
            {
                Console.WriteLine("Please select your difficulty level. Easy, Medium, or Hard");
                string difficulty = Console.ReadLine();
                if (isCheater) attemptsAvailable = 4;

                if (difficulty == "Easy")
                {
                    attemptsAvailable = 8;
                    difficultySet = true;
                }
                else if (difficulty == "Medium")
                {
                    attemptsAvailable = 6;
                    difficultySet = true;
                }
                else if (difficulty == "Hard")
                {
                    attemptsAvailable = 4;
                    difficultySet = true;
                }
                else if (difficulty == "Cheater")
                {
                    attemptsAvailable = 4;
                    difficultySet = true;
                    isCheater = true;

                }
                else if (difficulty == "iddqd")
                {
                    attemptsAvailable = 42;
                    difficultySet = true;
                    isCheater = true;
                    Console.WriteLine("GOD MODE ACTIVATED");
                }
            }


            while (attempts < attemptsAvailable)
            {
                Console.Write($"You have {attemptsAvailable - attempts} attempts remaining. Enter your guess for the secret number:");
                int guess;
                string stringGuess = Console.ReadLine();
                if (!Int32.TryParse(stringGuess, out guess))
                {
                    Console.WriteLine("Not a number");
                }
                else if (guess == secretNumber)
                {
                    Console.WriteLine("Success!");
                    break;
                }
                else if (guess > secretNumber)
                {
                    Console.WriteLine("Too high!");
                    if (!isCheater) attempts++;

                }

                else if (guess < secretNumber)
                {
                    Console.WriteLine("Too low.");
                    if (!isCheater) attempts++;
                }

            }
        }
    }
}

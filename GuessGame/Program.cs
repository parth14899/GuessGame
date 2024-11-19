using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();
        int targetNumber = random.Next(1, 101); // Random number between 1 and 100
        List<Guess> guesses = new List<Guess>(); // List to store previous guesses
        int userGuess = 0;

        Console.WriteLine("Welcome to the Guessing Game!");
        Console.WriteLine("Guess a number between 1 and 100.");

        // Loop until the user guesses the correct number
        do
        {
            string input = Console.ReadLine();
            bool isValidGuess = int.TryParse(input, out userGuess);

            if (!isValidGuess)
            {
                Console.WriteLine("Please enter a valid number.");
                continue;
            }

            // Check if the guess has been made before
            var previousGuess = guesses.Find(g => g.UserGuess == userGuess);
            if (previousGuess != null)
            {
                int turnsAgo = guesses.Count - guesses.IndexOf(previousGuess);
                Console.WriteLine($"You guessed this number {turnsAgo} turns ago!");
            }
            else
            {
                guesses.Add(new Guess(userGuess)); // Add new guess to the list
            }

            // Check if the guess is higher, lower, or correct
            if (userGuess < targetNumber)
            {
                Console.WriteLine("Your guess is too low. Try again.");
            }
            else if (userGuess > targetNumber)
            {
                Console.WriteLine("Your guess is too high. Try again.");
            }
            else
            {
                Console.WriteLine($"You Won! The answer was {targetNumber}.");
                break;
            }

        } while (userGuess != targetNumber); // Exit the loop if the guess is correct
    }
}

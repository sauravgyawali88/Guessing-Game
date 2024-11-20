using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Step 1: Generate a random number between 1 and 100
        Random rand = new Random();
        int hiddenNumber = rand.Next(1, 101); // Generates a random number 

        // Step 2: Create a list to store all guesses
        List<Guess> guesses = new List<Guess>();

        // Step 3: Game continues until the user guesses correctly
        int userGuess = -1; // Initialize the user's guess variable
        bool isGuessedCorrectly = false; // Flag to check if the correct guess is made

        do
        {
            // Step 4: Prompt user to input their guess
            Console.Write("Enter your guess (1-100): ");
            string input = Console.ReadLine();
            
            // Step 5: Validate user input and try to parse it as an integers
            if (int.TryParse(input, out userGuess))
            {
                // Check if the guess is within the valid range
                if (userGuess < 1 || userGuess > 100)
                {
                    Console.WriteLine("Please enter a number between 1 and 100.");
                    continue;
                }

                // Step 6: Create a new Guess object and add it to the guesses list
                Guess guess = new Guess(userGuess);
                guesses.Add(guess);

                // Step 7: Compare the guess to the hidden number and provide feedback
                if (userGuess < hiddenNumber)
                {
                    Console.WriteLine("Your guess is too low.");
                }
                else if (userGuess > hiddenNumber)
                {
                    Console.WriteLine("Your guess is too high.");
                }
                else
                {
                    // Correct guess
                    isGuessedCorrectly = true;
                    Console.WriteLine("You guessed correctly!");
                }

                // Step 8: Check if the guess was repeated
                foreach (var previousGuess in guesses)
                {
                    if (previousGuess.UserGuess == userGuess)
                    {
                        // Find the number of turns since this guess was made
                        int turn = guesses.Count - guesses.FindIndex(g => g.UserGuess == userGuess);
                        Console.WriteLine($"You guessed this number {turn} turns ago!");
                    }
                }

            }
            else
            {
                // If input is not a valid number
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
        while (!isGuessedCorrectly); // Keep looping until the user guesses correctly

        // Step 9: Print a congratulatory message when the game is won
        Console.WriteLine($"You Won! The answer was {hiddenNumber}."); // End game message
    }
}

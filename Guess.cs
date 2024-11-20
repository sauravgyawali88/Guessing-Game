using System;

public class Guess
{
    // Property to store the guessed number
    public int UserGuess { get; }
    
    // Property to store the time the guess was made
    public DateTime GuessTime { get; }

    // Constructor that accepts the guessed number and sets the guess time
    public Guess(int userGuess)
    {
        UserGuess = userGuess;
        GuessTime = DateTime.Now; // Set the current time when the guess is made
    }
}

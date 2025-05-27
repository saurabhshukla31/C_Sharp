using System;

public class CricketMatch
{
    public int[] playerScores = new int[5]; // Array to hold scores of up to 5 players
    public int currentIndex = 0; // Tracks the current number of scores added

    // Method to add a player's score
    public void AddPlayerScore(int score)
    {
        if (currentIndex >= 5)
        {
            throw new InvalidOperationException("Cannot add more than 5 player scores.");
        }
        if (score < 0 || score > 50)
        {
            throw new ArgumentException("Invalid score. Score must be between 0 and 50.");
        }
        playerScores[currentIndex] = score;
        currentIndex++;
    }

    // Method to calculate the total score
    public int CalculateTotalScore()
    {
        int total = 0;
        for (int i = 0; i < currentIndex; i++)
        {
            total += playerScores[i];
        }
        return total;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        CricketMatch match = new CricketMatch();

      
        string input = Console.ReadLine();
        string[] scoreStrings = input.Split(' ');

        try
        {
            foreach (string scoreString in scoreStrings)
            {
                if (int.TryParse(scoreString, out int score))
                {
                    match.AddPlayerScore(score);
                }
                else
                {
                    throw new ArgumentException("Invalid score. Score must be between 0 and 50.");
                }
            }

            int totalScore = match.CalculateTotalScore();
            Console.WriteLine($"Total score of the cricket team: {totalScore}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
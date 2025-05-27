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


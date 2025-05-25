using System;

public class StringAnalyzer
{
    public static (int vowels, int consonants) CountVowelsAndConsonants(string input)
    {
        int vowels = 0, consonants = 0;
        char[] vowelChars = { 'a', 'e', 'i', 'o', 'u' };

        foreach (char c in input.ToLower())
        {
            if (char.IsLetter(c))
            {
                if (Array.Exists(vowelChars, v => v == c))
                {
                    vowels++;
                }
                else
                {
                    consonants++;
                }
            }
        }

        return (vowels, consonants);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        string input;

        while (true)
        {
            input = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(input))
            {
                break;
            }
            else
            {
                Console.WriteLine("Please enter a valid string.");
            }
        }

        var (vowels, consonants) = StringAnalyzer.CountVowelsAndConsonants(input);

        Console.WriteLine($"Number of vowels: {vowels}");
        Console.WriteLine($"Number of consonants: {consonants}");
    }
}

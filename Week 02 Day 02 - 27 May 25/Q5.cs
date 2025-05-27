using System;

public class InvalidStringException: Exception
{
    public InvalidStringException(): base("Invalid string privided."){}
    public InvalidStringException(string message):base(message){}
}

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string input = Console.ReadLine();
            foreach(char c in input)
            {
                if(!char.IsLetter(c))
                {
                    throw new InvalidStringException("String must contain only alphabetic characters.");
                }
            }
            int vowelCount = 0;
            string vowels = "aeiouAEIOU";
            foreach(char c in input)
            {
                if(vowels.Contains(c))
                {
                    vowelCount++;
                }
            }
            Console.WriteLine($"Number of vowels: {vowelCount}");
        }
        catch(InvalidStringException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Error: An unexpected error occcured. {ex.Message}");
        }
    }
}

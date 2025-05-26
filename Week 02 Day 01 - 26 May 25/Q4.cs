using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        string input = Console.ReadLine();
        List<int> numbers = ParseIntegers(input);
        List<int> oddNumbers = GetOddNumbers(numbers);

        Console.WriteLine(string.Join(" ", oddNumbers));
    }

    private static List<int> ParseIntegers(string input)
    {
        List<int> result = new List<int>();
        string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        foreach (string part in parts)
        {
            if (int.TryParse(part, out int number))
            {
                result.Add(number);
            }
        }

        return result;
    }

    private static List<int> GetOddNumbers(List<int> numbers)
    {
        List<int> oddNumbers = new List<int>();

        foreach (int num in numbers)
        {
            if (num % 2 != 0)
            {
                oddNumbers.Add(num);
            }
        }

        oddNumbers.Sort();
        return oddNumbers;
    }
}

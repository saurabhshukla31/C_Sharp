using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        string input = Console.ReadLine();
        List<int> numbers = ReadIntegerList(input);

        if (numbers.Count == 0)
        {
            Console.WriteLine("Invalid input");
            return;
        }

        List<int> squared = SquareValues(numbers);
        ManualSort(squared);

        Console.WriteLine(string.Join(" ", squared));
    }

    private static List<int> ReadIntegerList(string input)
    {
        List<int> result = new List<int>();
        string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        foreach (string part in parts)
        {
            if (int.TryParse(part, out int number))
            {
                result.Add(number);
            }
            else
            {
                return new List<int>();
            }
        }

        return result;
    }

    private static List<int> SquareValues(List<int> numbers)
    {
        List<int> squared = new List<int>();
        foreach (int num in numbers)
        {
            squared.Add(num * num);
        }
        return squared;
    }

    private static void ManualSort(List<int> list)
    {
        int n = list.Count;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (list[j] > list[j + 1])
                {
                    int temp = list[j];
                    list[j] = list[j + 1];
                    list[j + 1] = temp;
                }
            }
        }
    }
}

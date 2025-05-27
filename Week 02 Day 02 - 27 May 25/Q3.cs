using System;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string inputArray1 = Console.ReadLine();
            int[] numbers1 = Array.ConvertAll(inputArray1.Split(' '),int.Parse);
            
            string inputArray2 = Console.ReadLine();
            int[] numbers2 = Array.ConvertAll(inputArray2.Split(' '),int.Parse);

            int index = int.Parse(Console.ReadLine());

            if(numbers1.Length != numbers2.Length)
            {
                Console.WriteLine("Error: Arrays must have the same length for addition.");
                return;
            }

            int[] sumArray = new int[numbers1.Length];
            for(int i = 0; i < numbers1.Length; i++)
            {
                sumArray[i] = numbers1[i] + numbers2[i];
            }

            Console.WriteLine($"Element at index {index} in the sum array: {sumArray[index]}");
        }
        catch(FormatException ex)
        {
            Console.WriteLine("Error: Invalid input format. Please enter integers only.");
            Console.WriteLine($"Exception Message: {ex.Message}");
        }
        catch(IndexOutOfRangeException ex)
        {
            Console.WriteLine("Error: Index out of range for the sum array.");
            Console.WriteLine($"Exception Message: {ex.Message}");
        }
    }
}

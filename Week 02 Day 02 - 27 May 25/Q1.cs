using System;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string input = Console.ReadLine();
            if (!double.TryParse(input, out double temperature))
            {
                throw new SystemException("Input string was not in a correct format.");
            }
            
            string conversionType = Console.ReadLine()?.Trim().ToUpper();
            
            if (conversionType == "C")
            {
                double fahrenheit = (temperature * 9 / 5) + 32;
                Console.WriteLine($"Temperature in Fahrenheit: {fahrenheit:F2}");
            }
            else if (conversionType == "F")
            {
                double celsius = (temperature - 32) * 5 / 9;
                Console.WriteLine($"Temperature in Celsius: {celsius:F2}");
            }
            else
            {
                Console.WriteLine("Invalid conversion type. Please enter 'F' or 'C'.");
            }
        }
        catch (SystemException ex)
        {
            Console.WriteLine("Error: Invalid input provided.");
            Console.WriteLine($"Exception Message: {ex.Message}");
        }

    }
}

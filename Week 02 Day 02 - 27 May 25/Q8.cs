using System;

public class Program
{
    static void ReverseString(string input)
    {
        char[] charArray = input.ToCharArray();
        Array.Reverse(charArray);
        Console.WriteLine($"Reversed string: {new string(charArray)}");
    }

    static bool CheckPalindrome(string input)
    {
        string processedString = input.ToLower();
        char[] charArray = processedString.ToCharArray();
        Array.Reverse(charArray);
        string reversedString = new string(charArray);
        return processedString == reversedString;
    }

    public static void Main(string[] args)
    {
        Action<string> printReversedString = ReverseString;
        Func<string, bool> isPalindrome = CheckPalindrome;

        //Console.WriteLine("Enter operation (reverse/palindrome):");
        string operation = Console.ReadLine()?.ToLower();

        //Console.WriteLine("Enter the string:");
        string inputString = Console.ReadLine();

        if(operation == "reverse")
        {
            printReversedString(inputString);
        }
        else if(operation == "palindrome")
        {
            bool result = isPalindrome(inputString);
            Console.WriteLine($"Is palindrome: {result}");
        }
        else
        {
            Console.WriteLine("Invalid operation.");
        }
    }
}

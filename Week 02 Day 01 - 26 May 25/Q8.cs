using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        string input = Console.ReadLine();

        List<string> words = new List<string>(input.Split(' '));

        words.Sort((a,b) => b.Length.CompareTo(a.Length));

        Console.WriteLine(string.Join(" ", words));
    }
}

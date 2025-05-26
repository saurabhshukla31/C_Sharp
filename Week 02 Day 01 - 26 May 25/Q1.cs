using System;
using System.Collections;

public class Program
{
    private static bool IsValidName(string name)
    {
        return !string.IsNullOrWhiteSpace(name);
    }

    private static bool IsNameInCollection(ArrayList studentNames, string name)
    {
        foreach (string student in studentNames)
        {
            if (student.Equals(name, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
        }
        return false;
    }

    private static void DisplayStudentNames(ArrayList studentNames)
    {
        Console.WriteLine("Unique student names entered:");
        foreach (string item in studentNames)
        {
            Console.WriteLine(item);
        }
    }

    public static void Main(string[] args)
    {
        ArrayList studentNames = new ArrayList();
        ArrayList messages = new ArrayList();

        while (true)
        {
            string name = Console.ReadLine();
            if (name.Equals("stop", StringComparison.OrdinalIgnoreCase))
            {
                break;
            }

            if (IsValidName(name))
            {
                if (!IsNameInCollection(studentNames, name))
                {
                    studentNames.Add(name);
                    messages.Add($"{name} added to the collection.");
                }
                else
                {
                    messages.Add($"{name} is already in the collection.");
                }
            }
        }

        foreach (string msg in messages)
        {
            Console.WriteLine(msg);
        }

        DisplayStudentNames(studentNames);
    }
}

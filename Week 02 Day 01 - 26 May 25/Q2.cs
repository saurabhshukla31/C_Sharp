using System;
using System.Collections;

public class Program
{
    public static void Main(string[] args)
    {
        ArrayList arr = new ArrayList();
        ArrayList msg = new ArrayList();

        while (true)
        {
            string input = Console.ReadLine();

            if (input == "exit")
            {
                break;
            }

            switch (input)
            {
                case "add":
                    string addInput = Console.ReadLine();
                    if (int.TryParse(addInput, out int numberToAdd))
                    {
                        arr.Add(numberToAdd);
                        msg.Add($"{numberToAdd} added to the number list.");
                    }
                    else
                    {
                        msg.Add("Invalid input. Please enter a valid number.");
                    }
                    break;

                case "remove":
                    string removeInput = Console.ReadLine();
                    if (int.TryParse(removeInput, out int numberToRemove))
                    {
                        if (arr.Contains(numberToRemove))
                        {
                            arr.Remove(numberToRemove);
                            msg.Add($"{numberToRemove} removed from the number list.");
                        }
                        else
                        {
                            msg.Add($"{numberToRemove} not found in the number list.");
                        }
                    }
                    else
                    {
                        msg.Add("Invalid input. Please enter a valid number.");
                    }
                    break;

                case "display":
                    msg.Add("Current numbers in the list:");
                    foreach (var it in arr)
                    {
                        msg.Add(it.ToString());
                    }
                    break;

                default:
                    msg.Add("Invalid command");
                    break;
            }
        }

        foreach (string m in msg)
        {
            Console.WriteLine(m);
        }
    }
}

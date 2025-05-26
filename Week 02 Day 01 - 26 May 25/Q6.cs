using System;

public class Program
{
    public static void Create(HashSet<string> hashSet)
    {
        Console.Write("Enter the string to add: ");
        string addInput = Console.ReadLine();
        if(!hashSet.Contains(addInput)){
            hashSet.Add(addInput);
        }
        else
        {
            Console.WriteLine($"'{addInput}' already exists in the set.");
        }
    }
    public static void Read(HashSet<string> hashSet)
    {
        Console.WriteLine("Current items in the set:");
        foreach(string items in hashSet){
            Console.WriteLine(items);
        }
    }
    public static void Update(HashSet<string> hashSet)
    {
        Console.Write("Enter the string to update: ");
        string currentInput = Console.ReadLine();
        if(hashSet.Contains(currentInput)){
            Console.Write("Enter the string to update: ");
            string updateInput = Console.ReadLine();
            hashSet.Remove(currentInput);
            hashSet.Add(updateInput);
        }
        else{
            Console.WriteLine($"'{currentInput}' does not exist in the set.");
        }
    }
    public static void Delete(HashSet<string> hashSet)
    {
        Console.Write("Enter the string to delete: ");
        string deleteInput = Console.ReadLine();
        if(hashSet.Contains(deleteInput)){
            hashSet.Remove(deleteInput);
            Console.WriteLine($"'{deleteInput}' has been removed.");
        }
        else{
            Console.WriteLine($"'{deleteInput}' does not exist in the set.");
        }
    }
    public static void Main(string[] args)
    {
        Console.WriteLine("Choose an operation:");
        Console.WriteLine("1: Create (Add a new string)");
        Console.WriteLine("2: Read (Display all strings)");
        Console.WriteLine("3: Update (Update an existing string)");
        Console.WriteLine("4: Delete (Remove a string)");
        Console.WriteLine("5: Exit");
        HashSet<string> Set = new HashSet<string>();
        while(true){
            int choice = int.Parse(Console.ReadLine());
            if(choice == 5){
                break;
            }
            switch(choice){
            case 1:
                Create(Set);
                break;
            case 2:
                Read(Set);
                break;
            case 3:
                Update(Set);
                break;
            case 4:
                Delete(Set);
                break;
            default :
                Console.WriteLine("Please enter a valid Choice:");
                break;
            }
        }
    }
}

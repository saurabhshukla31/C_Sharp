using System;
 
public class Program
{
    public static void Main(string[] args)
    {
        LinkedList<string> studlist = new LinkedList<string>();
        bool running=true;
        while(running){
            Console.WriteLine("LinkedList Operations:");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Display Students");
            Console.WriteLine("3. Update Student");
            Console.WriteLine("4. Delete Student by Name");
            Console.WriteLine("5. Clear List");
            Console.WriteLine("6. Exit");
            Console.Write("Enter your choice (1-6) : ");
            int n=int.Parse(Console.ReadLine());
            switch (n)
            {
                case 1:
                    AddStudent(studlist);
                    break;
                case 2:
                    DisplayStudents(studlist);
                    break;
                case 3:
                    UpdateStudent(studlist);
                    break;
                case 4:
                    DeleteStudentByName(studlist);
                    break;
                case 5:
                    ClearList(studlist);
                    break;
                case 6:
                    running=false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
    public static void AddStudent(LinkedList<string> studlist){
        Console.Write("Enter student name to add: ");
        string name=Console.ReadLine();
        studlist.AddLast(name);
        Console.WriteLine($"{name} added to the list.");
    }
    public static void DisplayStudents(LinkedList<string> studlist){
        Console.WriteLine("Students in the list:");
        foreach (var student in studlist)
            Console.WriteLine(student);    
    }
    public static void UpdateStudent(LinkedList<string> studlist){
        Console.Write("Enter the current student name to update: ");
        string oname=Console.ReadLine();
        var node=studlist.Find(oname);
        if(node==null){
            Console.WriteLine($"{oname} not found in the list.");
            return;
        }
        Console.Write("Enter the new student name: ");
        string nname=Console.ReadLine();
        node.Value=nname;
        Console.WriteLine($"{oname} updated to {nname}.");
    }
    public static void DeleteStudentByName(LinkedList<string> studlist){
        Console.Write("Enter student name to delete: ");
        string name=Console.ReadLine();
        var node=studlist.Find(name);
        if(node==null){
            Console.WriteLine($"{name} not found in the list.");
            return;
        }
        studlist.Remove(node);
        Console.WriteLine($"{name} removed from the list.");
    }
    public static void ClearList(LinkedList<string> studlist){
        studlist.Clear();
        Console.WriteLine("The list has been cleared.");
    }
}

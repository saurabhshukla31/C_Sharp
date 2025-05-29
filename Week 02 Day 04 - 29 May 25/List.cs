using System.Collections.Generic;

public class Employee{

    public List<string> list {get;set;}= new List<string>();    // list is both property and object of List<> class
    public const int maxEmployee = 4;

    public void AddEmployee(string name){
        // read question carefully then apply validations
        if(string.IsNullOrWhiteSpace(name)){
            throw new ArgumentException("Employee name can't be null, empty or whitespace.");
        }
        // Console.WriteLine(list.Count);
        if(list.Count >= maxEmployee){
            throw new InvalidOperationException("Cannot add more than 4 employees.");
        }
        list.Add(name);
    }

    public void DisplayList(){
        Console.WriteLine("List of Employees:");
        foreach(var ele in list){
            Console.WriteLine(ele);
        }
    }

    public void SearchList(string name){
        if(list.Contains(name)){
            Console.WriteLine($"Employee '{name}' is available.");
        }else{
            Console.WriteLine($"Employee '{name}' is not available.");
        }
    }

    public void SortListAscending(){
        list.Sort();
        Console.WriteLine("Employee list sorted in ascending order: ");
        DisplayList();
    }

    public void SortListDescending(){
        list.Sort();
        list.Reverse();
        Console.WriteLine("Employee list sorted in ascending order: ");
        DisplayList();
    }

}

public class Program{

    public static void Main(string[] args){
        Employee emp = new Employee();
        //accept data from keyboard
        string data = Console.ReadLine();
        string[] names = data.Split(',');
        foreach(var item in names){
            try{
                emp.AddEmployee(item);
            }catch(ArgumentException e){
                Console.WriteLine($"Error: {e.Message}");
                return;
            }catch(Exception e){
                Console.WriteLine($"Error: {e.Message}");
                return;
            }
        }
        Console.WriteLine("Choose sorting option: asc/desc/none");
        string sortOptions = Console.ReadLine().Trim().ToLower();
        switch(sortOptions){
            case "asc":
                emp.SortListAscending();
            break;

            case "desc":
                emp.SortListDescending();
            break;

            default:
                emp.DisplayList();
            break;
        }

        Console.Write("enter a name to search: ");
        string search = Console.ReadLine();
        emp.SearchList(search);
    }
}

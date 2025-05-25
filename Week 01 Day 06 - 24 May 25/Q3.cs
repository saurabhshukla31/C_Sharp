using System;

public class Employee
{
    public virtual double CalculateSalary()
    {
        return 0;
    }
}

public class FullTimeEmployee : Employee
{
    public double hourlyRate { get; set; }
    public double hoursWorked { get; set; }

    public FullTimeEmployee() { }

    public FullTimeEmployee(double hr, double hw)
    {
        hourlyRate = hr;
        hoursWorked = hw;
    }

    public override double CalculateSalary()
    {
        return hourlyRate * hoursWorked;
    }
}

public class PartTimeEmployee : Employee
{
    public double hourlyRate { get; set; }
    public double hoursWorked { get; set; }

    public PartTimeEmployee() { }

    public PartTimeEmployee(double hr, double hw)
    {
        hourlyRate = hr;
        hoursWorked = hw;
    }

    public override double CalculateSalary()
    {
        return hourlyRate * hoursWorked * 0.8;
    }
}

public class Intern : Employee
{
    public double hourlyRate { get; set; }
    public double hoursWorked { get; set; }

    public Intern() { }

    public Intern(double hr, double hw)
    {
        hourlyRate = hr;
        hoursWorked = hw;
    }

    public override double CalculateSalary()
    {
        return hourlyRate * hoursWorked * 0.6;
    }
}
public class Program
{
    public static void Main(string[] args)
    {
        int num = int.Parse(Console.ReadLine());
        string type = "";
        string[] t = new string[num];

        if (num <= 0)
        {
            Console.WriteLine("Please enter a valid positive integer.");
        }
        else
        {
            Employee[] e = new Employee[num];

            for (int i = 0; i < num; i++)
            {
                type = Console.ReadLine();
                switch (type.ToLower())
                {
                    case "fulltimeemployee":
                        FullTimeEmployee f = new FullTimeEmployee();
                        t[i] = "FullTimeEmployee";
                        f.hourlyRate = double.Parse(Console.ReadLine());
                        f.hoursWorked = double.Parse(Console.ReadLine());
                        e[i] = f;
                        break;

                    case "parttimeemployee":
                        PartTimeEmployee p = new PartTimeEmployee();
                        t[i] = "PartTimeEmployee";
                        p.hourlyRate = double.Parse(Console.ReadLine());
                        p.hoursWorked = double.Parse(Console.ReadLine());
                        e[i] = p;
                        break;

                    case "intern":
                        Intern ne = new Intern();
                        t[i] = "Intern";
                        ne.hourlyRate = double.Parse(Console.ReadLine());
                        ne.hoursWorked = double.Parse(Console.ReadLine());
                        e[i] = ne;
                        break;

                    default:
                        Console.WriteLine("Invalid employee type.");
                        break;
                }
            }

            Console.WriteLine("Salaries of the employees:");
            for (int i = 0; i < num; i++)
            {
                Console.WriteLine($"Salary of Employee {i + 1} ({t[i]}): {e[i].CalculateSalary()}");
            }
        }
    }
}

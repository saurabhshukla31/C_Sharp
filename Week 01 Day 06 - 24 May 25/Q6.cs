using System;

public interface IStudent
{
    void CalcTotal();
    void CalcAvg();
    void CalcGrade();
    void PrintMarksheet();
}

public class Student : IStudent
{
    private int rno;
    private string name;
    private int sub1, sub2, sub3;
    private int total;
    private double average;
    private string grade;

    public void ReadData()
    {
        string input;

        input = Console.ReadLine();
        if (!int.TryParse(input, out rno))
        {
            Console.WriteLine("Invalid input! Please enter a valid integer for Roll No.");
            return;
        }

        name = Console.ReadLine();

        input = Console.ReadLine();
        if (!int.TryParse(input, out sub1))
        {
            Console.WriteLine("Invalid input! Please enter a valid integer for subject 1:");
            return;
        }

        input = Console.ReadLine();
        if (!int.TryParse(input, out sub2))
        {
            Console.WriteLine("Invalid input! Please enter a valid integer for subject 2:");
            return;
        }

        input = Console.ReadLine();
        if (!int.TryParse(input, out sub3))
        {
            Console.WriteLine("Invalid input! Please enter a valid integer for subject 3:");
            return;
        }
    }

    public void CalcTotal()
    {
        total = sub1 + sub2 + sub3;
    }

    public void CalcAvg()
    {
        average = total / 3.0;
    }

    public void CalcGrade()
    {
        if (average >= 80)
            grade = "A";
        else if (average >= 60)
            grade = "B";
        else if (average >= 40)
            grade = "C";
        else
            grade = "F";
    }

    public void PrintMarksheet()
    {
        Console.WriteLine($"Roll No: {rno}");
        Console.WriteLine($"Name: {name}");
        Console.WriteLine($"Subject 1: {sub1}");
        Console.WriteLine($"Subject 2: {sub2}");
        Console.WriteLine($"Subject 3: {sub3}");
        Console.WriteLine($"Total Marks: {total}");
        Console.WriteLine($"Average Marks: {average}");
        Console.WriteLine($"Grade: {grade}");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Student student = new Student();
        student.ReadData();
        student.CalcTotal();
        student.CalcAvg();
        student.CalcGrade();
        student.PrintMarksheet();
    }
}

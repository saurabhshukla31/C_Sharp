using System;

public class Student
{
    public event Action<int> GradeChanged;
    int grade;

    public int Grade
    {
        get{
            return grade;
        }
        set{
            grade = value;
            if(GradeChanged != null)
            {
                GradeChanged(grade);
            }
        }
    }
}
public class Program
{   
    
    public static void Main(string[] args)
    {
        Student s= new Student();
        s.GradeChanged += (val) => Console.WriteLine($"Grade changed to: {val}");
        bool Valid = int.TryParse(Console.ReadLine(),out int val);
        if(Valid)
        {
            s.Grade = val;
        }
        else
        {
            Console.WriteLine("Invalid grade.");
        }
    }
}

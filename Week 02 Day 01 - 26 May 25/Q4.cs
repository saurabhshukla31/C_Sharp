using System;
using System.Collections.Generic;
public class Student
{
    public int Id{get;set;}
    public string Name{get;set;}
    public string Grade{get;set;}

}

public class StudentManager
{
    public Dictionary<int,Student> Students{get;set;} = new Dictionary<int,Student>();
    public void AddStudent(Student student)
    {
        Students.Add(student.Id,student);
    }
    public void DisplayStudents()
    {
        Console.WriteLine("Student Information:");
        foreach(KeyValuePair<int,Student> s in Students)
        {
            Student obj=s.Value;
            Console.WriteLine($"ID: {obj.Id}, Name: {obj.Name}, Grade: {obj.Grade}");
        }
    }
}


public class Program
{
    public static void Main(string[] args)
    {
        
        StudentManager ob = new StudentManager();
        int numOfStu=int.Parse(Console.ReadLine());
        for(int i=0;i<numOfStu;i++)
        {
            int id=int.Parse(Console.ReadLine());
            string name = Console.ReadLine();
            string grade = Console.ReadLine();

            Student s = new Student();
            s.Id=id;
            s.Name=name;
            s.Grade = grade;

            ob.AddStudent(s);
        }

        ob.DisplayStudents();
    }
}

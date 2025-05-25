using System;

public sealed class Circle
{
    private double radius;

    public Circle(double radius)
    {
        this.radius = radius;
    }

    public double GetArea()
    {
        return 3.14 * radius * radius;
    }

    public double GetCircumference()
    {
        return 2 * 3.14 * radius;
    }
}

public static class MathUtilities
{
    public static int Square(int number)
    {
        return number * number;
    }

    public static int Cube(int number)
    {
        return number * number * number;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        int radius = int.Parse(Console.ReadLine());
        int number = int.Parse(Console.ReadLine());

        Circle circle = new Circle(radius);
        double area = circle.GetArea();
        double circumference = circle.GetCircumference();

        int square = MathUtilities.Square(number);
        int cube = MathUtilities.Cube(number);

        Console.WriteLine($"Area of Circle: {area}");
        Console.WriteLine($"Circumference of Circle: {circumference}");
        Console.WriteLine($"Square of {number}: {square}");
        Console.WriteLine($"Cube of {number}: {cube}");
    }
}

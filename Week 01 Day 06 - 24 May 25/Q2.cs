using System;

public class Shape
{
    public virtual double CalculateArea()
    {
        return 0;
    }
}

public class Rectangle : Shape
{
    public double len { get; set; }
    public double width { get; set; }

    public Rectangle() { }

    public Rectangle(double l, double w)
    {
        this.len = l;
        this.width = w;
    }

    public override double CalculateArea()
    {
        return (len * width);
    }
}

public class Circle : Shape
{
    public double rad { get; set; }

    public Circle() { }

    public Circle(double r)
    {
        this.rad = r;
    }

    public override double CalculateArea()
    {
        return (Math.PI * rad * rad);
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
            Shape[] s = new Shape[num];

            for (int i = 0; i < num; i++)
            {
                type = Console.ReadLine();
                switch (type.ToLower())
                {
                    case "rectangle":
                        Rectangle r = new Rectangle();
                        t[i] = "Rectangle";
                        try
                        {
                            r.len = double.Parse(Console.ReadLine());
                            r.width = double.Parse(Console.ReadLine());
                            s[i] = r;
                        }
                        catch
                        {
                            Console.WriteLine("Invalid input for length or width. Please enter a numeric value.");
                        }
                        break;

                    case "circle":
                        Circle c = new Circle();
                        t[i] = "Circle";
                        try
                        {
                            c.rad = double.Parse(Console.ReadLine());
                            if (double.IsNaN(c.rad))
                            {
                                Console.WriteLine("Invalid input for radius. Please enter numeric values.");
                                break;
                            }
                            else
                            {
                                s[i] = c;
                                break;
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Invalid input for radius. Please enter numeric values.");
                            break;
                        }

                    default:
                        Console.WriteLine("Unknown shape type. Please enter a rectangle or circle.");
                        break;
                }
            }

            Console.WriteLine("Areas of the shapes:");
            for (int i = 0; i < num; i++)
            {
                if (string.IsNullOrEmpty(t[i])) { return; }

                if (t[i] == "Rectangle")
                    Console.WriteLine($"Area of Shape {i + 1} ({t[i]}): {s[i].CalculateArea()}");
                else
                    Console.WriteLine($"Area of Shape {i + 1} ({t[i]}): {s[i].CalculateArea():F2}");
            }
        }
    }
}

using System;
using System.Net;

public abstract class Shape
    {
        public abstract double Perimeter();
    }

    public class Rectangle : Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public override double Perimeter()
        {
            return 2 * (Width + Height);
        }
    }

    public class Circle : Shape
    {
        public double Radius { get; set; }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public override double Perimeter()
        {
            return 2 * Math.PI * Radius;
        }
    }

    public class PerimeterCalculator
    {
        public double CalculateTotalPerimeter(List<Shape> shapes)
        {
            double totalPerimeter = 0;
            foreach (Shape shape in shapes)
            {
                totalPerimeter += shape.Perimeter();
            }
            return totalPerimeter;
        }
    }

    public class Program
    {
       public  static void Main(string[] args)
        {
            List<Shape> shapes = new List<Shape>();
            bool addMoreShapes = true;
            bool invalidShapeEntered = false;

            while (addMoreShapes)
            {
                string shapeType = Console.ReadLine().ToUpper();

                if (shapeType == "R")
                {
                    double width = double.Parse(Console.ReadLine());
                    double height = double.Parse(Console.ReadLine());

                    shapes.Add(new Rectangle(width, height));
                }
                else if (shapeType == "C")
                {
                    double radius = double.Parse(Console.ReadLine());

                    shapes.Add(new Circle(radius));
                }
                else
                {
                  //  Console.WriteLine("Invalid shape. Please try again.");
                    invalidShapeEntered = true;
                    break;
                }
                string continueChoice = Console.ReadLine().ToUpper();
                if (continueChoice != "Y")
                {
                    addMoreShapes = false;
                }
            }

            PerimeterCalculator calculator = new PerimeterCalculator();
            double totalPerimeter = calculator.CalculateTotalPerimeter(shapes);

            if (invalidShapeEntered)
            {
                Console.WriteLine("Invalid shape. Please try again.");
            }
            
            Console.WriteLine($"Total perimeter of all shapes: {totalPerimeter:F2}");
        }
    }

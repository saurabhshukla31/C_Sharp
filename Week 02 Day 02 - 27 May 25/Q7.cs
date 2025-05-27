using System;
  public delegate double ArithmeticOperation(double a, double b);



    public class Program
    {
        // Delegate Definition
      

        // Arithmetic Methods
        public static double Add(double a, double b)
        {
            return a + b;
        }

        public static double Subtract(double a, double b)
        {
            return a - b;
        }

        public static double Multiply(double a, double b)
        {
            return a * b;
        }

        public static double Divide(double a, double b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException("Division by zero is not allowed.");
            }
            return a / b;
        }

        // PerformOperation Method
        public static double PerformOperation(ArithmeticOperation operation, double a, double b)
        {
            return operation(a, b);
        }

        public static void Main(string[] args)
        {
            try
            {
                // Get first number
                //Console.WriteLine("Enter the first number:");
                double num1 = Convert.ToDouble(Console.ReadLine());

                // Get second number
               // Console.WriteLine("Enter the second number:");
                double num2 = Convert.ToDouble(Console.ReadLine());

                // Get operation
                //Console.WriteLine("Enter the operation (add, subtract, multiply, divide):");
                string inputOperation = Console.ReadLine().ToLower();

                // Select delegate based on user input
                ArithmeticOperation operation;

                switch (inputOperation)
                {
                    case "add":
                        operation = Add;
                        break;
                    case "subtract":
                        operation = Subtract;
                        break;
                    case "multiply":
                        operation = Multiply;
                        break;
                    case "divide":
                        operation = Divide;
                        break;
                    default:
                        Console.WriteLine("Invalid operation");
                        return;
                }

                // Perform operation
                double result = PerformOperation(operation, num1, num2);
                Console.WriteLine($"The result is: {result:F2}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter valid numbers.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
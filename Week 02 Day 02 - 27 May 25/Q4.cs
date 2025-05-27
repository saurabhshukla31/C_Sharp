using System;
using System.Diagnostics.Contracts;

public class Program
{
    public static void Main(string[] args)
    {
        try 
        {
            double price = double.Parse(Console.ReadLine());
            if(price<=0)
            {
                throw new InvalidPriceException("Price must be greater than zero.");
            }

            int quantity = int.Parse(Console.ReadLine());
            if(quantity < 0)
            {
                throw new InvalidQuantityException("Quantity must be greater than zero.");
            }
            double Total = price* quantity;
            Console.WriteLine($"Total cost is {Total}");
        }
        catch(InvalidPriceException e1)
        {
            Console.WriteLine($"Error: {e1.Message}");
        }
        catch(InvalidQuantityException e2)
        {
            Console.WriteLine($"Error: {e2.Message}");
        }
        catch(FormatException e3)
        {
            Console.WriteLine("Error: Please enter a valid number.");
        }
    }
}


public class InvalidPriceException : Exception
{
    public InvalidPriceException(string msg):base(msg)
    {

    }
}

public class InvalidQuantityException : Exception
{
    public InvalidQuantityException(string msg) : base(msg)
    {

    }
}
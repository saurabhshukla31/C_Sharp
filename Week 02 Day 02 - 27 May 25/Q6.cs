using System;
using Microsoft.Win32.SafeHandles;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string ticketinput = Console.ReadLine();
            int numberofTickets = int.Parse(ticketinput);

            if(numberofTickets <= 0)
            {
                throw new ArgumentException("Number of tickets must be greater than 0.");
            }
            string priceInput = Console.ReadLine();
            decimal pricePerTicket = decimal.Parse(priceInput);

            if(pricePerTicket <= 0)
            {
                throw new ArgumentException("Price per ticket must be greater than 0.");
            }

            decimal totalCost = numberofTickets * pricePerTicket;
            Console.WriteLine($"Total ticket cost: {totalCost}");
        }
        catch(ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        catch(FormatException)
        {
            Console.WriteLine("Error: Please enter a valid number.");
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Error: An unexpected error occured. {ex.Message}");
        }
    }
}

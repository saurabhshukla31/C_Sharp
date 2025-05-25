using System;

public abstract class Ticket
{
    public int TicketId { get; set; }
    public string TicketType { get; set; }
    public abstract (double, string) CalculatePrice();
}

public class ChildTicket : Ticket
{
    public override (double, string) CalculatePrice()
    {
        return (20, "Free ice cream included");
    }
}

public class AdultTicket : Ticket
{
    public override (double, string) CalculatePrice()
    {
        return (50, "Free park map included");
    }
}

public class SeniorTicket : Ticket
{
    public override (double, string) CalculatePrice()
    {
        return (30, "Free wheelchair service included");
    }
}

public class TicketManager
{
    public void PrintTicketPrice(Ticket ticket)
    {
        var (price, service) = ticket.CalculatePrice();
        Console.WriteLine($"Price: {price}, Included Service: {service}");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        double totalCost = 0;
        TicketManager manager = new TicketManager();

        for (int i = 0; i < n; i++)
        {
            string type = Console.ReadLine();
            Ticket ticket = null;

            switch (type)
            {
                case "Child":
                    ticket = new ChildTicket();
                    break;
                case "Adult":
                    ticket = new AdultTicket();
                    break;
                case "Senior":
                    ticket = new SeniorTicket();
                    break;
                default:
                    Console.WriteLine("Invalid ticket type");
                    continue;
            }

            manager.PrintTicketPrice(ticket);
            totalCost += ticket.CalculatePrice().Item1;
        }

        Console.WriteLine($"Total cost: {totalCost}");
    }
}

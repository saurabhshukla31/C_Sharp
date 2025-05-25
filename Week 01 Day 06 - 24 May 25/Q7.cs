using System;
using System.Diagnostics;

public abstract class Laptop
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public double Price { get; set; }
    public string Processor { get; set; }
    public int RAM { get; set; }
    public int Storage { get; set; }

    public abstract void DisplayDetails();
    public abstract void ApplyDiscount(double percentage);
}

public class GamingLaptop : Laptop
{
    public GamingLaptop(string brand, string model, double price, string processor, int ram, int storage)
    {
        Brand = brand;
        Model = model;
        Price = price;
        Processor = processor;
        RAM = ram;
        Storage = storage;
    }
    public override void DisplayDetails()
    {
        Console.WriteLine($"Laptop Details: Brand - {Brand}, Model - {Model}, Price: ${Price}, Processor: {Processor}, RAM: {RAM} GB, Storage: {Storage} GB");
        Console.WriteLine("Type: Gaming");
    }

    public override void ApplyDiscount(double percentage)
    {
        Price = Price - (Price * percentage / 100);
    }
}

public class BusinessLaptop : Laptop
{
    public BusinessLaptop(string brand, string model, double price, string processor, int ram, int storage)
    {
        Brand = brand;
        Model = model;
        Price = price;
        Processor = processor;
        RAM = ram;
        Storage = storage;
    }
    public override void DisplayDetails()
    {
        Console.WriteLine($"Laptop Details: Brand - {Brand}, Model - {Model}, Price: ${Price}, Processor: {Processor}, RAM: {RAM} GB, Storage: {Storage} GB");
        Console.WriteLine("Type: Business");
    }

    public override void ApplyDiscount(double percentage)
    {
        Price = Price - (Price * percentage / 100);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        string brand = Console.ReadLine();
        string model = Console.ReadLine();
        double price = double.Parse(Console.ReadLine());
        string processor = Console.ReadLine();
        int ram = int.Parse(Console.ReadLine());
        int storage = int.Parse(Console.ReadLine());
        string laptopType = Console.ReadLine();

        Laptop laptop;
        
        if (laptopType == "Gaming")
        {
            laptop = new GamingLaptop(brand, model, price, processor, ram, storage);
            string discountInput = Console.ReadLine();
            double discount = double.Parse(discountInput);
            laptop.ApplyDiscount(discount);
            laptop.DisplayDetails();
        }
        else
        {
            laptop = new BusinessLaptop(brand, model, price, processor, ram, storage);
            laptop.Brand = brand;
            laptop.Model = model;
            laptop.Price = price;
            laptop.Processor = processor;
            laptop.RAM = ram;
            laptop.Storage = storage;
            string discountInput = Console.ReadLine();
            double discount = double.Parse(discountInput);
            laptop.ApplyDiscount(discount);
            laptop.DisplayDetails();
        }
    }   
}

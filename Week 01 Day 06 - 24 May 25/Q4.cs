using System.Collections.Generic;

public abstract class Property
{
    public int PropertyId { get; set; }
    public string Location { get; set; }
    public double Area { get; set; }
    protected string PropertyType { get; set; }

    public abstract double CalculatePropertyTax();
    
    public string GetPropertyType()
    {
        return PropertyType;
    }
}

public class Apartment : Property
{
    public Apartment()
    {
        PropertyType = "Apartment";
    }

    public override double CalculatePropertyTax()
    {
        return Math.Round(Area * 0.01, 2);
    }
}

public class House : Property
{
    public House()
    {
        PropertyType = "House";
    }

    public override double CalculatePropertyTax()
    {
        return Math.Round(Area * 0.02, 2);
    }
}

public class CommercialBuilding : Property
{
    public CommercialBuilding()
    {
        PropertyType = "CommercialBuilding";
    }

    public override double CalculatePropertyTax()
    {
        return Math.Round(Area * 0.03, 2);
    }
}

public class PropertyManager
{
    public void PrintPropertyTax(Property property)
    {
        Console.WriteLine($"Property Tax for {property.GetPropertyType()} (ID: {property.PropertyId}, Location: {property.Location}, Area: {property.Area}): {property.CalculatePropertyTax():F2}");
    }
}

public class Program
{
   public static void Main(string[] args)
    {
        int numberOfProperties = int.Parse(Console.ReadLine());
        List<Property> properties = new List<Property>();
        PropertyManager manager = new PropertyManager();

        for (int i = 0; i < numberOfProperties; i++)
        {
            int propertyId = int.Parse(Console.ReadLine());
            string location = Console.ReadLine();
            double area = double.Parse(Console.ReadLine());
            string propertyType = Console.ReadLine();

            Property property = CreateProperty(propertyType);
            
            if (property != null)
            {
                property.PropertyId = propertyId;
                property.Location = location;
                property.Area = area;
                properties.Add(property);
            }
            else
            {
                Console.WriteLine("Invalid property type.");
                continue;
            }
        }

        foreach (Property property in properties)
        {
            manager.PrintPropertyTax(property);
        }
    }

    static Property CreateProperty(string propertyType)
    {
        switch (propertyType)
        {
            case "Apartment":
                return new Apartment();
            case "House":
                return new House();
            case "CommercialBuilding":
                return new CommercialBuilding();
            default:
                return null;
        }
    }
}

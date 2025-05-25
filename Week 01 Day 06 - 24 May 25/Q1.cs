using System;
public class Animal{
    public virtual void MakeSound()
    {
        Console.WriteLine("Some generic animal sound");
    }
}

public class Dog : Animal{
    public override void MakeSound()
    {
        Console.WriteLine("Bark");
    }
}

public class Cat : Animal{
    public override void MakeSound()
    {
        Console.WriteLine("Meow");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        int noOfAnimals = int.Parse(Console.ReadLine());
        Animal [] animal_arr = new Animal[noOfAnimals];
        if(noOfAnimals<=0)
        {
            Console.WriteLine("Please enter a valid positive integer.");
        }
        else
        {
            for (int i = 0; i < noOfAnimals; i++)
            {
                string strA = Console.ReadLine();
                if(strA == "dog")
                {
                    animal_arr[i] = new Dog();
                }
                else if(strA == "cat")
                {
                    animal_arr[i] = new Cat();
                }
                else if(strA == "animal")
                {
                    animal_arr[i] = new Animal();
                }
            }
            if(animal_arr.Length > 0)
            {
                Console.WriteLine("Sounds of the animals in the array:");
                for (int j = 0; j < noOfAnimals; j++)
                {
                    animal_arr[j].MakeSound();
                }
            }
        }
    }
}

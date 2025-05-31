 using System;

 public sealed class UserSingleton {

   private static UserSingleton instance = null;

   private static readonly object lockObject = new object();

   private int accessCount = 0;

   private UserSingleton() {}

   public static UserSingleton Instance {

     get {

       if (instance == null) {

         instance = new UserSingleton();

       }

       return instance;

     }

   }

   public int GetAccessCounter() {

     return accessCount;

   }

   public void IncrementAccessCounter() {

     accessCount++;

   }

   public void DisplayGreeting(string username) {

     Console.WriteLine($"Welcome, {username}!");

   }

 }

 public class Program

 {

   public static void Main(string[] args)

   {

     UserSingleton user = UserSingleton.Instance;

     string usern = Console.ReadLine();

     user.IncrementAccessCounter();

     user.IncrementAccessCounter();

     Console.WriteLine("Access Counter: " + user.GetAccessCounter());

     user.DisplayGreeting(usern);

   }

 }

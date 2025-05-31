using System;

using System.Collections;

using System.Collections.Generic;

public sealed class Logger {

  private static Logger instance = null;

  private static readonly object lockObject = new object();

  private List < string > logMessages = new List < string > ();

  private Logger() {}

  public static Logger Instance {

    get {

      lock(lockObject) {

        if (instance == null) {

          instance = new Logger();

        }

        return instance;

      }

    }

  }

  public void LogMessage(string message) {

    logMessages.Add(message);

    Console.WriteLine("Logging message: " + message);

  }

  public void DisplayLogMessages() {

    Console.WriteLine("Log Messages:");

    foreach(string str in logMessages) {

      Console.WriteLine(str);

    }

  }

}

public class Program

{

  public static void Main(string[] args)

  {

    Logger log = Logger.Instance;

    int num = int.Parse(Console.ReadLine());

    for (int i = 0; i < num; i++) {

      string text = Console.ReadLine();

      log.LogMessage(text);

    }

    log.DisplayLogMessages();

  }

}

using System;

public sealed class Logger {

  private static Logger instance = null;

  private static readonly object lockObject = new object();

  private int logCount = 0;

  public static Logger Instance {

    get {

      if (instance == null) {

        instance = new Logger();

      }

      return instance;

    }

  }

  public void Log(string message) {

    logCount++;

    Console.WriteLine($"[Log {logCount}]: {message}");

  }

  public int GetLogCount() {

    return logCount;

  }

}

public class Program

{

  public static void Main(string[] args)

  {

    Logger logger = Logger.Instance;

    while (true) {

      string txt = Console.ReadLine();

      if (txt.ToLower() == "exit") {

        break;

      }

      logger.Log(txt);

      Console.WriteLine("Log count: " + logger.GetLogCount());

    }

  }

}

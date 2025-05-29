using System;


    public interface  IPrintable
    {
        void Print();
    }

    public interface IScannable
    {
        void Scan();
    }

    public interface IFaxable
    {
       public void Fax();
    }

    public class MultiFunctionalPrinter : IPrintable, IScannable, IFaxable
    {
        public void Print()
        {
            Console.WriteLine("Printing document...");
        }

        public void Scan()
        {
            Console.WriteLine("Scanning document...");
        }

        public void Fax()
        {
            Console.WriteLine("Faxing document...");
        }
    }

    public class BasicPrinter : IPrintable
    {
        public void Print()
        {
            Console.WriteLine("Printing document...");
        }
    }

    public class BasicScanner : IScannable
    {
        public void Scan()
        {
            Console.WriteLine("Scanning document...");
        }
    }

    public class Program
    {
       public static void Main(string[] args)
        {
            //Console.WriteLine("Enter the type of device you want to use (M for multi-functional printer, B for basic printer, S for basic scanner): ");
            string input = Console.ReadLine().ToUpper();

            switch (input)
            {
                case "M":
                    MultiFunctionalPrinter multiFunctionalPrinter = new MultiFunctionalPrinter();
                    multiFunctionalPrinter.Print();
                    multiFunctionalPrinter.Scan();
                    multiFunctionalPrinter.Fax();
                    break;
                case "B":
                    BasicPrinter basicPrinter = new BasicPrinter();
                    basicPrinter.Print();
                    break;
                case "S":
                    BasicScanner basicScanner = new BasicScanner();
                    basicScanner.Scan();
                    break;
                default:
                    Console.WriteLine("Invalid device type. Please try again.");
                    break;
            }
        }
    }


using System;
using System.Threading;

namespace LoggingKata
{
    public class TacoLogger : ILog
    {
        public void LogFatal(string log, Exception exception = null)
        {
            Console.WriteLine($"Fatal: {log}, Exception {exception}");
        }

        public void LogError(string log, Exception exception = null)
        {
            Console.WriteLine($"Error: {log}, Exception {exception}");
        }

        public void LogWarning(string log)
        {
            Console.WriteLine($"Warning: {log}");
        }

        public void LogInfo(string log)
        {
            Console.WriteLine($"Info: {log}");
        }

        public void LogDebug(string log)
        {
            Console.WriteLine($"Debug: {log}");
        }
        
        public static bool LogStartApp()
        {
            Console.Write("Would you like to run the Taco Bell Parser? (y/n): ");
            var toStart = Console.ReadLine();
            Console.Clear();
            while (toStart.ToLower() != "y" && toStart.ToLower() != "n")
            {
                Console.WriteLine("Please enter a valid answer (y/n)");
                Console.Write("Would you like to run the Taco Bell Parser? (y/n): ");
                toStart = Console.ReadLine().ToLower();
                Console.Clear();
            }

            if (toStart == "y") { return true; }
            else
            {
                Console.WriteLine("Exiting App...");
                Thread.Sleep(2000);
                return false;
            }
        }
    }
}

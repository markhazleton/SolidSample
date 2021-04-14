using System;

namespace ArdalisRating.Logger
{
    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message ?? string.Empty);
        }
    }
}

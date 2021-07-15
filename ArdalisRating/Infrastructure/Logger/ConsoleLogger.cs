using ArdalisRating.Core.Interfaces;
using System;
using System.Collections.Generic;

namespace ArdalisRating.Infrastructure.Logger
{
    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message ?? string.Empty);
        }

        public void LogList(List<string> list)
        {
            foreach (var message in list)
            {
                Console.WriteLine(message ?? string.Empty);
            }
        }
    }
}
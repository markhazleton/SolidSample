using ArdalisRating.Core.Interfaces;
using System;
using System.IO;

namespace ArdalisRating.Infrastructure.Logger
{
    public class FileLogger : ILogger
    {
        public void Log(string message)
        {
            using (var stream = File.AppendText("log.txt"))
            {
                stream.WriteLine(message);
                stream.Flush();
            }
        }
    }
}

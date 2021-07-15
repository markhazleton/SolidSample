using ArdalisRating.Core.Interfaces;
using System.Collections.Generic;
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

        public void LogList(List<string> list)
        {
            foreach (var message in list)
            {
                using (var stream = File.AppendText("log.txt"))
                {
                    stream.WriteLine(message);
                    stream.Flush();
                }
            }
        }
    }
}
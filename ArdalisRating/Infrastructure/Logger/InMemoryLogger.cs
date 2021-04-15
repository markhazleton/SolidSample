using ArdalisRating.Core.Interfaces;
using System.Collections.Generic;

namespace ArdalisRating.Infrastructure.Logger
{
    /// <summary>
    /// In Memory Logger
    /// </summary>
    public class InMemoryLogger : ILogger,IBatchLogger
    {
        private List<string> logList = new List<string>();
        public void Log(string message)
        {
            logList.Add(message);
        }

        public void LogList(List<string> list)
        {
            logList.AddRange(list);
        }

        public List<string> LogList()
        {
            return logList;
        }

        /// <summary>
        /// Reset Log
        /// </summary>
        public void ResetLog()
        {
            logList.Clear();
        }
    }
}

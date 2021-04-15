using ArdalisRating.Core.Interfaces;
using System;
using System.Collections.Generic;

namespace ArdalisRating.Infrastructure.Logger
{
    /// <summary>
    /// Null Logger
    /// </summary>
    public class NullLogger : ILogger
    {
        public void Log(string message)
        {
        }

        public void LogList(List<string> list)
        {
        }
    }
}

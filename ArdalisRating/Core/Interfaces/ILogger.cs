using System;
using System.Collections.Generic;

namespace ArdalisRating.Core.Interfaces
{
    public interface ILogger
    {
        void Log(string message);
        void LogList(List<string> list);
    }
}

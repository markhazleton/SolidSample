using System;
using System.Collections.Generic;

namespace ArdalisRating.Core.Interfaces
{
    public interface IBatchLogger : ILogger
    {
        List<string> LogList();
        void ResetLog();
    }
}

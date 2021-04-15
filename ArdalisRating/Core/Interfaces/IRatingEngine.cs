using System;

namespace ArdalisRating.Core.Interfaces
{
    public interface IRatingEngine
    {
        string GetLogMessage();
        void Rate(IPolicyModel policy);

        decimal Rating { get; set; }
    }
}

using System;

namespace ArdalisRating.Core.Interfaces
{
    public interface IPolicySource
    {
        string GetPolicyFromSource(string policyjson);
    }
}

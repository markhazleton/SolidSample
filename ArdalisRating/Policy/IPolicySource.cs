using System;

namespace ArdalisRating.Policy
{
    public interface IPolicySource
    {
        string GetPolicyFromSource(string policyjson);
    }
}

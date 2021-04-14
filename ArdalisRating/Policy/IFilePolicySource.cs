using System;

namespace ArdalisRating.Policy
{
    public interface IFilePolicySource
    {
        string GetPolicyFromSource(string policyjson);
    }
}

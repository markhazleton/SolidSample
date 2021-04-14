using System;
using System.IO;

namespace ArdalisRating.Policy
{
    public class FilePolicySource : IPolicySource
    {
        public string GetPolicyFromSource(string policyjson)
        {
            return File.ReadAllText(policyjson);
        }
    }
}

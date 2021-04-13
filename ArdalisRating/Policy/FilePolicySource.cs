using System;
using System.IO;

namespace ArdalisRating.Policy
{
    public class FilePolicySource : IFilePolicySource
    {
        public string GetPolicyFromSource()
        {
            return File.ReadAllText("policy.json");
        }
    }
}

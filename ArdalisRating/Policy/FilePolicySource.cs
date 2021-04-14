using System;
using System.IO;

namespace ArdalisRating.Policy
{
    public class FilePolicySource : IFilePolicySource
    {
        public string GetPolicyFromSource(string policyjson)
        {
            return File.ReadAllText(policyjson);
        }
    }
}

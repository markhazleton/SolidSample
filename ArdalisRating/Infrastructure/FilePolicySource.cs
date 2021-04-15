using ArdalisRating.Core.Interfaces;
using System;
using System.IO;

namespace ArdalisRating.Infrastructure
{
    public class FilePolicySource : IPolicySource
    {
        public string GetPolicyFromSource(string policyjson)
        {
            return File.ReadAllText(policyjson);
        }
    }
}

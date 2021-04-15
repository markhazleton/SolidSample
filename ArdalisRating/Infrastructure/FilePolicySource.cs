using ArdalisRating.Core.Interfaces;
using System;
using System.IO;

namespace ArdalisRating.Infrastructure
{
    public class FilePolicySource : IPolicySource
    {
        /// <summary>
        /// Constructor 
        /// </summary>
        public FilePolicySource(string fileName)
        {
            PolicySource = fileName;
        }
        /// <summary>
        /// 
        /// </summary>
        public string PolicySource { get; set; }
        public string GetPolicyFromSource()
        {
            return File.ReadAllText(PolicySource);
        }
    }
}

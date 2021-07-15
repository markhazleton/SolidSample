using ArdalisRating.Core.Interfaces;

namespace ArdalisRating.Infrastructure
{
    public class StringPolicySource : IPolicySource
    {
        public string PolicySource { get; set; }

        public string GetPolicyFromSource()
        {
            return PolicySource;
        }
    }
}
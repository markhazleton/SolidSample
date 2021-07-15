using ArdalisRating.Core.Interfaces;
using System;

namespace ArdalisRating.Core.Raters.PolicyType
{
    public class AutoPolicyRater : Rater
    {
        public AutoPolicyRater(IBatchLogger logger)
            : base(logger)
        {
        }

        public override decimal Rate(IPolicyModel policy)
        {
            _InMemory.Log("Rating AUTO policy...");
            _InMemory.Log("Validating policy.");
            if (String.IsNullOrEmpty(policy.Make))
            {
                _InMemory.Log("Auto policy must specify Make");
                return 0;
            }
            if (string.Compare(policy.Make, "BMW", StringComparison.Ordinal) == 0)
            {
                if (policy.Deductible < 500)
                {
                    return 1000m;
                }
                return 900m;
            }
            _InMemory.Log("Unable to rate policy");
            return 0;
        }
    }
}
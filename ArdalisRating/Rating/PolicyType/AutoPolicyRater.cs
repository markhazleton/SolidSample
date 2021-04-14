using ArdalisRating.Logger;
using System;

namespace ArdalisRating.Rating.PolicyType
{
    public class AutoPolicyRater : Rater
    {
        public AutoPolicyRater(ILogger logger)
            : base(logger)
        {
        }

        public override decimal Rate(Policy.PolicyModel policy)
        {
            _logger.Log("Rating AUTO policy...");
            _logger.Log("Validating policy.");
            if (String.IsNullOrEmpty(policy.Make))
            {
                _logger.Log("Auto policy must specify Make");
            }
            if (string.Compare(policy.Make, "BMW", StringComparison.Ordinal) == 0)
            {
                if (policy.Deductible < 500)
                {
                    return 1000m;
                }
                return 900m;
            }
            return 0;
        }
    }
}

using ArdalisRating.Logger;
using ArdalisRating.Policy;

namespace ArdalisRating.Rating.PolicyType
{
    public class LandPolicyRater : Rater
    {
        public LandPolicyRater(ILogger logger) : base(logger)
        {
        }

        public override decimal Rate(PolicyModel policy)
        {
            _logger.Log("Rating LAND policy...");
            _logger.Log("Validating policy.");
            if (policy.BondAmount == 0 || policy.Valuation == 0)
            {
                _logger.Log("Land policy must specify Bond Amount and Valuation.");
                return 0;
            }
            if (policy.BondAmount < 0.8m * policy.Valuation)
            {
                _logger.Log("Insufficient bond amount.");
                return 0;
            }
            return policy.BondAmount * 0.05m;
        }
    }
}

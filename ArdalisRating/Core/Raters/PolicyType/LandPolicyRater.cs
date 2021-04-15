using ArdalisRating.Core.Interfaces;

namespace ArdalisRating.Core.Raters.PolicyType
{
    public class LandPolicyRater : Rater
    {
        public LandPolicyRater(IBatchLogger logger) : base(logger)
        {
        }

        public override decimal Rate(IPolicyModel policy)
        {
            _InMemory.Log("Rating LAND policy...");
            _InMemory.Log("Validating policy.");
            if (policy.BondAmount == 0 || policy.Valuation == 0)
            {
                _InMemory.Log("Land policy must specify Bond Amount and Valuation.");
                return 0;
            }
            if (policy.BondAmount < 0.8m * policy.Valuation)
            {
                _InMemory.Log("Insufficient bond amount.");
                return 0;
            }
            return policy.BondAmount * 0.05m;
        }
    }
}

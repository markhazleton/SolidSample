using ArdalisRating.Core.Interfaces;

namespace ArdalisRating.Core.Raters.PolicyType
{
    internal class FloodPolicyRater : Rater
    {
        public FloodPolicyRater(IBatchLogger logger) : base(logger)
        {
        }

        public override decimal Rate(IPolicyModel policy)
        {
            _InMemory.Log("Rating FLOOD policy...");
            _InMemory.Log("Validating policy.");
            if (policy.BondAmount == 0 || policy.Valuation == 0)
            {
                _InMemory.Log("Flood policy must specify Bond Amount and Valuation.");
                return 0;
            }
            if (policy.ElevationAboveSeaLevelFeet <= 0)
            {
                _InMemory.Log("Flood policy is not available for elevations at or below sea level.");
                return 0;
            }
            if (policy.BondAmount < 0.8m * policy.Valuation)
            {
                _InMemory.Log("Insufficient bond amount.");
                return 0;
            }
            decimal multiple = 1.0m;
            if (policy.ElevationAboveSeaLevelFeet < 100)
            {
                multiple = 2.0m;
            }
            else if (policy.ElevationAboveSeaLevelFeet < 500)
            {
                multiple = 1.5m;
            }
            else if (policy.ElevationAboveSeaLevelFeet < 1000)
            {
                multiple = 1.1m;
            }
            return policy.BondAmount * 0.05m * multiple;
        }
    }
}
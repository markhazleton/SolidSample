using ArdalisRating.Logger;
using System;

namespace ArdalisRating.Rating.PolicyType
{
    public class AutoPolicyRater : Rater
    {
        public AutoPolicyRater(IRatingUpdater ratingUpdater)
            : base(ratingUpdater)
        {
        }

        public override void Rate(Policy.PolicyModel policy)
        {
            Logger.Log("Rating AUTO policy...");
            Logger.Log("Validating policy.");
            if (String.IsNullOrEmpty(policy.Make))
            {
                Logger.Log("Auto policy must specify Make");
                return;
            }
            if (policy.Make == "BMW")
            {
                if (policy.Deductible < 500)
                {
                    _ratingUpdater.UpdateRating(1000m);
                    return;
                }
                _ratingUpdater.UpdateRating(900m);
            }
        }
    }
}

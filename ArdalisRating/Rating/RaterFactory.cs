using ArdalisRating.Logger;
using ArdalisRating.Policy;
using ArdalisRating.Rating.PolicyType;
using System;

namespace ArdalisRating.Rating
{
    public class RaterFactory
    {
        public Rater Create(PolicyModel policy, IPolicyRatingContext context, ILogger logger)
        {
            try
            {
                return (Rater)Activator.CreateInstance(
                    Type.GetType($"ArdalisRating.Rating.PolicyType.{policy.Type}PolicyRater"),
                        new object[] { logger });
            }
            catch
            {
                return new UnknownPolicyRater(logger);
            }
        }
    }
}

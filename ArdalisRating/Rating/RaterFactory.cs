using ArdalisRating.Policy;
using ArdalisRating.Rating.PolicyType;
using System;

namespace ArdalisRating.Rating
{
    public class RaterFactory
    {
        public Rater Create(PolicyModel policy, IPolicyRatingContext context)
        {
            try
            {
                return (Rater)Activator.CreateInstance(
                    Type.GetType($"ArdalisRating.Rating.PolicyType.{policy.Type}PolicyRater"),
                        new object[] { new RatingUpdater(context.Engine) });
            }
            catch
            {
                return new UnknownPolicyRater(new RatingUpdater(context.Engine));
            }
        }
    }
}

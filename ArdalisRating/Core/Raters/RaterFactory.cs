using ArdalisRating.Core.Interfaces;
using ArdalisRating.Core.Models;
using ArdalisRating.Core.Raters.PolicyType;
using System;

namespace ArdalisRating.Core.Raters
{
    public class RaterFactory
    {
        public Rater Create(PolicyModel policy, ILogger logger)
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

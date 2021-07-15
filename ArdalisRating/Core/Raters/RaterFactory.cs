using ArdalisRating.Core.Interfaces;
using ArdalisRating.Core.Raters.PolicyType;
using System;

namespace ArdalisRating.Core.Raters
{
    /// <summary>
    /// Rater Factory
    /// </summary>
    public class RaterFactory : IRaterFactory
    {
        public RaterFactory()
        {
        }

        public Rater Create(IPolicyModel policy, IBatchLogger logger)
        {
            try
            {
                return (Rater)Activator.CreateInstance(
                    Type.GetType($"ArdalisRating.Core.Raters.PolicyType.{policy.Type}PolicyRater"),
                        new object[] { logger });
            }
            catch
            {
                return new UnknownPolicyRater(logger);
            }
        }
    }
}
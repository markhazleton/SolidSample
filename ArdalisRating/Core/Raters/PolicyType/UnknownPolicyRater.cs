using ArdalisRating.Core.Interfaces;
using ArdalisRating.Core.Models;

namespace ArdalisRating.Core.Raters.PolicyType
{
    internal class UnknownPolicyRater : Rater
    {
        public UnknownPolicyRater(ILogger logger)
            : base(logger)
        {
        }
        public override decimal Rate(PolicyModel policy)
        {
            _logger.Log("Unknown policy type");
            return 0;
        }

    }
}
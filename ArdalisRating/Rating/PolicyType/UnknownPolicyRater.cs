using ArdalisRating.Logger;
using ArdalisRating.Policy;

namespace ArdalisRating.Rating.PolicyType
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
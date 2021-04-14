using ArdalisRating.Logger;
using ArdalisRating.Policy;

namespace ArdalisRating
{
    internal class UnknownPolicyRater : Rater
    {
        public UnknownPolicyRater(RatingEngine engine, IConsoleLogger logger) : base(engine, logger)
        {
        }

        public override void Rate(PolicyModel policy)
        {
            _logger.Log("Unknown policy type");
        }
    }
}
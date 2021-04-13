using ArdalisRating.Logger;
using ArdalisRating.Policy;

namespace ArdalisRating
{
    internal class FloodPolicyRater : Rater
    {
        public FloodPolicyRater(RatingEngine engine, ConsoleLogger logger) : base(engine, logger)
        {
        }

        public override void Rate(PolicyModel policy)
        {
            throw new System.NotImplementedException();
        }
    }
}
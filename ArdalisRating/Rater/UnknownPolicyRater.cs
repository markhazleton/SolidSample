using ArdalisRating.Logger;
using ArdalisRating.Policy;

namespace ArdalisRating
{
    internal class UnknownPolicyRater : Rater
    {
        public UnknownPolicyRater(RatingEngine engine, ConsoleLogger logger) : base(engine, logger)
        {
        }

        public override void Rate(PolicyModel policy)
        {
            throw new System.NotImplementedException();
        }
    }
}
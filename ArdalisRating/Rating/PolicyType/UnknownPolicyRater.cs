using ArdalisRating.Policy;

namespace ArdalisRating.Rating.PolicyType
{
    internal class UnknownPolicyRater : Rater
    {
        public UnknownPolicyRater(IRatingUpdater ratingUpdater)
            : base(ratingUpdater)
        {
        }
        public override void Rate(PolicyModel policy)
        {
            Logger.Log("Unknown policy type");
        }
    }
}
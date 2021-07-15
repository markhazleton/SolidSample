using ArdalisRating.Core.Interfaces;

namespace ArdalisRating.Core.Raters.PolicyType
{
    internal class UnknownPolicyRater : Rater
    {
        public UnknownPolicyRater(IBatchLogger logger)
            : base(logger)
        {
        }

        public override decimal Rate(IPolicyModel policy)
        {
            _InMemory.Log("Unknown policy type");
            return 0;
        }
    }
}
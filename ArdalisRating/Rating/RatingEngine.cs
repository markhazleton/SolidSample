using ArdalisRating.Logger;
using ArdalisRating.Policy;
using System;

namespace ArdalisRating.Rating
{
    /// <summary>
    /// The RatingEngine reads the policy application details from a file and produces a numeric 
    /// rating value based on the details.
    /// </summary>
    public class RatingEngine
    {
        public IPolicyRatingContext Context;
        public PolicyModel _policy;
        public decimal Rating { get; set; }

        public RatingEngine(PolicyModel policy,IPolicyRatingContext context)
        {
            _policy = policy;
            Context = context;
            Context.Engine = this;
        }

        public void Rate()
        {
            Context.Log("Starting rate.");
            var rater = Context.CreateRaterForPolicy(_policy, Context);
            rater.Rate(_policy);
            Context.Log("Rating completed.");
        }
    }
}

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
        protected readonly ILogger _logger;

        public decimal Rating { get; set; }

        public RatingEngine(PolicyModel policy, IPolicyRatingContext context, ILogger logger)
        {
            _policy = policy;
            Context = context;
            Context.Engine = this;
            _logger = logger;
        }

        public void Rate()
        {
            _logger.Log("Starting rate.");
            var rater = Context.CreateRaterForPolicy(_policy, Context, _logger);
            Rating = rater.Rate(_policy);
            _logger.Log("Rating completed.");
        }
    }
}

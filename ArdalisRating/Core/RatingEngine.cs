using ArdalisRating.Core.Interfaces;
using ArdalisRating.Core.Models;
using ArdalisRating.Core.Raters;
using System;

namespace ArdalisRating.Core
{
    /// <summary>
    /// The RatingEngine reads the policy application details from a file and produces a numeric 
    /// rating value based on the details.
    /// </summary>
    public class RatingEngine : IRatingEngine
    {
        public PolicyModel _policy;
        protected readonly ILogger _logger;
        private readonly RaterFactory _raterFactory;

        public decimal Rating { get; set; }

        public RatingEngine(PolicyModel policy, ILogger logger, RaterFactory raterFactory)
        {
            _policy = policy;
            _logger = logger;
            _raterFactory = raterFactory;
        }

        public void Rate()
        {
            _logger.Log("Starting rate.");
            var rater = _raterFactory.Create(_policy, _logger);
            Rating = rater.Rate(_policy);
            _logger.Log("Rating completed.");
        }
    }
}

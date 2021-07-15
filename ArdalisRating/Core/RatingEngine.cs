using ArdalisRating.Core.Interfaces;
using System;

namespace ArdalisRating.Core
{
    /// <summary>
    /// The RatingEngine reads the policy application details from a file and produces a numeric
    /// rating value based on the details.
    /// </summary>
    public class RatingEngine : IRatingEngine
    {
        protected readonly IBatchLogger _logger;
        private readonly IRaterFactory _raterFactory;

        public decimal Rating { get; set; }

        public string GetLogMessage()
        {
            return String.Join(";", _logger.LogList());
        }

        public RatingEngine(IBatchLogger logger, IRaterFactory raterFactory)
        {
            _logger = logger;
            _raterFactory = raterFactory;
        }

        public void Rate(IPolicyModel policy)
        {
            _logger.Log("Starting rate.");
            var rater = _raterFactory.Create(policy, _logger);
            Rating = rater.Rate(policy);
            _logger.Log("Rating completed.");
        }
    }
}
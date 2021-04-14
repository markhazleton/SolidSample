using ArdalisRating.Logger;
using ArdalisRating.Policy;
using System;

namespace ArdalisRating
{
    /// <summary>
    /// The RatingEngine reads the policy application details from a file and produces a numeric 
    /// rating value based on the details.
    /// </summary>
    public class RatingEngine
    {
        public RatingEngine(PolicyModel policy)
        {
            _policy = policy;
        }
        public PolicyModel _policy;
        public IConsoleLogger _logger { get; set; } = new ConsoleLogger();
        public decimal Rating { get; set; }
        public void Rate()
        {
            _logger.Log("Starting rate.");
            _logger.Log("Loading policy.");

            var factory = new RaterFactory();

            var rater = factory.Create(_policy, this);
            rater?.Rate(_policy);

            _logger.Log("Rating completed.");
        }
    }
}

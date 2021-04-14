using ArdalisRating.Logger;
using ArdalisRating.Policy;

namespace ArdalisRating.Rating
{
    public abstract class Rater
    {
        protected readonly ILogger _logger;
        public Rater(ILogger logger)
        {
            _logger = logger;
        }
        public abstract decimal Rate(PolicyModel policy);
    }
}

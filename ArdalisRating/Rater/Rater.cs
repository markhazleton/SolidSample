using ArdalisRating.Logger;
using ArdalisRating.Policy;

namespace ArdalisRating
{
    public abstract class Rater
    {
        protected readonly RatingEngine _engine;
        protected readonly IConsoleLogger _logger;

        public Rater(RatingEngine engine, IConsoleLogger logger)
        {
            _engine = engine;
            _logger = logger;
        }

        public abstract void Rate(PolicyModel policy);
    }
}

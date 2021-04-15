using ArdalisRating.Core.Interfaces;
using ArdalisRating.Core.Models;

namespace ArdalisRating.Core.Raters
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

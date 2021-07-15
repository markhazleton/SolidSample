using ArdalisRating.Core;
using ArdalisRating.Core.Interfaces;
using ArdalisRating.Core.Models;
using ArdalisRating.Core.Raters;
using ArdalisRating.Infrastructure.Logger;
using Xunit;

namespace ArdalisRating.Tests.Core
{
    public class RatingEngineRate
    {
        [Fact]
        public void ReturnsRatingOf10000For200000LandPolicy()
        {
            IBatchLogger logger = new InMemoryLogger();
            var policy = new PolicyModel
            {
                Type = PolicyType.Land,
                BondAmount = 200000,
                Valuation = 200000
            };
            var engine = new RatingEngine(logger, new RaterFactory());
            engine.Rate(policy);
            Assert.Equal(10000, engine.Rating);
        }

        [Fact]
        public void ReturnsRatingOf0For200000BondOn260000LandPolicy()
        {
            IBatchLogger logger = new InMemoryLogger();
            var policy = new PolicyModel
            {
                Type = PolicyType.Land,
                BondAmount = 200000,
                Valuation = 260000
            };
            var engine = new RatingEngine(logger, new RaterFactory());
            engine.Rate(policy);
            var result = engine.Rating;

            Assert.Equal(0, result);
        }
    }
}
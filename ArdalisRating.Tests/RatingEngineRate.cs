using ArdalisRating.Logger;
using ArdalisRating.Policy;
using ArdalisRating.Rating;
using Xunit;

namespace ArdalisRating.Tests
{
    public class RatingEngineRate
    {
        [Fact]
        public void ReturnsRatingOf10000For200000LandPolicy()
        {
            ILogger logger = new FakeLogger();

            DefaultRatingContext context = new DefaultRatingContext();
            var policy = new PolicyModel
            {
                Type = PolicyType.Land,
                BondAmount = 200000,
                Valuation = 200000
            };
            var engine = new RatingEngine(policy,context,logger);
            engine.Rate();
            Assert.Equal(10000, engine.Rating);
        }

        [Fact]
        public void ReturnsRatingOf0For200000BondOn260000LandPolicy()
        {
            ILogger logger = new FakeLogger();
            DefaultRatingContext context = new DefaultRatingContext();
            var policy = new PolicyModel
            {
                Type = PolicyType.Land,
                BondAmount = 200000,
                Valuation = 260000
            };
            var engine = new RatingEngine(policy, context, logger);
            engine.Rate();
            var result = engine.Rating;

            Assert.Equal(0, result);
        }
    }
}

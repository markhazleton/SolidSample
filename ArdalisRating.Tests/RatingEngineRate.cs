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
            DefaultRatingContext context = new DefaultRatingContext();
            var policy = new PolicyModel
            {
                Type = PolicyType.Land,
                BondAmount = 200000,
                Valuation = 200000
            };
            var engine = new RatingEngine(policy,context);
            engine.Rate();
            var result = engine.Rating;
            Assert.Equal(10000, result);
        }

        [Fact]
        public void ReturnsRatingOf0For200000BondOn260000LandPolicy()
        {
            DefaultRatingContext context = new DefaultRatingContext();
            var policy = new PolicyModel
            {
                Type = PolicyType.Land,
                BondAmount = 200000,
                Valuation = 260000
            };
            var engine = new RatingEngine(policy,context);
            engine.Rate();
            var result = engine.Rating;

            Assert.Equal(0, result);
        }
    }
}

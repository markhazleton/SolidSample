using System.Linq;
using Xunit;

namespace ArdalisRating.Tests;

public class AutoPolicyRaterRate
{
    [Fact]
    public void LogsMakeRequiredMessageGivenPolicyWithoutMake()
    {
        var policy = new Policy { Type = "Auto" };
        var logger = new FakeLogger();
        var rater = new AutoPolicyRater(logger);

        rater.Rate(policy);

        Assert.Equal("Auto policy must specify Make", logger.LoggedMessages.Last());
    }

    [Fact]
    public void SetsRatingTo1000ForBMWWith250Deductible()
    {
        var policy = new Policy
        {
            Type = "Auto",
            Make = "BMW",
            Deductible = 250m
        };
        var logger = new FakeLogger();
        var rater = new AutoPolicyRater(logger);

        var rating = rater.Rate(policy);

        Assert.Equal(1000m, rating);
    }
}

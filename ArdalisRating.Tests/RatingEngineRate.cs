using System.Text.Json;
using Xunit;

namespace ArdalisRating.Tests;

public class RatingEngineRate
{
    private readonly RatingEngine _engine;
    private readonly FakeLogger _logger;
    private readonly FakePolicySource _policySource;
    private readonly JsonPolicySerializer _policySerializer;

    public RatingEngineRate()
    {
        _logger = new FakeLogger();
        _policySource = new FakePolicySource();
        _policySerializer = new JsonPolicySerializer();

        _engine = new RatingEngine(
            _logger,
            _policySource,
            _policySerializer,
            new RaterFactory(_logger));
    }

    [Fact]
    public void ReturnsRatingOf10000For200000LandPolicy()
    {
        var policy = new Policy
        {
            Type = "Land",
            BondAmount = 200000,
            Valuation = 200000
        };
        string json = JsonSerializer.Serialize(policy);
        _policySource.PolicyString = json;

        _engine.Rate();
        var result = _engine.Rating;

        Assert.Equal(10000, result);
    }

    [Fact]
    public void ReturnsRatingOf0For200000BondOn260000LandPolicy()
    {
        var policy = new Policy
        {
            Type = "Land",
            BondAmount = 200000,
            Valuation = 260000
        };
        string json = JsonSerializer.Serialize(policy);
        _policySource.PolicyString = json;

        _engine.Rate();
        var result = _engine.Rating;

        Assert.Equal(0, result);
    }

    [Fact]
    public void LogsStartingLoadingAndCompleting()
    {
        var policy = new Policy
        {
            Type = "Land",
            BondAmount = 200000,
            Valuation = 260000
        };
        string json = JsonSerializer.Serialize(policy);
        _policySource.PolicyString = json;

        _engine.Rate();

        Assert.Contains(_logger.LoggedMessages, m => m == "Starting rate.");
        Assert.Contains(_logger.LoggedMessages, m => m == "Loading policy.");
        Assert.Contains(_logger.LoggedMessages, m => m == "Rating completed.");
    }

    [Fact]
    public async Task RateAsyncReturnsExpectedRating()
    {
        var policy = new Policy
        {
            Type = "Land",
            BondAmount = 200000,
            Valuation = 200000
        };
        string json = JsonSerializer.Serialize(policy);
        _policySource.PolicyString = json;

        await _engine.RateAsync();
        var result = _engine.Rating;

        Assert.Equal(10000, result);
    }
}

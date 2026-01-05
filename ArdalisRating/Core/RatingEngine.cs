namespace ArdalisRating;

/// <summary>
/// The RatingEngine reads the policy application details from a file and produces a numeric
/// rating value based on the details.
/// </summary>
public class RatingEngine
{
    private readonly ILogger _logger;
    private readonly IPolicySource _policySource;
    private readonly IPolicySerializer _policySerializer;
    private readonly RaterFactory _raterFactory;

    public decimal Rating { get; set; }

    public RatingEngine(
        ILogger logger,
        IPolicySource policySource,
        IPolicySerializer policySerializer,
        RaterFactory raterFactory)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _policySource = policySource ?? throw new ArgumentNullException(nameof(policySource));
        _policySerializer = policySerializer ?? throw new ArgumentNullException(nameof(policySerializer));
        _raterFactory = raterFactory ?? throw new ArgumentNullException(nameof(raterFactory));
    }

    public void Rate()
    {
        _logger.Log("Starting rate.");
        _logger.Log("Loading policy.");

        string policyJson = _policySource.GetPolicyFromSource();
        var policy = _policySerializer.GetPolicyFromString(policyJson);

        if (policy is null)
        {
            _logger.Log("No policy loaded.");
            Rating = 0;
            return;
        }

        var rater = _raterFactory.Create(policy);
        Rating = rater.Rate(policy);

        _logger.Log("Rating completed.");
    }

    public async Task RateAsync(CancellationToken cancellationToken = default)
    {
        _logger.Log("Starting rate.");
        _logger.Log("Loading policy.");

        string policyJson = await _policySource.GetPolicyFromSourceAsync(cancellationToken);
        var policy = await _policySerializer.GetPolicyFromStringAsync(policyJson, cancellationToken);

        if (policy is null)
        {
            _logger.Log("No policy loaded.");
            Rating = 0;
            return;
        }

        var rater = _raterFactory.Create(policy);
        Rating = rater.Rate(policy);

        _logger.Log("Rating completed.");
    }
}

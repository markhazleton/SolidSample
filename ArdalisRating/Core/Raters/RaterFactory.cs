namespace ArdalisRating;

public class RaterFactory
{
    private readonly ILogger _logger;

    public RaterFactory(ILogger logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public Rater Create(Policy policy)
    {
        ArgumentNullException.ThrowIfNull(policy);

        var raterTypeName = $"ArdalisRating.{policy.Type}PolicyRater";
        var raterType = Type.GetType(raterTypeName);

        if (raterType is null)
        {
            return new UnknownPolicyRater(_logger);
        }

        try
        {
            var rater = Activator.CreateInstance(raterType, _logger) as Rater;
            return rater ?? new UnknownPolicyRater(_logger);
        }
        catch
        {
            return new UnknownPolicyRater(_logger);
        }
    }
}

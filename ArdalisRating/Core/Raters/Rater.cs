namespace ArdalisRating;

public abstract class Rater
{
    protected ILogger Logger { get; }

    protected Rater(ILogger logger)
    {
        Logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public abstract decimal Rate(Policy policy);
}

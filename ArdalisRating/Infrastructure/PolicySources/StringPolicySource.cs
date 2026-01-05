namespace ArdalisRating;

public class StringPolicySource : IPolicySource
{
    public string PolicyString { get; set; } = string.Empty;

    public string GetPolicyFromSource()
    {
        return PolicyString;
    }

    public Task<string> GetPolicyFromSourceAsync(CancellationToken cancellationToken = default)
    {
        return Task.FromResult(PolicyString);
    }
}

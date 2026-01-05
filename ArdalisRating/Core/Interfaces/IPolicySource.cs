namespace ArdalisRating;

public interface IPolicySource
{
    Task<string> GetPolicyFromSourceAsync(CancellationToken cancellationToken = default);
    string GetPolicyFromSource(); // Keep for backward compatibility
}

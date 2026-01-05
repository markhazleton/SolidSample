namespace ArdalisRating;

public interface IPolicySerializer
{
    Task<Policy?> GetPolicyFromStringAsync(string policyString, CancellationToken cancellationToken = default);
    Policy? GetPolicyFromString(string policyString); // Keep for backward compatibility
}

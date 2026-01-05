namespace ArdalisRating;

public class FilePolicySource : IPolicySource
{
    private const string DefaultPolicyFile = "policy.json";

    public string GetPolicyFromSource()
    {
        return File.ReadAllText(DefaultPolicyFile);
    }

    public async Task<string> GetPolicyFromSourceAsync(CancellationToken cancellationToken = default)
    {
        return await File.ReadAllTextAsync(DefaultPolicyFile, cancellationToken);
    }
}

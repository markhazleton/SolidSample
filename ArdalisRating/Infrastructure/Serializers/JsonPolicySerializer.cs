using System.Text.Json;
using System.Text.Json.Serialization;

namespace ArdalisRating;

public class JsonPolicySerializer : IPolicySerializer
{
    private static readonly JsonSerializerOptions Options = new()
    {
        PropertyNameCaseInsensitive = true,
        Converters = { new JsonStringEnumConverter() }
    };

    public Policy? GetPolicyFromString(string policyString)
    {
        if (string.IsNullOrWhiteSpace(policyString))
        {
            return null;
        }

        return JsonSerializer.Deserialize<Policy>(policyString, Options);
    }

    public async Task<Policy?> GetPolicyFromStringAsync(string policyString, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(policyString))
        {
            return null;
        }

        using var stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(policyString));
        return await JsonSerializer.DeserializeAsync<Policy>(stream, Options, cancellationToken);
    }
}

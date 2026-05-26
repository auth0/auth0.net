using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record ListRateLimitPoliciesRequestParameters
{
    /// <summary>
    /// The API protected by the Rate Limit Policy.
    /// </summary>
    [JsonIgnore]
    public Optional<RateLimitPolicyResourceEnum?> Resource { get; set; }

    /// <summary>
    /// The consumer to which the rate limit policy applies.
    /// </summary>
    [JsonIgnore]
    public Optional<RateLimitPolicyConsumerEnum?> Consumer { get; set; }

    /// <summary>
    /// Identifier or category within the consumer to which the policy applies. Supported values: `client_id:` to target a specific client by ID, `client_id:` to target a CIMD client by URI, `cimd_clients` to target all CIMD clients, `third_party_clients` to target all third-party clients, or `default` to apply the policy to any consumer identifier not otherwise explicitly targeted.
    /// </summary>
    [JsonIgnore]
    public Optional<string?> ConsumerSelector { get; set; }

    /// <summary>
    /// Number of results per page. Defaults to 50.
    /// </summary>
    [JsonIgnore]
    public Optional<int?> Take { get; set; } = 50;

    /// <summary>
    /// Cursor for pagination.
    /// </summary>
    [JsonIgnore]
    public Optional<string?> From { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

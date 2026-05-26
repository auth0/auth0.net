using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record UpdateRateLimitPolicyResponseContent : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Unique identifier for the Rate Limit Policy.
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("resource")]
    public required RateLimitPolicyResourceEnum Resource { get; set; }

    [JsonPropertyName("consumer")]
    public required RateLimitPolicyConsumerEnum Consumer { get; set; }

    /// <summary>
    /// Identifier or category within the consumer to which the policy applies. Supported values: `client_id:` to target a specific client by ID, `client_id:` to target a CIMD client by URI, `cimd_clients` to target all CIMD clients, `third_party_clients` to target all third-party clients, or `default` to apply the policy to any consumer identifier not otherwise explicitly targeted.
    /// </summary>
    [JsonPropertyName("consumer_selector")]
    public required string ConsumerSelector { get; set; }

    [JsonPropertyName("configuration")]
    public required RateLimitPolicyConfiguration Configuration { get; set; }

    /// <summary>
    /// The date and time when the rate limit policy was created.
    /// </summary>
    [Optional]
    [JsonPropertyName("created_at")]
    public DateTime? CreatedAt { get; set; }

    /// <summary>
    /// The date and time when the rate limit policy was last updated.
    /// </summary>
    [Optional]
    [JsonPropertyName("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

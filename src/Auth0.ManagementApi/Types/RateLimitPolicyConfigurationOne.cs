using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record RateLimitPolicyConfigurationOne : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Determines the action to take when the rate limit is exceeded.
    /// </summary>
    [JsonPropertyName("action")]
    public required RateLimitPolicyConfigurationOneAction Action { get; set; }

    /// <summary>
    /// The maximum number of requests allowed in a single refresh window.
    /// </summary>
    [JsonPropertyName("limit")]
    public required int Limit { get; set; }

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

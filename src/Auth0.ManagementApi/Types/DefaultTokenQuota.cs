using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// Token Quota configuration, to configure quotas for token issuance for clients and organizations. Applied to all clients and organizations unless overridden in individual client or organization settings.
/// </summary>
[Serializable]
public record DefaultTokenQuota : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [Optional]
    [JsonPropertyName("clients")]
    public TokenQuotaConfiguration? Clients { get; set; }

    [Optional]
    [JsonPropertyName("organizations")]
    public TokenQuotaConfiguration? Organizations { get; set; }

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

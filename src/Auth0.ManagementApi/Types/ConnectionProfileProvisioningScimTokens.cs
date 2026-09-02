using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// SCIM token settings for connections created from this profile.
/// </summary>
[Serializable]
public record ConnectionProfileProvisioningScimTokens : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("scopes")]
    public IEnumerable<ConnectionProfileProvisioningScimTokenScopeEnum> Scopes { get; set; } =
        new List<ConnectionProfileProvisioningScimTokenScopeEnum>();

    [Nullable, Optional]
    [JsonPropertyName("default_expiry")]
    public Optional<int?> DefaultExpiry { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("max_allowed_expiry")]
    public Optional<int?> MaxAllowedExpiry { get; set; }

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

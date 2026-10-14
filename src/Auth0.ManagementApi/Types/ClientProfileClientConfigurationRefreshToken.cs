using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// Refresh token settings. Omit any sub-field to use the client's own value.
/// </summary>
[Serializable]
public record ClientProfileClientConfigurationRefreshToken : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [Optional]
    [JsonPropertyName("token_lifetime")]
    public ClientProfileRefreshTokenTokenLifetime? TokenLifetime { get; set; }

    [Optional]
    [JsonPropertyName("idle_token_lifetime")]
    public ClientProfileRefreshTokenIdleTokenLifetime? IdleTokenLifetime { get; set; }

    [Optional]
    [JsonPropertyName("leeway")]
    public ClientProfileRefreshTokenLeeway? Leeway { get; set; }

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

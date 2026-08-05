using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// Configure the purpose of a connection to be used for connected accounts and Token Vault.
/// </summary>
[Serializable]
public record ConnectionConnectedAccountsPurpose : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("active")]
    public required bool Active { get; set; }

    [Optional]
    [JsonPropertyName("cross_app_access")]
    public bool? CrossAppAccess { get; set; }

    /// <summary>
    /// When true, allows storing a connected account without an upstream identity provider user id. At most one such connected account is allowed per user per connection. Default false preserves the strict behaviour (an upstream user id is required).
    /// </summary>
    [Optional]
    [JsonPropertyName("allow_missing_user_id")]
    public bool? AllowMissingUserId { get; set; }

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

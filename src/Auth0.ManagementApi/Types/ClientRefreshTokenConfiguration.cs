using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// Refresh token configuration
/// </summary>
[Serializable]
public record ClientRefreshTokenConfiguration : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("rotation_type")]
    public required RefreshTokenRotationTypeEnum RotationType { get; set; }

    [JsonPropertyName("expiration_type")]
    public required RefreshTokenExpirationTypeEnum ExpirationType { get; set; }

    /// <summary>
    /// Period in seconds where the previous refresh token can be exchanged without triggering breach detection
    /// </summary>
    [Optional]
    [JsonPropertyName("leeway")]
    public int? Leeway { get; set; }

    /// <summary>
    /// Period (in seconds) for which refresh tokens will remain valid
    /// </summary>
    [Optional]
    [JsonPropertyName("token_lifetime")]
    public int? TokenLifetime { get; set; }

    /// <summary>
    /// Prevents tokens from having a set lifetime when `true` (takes precedence over `token_lifetime` values)
    /// </summary>
    [Optional]
    [JsonPropertyName("infinite_token_lifetime")]
    public bool? InfiniteTokenLifetime { get; set; }

    /// <summary>
    /// Period (in seconds) for which refresh tokens will remain valid without use
    /// </summary>
    [Optional]
    [JsonPropertyName("idle_token_lifetime")]
    public int? IdleTokenLifetime { get; set; }

    /// <summary>
    /// Prevents tokens from expiring without use when `true` (takes precedence over `idle_token_lifetime` values)
    /// </summary>
    [Optional]
    [JsonPropertyName("infinite_idle_token_lifetime")]
    public bool? InfiniteIdleTokenLifetime { get; set; }

    /// <summary>
    /// A collection of policies governing multi-resource refresh token exchange (MRRT), defining how refresh tokens can be used across different resource servers
    /// </summary>
    [Nullable, Optional]
    [JsonPropertyName("policies")]
    public Optional<IEnumerable<ClientRefreshTokenPolicy>?> Policies { get; set; }

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

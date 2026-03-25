using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record UserIdentity : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Connection name of this identity.
    /// </summary>
    [JsonPropertyName("connection")]
    public required string Connection { get; set; }

    /// <summary>
    /// user_id of this identity.
    /// </summary>
    [JsonPropertyName("user_id")]
    public required UserId UserId { get; set; }

    /// <summary>
    /// Type of identity provider.
    /// </summary>
    [JsonPropertyName("provider")]
    public required string Provider { get; set; }

    [Optional]
    [JsonPropertyName("profileData")]
    public UserProfileData? ProfileData { get; set; }

    /// <summary>
    /// Whether the identity provider is a social provider (true) or not (false).
    /// </summary>
    [Optional]
    [JsonPropertyName("isSocial")]
    public bool? IsSocial { get; set; }

    /// <summary>
    /// IDP access token returned if scope `read:user_idp_tokens` is defined.
    /// </summary>
    [Optional]
    [JsonPropertyName("access_token")]
    public string? AccessToken { get; set; }

    /// <summary>
    /// IDP access token secret returned only if `scope read:user_idp_tokens` is defined.
    /// </summary>
    [Optional]
    [JsonPropertyName("access_token_secret")]
    public string? AccessTokenSecret { get; set; }

    /// <summary>
    /// IDP refresh token returned only if scope `read:user_idp_tokens` is defined.
    /// </summary>
    [Optional]
    [JsonPropertyName("refresh_token")]
    public string? RefreshToken { get; set; }

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

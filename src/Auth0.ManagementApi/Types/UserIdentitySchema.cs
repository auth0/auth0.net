using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record UserIdentitySchema : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Name of the connection containing this identity.
    /// </summary>
    [Optional]
    [JsonPropertyName("connection")]
    public string? Connection { get; set; }

    /// <summary>
    /// Unique identifier of the user user for this identity.
    /// </summary>
    [Optional]
    [JsonPropertyName("user_id")]
    public string? UserId { get; set; }

    [Optional]
    [JsonPropertyName("provider")]
    public UserIdentityProviderEnum? Provider { get; set; }

    /// <summary>
    /// Whether this identity is from a social provider (true) or not (false).
    /// </summary>
    [Optional]
    [JsonPropertyName("isSocial")]
    public bool? IsSocial { get; set; }

    /// <summary>
    /// IDP access token returned only if scope read:user_idp_tokens is defined.
    /// </summary>
    [Optional]
    [JsonPropertyName("access_token")]
    public string? AccessToken { get; set; }

    /// <summary>
    /// IDP access token secret returned only if scope read:user_idp_tokens is defined.
    /// </summary>
    [Optional]
    [JsonPropertyName("access_token_secret")]
    public string? AccessTokenSecret { get; set; }

    /// <summary>
    /// IDP refresh token returned only if scope read:user_idp_tokens is defined.
    /// </summary>
    [Optional]
    [JsonPropertyName("refresh_token")]
    public string? RefreshToken { get; set; }

    [Optional]
    [JsonPropertyName("profileData")]
    public UserProfileData? ProfileData { get; set; }

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

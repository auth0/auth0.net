using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record DeleteUserIdentityResponseContentItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The name of the connection for the identity.
    /// </summary>
    [JsonPropertyName("connection")]
    public required string Connection { get; set; }

    /// <summary>
    /// The unique identifier for the user for the identity.
    /// </summary>
    [JsonPropertyName("user_id")]
    public required string UserId { get; set; }

    /// <summary>
    /// The type of identity provider.
    /// </summary>
    [JsonPropertyName("provider")]
    public required string Provider { get; set; }

    /// <summary>
    /// <code>true</code> if the identity provider is a social provider, <code>false</code>s otherwise
    /// </summary>
    [Optional]
    [JsonPropertyName("isSocial")]
    public bool? IsSocial { get; set; }

    /// <summary>
    /// IDP access token returned only if scope read:user_idp_tokens is defined
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

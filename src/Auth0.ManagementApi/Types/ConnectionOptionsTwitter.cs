using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

/// <summary>
/// Options for the 'twitter' connection
/// </summary>
[Serializable]
public record ConnectionOptionsTwitter : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    [Optional]
    [JsonPropertyName("client_id")]
    public string? ClientId { get; set; }

    [Optional]
    [JsonPropertyName("client_secret")]
    public string? ClientSecret { get; set; }

    [Optional]
    [JsonPropertyName("freeform_scopes")]
    public IEnumerable<string>? FreeformScopes { get; set; }

    [Optional]
    [JsonPropertyName("protocol")]
    public ConnectionOptionsProtocolEnumTwitter? Protocol { get; set; }

    [Optional]
    [JsonPropertyName("scope")]
    public IEnumerable<string>? Scope { get; set; }

    [Optional]
    [JsonPropertyName("set_user_root_attributes")]
    public ConnectionSetUserRootAttributesEnum? SetUserRootAttributes { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("upstream_params")]
    public Optional<Dictionary<
        string,
        ConnectionUpstreamAdditionalProperties?
    >?> UpstreamParams { get; set; }

    /// <summary>
    /// Request long-lived refresh tokens so your app can act on behalf of users even when they’re not actively signed in. Typical Twitter use case: keeping a background service synced without forcing users to reauthorize every session.
    /// </summary>
    [Optional]
    [JsonPropertyName("offline_access")]
    public bool? OfflineAccess { get; set; }

    /// <summary>
    /// Pull account profile metadata such as display name, bio, location, and URL so downstream apps can prefill or personalize user experiences.
    /// </summary>
    [Optional]
    [JsonPropertyName("profile")]
    public bool? Profile { get; set; }

    /// <summary>
    /// Allow the application to read a user’s public and protected Tweets—required for timelines, analytics, or moderation workflows.
    /// </summary>
    [Optional]
    [JsonPropertyName("tweet_read")]
    public bool? TweetRead { get; set; }

    /// <summary>
    /// Read non-Tweet user information (e.g., followers/following, account settings) to power relationship graphs or audience insights.
    /// </summary>
    [Optional]
    [JsonPropertyName("users_read")]
    public bool? UsersRead { get; set; }

    [Optional]
    [JsonPropertyName("non_persistent_attrs")]
    public IEnumerable<string>? NonPersistentAttrs { get; set; }

    [JsonIgnore]
    public AdditionalProperties AdditionalProperties { get; set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    void IJsonOnSerializing.OnSerializing() =>
        AdditionalProperties.CopyToExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

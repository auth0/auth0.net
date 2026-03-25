using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// Options for the 'linkedin' connection
/// </summary>
[Serializable]
public record ConnectionOptionsLinkedin : IJsonOnDeserialized, IJsonOnSerializing
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
    [JsonPropertyName("scope")]
    public IEnumerable<string>? Scope { get; set; }

    [Optional]
    [JsonPropertyName("set_user_root_attributes")]
    public ConnectionSetUserRootAttributesEnum? SetUserRootAttributes { get; set; }

    /// <summary>
    /// The strategy_version property determines which LinkedIn API version and OAuth scopes are used for authentication. Version 1 uses legacy scopes (r_basicprofile, r_fullprofile, r_network), Version 2 uses updated scopes (r_liteprofile, r_basicprofile), and Version 3 uses OpenID Connect scopes (profile, email, openid). If not specified, the connection defaults to Version 3.
    /// </summary>
    [Optional]
    [JsonPropertyName("strategy_version")]
    public int? StrategyVersion { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("upstream_params")]
    public Optional<Dictionary<
        string,
        ConnectionUpstreamAdditionalProperties?
    >?> UpstreamParams { get; set; }

    /// <summary>
    /// Request the LinkedIn lite profile scope (r_liteprofile) to retrieve member id, localized first/last name, and profile picture. Off by default.
    /// </summary>
    [Optional]
    [JsonPropertyName("basic_profile")]
    public bool? BasicProfile { get; set; }

    /// <summary>
    /// Request the email address scope (r_emailaddress) to return the member's primary email. Off by default.
    /// </summary>
    [Optional]
    [JsonPropertyName("email")]
    public bool? Email { get; set; }

    /// <summary>
    /// Request the legacy full profile scope (r_fullprofile) for extended attributes. Deprecated by LinkedIn; use only if enabled for your app. Off by default.
    /// </summary>
    [Optional]
    [JsonPropertyName("full_profile")]
    public bool? FullProfile { get; set; }

    /// <summary>
    /// Request legacy network access (first-degree connections). Deprecated by LinkedIn and typically unavailable to new apps. Off by default.
    /// </summary>
    [Optional]
    [JsonPropertyName("network")]
    public bool? Network { get; set; }

    /// <summary>
    /// Request OpenID Connect authentication support (openid scope). When enabled, the connection will request the 'openid' scope from LinkedIn, allowing the use of OpenID Connect flows for authentication and enabling the issuance of ID tokens. This is off by default and should only be enabled if your LinkedIn application is configured for OpenID Connect.
    /// </summary>
    [Optional]
    [JsonPropertyName("openid")]
    public bool? Openid { get; set; }

    /// <summary>
    /// Always-true flag that ensures the LinkedIn profile scope (r_basicprofile/r_liteprofile/profile) is requested.
    /// </summary>
    [Optional]
    [JsonPropertyName("profile")]
    public bool? Profile { get; set; }

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

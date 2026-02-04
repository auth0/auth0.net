using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

/// <summary>
/// Options for the 'oauth2' connection
/// </summary>
[Serializable]
public record ConnectionOptionsOAuth2 : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [Optional]
    [JsonPropertyName("authParams")]
    public Dictionary<string, string>? AuthParams { get; set; }

    [Optional]
    [JsonPropertyName("authParamsMap")]
    public Dictionary<string, string>? AuthParamsMap { get; set; }

    [Optional]
    [JsonPropertyName("authorizationURL")]
    public string? AuthorizationUrl { get; set; }

    [Optional]
    [JsonPropertyName("client_id")]
    public string? ClientId { get; set; }

    [Optional]
    [JsonPropertyName("client_secret")]
    public string? ClientSecret { get; set; }

    [Optional]
    [JsonPropertyName("customHeaders")]
    public Dictionary<string, string>? CustomHeaders { get; set; }

    [Optional]
    [JsonPropertyName("fieldsMap")]
    public Dictionary<string, string>? FieldsMap { get; set; }

    [Optional]
    [JsonPropertyName("icon_url")]
    public string? IconUrl { get; set; }

    [Optional]
    [JsonPropertyName("logoutUrl")]
    public string? LogoutUrl { get; set; }

    /// <summary>
    /// When true, enables Proof Key for Code Exchange (PKCE) for the authorization code flow. PKCE provides additional security by preventing authorization code interception attacks.
    /// </summary>
    [Optional]
    [JsonPropertyName("pkce_enabled")]
    public bool? PkceEnabled { get; set; }

    [Optional]
    [JsonPropertyName("scope")]
    public ConnectionScopeOAuth2? Scope { get; set; }

    [Optional]
    [JsonPropertyName("scripts")]
    public ConnectionScriptsOAuth2? Scripts { get; set; }

    [Optional]
    [JsonPropertyName("set_user_root_attributes")]
    public ConnectionSetUserRootAttributesEnum? SetUserRootAttributes { get; set; }

    [Optional]
    [JsonPropertyName("tokenURL")]
    public string? TokenUrl { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("upstream_params")]
    public Optional<Dictionary<
        string,
        ConnectionUpstreamAdditionalProperties?
    >?> UpstreamParams { get; set; }

    /// <summary>
    /// When true, uses space-delimited scopes (per OAuth 2.0 spec) instead of comma-delimited when calling the identity provider's authorization endpoint. Only relevant when using the connection_scope parameter. See https://auth0.com/docs/authenticate/identity-providers/adding-scopes-for-an-external-idp#pass-scopes-to-authorize-endpoint
    /// </summary>
    [Optional]
    [JsonPropertyName("useOauthSpecScope")]
    public bool? UseOauthSpecScope { get; set; }

    [Optional]
    [JsonPropertyName("non_persistent_attrs")]
    public IEnumerable<string>? NonPersistentAttrs { get; set; }

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

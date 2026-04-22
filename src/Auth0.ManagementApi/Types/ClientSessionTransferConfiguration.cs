using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// Native to Web SSO Configuration
/// </summary>
[Serializable]
public record ClientSessionTransferConfiguration : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Indicates whether an app can issue a Session Transfer Token through Token Exchange. If set to 'false', the app will not be able to issue a Session Transfer Token. Usually configured in the native application. Default value is `false`.
    /// </summary>
    [Optional]
    [JsonPropertyName("can_create_session_transfer_token")]
    public bool? CanCreateSessionTransferToken { get; set; }

    /// <summary>
    /// Indicates whether revoking the parent Refresh Token that initiated a Native to Web flow and was used to issue a Session Transfer Token should trigger a cascade revocation affecting its dependent child entities. Usually configured in the native application. Default value is `true`, applicable only in Native to Web SSO context.
    /// </summary>
    [Optional]
    [JsonPropertyName("enforce_cascade_revocation")]
    public bool? EnforceCascadeRevocation { get; set; }

    /// <summary>
    /// Indicates whether an app can create a session from a Session Transfer Token received via indicated methods. Can include `cookie` and/or `query`. Usually configured in the web application. Default value is an empty array [].
    /// </summary>
    [Nullable, Optional]
    [JsonPropertyName("allowed_authentication_methods")]
    public Optional<IEnumerable<ClientSessionTransferAllowedAuthenticationMethodsEnum>?> AllowedAuthenticationMethods { get; set; }

    [Optional]
    [JsonPropertyName("enforce_device_binding")]
    public ClientSessionTransferDeviceBindingEnum? EnforceDeviceBinding { get; set; }

    /// <summary>
    /// Indicates whether Refresh Tokens are allowed to be issued when authenticating with a Session Transfer Token. Usually configured in the web application. Default value is `false`.
    /// </summary>
    [Optional]
    [JsonPropertyName("allow_refresh_token")]
    public bool? AllowRefreshToken { get; set; }

    /// <summary>
    /// Indicates whether Refresh Tokens created during a Native to Web session are tied to that session's lifetime. This determines if such refresh tokens should be automatically revoked when their corresponding sessions are. Usually configured in the web application. Default value is `true`, applicable only in Native to Web SSO context.
    /// </summary>
    [Optional]
    [JsonPropertyName("enforce_online_refresh_tokens")]
    public bool? EnforceOnlineRefreshTokens { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("delegation")]
    public Optional<ClientSessionTransferDelegationConfiguration?> Delegation { get; set; }

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

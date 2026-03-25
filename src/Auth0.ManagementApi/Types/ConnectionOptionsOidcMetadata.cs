using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// OpenID Connect Provider Metadata as per https://openid.net/specs/openid-connect-discovery-1_0.html#ProviderMetadata
/// </summary>
[Serializable]
public record ConnectionOptionsOidcMetadata : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    [Optional]
    [JsonPropertyName("acr_values_supported")]
    public IEnumerable<string>? AcrValuesSupported { get; set; }

    [JsonPropertyName("authorization_endpoint")]
    public required string AuthorizationEndpoint { get; set; }

    [Optional]
    [JsonPropertyName("claim_types_supported")]
    public IEnumerable<string>? ClaimTypesSupported { get; set; }

    [Optional]
    [JsonPropertyName("claims_locales_supported")]
    public IEnumerable<string>? ClaimsLocalesSupported { get; set; }

    [Optional]
    [JsonPropertyName("claims_parameter_supported")]
    public bool? ClaimsParameterSupported { get; set; }

    [Optional]
    [JsonPropertyName("claims_supported")]
    public IEnumerable<string>? ClaimsSupported { get; set; }

    [Optional]
    [JsonPropertyName("display_values_supported")]
    public IEnumerable<string>? DisplayValuesSupported { get; set; }

    [Optional]
    [JsonPropertyName("dpop_signing_alg_values_supported")]
    public IEnumerable<string>? DpopSigningAlgValuesSupported { get; set; }

    [Optional]
    [JsonPropertyName("end_session_endpoint")]
    public string? EndSessionEndpoint { get; set; }

    [Optional]
    [JsonPropertyName("grant_types_supported")]
    public IEnumerable<string>? GrantTypesSupported { get; set; }

    [Optional]
    [JsonPropertyName("id_token_encryption_alg_values_supported")]
    public IEnumerable<string>? IdTokenEncryptionAlgValuesSupported { get; set; }

    [Optional]
    [JsonPropertyName("id_token_encryption_enc_values_supported")]
    public IEnumerable<string>? IdTokenEncryptionEncValuesSupported { get; set; }

    [JsonPropertyName("id_token_signing_alg_values_supported")]
    public IEnumerable<string> IdTokenSigningAlgValuesSupported { get; set; } = new List<string>();

    [JsonPropertyName("issuer")]
    public required string Issuer { get; set; }

    [JsonPropertyName("jwks_uri")]
    public required string JwksUri { get; set; }

    [Optional]
    [JsonPropertyName("op_policy_uri")]
    public string? OpPolicyUri { get; set; }

    [Optional]
    [JsonPropertyName("op_tos_uri")]
    public string? OpTosUri { get; set; }

    [Optional]
    [JsonPropertyName("registration_endpoint")]
    public string? RegistrationEndpoint { get; set; }

    [Optional]
    [JsonPropertyName("request_object_encryption_alg_values_supported")]
    public IEnumerable<string>? RequestObjectEncryptionAlgValuesSupported { get; set; }

    [Optional]
    [JsonPropertyName("request_object_encryption_enc_values_supported")]
    public IEnumerable<string>? RequestObjectEncryptionEncValuesSupported { get; set; }

    [Optional]
    [JsonPropertyName("request_object_signing_alg_values_supported")]
    public IEnumerable<string>? RequestObjectSigningAlgValuesSupported { get; set; }

    [Optional]
    [JsonPropertyName("request_parameter_supported")]
    public bool? RequestParameterSupported { get; set; }

    [Optional]
    [JsonPropertyName("request_uri_parameter_supported")]
    public bool? RequestUriParameterSupported { get; set; }

    [Optional]
    [JsonPropertyName("require_request_uri_registration")]
    public bool? RequireRequestUriRegistration { get; set; }

    [Optional]
    [JsonPropertyName("response_modes_supported")]
    public IEnumerable<string>? ResponseModesSupported { get; set; }

    [Optional]
    [JsonPropertyName("response_types_supported")]
    public IEnumerable<string>? ResponseTypesSupported { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("scopes_supported")]
    public Optional<IEnumerable<string>?> ScopesSupported { get; set; }

    [Optional]
    [JsonPropertyName("service_documentation")]
    public string? ServiceDocumentation { get; set; }

    [Optional]
    [JsonPropertyName("subject_types_supported")]
    public IEnumerable<string>? SubjectTypesSupported { get; set; }

    [Optional]
    [JsonPropertyName("token_endpoint")]
    public string? TokenEndpoint { get; set; }

    [Optional]
    [JsonPropertyName("token_endpoint_auth_methods_supported")]
    public IEnumerable<string>? TokenEndpointAuthMethodsSupported { get; set; }

    [Optional]
    [JsonPropertyName("token_endpoint_auth_signing_alg_values_supported")]
    public IEnumerable<string>? TokenEndpointAuthSigningAlgValuesSupported { get; set; }

    [Optional]
    [JsonPropertyName("ui_locales_supported")]
    public IEnumerable<string>? UiLocalesSupported { get; set; }

    [Optional]
    [JsonPropertyName("userinfo_encryption_alg_values_supported")]
    public IEnumerable<string>? UserinfoEncryptionAlgValuesSupported { get; set; }

    [Optional]
    [JsonPropertyName("userinfo_encryption_enc_values_supported")]
    public IEnumerable<string>? UserinfoEncryptionEncValuesSupported { get; set; }

    [Optional]
    [JsonPropertyName("userinfo_endpoint")]
    public string? UserinfoEndpoint { get; set; }

    [Optional]
    [JsonPropertyName("userinfo_signing_alg_values_supported")]
    public IEnumerable<string>? UserinfoSigningAlgValuesSupported { get; set; }

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

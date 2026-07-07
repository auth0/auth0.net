using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// OpenID Connect Provider Metadata as per https://openid.net/specs/openid-connect-discovery-1_0.html#ProviderMetadata
/// </summary>
[Serializable]
public record EventStreamCloudEventConnectionCreatedObject0OptionsOidcMetadata : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// A list of the Authentication Context Class References that this OP supports
    /// </summary>
    [Optional]
    [JsonPropertyName("acr_values_supported")]
    public IEnumerable<string>? AcrValuesSupported { get; set; }

    /// <summary>
    /// URL of the identity provider's OAuth 2.0 authorization endpoint where users are redirected for authentication. Must be a valid HTTPS URL. This endpoint initiates the OAuth 2.0 authorization code flow.
    /// </summary>
    [JsonPropertyName("authorization_endpoint")]
    public required string AuthorizationEndpoint { get; set; }

    /// <summary>
    /// JSON array containing a list of the Claim Types that the OpenID Provider supports. These Claim Types are described in Section 5.6 of OpenID Connect Core 1.0 [OpenID.Core]. If omitted, the implementation supports only normal Claims.
    /// </summary>
    [Optional]
    [JsonPropertyName("claim_types_supported")]
    public IEnumerable<string>? ClaimTypesSupported { get; set; }

    /// <summary>
    /// Languages and scripts supported for values in Claims being returned, represented as a JSON array of BCP47 [RFC5646] language tag values. Not all languages and scripts are necessarily supported for all Claim values.
    /// </summary>
    [Optional]
    [JsonPropertyName("claims_locales_supported")]
    public IEnumerable<string>? ClaimsLocalesSupported { get; set; }

    /// <summary>
    /// Boolean value specifying whether the OP supports use of the claims parameter, with true indicating support. If omitted, the default value is false.
    /// </summary>
    [Optional]
    [JsonPropertyName("claims_parameter_supported")]
    public bool? ClaimsParameterSupported { get; set; }

    /// <summary>
    /// JSON array containing a list of the Claim Names of the Claims that the OpenID Provider MAY be able to supply values for. Note that for privacy or other reasons, this might not be an exhaustive list.
    /// </summary>
    [Optional]
    [JsonPropertyName("claims_supported")]
    public IEnumerable<string>? ClaimsSupported { get; set; }

    /// <summary>
    /// JSON array containing a list of the JWS signing algorithms (alg values) supported by the Token Endpoint for the signature on the JWT [JWT] used to authenticate the Client at the Token Endpoint for the private_key_jwt and client_secret_jwt authentication methods. Servers SHOULD support RS256. The value none MUST NOT be used.
    /// </summary>
    [Optional]
    [JsonPropertyName("display_values_supported")]
    public IEnumerable<string>? DisplayValuesSupported { get; set; }

    /// <summary>
    /// JSON array containing a list of the JWS signing algorithms (alg values) supported for DPoP proof JWT signing.
    /// </summary>
    [Optional]
    [JsonPropertyName("dpop_signing_alg_values_supported")]
    public IEnumerable<string>? DpopSigningAlgValuesSupported { get; set; }

    /// <summary>
    /// URL of the identity provider's logout/end session endpoint. When configured as a static URL, users are redirected here after logging out from Auth0. Must use HTTPS scheme.
    /// </summary>
    [Optional]
    [JsonPropertyName("end_session_endpoint")]
    public string? EndSessionEndpoint { get; set; }

    /// <summary>
    /// A list of the OAuth 2.0 Grant Type values that this OP supports. Dynamic OpenID Providers MUST support the authorization_code and implicit Grant Type values and MAY support other Grant Types. If omitted, the default value is ["authorization_code", "implicit"].
    /// </summary>
    [Optional]
    [JsonPropertyName("grant_types_supported")]
    public IEnumerable<string>? GrantTypesSupported { get; set; }

    /// <summary>
    /// JSON array containing a list of the JWE encryption algorithms (alg values) supported by the OP for the ID Token to encode the Claims in a JWT
    /// </summary>
    [Optional]
    [JsonPropertyName("id_token_encryption_alg_values_supported")]
    public IEnumerable<string>? IdTokenEncryptionAlgValuesSupported { get; set; }

    /// <summary>
    /// JSON array containing a list of the JWE encryption algorithms (enc values) supported by the OP for the ID Token to encode the Claims in a JWT [JWT].
    /// </summary>
    [Optional]
    [JsonPropertyName("id_token_encryption_enc_values_supported")]
    public IEnumerable<string>? IdTokenEncryptionEncValuesSupported { get; set; }

    /// <summary>
    /// A list of the JWS signing algorithms (alg values) supported by the OP for the ID Token to encode the Claims in a JWT. The algorithm RS256 MUST be included. The value none MAY be supported, but MUST NOT be used unless the Response Type used returns no ID Token from the Authorization Endpoint (such as when using the Authorization Code Flow). https://datatracker.ietf.org/doc/html/rfc7518
    /// </summary>
    [JsonPropertyName("id_token_signing_alg_values_supported")]
    public IEnumerable<string> IdTokenSigningAlgValuesSupported { get; set; } = new List<string>();

    /// <summary>
    /// The identity provider's unique issuer identifier URL (e.g., https://accounts.google.com). Must match the 'iss' claim in ID tokens from the identity provider.
    /// </summary>
    [JsonPropertyName("issuer")]
    public required string Issuer { get; set; }

    /// <summary>
    /// URL of the identity provider's JSON Web Key Set (JWKS) endpoint containing public keys for signature verification. Auth0 retrieves these keys to validate ID token signatures.
    /// </summary>
    [JsonPropertyName("jwks_uri")]
    public required string JwksUri { get; set; }

    /// <summary>
    /// URL that the OpenID Provider provides to the person registering the Client to read about the OPs requirements on how the Relying Party can use the data provided by the OP. The registration process SHOULD display this URL to the person registering the Client if it is given.
    /// </summary>
    [Optional]
    [JsonPropertyName("op_policy_uri")]
    public string? OpPolicyUri { get; set; }

    /// <summary>
    /// URL that the OpenID Provider provides to the person registering the Client to read about OpenID Providers terms of service. The registration process SHOULD display this URL to the person registering the Client if it is given.
    /// </summary>
    [Optional]
    [JsonPropertyName("op_tos_uri")]
    public string? OpTosUri { get; set; }

    /// <summary>
    /// URL of the OPs Dynamic Client Registration Endpoint. RECOMMENDED but not REQUIRED. https://openid.net/specs/openid-connect-discovery-1_0.html#OpenID.Registration
    /// </summary>
    [Optional]
    [JsonPropertyName("registration_endpoint")]
    public string? RegistrationEndpoint { get; set; }

    /// <summary>
    /// JSON array containing a list of the JWE encryption algorithms (alg values) supported by the OP for Request Objects. These algorithms are used both when the Request Object is passed by value and when it is passed by reference.
    /// </summary>
    [Optional]
    [JsonPropertyName("request_object_encryption_alg_values_supported")]
    public IEnumerable<string>? RequestObjectEncryptionAlgValuesSupported { get; set; }

    /// <summary>
    /// JSON array containing a list of the JWE encryption algorithms (enc values) supported by the OP for Request Objects. These algorithms are used both when the Request Object is passed by value and when it is passed by reference.
    /// </summary>
    [Optional]
    [JsonPropertyName("request_object_encryption_enc_values_supported")]
    public IEnumerable<string>? RequestObjectEncryptionEncValuesSupported { get; set; }

    /// <summary>
    /// JSON array containing a list of the JWS signing algorithms (alg values) supported by the OP for Request Objects, which are described in Section 6.1 of OpenID Connect Core 1.0 [OpenID.Core]. These algorithms are used both when the Request Object is passed by value (using the request parameter) and when it is passed by reference (using the request_uri parameter). Servers SHOULD support none and RS256.
    /// </summary>
    [Optional]
    [JsonPropertyName("request_object_signing_alg_values_supported")]
    public IEnumerable<string>? RequestObjectSigningAlgValuesSupported { get; set; }

    /// <summary>
    /// Boolean value specifying whether the OP supports use of the request parameter, with true indicating support. If omitted, the default value is false.
    /// </summary>
    [Optional]
    [JsonPropertyName("request_parameter_supported")]
    public bool? RequestParameterSupported { get; set; }

    /// <summary>
    /// Boolean value specifying whether the OP supports use of the request_uri parameter, with true indicating support. If omitted, the default value is false.
    /// </summary>
    [Optional]
    [JsonPropertyName("request_uri_parameter_supported")]
    public bool? RequestUriParameterSupported { get; set; }

    /// <summary>
    /// Boolean value specifying whether the OP requires use of the request_uri parameter. If omitted, the default value is false.
    /// </summary>
    [Optional]
    [JsonPropertyName("require_request_uri_registration")]
    public bool? RequireRequestUriRegistration { get; set; }

    /// <summary>
    /// A list of the OAuth 2.0 response_mode values that this OP supports. If omitted, the default for Dynamic OpenID Providers is ["query", "fragment"]
    /// </summary>
    [Optional]
    [JsonPropertyName("response_modes_supported")]
    public IEnumerable<string>? ResponseModesSupported { get; set; }

    /// <summary>
    /// A list of the OAuth 2.0 response_type values that this OP supports. Dynamic OpenID Providers MUST support the code, id_token, and the token id_token Response Type values
    /// </summary>
    [Optional]
    [JsonPropertyName("response_types_supported")]
    public IEnumerable<string>? ResponseTypesSupported { get; set; }

    /// <summary>
    /// A list of the OAuth 2.0 [RFC6749] scope values that this server supports. The server MUST support the openid scope value. Servers MAY choose not to advertise some supported scope values even when this parameter is used, although those defined in [OpenID.Core] SHOULD be listed, if supported. RECOMMENDED but not REQUIRED
    /// </summary>
    [Optional]
    [JsonPropertyName("scopes_supported")]
    public IEnumerable<string>? ScopesSupported { get; set; }

    /// <summary>
    /// URL of a page containing human-readable information that developers might want or need to know when using the OpenID Provider. In particular, if the OpenID Provider does not support Dynamic Client Registration, then information on how to register Clients needs to be provided in this documentation.
    /// </summary>
    [Optional]
    [JsonPropertyName("service_documentation")]
    public string? ServiceDocumentation { get; set; }

    /// <summary>
    /// A list of the Subject Identifier types that this OP supports. Valid types include pairwise and public
    /// </summary>
    [Optional]
    [JsonPropertyName("subject_types_supported")]
    public IEnumerable<string>? SubjectTypesSupported { get; set; }

    /// <summary>
    /// URL of the identity provider's OAuth 2.0 token endpoint where authorization codes are exchanged for access tokens. Must be a valid HTTPS URL. Required for authorization code flow but optional for implicit flow.
    /// </summary>
    [Optional]
    [JsonPropertyName("token_endpoint")]
    public string? TokenEndpoint { get; set; }

    /// <summary>
    /// JSON array containing a list of Client Authentication methods supported by this Token Endpoint. The options are client_secret_post, client_secret_basic, client_secret_jwt, and private_key_jwt, as described in Section 9 of OpenID Connect Core 1.0 [OpenID.Core]. Other authentication methods MAY be defined by extensions. If omitted, the default is client_secret_basic -- the HTTP Basic Authentication Scheme specified in Section 2.3.1 of OAuth 2.0 [RFC6749].
    /// </summary>
    [Optional]
    [JsonPropertyName("token_endpoint_auth_methods_supported")]
    public IEnumerable<string>? TokenEndpointAuthMethodsSupported { get; set; }

    /// <summary>
    /// JSON array containing a list of the JWS signing algorithms (alg values) supported by the Token Endpoint for the signature on the JWT [JWT] used to authenticate the Client at the Token Endpoint for the private_key_jwt and client_secret_jwt authentication methods. Servers SHOULD support RS256. The value none MUST NOT be used.
    /// </summary>
    [Optional]
    [JsonPropertyName("token_endpoint_auth_signing_alg_values_supported")]
    public IEnumerable<string>? TokenEndpointAuthSigningAlgValuesSupported { get; set; }

    /// <summary>
    /// Languages and scripts supported for the user interface, represented as a JSON array of BCP47 [RFC5646] language tag values.
    /// </summary>
    [Optional]
    [JsonPropertyName("ui_locales_supported")]
    public IEnumerable<string>? UiLocalesSupported { get; set; }

    /// <summary>
    /// JSON array containing a list of the JWE [JWE] encryption algorithms (alg values) [JWA] supported by the UserInfo Endpoint to encode the Claims in a JWT [JWT].
    /// </summary>
    [Optional]
    [JsonPropertyName("userinfo_encryption_alg_values_supported")]
    public IEnumerable<string>? UserinfoEncryptionAlgValuesSupported { get; set; }

    /// <summary>
    /// JSON array containing a list of the JWE encryption algorithms (enc values) [JWA] supported by the UserInfo Endpoint to encode the Claims in a JWT [JWT].
    /// </summary>
    [Optional]
    [JsonPropertyName("userinfo_encryption_enc_values_supported")]
    public IEnumerable<string>? UserinfoEncryptionEncValuesSupported { get; set; }

    /// <summary>
    /// Optional URL of the identity provider's UserInfo endpoint. When configured with attribute mapping, Auth0 calls this endpoint to retrieve additional user profile claims using the access token.
    /// </summary>
    [Optional]
    [JsonPropertyName("userinfo_endpoint")]
    public string? UserinfoEndpoint { get; set; }

    /// <summary>
    /// JSON array containing a list of the JWS [JWS] signing algorithms (alg values) [JWA] supported by the UserInfo Endpoint to encode the Claims in a JWT [JWT]. The value none MAY be included.
    /// </summary>
    [Optional]
    [JsonPropertyName("userinfo_signing_alg_values_supported")]
    public IEnumerable<string>? UserinfoSigningAlgValuesSupported { get; set; }

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

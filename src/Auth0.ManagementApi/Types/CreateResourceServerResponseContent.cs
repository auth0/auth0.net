using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record CreateResourceServerResponseContent : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// ID of the API (resource server).
    /// </summary>
    [Optional]
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// Friendly name for this resource server. Can not contain `&lt;` or `&gt;` characters.
    /// </summary>
    [Optional]
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Whether this is an Auth0 system API (true) or a custom API (false).
    /// </summary>
    [Optional]
    [JsonPropertyName("is_system")]
    public bool? IsSystem { get; set; }

    /// <summary>
    /// Unique identifier for the API used as the audience parameter on authorization calls. Can not be changed once set.
    /// </summary>
    [Optional]
    [JsonPropertyName("identifier")]
    public string? Identifier { get; set; }

    /// <summary>
    /// List of permissions (scopes) that this API uses.
    /// </summary>
    [Optional]
    [JsonPropertyName("scopes")]
    public IEnumerable<ResourceServerScope>? Scopes { get; set; }

    [Optional]
    [JsonPropertyName("signing_alg")]
    public SigningAlgorithmEnum? SigningAlg { get; set; }

    /// <summary>
    /// Secret used to sign tokens when using symmetric algorithms (HS256).
    /// </summary>
    [Optional]
    [JsonPropertyName("signing_secret")]
    public string? SigningSecret { get; set; }

    /// <summary>
    /// Whether refresh tokens can be issued for this API (true) or not (false).
    /// </summary>
    [Optional]
    [JsonPropertyName("allow_offline_access")]
    public bool? AllowOfflineAccess { get; set; }

    /// <summary>
    /// Whether to skip user consent for applications flagged as first party (true) or not (false).
    /// </summary>
    [Optional]
    [JsonPropertyName("skip_consent_for_verifiable_first_party_clients")]
    public bool? SkipConsentForVerifiableFirstPartyClients { get; set; }

    /// <summary>
    /// Expiration value (in seconds) for access tokens issued for this API from the token endpoint.
    /// </summary>
    [Optional]
    [JsonPropertyName("token_lifetime")]
    public int? TokenLifetime { get; set; }

    /// <summary>
    /// Expiration value (in seconds) for access tokens issued for this API via Implicit or Hybrid Flows. Cannot be greater than the `token_lifetime` value.
    /// </summary>
    [Optional]
    [JsonPropertyName("token_lifetime_for_web")]
    public int? TokenLifetimeForWeb { get; set; }

    /// <summary>
    /// Whether authorization polices are enforced (true) or unenforced (false).
    /// </summary>
    [Optional]
    [JsonPropertyName("enforce_policies")]
    public bool? EnforcePolicies { get; set; }

    [Optional]
    [JsonPropertyName("token_dialect")]
    public ResourceServerTokenDialectResponseEnum? TokenDialect { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("token_encryption")]
    public Optional<ResourceServerTokenEncryption?> TokenEncryption { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("consent_policy")]
    public Optional<string?> ConsentPolicy { get; set; }

    [Optional]
    [JsonPropertyName("authorization_details")]
    public IEnumerable<object>? AuthorizationDetails { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("proof_of_possession")]
    public Optional<ResourceServerProofOfPossession?> ProofOfPossession { get; set; }

    [Optional]
    [JsonPropertyName("subject_type_authorization")]
    public ResourceServerSubjectTypeAuthorization? SubjectTypeAuthorization { get; set; }

    /// <summary>
    /// The client ID of the client that this resource server is linked to
    /// </summary>
    [Optional]
    [JsonPropertyName("client_id")]
    public string? ClientId { get; set; }

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

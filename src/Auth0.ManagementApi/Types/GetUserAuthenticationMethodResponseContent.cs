using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record GetUserAuthenticationMethodResponseContent : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The ID of the authentication method (auto generated)
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("type")]
    public required AuthenticationMethodTypeEnum Type { get; set; }

    /// <summary>
    /// The authentication method status
    /// </summary>
    [Optional]
    [JsonPropertyName("confirmed")]
    public bool? Confirmed { get; set; }

    /// <summary>
    /// A human-readable label to identify the authentication method
    /// </summary>
    [Optional]
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [Optional]
    [JsonPropertyName("authentication_methods")]
    public IEnumerable<UserAuthenticationMethodProperties>? AuthenticationMethods { get; set; }

    [Optional]
    [JsonPropertyName("preferred_authentication_method")]
    public PreferredAuthenticationMethodEnum? PreferredAuthenticationMethod { get; set; }

    /// <summary>
    /// The ID of a linked authentication method. Linked authentication methods will be deleted together.
    /// </summary>
    [Optional]
    [JsonPropertyName("link_id")]
    public string? LinkId { get; set; }

    /// <summary>
    /// Applies to phone authentication methods only. The destination phone number used to send verification codes via text and voice.
    /// </summary>
    [Optional]
    [JsonPropertyName("phone_number")]
    public string? PhoneNumber { get; set; }

    /// <summary>
    /// Applies to email and email-verification authentication methods only. The email address used to send verification messages.
    /// </summary>
    [Optional]
    [JsonPropertyName("email")]
    public string? Email { get; set; }

    /// <summary>
    /// Applies to webauthn authentication methods only. The ID of the generated credential.
    /// </summary>
    [Optional]
    [JsonPropertyName("key_id")]
    public string? KeyId { get; set; }

    /// <summary>
    /// Applies to webauthn authentication methods only. The public key.
    /// </summary>
    [Optional]
    [JsonPropertyName("public_key")]
    public string? PublicKey { get; set; }

    /// <summary>
    /// Authenticator creation date
    /// </summary>
    [JsonPropertyName("created_at")]
    public required DateTime CreatedAt { get; set; }

    /// <summary>
    /// Enrollment date
    /// </summary>
    [Optional]
    [JsonPropertyName("enrolled_at")]
    public DateTime? EnrolledAt { get; set; }

    /// <summary>
    /// Last authentication
    /// </summary>
    [Optional]
    [JsonPropertyName("last_auth_at")]
    public DateTime? LastAuthAt { get; set; }

    /// <summary>
    /// Applies to passkeys only. The kind of device the credential is stored on as defined by backup eligibility. "single_device" credentials cannot be backed up and synced to another device, "multi_device" credentials can be backed up if enabled by the end-user.
    /// </summary>
    [Optional]
    [JsonPropertyName("credential_device_type")]
    public string? CredentialDeviceType { get; set; }

    /// <summary>
    /// Applies to passkeys only. Whether the credential was backed up.
    /// </summary>
    [Optional]
    [JsonPropertyName("credential_backed_up")]
    public bool? CredentialBackedUp { get; set; }

    /// <summary>
    /// Applies to passkeys only. The ID of the user identity linked with the authentication method.
    /// </summary>
    [Optional]
    [JsonPropertyName("identity_user_id")]
    public string? IdentityUserId { get; set; }

    /// <summary>
    /// Applies to passkeys only. The user-agent of the browser used to create the passkey.
    /// </summary>
    [Optional]
    [JsonPropertyName("user_agent")]
    public string? UserAgent { get; set; }

    /// <summary>
    /// Applies to passkey authentication methods only. Authenticator Attestation Globally Unique Identifier.
    /// </summary>
    [Optional]
    [JsonPropertyName("aaguid")]
    public string? Aaguid { get; set; }

    /// <summary>
    /// Applies to webauthn/passkey authentication methods only. The credential's relying party identifier.
    /// </summary>
    [Optional]
    [JsonPropertyName("relying_party_identifier")]
    public string? RelyingPartyIdentifier { get; set; }

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

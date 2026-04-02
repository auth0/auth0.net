using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi.Users;

[Serializable]
public record CreateUserAuthenticationMethodRequestContent
{
    [JsonPropertyName("type")]
    public required CreatedUserAuthenticationMethodTypeEnum Type { get; set; }

    /// <summary>
    /// A human-readable label to identify the authentication method.
    /// </summary>
    [Optional]
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Base32 encoded secret for TOTP generation.
    /// </summary>
    [Optional]
    [JsonPropertyName("totp_secret")]
    public string? TotpSecret { get; set; }

    /// <summary>
    /// Applies to phone authentication methods only. The destination phone number used to send verification codes via text and voice.
    /// </summary>
    [Optional]
    [JsonPropertyName("phone_number")]
    public string? PhoneNumber { get; set; }

    /// <summary>
    /// Applies to email authentication methods only. The email address used to send verification messages.
    /// </summary>
    [Optional]
    [JsonPropertyName("email")]
    public string? Email { get; set; }

    [Optional]
    [JsonPropertyName("preferred_authentication_method")]
    public PreferredAuthenticationMethodEnum? PreferredAuthenticationMethod { get; set; }

    /// <summary>
    /// Applies to webauthn authentication methods only. The id of the credential.
    /// </summary>
    [Optional]
    [JsonPropertyName("key_id")]
    public string? KeyId { get; set; }

    /// <summary>
    /// Applies to webauthn authentication methods only. The public key, which is encoded as base64.
    /// </summary>
    [Optional]
    [JsonPropertyName("public_key")]
    public string? PublicKey { get; set; }

    /// <summary>
    /// Applies to webauthn authentication methods only. The relying party identifier.
    /// </summary>
    [Optional]
    [JsonPropertyName("relying_party_identifier")]
    public string? RelyingPartyIdentifier { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

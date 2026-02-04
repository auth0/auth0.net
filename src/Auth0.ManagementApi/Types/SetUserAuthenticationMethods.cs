using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record SetUserAuthenticationMethods : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("type")]
    public required AuthenticationTypeEnum Type { get; set; }

    [Optional]
    [JsonPropertyName("preferred_authentication_method")]
    public PreferredAuthenticationMethodEnum? PreferredAuthenticationMethod { get; set; }

    /// <summary>
    /// AA human-readable label to identify the authentication method.
    /// </summary>
    [Optional]
    [JsonPropertyName("name")]
    public string? Name { get; set; }

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

    /// <summary>
    /// Applies to totp authentication methods only. The base32 encoded secret for TOTP generation.
    /// </summary>
    [Optional]
    [JsonPropertyName("totp_secret")]
    public string? TotpSecret { get; set; }

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

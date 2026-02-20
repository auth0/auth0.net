using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

/// <summary>
/// Options for enabling authentication methods.
/// </summary>
[Serializable]
public record ConnectionAuthenticationMethods : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [Optional]
    [JsonPropertyName("password")]
    public ConnectionPasswordAuthenticationMethod? Password { get; set; }

    [Optional]
    [JsonPropertyName("passkey")]
    public ConnectionPasskeyAuthenticationMethod? Passkey { get; set; }

    [Optional]
    [JsonPropertyName("email_otp")]
    public ConnectionEmailOtpAuthenticationMethod? EmailOtp { get; set; }

    [Optional]
    [JsonPropertyName("phone_otp")]
    public ConnectionPhoneOtpAuthenticationMethod? PhoneOtp { get; set; }

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

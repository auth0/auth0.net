using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// OTP settings for a delivery channel.
/// </summary>
[Serializable]
public record ConnectionOtpChannelSettings : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Number of digits in the generated one-time password.
    /// </summary>
    [Optional]
    [JsonPropertyName("otp_length")]
    public int? OtpLength { get; set; }

    /// <summary>
    /// Number of seconds before the one-time password expires.
    /// </summary>
    [Optional]
    [JsonPropertyName("otp_expiry")]
    public int? OtpExpiry { get; set; }

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

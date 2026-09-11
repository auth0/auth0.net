using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi.Guardian.Factors;

[Serializable]
public record SetPhoneFactorSettingsRequestContent
{
    /// <summary>
    /// The length of the OTP code.
    /// </summary>
    [JsonPropertyName("otp_length")]
    public required int OtpLength { get; set; }

    /// <summary>
    /// The OTP expiration time in seconds.
    /// </summary>
    [JsonPropertyName("otp_expiration_time")]
    public required int OtpExpirationTime { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

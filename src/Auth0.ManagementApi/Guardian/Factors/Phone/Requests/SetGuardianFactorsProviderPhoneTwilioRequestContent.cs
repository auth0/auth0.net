using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi.Guardian.Factors;

[Serializable]
public record SetGuardianFactorsProviderPhoneTwilioRequestContent
{
    /// <summary>
    /// From number
    /// </summary>
    [Nullable, Optional]
    [JsonPropertyName("from")]
    public Optional<string?> From { get; set; }

    /// <summary>
    /// Copilot SID
    /// </summary>
    [Nullable, Optional]
    [JsonPropertyName("messaging_service_sid")]
    public Optional<string?> MessagingServiceSid { get; set; }

    /// <summary>
    /// Twilio Authentication token
    /// </summary>
    [Nullable, Optional]
    [JsonPropertyName("auth_token")]
    public Optional<string?> AuthToken { get; set; }

    /// <summary>
    /// Twilio SID
    /// </summary>
    [Nullable, Optional]
    [JsonPropertyName("sid")]
    public Optional<string?> Sid { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

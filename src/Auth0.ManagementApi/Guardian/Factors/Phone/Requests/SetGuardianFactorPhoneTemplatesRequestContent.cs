using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi.Guardian.Factors;

[Serializable]
public record SetGuardianFactorPhoneTemplatesRequestContent
{
    /// <summary>
    /// Message sent to the user when they are invited to enroll with a phone number.
    /// </summary>
    [JsonPropertyName("enrollment_message")]
    public required string EnrollmentMessage { get; set; }

    /// <summary>
    /// Message sent to the user when they are prompted to verify their account.
    /// </summary>
    [JsonPropertyName("verification_message")]
    public required string VerificationMessage { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

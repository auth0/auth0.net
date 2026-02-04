using System.Text.Json.Serialization;
using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Guardian;

[Serializable]
public record CreateGuardianEnrollmentTicketRequestContent
{
    /// <summary>
    /// user_id for the enrollment ticket
    /// </summary>
    [JsonPropertyName("user_id")]
    public required string UserId { get; set; }

    /// <summary>
    /// alternate email to which the enrollment email will be sent. Optional - by default, the email will be sent to the user's default address
    /// </summary>
    [Optional]
    [JsonPropertyName("email")]
    public string? Email { get; set; }

    /// <summary>
    /// Send an email to the user to start the enrollment
    /// </summary>
    [Optional]
    [JsonPropertyName("send_mail")]
    public bool? SendMail { get; set; }

    /// <summary>
    /// Optional. Specify the locale of the enrollment email. Used with send_email.
    /// </summary>
    [Optional]
    [JsonPropertyName("email_locale")]
    public string? EmailLocale { get; set; }

    [Optional]
    [JsonPropertyName("factor")]
    public GuardianEnrollmentFactorEnum? Factor { get; set; }

    /// <summary>
    /// Optional. Allows a user who has previously enrolled in MFA to enroll with additional factors.<br />Note: Parameter can only be used with Universal Login; it cannot be used with Classic Login or custom MFA pages.
    /// </summary>
    [Optional]
    [JsonPropertyName("allow_multiple_enrollments")]
    public bool? AllowMultipleEnrollments { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

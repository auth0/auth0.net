using Auth0.ManagementApi;

namespace Auth0.ManagementApi.Guardian;

public partial interface IEnrollmentsClient
{
    /// <summary>
    /// Create a <a href="https://auth0.com/docs/secure/multi-factor-authentication/auth0-guardian/create-custom-enrollment-tickets">multi-factor authentication (MFA) enrollment ticket</a>, and optionally send an email with the created ticket, to a given user.
    /// Create a <a href="https://auth0.com/docs/secure/multi-factor-authentication/auth0-guardian/create-custom-enrollment-tickets">multi-factor authentication (MFA) enrollment ticket</a>, and optionally send an email with the created ticket to a given user. Enrollment tickets can specify which factor users must enroll with or allow existing MFA users to enroll in additional factors.<br/>
    ///
    /// Note: Users cannot enroll in Email as a factor through custom enrollment tickets.
    /// </summary>
    WithRawResponseTask<CreateGuardianEnrollmentTicketResponseContent> CreateTicketAsync(
        CreateGuardianEnrollmentTicketRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve details, such as status and type, for a specific multi-factor authentication enrollment registered to a user account.
    /// </summary>
    WithRawResponseTask<GetGuardianEnrollmentResponseContent> GetAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Remove a specific multi-factor authentication (MFA) enrollment from a user's account. This allows the user to re-enroll with MFA. For more information, review <a href="https://auth0.com/docs/secure/multi-factor-authentication/reset-user-mfa">Reset User Multi-Factor Authentication and Recovery Codes</a>.
    /// </summary>
    Task DeleteAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}

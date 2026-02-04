namespace Auth0.ManagementApi;

public partial interface ITicketsClient
{
    /// <summary>
    /// Create an email verification ticket for a given user. An email verification ticket is a generated URL that the user can consume to verify their email address.
    /// </summary>
    WithRawResponseTask<VerifyEmailTicketResponseContent> VerifyEmailAsync(
        VerifyEmailTicketRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create a password change ticket for a given user. A password change ticket is a generated URL that the user can consume to start a reset password flow.
    ///
    /// Note: This endpoint does not verify the given user’s identity. If you call this endpoint within your application, you must design your application to verify the user’s identity.
    /// </summary>
    WithRawResponseTask<ChangePasswordTicketResponseContent> ChangePasswordAsync(
        ChangePasswordTicketRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}

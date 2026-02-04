using Auth0.ManagementApi;

namespace Auth0.ManagementApi.Jobs;

public partial interface IVerificationEmailClient
{
    /// <summary>
    /// Send an email to the specified user that asks them to click a link to <a href="https://auth0.com/docs/email/custom#verification-email">verify their email address</a>.
    ///
    /// Note: You must have the `Status` toggle enabled for the verification email template for the email to be sent.
    /// </summary>
    WithRawResponseTask<CreateVerificationEmailResponseContent> CreateAsync(
        CreateVerificationEmailRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}

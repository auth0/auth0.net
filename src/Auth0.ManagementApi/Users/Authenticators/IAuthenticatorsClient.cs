using Auth0.ManagementApi;

namespace Auth0.ManagementApi.Users;

public partial interface IAuthenticatorsClient
{
    /// <summary>
    /// Remove all authenticators registered to a given user ID, such as OTP, email, phone, and push-notification. This action cannot be undone. For more information, review <see href="https://auth0.com/docs/secure/multi-factor-authentication/manage-mfa-auth0-apis/manage-authentication-methods-with-management-api">Manage Authentication Methods with Management API</see>.
    /// </summary>
    Task DeleteAllAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}

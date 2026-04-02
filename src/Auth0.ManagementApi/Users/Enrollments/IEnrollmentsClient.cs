using Auth0.ManagementApi;

namespace Auth0.ManagementApi.Users;

public partial interface IEnrollmentsClient
{
    /// <summary>
    /// Retrieve the first <see href="https://auth0.com/docs/secure/multi-factor-authentication/multi-factor-authentication-factors">multi-factor authentication</see> enrollment that a specific user has confirmed.
    /// </summary>
    WithRawResponseTask<IEnumerable<UsersEnrollment>> GetAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}

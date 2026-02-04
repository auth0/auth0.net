using Auth0.ManagementApi;

namespace Auth0.ManagementApi.Users;

public partial interface IMultifactorClient
{
    /// <summary>
    /// Invalidate all remembered browsers across all <a href="https://auth0.com/docs/multifactor-authentication">authentication factors</a> for a user.
    /// </summary>
    Task InvalidateRememberBrowserAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Remove a <a href="https://auth0.com/docs/multifactor-authentication">multifactor</a> authentication configuration from a user's account. This forces the user to manually reconfigure the multi-factor provider.
    /// </summary>
    Task DeleteProviderAsync(
        string id,
        UserMultifactorProviderEnum provider,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}

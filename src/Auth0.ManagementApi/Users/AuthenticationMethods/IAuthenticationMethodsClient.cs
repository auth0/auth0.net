using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Users;

public partial interface IAuthenticationMethodsClient
{
    /// <summary>
    /// Retrieve detailed list of authentication methods associated with a specified user.
    /// </summary>
    Task<Pager<UserAuthenticationMethod>> ListAsync(
        string id,
        ListUserAuthenticationMethodsRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create an authentication method. Authentication methods created via this endpoint will be auto confirmed and should already have verification completed.
    /// </summary>
    WithRawResponseTask<CreateUserAuthenticationMethodResponseContent> CreateAsync(
        string id,
        CreateUserAuthenticationMethodRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Replace the specified user <a href="https://auth0.com/docs/secure/multi-factor-authentication/multi-factor-authentication-factors"> authentication methods</a> with supplied values.
    ///
    ///     <b>Note</b>: Authentication methods supplied through this action do not iterate on existing methods. Instead, any methods passed will overwrite the user&#8217s existing settings.
    /// </summary>
    WithRawResponseTask<IEnumerable<SetUserAuthenticationMethodResponseContent>> SetAsync(
        string id,
        IEnumerable<SetUserAuthenticationMethods> request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Remove all authentication methods (i.e., enrolled MFA factors) from the specified user account. This action cannot be undone.
    /// </summary>
    Task DeleteAllAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<GetUserAuthenticationMethodResponseContent> GetAsync(
        string id,
        string authenticationMethodId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Remove the authentication method with the given ID from the specified user. For more information, review <a href="https://auth0.com/docs/secure/multi-factor-authentication/manage-mfa-auth0-apis/manage-authentication-methods-with-management-api">Manage Authentication Methods with Management API</a>.
    /// </summary>
    Task DeleteAsync(
        string id,
        string authenticationMethodId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Modify the authentication method with the given ID from the specified user. For more information, review <a href="https://auth0.com/docs/secure/multi-factor-authentication/manage-mfa-auth0-apis/manage-authentication-methods-with-management-api">Manage Authentication Methods with Management API</a>.
    /// </summary>
    WithRawResponseTask<UpdateUserAuthenticationMethodResponseContent> UpdateAsync(
        string id,
        string authenticationMethodId,
        UpdateUserAuthenticationMethodRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}

using Auth0.ManagementApi.Core;
using Auth0.ManagementApi.Users;

namespace Auth0.ManagementApi;

public partial interface IUsersClient
{
    public IAuthenticationMethodsClient AuthenticationMethods { get; }
    public IAuthenticatorsClient Authenticators { get; }
    public IConnectedAccountsClient ConnectedAccounts { get; }
    public Auth0.ManagementApi.Users.IEnrollmentsClient Enrollments { get; }
    public IFederatedConnectionsTokensetsClient FederatedConnectionsTokensets { get; }
    public Auth0.ManagementApi.Users.IGroupsClient Groups { get; }
    public IIdentitiesClient Identities { get; }
    public Auth0.ManagementApi.Users.ILogsClient Logs { get; }
    public IMultifactorClient Multifactor { get; }
    public Auth0.ManagementApi.Users.IOrganizationsClient Organizations { get; }
    public Auth0.ManagementApi.Users.IPermissionsClient Permissions { get; }
    public Auth0.ManagementApi.Users.IRiskAssessmentsClient RiskAssessments { get; }
    public Auth0.ManagementApi.Users.IRolesClient Roles { get; }
    public IRefreshTokenClient RefreshToken { get; }
    public Auth0.ManagementApi.Users.ISessionsClient Sessions { get; }

    /// <summary>
    /// Retrieve details of users. It is possible to:
    ///
    /// - Specify a search criteria for users
    /// - Sort the users to be returned
    /// - Select the fields to be returned
    /// - Specify the number of users to retrieve per page and the page index
    ///
    /// The <c>q</c> query parameter can be used to get users that match the specified criteria <see href="https://auth0.com/docs/users/search/v3/query-syntax">using query string syntax.</see>
    ///
    /// <see href="https://auth0.com/docs/users/search/v3">Learn more about searching for users.</see>
    ///
    /// Read about <see href="https://auth0.com/docs/users/search/best-practices">best practices</see> when working with the API endpoints for retrieving users.
    ///
    /// Auth0 limits the number of users you can return. If you exceed this threshold, please redefine your search, use the <see href="https://auth0.com/docs/api/management/v2#!/Jobs/post_users_exports">export job</see>, or the <see href="https://auth0.com/docs/extensions/user-import-export">User Import / Export</see> extension.
    /// </summary>
    Task<Pager<UserResponseSchema>> ListAsync(
        ListUsersRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create a new user for a given <see href="https://auth0.com/docs/connections/database">database</see> or <see href="https://auth0.com/docs/connections/passwordless">passwordless</see> connection.
    ///
    /// Note: <c>connection</c> is required but other parameters such as <c>email</c> and <c>password</c> are dependent upon the type of connection.
    /// </summary>
    WithRawResponseTask<CreateUserResponseContent> CreateAsync(
        CreateUserRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Find users by email. If Auth0 is the identity provider (idP), the email address associated with a user is saved in lower case, regardless of how you initially provided it.
    ///
    /// For example, if you register a user as JohnSmith@example.com, Auth0 saves the user's email as johnsmith@example.com.
    ///
    /// Therefore, when using this endpoint, make sure that you are searching for users via email addresses using the correct case.
    /// </summary>
    WithRawResponseTask<IEnumerable<UserResponseSchema>> ListUsersByEmailAsync(
        ListUsersByEmailRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve user details. A list of fields to include or exclude may also be specified. For more information, see <see href="https://auth0.com/docs/manage-users/user-search/retrieve-users-with-get-users-endpoint">Retrieve Users with the Get Users Endpoint</see>.
    /// </summary>
    WithRawResponseTask<GetUserResponseContent> GetAsync(
        string id,
        GetUserRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a user by user ID. This action cannot be undone. For Auth0 Dashboard instructions, see <see href="https://auth0.com/docs/manage-users/user-accounts/delete-users">Delete Users</see>.
    /// </summary>
    Task DeleteAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update a user.
    ///
    /// These are the attributes that can be updated at the root level:
    ///
    /// <list type="bullet">
    ///     <item><description>app_metadata</description></item>
    ///     <item><description>blocked</description></item>
    ///     <item><description>email</description></item>
    ///     <item><description>email_verified</description></item>
    ///     <item><description>family_name</description></item>
    ///     <item><description>given_name</description></item>
    ///     <item><description>name</description></item>
    ///     <item><description>nickname</description></item>
    ///     <item><description>password</description></item>
    ///     <item><description>phone_number</description></item>
    ///     <item><description>phone_verified</description></item>
    ///     <item><description>picture</description></item>
    ///     <item><description>username</description></item>
    ///     <item><description>user_metadata</description></item>
    ///     <item><description>verify_email</description></item>
    /// </list>
    ///
    /// Some considerations:
    /// <list type="bullet">
    ///     <item><description>The properties of the new object will replace the old ones.</description></item>
    ///     <item><description>The metadata fields are an exception to this rule (<c>user_metadata</c> and <c>app_metadata</c>). These properties are merged instead of being replaced but be careful, the merge only occurs on the first level.</description></item>
    ///     <item><description>If you are updating <c>email</c>, <c>email_verified</c>, <c>phone_number</c>, <c>phone_verified</c>, <c>username</c> or <c>password</c> of a secondary identity, you need to specify the <c>connection</c> property too.</description></item>
    ///     <item><description>If you are updating <c>email</c> or <c>phone_number</c> you can specify, optionally, the <c>client_id</c> property.</description></item>
    ///     <item><description>Updating <c>email_verified</c> is not supported for enterprise and passwordless sms connections.</description></item>
    ///     <item><description>Updating the <c>blocked</c> to <c>false</c> does not affect the user's blocked state from an excessive amount of incorrectly provided credentials. Use the "Unblock a user" endpoint from the "User Blocks" API to change the user's state.</description></item>
    ///     <item><description>Supported attributes can be unset by supplying <c>null</c> as the value.</description></item>
    /// </list>
    ///
    /// <para>Updating a field (non-metadata property)</para>
    /// To mark the email address of a user as verified, the body to send should be:
    /// <code>{ "email_verified": true }</code>
    ///
    /// <para>Updating a user metadata root property</para>Let's assume that our test user has the following <c>user_metadata</c>:
    /// <code>{ "user_metadata" : { "profileCode": 1479 } }</code>
    ///
    /// To add the field <c>addresses</c> the body to send should be:
    /// <code>{ "user_metadata" : { "addresses": {"work_address": "100 Industrial Way"} }}</code>
    ///
    /// The modified object ends up with the following <c>user_metadata</c> property:<code>{
    ///   "user_metadata": {
    ///     "profileCode": 1479,
    ///     "addresses": { "work_address": "100 Industrial Way" }
    ///   }
    /// }</code>
    ///
    /// <para>Updating an inner user metadata property</para>If there's existing user metadata to which we want to add  <c>"home_address": "742 Evergreen Terrace"</c> (using the <c>addresses</c> property) we should send the whole <c>addresses</c> object. Since this is a first-level object, the object will be merged in, but its own properties will not be. The body to send should be:
    /// <code>{
    ///   "user_metadata": {
    ///     "addresses": {
    ///       "work_address": "100 Industrial Way",
    ///       "home_address": "742 Evergreen Terrace"
    ///     }
    ///   }
    /// }</code>
    ///
    /// The modified object ends up with the following <c>user_metadata</c> property:
    /// <code>{
    ///   "user_metadata": {
    ///     "profileCode": 1479,
    ///     "addresses": {
    ///       "work_address": "100 Industrial Way",
    ///       "home_address": "742 Evergreen Terrace"
    ///     }
    ///   }
    /// }</code>
    /// </summary>
    WithRawResponseTask<UpdateUserResponseContent> UpdateAsync(
        string id,
        UpdateUserRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Remove an existing multi-factor authentication (MFA) <see href="https://auth0.com/docs/secure/multi-factor-authentication/reset-user-mfa">recovery code</see> and generate a new one. If a user cannot access the original device or account used for MFA enrollment, they can use a recovery code to authenticate.
    /// </summary>
    WithRawResponseTask<RegenerateUsersRecoveryCodeResponseContent> RegenerateRecoveryCodeAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Revokes selected resources related to a user (sessions, refresh tokens, ...).
    /// </summary>
    Task RevokeAccessAsync(
        string id,
        RevokeUserAccessRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}

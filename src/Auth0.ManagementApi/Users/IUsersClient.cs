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
    ///  &lt;!-- only v3 is available --&gt;
    /// The <code>q</code> query parameter can be used to get users that match the specified criteria <a href="https://auth0.com/docs/users/search/v3/query-syntax">using query string syntax.</a>
    ///
    /// <a href="https://auth0.com/docs/users/search/v3">Learn more about searching for users.</a>
    ///
    /// Read about <a href="https://auth0.com/docs/users/search/best-practices">best practices</a> when working with the API endpoints for retrieving users.
    ///
    /// Auth0 limits the number of users you can return. If you exceed this threshold, please redefine your search, use the <a href="https://auth0.com/docs/api/management/v2#!/Jobs/post_users_exports">export job</a>, or the <a href="https://auth0.com/docs/extensions/user-import-export">User Import / Export</a> extension.
    /// </summary>
    Task<Pager<UserResponseSchema>> ListAsync(
        ListUsersRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create a new user for a given <a href="https://auth0.com/docs/connections/database">database</a> or <a href="https://auth0.com/docs/connections/passwordless">passwordless</a> connection.
    ///
    /// Note: <code>connection</code> is required but other parameters such as <code>email</code> and <code>password</code> are dependent upon the type of connection.
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
    /// Retrieve user details. A list of fields to include or exclude may also be specified. For more information, see <a href="https://auth0.com/docs/manage-users/user-search/retrieve-users-with-get-users-endpoint">Retrieve Users with the Get Users Endpoint</a>.
    /// </summary>
    WithRawResponseTask<GetUserResponseContent> GetAsync(
        string id,
        GetUserRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a user by user ID. This action cannot be undone. For Auth0 Dashboard instructions, see <a href="https://auth0.com/docs/manage-users/user-accounts/delete-users">Delete Users</a>.
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
    /// <ul>
    ///     <li>app_metadata</li>
    ///     <li>blocked</li>
    ///     <li>email</li>
    ///     <li>email_verified</li>
    ///     <li>family_name</li>
    ///     <li>given_name</li>
    ///     <li>name</li>
    ///     <li>nickname</li>
    ///     <li>password</li>
    ///     <li>phone_number</li>
    ///     <li>phone_verified</li>
    ///     <li>picture</li>
    ///     <li>username</li>
    ///     <li>user_metadata</li>
    ///     <li>verify_email</li>
    /// </ul>
    ///
    /// Some considerations:
    /// <ul>
    ///     <li>The properties of the new object will replace the old ones.</li>
    ///     <li>The metadata fields are an exception to this rule (<code>user_metadata</code> and <code>app_metadata</code>). These properties are merged instead of being replaced but be careful, the merge only occurs on the first level.</li>
    ///     <li>If you are updating <code>email</code>, <code>email_verified</code>, <code>phone_number</code>, <code>phone_verified</code>, <code>username</code> or <code>password</code> of a secondary identity, you need to specify the <code>connection</code> property too.</li>
    ///     <li>If you are updating <code>email</code> or <code>phone_number</code> you can specify, optionally, the <code>client_id</code> property.</li>
    ///     <li>Updating <code>email_verified</code> is not supported for enterprise and passwordless sms connections.</li>
    ///     <li>Updating the <code>blocked</code> to <code>false</code> does not affect the user's blocked state from an excessive amount of incorrectly provided credentials. Use the "Unblock a user" endpoint from the "User Blocks" API to change the user's state.</li>
    ///     <li>Supported attributes can be unset by supplying <code>null</code> as the value.</li>
    /// </ul>
    ///
    /// &lt;h5&gt;Updating a field (non-metadata property)&lt;/h5&gt;
    /// To mark the email address of a user as verified, the body to send should be:
    /// <pre><code>{ "email_verified": true }</code></pre>
    ///
    /// &lt;h5&gt;Updating a user metadata root property&lt;/h5&gt;Let's assume that our test user has the following <code>user_metadata</code>:
    /// <pre><code>{ "user_metadata" : { "profileCode": 1479 } }</code></pre>
    ///
    /// To add the field <code>addresses</code> the body to send should be:
    /// <pre><code>{ "user_metadata" : { "addresses": {"work_address": "100 Industrial Way"} }}</code></pre>
    ///
    /// The modified object ends up with the following <code>user_metadata</code> property:<pre><code>{
    ///   "user_metadata": {
    ///     "profileCode": 1479,
    ///     "addresses": { "work_address": "100 Industrial Way" }
    ///   }
    /// }</code></pre>
    ///
    /// &lt;h5&gt;Updating an inner user metadata property&lt;/h5&gt;If there's existing user metadata to which we want to add  <code>"home_address": "742 Evergreen Terrace"</code> (using the <code>addresses</code> property) we should send the whole <code>addresses</code> object. Since this is a first-level object, the object will be merged in, but its own properties will not be. The body to send should be:
    /// <pre><code>{
    ///   "user_metadata": {
    ///     "addresses": {
    ///       "work_address": "100 Industrial Way",
    ///       "home_address": "742 Evergreen Terrace"
    ///     }
    ///   }
    /// }</code></pre>
    ///
    /// The modified object ends up with the following <code>user_metadata</code> property:
    /// <pre><code>{
    ///   "user_metadata": {
    ///     "profileCode": 1479,
    ///     "addresses": {
    ///       "work_address": "100 Industrial Way",
    ///       "home_address": "742 Evergreen Terrace"
    ///     }
    ///   }
    /// }</code></pre>
    /// </summary>
    WithRawResponseTask<UpdateUserResponseContent> UpdateAsync(
        string id,
        UpdateUserRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Remove an existing multi-factor authentication (MFA) <a href="https://auth0.com/docs/secure/multi-factor-authentication/reset-user-mfa">recovery code</a> and generate a new one. If a user cannot access the original device or account used for MFA enrollment, they can use a recovery code to authenticate.
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

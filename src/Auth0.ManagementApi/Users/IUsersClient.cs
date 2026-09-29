using Auth0.ManagementApi.Core;
using Auth0.ManagementApi.Users;

namespace Auth0.ManagementApi;

public partial interface IUsersClient
{
    public IAuthenticationMethodsClient AuthenticationMethods { get; }
    public IAuthenticatorsClient Authenticators { get; }
    public IConnectedAccountsClient ConnectedAccounts { get; }
    public IEffectivePermissionsClient EffectivePermissions { get; }
    public Auth0.ManagementApi.Users.IEffectiveRolesClient EffectiveRoles { get; }
    public Auth0.ManagementApi.Users.IEnrollmentsClient Enrollments { get; }
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
    /// This endpoint retrieves details of users. It's best suited to interactive, best-effort search and lookups where slightly stale results are acceptable. With it, you can:
    ///
    /// - Specify search criteria for users
    /// - Sort the users to be returned
    /// - Select the fields to be returned
    /// - Specify the number of users to retrieve per page and the page index
    ///
    /// This endpoint is **not suited for use in critical paths**. It is eventually consistent and runs under a short (~2 second) query time limit, so results can be stale and heavy queries can return a 503.
    ///
    /// - Do not use this endpoint for authentication, account linking, or logic inside login-flow Actions. Instead, [look users up directly by ID or email](https://auth0.com/docs/manage-users/user-search/get-users-by-id-or-email#management-api) to get their current state.
    /// - Do not use this endpoint to keep an external system in sync with user data. Instead, subscribe to [Event Streams](https://auth0.com/docs/customize/events/sync-data-across-systems) to receive every change as it happens.
    /// - Do not use this endpoint to enumerate or export your entire user base. Instead, run a [bulk user export](https://auth0.com/docs/manage-users/user-migration/bulk-user-exports) to retrieve the full set.
    ///
    /// Use the `q` query parameter to match users with [query string syntax](https://auth0.com/docs/manage-users/user-search/user-search-query-syntax). For full instructions and guidance, see [How to List and Search Users](https://auth0.com/docs/manage-users/user-search/list-and-search-users).
    ///
    /// For efficient queries, prefer indexed top-level fields and exact matches. Certain kinds of queries can be slow and may time out, such as filtering on freeform or multi-value fields (like user-defined attributes in `app_metadata` or `user_metadata`) or using leading wildcards.
    /// </summary>
    Task<Pager<UserResponseSchema>> ListAsync(
        ListUsersRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create a new user for a given [database](https://auth0.com/docs/connections/database) or [passwordless](https://auth0.com/docs/connections/passwordless) connection.
    ///
    /// Note: `connection` is required but other parameters such as `email` and `password` are dependent upon the type of connection.
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
    /// Retrieve user details. A list of fields to include or exclude may also be specified. For more information, see [Retrieve Users with the Get Users Endpoint](https://auth0.com/docs/manage-users/user-search/retrieve-users-with-get-users-endpoint).
    /// </summary>
    WithRawResponseTask<GetUserResponseContent> GetAsync(
        string id,
        GetUserRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a user by user ID. This action cannot be undone. For Auth0 Dashboard instructions, see [Delete Users](https://auth0.com/docs/manage-users/user-accounts/delete-users).
    /// </summary>
    WithRawResponseTask DeleteAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update a user.
    ///
    /// These are the attributes that can be updated at the root level:
    ///
    /// - app_metadata
    /// - blocked
    /// - email
    /// - email_verified
    /// - family_name
    /// - given_name
    /// - name
    /// - nickname
    /// - password
    /// - phone_number
    /// - phone_verified
    /// - picture
    /// - username
    /// - user_metadata
    /// - verify_email
    ///
    /// Some considerations:
    ///
    /// - The properties of the new object will replace the old ones.
    /// - The metadata fields are an exception to this rule (`user_metadata` and `app_metadata`). These properties are merged instead of being replaced but be careful, the merge only occurs on the first level.
    /// - If you are updating `email`, `email_verified`, `phone_number`, `phone_verified`, `username` or `password` of a secondary identity, you need to specify the `connection` property too.
    /// - If you are updating `email` or `phone_number` you can specify, optionally, the `client_id` property.
    /// - Updating `email_verified` is not supported for enterprise and passwordless sms connections.
    /// - Updating the `blocked` to `false` does not affect the user's blocked state from an excessive amount of incorrectly provided credentials. Use the "Unblock a user" endpoint from the "User Blocks" API to change the user's state.
    /// - Supported attributes can be unset by supplying `null` as the value.
    ///
    /// **Updating a field (non-metadata property)**
    ///
    /// To mark the email address of a user as verified, the body to send should be:
    ///
    /// ```json
    /// { "email_verified": true }
    /// ```
    ///
    /// **Updating a user metadata root property**
    ///
    /// Let's assume that our test user has the following `user_metadata`:
    ///
    /// ```json
    /// { "user_metadata" : { "profileCode": 1479 } }
    /// ```
    ///
    /// To add the field `addresses` the body to send should be:
    ///
    /// ```json
    /// { "user_metadata" : { "addresses": {"work_address": "100 Industrial Way"} }}
    /// ```
    ///
    /// The modified object ends up with the following `user_metadata` property:
    ///
    /// ```json
    /// {
    ///   "user_metadata": {
    ///     "profileCode": 1479,
    ///     "addresses": { "work_address": "100 Industrial Way" }
    ///   }
    /// }
    /// ```
    ///
    /// **Updating an inner user metadata property**
    ///
    /// If there's existing user metadata to which we want to add  `"home_address": "742 Evergreen Terrace"` (using the `addresses` property) we should send the whole `addresses` object. Since this is a first-level object, the object will be merged in, but its own properties will not be. The body to send should be:
    ///
    /// ```json
    /// {
    ///   "user_metadata": {
    ///     "addresses": {
    ///       "work_address": "100 Industrial Way",
    ///       "home_address": "742 Evergreen Terrace"
    ///     }
    ///   }
    /// }
    /// ```
    ///
    /// The modified object ends up with the following `user_metadata` property:
    ///
    /// ```json
    /// {
    ///   "user_metadata": {
    ///     "profileCode": 1479,
    ///     "addresses": {
    ///       "work_address": "100 Industrial Way",
    ///       "home_address": "742 Evergreen Terrace"
    ///     }
    ///   }
    /// }
    /// ```
    /// </summary>
    WithRawResponseTask<UpdateUserResponseContent> UpdateAsync(
        string id,
        UpdateUserRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Remove an existing multi-factor authentication (MFA) [recovery code](https://auth0.com/docs/secure/multi-factor-authentication/reset-user-mfa) and generate a new one. If a user cannot access the original device or account used for MFA enrollment, they can use a recovery code to authenticate.
    /// </summary>
    WithRawResponseTask<RegenerateUsersRecoveryCodeResponseContent> RegenerateRecoveryCodeAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Revokes selected resources related to a user (sessions, refresh tokens, ...).
    /// </summary>
    WithRawResponseTask RevokeAccessAsync(
        string id,
        RevokeUserAccessRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}

namespace Auth0.ManagementApi;

public partial interface IUserBlocksClient
{
    /// <summary>
    /// Retrieve details of all [Brute-force Protection](https://auth0.com/docs/secure/attack-protection/brute-force-protection) blocks for a user with the given identifier (username, phone number, or email).
    /// </summary>
    WithRawResponseTask<ListUserBlocksByIdentifierResponseContent> ListByIdentifierAsync(
        ListUserBlocksByIdentifierRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Remove all [Brute-force Protection](https://auth0.com/docs/secure/attack-protection/brute-force-protection) blocks for the user with the given identifier (username, phone number, or email).
    ///
    /// Note: This endpoint does not unblock users that were [blocked by a tenant administrator](https://auth0.com/docs/user-profile#block-and-unblock-a-user).
    /// </summary>
    WithRawResponseTask DeleteByIdentifierAsync(
        DeleteUserBlocksByIdentifierRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve details of all [Brute-force Protection](https://auth0.com/docs/secure/attack-protection/brute-force-protection) blocks for the user with the given ID.
    /// </summary>
    WithRawResponseTask<ListUserBlocksResponseContent> ListAsync(
        string id,
        ListUserBlocksRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Remove all [Brute-force Protection](https://auth0.com/docs/secure/attack-protection/brute-force-protection) blocks for the user with the given ID.
    ///
    /// Note: This endpoint does not unblock users that were [blocked by a tenant administrator](https://auth0.com/docs/user-profile#block-and-unblock-a-user).
    /// </summary>
    WithRawResponseTask DeleteAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}

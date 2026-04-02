namespace Auth0.ManagementApi;

public partial interface IUserBlocksClient
{
    /// <summary>
    /// Retrieve details of all <see href="https://auth0.com/docs/secure/attack-protection/brute-force-protection">Brute-force Protection</see> blocks for a user with the given identifier (username, phone number, or email).
    /// </summary>
    WithRawResponseTask<ListUserBlocksByIdentifierResponseContent> ListByIdentifierAsync(
        ListUserBlocksByIdentifierRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Remove all <see href="https://auth0.com/docs/secure/attack-protection/brute-force-protection">Brute-force Protection</see> blocks for the user with the given identifier (username, phone number, or email).
    ///
    /// Note: This endpoint does not unblock users that were <see href="https://auth0.com/docs/user-profile#block-and-unblock-a-user">blocked by a tenant administrator</see>.
    /// </summary>
    Task DeleteByIdentifierAsync(
        DeleteUserBlocksByIdentifierRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve details of all <see href="https://auth0.com/docs/secure/attack-protection/brute-force-protection">Brute-force Protection</see> blocks for the user with the given ID.
    /// </summary>
    WithRawResponseTask<ListUserBlocksResponseContent> ListAsync(
        string id,
        ListUserBlocksRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Remove all <see href="https://auth0.com/docs/secure/attack-protection/brute-force-protection">Brute-force Protection</see> blocks for the user with the given ID.
    ///
    /// Note: This endpoint does not unblock users that were <see href="https://auth0.com/docs/user-profile#block-and-unblock-a-user">blocked by a tenant administrator</see>.
    /// </summary>
    Task DeleteAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}

namespace Auth0.ManagementApi;

public partial interface ISessionsClient
{
    /// <summary>
    /// Retrieve session information.
    /// </summary>
    WithRawResponseTask<GetSessionResponseContent> GetAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a session by ID.
    /// </summary>
    Task DeleteAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update session information.
    /// </summary>
    WithRawResponseTask<UpdateSessionResponseContent> UpdateAsync(
        string id,
        UpdateSessionRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Revokes a session by ID and all associated refresh tokens.
    /// </summary>
    Task RevokeAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}

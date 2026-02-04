using Auth0.ManagementApi;

namespace Auth0.ManagementApi.Connections.ScimConfiguration;

public partial interface ITokensClient
{
    /// <summary>
    /// Retrieves all scim tokens by its connection <code>id</code>.
    /// </summary>
    WithRawResponseTask<IEnumerable<ScimTokenItem>> GetAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create a scim token for a scim client.
    /// </summary>
    WithRawResponseTask<CreateScimTokenResponseContent> CreateAsync(
        string id,
        CreateScimTokenRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Deletes a scim token by its connection <code>id</code> and <code>tokenId</code>.
    /// </summary>
    Task DeleteAsync(
        string id,
        string tokenId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}

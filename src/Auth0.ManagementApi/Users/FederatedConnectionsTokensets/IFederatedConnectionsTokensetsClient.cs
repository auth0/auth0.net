using Auth0.ManagementApi;

namespace Auth0.ManagementApi.Users;

public partial interface IFederatedConnectionsTokensetsClient
{
    /// <summary>
    /// List active federated connections tokensets for a provided user
    /// </summary>
    WithRawResponseTask<IEnumerable<FederatedConnectionTokenSet>> ListAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    Task DeleteAsync(
        string id,
        string tokensetId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}

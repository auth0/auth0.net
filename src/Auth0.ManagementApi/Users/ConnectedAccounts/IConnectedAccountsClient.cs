using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Users;

public partial interface IConnectedAccountsClient
{
    /// <summary>
    /// Retrieve all connected accounts associated with the user.
    /// </summary>
    Task<Pager<ConnectedAccount>> ListAsync(
        string id,
        GetUserConnectedAccountsRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}

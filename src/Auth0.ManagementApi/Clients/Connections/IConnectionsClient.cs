using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Clients;

public partial interface IConnectionsClient
{
    /// <summary>
    /// Retrieve all connections that are enabled for the specified [Application](https://www.auth0.com/docs/get-started/applications), using checkpoint pagination. A list of fields to include or exclude for each connection may also be specified.
    ///
    /// - This endpoint requires the `read:connections` scope and any one of `read:clients` or `read:client_summary`.
    /// - **Note**: The first time you call this endpoint, omit the `from` parameter. If there are more results, a `next` value is included in the response. You can use this for subsequent API calls. When `next` is no longer included in the response, no further results are remaining.
    /// </summary>
    Task<Pager<ConnectionForList>> GetAsync(
        string id,
        ConnectionsGetRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}

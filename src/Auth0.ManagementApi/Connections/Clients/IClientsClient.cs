using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Connections;

public partial interface IClientsClient
{
    /// <summary>
    /// Retrieve all clients that have the specified <see href="https://auth0.com/docs/authenticate/identity-providers">connection</see> enabled.
    ///
    /// <b>Note</b>: The first time you call this endpoint, omit the <c>from</c> parameter. If there are more results, a <c>next</c> value is included in the response. You can use this for subsequent API calls. When <c>next</c> is no longer included in the response, no further results are remaining.
    /// </summary>
    Task<Pager<ConnectionEnabledClient>> GetAsync(
        string id,
        GetConnectionEnabledClientsRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    Task UpdateAsync(
        string id,
        IEnumerable<UpdateEnabledClientConnectionsRequestContentItem> request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}

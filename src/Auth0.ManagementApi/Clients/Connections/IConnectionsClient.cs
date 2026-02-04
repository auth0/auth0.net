using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Clients;

public partial interface IConnectionsClient
{
    /// <summary>
    /// Retrieve all connections that are enabled for the specified <a href="https://www.auth0.com/docs/get-started/applications"> Application</a>, using checkpoint pagination. A list of fields to include or exclude for each connection may also be specified.
    /// <ul>
    ///   <li>
    ///     This endpoint requires the <code>read:connections</code> scope and any one of <code>read:clients</code> or <code>read:client_summary</code>.
    ///   </li>
    ///   <li>
    ///     <b>Note</b>: The first time you call this endpoint, omit the <code>from</code> parameter. If there are more results, a <code>next</code> value is included in the response. You can use this for subsequent API calls. When <code>next</code> is no longer included in the response, no further results are remaining.
    ///   </li>
    /// </ul>
    /// </summary>
    Task<Pager<ConnectionForList>> GetAsync(
        string id,
        ConnectionsGetRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}

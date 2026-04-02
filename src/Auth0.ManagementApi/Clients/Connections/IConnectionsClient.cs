using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Clients;

public partial interface IConnectionsClient
{
    /// <summary>
    /// Retrieve all connections that are enabled for the specified <see href="https://www.auth0.com/docs/get-started/applications"> Application</see>, using checkpoint pagination. A list of fields to include or exclude for each connection may also be specified.
    /// <list type="bullet">
    ///   <item><description>
    ///     This endpoint requires the <c>read:connections</c> scope and any one of <c>read:clients</c> or <c>read:client_summary</c>.
    ///   </description></item>
    ///   <item><description>
    ///     <b>Note</b>: The first time you call this endpoint, omit the <c>from</c> parameter. If there are more results, a <c>next</c> value is included in the response. You can use this for subsequent API calls. When <c>next</c> is no longer included in the response, no further results are remaining.
    ///   </description></item>
    /// </list>
    /// </summary>
    Task<Pager<ConnectionForList>> GetAsync(
        string id,
        ConnectionsGetRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}

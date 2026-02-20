using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Users;

public partial interface ILogsClient
{
    /// <summary>
    /// Retrieve log events for a specific user.
    ///
    /// Note: For more information on all possible event types, their respective acronyms and descriptions, see <see href="https://auth0.com/docs/logs/log-event-type-codes">Log Event Type Codes</see>.
    ///
    /// For more information on the list of fields that can be used in `sort`, see <see href="https://auth0.com/docs/logs/log-search-query-syntax#searchable-fields">Searchable Fields</see>.
    ///
    /// Auth0 <see href="https://auth0.com/docs/logs/retrieve-log-events-using-mgmt-api#limitations">limits the number of logs</see> you can return by search criteria to 100 logs per request. Furthermore, you may only paginate through up to 1,000 search results. If you exceed this threshold, please redefine your search.
    /// </summary>
    Task<Pager<Log>> ListAsync(
        string id,
        ListUserLogsRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}

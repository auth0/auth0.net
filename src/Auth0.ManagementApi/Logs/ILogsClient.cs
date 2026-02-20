using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

public partial interface ILogsClient
{
    /// <summary>
    /// Retrieve log entries that match the specified search criteria (or all log entries if no criteria specified).
    ///
    /// Set custom search criteria using the <c>q</c> parameter, or search from a specific log ID (<i>"search from checkpoint"</i>).
    ///
    /// For more information on all possible event types, their respective acronyms, and descriptions, see <see href="https://auth0.com/docs/logs/log-event-type-codes">Log Event Type Codes</see>.
    ///
    /// <para>To set custom search criteria, use the following parameters:</para>
    ///
    /// <list type="bullet">
    ///     <item><description><b>q:</b> Search Criteria using <see href="https://auth0.com/docs/logs/log-search-query-syntax">Query String Syntax</see></description></item>
    ///     <item><description><b>page:</b> Page index of the results to return. First page is 0.</description></item>
    ///     <item><description><b>per_page:</b> Number of results per page.</description></item>
    ///     <item><description><b>sort:</b> Field to use for sorting appended with `:1` for ascending and `:-1` for descending. e.g. `date:-1`</description></item>
    ///     <item><description><b>fields:</b> Comma-separated list of fields to include or exclude (depending on include_fields) from the result, empty to retrieve all fields.</description></item>
    ///     <item><description><b>include_fields:</b> Whether specified fields are to be included (true) or excluded (false).</description></item>
    ///     <item><description><b>include_totals:</b> Return results inside an object that contains the total result count (true) or as a direct array of results (false, default). <b>Deprecated:</b> this field is deprecated and should be removed from use. See <see href="https://auth0.com/docs/product-lifecycle/deprecations-and-migrations/migrate-to-tenant-log-search-v3#pagination">Search Engine V3 Breaking Changes</see></description></item>
    /// </list>
    ///
    /// For more information on the list of fields that can be used in <c>fields</c> and <c>sort</c>, see <see href="https://auth0.com/docs/logs/log-search-query-syntax#searchable-fields">Searchable Fields</see>.
    ///
    /// Auth0 <see href="https://auth0.com/docs/logs/retrieve-log-events-using-mgmt-api#limitations">limits the number of logs</see> you can return by search criteria to 100 logs per request. Furthermore, you may paginate only through 1,000 search results. If you exceed this threshold, please redefine your search or use the <see href="https://auth0.com/docs/logs/retrieve-log-events-using-mgmt-api#retrieve-logs-by-checkpoint">get logs by checkpoint method</see>.
    ///
    /// <para>To search from a checkpoint log ID, use the following parameters:</para>
    /// <list type="bullet">
    ///     <item><description><b>from:</b> Log Event ID from which to start retrieving logs. You can limit the number of logs returned using the <c>take</c> parameter. If you use <c>from</c> at the same time as <c>q</c>, <c>from</c> takes precedence and <c>q</c> is ignored.</description></item>
    ///     <item><description><b>take:</b> Number of entries to retrieve when using the <c>from</c> parameter.</description></item>
    /// </list>
    ///
    /// <b>Important:</b> When fetching logs from a checkpoint log ID, any parameter other than <c>from</c> and <c>take</c> will be ignored, and date ordering is not guaranteed.
    /// </summary>
    Task<Pager<Log>> ListAsync(
        ListLogsRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve an individual log event.
    /// </summary>
    WithRawResponseTask<GetLogResponseContent> GetAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}

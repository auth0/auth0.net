using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Auth0.Core;
using Auth0.Core.Collections;
using Auth0.Core.Http;
using Auth0.ManagementApi.Serialization;

namespace Auth0.ManagementApi.Clients
{
    /// <summary>
    /// Contains all the methods to call the /logs endpoints
    /// </summary>
    public class LogsClient : ClientBase, ILogsClient
    {
        /// <summary>
        /// Creates a new instance on <see cref="LogsClient"/>
        /// </summary>
        /// <param name="connection">The <see cref="IApiConnection"/> which is used to communicate with the API.</param>
        public LogsClient(IApiConnection connection)
            : base(connection)
        {
        }

        /// <summary>
        /// Retrieves log entries that match the specified search criteria
        /// </summary>
        /// <remarks>
        /// Will list all entries if no criteria is used. You can search with a criteria using the q parameter or you can search by a specific log ID (search by checkpoint)
        /// </remarks>
        /// <param name="page">The page number. Zero based</param>
        /// <param name="perPage">The amount of entries per page. Default: 50. Max value: 100</param>
        /// <param name="sort">The field to use for sorting. Use field:order where order is 1 for ascending and -1 for descending. For example date:-1</param>
        /// <param name="fields">A comma separated list of fields to include or exclude (depending on include_fields) from the result, empty to retrieve all fields</param>
        /// <param name="includeFields">True if the fields specified are to be included in the result, false otherwise. Defaults to true</param>
        /// <param name="includeTotals">True if a query summary must be included in the result, false otherwise. Default false.</param>
        /// <param name="from">Log Event Id to start retrieving logs. You can limit the amount of logs using the take parameter.</param>
        /// <param name="take">The total amount of entries to retrieve when using the from parameter. Default: 50. Max value: 100</param>
        /// <param name="q">Query in Lucene query string syntax.</param>
        /// <returns></returns>
        public Task<IPagedList<LogEntry>> GetAllAsync(int? page = null, int? perPage = null, string sort = null,
            string fields = null, bool? includeFields = null, bool? includeTotals = null,
            string from = null, int? take = null, string q = null)
        {
            return Connection.GetAsync<IPagedList<LogEntry>>("logs", null,
                new Dictionary<string, string>
                {
                    {"page", page?.ToString()},
                    {"per_page", perPage?.ToString()},
                    {"sort", sort},
                    {"fields", fields},
                    {"include_fields", includeFields?.ToString().ToLower()},
                    {"include_totals", includeTotals?.ToString().ToLower()},
                    {"from", from},
                    {"take", take?.ToString().ToLower()},
                    {"q", q}
                }, null, new PagedListConverter<LogEntry>("logs"));
        }

        /// <summary>
        /// Retrieves the data related to the log entry identified by id. This returns a single log entry representation as specified in the schema.
        /// </summary>
        /// <param name="id">The identifier of the log entry to retrieve</param>
        /// <returns></returns>

        public Task<LogEntry> GetAsync(string id)
        {
            return Connection.GetAsync<LogEntry>("logs/{id}",
                new Dictionary<string, string>
                {
                    {"id", id}
                },
                null, null, null);
        }
    }
}
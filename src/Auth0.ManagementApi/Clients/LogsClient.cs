using Auth0.ManagementApi.Models;
using Auth0.ManagementApi.Paging;
using Auth0.ManagementApi.Serialization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Auth0.ManagementApi.Clients
{
    /// <summary>
    /// Contains all the methods to call the /logs endpoints.
    /// </summary>
    public class LogsClient : ClientBase
    {
        /// <summary>
        /// Creates a new instance on <see cref="LogsClient"/>
        /// </summary>
        /// <param name="connection">The <see cref="ILegacyApiConnection"/> which is used to communicate with the API.</param>
        public LogsClient(ILegacyApiConnection connection)
            : base(connection)
        {
        }

        /// <summary>
        /// Retrieves log entries that match the specified search criteria.
        /// </summary>
        /// <param name="request">Specifies criteria to use when querying logs.</param>
        /// <param name="pagination">Specifies pagination info to use when requesting paged results.</param>
        /// <returns>An <see cref="IPagedList{LogEntry}"/> containing the list of log entries.</returns>
        public Task<IPagedList<LogEntry>> GetAllAsync(GetLogsRequest request, PaginationInfo pagination)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));
            if (pagination == null)
                throw new ArgumentNullException(nameof(pagination));

            return Connection.GetAsync<IPagedList<LogEntry>>("logs", null,
                new Dictionary<string, string>
                {
                    {"sort", request.Sort},
                    {"fields", request.Fields},
                    {"include_fields", request.IncludeFields?.ToString().ToLower()},
                    {"from", request.From},
                    {"take", request.Take?.ToString().ToLower()},
                    {"q", request.Query},
                    {"page", pagination.PageNo.ToString()},
                    {"per_page", pagination.PerPage.ToString()},
                    {"include_totals", pagination.IncludeTotals.ToString().ToLower()}
                }, null, new PagedListConverter<LogEntry>("logs"));
        }

        /// <summary>
        /// Retrieves the data related to the log entry identified by id. This returns a single log entry representation as specified in the schema.
        /// </summary>
        /// <param name="id">The identifier of the log entry to retrieve.</param>
        /// <returns>A <see cref="LogEntry"/> instance containing the information about the log entry.</returns>
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
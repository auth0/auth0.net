using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Auth0.Core.Collections;
using Auth0.Core.Http;
using Auth0.ManagementApi.Models;
using Auth0.ManagementApi.Serialization;

namespace Auth0.ManagementApi.Clients
{
    /// <inheritdoc />
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

        /// <inheritdoc />
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

        /// <inheritdoc />
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
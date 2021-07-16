using Auth0.ManagementApi.Models;
using Auth0.ManagementApi.Paging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Auth0.ManagementApi.Clients
{
    /// <summary>
    /// Contains methods to access the /logs endpoints.
    /// </summary>
    public class LogsClient : BaseClient
    {
        readonly JsonConverter[] converters = new JsonConverter[] { new PagedListConverter<LogEntry>("logs") };

        /// <summary>
        /// Initializes a new instance of <see cref="LogsClient"/>
        /// </summary>
        /// <param name="connection"><see cref="IManagementConnection"/> used to make all API calls.</param>
        /// <param name="baseUri"><see cref="Uri"/> of the endpoint to use in making API calls.</param>
        /// <param name="defaultHeaders">Dictionary containing default headers included with every request this client makes.</param>
        public LogsClient(IManagementConnection connection, Uri baseUri, IDictionary<string, string> defaultHeaders)
            : base(connection, baseUri, defaultHeaders)
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

            return Connection.GetAsync<IPagedList<LogEntry>>(BuildUri("logs",
                new Dictionary<string, string>
                {
                    {"sort", request.Sort},
                    {"fields", request.Fields},
                    {"include_fields", request.IncludeFields?.ToString().ToLower()},
                    {"from", pagination.From?.ToString() ?? request.From.ToString()},
                    {"take", pagination.Take?.ToString() ?? request.Take?.ToString()},
                    {"q", request.Query},
                    {"page", pagination.PageNo?.ToString()},
                    {"per_page", pagination.PerPage?.ToString()},
                    {"include_totals", pagination.IncludeTotals?.ToString().ToLower()},
                }), DefaultHeaders, converters);
        }

        /// <summary>
        /// Retrieves the data related to the log entry identified by id. This returns a single log entry representation as specified in the schema.
        /// </summary>
        /// <param name="id">The identifier of the log entry to retrieve.</param>
        /// <returns>A <see cref="LogEntry"/> instance containing the information about the log entry.</returns>
        public Task<LogEntry> GetAsync(string id)
        {
            return Connection.GetAsync<LogEntry>(BuildUri($"logs/{EncodePath(id)}"), DefaultHeaders);
        }
    }
}
using Auth0.ManagementApi.Models;
using Auth0.ManagementApi.Paging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Auth0.ManagementApi.Clients
{
    /// <summary>
    /// Contains methods to access the /logs endpoints.
    /// </summary>
    public class LogsClient : BaseClient, ILogsClient
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
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>An <see cref="IPagedList{LogEntry}"/> containing the list of log entries.</returns>
        public Task<IPagedList<LogEntry>> GetAllAsync(GetLogsRequest request, PaginationInfo pagination = null, CancellationToken cancellationToken = default)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var queryStrings = new Dictionary<string, string>
            {
                {"sort", request.Sort},
                {"fields", request.Fields},
                {"include_fields", request.IncludeFields?.ToString().ToLower()},
                {"from", request.From},
                {"take", request.Take?.ToString().ToLower()},
                {"q", request.Query},
            };

            if (pagination != null)
            {
                queryStrings["page"] = pagination.PageNo.ToString();
                queryStrings["per_page"] = pagination.PerPage.ToString();
                queryStrings["include_totals"] = pagination.IncludeTotals.ToString().ToLower();
            }

            return Connection.GetAsync<IPagedList<LogEntry>>(BuildUri("logs", queryStrings), DefaultHeaders, converters, cancellationToken);
        }

        /// <summary>
        /// Retrieves the data related to the log entry identified by id. This returns a single log entry representation as specified in the schema.
        /// </summary>
        /// <param name="id">The identifier of the log entry to retrieve.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>A <see cref="LogEntry"/> instance containing the information about the log entry.</returns>
        public Task<LogEntry> GetAsync(string id, CancellationToken cancellationToken = default)
        {
            return Connection.GetAsync<LogEntry>(BuildUri($"logs/{EncodePath(id)}"), DefaultHeaders, cancellationToken: cancellationToken);
        }
    }
}

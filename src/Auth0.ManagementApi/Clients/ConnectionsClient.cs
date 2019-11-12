using Auth0.Core.Collections;
using Auth0.Core.Http;
using Auth0.ManagementApi.Models;
using Auth0.ManagementApi.Serialization;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Auth0.ManagementApi.Clients
{
    /// <summary>
    /// Contains all the methods to call the /connections endpoints.
    /// </summary>
    public class ConnectionsClient : ClientBase
    {
        /// <summary>
        /// Creates a new instance of the <see cref="ConnectionsClient"/>.
        /// </summary>
        /// <param name="connection">The <see cref="IApiConnection" /> which is used to communicate with the API.</param>
        public ConnectionsClient(IApiConnection connection)
            : base(connection)
        {
        }

        /// <summary>
        /// Creates a new connection according to the request.
        /// </summary>
        /// <param name="request">The request containing the properties for the new connection.</param>
        /// <returns>A <see cref="Connection"/> containing the newly created Connection.</returns>
        public Task<Connection> CreateAsync(ConnectionCreateRequest request)
        {
            return Connection.RunAsync<Connection>(HttpMethod.Post, "connections", request);
        }

        /// <summary>
        /// Deletes a connection and all its users.
        /// </summary>
        /// <param name="id">The id of the connection to delete.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous delete operation.</returns>
        public Task DeleteAsync(string id)
        {
            return Connection.RunAsync<object>(HttpMethod.Delete, $"connections/{id}");
        }

        /// <summary>
        /// Deletes a specified connection user by its <paramref name="email"/>.
        /// </summary>
        /// <remarks>
        /// Currently only database connections are supported and you cannot delete all users from specific connection.
        /// </remarks>
        /// <param name="id">The identifier of the connection.</param>
        /// <param name="email">The email of the user to delete.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous delete operation.</returns>
        public Task DeleteUserAsync(string id, string email)
        {
            return Connection.RunAsync<object>(HttpMethod.Delete, $"connections/{id}/users", queryStrings:
                new Dictionary<string, string>
                {
                    {"email", email},
                });
        }

        /// <summary>
        /// Retrieves a connection by its <paramref name="id"/>.
        /// </summary>
        /// <param name="id">The id of the connection to retrieve.</param>
        /// <param name="fields">A comma separated list of fields to include or exclude (depending on include_fields) from the result, empty to retrieve all fields.</param>
        /// <param name="includeFields">True if the fields specified are to be included in the result, false otherwise (defaults to true).</param>
        /// <returns>The <see cref="Connection"/>.</returns>
        public Task<Connection> GetAsync(string id, string fields = null, bool includeFields = true)
        {
            return Connection.RunAsync<Connection>(HttpMethod.Get, $"connections/{id}", queryStrings:
                new Dictionary<string, string>
                {
                    {"fields", fields},
                    {"include_fields", includeFields.ToString().ToLower()}
                });
        }

        /// <summary>
        /// Retrieves every connection matching the specified strategy. All connections are retrieved if no strategy is being specified. Accepts a list of fields to include or exclude in the resulting list of connection objects.
        /// </summary>
        /// <param name="request">Specifies criteria to use when querying connections.</param>
        /// <param name="pagination">Specifies pagination info to use when requesting paged results.</param>
        /// <returns>An <see cref="IPagedList{Connection}"/> containing the list of connections.</returns>
        public Task<IPagedList<Connection>> GetAllAsync(GetConnectionsRequest request, PaginationInfo pagination)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));
            if (pagination == null)
                throw new ArgumentNullException(nameof(pagination));

            var queryStrings = new Dictionary<string, string>
            {
                {"fields", request.Fields},
                {"include_fields", request.IncludeFields?.ToString().ToLower()},
                {"name", request.Name},
                {"page", pagination.PageNo.ToString()},
                {"per_page", pagination.PerPage.ToString()},
                {"include_totals", pagination.IncludeTotals.ToString().ToLower()}
            };

            // Add each strategy as a separate querystring
            if (request.Strategy != null)
            {
                foreach (var s in request.Strategy)
                {
                    queryStrings.Add("strategy", s);
                }
            }

            return Connection.RunAsync<IPagedList<Connection>>(HttpMethod.Get, "connections", queryStrings, converters: new PagedListConverter<Connection>("connections"));
        }

        /// <summary>
        /// Updates a connection.
        /// </summary>
        /// <param name="id">The id of the connection to update.</param>
        /// <param name="request">The <see cref="ConnectionUpdateRequest"/> containing the properties of the connection you wish to update.</param>
        /// <returns>The <see cref="Connection"/> that has been updated.</returns>
        public Task<Connection> UpdateAsync(string id, ConnectionUpdateRequest request)
        {
            return Connection.RunAsync<Connection>(new HttpMethod("PATCH"), $"connections/{id}", request);
        }
    }
}
using Auth0.ManagementApi.Models;
using Auth0.ManagementApi.Paging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Auth0.ManagementApi.Clients
{
    /// <summary>
    /// Contains methods to acess the /connections endpoints.
    /// </summary>
    public class ConnectionsClient : BaseClient
    {
        readonly JsonConverter[] converters = new JsonConverter[] { new PagedListConverter<Connection>("connections") };

        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectionsClient"/>.
        /// </summary>
        /// <param name="connection"><see cref="IManagementConnection"/> used to make all API calls.</param>
        /// <param name="baseUri"><see cref="Uri"/> of the endpoint to use in making API calls.</param>
        public ConnectionsClient(IManagementConnection connection, Uri baseUri)
            : base(connection, baseUri)
        {
        }

        /// <summary>
        /// Creates a new connection according to the request.
        /// </summary>
        /// <param name="request">The request containing the properties for the new connection.</param>
        /// <returns>A <see cref="Connection"/> containing the newly created Connection.</returns>
        public Task<Connection> CreateAsync(ConnectionCreateRequest request)
        {
            return Connection.SendAsync<Connection>(HttpMethod.Post, BuildUri("connections"), request, null);
        }

        /// <summary>
        /// Deletes a connection and all its users.
        /// </summary>
        /// <param name="id">The id of the connection to delete.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous delete operation.</returns>
        public Task DeleteAsync(string id)
        {
            return Connection.SendAsync<object>(HttpMethod.Delete, BuildUri($"connections/{id}"), null);
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
            return Connection.SendAsync<object>(HttpMethod.Delete, BuildUri($"connections/{id}/users"),
                new Dictionary<string, string> { {"email", email} });
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
            return Connection.GetAsync<Connection>(BuildUri($"connections/{id}",
                new Dictionary<string, string>
                {
                    {"fields", fields},
                    {"include_fields", includeFields.ToString().ToLower()}
                }));
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
                foreach (var s in request.Strategy)
                    queryStrings.Add("strategy", s);

            return Connection.GetAsync<IPagedList<Connection>>(BuildUri("connections", queryStrings), converters: converters);
        }

        /// <summary>
        /// Updates a connection.
        /// </summary>
        /// <param name="id">The id of the connection to update.</param>
        /// <param name="request">The <see cref="ConnectionUpdateRequest"/> containing the properties of the connection you wish to update.</param>
        /// <returns>The <see cref="Connection"/> that has been updated.</returns>
        public Task<Connection> UpdateAsync(string id, ConnectionUpdateRequest request)
        {
            return Connection.SendAsync<Connection>(new HttpMethod("PATCH"), BuildUri($"connections/{id}"), request);
        }
    }
}
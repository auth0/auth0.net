using Auth0.ManagementApi.Models;
using Auth0.ManagementApi.Paging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Auth0.ManagementApi.Clients
{
    /// <summary>
    /// Contains methods to access the /connections endpoints.
    /// </summary>
    public class ConnectionsClient : BaseClient, IConnectionsClient
    {
        readonly JsonConverter[] converters = new JsonConverter[] { new PagedListConverter<Connection>("connections") };

        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectionsClient"/>.
        /// </summary>
        /// <param name="connection"><see cref="IManagementConnection"/> used to make all API calls.</param>
        /// <param name="baseUri"><see cref="Uri"/> of the endpoint to use in making API calls.</param>
        /// <param name="defaultHeaders">Dictionary containing default headers included with every request this client makes.</param>
        public ConnectionsClient(IManagementConnection connection, Uri baseUri, IDictionary<string, string> defaultHeaders)
            : base(connection, baseUri, defaultHeaders)
        {
        }

        /// <summary>
        /// Creates a new connection according to the request.
        /// </summary>
        /// <param name="request">The request containing the properties for the new connection.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>A <see cref="Connection"/> containing the newly created Connection.</returns>
        public Task<Connection> CreateAsync(ConnectionCreateRequest request, CancellationToken cancellationToken = default)
        {
            return Connection.SendAsync<Connection>(HttpMethod.Post, BuildUri("connections"), request, DefaultHeaders, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Deletes a connection and all its users.
        /// </summary>
        /// <param name="id">The id of the connection to delete.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous delete operation.</returns>
        public Task DeleteAsync(string id, CancellationToken cancellationToken = default)
        {
            return Connection.SendAsync<object>(HttpMethod.Delete, BuildUri($"connections/{EncodePath(id)}"), null, DefaultHeaders, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Deletes a specified connection user by its <paramref name="email"/>.
        /// </summary>
        /// <remarks>
        /// Currently only database connections are supported and you cannot delete all users from specific connection.
        /// </remarks>
        /// <param name="id">The identifier of the connection.</param>
        /// <param name="email">The email of the user to delete.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous delete operation.</returns>
        public Task DeleteUserAsync(string id, string email, CancellationToken cancellationToken = default)
        {
            return Connection.SendAsync<object>(HttpMethod.Delete, BuildUri($"connections/{EncodePath(id)}/users",
                new Dictionary<string, string> { {"email", email} }), null, DefaultHeaders, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Retrieves a connection by its <paramref name="id"/>.
        /// </summary>
        /// <param name="id">The id of the connection to retrieve.</param>
        /// <param name="fields">A comma separated list of fields to include or exclude (depending on include_fields) from the result, empty to retrieve all fields.</param>
        /// <param name="includeFields">True if the fields specified are to be included in the result, false otherwise (defaults to true).</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The <see cref="Connection"/>.</returns>
        public Task<Connection> GetAsync(string id, string fields = null, bool includeFields = true, CancellationToken cancellationToken = default)
        {
            return Connection.GetAsync<Connection>(BuildUri($"connections/{EncodePath(id)}",
                new Dictionary<string, string>
                {
                    {"fields", fields},
                    {"include_fields", includeFields.ToString().ToLower()}
                }), DefaultHeaders, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Retrieves every connection matching the specified strategy. All connections are retrieved if no strategy is being specified. Accepts a list of fields to include or exclude in the resulting list of connection objects.
        /// </summary>
        /// <remarks>
        /// Can only retrieve a maximum of 1000 connections, if you need to retrieve more use the overload with <see cref="CheckpointPagingInformation"/>
        /// </remarks>
        /// <param name="request">Specifies criteria to use when querying connections.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>An <see cref="IPagedList{Connection}"/> containing the list of connections.</returns>
        private Task<IPagedList<Connection>> GetAllAsync(GetConnectionsRequest request, CancellationToken cancellationToken = default)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return GetAllAsync(request, new Dictionary<string, string>(), cancellationToken);
        }

        /// <summary>
        /// Retrieves every connection matching the specified strategy. All connections are retrieved if no strategy is being specified. Accepts a list of fields to include or exclude in the resulting list of connection objects.
        /// </summary>
        /// <remarks>
        /// Can only retrieve a maximum of 1000 connections, if you need to retrieve more use the overload with <see cref="CheckpointPagingInformation"/>
        /// </remarks>
        /// <param name="request">Specifies criteria to use when querying connections.</param>
        /// <param name="pagination">Specifies pagination info to use when requesting paged results.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>An <see cref="IPagedList{Connection}"/> containing the list of connections.</returns>
        public Task<IPagedList<Connection>> GetAllAsync(GetConnectionsRequest request, PaginationInfo pagination, CancellationToken cancellationToken = default)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var queryStrings = new Dictionary<string, string>();
            queryStrings["page"] = pagination.PageNo.ToString();
            queryStrings["per_page"] = pagination.PerPage.ToString();
            queryStrings["include_totals"] = pagination.IncludeTotals.ToString().ToLower();

            return GetAllAsync(request, new Dictionary<string, string>(), cancellationToken);
        }

        /// <summary>
        /// Retrieves every connection matching the specified strategy. All connections are retrieved if no strategy is being specified. Accepts a list of fields to include or exclude in the resulting list of connection objects.
        /// </summary>
        /// <param name="request">Specifies criteria to use when querying connections.</param>
        /// <param name="pagination">Specifies pagination info to use when requesting paged results.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>An <see cref="IPagedList{Connection}"/> containing the list of connections.</returns>
        public Task<IPagedList<Connection>> GetAllAsync(GetConnectionsRequest request, CheckpointPagingInformation pagination, CancellationToken cancellationToken = default)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var queryStrings = new Dictionary<string, string>();
            queryStrings["take"] = pagination.Take.ToString();
            if (pagination.From != null)
            {
                queryStrings["from"] = pagination.From.ToString();
            }

            return GetAllAsync(request, new Dictionary<string, string>(), cancellationToken);
        }

        /// <summary>
        /// Inner call to resolve all overloads to the same call
        /// </summary>
        /// <param name="request">Specifies criteria to use when querying connections.</param>
        /// <param name="queryStrings">Specifies pre set query strings</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>An <see cref="IPagedList{Connection}"/> containing the list of connections.</returns>
        private Task<IPagedList<Connection>> GetAllAsync(GetConnectionsRequest request, Dictionary<string, string> queryStrings, CancellationToken cancellationToken = default)
        {
            queryStrings["fields"] = request.Fields;
            queryStrings["include_fields"] = request.IncludeFields?.ToString().ToLower();
            queryStrings["name"] = request.Name;

            // Add each strategy as a separate querystring
            if (request.Strategy != null)
            {
                for (var i = 0; i < request.Strategy.Length; i++)
                {
                    queryStrings.Add($"strategy[{i}]", request.Strategy[i]);
                }
            }

            return Connection.GetAsync<IPagedList<Connection>>(BuildUri("connections", queryStrings), DefaultHeaders, converters, cancellationToken);
        }

        /// <summary>
        /// Updates a connection.
        /// </summary>
        /// <param name="id">The id of the connection to update.</param>
        /// <param name="request">The <see cref="ConnectionUpdateRequest"/> containing the properties of the connection you wish to update.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The <see cref="Connection"/> that has been updated.</returns>
        public Task<Connection> UpdateAsync(string id, ConnectionUpdateRequest request, CancellationToken cancellationToken = default)
        {
            return Connection.SendAsync<Connection>(new HttpMethod("PATCH"), BuildUri($"connections/{EncodePath(id)}"), request, DefaultHeaders, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Retrieves the status of an ad/ldap connection.
        /// </summary>
        /// <param name="id">ID of the connection to check.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous check operation. Will throw if the check fails.</returns>
        public Task CheckStatusAsync(string id, CancellationToken cancellationToken = default)
        {
            return Connection.GetAsync<object>(BuildUri($"connections/{EncodePath(id)}/status"), DefaultHeaders, cancellationToken: cancellationToken);
        }
    }
}

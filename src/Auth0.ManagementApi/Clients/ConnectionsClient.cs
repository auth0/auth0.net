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
        private readonly JsonConverter[] _converters = { new PagedListConverter<Connection>("connections") };
        private readonly JsonConverter[] _defaultMappingsConverter = { new ListConverter<ScimMapping>("mapping") };

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
        /// <param name="request">Specifies criteria to use when querying connections.</param>
        /// <param name="pagination">Specifies pagination info to use when requesting paged results.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>An <see cref="IPagedList{Connection}"/> containing the list of connections.</returns>
        public Task<IPagedList<Connection>> GetAllAsync(GetConnectionsRequest request, PaginationInfo pagination = null, CancellationToken cancellationToken = default)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var queryStrings = new Dictionary<string, string>
            {
                {"fields", request.Fields},
                {"include_fields", request.IncludeFields?.ToString().ToLower()},
                {"name", request.Name},
            };

            if (pagination != null)
            {
                queryStrings["page"] = pagination.PageNo.ToString();
                queryStrings["per_page"] = pagination.PerPage.ToString();
                queryStrings["include_totals"] = pagination.IncludeTotals.ToString().ToLower();
            }

            // Add each strategy as a separate querystring
            if (request.Strategy != null)
            {
                for (var i = 0; i < request.Strategy.Length; i++)
                {
                    queryStrings.Add($"strategy[{i}]", request.Strategy[i]);
                }
            }

            return Connection.GetAsync<IPagedList<Connection>>(BuildUri("connections", queryStrings), DefaultHeaders, _converters, cancellationToken);
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

        /// <summary>
        /// Creates an <see cref="ScimConfiguration"/>.
        /// </summary>
        /// <param name="id">The id of the connection to create an <see cref="ScimConfiguration"/></param>
        /// <param name="request"> <see cref="ScimConfigurationCreateRequest"/> containing information required for creating an <see cref="ScimConfiguration"/></param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>A <see cref="ScimConfiguration"/>.</returns>
        public Task<ScimConfiguration> CreateScimConfigurationAsync(string id, ScimConfigurationCreateRequest request, CancellationToken cancellationToken = default)
        {
            return Connection.SendAsync<ScimConfiguration>(HttpMethod.Post, BuildUri($"connections/{EncodePath(id)}/scim-configuration"), request, DefaultHeaders, cancellationToken: cancellationToken);            
        }
        
        /// <summary>
        /// Retrieves an <see cref="ScimConfiguration"/>.
        /// </summary>
        /// <param name="id">The id of the connection to retrieve its <see cref="ScimConfiguration"/></param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>A <see cref="ScimConfiguration"/>.</returns>
        public Task<ScimConfiguration> GetScimConfigurationAsync(string id, CancellationToken cancellationToken = default)
        {
            return Connection.GetAsync<ScimConfiguration>(BuildUri($"connections/{EncodePath(id)}/scim-configuration"), DefaultHeaders, cancellationToken: cancellationToken);            
        }
        
        /// <summary>
        /// Updates an <see cref="ScimConfiguration"/>n.
        /// </summary>
        /// <param name="id">The id of the connection to update its SCIM configuration</param>
        /// <param name="request"> <see cref="ScimConfigurationUpdateRequest"/> containing information required for updating an <see cref="ScimConfiguration"/></param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>A <see cref="ScimConfiguration"/>.</returns>
        public Task<ScimConfiguration> UpdateScimConfigurationAsync(string id, ScimConfigurationUpdateRequest request, CancellationToken cancellationToken = default)
        {
            return Connection.SendAsync<ScimConfiguration>(new HttpMethod("PATCH"), BuildUri($"connections/{EncodePath(id)}/scim-configuration"), request, DefaultHeaders, cancellationToken: cancellationToken);            
        }
        
        /// <summary>
        /// Deletes an <see cref="ScimConfiguration"/>.
        /// </summary>
        /// <param name="id">The id of the connection to delete its SCIM configuration</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        public Task DeleteScimConfigurationAsync(string id, CancellationToken cancellationToken = default)
        {
            return Connection.SendAsync<object>(HttpMethod.Delete, BuildUri($"connections/{EncodePath(id)}/scim-configuration"), null, DefaultHeaders, cancellationToken: cancellationToken);            
        }
        
        /// <summary>
        /// Retrieves the default <see cref="ScimMapping"/>.
        /// </summary>
        /// <param name="id">The id of the connection to retrieve its default <see cref="ScimMapping"/></param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>An IList of <see cref="ScimMapping"/>.</returns>
        public Task<IList<ScimMapping>> GetDefaultScimMappingAsync(string id, CancellationToken cancellationToken = default)
        {
            return Connection.GetAsync<IList<ScimMapping>>(BuildUri($"connections/{EncodePath(id)}/scim-configuration/default-mapping"), DefaultHeaders, _defaultMappingsConverter, cancellationToken: cancellationToken);
        }
        
        /// <summary>
        /// Creates an <see cref="ScimToken"/>.
        /// </summary>
        /// <param name="id">The id of the connection to create an <see cref="ScimToken"/></param>
        /// <param name="request"> <see cref="ScimTokenCreateRequest"/> containing information required for creating an <see cref="ScimToken"/></param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>An <see cref="ScimTokenCreateResponse"/>.</returns>
        public Task<ScimTokenCreateResponse> CreateScimTokenAsync(string id, ScimTokenCreateRequest request, CancellationToken cancellationToken = default)
        {
            return Connection.SendAsync<ScimTokenCreateResponse>(HttpMethod.Post, BuildUri($"connections/{EncodePath(id)}/scim-configuration/tokens"), request, DefaultHeaders, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Retrieves all <see cref="ScimToken"/> for the given connection.
        /// </summary>
        /// <param name="id">The id of the connection to retrieve its <see cref="ScimToken"/></param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>An <see cref="ScimToken"/>.</returns>
        public Task<IList<ScimToken>> GetScimTokenAsync(string id, CancellationToken cancellationToken = default)
        {
            return Connection.GetAsync<IList<ScimToken>>(BuildUri($"connections/{EncodePath(id)}/scim-configuration/tokens"), DefaultHeaders, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Deletes an SCIM token.
        /// </summary>
        /// <param name="id">The ID of the connection that owns the  <see cref="ScimToken"/> to be deleted</param>
        /// <param name="tokenId">The ID of the <see cref="ScimToken"/> to delete</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        public Task DeleteScimTokenAsync(string id, string tokenId, CancellationToken cancellationToken = default)
        {
            return Connection.SendAsync<object>(HttpMethod.Delete, BuildUri($"connections/{EncodePath(id)}/scim-configuration/tokens/{EncodePath(tokenId)}"), null, DefaultHeaders, cancellationToken: cancellationToken);
        }
    }
}

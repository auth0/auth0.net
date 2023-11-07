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
    /// Contains methods to access the /client-grants endpoints.
    /// </summary>
    public class ClientGrantsClient : BaseClient, IClientGrantsClient
    {
        readonly JsonConverter[] converters = new JsonConverter[] { new PagedListConverter<ClientGrant>("client_grants") };
        readonly JsonConverter[] organizationsConverters = new JsonConverter[] { new PagedListConverter<Organization>("organizations") };

        /// <summary>
        /// Initializes a new instance of <see cref="ClientGrantsClient"/>.
        /// </summary>
        /// <param name="connection"><see cref="IManagementConnection"/> used to make all API calls.</param>
        /// <param name="baseUri"><see cref="Uri"/> of the endpoint to use in making API calls.</param>
        /// <param name="defaultHeaders">Dictionary containing default headers included with every request this client makes.</param>
        public ClientGrantsClient(IManagementConnection connection, Uri baseUri, IDictionary<string, string> defaultHeaders)
            : base(connection, baseUri, defaultHeaders)
        {
        }

        /// <summary>
        /// Creates a new client grant.
        /// </summary>
        /// <param name="request">The <see cref="ClientGrantCreateRequest"/> containing the properties of the Client Grant.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The new <see cref="ClientGrant"/> that has been created.</returns>
        public Task<ClientGrant> CreateAsync(ClientGrantCreateRequest request, CancellationToken cancellationToken = default)
        {
            return Connection.SendAsync<ClientGrant>(HttpMethod.Post, BuildUri("client-grants"), request, DefaultHeaders, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Deletes a client grant.
        /// </summary>
        /// <param name="id">The identifier of the Client Grant to delete.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous delete operation.</returns>
        public Task DeleteAsync(string id, CancellationToken cancellationToken = default)
        {
            return Connection.SendAsync<object>(HttpMethod.Delete, BuildUri($"client-grants/{EncodePath(id)}"), null, DefaultHeaders, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Gets a list of all the client grants.
        /// </summary>
        /// <param name="request">Specifies criteria to use when querying client grants.</param>
        /// <param name="pagination">Specifies <see cref="PaginationInfo"/> to use in requesting paged results.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>A <see cref="IPagedList{ClientGrant}"/> containing the client grants requested.</returns>
        public Task<IPagedList<ClientGrant>> GetAllAsync(GetClientGrantsRequest request, PaginationInfo pagination = null, CancellationToken cancellationToken = default)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var queryStrings = new Dictionary<string, string>
            {
                {"audience", request.Audience},
                {"client_id", request.ClientId},
            };
            
            queryStrings.AddIfNotEmpty("allow_any_organization", request.AllowAnyOrganization?.ToString() ?? string.Empty);

            if (pagination != null)
            {
                queryStrings["page"] = pagination.PageNo.ToString();
                queryStrings["per_page"] = pagination.PerPage.ToString();
                queryStrings["include_totals"] = pagination.IncludeTotals.ToString().ToLower();
            }

            return Connection.GetAsync<IPagedList<ClientGrant>>(BuildUri("client-grants", queryStrings), DefaultHeaders, converters, cancellationToken);
        }

        /// <summary>
        /// Updates a client grant.
        /// </summary>
        /// <param name="id">The identifier of the client grant to update.</param>
        /// <param name="request">The <see cref="ClientGrantUpdateRequest"/> containing the properties to update.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The <see cref="ClientGrant"/> that has been updated.</returns>
        public Task<ClientGrant> UpdateAsync(string id, ClientGrantUpdateRequest request, CancellationToken cancellationToken = default)
        {
            return Connection.SendAsync<ClientGrant>(new HttpMethod("PATCH"), BuildUri($"client-grants/{EncodePath(id)}"), request, DefaultHeaders, cancellationToken: cancellationToken);
        }
        
        /// <summary>
        /// Get the organizations associated to a client grant
        /// </summary>
        /// <param name="id">The identifier of the client grant.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>A <see cref="IPagedList{Organization}"/> containing the organizations requested.</returns>
        public Task<IPagedList<Organization>> GetAllOrganizationsAsync(string id, CancellationToken cancellationToken = default)
        {
            var queryStrings = new Dictionary<string, string>();
            return Connection.GetAsync<IPagedList<Organization>>(BuildUri($"client-grants/{EncodePath(id)}/organizations", queryStrings), DefaultHeaders, organizationsConverters, cancellationToken);
            
        }
        /// <summary>
        /// Get the organizations associated to a client grant
        /// </summary>
        /// <param name="id">The identifier of the client grant.</param>
        /// <param name="pagination">Specifies <see cref="PaginationInfo"/> to use in requesting paged results.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>A <see cref="IPagedList{Organization}"/> containing the organizations requested.</returns>
        public Task<IPagedList<Organization>> GetAllOrganizationsAsync(string id, PaginationInfo pagination, CancellationToken cancellationToken = default)
        {
            if (pagination == null)
            {
                throw new ArgumentNullException(nameof(pagination));
            }

            var queryStrings = new Dictionary<string, string>
            {
                ["page"] = pagination.PageNo.ToString(),
                ["per_page"] = pagination.PerPage.ToString(),
                ["include_totals"] = pagination.IncludeTotals.ToString().ToLower()
            };
            
            return Connection.GetAsync<IPagedList<Organization>>(BuildUri($"client-grants/{EncodePath(id)}/organizations", queryStrings), DefaultHeaders, organizationsConverters, cancellationToken);
        }
        
        /// <summary>
        /// Get the organizations associated to a client grant
        /// </summary>
        /// <param name="id">The identifier of the client grant.</param>
        /// <param name="pagination">Specifies <see cref="CheckpointPaginationInfo"/> to use in requesting checkpoint-paginated results.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>A <see cref="IPagedList{Organization}"/> containing the organizations requested.</returns>
        public Task<IPagedList<Organization>> GetAllOrganizationsAsync(string id, CheckpointPaginationInfo pagination = null, CancellationToken cancellationToken = default)
        {
            if (pagination == null)
            {
                throw new ArgumentNullException(nameof(pagination));
            }

            var queryStrings = new Dictionary<string, string>
            {
                ["from"] = pagination.From?.ToString(),
                ["take"] = pagination.Take.ToString()
            };
            
            return Connection.GetAsync<IPagedList<Organization>>(BuildUri($"client-grants/{EncodePath(id)}/organizations", queryStrings), DefaultHeaders, organizationsConverters, cancellationToken);
        }
    }
}

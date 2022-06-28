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
    /// Contains methods to access the /resource-server endpoints.
    /// </summary>
    public class ResourceServersClient : BaseClient, IResourceServersClient
    {
        readonly JsonConverter[] converters = new JsonConverter[] { new PagedListConverter<ResourceServer>("resource_servers") };

        /// <summary>
        /// Creates a new instance of <see cref="ResourceServersClient"/>.
        /// </summary>
        /// <param name="connection"><see cref="IManagementConnection"/> used to make all API calls.</param>
        /// <param name="baseUri"><see cref="Uri"/> of the endpoint to use in making API calls.</param>
        /// <param name="defaultHeaders">Dictionary containing default headers included with every request this client makes.</param>
        public ResourceServersClient(IManagementConnection connection, Uri baseUri, IDictionary<string, string> defaultHeaders)
            : base(connection, baseUri, defaultHeaders)
        {
        }

        /// <summary>
        /// Creates a new resource server.
        /// </summary>
        /// <param name="request">Contains the information for the resource server to create.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The newly created <see cref="ResourceServer"/>.</returns>
        public Task<ResourceServer> CreateAsync(ResourceServerCreateRequest request, CancellationToken cancellationToken = default)
        {
            return Connection.SendAsync<ResourceServer>(HttpMethod.Post, BuildUri("resource-servers"), request, DefaultHeaders, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Deletes a resource server.
        /// </summary>
        /// <param name="id">The id of the resource server to delete.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous delete operation.</returns>
        public Task DeleteAsync(string id, CancellationToken cancellationToken = default)
        {
            return Connection.SendAsync<object>(HttpMethod.Delete, BuildUri($"resource-servers/{EncodePath(id)}"), null, DefaultHeaders, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Get a resource server by its id.
        /// </summary>
        /// <param name="id">The identifier of the resource server.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The <see cref="ResourceServer"/> that was requested.</returns>
        public Task<ResourceServer> GetAsync(string id, CancellationToken cancellationToken = default)
        {
            return Connection.GetAsync<ResourceServer>(BuildUri($"resource-servers/{EncodePath(id)}"), DefaultHeaders, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Gets a list of all the resource servers.
        /// </summary>
        /// <param name="pagination">Specifies pagination info to use when requesting paged results.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>A <see cref="IPagedList{ResourceServer}"/> containing the list of resource servers.</returns>
        public Task<IPagedList<ResourceServer>> GetAllAsync(PaginationInfo pagination = null, CancellationToken cancellationToken = default)
        {
            return Connection.GetAsync<IPagedList<ResourceServer>>(BuildUri("resource-servers",
                pagination != null ? new Dictionary<string, string>
                {
                    {"page", pagination.PageNo.ToString()},
                    {"per_page", pagination.PerPage.ToString()},
                    {"include_totals", pagination.IncludeTotals.ToString().ToLower()}
                } : null), DefaultHeaders, converters, cancellationToken);
        }

        /// <summary>
        /// Updates a resource server,
        /// </summary>
        /// <param name="id">The id of the resource server to update.</param>
        /// <param name="request">Contains the information for the resource server to update.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The newly updated <see cref="ResourceServer"/>.</returns>
        public Task<ResourceServer> UpdateAsync(string id, ResourceServerUpdateRequest request, CancellationToken cancellationToken = default)
        {
            return Connection.SendAsync<ResourceServer>(new HttpMethod("PATCH"), BuildUri($"resource-servers/{EncodePath(id)}"), request, DefaultHeaders, cancellationToken: cancellationToken);
        }
    }
}

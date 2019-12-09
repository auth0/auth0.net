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
    /// Contains methods to access the /resource-server endpoints.
    /// </summary>
    public class ResourceServersClient : BaseClient
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
        /// <returns>The newly created <see cref="ResourceServer"/>.</returns>
        public Task<ResourceServer> CreateAsync(ResourceServerCreateRequest request)
        {
            return Connection.SendAsync<ResourceServer>(HttpMethod.Post, BuildUri("resource-servers"), request, DefaultHeaders);
        }

        /// <summary>
        /// Deletes a resource server.
        /// </summary>
        /// <param name="id">The id of the resource server to delete.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous delete operation.</returns>
        public Task DeleteAsync(string id)
        {
            return Connection.SendAsync<object>(HttpMethod.Delete, BuildUri($"resource-servers/{id}"), null, DefaultHeaders);
        }

        /// <summary>
        /// Get a resource server by its id.
        /// </summary>
        /// <param name="id">The id of the resource server.</param>
        /// <returns>The <see cref="ResourceServer"/> that was requested.</returns>
        public Task<ResourceServer> GetAsync(string id)
        {
            return Connection.GetAsync<ResourceServer>(BuildUri($"resource-servers/{id}"), DefaultHeaders);
        }

        /// <summary>
        /// Gets a list of all the resource servers.
        /// </summary>
        /// <param name="pagination">Specifies pagination info to use when requesting paged results.</param>
        /// <returns>A <see cref="IPagedList{ResourceServer}"/> containing the list of resource servers.</returns>
        public Task<IPagedList<ResourceServer>> GetAllAsync(PaginationInfo pagination)
        {
            return Connection.GetAsync<IPagedList<ResourceServer>>(BuildUri("resource-servers",
                new Dictionary<string, string>
                {
                    {"page", pagination.PageNo.ToString()},
                    {"per_page", pagination.PerPage.ToString()},
                    {"include_totals", pagination.IncludeTotals.ToString().ToLower()}
                }), DefaultHeaders, converters);
        }

        /// <summary>
        /// Updates a resource server,
        /// </summary>
        /// <param name="id">The id of the resource server to update.</param>
        /// <param name="request">Contains the information for the resource server to update.</param>
        /// <returns>The newly updated <see cref="ResourceServer"/>.</returns>
        public Task<ResourceServer> UpdateAsync(string id, ResourceServerUpdateRequest request)
        {
            return Connection.SendAsync<ResourceServer>(new HttpMethod("PATCH"), BuildUri($"resource-servers/{id}"), request, DefaultHeaders);
        }
    }
}
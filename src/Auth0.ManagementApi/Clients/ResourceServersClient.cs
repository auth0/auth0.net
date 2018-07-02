using System.Collections.Generic;
using System.Threading.Tasks;
using Auth0.Core.Collections;
using Auth0.Core.Http;
using Auth0.ManagementApi.Models;
using Auth0.ManagementApi.Serialization;

namespace Auth0.ManagementApi.Clients
{
    /// <summary>
    /// Contains all the methods to call the /resource-server endpoints.
    /// </summary>
    public class ResourceServersClient : ClientBase, IResourceServersClient
    {
        /// <summary>
        /// Creates a new instance of the resource servers client.
        /// </summary>
        /// <param name="connection">The <see cref="IApiConnection" /> which is used to communicate with the API.</param>
        public ResourceServersClient(IApiConnection connection) : base(connection)
        {
        }

        /// <summary>
        /// Creates a new resource server
        /// </summary>
        /// <param name="request">Contains the information for the resource server to create</param>
        /// <returns></returns>
        public Task<ResourceServer> CreateAsync(ResourceServerCreateRequest request)
        {
            return Connection.PostAsync<ResourceServer>("resource-servers", request, null, null, null, null, null);
        }

        /// <summary>
        /// Deletes a resource server
        /// </summary>
        /// <param name="id">The id of the resource server to delete</param>
        /// <returns></returns>
        public Task DeleteAsync(string id)
        {
            return Connection.DeleteAsync<object>("resource-servers/{id}", new Dictionary<string, string>
            {
                {"id", id}
            }, null);
        }

        /// <summary>
        /// Get a resource server by its id
        /// </summary>
        /// <param name="id">The id of the resource server</param>
        /// <returns>A <see cref="ResourceServer"/></returns>
        public Task<ResourceServer> GetAsync(string id)
        {
            return Connection.GetAsync<ResourceServer>("resource-servers/{id}",
                new Dictionary<string, string>
                {
                    {"id", id}
                },
                null, null, null);
        }

        /// <inheritdoc />
        public Task<IPagedList<ResourceServer>> GetAllAsync(int? page = null, int? perPage = null, bool? includeTotals = null)
        {
            return Connection.GetAsync<IPagedList<ResourceServer>>("resource-servers", null,
                new Dictionary<string, string>
                {
                    {"page", page?.ToString()},
                    {"per_page", perPage?.ToString()},
                    {"include_totals", includeTotals?.ToString().ToLower()}
                }, null, new PagedListConverter<ResourceServer>("resource_servers"));
        }

        /// <summary>
        /// Updates a resource server
        /// </summary>
        /// <param name="id">The id of the resource server to update</param>
        /// <param name="request">Contains the information for the resource server to update</param>
        /// <returns></returns>
        public Task<ResourceServer> UpdateAsync(string id, ResourceServerUpdateRequest request)
        {
            return Connection.PatchAsync<ResourceServer>("resource-servers/{id}", request, new Dictionary<string, string>
            {
                {"id", id}
            });
        }
    }
}
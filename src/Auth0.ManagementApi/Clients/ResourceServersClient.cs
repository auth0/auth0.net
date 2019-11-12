﻿using Auth0.Core.Collections;
using Auth0.Core.Http;
using Auth0.ManagementApi.Models;
using Auth0.ManagementApi.Serialization;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Auth0.ManagementApi.Clients
{
    /// <summary>
    /// Contains all the methods to call the /resource-server endpoints.
    /// </summary>
    public class ResourceServersClient : ClientBase
    {
        /// <summary>
        /// Creates a new instance of <see cref="ResourceServersClient"/>.
        /// </summary>
        /// <param name="connection">The <see cref="IApiConnection" /> which is used to communicate with the API.</param>
        public ResourceServersClient(IApiConnection connection) : base(connection)
        {
        }

        /// <summary>
        /// Creates a new resource server.
        /// </summary>
        /// <param name="request">Contains the information for the resource server to create.</param>
        /// <returns>The newly created <see cref="ResourceServer"/>.</returns>
        public Task<ResourceServer> CreateAsync(ResourceServerCreateRequest request)
        {
            return Connection.RunAsync<ResourceServer>(HttpMethod.Post, "resource-servers", request);
        }

        /// <summary>
        /// Deletes a resource server.
        /// </summary>
        /// <param name="id">The id of the resource server to delete.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous delete operation.</returns>
        public Task DeleteAsync(string id)
        {
            return Connection.DeleteAsync<object>($"resource-servers/{id}");
        }

        /// <summary>
        /// Get a resource server by its id.
        /// </summary>
        /// <param name="id">The id of the resource server.</param>
        /// <returns>The <see cref="ResourceServer"/> that was requested.</returns>
        public Task<ResourceServer> GetAsync(string id)
        {
            return Connection.GetAsync<ResourceServer>($"resource-servers/{id}");
        }

        /// <summary>
        /// Gets a list of all the resource servers.
        /// </summary>
        /// <param name="pagination">Specifies pagination info to use when requesting paged results.</param>
        /// <returns>A <see cref="IPagedList{ResourceServer}"/> containing the list of resource servers.</returns>
        public Task<IPagedList<ResourceServer>> GetAllAsync(PaginationInfo pagination)
        {
            return Connection.GetAsync<IPagedList<ResourceServer>>("resource-servers", null,
                new Dictionary<string, string>
                {
                    {"page", pagination.PageNo.ToString()},
                    {"per_page", pagination.PerPage.ToString()},
                    {"include_totals", pagination.IncludeTotals.ToString().ToLower()}
                }, null, new PagedListConverter<ResourceServer>("resource_servers"));
        }

        /// <summary>
        /// Updates a resource server,
        /// </summary>
        /// <param name="id">The id of the resource server to update.</param>
        /// <param name="request">Contains the information for the resource server to update.</param>
        /// <returns>The newly updated <see cref="ResourceServer"/>.</returns>
        public Task<ResourceServer> UpdateAsync(string id, ResourceServerUpdateRequest request)
        {
            return Connection.PatchAsync<ResourceServer>($"resource-servers/{id}", request);
        }
    }
}
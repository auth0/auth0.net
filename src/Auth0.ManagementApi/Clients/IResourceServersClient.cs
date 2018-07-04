using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Auth0.Core.Collections;
using Auth0.ManagementApi.Models;

namespace Auth0.ManagementApi.Clients
{
    /// <summary>
    /// Contains all the methods to call the /resource-server endpoints.
    /// </summary>
    public interface IResourceServersClient
    {
        [Obsolete("Use GetAllAsync(PaginationInfo) instead")]
        Task<System.Collections.Generic.IList<ResourceServer>> GetAllAsync();

        /// <summary>
        /// Creates a new resource server
        /// </summary>
        /// <param name="request">Contains the information for the resource server to create</param>
        /// <returns></returns>
        Task<ResourceServer> CreateAsync(ResourceServerCreateRequest request);

        /// <summary>
        /// Deletes a resource server
        /// </summary>
        /// <param name="id">The id of the resource server to delete</param>
        /// <returns></returns>
        Task DeleteAsync(string id);

        /// <summary>
        /// Gets a list of all the resource servers.
        /// </summary>
        /// <param name="pagination">Specifies pagination info to use when requesting paged results.</param>
        /// <returns>A <see cref="IPagedList{ResourceServer}"/> containing the list of resource servers.</returns>
        Task<IPagedList<ResourceServer>> GetAllAsync(PaginationInfo pagination);

        /// <summary>
        /// Get a resource server by its id
        /// </summary>
        /// <param name="id">The id of the resource server</param>
        /// <returns>A <see cref="ResourceServer"/></returns>
        Task<ResourceServer> GetAsync(string id);

        /// <summary>
        /// Updates a resource server
        /// </summary>
        /// <param name="id">The id of the resource server to update</param>
        /// <param name="request">Contains the information for the resource server to update</param>
        /// <returns></returns>
        Task<ResourceServer> UpdateAsync(string id, ResourceServerUpdateRequest request);
    }
}
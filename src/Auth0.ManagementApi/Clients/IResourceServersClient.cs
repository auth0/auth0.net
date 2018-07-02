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
        /// Gets a list of all the client grants.
        /// </summary>
        /// <param name="page">The page number. Zero based.</param>
        /// <param name="perPage">The amount of entries per page.</param>
        /// <param name="includeTotals">True if a query summary must be included in the result.</param>
        /// <returns>A list of client grants</returns>
        Task<IPagedList<ResourceServer>> GetAllAsync(int? page = null, int? perPage = null, bool? includeTotals = null);

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
using System.Threading.Tasks;
using Auth0.ManagementApi.Models;

namespace Auth0.ManagementApi.Clients
{
    /// <summary>
    /// Contains all the methods to call the /resource-server endpoints.
    /// </summary>
    public interface IResourceServersClient
    {
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
using Auth0.ManagementApi.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using Auth0.Core.Collections;

namespace Auth0.ManagementApi.Clients
{
    /// <summary>
    /// Contains all methods to work with Client Grants.
    /// </summary>
    public interface IClientGrantsClient
    {
        /// <summary>
        /// Creates a new Client Grant
        /// </summary>
        /// <param name="request">The request containing the properties of the Client Grant.</param>
        /// <returns>The new <see cref="ClientGrant"/></returns>
        Task<ClientGrant> CreateAsync(ClientGrantCreateRequest request);

        /// <summary>
        /// Deletes a client grant.
        /// </summary>
        /// <param name="id">The identifier of the Client Grant to delete.</param>
        /// <returns></returns>
        Task DeleteAsync(string id);

        /// <summary>
        /// Gets a list of all the client grants.
        /// </summary>
        /// <param name="audience">The audience according to which you want to filter the returned client grants.</param>
        /// <param name="clientId">The Id of a client to filter</param>
        /// <returns>A list of client grants</returns>
        Task<IList<ClientGrant>> GetAllAsync(string audience = null, string clientId = null);

        /// <summary>
        /// Gets a list of all the client grants.
        /// </summary>
        /// <param name="page">The page number. Zero based.</param>
        /// <param name="perPage">The amount of entries per page.</param>
        /// <param name="includeTotals">True if a query summary must be included in the result.</param>
        /// <param name="audience">The audience according to which you want to filter the returned client grants.</param>
        /// <param name="clientId">The Id of a client to filter</param>
        /// <returns>A list of client grants</returns>
        Task<IPagedList<ClientGrant>> GetAllAsync(int? page = null, int? perPage = null, bool? includeTotals = null, string audience = null, string clientId = null);

        /// <summary>
        /// Updates a client grant
        /// </summary>
        /// <param name="id">The identifier of the client grant to update.</param>
        /// <param name="request">The <see cref="ClientGrantUpdateRequest"/> containing the properties to update.</param>
        /// <returns></returns>
        Task<ClientGrant> UpdateAsync(string id, ClientGrantUpdateRequest request);
    }
}
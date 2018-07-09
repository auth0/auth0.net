using System;
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
        /// <returns>A list of client grants</returns>
        [Obsolete("Use GetAllAsync(GetClientGrantsRequest) or GetAllAsync(GetClientGrantsRequest, PaginationInfo) instead")]
        Task<IList<ClientGrant>> GetAllAsync(string audience = null);

        /// <summary>
        /// Gets a list of all the client grants.
        /// </summary>
        /// <param name="request">Specifies criteria to use when querying client grants</param>
        /// <returns>A paged list of client grants</returns>
        Task<IPagedList<ClientGrant>> GetAllAsync(GetClientGrantsRequest request);

        /// <summary>
        /// Gets a list of all the client grants.
        /// </summary>
        /// <param name="request">Specifies criteria to use when querying client grants.</param>
        /// <param name="pagination">Specifies pagination info to use when requesting paged results.</param>
        /// <returns>A paged list of client grants</returns>
        Task<IPagedList<ClientGrant>> GetAllAsync(GetClientGrantsRequest request, PaginationInfo pagination);

        /// <summary>
        /// Updates a client grant
        /// </summary>
        /// <param name="id">The identifier of the client grant to update.</param>
        /// <param name="request">The <see cref="ClientGrantUpdateRequest"/> containing the properties to update.</param>
        /// <returns></returns>
        Task<ClientGrant> UpdateAsync(string id, ClientGrantUpdateRequest request);
    }
}
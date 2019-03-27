using System;
using Auth0.ManagementApi.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using Auth0.Core.Collections;

namespace Auth0.ManagementApi.Clients
{
    /// <summary>
    /// Contains all methods to call the /client-grants endpoints.
    /// </summary>
    public interface IClientGrantsClient
    {
        /// <summary>
        /// Creates a new client grant.
        /// </summary>
        /// <param name="request">The <see cref="ClientGrantCreateRequest"/> containing the properties of the Client Grant.</param>
        /// <returns>The new <see cref="ClientGrant"/> that has been created.</returns>
        Task<ClientGrant> CreateAsync(ClientGrantCreateRequest request);

        /// <summary>
        /// Deletes a client grant.
        /// </summary>
        /// <param name="id">The identifier of the Client Grant to delete.</param>
        /// <returns>A <see cref="Task"/> indicating the request completion.</returns>
        Task DeleteAsync(string id);

        /// <summary>
        /// Gets a list of all the client grants.
        /// </summary>
        /// <param name="request">Specifies criteria to use when querying client grants.</param>
        /// <param name="pagination">Specifies <see cref="PaginationInfo"/> to use in requesting paged results.</param>
        /// <returns>A <see cref="IPagedList"/> containing the matching <see cref="ClientGrant"/> instances.</returns>
        Task<IPagedList<ClientGrant>> GetAllAsync(GetClientGrantsRequest request, PaginationInfo pagination);

        /// <summary>
        /// Updates a client grant.
        /// </summary>
        /// <param name="id">The identifier of the client grant to update.</param>
        /// <param name="request">The <see cref="ClientGrantUpdateRequest"/> containing the properties to update.</param>
        /// <returns>The <see cref="ClientGrant"/> that has been updated.</returns>
        Task<ClientGrant> UpdateAsync(string id, ClientGrantUpdateRequest request);
    }
}
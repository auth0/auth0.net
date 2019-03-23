using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Auth0.Core.Collections;
using Auth0.ManagementApi.Models;

namespace Auth0.ManagementApi.Clients
{
    /// <summary>
    /// Contains all the methods to call the /roles endpoints.
    /// </summary>
    public interface IRolesClient
    {
        /// <summary>
        ///     Creates a new role according to the request.
        /// </summary>
        /// <param name="request">The <see cref="RoleCreateRequest" /> containing the details of the role to create.</param>
        /// <returns>The newly created <see cref="Role" />.</returns>
        Task<Role> CreateAsync(RoleCreateRequest request);

        /// <summary>
        ///     Deletes a role.
        /// </summary>
        /// <param name="id">The ID of the role to delete.</param>
        Task DeleteAsync(string id);

        /// <summary>
        /// Retrieves a list of all roles.
        /// </summary>
        /// <param name="request">Specifies criteria to use when querying roles.</param>
        /// <returns>An <see cref="IPagedList{Role}"/> containing the roles</returns>
        Task<IPagedList<Role>> GetAllAsync(GetRolesRequest request);

        /// <summary>
        /// Retrieves a list of all roles.
        /// </summary>
        /// <param name="request">Specifies criteria to use when querying roles.</param>
        /// <param name="pagination">Specifies pagination info to use when requesting paged results.</param>
        /// <returns>An <see cref="IPagedList{Role}"/> containing the roles</returns>
        Task<IPagedList<Role>> GetAllAsync(GetRolesRequest request, PaginationInfo pagination);

        /// <summary>
        ///     Retrieves a role by its ID.
        /// </summary>
        /// <param name="id">The ID of the role to retrieve.</param>
        /// <returns>The <see cref="Role" />.</returns>
        Task<Role> GetAsync(string id);

        /// <summary>
        ///     Updates a role.
        /// </summary>
        /// <param name="id">The ID of the role to update.</param>
        /// <param name="request">A <see cref="RoleUpdateRequest" /> containing the information to update.</param>
        /// <returns></returns>
        Task<Role> UpdateAsync(string id, RoleUpdateRequest request);
    }
}

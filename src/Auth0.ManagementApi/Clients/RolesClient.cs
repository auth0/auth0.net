using Auth0.Core.Collections;
using Auth0.Core.Http;
using Auth0.ManagementApi.Models;
using Auth0.ManagementApi.Serialization;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Auth0.ManagementApi.Clients
{
    /// <summary>
    /// Contains all the methods to call the /roles endpoints.
    /// </summary>
    public class RolesClient : ClientBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RolesClient"/> class.
        /// </summary>
        /// <param name="connection">The <see cref="ApiConnection"/> to use.</param>
        public RolesClient(IApiConnection connection)
            : base(connection)
        {
        }

        /// <summary>
        /// Creates a new role according to the request.
        /// </summary>
        /// <param name="request">The <see cref="RoleCreateRequest"/> containing the details of the role to create.</param>
        /// <returns>The newly created <see cref="Role" />.</returns>
        public Task<Role> CreateAsync(RoleCreateRequest request)
        {
            return Connection.RunAsync<Role>(HttpMethod.Post, "roles", request, null, null, null, null, null);
        }

        /// <summary>
        /// Deletes a role.
        /// </summary>
        /// <param name="id">The ID of the role to delete.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous delete operation.</returns>
        public Task DeleteAsync(string id)
        {
            return Connection.DeleteAsync<object>("roles/{id}", new Dictionary<string, string>
            {
                {"id", id}
            }, null);
        }

        /// <summary>
        /// Retrieves a list of all roles.
        /// </summary>
        /// <param name="request">Specifies criteria to use when querying roles.</param>
        /// <returns>An <see cref="IPagedList{Role}"/> containing the roles</returns>
        public Task<IPagedList<Role>> GetAllAsync(GetRolesRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return Connection.GetAsync<IPagedList<Role>>("roles", null,
                new Dictionary<string, string>
                {
                    {"name_filter", request.NameFilter},
                }, null, new PagedListConverter<Role>("roles"));
        }

        /// <summary>
        /// Retrieves a list of all roles.
        /// </summary>
        /// <param name="request">Specifies criteria to use when querying roles.</param>
        /// <param name="pagination">Specifies pagination info to use when requesting paged results.</param>
        /// <returns>An <see cref="IPagedList{Role}"/> containing the roles requested.</returns>
        public Task<IPagedList<Role>> GetAllAsync(GetRolesRequest request, PaginationInfo pagination)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));
            if (pagination == null)
                throw new ArgumentNullException(nameof(pagination));

            return Connection.GetAsync<IPagedList<Role>>("roles", null,
                new Dictionary<string, string>
                {
                    {"name_filter", request.NameFilter},
                    {"page", pagination.PageNo.ToString()},
                    {"per_page", pagination.PerPage.ToString()},
                    {"include_totals", pagination.IncludeTotals.ToString().ToLower()}
                }, null, new PagedListConverter<Role>("roles"));
        }

        /// <summary>
        /// Retrieves a role by its ID.
        /// </summary>
        /// <param name="id">The ID of the role to retrieve.</param>
        /// <returns>The <see cref="Role"/> that was requested.</returns>
        public Task<Role> GetAsync(string id)
        {
            return Connection.GetAsync<Role>("roles/{id}",
                new Dictionary<string, string>
                {
                    {"id", id}
                }, null, null, null);
        }

        /// <summary>
        /// Updates a role.
        /// </summary>
        /// <param name="id">The ID of the role to update.</param>
        /// <param name="request">A <see cref="RoleUpdateRequest" /> containing the information to update.</param>
        /// <returns>The newly updated <see cref="Role"/>.</returns>
        public Task<Role> UpdateAsync(string id, RoleUpdateRequest request)
        {
            return Connection.PatchAsync<Role>("roles/{id}", request, new Dictionary<string, string>
            {
                {"id", id}
            });
        }

        /// <summary>
        /// Retrieves a list of users associated with a role.
        /// </summary>
        /// <param name="id">The ID of the role to query.</param>
        /// <returns>An <see cref="IPagedList{AssignedUser}"/> containing the assigned users.</returns>
        public Task<IPagedList<AssignedUser>> GetUsersAsync(string id)
        {
            return Connection.GetAsync<IPagedList<AssignedUser>>("roles/{id}/users",
                new Dictionary<string, string>
                {
                    {"id", id}
                }, null, null, new PagedListConverter<AssignedUser>("users"));
        }

        /// <summary>
        /// Retrieves a list of users associated with a role.
        /// </summary>
        /// <param name="id">The ID of the role to query.</param>
        /// <param name="pagination">Specifies <see cref="PaginationInfo"/> to use in requesting paged results.</param>
        /// <returns>An <see cref="IPagedList{AssignedUser}"/> containing the assigned users.</returns>
        public Task<IPagedList<AssignedUser>> GetUsersAsync(string id, PaginationInfo pagination)
        {
            return Connection.GetAsync<IPagedList<AssignedUser>>("roles/{id}/users",
                new Dictionary<string, string>
                {
                    {"id", id}
                },
                new Dictionary<string, string>
                {
                    {"page", pagination.PageNo.ToString()},
                    {"per_page", pagination.PerPage.ToString()},
                    {"include_totals", pagination.IncludeTotals.ToString().ToLower()}
                }, null, new PagedListConverter<AssignedUser>("users"));
        }

        /// <summary>
        /// Assigns Users to a role.
        /// </summary>
        /// <param name="id">The ID of the role to assign users to.</param>
        /// <param name="request">A <see cref="AssignUsersRequest" /> containing the user IDs to assign to the role.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous assign operation.</returns>
        public Task AssignUsersAsync(string id, AssignUsersRequest request)
        {
            return Connection.RunAsync<AssignUsersRequest>(HttpMethod.Post, "roles/{id}/users", request, null, null,
                new Dictionary<string, string>
                {
                    {"id", id},
                }, null, null);
        }

        /// <summary>
        /// Gets the permissions assigned to a role.
        /// </summary>
        /// <param name="id">The id of the role to obtain the permissions for.</param>
        /// <param name="pagination">Specifies <see cref="PaginationInfo"/> to use in requesting paged results.</param>
        /// <returns>An <see cref="IPagedList{Permission}"/> containing the assigned permissions for this role.</returns>
        public Task<IPagedList<Permission>> GetPermissionsAsync(string id, PaginationInfo pagination)
        {
            return Connection.GetAsync<IPagedList<Permission>>("roles/{id}/permissions",
                new Dictionary<string, string>
                {
                    {"id", id}
                },
                new Dictionary<string, string>
                {
                    {"page", pagination.PageNo.ToString()},
                    {"per_page", pagination.PerPage.ToString()},
                    {"include_totals", pagination.IncludeTotals.ToString().ToLower()}
                }, null, new PagedListConverter<Permission>("permissions"));
        }

        /// <summary>
        /// Assign permissions to a role.
        /// </summary>
        /// <param name="id">The ID of the role to assign permissions to.</param>
        /// <param name="request">A <see cref="AssignPermissionsRequest" /> containing the permission identifiers to assign to the role.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous assignment operation.</returns>
        public Task AssignPermissionsAsync(string id, AssignPermissionsRequest request)
        {
            return Connection.RunAsync<object>(HttpMethod.Post, "roles/{id}/permissions", request, null, null,
                new Dictionary<string, string> { { "id", id}, }, null, null);
        }

        /// <summary>
        /// Remove permissions assigned to a role.
        /// </summary>
        /// <param name="id">The ID of the role to remove permissions from.</param>
        /// <param name="request">A <see cref="AssignPermissionsRequest" /> containing the permission identifiers to remove from the role.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous remove operation.</returns>
        public Task RemovePermissionsAsync(string id, AssignPermissionsRequest request)
        {
            return Connection.DeleteAsync<object>("roles/{id}/permissions", request,
                new Dictionary<string, string> { {"id", id}, }, null);
        }
    }
}

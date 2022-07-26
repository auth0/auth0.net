using Auth0.ManagementApi.Models;
using Auth0.ManagementApi.Paging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Auth0.ManagementApi.Clients
{
    /// <summary>
    /// Contains methods to access the /roles endpoints.
    /// </summary>
    public class RolesClient : BaseClient, IRolesClient
    {
        readonly JsonConverter[] rolesConverters = new JsonConverter[] { new PagedListConverter<Role>("roles") };
        readonly JsonConverter[] assignedUsersConverters = new JsonConverter[] { new PagedListConverter<AssignedUser>("users") };
        readonly JsonConverter[] assignedUsersCheckpointConverters = new JsonConverter[] { new CheckpointPagedListConverter<AssignedUser>("users") };
        readonly JsonConverter[] permissionsConverters = new JsonConverter[] { new PagedListConverter<Permission>("permissions") };

        /// <summary>
        /// Initializes a new instance of the <see cref="RolesClient"/> class.
        /// </summary>
        /// <param name="connection"><see cref="IManagementConnection"/> used to make all API calls.</param>
        /// <param name="baseUri"><see cref="Uri"/> of the endpoint to use in making API calls.</param>
        /// <param name="defaultHeaders">Dictionary containing default headers included with every request this client makes.</param>
        public RolesClient(IManagementConnection connection, Uri baseUri, IDictionary<string, string> defaultHeaders)
            : base(connection, baseUri, defaultHeaders)
        {
        }

        /// <summary>
        /// Creates a new role according to the request.
        /// </summary>
        /// <param name="request">The <see cref="RoleCreateRequest"/> containing the details of the role to create.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The newly created <see cref="Role" />.</returns>
        public Task<Role> CreateAsync(RoleCreateRequest request, CancellationToken cancellationToken = default)
        {
            return Connection.SendAsync<Role>(HttpMethod.Post, BuildUri("roles"), request, DefaultHeaders, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Deletes a role.
        /// </summary>
        /// <param name="id">The ID of the role to delete.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous delete operation.</returns>
        public Task DeleteAsync(string id, CancellationToken cancellationToken = default)
        {
            return Connection.SendAsync<object>(HttpMethod.Delete, BuildUri($"roles/{EncodePath(id)}"), null, DefaultHeaders, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Retrieves a list of all roles.
        /// </summary>
        /// <param name="request">Specifies criteria to use when querying roles.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>An <see cref="IPagedList{Role}"/> containing the roles</returns>
        public Task<IPagedList<Role>> GetAllAsync(GetRolesRequest request, CancellationToken cancellationToken = default)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return Connection.GetAsync<IPagedList<Role>>(BuildUri("roles",
                new Dictionary<string, string> { { "name_filter", request.NameFilter } }),
                DefaultHeaders,
                rolesConverters, cancellationToken);
        }

        /// <summary>
        /// Retrieves a list of all roles.
        /// </summary>
        /// <param name="request">Specifies criteria to use when querying roles.</param>
        /// <param name="pagination">Specifies pagination info to use when requesting paged results.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>An <see cref="IPagedList{Role}"/> containing the roles requested.</returns>
        public Task<IPagedList<Role>> GetAllAsync(GetRolesRequest request, PaginationInfo pagination, CancellationToken cancellationToken = default)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));
            if (pagination == null)
                throw new ArgumentNullException(nameof(pagination));

            return Connection.GetAsync<IPagedList<Role>>(BuildUri($"roles",
                new Dictionary<string, string>
                {
                    {"name_filter", request.NameFilter},
                    {"page", pagination.PageNo.ToString()},
                    {"per_page", pagination.PerPage.ToString()},
                    {"include_totals", pagination.IncludeTotals.ToString().ToLower()}
                }), DefaultHeaders, rolesConverters, cancellationToken);
        }

        /// <summary>
        /// Retrieves a role by its ID.
        /// </summary>
        /// <param name="id">The ID of the role to retrieve.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The <see cref="Role"/> that was requested.</returns>
        public Task<Role> GetAsync(string id, CancellationToken cancellationToken = default)
        {
            return Connection.GetAsync<Role>(BuildUri($"roles/{EncodePath(id)}"), DefaultHeaders, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Updates a role.
        /// </summary>
        /// <param name="id">The ID of the role to update.</param>
        /// <param name="request">A <see cref="RoleUpdateRequest" /> containing the information to update.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The newly updated <see cref="Role"/>.</returns>
        public Task<Role> UpdateAsync(string id, RoleUpdateRequest request, CancellationToken cancellationToken = default)
        {
            return Connection.SendAsync<Role>(new HttpMethod("PATCH"), BuildUri($"roles/{EncodePath(id)}"), request, DefaultHeaders, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Retrieves a list of users associated with a role.
        /// </summary>
        /// <param name="id">The ID of the role to query.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>An <see cref="IPagedList{AssignedUser}"/> containing the assigned users.</returns>
        public Task<IPagedList<AssignedUser>> GetUsersAsync(string id, CancellationToken cancellationToken = default)
        {
            return Connection.GetAsync<IPagedList<AssignedUser>>(BuildUri($"roles/{EncodePath(id)}/users"), DefaultHeaders, assignedUsersConverters, cancellationToken);
        }

        /// <summary>
        /// Retrieves a list of users associated with a role.
        /// </summary>
        /// <param name="id">The ID of the role to query.</param>
        /// <param name="pagination">Specifies <see cref="PaginationInfo"/> to use in requesting paged results.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>An <see cref="IPagedList{AssignedUser}"/> containing the assigned users.</returns>
        public Task<IPagedList<AssignedUser>> GetUsersAsync(string id, PaginationInfo pagination, CancellationToken cancellationToken = default)
        {
            return Connection.GetAsync<IPagedList<AssignedUser>>(BuildUri($"roles/{EncodePath(id)}/users",
                new Dictionary<string, string>
                {
                    {"page", pagination.PageNo.ToString()},
                    {"per_page", pagination.PerPage.ToString()},
                    {"include_totals", pagination.IncludeTotals.ToString().ToLower()}
                }), DefaultHeaders, assignedUsersConverters, cancellationToken);
        }

        /// <summary>
        /// Retrieves a list of users associated with a role.
        /// </summary>
        /// <param name="id">The ID of the role to query.</param>
        /// <param name="pagination">Specifies <see cref="CheckpointPaginationInfo"/> to use in requesting checkpoint-paginated results.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>An <see cref="IPagedList{AssignedUser}"/> containing the assigned users.</returns>
        public Task<ICheckpointPagedList<AssignedUser>> GetUsersAsync(string id, CheckpointPaginationInfo pagination, CancellationToken cancellationToken = default)
        {
            return Connection.GetAsync<ICheckpointPagedList<AssignedUser>>(BuildUri($"roles/{EncodePath(id)}/users",
                new Dictionary<string, string>
                {
                    {"from", pagination.From?.ToString()},
                    {"take", pagination.Take.ToString()},
                }), DefaultHeaders, assignedUsersCheckpointConverters, cancellationToken);
        }

        /// <summary>
        /// Assigns Users to a role.
        /// </summary>
        /// <param name="id">The ID of the role to assign users to.</param>
        /// <param name="request">A <see cref="AssignUsersRequest" /> containing the user IDs to assign to the role.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous assign operation.</returns>
        public Task AssignUsersAsync(string id, AssignUsersRequest request, CancellationToken cancellationToken = default)
        {
            return Connection.SendAsync<AssignUsersRequest>(HttpMethod.Post, BuildUri($"roles/{EncodePath(id)}/users"), request, DefaultHeaders, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Gets the permissions assigned to a role.
        /// </summary>
        /// <param name="id">The id of the role to obtain the permissions for.</param>
        /// <param name="pagination">Specifies <see cref="PaginationInfo"/> to use in requesting paged results.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>An <see cref="IPagedList{Permission}"/> containing the assigned permissions for this role.</returns>
        public Task<IPagedList<Permission>> GetPermissionsAsync(string id, PaginationInfo pagination, CancellationToken cancellationToken = default)
        {
            return Connection.GetAsync<IPagedList<Permission>>(BuildUri($"roles/{EncodePath(id)}/permissions",
                new Dictionary<string, string>
                {
                    {"page", pagination.PageNo.ToString()},
                    {"per_page", pagination.PerPage.ToString()},
                    {"include_totals", pagination.IncludeTotals.ToString().ToLower()}
                }), DefaultHeaders, permissionsConverters, cancellationToken);
        }

        /// <summary>
        /// Assign permissions to a role.
        /// </summary>
        /// <param name="id">The ID of the role to assign permissions to.</param>
        /// <param name="request">A <see cref="AssignPermissionsRequest" /> containing the permission identifiers to assign to the role.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous assignment operation.</returns>
        public Task AssignPermissionsAsync(string id, AssignPermissionsRequest request, CancellationToken cancellationToken = default)
        {
            return Connection.SendAsync<object>(HttpMethod.Post, BuildUri($"roles/{EncodePath(id)}/permissions"), request, DefaultHeaders, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Remove permissions assigned to a role.
        /// </summary>
        /// <param name="id">The ID of the role to remove permissions from.</param>
        /// <param name="request">A <see cref="AssignPermissionsRequest" /> containing the permission identifiers to remove from the role.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous remove operation.</returns>
        public Task RemovePermissionsAsync(string id, AssignPermissionsRequest request, CancellationToken cancellationToken = default)
        {
            return Connection.SendAsync<object>(HttpMethod.Delete, BuildUri($"roles/{EncodePath(id)}/permissions"), request, DefaultHeaders, cancellationToken: cancellationToken);
        }
    }
}

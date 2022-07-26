namespace Auth0.ManagementApi.Clients
{
  using System.Threading;
  using System.Threading.Tasks;
  using Models;
  using Paging;

  public interface IRolesClient
  {
    /// <summary>
    /// Creates a new role according to the request.
    /// </summary>
    /// <param name="request">The <see cref="RoleCreateRequest"/> containing the details of the role to create.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>The newly created <see cref="Role" />.</returns>
    Task<Role> CreateAsync(RoleCreateRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a role.
    /// </summary>
    /// <param name="id">The ID of the role to delete.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>A <see cref="Task"/> that represents the asynchronous delete operation.</returns>
    Task DeleteAsync(string id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a list of all roles.
    /// </summary>
    /// <param name="request">Specifies criteria to use when querying roles.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>An <see cref="IPagedList{Role}"/> containing the roles</returns>
    Task<IPagedList<Role>> GetAllAsync(GetRolesRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a list of all roles.
    /// </summary>
    /// <param name="request">Specifies criteria to use when querying roles.</param>
    /// <param name="pagination">Specifies pagination info to use when requesting paged results.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>An <see cref="IPagedList{Role}"/> containing the roles requested.</returns>
    Task<IPagedList<Role>> GetAllAsync(GetRolesRequest request, PaginationInfo pagination, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a role by its ID.
    /// </summary>
    /// <param name="id">The ID of the role to retrieve.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>The <see cref="Role"/> that was requested.</returns>
    Task<Role> GetAsync(string id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates a role.
    /// </summary>
    /// <param name="id">The ID of the role to update.</param>
    /// <param name="request">A <see cref="RoleUpdateRequest" /> containing the information to update.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>The newly updated <see cref="Role"/>.</returns>
    Task<Role> UpdateAsync(string id, RoleUpdateRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a list of users associated with a role.
    /// </summary>
    /// <param name="id">The ID of the role to query.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>An <see cref="IPagedList{AssignedUser}"/> containing the assigned users.</returns>
    Task<IPagedList<AssignedUser>> GetUsersAsync(string id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a list of users associated with a role.
    /// </summary>
    /// <param name="id">The ID of the role to query.</param>
    /// <param name="pagination">Specifies <see cref="PaginationInfo"/> to use in requesting paged results.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>An <see cref="IPagedList{AssignedUser}"/> containing the assigned users.</returns>
    Task<IPagedList<AssignedUser>> GetUsersAsync(string id, PaginationInfo pagination, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a list of users associated with a role.
    /// </summary>
    /// <param name="id">The ID of the role to query.</param>
    /// <param name="pagination">Specifies <see cref="CheckpointPaginationInfo"/> to use in requesting checkpoint-paginated results.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>An <see cref="IPagedList{AssignedUser}"/> containing the assigned users.</returns>
    Task<ICheckpointPagedList<AssignedUser>> GetUsersAsync(string id, CheckpointPaginationInfo pagination, CancellationToken cancellationToken = default);

    /// <summary>
    /// Assigns Users to a role.
    /// </summary>
    /// <param name="id">The ID of the role to assign users to.</param>
    /// <param name="request">A <see cref="AssignUsersRequest" /> containing the user IDs to assign to the role.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>A <see cref="Task"/> that represents the asynchronous assign operation.</returns>
    Task AssignUsersAsync(string id, AssignUsersRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets the permissions assigned to a role.
    /// </summary>
    /// <param name="id">The id of the role to obtain the permissions for.</param>
    /// <param name="pagination">Specifies <see cref="PaginationInfo"/> to use in requesting paged results.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>An <see cref="IPagedList{Permission}"/> containing the assigned permissions for this role.</returns>
    Task<IPagedList<Permission>> GetPermissionsAsync(string id, PaginationInfo pagination, CancellationToken cancellationToken = default);

    /// <summary>
    /// Assign permissions to a role.
    /// </summary>
    /// <param name="id">The ID of the role to assign permissions to.</param>
    /// <param name="request">A <see cref="AssignPermissionsRequest" /> containing the permission identifiers to assign to the role.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>A <see cref="Task"/> that represents the asynchronous assignment operation.</returns>
    Task AssignPermissionsAsync(string id, AssignPermissionsRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Remove permissions assigned to a role.
    /// </summary>
    /// <param name="id">The ID of the role to remove permissions from.</param>
    /// <param name="request">A <see cref="AssignPermissionsRequest" /> containing the permission identifiers to remove from the role.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>A <see cref="Task"/> that represents the asynchronous remove operation.</returns>
    Task RemovePermissionsAsync(string id, AssignPermissionsRequest request, CancellationToken cancellationToken = default);
  }
}

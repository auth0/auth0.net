namespace Auth0.ManagementApi.Clients
{
  using System.Threading;
  using System.Threading.Tasks;
  using Models;
  using Paging;

  public interface IClientGrantsClient
  {
    /// <summary>
    /// Creates a new client grant.
    /// </summary>
    /// <param name="request">The <see cref="ClientGrantCreateRequest"/> containing the properties of the Client Grant.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>The new <see cref="ClientGrant"/> that has been created.</returns>
    Task<ClientGrant> CreateAsync(ClientGrantCreateRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a client grant.
    /// </summary>
    /// <param name="id">The identifier of the Client Grant to delete.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>A <see cref="Task"/> that represents the asynchronous delete operation.</returns>
    Task DeleteAsync(string id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets a list of all the client grants.
    /// </summary>
    /// <param name="request">Specifies criteria to use when querying client grants.</param>
    /// <param name="pagination">Specifies <see cref="PaginationInfo"/> to use in requesting paged results.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>A <see cref="IPagedList{ClientGrant}"/> containing the client grants requested.</returns>
    Task<IPagedList<ClientGrant>> GetAllAsync(GetClientGrantsRequest request, PaginationInfo pagination = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates a client grant.
    /// </summary>
    /// <param name="id">The identifier of the client grant to update.</param>
    /// <param name="request">The <see cref="ClientGrantUpdateRequest"/> containing the properties to update.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>The <see cref="ClientGrant"/> that has been updated.</returns>
    Task<ClientGrant> UpdateAsync(string id, ClientGrantUpdateRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get the organizations associated to a client grant
    /// </summary>
    /// <param name="id">The identifier of the client grant.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>A <see cref="IPagedList{Organization}"/> containing the organizations requested.</returns>
    Task<IPagedList<Organization>> GetAllOrganizationsAsync(string id, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Get the organizations associated to a client grant
    /// </summary>
    /// <param name="id">The identifier of the client grant.</param>
    /// <param name="pagination">Specifies <see cref="PaginationInfo"/> to use in requesting paged results.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>A <see cref="IPagedList{Organization}"/> containing the organizations requested.</returns>
    Task<IPagedList<Organization>> GetAllOrganizationsAsync(string id, PaginationInfo pagination,
      CancellationToken cancellationToken = default);

    /// <summary>
    /// Get the organizations associated to a client grant
    /// </summary>
    /// <param name="id">The identifier of the client grant.</param>
    /// <param name="pagination">Specifies <see cref="CheckpointPaginationInfo"/> to use in requesting checkpoint-paginated results.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>A <see cref="IPagedList{Organization}"/> containing the organizations requested.</returns>
    Task<IPagedList<Organization>> GetAllOrganizationsAsync(string id, CheckpointPaginationInfo pagination,
      CancellationToken cancellationToken = default);
  }
}

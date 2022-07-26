namespace Auth0.ManagementApi.Clients
{
  using System.Threading;
  using System.Threading.Tasks;
  using Models;
  using Paging;

  public interface IResourceServersClient
  {
    /// <summary>
    /// Creates a new resource server.
    /// </summary>
    /// <param name="request">Contains the information for the resource server to create.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>The newly created <see cref="ResourceServer"/>.</returns>
    Task<ResourceServer> CreateAsync(ResourceServerCreateRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a resource server.
    /// </summary>
    /// <param name="id">The id of the resource server to delete.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>A <see cref="Task"/> that represents the asynchronous delete operation.</returns>
    Task DeleteAsync(string id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get a resource server by its id.
    /// </summary>
    /// <param name="id">The identifier of the resource server.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>The <see cref="ResourceServer"/> that was requested.</returns>
    Task<ResourceServer> GetAsync(string id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets a list of all the resource servers.
    /// </summary>
    /// <param name="pagination">Specifies pagination info to use when requesting paged results.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>A <see cref="IPagedList{ResourceServer}"/> containing the list of resource servers.</returns>
    Task<IPagedList<ResourceServer>> GetAllAsync(PaginationInfo pagination = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates a resource server,
    /// </summary>
    /// <param name="id">The id of the resource server to update.</param>
    /// <param name="request">Contains the information for the resource server to update.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>The newly updated <see cref="ResourceServer"/>.</returns>
    Task<ResourceServer> UpdateAsync(string id, ResourceServerUpdateRequest request, CancellationToken cancellationToken = default);
  }
}

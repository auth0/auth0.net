namespace Auth0.ManagementApi.Clients
{
  using System.Threading;
  using System.Threading.Tasks;
  using Models;
  using Paging;

  public interface IHooksClient
  {
    /// <summary>
    /// Creates a new hook according to the request.
    /// </summary>
    /// <param name="request">The <see cref="HookCreateRequest" /> containing the details of the hook to create.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>The newly created <see cref="Hook" />.</returns>
    Task<Hook> CreateAsync(HookCreateRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a hook.
    /// </summary>
    /// <param name="id">The ID of the hook to delete.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>A <see cref="Task"/> that represents the asynchronous delete operation.</returns>
    Task DeleteAsync(string id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a list of all hooks.
    /// </summary>
    /// <param name="request">Specifies criteria to use when querying hooks.</param>
    /// <param name="pagination">Specifies pagination info to use when requesting paged results.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>An <see cref="IPagedList{T}"/> containing the hooks requested.</returns>
    Task<IPagedList<Hook>> GetAllAsync(GetHooksRequest request, PaginationInfo pagination = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a hook by its ID.
    /// </summary>
    /// <param name="id">The ID of the hook to retrieve.</param>
    /// <param name="fields">
    /// A comma separated list of fields to include, empty to retrieve all fields.
    /// </param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>The <see cref="Hook" /> that was requested.</returns>
    Task<Hook> GetAsync(string id, string fields = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates a hook.
    /// </summary>
    /// <param name="id">The ID of the hook to update.</param>
    /// <param name="request">A <see cref="HookUpdateRequest" /> containing the information to update.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>The newly updated <see cref="Hook"/>.</returns>
    Task<Hook> UpdateAsync(string id, HookUpdateRequest request, CancellationToken cancellationToken = default);
  }
}

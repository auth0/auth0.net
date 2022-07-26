namespace Auth0.ManagementApi.Clients
{
  using System.Threading;
  using System.Threading.Tasks;
  using Models;
  using Paging;

  public interface IClientsClient
  {
    /// <summary>
    /// Creates a new client application.
    /// </summary>
    /// <param name="request">The <see cref="ClientCreateRequest"/> containing the properties of the new client.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>The new <see cref="Client"/> that has been created.</returns>
    Task<Client> CreateAsync(ClientCreateRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a client and all its related assets (like rules, connections, etc) given its id.
    /// </summary>
    /// <param name="id">The id of the client to delete.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>A <see cref="Task"/> that represents the asynchronous delete operation.</returns>
    Task DeleteAsync(string id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a list of all client applications.
    /// </summary>
    /// <param name="request">Specifies criteria to use when querying clients.</param>
    /// <param name="pagination">Specifies pagination info to use when requesting paged results.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>An <see cref="IPagedList{Client}"/> containing the clients.</returns>
    Task<IPagedList<Client>> GetAllAsync(GetClientsRequest request, PaginationInfo pagination = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a client by its id.
    /// </summary>
    /// <param name="id">The id of the client to retrieve.</param>
    /// <param name="fields">
    /// A comma separated list of fields to include or exclude (depending on includeFields) from the
    /// result, empty to retrieve all fields.
    /// </param>
    /// <param name="includeFields">
    /// true if the fields specified are to be included in the result, false otherwise (defaults to
    /// true)
    /// </param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>The <see cref="Client"/> retrieved.</returns>
    Task<Client> GetAsync(string id, string fields = null, bool includeFields = true, CancellationToken cancellationToken = default);

    /// <summary>
    /// Rotate a client secret. The generated secret is NOT base64 encoded.
    /// </summary>
    /// <param name="id">The id of the client which secret needs to be rotated.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>The <see cref="Client"/> that has had its secret rotated.</returns>
    Task<Client> RotateClientSecret(string id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates a client application.
    /// </summary>
    /// <param name="id">The id of the client you want to update.</param>
    /// <param name="request">The <see cref="ClientUpdateRequest"/> containing the properties of the client you want to update.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>The <see cref="Client"/> that was updated.</returns>
    Task<Client> UpdateAsync(string id, ClientUpdateRequest request, CancellationToken cancellationToken = default);
  }
}

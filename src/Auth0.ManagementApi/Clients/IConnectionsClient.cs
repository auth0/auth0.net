namespace Auth0.ManagementApi.Clients
{
  using System.Threading;
  using System.Threading.Tasks;
  using Models;
  using Paging;

  public interface IConnectionsClient
  {
    /// <summary>
    /// Creates a new connection according to the request.
    /// </summary>
    /// <param name="request">The request containing the properties for the new connection.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>A <see cref="Connection"/> containing the newly created Connection.</returns>
    Task<Connection> CreateAsync(ConnectionCreateRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a connection and all its users.
    /// </summary>
    /// <param name="id">The id of the connection to delete.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>A <see cref="Task"/> that represents the asynchronous delete operation.</returns>
    Task DeleteAsync(string id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a specified connection user by its <paramref name="email"/>.
    /// </summary>
    /// <remarks>
    /// Currently only database connections are supported and you cannot delete all users from specific connection.
    /// </remarks>
    /// <param name="id">The identifier of the connection.</param>
    /// <param name="email">The email of the user to delete.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>A <see cref="Task"/> that represents the asynchronous delete operation.</returns>
    Task DeleteUserAsync(string id, string email, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a connection by its <paramref name="id"/>.
    /// </summary>
    /// <param name="id">The id of the connection to retrieve.</param>
    /// <param name="fields">A comma separated list of fields to include or exclude (depending on include_fields) from the result, empty to retrieve all fields.</param>
    /// <param name="includeFields">True if the fields specified are to be included in the result, false otherwise (defaults to true).</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>The <see cref="Connection"/>.</returns>
    Task<Connection> GetAsync(string id, string fields = null, bool includeFields = true, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves every connection matching the specified strategy. All connections are retrieved if no strategy is being specified. Accepts a list of fields to include or exclude in the resulting list of connection objects.
    /// </summary>
    /// <param name="request">Specifies criteria to use when querying connections.</param>
    /// <param name="pagination">Specifies pagination info to use when requesting paged results.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>An <see cref="IPagedList{Connection}"/> containing the list of connections.</returns>
    Task<IPagedList<Connection>> GetAllAsync(GetConnectionsRequest request, PaginationInfo pagination = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates a connection.
    /// </summary>
    /// <param name="id">The id of the connection to update.</param>
    /// <param name="request">The <see cref="ConnectionUpdateRequest"/> containing the properties of the connection you wish to update.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>The <see cref="Connection"/> that has been updated.</returns>
    Task<Connection> UpdateAsync(string id, ConnectionUpdateRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves the status of an ad/ldap connection.
    /// </summary>
    /// <param name="id">ID of the connection to check.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>A <see cref="Task"/> that represents the asynchronous check operation. Will throw if the status check fails.</returns>
    Task CheckAsync(string id, CancellationToken cancellationToken = default);
  }
}

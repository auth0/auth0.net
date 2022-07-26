namespace Auth0.ManagementApi.Clients
{
  using System.Collections.Generic;
  using System.Threading;
  using System.Threading.Tasks;
  using Models;

  public interface ILogStreamsClient
  {
    /// <summary>
    /// Gets all of the log streams
    /// </summary>
    /// <returns>A list of <see cref="LogStream"/> objects</returns>
    Task<IList<LogStream>> GetAllAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets a log stream
    /// </summary>
    /// <param name="id">The id of the log stream to get</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>A <see cref="LogStream"/> object</returns>
    Task<LogStream> GetAsync(string id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates a new log stream
    /// </summary>
    /// <param name="request">The <see cref="LogStreamCreateRequest"/> containing the information needed to create the log stream</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>A <see cref="Task"/> that represents the  asynchronous create operation.</returns>
    Task<LogStream> CreateAsync(LogStreamCreateRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a log stream
    /// </summary>
    /// <param name="id">The id of the log stream to delete</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>A <see cref="Task"/> that represents the asynchronous delete operation.</returns>
    Task DeleteAsync(string id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates a log stream
    /// </summary>
    /// <param name="id">The id of the log stream to update</param>
    /// <param name="request">The information required to update the log stream</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>The updated <see cref="LogStream"/> object</returns>
    Task<LogStream> UpdateAsync(string id, LogStreamUpdateRequest request, CancellationToken cancellationToken = default);
  }
}

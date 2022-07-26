namespace Auth0.ManagementApi.Clients
{
  using System.Threading;
  using System.Threading.Tasks;
  using Models;
  using Paging;

  public interface ILogsClient
  {
    /// <summary>
    /// Retrieves log entries that match the specified search criteria.
    /// </summary>
    /// <param name="request">Specifies criteria to use when querying logs.</param>
    /// <param name="pagination">Specifies pagination info to use when requesting paged results.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>An <see cref="IPagedList{LogEntry}"/> containing the list of log entries.</returns>
    Task<IPagedList<LogEntry>> GetAllAsync(GetLogsRequest request, PaginationInfo pagination = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves the data related to the log entry identified by id. This returns a single log entry representation as specified in the schema.
    /// </summary>
    /// <param name="id">The identifier of the log entry to retrieve.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>A <see cref="LogEntry"/> instance containing the information about the log entry.</returns>
    Task<LogEntry> GetAsync(string id, CancellationToken cancellationToken = default);
  }
}

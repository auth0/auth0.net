namespace Auth0.ManagementApi.Clients
{
  using System;
  using System.Collections.Generic;
  using System.Threading;
  using System.Threading.Tasks;
  using Models;

  public interface IStatsClient
  {
    /// <summary>
    /// Gets the active users count (logged in during the last 30 days).
    /// </summary>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>The number of users that have logged in during the last 30 days.</returns>
    Task<long> GetActiveUsersAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets the daily stats for a particular period.
    /// </summary>
    /// <param name="from">The first day of the period (inclusive).</param>
    /// <param name="to">The last day of the period (inclusive).</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>A list of <see cref="DailyStatistics"/> containing the statistics for each day in the period.</returns>
    Task<IList<DailyStatistics>> GetDailyStatsAsync(DateTime from, DateTime to, CancellationToken cancellationToken = default);
  }
}

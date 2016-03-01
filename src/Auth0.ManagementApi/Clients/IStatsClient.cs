using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Auth0.Core;

namespace Auth0.ManagementApi.Clients
{
    /// <summary>
    /// Contains all the methods to call the /stats endpoints.
    /// </summary>
    public interface IStatsClient
    {
        /// <summary>
        ///     Gets the active users count (logged in during the last 30 days).
        /// </summary>
        /// <returns>The number of users.</returns>
        Task<long> GetActiveUsersAsync();

        /// <summary>
        /// Gets the daily stats for a particular period.
        /// </summary>
        /// <param name="from">The first day of the period (inclusive).</param>
        /// <param name="to">The last day of the period (inclusive).</param>
        /// <returns>A list of <see cref="DailyStatistics"/> containing the statistics for each day in the period.</returns>
        Task<IList<DailyStatistics>> GetDailyStatsAsync(DateTime from, DateTime to);

        #region Obsolete Methods
        #pragma warning disable 1591

        [Obsolete("Use GetActiveUsersAsync instead")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        Task<long> GetActiveUsers();

        [Obsolete("Use GetDailyStatsAsync instead")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        Task<IList<DailyStatistics>> GetDailyStats(DateTime from, DateTime to);

        #pragma warning restore 1591
        #endregion
    }
}
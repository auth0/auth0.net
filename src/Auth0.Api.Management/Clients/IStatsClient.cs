using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Auth0.Core.Models;

namespace Auth0.Api.Management.Clients
{
    public interface IStatsClient
    {
        /// <summary>
        ///     Gets the active users count (logged in during the last 30 days).
        /// </summary>
        /// <returns>The number of users.</returns>
        Task<long> GetActiveUsers();

        /// <summary>
        /// Gets the daily stats for a particular period.
        /// </summary>
        /// <param name="from">The first day of the period (inclusive).</param>
        /// <param name="to">The last day of the period (inclusive).</param>
        /// <returns>A list of <see cref="DailyStatistics"/> containing the statistics for each day in the period.</returns>
        Task<IList<DailyStatistics>> GetDailyStats(DateTime from, DateTime to);
    }
}
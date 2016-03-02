using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Auth0.Core;
using Auth0.Core.Http;

namespace Auth0.ManagementApi.Clients
{
    /// <summary>
    /// Contains all the methods to call the /stats endpoints.
    /// </summary>
    public class StatsClient :  ClientBase, IStatsClient
    {
        /// <summary>
        /// Creates a new instance of the ClientBase class.
        /// </summary>
        /// <param name="connection">The <see cref="IApiConnection" /> which is used to communicate with the API.</param>
        public StatsClient(IApiConnection connection)
            : base(connection)
        {
        }

        /// <summary>
        /// Gets the active users count (logged in during the last 30 days).
        /// </summary>
        /// <returns>The number of users.</returns>
        public async Task<long> GetActiveUsersAsync()
        {
            var result = await Connection.GetAsync<object>("stats/active-users", null, null, null, null);

            return Convert.ToInt64(result);
        }


        /// <summary>
        /// Gets the daily stats for a particular period.
        /// </summary>
        /// <param name="from">The first day of the period (inclusive).</param>
        /// <param name="to">The last day of the period (inclusive).</param>
        /// <returns>A list of <see cref="DailyStatistics" /> containing the statistics for each day in the period.</returns>
        public Task<IList<DailyStatistics>> GetDailyStatsAsync(DateTime from, DateTime to)
        {
            return Connection.GetAsync<IList<DailyStatistics>>("stats/daily", null, 
                new Dictionary<string, string>
                {
                    { "from", @from.ToString("yyyyMMdd") },
                    { "to", to.ToString("yyyyMMdd") }
                }, null, null);
        }

        #region Obsolete Methods
#pragma warning disable 1591

        [Obsolete("Use GetActiveUsersAsync instead")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Task<long> GetActiveUsers()
        {
            return GetActiveUsersAsync();
        }

        [Obsolete("Use GetDailyStatsAsync instead")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Task<IList<DailyStatistics>> GetDailyStats(DateTime from, DateTime to)
        {
            return GetDailyStatsAsync(from, to);
        }

#pragma warning restore 1591
        #endregion
    }
}
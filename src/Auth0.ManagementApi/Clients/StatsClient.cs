using Auth0.Core.Http;
using Auth0.ManagementApi.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Auth0.ManagementApi.Clients
{
    /// <summary>
    /// Contains all the methods to call the /stats endpoints.
    /// </summary>
    public class StatsClient : ClientBase
    {
        /// <summary>
        /// Creates a new instance of <see cref="StatsClient"/>.
        /// </summary>
        /// <param name="connection">The <see cref="IApiConnection" /> which is used to communicate with the API.</param>
        public StatsClient(IApiConnection connection)
            : base(connection)
        {
        }

        /// <summary>
        /// Gets the active users count (logged in during the last 30 days).
        /// </summary>
        /// <returns>The number of users that have logged in during the last 30 days.</returns>
        public async Task<long> GetActiveUsersAsync()
        {
            var result = await Connection.RunAsync<object>(HttpMethod.Get, "stats/active-users").ConfigureAwait(false);

            return Convert.ToInt64(result);
        }

        /// <summary>
        /// Gets the daily stats for a particular period.
        /// </summary>
        /// <param name="from">The first day of the period (inclusive).</param>
        /// <param name="to">The last day of the period (inclusive).</param>
        /// <returns>A list of <see cref="DailyStatistics"/> containing the statistics for each day in the period.</returns>
        public Task<IList<DailyStatistics>> GetDailyStatsAsync(DateTime from, DateTime to)
        {
            return Connection.RunAsync<IList<DailyStatistics>>(HttpMethod.Get, "stats/daily", queryStrings:
                new Dictionary<string, string>
                {
                    { "from", from.ToString("yyyyMMdd") },
                    { "to", to.ToString("yyyyMMdd") }
                });
        }
    }
}
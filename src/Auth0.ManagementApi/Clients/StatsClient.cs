using Auth0.ManagementApi.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Auth0.ManagementApi.Clients
{
    /// <summary>
    /// Contains methods to access the /stats endpoints.
    /// </summary>
    public class StatsClient : BaseClient, IStatsClient
    {
        /// <summary>
        /// Initializes a new instance of <see cref="StatsClient"/>.
        /// </summary>
        /// <param name="connection"><see cref="IManagementConnection"/> used to make all API calls.</param>
        /// <param name="baseUri"><see cref="Uri"/> of the endpoint to use in making API calls.</param>
        /// <param name="defaultHeaders">Dictionary containing default headers included with every request this client makes.</param>
        public StatsClient(IManagementConnection connection, Uri baseUri, IDictionary<string, string> defaultHeaders)
            : base(connection, baseUri, defaultHeaders)
        {
        }

        /// <summary>
        /// Gets the active users count (logged in during the last 30 days).
        /// </summary>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The number of users that have logged in during the last 30 days.</returns>
        public Task<long> GetActiveUsersAsync(CancellationToken cancellationToken = default)
        {
            return Connection.GetAsync<long>(BuildUri("stats/active-users"), DefaultHeaders, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Gets the daily stats for a particular period.
        /// </summary>
        /// <param name="from">The first day of the period (inclusive).</param>
        /// <param name="to">The last day of the period (inclusive).</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>A list of <see cref="DailyStatistics"/> containing the statistics for each day in the period.</returns>
        public Task<IList<DailyStatistics>> GetDailyStatsAsync(DateTime from, DateTime to, CancellationToken cancellationToken = default)
        {
            return Connection.GetAsync<IList<DailyStatistics>>(BuildUri("stats/daily",
                new Dictionary<string, string>
                {
                    { "from", from.ToString("yyyyMMdd") },
                    { "to", to.ToString("yyyyMMdd") }
                }), DefaultHeaders, cancellationToken: cancellationToken);
        }
    }
}
